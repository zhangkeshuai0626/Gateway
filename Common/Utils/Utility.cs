using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Common.Utils
{
    /// <summary>
    /// 常用工具类,单例模式
    /// </summary>
    public class Utility
    {
        private Utility() { }
        private static Utility Instance = new Utility();
        /// <summary>
        /// 生成一个GUID的md5值
        /// </summary>
        public string HashGuid
        {
            get
            {
                string code = Guid.NewGuid() + DateTime.Now.ToString();
                return code.MD5Code();
            }
        }
        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }

        public static Utility GetInstance()
        {
            return Instance;
        }
        /// <summary>
        ///  md5密码加密法
        /// </summary>
        /// <param name="s">需要加密的密码</param>
        /// <returns></returns>
        public string EncodePassword(string str)
        {
            if (str.IsNullOrEmpty())
            {
                return string.Empty;
            }
            string code = "dh.aspnet" + str;
            string result = code.MD5Code().MD5Code();
            return result;
        }
        /// <summary>
        /// 过滤SQl语句
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public string SqlFilter(string source)
        {
            if (source.IsNullOrEmpty())
            {
                return "";
            }
            source = FilteSQLStr(source);
            source = FilteSQLScript(source);
            source = ReplaceSQLChar(source);
            return source;
        }
        /// <summary>
        /// 过滤SQL字符 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string ReplaceSQLChar(string str)
        {
            if (str == String.Empty)
                return String.Empty; str = str.Replace("'", "‘");
            str = str.Replace(";", "；");
            str = str.Replace(",", ",");
            str = str.Replace("?", "?");
            str = str.Replace("<", "＜");
            str = str.Replace(">", "＞");
            str = str.Replace("(", "(");
            str = str.Replace(")", ")");
            str = str.Replace("@", "＠");
            str = str.Replace("=", "＝");
            str = str.Replace("+", "＋");
            str = str.Replace("*", "＊");
            str = str.Replace("&", "＆");
            str = str.Replace("#", "＃");
            str = str.Replace("%", "％");
            str = str.Replace("$", "￥");
            return str;
        }

        /// <summary>
        /// 过滤SQl脚本
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private string FilteSQLScript(string source)
        {
            //单引号替换成两个单引号
            source = source.Replace("'", "''");

            //半角封号替换为全角封号，防止多语句执行
            source = source.Replace(";", "；");

            //半角括号替换为全角括号
            source = source.Replace("(", "（");
            source = source.Replace(")", "）");

            ///用正则表达式替换，防止字母大小写得情况
            //去除执行存储过程的命令关键字
            source = source.Replace("Exec", "");
            source = source.Replace("Execute", "");

            //去除系统存储过程或扩展存储过程关键字
            source = source.Replace("xp_", "x p_");
            source = source.Replace("sp_", "s p_");

            //防止16进制注入
            source = source.Replace("0x", "0 x");

            return source;
        }
        /// <summary>
        /// 过滤SQL关键字
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        private string FilteSQLStr(string Str)
        {

            Str = Str.Replace("'", "");
            Str = Str.Replace("\"", "");
            Str = Str.Replace("&", "&amp");
            Str = Str.Replace("<", "&lt");
            Str = Str.Replace(">", "&gt");
            Str = Str.Replace("delete", "");
            Str = Str.Replace("update", "");
            Str = Str.Replace("insert", "");
            return Str;
        }
    }
}
