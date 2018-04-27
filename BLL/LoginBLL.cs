using Common.AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALContainer;
using IDAL;
using Models.DbModels;
using Common.Utils;

namespace BLL
{
    public class LoginBLL : BaseBLL
    {
        ILoginDAL LoginDAL = Container.Resolve<ILoginDAL>();
        IApplicationDAL ApplicationDAL = Container.Resolve<IApplicationDAL>();
        IRoleDAL RoleDAL = Container.Resolve<IRoleDAL>();
        IDepartmentRoleDAL DepartmentRoleDAL = Container.Resolve<IDepartmentRoleDAL>();
        IEmployeeDAL EmployeeDAL = Container.Resolve<IEmployeeDAL>();
        IEmployeeApplicationDAL EmployeeApplicationDAL = Container.Resolve<IEmployeeApplicationDAL>();
        IDepartmentDAL DepartmentDAL = Container.Resolve<IDepartmentDAL>();
        IDepartmentApplicationDAL DepartmentApplicationDAL = Container.Resolve<IDepartmentApplicationDAL>();
        IDepartmentRoleApplicationDAL DepartmentRoleApplicationDAL = Container.Resolve<IDepartmentRoleApplicationDAL>();
        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="loginAccount"></param>
        /// <param name="loginPassword"></param>
        /// <returns></returns>
        public DataModel Login(string loginAccount, string loginPassword)
        {

            string password = Util.EncodePassword(loginPassword);
            Login account = LoginDAL.Get(u => u.LoginAccount == loginAccount && u.LoginPassword == password);
            if (account == null)
            {
                return DataModel(false, "帐号或密码错误");
            }
            else
            {
                //保存Session
                SaveLoginSession(account);
                return DataModel(true);
            }
        }

        private void SaveLoginSession(Login account)
        {
            Employee employee = EmployeeDAL.Get(u => u.Enable && u.EmployeeId == account.EmployeeId);
            if (employee == null)
            {
                return;
            }
            //Session模型
            LoginSessionModel sessionModel = new LoginSessionModel();
            //用户的权限id集合
            List<string> applist = new List<string>();
            //1.获取用户登录信息
            applist.AddRange(GetUserSession(ref sessionModel, account, employee));
            //2. 获取用户的部门信息
            applist.AddRange(GetDepartmentSession(ref sessionModel, employee));
            //3. 获取用户的部门岗位信息
            applist.AddRange(GetRoleSession(ref sessionModel, employee));

            //4. 保存用户的应用权限
            if (!applist.IsNullOrEmpty())
            {
                applist = applist.Distinct().ToList();
                var applications = ApplicationDAL.GetModels(u => u.Enable && applist.Contains(u.ApplicationId)).ToList();
                sessionModel.Applications = applications;
            }
            sessionModel.AppIds = applist;
            SessionHelper.Set(Enumer.Session.LoginInfo, sessionModel);
        }
        /// <summary>
        /// 保存角色信息和权限
        /// </summary>
        /// <param name="sessionModel"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        private IEnumerable<string> GetRoleSession(ref LoginSessionModel sessionModel, Employee employee)
        {
            List<string> list = new List<string>();
            //部门或角色为空,
            if (employee.RoleId.IsNullOrEmpty() || employee.DepartmentId.IsNullOrEmpty())
            {
                return list;
            }
            else
            {
                var RoleDept = DepartmentRoleDAL.Get(u => u.Enable && u.DepartmentId == employee.DepartmentId && u.RoleId == employee.RoleId);
                if (RoleDept == null)
                {
                    return list;
                }
                var Role = RoleDAL.Get(u => u.Enable && u.RoleId == RoleDept.RoleId);
                if (Role == null)
                {
                    return list;
                }
                sessionModel.Role = Role;
                var appList = DepartmentRoleApplicationDAL.GetModels(u => u.Enable && u.DepartmentId == employee.DepartmentId && u.RoleId == employee.RoleId).Select(u => u.ApplicationId);
                if (appList.IsNullOrEmpty())
                {
                    return list;
                }
                else
                {
                    return list = appList.ToList();
                }
            }
        }
        /// <summary>
        /// 保存部门信息和角色权限
        /// </summary>
        /// <param name="sessionModel"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        private IEnumerable<string> GetDepartmentSession(ref LoginSessionModel sessionModel, Employee employee)
        {
            List<string> list = new List<string>();
            if (employee.DepartmentId.IsNullOrEmpty())
            {
                return list;
            }
            else
            {
                var dept = DepartmentDAL.Get(u => u.DepartmentId == employee.DepartmentId);
                if (dept != null)
                {
                    sessionModel.Department = dept;
                    var appList = DepartmentApplicationDAL.GetModels(u => u.Enable && u.DepartmentId == employee.DepartmentId).Select(u => u.ApplicationId);
                    if (!appList.IsNullOrEmpty())
                    {
                        list = appList.ToList();
                    }
                }
                return list;
            }
        }
        /// <summary>
        /// 保存用户基本信息和登陆信息
        /// </summary>
        /// <param name="sessionModel"></param>
        /// <param name="account"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        private IEnumerable<string> GetUserSession(ref LoginSessionModel sessionModel, Login account, Employee employee)
        {
            //不保存登陆密码信息
            account.LoginPassword = "";
            account.Salt = "";

            sessionModel.Account = account;

            List<string> list = new List<string>();
            //获取员工基本信息
            sessionModel.Employee = employee;
            //获取员工的应用程序权限
            var appids = EmployeeApplicationDAL.GetModels(u => u.Enable && u.EmployeeId == employee.EmployeeId).Select(u => u.ApplicationId);

            if (!appids.IsNullOrEmpty())
            {
                list = appids.ToList();
            }
            return list;
        }
    }
}
