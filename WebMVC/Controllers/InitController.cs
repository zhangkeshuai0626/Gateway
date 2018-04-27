using BLL;
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
    public class InitController : BaseController
    {
        public ActionResult InitData()
        {
            return Content("数据初始化成功");
        }
    }
}