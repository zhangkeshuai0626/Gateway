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


            return View();
        }
    }
}