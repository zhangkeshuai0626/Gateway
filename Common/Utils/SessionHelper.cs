
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common.Utils
{
    public static class SessionHelper
    {
        /// <summary>
        /// 获取Session
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object Get(Key.SessionKey key)
        {
            string name = key.ToString();
            return HttpContext.Current.Session[name];
        }

        /// <summary>
        /// 保存用户Session
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="data"></param>
        public static void Insert(Key.SessionKey sessionKey, object data)
        {
            string key = sessionKey.ToString();
            HttpContext.Current.Session[key] = data;
        }
        /// <summary>
        /// 移除Session
        /// </summary>
        /// <param name="sessionKey"></param>
        public static void Remove(Key.SessionKey sessionKey)
        {
            string key = sessionKey.ToString();
            HttpContext.Current.Session.Remove(key);
        }
    }
}
