using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Key
{
    private Key() { }
    /// <summary>
    /// Session键
    /// </summary>
    public enum SessionKey
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

}

