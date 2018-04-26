using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InitDAL : BaseDAL
    {
        public void InitDataBase()
        {
            //添加员工
            InsertEmployee();
            //添加部门
            InsertDepartment();
        }

        private void InsertDepartment()
        {
            Department[] depts = new Department[] {
                new Department() {
                    CreateBy=Util.HashGuid,
                    DepartmentId="1CB4F129D22E64E5527D28F7E590B897",
                    DepartmentName="三人行",
                    DepartmentCode="001",
                    Sort=1

                },
                  new Department() {
                    CreateBy=Util.HashGuid,
                    DepartmentId="7FE634EE70915C573340347B90DBC308",
                    DepartmentName="开发部",
                    DepartmentCode="001-001",
                    Sort=1

                },
                      new Department() {
                    CreateBy=Util.HashGuid,
                    DepartmentId="39251E37CA896471F73077080D3530F1",
                    DepartmentName="市场部",
                     DepartmentCode="001-002",
                    Sort=2

                },
                    new Department() {
                    CreateBy=Util.HashGuid,
                    DepartmentId="24B3900C01BAACCCB0F5FA8727EC97D3",
                    DepartmentName="后勤部",
                     DepartmentCode="001-003",
                    Sort=3
                },

            };
            DbHandler.AddOrUpdate(depts);
            int n = DbHandler.SaveChange();
        }

        private void InsertEmployee()
        {


            Employee[] emps = new Employee[]{
                new Employee()
                {
                    EmployeeId = Util.HashGuid,
                    CreateBy = Util.HashGuid,
                    Birthday = DateTime.Now.AddYears(-20),
                    CreateTime = Util.Now,
                    DepartmentId = "1CB4F129D22E64E5527D28F7E590B897",
                    EmployeeAddress = "陕西",
                    EmployeeName = "张大帅",
                    EmployeeNo = "001",
                    Enable = true,
                    RoleId = Util.HashGuid,
                    Sex = (int)Enumer.Sex.Male
                },
                new Employee()
                {
                    EmployeeId = Util.HashGuid,
                    CreateBy = Util.HashGuid,
                    Birthday = DateTime.Now.AddYears(-17),
                    CreateTime = Util.Now,
                    DepartmentId = "7FE634EE70915C573340347B90DBC308",
                    EmployeeAddress = "四川省",
                    EmployeeName = "张三丰",
                    EmployeeNo = "002",
                    Enable = true,
                    RoleId = Util.HashGuid,
                    Sex = (int)Enumer.Sex.FMale
                },
                 new Employee()
                {
                    EmployeeId = Util.HashGuid,
                    CreateBy = Util.HashGuid,
                    Birthday = DateTime.Now.AddYears(-23),
                    CreateTime = Util.Now,
                    DepartmentId = "39251E37CA896471F73077080D3530F1",
                    EmployeeAddress = "四川省",
                    EmployeeName = "邓大平",
                    EmployeeNo = "003",
                    Enable = true,
                    RoleId = Util.HashGuid,
                    Sex = (int)Enumer.Sex.Male
                },
                       new Employee()
                {
                    EmployeeId = Util.HashGuid,
                    CreateBy = Util.HashGuid,
                    Birthday = DateTime.Now.AddYears(-23),
                    CreateTime = Util.Now,
                    DepartmentId = "24B3900C01BAACCCB0F5FA8727EC97D3",
                    EmployeeAddress = "四川省",
                    EmployeeName = "安德明",
                    EmployeeNo = "004",
                    Enable = true,
                    RoleId = Util.HashGuid,
                    Sex = (int)Enumer.Sex.Male
                },

            };
            DbHandler.AddOrUpdate<Employee>(emps);
            int n = DbHandler.SaveChange();
        }
    }
}
