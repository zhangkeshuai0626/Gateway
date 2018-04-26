using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models.Validator
{
    /// <summary>
    /// 验证一个属性是否在数据字典表中
    /// </summary>
    public class EnumerAttribute : ValidationAttribute
    {
        private static int[] Numbers = new int[] { 30, 35, 23 };
        private string _dataType;
        /// <summary>
        /// 数据字典表中dataType
        /// </summary>
        /// <param name="dataType"></param>
        public EnumerAttribute(string dataType)
        {
            this._dataType = dataType;
        }
        public override bool IsValid(object value)
        {
            if (value is int)
            {
                int val = Convert.ToInt32(value);
                return Numbers.Any(u => u == val && _dataType == "666");
            }
            return false;
        }
    }
}