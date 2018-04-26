namespace DAL
{
    public class BaseDAL
    {
        /// <summary>
        /// 工具类
        /// </summary>
        public Common.Utils.Utility Util = Common.Utils.Utility.GetInstance();
        /// <summary>
        /// 数据库操作对象
        /// </summary>
        internal DbHelper DbHandler = DbHelper.GetDbHelper();
    }
}