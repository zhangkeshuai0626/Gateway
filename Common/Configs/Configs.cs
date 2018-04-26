using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Configs
{
    /// <summary>
    /// 默认密码
    /// </summary>
    public static readonly string DEFAULT_PASSWORD = "1";
    /// <summary>
    /// IIS根目录
    /// </summary>
    public static readonly string IIS_DIRECTORY = "";
    /// <summary>
    /// 地址栏中应用程序参数名称
    /// </summary>
    public static readonly string APPID = "AppId";
    /// <summary>
    /// 时间日期字符串
    /// </summary>
    public static readonly string DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";
    /// <summary>
    /// 允许上传的文件类型
    /// </summary>
    public static readonly string[] ALLOW_FILE_TYPE = ConfigurationManager.AppSettings["AllowUploadFileType"].Split(',');
    /// <summary>
    /// Gateway 数据库实体缓存键
    /// </summary>
    public const string GATEWAY_ITEM = "GatewayEntity";
    /// <summary>
    /// Gateway 数据库实体缓存键
    /// </summary>
    public const string DBHELPER_ITEM = "DbHelper";

}

