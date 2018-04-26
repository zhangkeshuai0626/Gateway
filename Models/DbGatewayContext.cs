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
        public virtual DbSet<DepartmentRole> DepartmentRole { get; set; }
        public virtual DbSet<DepartmentRoleApplication> DepartmentRoleApplication { get; set; }
        public virtual DbSet<Dictionary> Dictionary { get; set; }
        public virtual DbSet<EmployeeApplication> EmployeeApplication { get; set; }
        public virtual DbSet<EmployeeDepartment> EmployeeDepartment { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<DictionaryType> DictionaryType { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        #endregion
        /// <summary>
        /// 模型和数据表映射关系
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>().ToTable("t_application");
            modelBuilder.Entity<Department>().ToTable("t_department");
            modelBuilder.Entity<Dictionary>().ToTable("t_dictionary");
            modelBuilder.Entity<Employee>().ToTable("t_employee");
            modelBuilder.Entity<DepartmentApplication>().ToTable("t_department_application");
            modelBuilder.Entity<DepartmentRole>().ToTable("t_departmentrole");
            modelBuilder.Entity<DepartmentRoleApplication>().ToTable("t_departmentroleapplication");
            modelBuilder.Entity<Dictionary>().ToTable("t_dictionary");
            modelBuilder.Entity<EmployeeApplication>().ToTable("t_employeeapplication");
            modelBuilder.Entity<EmployeeDepartment>().ToTable("t_employeedepartment");
            modelBuilder.Entity<Role>().ToTable("t_role");
            modelBuilder.Entity<Log>().ToTable("t_log");
            modelBuilder.Entity<DictionaryType>().ToTable("t_dictionarytype");
            modelBuilder.Entity<Login>().ToTable("t_login");
        }
    }


}