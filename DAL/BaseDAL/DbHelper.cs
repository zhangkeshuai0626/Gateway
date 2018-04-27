using Common.Utils;
using DAL;
using Models;
using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class DbHelper
    {
        private DbHelper() { }
        /// <summary>
        /// 当前上下文唯一的数据库上下文
        /// </summary>
        internal DbContext GatewayDb
        {
            get
            {
                return DbFactory.CreateDbContext();
            }
        }
        /// <summary>
        /// 执行一条sql查询
        /// </summary>
        /// <typeparam name="ReturnType"></typeparam>
        /// <param name="sql"></param>
        /// <param name="paramters"></param>
        /// <returns></returns>
        internal DbRawSqlQuery<ReturnType> SqlQuery<ReturnType>(string sql, params object[] paramters)
        {
            return GatewayDb.Database.SqlQuery<ReturnType>(sql, paramters);
        }
        /// <summary>
        /// 执行一条sql指令
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramters"></param>
        /// <returns></returns>
        internal int ExecuteSqlCommand(string sql, params object[] paramters)
        {
            return GatewayDb.Database.ExecuteSqlCommand(sql, paramters);
        }
        /// <summary>
        /// 提交改变
        /// </summary>
        /// <returns></returns>
        internal int SaveChange()
        {
            return GatewayDb.SaveChanges();
        }

        #region 泛型方法

        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        internal T[] AddOrUpdate<T>(params T[] models) where T : DbBaseModel
        {
            if (models != null)
            {
                GatewayDb.Set<T>().AddOrUpdate(models);
            }
            return models;
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        internal bool Exist<T>(Expression<Func<T, bool>> whereLambda) where T : DbBaseModel
        {

            return GatewayDb.Set<T>().AsNoTracking().Any(whereLambda);
        }
        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <param name="asNotracking"></param>
        /// <returns></returns>
        internal T Get<T>(Expression<Func<T, bool>> whereLambda, bool asNotracking = false) where T : DbBaseModel
        {
            var set = GatewayDb.Set<T>();
            if (asNotracking)
            {
                return set.FirstOrDefault(whereLambda);
            }
            else
            {
                return set.AsNoTracking().FirstOrDefault(whereLambda);
            }
        }
        /// <summary>
        /// 获取多条记录
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <param name="asNotracking"></param>
        /// <returns></returns>
        internal IQueryable<T> GetModels<T>(Expression<Func<T, bool>> whereLambda, bool asNotracking = false) where T : DbBaseModel
        {
            var set = GatewayDb.Set<T>();
            if (asNotracking)
            {
                return set.Where(whereLambda);
            }
            else
            {
                return set.AsNoTracking().Where(whereLambda);
            }
        }

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <typeparam name="Ttype"></typeparam>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="total"></param>
        /// <param name="whereLambda"></param>
        /// <param name="SortByLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        internal IQueryable<T> Page<T, Ttype>(int skip, int take, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, Ttype>> SortByLambda, bool isAsc) where T : DbBaseModel
        {
            IQueryable<T> result = null;
            var set = this.GetModels(whereLambda);
            total = set.AsEnumerable().Count();
            if (isAsc)
            {
                result = set.OrderBy(SortByLambda).Skip(skip).Take(take);
            }
            else
            {
                result = set.OrderByDescending(SortByLambda).Skip(skip).Take(take);
            }
            return result;
        }
        #endregion
    }
}
