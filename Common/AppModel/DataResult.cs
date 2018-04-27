using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.AppModel
{
    /// <summary>
    /// 数据模型类,用于数据交互
    /// </summary>
    public class DataModel
    {
        /// <summary>
        /// 执行结果
        /// </summary>
        public bool Flag { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 数据内容
        /// </summary>
        public object Content { get; set; }
    }
}
