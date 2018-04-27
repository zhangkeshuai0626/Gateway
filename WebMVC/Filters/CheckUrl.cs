using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebMVC.Filters
{
    /// <summary>
    /// 检测链接是否盗用
    /// </summary>
    public class CheckUrl : ActionFilterAttribute
    {
        public CheckUrl() { }
        public CheckUrl(bool ignore)
        {
            this.Ignore = ignore;
        }

        /// <summary>
        /// 是否要忽略过滤
        /// </summary>
        public bool Ignore { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (!Ignore)
            {
                Uri urlRefer = filterContext.HttpContext.Request.UrlReferrer;
                Uri url = filterContext.HttpContext.Request.Url;
                if (urlRefer == null || url == null || urlRefer.Host != url.Host)
                {
                    filterContext.HttpContext.Response.Write("<h2>连接错误!</h2>");
                    filterContext.Result = new ContentResult();
                }
            }
        }
    }
}