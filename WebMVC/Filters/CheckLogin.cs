using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;


namespace WebMVC.Filters
{
    /// <summary>
    /// 检测用户是否登陆
    /// </summary>
    public class CheckLogin : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //根据需要添加
            string controllerName = filterContext.RouteData.Values["controller"].ToString();
            string actionName = filterContext.RouteData.Values["action"].ToString();
            if (controllerName == Configs.DEFAULT_CONTROLLER && actionName == Configs.DEFAULT_VIEW)
            {
                ContentResult content = new ContentResult() { Content = "请登录" };
                filterContext.Result = content;
            }
            else
            {
                string defaultUrl = string.Format("/{0}/{1}/{2}", Configs.IIS_DIRECTORY, Configs.DEFAULT_CONTROLLER, Configs.DEFAULT_VIEW);
                filterContext.HttpContext.Server.Transfer(defaultUrl);
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            base.AuthorizeCore(httpContext);
            var loginInfoSession = httpContext.Session[Enumer.Session.LoginInfo.ToString()];
            if (loginInfoSession == null)
            {
                return false;
            }
            return true;
        }
    }
}