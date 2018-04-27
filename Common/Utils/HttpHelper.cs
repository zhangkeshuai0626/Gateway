using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common.Utils
{
    public class HttpHelper
    {
        private HttpHelper() { }
        /// <summary>
        /// 获取缓存在当前请求上下文中的对象
        /// </summary>
        /// <param name="itemkey"></param>
        /// <returns></returns>
        public static object GetHttpContextItem(string name)
        {
            if (name.IsNullOrEmpty())
            {
                return null;
            }
            return HttpContext.Current.Items[name];
        }
        public static void SetHttpContextItem(string name, object obj)
        {
            HttpContext.Current.Items[name] = obj;
        }
        //public static IEnumerable<ShowError> AllModelStateErrors(this ModelStateDictionary modelState)
        //{
        //    var result = new List<ShowError>();
        //    //找到出错的字段以及出错信息
        //    var errorFieldsAndMsgs = modelState.Where(m => m.Value.Errors.Any())
        //        .Select(x => new { x.Key, x.Value.Errors });
        //    foreach (var item in errorFieldsAndMsgs)
        //    {
        //        //获取键
        //        var fieldKey = item.Key;
        //        //获取键对应的错误信息
        //        var fieldErrors = item.Errors
        //            .Select(e => new ShowError(fieldKey, e.ErrorMessage));
        //        result.AddRange(fieldErrors);
        //    }
        //    return result;
        //}
    }
}
