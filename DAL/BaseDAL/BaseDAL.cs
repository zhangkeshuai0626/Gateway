using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Web;
using System.Net.Http;
using Models;
using IDAL;

namespace DAL
{
    public class BaseDAL : IBaseDAL
    {
        /// <summary>
        /// 工具类
        /// </summary>
        public Common.Utils.Utility Util = Common.Utils.Utility.GetInstance();
        /// <summary>
        /// 创建数据库上下文, 存入请求上下文容器,保证线程内唯一
        /// </summary>
        public DbContext DataContext
        {
            get
            {
                return DbFactory.CreateDbContext();
            }
        }

        public bool SaveChange()
        {
            return DataContext.SaveChanges() > 0;
        }

        public DbRawSqlQuery<ReturnType> SqlQuery<ReturnType>(string sql, params object[] paramters)
        {
            return DataContext.Database.SqlQuery<ReturnType>(sql, paramters);
        }
        public int ExecuteSqlCommand(string sql, params object[] paramters)
        {
            return DataContext.Database.ExecuteSqlCommand(sql, paramters);
        }
    }
    public class BaseDAL<T> : BaseDAL, IBaseDAL<T> where T : class, new()
    {
        public T[] AddOrUpdate(params T[] models)
        {
            if (models != null)
            {
                DataContext.Set<T>().AddOrUpdate(models);
            }
            return models;
        }

        public bool Exist(Expression<Func<T, bool>> whereLambda)
        {
            return DataContext.Set<T>().AsNoTracking().Any(whereLambda);
        }

        public T Get(Expression<Func<T, bool>> whereLambda, bool asNotracking = false)
        {
            var set = DataContext.Set<T>();
            if (asNotracking)
            {
                return set.FirstOrDefault(whereLambda);
            }
            else
            {
                return set.AsNoTracking().FirstOrDefault(whereLambda);
            }
        }

        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda, bool asNotracking = false)
        {
            var set = DataContext.Set<T>();
            if (asNotracking)
            {
                return set.Where(whereLambda);
            }
            else
            {
                return set.AsNoTracking().Where(whereLambda);
            }
        }

        public T[] Insert(params T[] models)
        {
            if (models != null)
            {
                DataContext.Set<T>().AddRange(models);
            }
            return models;
        }

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


    }
}
