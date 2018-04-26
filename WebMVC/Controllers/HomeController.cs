using DFlow.Web.Controllers;
using Models;
using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public override ActionResult Index()
        {
            var db = DbGatewayContext.CreateDbContext();

            Employee emp = new Employee()
            {
                EmployeeId = Util.HashGuid,
                CreateBy = Util.HashGuid,
                Birthday = DateTime.Now,
                CreateTime = Util.Now,
                DepartmentId = Util.HashGuid,
                EmployeeAddress = "陕西",
                EmployeeName = "张三",
                EmployeeNo = "001",
                Email = "540279671@qq.com",
                Enable = true,
                JobId = Util.HashGuid,
                LoginAccount = "admin",
                LoginPassword = "1",
                Sex = 1
            };
            db.Set<Employee>().Add(emp);
            int n = db.SaveChanges();

            return View(emp);
        }
    }
}