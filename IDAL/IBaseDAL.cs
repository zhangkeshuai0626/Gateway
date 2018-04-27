using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace IDAL
{
    /// <summary>
    /// 数据库操作接口
    /// </summary>
    public partial interface IBaseDAL
    {
        /// <summary>
        /// 返回数据库上下文对象(线程内唯一)
        /// </summary>
        DbContext DataContext { get; }
        /// <summary>
        /// 执行一条sql查询
        /// </summary>
        /// <typeparam name="ReturnType">返回值类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="paramters">sql参数</param>
        /// <returns></returns>
        DbRawSqlQuery<ReturnType> SqlQuery<ReturnType>(string sql, params object[] paramters);
        /// <summary>
        /// 执行一条SQL指令
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramters"></param>
        /// <returns></returns>
        int ExecuteSqlCommand(string sql, params object[] paramters);
        /// <summary>
        /// 一个业务中有可能涉及到对多张表的操作,那么可以将操作的数据,打上相应的标记,最后调用该方法,将数据一次性提交到数据库中,避免了多次链接数据库。
        /// </summary>
        bool SaveChange();

    }
    /// <summary>
    /// 数据库泛型操作接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial interface IBaseDAL<T> : IBaseDAL where T : class, new()
    {
        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        T[] Insert(params T[] models);
        /// <summary>
        /// 修改一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        T[] AddOrUpdate(params T[] models);
        /// <summary>
        /// 查询是否存在记录
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        bool Exist(Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <param name="asNotracking">是否要缓存在上下文</param>
        /// <returns></returns>
        IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda, bool asNotracking = false);
        /// <summary>
        /// 获取单个对象
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <param name="asNotracking"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> whereLambda, bool asNotracking = false);
        /// <summary>
        /// 获取分页
        /// </summary>
        /// <typeparam name="Ttype">返回值类型</typeparam>
        /// <param name="skip">过滤条数</param>
        /// <param name="take">获取记录数</param>
        /// <param name="total">总条数</param>
        /// <param name="whereLambda"></param>
        /// <param name="orderByLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        IQueryable<T> Page<Ttype>(int skip, int take, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, Ttype>> orderByLambda, bool isAsc);

    }
}
