namespace Models
{
    using Common.Utils;
    using DbModels;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;

    public class DbGatewayContext : DbContext
    {
        public enum DbName
        {
            GatewayEntity = 0
        }

        /// <summary>
        /// 获取线程内唯一的DbContext
        /// </summary>
        /// <returns></returns>
        public static DbContext CreateDbContext()
        {

            DbContext dbContext = HttpHelper.GetHttpContextItem(Configs.GATEWAY_ENTITY) as DbContext;
            if (dbContext == null)
            {
                dbContext = new DbGatewayContext();
                HttpHelper.SetHttpContextItem(Configs.GATEWAY_ENTITY, dbContext);
            }
            return dbContext;
        }
        /// <summary>
        /// 私有的构造函数, 防止外部new
        /// </summary>
        public DbGatewayContext()
            : base("name=GatewayEntity")
        {

        }

        #region 数据模型
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<DepartmentApplication> DepartmentApplication { get; set; }
        public virtual DbSet<DepartmentJob> DepartmentJob { get; set; }
        public virtual DbSet<DepartmentJobApplication> DepartmentJobApplication { get; set; }
        public virtual DbSet<Dictionary> Dictionary { get; set; }
        public virtual DbSet<EmployeeApplication> EmployeeApplication { get; set; }
        public virtual DbSet<EmployeeDepartment> EmployeeDepartment { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<ApplicationButton> ApplicationButton { get; set; }
        public virtual DbSet<DictionaryType> DictionaryType { get; set; }
        #endregion
        /// <summary>
        /// 模型和数据表映射关系
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>().ToTable("T_Application");
            modelBuilder.Entity<Department>().ToTable("T_Department");
            modelBuilder.Entity<Dictionary>().ToTable("T_Dictionary");
            modelBuilder.Entity<Employee>().ToTable("T_Employee");
            modelBuilder.Entity<DepartmentApplication>().ToTable("T_DepartmentApplication");
            modelBuilder.Entity<DepartmentJob>().ToTable("T_DepartmentJob");
            modelBuilder.Entity<DepartmentJobApplication>().ToTable("T_DepartmentJobApplication");
            modelBuilder.Entity<Dictionary>().ToTable("T_Dictionary");
            modelBuilder.Entity<EmployeeApplication>().ToTable("T_EmployeeApplication");
            modelBuilder.Entity<EmployeeDepartment>().ToTable("T_EmployeeDepartment");
            modelBuilder.Entity<Job>().ToTable("T_Job");
            modelBuilder.Entity<Log>().ToTable("T_Log");
            modelBuilder.Entity<ApplicationButton>().ToTable("T_ApplicationButton");
            modelBuilder.Entity<DictionaryType>().ToTable("T_DictionaryType");
        }
    }


}