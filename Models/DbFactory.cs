using Common.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DbFactory
    {
        /// <summary>
        /// 获取线程内唯一的DbContext
        /// </summary>
        /// <returns></returns>
        public static DbContext CreateDbContext()
        {

            DbContext dbContext = HttpHelper.GetHttpContextItem(Configs.GATEWAY_ITEM) as DbContext;
            if (dbContext == null)
            {
                dbContext = new DbGatewayContext();
                HttpHelper.SetHttpContextItem(Configs.GATEWAY_ITEM, dbContext);
            }
            return dbContext;
        }
    }
}
