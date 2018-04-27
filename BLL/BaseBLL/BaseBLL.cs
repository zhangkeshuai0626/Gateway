using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Utils;
using Common.AppModel;

namespace BLL
{
    public class BaseBLL
    {
        /// <summary>
        /// 常用的操作工具类
        /// </summary>
        protected Utility Util = Utility.GetInstance();
        /// <summary>
        /// 返回一个数据模型
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="content"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        protected DataModel DataModel(bool flag = false, object content = null, string message = "")
        {
            return new DataModel()
            {
                Flag = flag,
                Content = content,
                Message = message
            };
        }
        /// <summary>
        /// 返回一个数据模型
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="content"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        protected DataModel DataModel(bool flag, string message)
        {
            return DataModel(flag, null, message);
        }
    }
}
