using System;
using Autofac;
using DAL;
using IDAL;


namespace DALContainer
{

    /// <summary>
    /// 该类主要是创建IDAL的实例对象,我们这里可以自己写一个工厂也可以通过一些第三方的IOC框架,这里使用Autofac 
    /// </summary>
    public class Container
    {
        /// <summary>
        /// IOC 容器
        /// </summary>
        public static IContainer container = null;
        /// <summary>
        /// 获取 IDal 的实例化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>() where T : IBaseDAL
        {
            try
            {
                if (container == null)
                {
                    Initialise();
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("IOC实例化出错!" + ex.Message);
            }
            return container.Resolve<T>();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialise()
        {
            var builder = new ContainerBuilder();
            //在这里注册对象
            builder = RegisterInterface(builder);
            container = builder.Build();
        }
        /// <summary>
        /// 注册数据操作对象接口
        /// </summary>
        private static ContainerBuilder RegisterInterface(ContainerBuilder builder)
        {
            //格式：builder.RegisterType<xxxx>().As<Ixxxx>().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationDAL>().As<IApplicationDAL>().InstancePerLifetimeScope();
            builder.RegisterType<DepartmentDAL>().As<IDepartmentDAL>().InstancePerLifetimeScope();
            builder.RegisterType<DepartmentApplicationDAL>().As<IDepartmentApplicationDAL>().InstancePerLifetimeScope();
            builder.RegisterType<DepartmentRoleDAL>().As<IDepartmentRoleDAL>().InstancePerLifetimeScope();
            builder.RegisterType<DepartmentRoleApplicationDAL>().As<IDepartmentRoleApplicationDAL>().InstancePerLifetimeScope();

            builder.RegisterType<DictionaryDAL>().As<IDictionaryDAL>().InstancePerLifetimeScope();


            builder.RegisterType<EmployeeDAL>().As<IEmployeeDAL>().InstancePerLifetimeScope();

            builder.RegisterType<EmployeeApplicationDAL>().As<IEmployeeApplicationDAL>().InstancePerLifetimeScope();


            builder.RegisterType<EmployeeDepartmentDAL>().As<IEmployeeDepartmentDAL>().InstancePerLifetimeScope();

            builder.RegisterType<RoleDAL>().As<IRoleDAL>().InstancePerLifetimeScope();
            builder.RegisterType<LogDAL>().As<ILogDAL>().InstancePerLifetimeScope();

            builder.RegisterType<LoginDAL>().As<ILoginDAL>().InstancePerLifetimeScope();

            builder.RegisterType<DictionaryTypeDAL>().As<IDictionaryTypeDAL>().InstancePerLifetimeScope();
            return builder;
        }
    }
}
