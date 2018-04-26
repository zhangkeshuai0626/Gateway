using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Common.Utils
{
    /// <summary>
    /// 日志级别
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// 调试
        /// </summary>
        Debug,
        /// <summary>
        /// 提示
        /// </summary>
        Info,
        /// <summary>
        /// 警告
        /// </summary>
        Warn,
        /// <summary>
        /// 错误
        /// </summary>
        Error,
        /// <summary>
        /// 严重错误
        /// </summary>
        Fatal
    }
    public sealed class LogHelper
    {
        private LogHelper() { }
        private static readonly ILog provider = GetLogger();
        static LogHelper() { }
        private static ILog GetLogger()
        {
            XmlConfigurator.Configure();
            return  log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
           // return LogManager.GetLogger("log4net");
        }
        /// <summary>
        /// 记录一条日志
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="logLevel">日志级别</param>
        /// <param name="ex">异常</param>
        public static void Write(string msg, LogLevel logLevel, Exception ex = null)
        {
            WriteLog(msg, logLevel, ex);
        }
        /// <summary>
        /// 初始化Log4Net
        /// </summary>
        public static void InitConfig()
        {
            XmlConfigurator.Configure();
        }
        /// <summary>
        /// 关闭Log4Net
        /// </summary>
        public static void ShutDown()
        {
            LogManager.Shutdown();
        }
        private static void WriteLog(string msg, LogLevel logLevel, Exception ex)
        {
            if (provider != null)
            {
                switch (logLevel)
                {
                    case LogLevel.Debug:
                        provider.Debug(msg, ex);
                        break;
                    case LogLevel.Info:
                        provider.Info(msg, ex);
                        break;
                    case LogLevel.Warn:
                        provider.Warn(msg, ex);
                        break;
                    case LogLevel.Error:
                        provider.Error(msg, ex);
                        break;
                    case LogLevel.Fatal:
                        provider.Fatal(msg, ex);
                        break;
                }
            }
        }

    }
}
