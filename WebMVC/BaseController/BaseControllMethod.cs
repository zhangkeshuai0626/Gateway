
using Common.AppModel;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DFlow.Web.Controllers
{
    public partial class BaseController : Controller
    {
        /// <summary>
        /// 获取bootstrap请求参数
        /// </summary>
        /// <returns></returns>
        protected PageModel GetParams()
        {
            if (Request != null)
            {
                PageModel p = new PageModel();
                string offset = Request.Params["offset"] ?? "0";
                string size = Request.Params["limit"] ?? "0";
                p.Offset = Convert.ToInt32(offset);
                p.Size = Convert.ToInt32(size);
                if (!Request["sort"].IsNullOrEmpty())
                {
                    p.Sort = new List<string>();
                    string[] sort = Request["sort"].Split(',');
                    p.Sort.AddRange(sort);
                }
                if (Request["order"] != null)
                {
                    p.Order = new List<bool>();
                    string[] Sort = Request["Sort"].Split(',');
                    foreach (var item in Sort)
                    {
                        if (item.ToLower() == "asc")
                        {
                            p.Order.Add(true);
                        }
                        else
                        {
                            p.Order.Add(false);
                        }
                    }
                }
                return p;
            }
            return null;
        }
        /// <summary>
        /// 返回一个BadRequest 异常400
        /// </summary>
        /// <returns></returns>
        protected ActionResult BadRequest()
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        /// <summary>
        /// 返回一个404异常
        /// </summary>
        /// <returns></returns>
        protected ActionResult NotFound()
        {
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }
        /// <summary>
        /// 返回一个405
        /// </summary>
        /// <returns></returns>
        protected ActionResult MethodNotAllowed()
        {
            return new HttpStatusCodeResult(HttpStatusCode.MethodNotAllowed);
        }
        /// <summary>
        /// 返回Json类型,基于Json.net
        /// </summary>
        /// <param name="data"></param>
        /// <param name="contentType"></param>
        /// <param name="contentEncoding"></param>
        /// <param name="behavior"></param>
        /// <returns></returns>
        protected JsonResult JsonNet(object data, string contentType = "", Encoding contentEncoding = null)
        {
            return new MyJson { Data = data, ContentType = contentType, ContentEncoding = contentEncoding };
        }
    }

    public class MyJson : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            var jsonSerizlizerSetting = new JsonSerializerSettings();
            //设置取消循环引用
            jsonSerizlizerSetting.MissingMemberHandling = MissingMemberHandling.Ignore;
            //设置首字母小写
            //  jsonSerizlizerSetting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //设置日期的格式为：yyyy-MM-dd
            jsonSerizlizerSetting.DateFormatString = Configs.DATETIME_FORMAT;
            var json = JsonConvert.SerializeObject(Data, Formatting.None, jsonSerizlizerSetting);
            response.Write(json);
        }
    }
}