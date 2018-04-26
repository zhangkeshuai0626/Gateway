using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Enumer
{
    /// <summary>
    /// Session键
    /// </summary>
    public enum Session
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        LoginInfo = 1,
    }
    /// <summary>
    /// HttpItemKey
    /// </summary>
    public enum HttpItemKey
    {
        /// <summary>
        /// Gateway数据库实体
        /// </summary>
        GatewayEntity = 1,
    }
    /// <summary>
    /// 性别
    /// </summary>
    public enum Sex
    {
        /// <summary>
        /// 男
        /// </summary>
        Male = 1,
        /// <summary>
        /// 女
        /// </summary>
        FMale = 2,
    }
}

