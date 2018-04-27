using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;


namespace WebMVC.Filters
{
    /// <summary>
    /// 检测用户是否登陆
    /// </summary>
    public class CheckLogin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var loginInfoSession = filterContext.HttpContext.Session[Enumer.Session.LoginInfo.ToString()];
            if (loginInfoSession == null)
            {
                string defaultUrl = Configs.IIS_DIRECTORY + "/Home/Index";
                filterContext.Result = new RedirectResult(defaultUrl);
            }
        }
    }
}