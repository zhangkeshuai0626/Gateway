using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AppModels
{
    /// <summary>
    /// 分页参数模型
    /// </summary>
    public class PageModel
    {
        /// <summary>
        /// 偏移量
        /// </summary>
        public int Offset { get; set; }
        /// <summary>
        /// 分页大小
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public List<bool> Order { get; set; }
        /// <summary>
        /// 排序类型
        /// </summary>
        public List<string> Sort { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        [JsonProperty(PropertyName = "rows")]
        public object Rows { get; set; }
    }
}
