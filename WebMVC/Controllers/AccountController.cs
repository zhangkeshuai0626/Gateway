using BLL;
using Common.AppModel;
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
    public class AccountController : BaseController
    {
        LoginBLL loginBLL  = new LoginBLL();
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login([Bind(Include = "LoginAccount,LoginPassword")] Login model)
        {
            if (model.LoginAccount.IsNullOrEmpty() || model.LoginPassword.IsNullOrEmpty())
            {
                return BadRequest();
            }
            else
            {
                DataModel dr = loginBLL.Login(model.LoginAccount, model.LoginPassword);
                return Json(dr);
            }

        }
        /// <summary>
        /// 用户注销
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginOut()
        {
            //1. 清除Session
            Session.RemoveAll();
            return RedirectToAction("Index", "Home", null);
        }
    }
}