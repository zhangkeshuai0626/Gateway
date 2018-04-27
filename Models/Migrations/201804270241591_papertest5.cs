namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class papertest5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.t_application", "CreateBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.t_department", "CreateBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.t_department_application", "CreateBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.t_departmentrole", "CreateBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.t_departmentroleapplication", "CreateBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.t_dictionary", "CreateBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.t_dictionarytype", "CreateBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.t_employee", "CreateBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.t_employeeapplication", "CreateBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.t_employeedepartment", "CreateBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.t_log", "CreateBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.t_login", "CreateBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.t_role", "CreateBy", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.t_role", "CreateBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.t_login", "CreateBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.t_log", "CreateBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.t_employeedepartment", "CreateBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.t_employeeapplication", "CreateBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.t_employee", "CreateBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.t_dictionarytype", "CreateBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.t_dictionary", "CreateBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.t_departmentroleapplication", "CreateBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.t_departmentrole", "CreateBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.t_department_application", "CreateBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.t_department", "CreateBy", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.t_application", "CreateBy", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
