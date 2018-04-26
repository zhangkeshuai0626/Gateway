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
    public class DbHelper<T> where T : DbBaseModel
    {
        private DbHelper() { }
        /// <summary>
        /// 当前上下文唯一的数据库上下文
        /// </summary>
        public DbContext GatewayDb
        {
            get
            {
                return DbGatewayContext.CreateDbContext();
            }
        }
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public T[] AddOrUpdate(params T[] models)
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
        public bool Exist(Expression<Func<T, bool>> whereLambda)
        {
            return GatewayDb.Set<T>().AsNoTracking().Any(whereLambda);
        }
        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <param name="asNotracking"></param>
        /// <returns></returns>
        public T Get(Expression<Func<T, bool>> whereLambda, bool asNotracking = false)
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
        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda, bool asNotracking = false)
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
        /// <param name="orderByLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> Page<Ttype>(int skip, int take, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, Ttype>> orderByLambda, bool isAsc)
        {
            IQueryable<T> result = null;
            var set = this.GetModels(whereLambda);
            total = set.AsEnumerable().Count();
            if (isAsc)
            {
                result = set.OrderBy(orderByLambda).Skip(skip).Take(take);
            }
            else
            {
                result = set.OrderByDescending(orderByLambda).Skip(skip).Take(take);
            }
            return result;
        }
        /// <summary>
        /// 提交改变
        /// </summary>
        /// <returns></returns>
        public int SaveChange()
        {
            return GatewayDb.SaveChanges();
        }
        /// <summary>
        /// 执行一条sql查询
        /// </summary>
        /// <typeparam name="ReturnType"></typeparam>
        /// <param name="sql"></param>
        /// <param name="paramters"></param>
        /// <returns></returns>
        public DbRawSqlQuery<ReturnType> SqlQuery<ReturnType>(string sql, params object[] paramters)
        {
            return GatewayDb.Database.SqlQuery<ReturnType>(sql, paramters);
        }
        /// <summary>
        /// 执行一条sql指令
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramters"></param>
        /// <returns></returns>
        public int ExecuteSqlCommand(string sql, params object[] paramters)
        {
            return GatewayDb.Database.ExecuteSqlCommand(sql, paramters);

        }

    }
}
