using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DbModels
{
    /// <summary>
    /// 用户Session类
    /// </summary>
    public class LoginSessionModel
    {
        /// <summary>
        /// 当前用户的登陆信息
        /// </summary>
        public Login Account { get; set; }
        /// <summary>
        /// 员工信息
        /// </summary>
        public Employee Employee { get; set; }
        /// <summary>
        /// 部门信息
        /// </summary>
        public Department Department { get; set; }
        /// <summary>
        /// 职务信息
        /// </summary>
        public Role Role { get; set; }
        /// <summary>
        /// 应用程序信息
        /// </summary>
        public List<Application> Applications { get; set; }
        /// <summary>
        /// 应用程序Id
        /// </summary>
        public List<string> AppIds { get; set; }
    }
}
