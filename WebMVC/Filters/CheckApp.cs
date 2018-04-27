
using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebMVC.Filters
{

    /// <summary>
    /// 检测用户的权限
    /// </summary>
    public class CheckApp : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string arg = filterContext.HttpContext.Request.QueryString[Enumer.Session.LoginInfo.ToString()];
            if (string.IsNullOrEmpty(arg))
            {
                filterContext.Result = new ContentResult() { Content = "无权访问" };
            }
            else
            {
                string key = Enumer.Session.LoginInfo.ToString();
                object obj = filterContext.HttpContext.Session[key];
                if (obj == null)
                {
                    filterContext.Result = new ContentResult() { Content = "无权访问" };
                }
                else
                {
                    LoginSessionModel sessionModel = obj as LoginSessionModel;
                    List<string> appIds = sessionModel.AppIds;
                    string appId = arg;
                    if (appIds == null || !appIds.Contains(appId))
                    {
                        filterContext.Result = new ContentResult() { Content = "无权访问" };
                    }
                }
            }
        }
    }
}