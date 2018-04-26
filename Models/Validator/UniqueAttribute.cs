using Common.Utils;
using Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validator
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class UniqueAttribute : ValidationAttribute
    {
        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 列名称
        /// </summary>
        public string ColumnName { get; set; }
        public override bool IsValid(object value)
        {
            //校验数据库是否存在当前Key
            if (value != null)
            {
                return Check(value);
            }
            return false;
        }

        private bool Check(object value)
        {

            if (TableName.IsNullOrEmpty() || ColumnName.IsNullOrEmpty())
            {
                return false;
            }
            else
            {
                string tableName = Util.GetInstance().SqlFilter(TableName);
                string columnName = Util.GetInstance().SqlFilter(ColumnName);
                string sql = string.Format("select count(1) from {0} where 1=1 and {1} = @p0 ", tableName, columnName);
                var db = DbGatewayContext.CreateDbContext();
                int n = db.Database.SqlQuery<int>(sql, value).FirstOrDefault();
                return n <= 0;
            }

        }
    }
}
