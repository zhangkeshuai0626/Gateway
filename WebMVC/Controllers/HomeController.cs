using DFlow.Web.Controllers;
using Models;
using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Filters;

namespace WebMVC.Controllers
{
    public class HomeController : BaseController
    {
        [CheckUrl(true)]
        public override ActionResult Index()
        {
            return View();
        }
    }
}