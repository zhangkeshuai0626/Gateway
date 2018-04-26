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
    }
}
