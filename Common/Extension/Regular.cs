using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extension
{
    /// <summary>
    /// 常用正则表达式
    /// </summary>
    public static class Regular
    {
        /// <summary>
        /// 验证邮箱
        /// </summary>
        public const string Email = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        /// <summary>
        /// 验证正整数
        /// </summary>
        public const string Integer = @"^[0-9]*$";
        /// <summary>
        /// 数字类型,小数,整数,负数
        /// </summary>
        public const string Number = @"^(\-|\+)?\d+(\.\d+)?$";
        /// <summary>
        /// 验证汉字
        /// </summary>
        public const string Chinese = @"^[\u4e00-\u9fa5]{0,}$";
        /// <summary>
        /// 英文和数字
        /// </summary>
        public const string EnglishOrNumber = @"^[A-Za-z0-9]+$ 或 ^[A-Za-z0-9]{4,40}$";
        /// <summary>
        /// 域名
        /// </summary>
        public const string DomanName = @"[a-zA-Z0-9][-a-zA-Z0-9]{0,62}(/.[a-zA-Z0-9][-a-zA-Z0-9]{0,62})+/.?";
        /// <summary>
        /// url链接
        /// </summary>
        public const string Url = @"[a-zA-z]+://[^\s]* 或 ^http://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$";
        /// <summary>
        /// 验证电话号码,座机
        /// </summary>
        public const string TelPhone = @"^(\(\d{3,4}-)|\d{3.4}-)?\d{7,8}$ ";
        /// <summary>
        /// 验证手机号码
        /// </summary>
        public const string MobiePhone = @"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$";
        /// <summary>
        /// 腾讯QQ
        /// </summary>
        public const string QQ = @"[1-9][0-9]{4,}";
        /// <summary>
        /// IP地址
        /// </summary>
        public const string IP = @"\d+\.\d+\.\d+\.\d+";

    }
}
