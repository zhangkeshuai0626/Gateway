namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class papertest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.t_application",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationId = c.String(nullable: false, maxLength: 50),
                        ApplicationName = c.String(nullable: false, maxLength: 50),
                        ApplicationCode = c.String(nullable: false, maxLength: 50),
                        Sort = c.Int(nullable: false),
                        ApplicationType = c.Int(nullable: false),
                        ParentId = c.String(nullable: false, maxLength: 50),
                        Icon = c.String(maxLength: 200),
                        Url = c.String(maxLength: 2000),
                        ActionName = c.String(maxLength: 50),
                        ControllerName = c.String(maxLength: 50),
                        Method = c.Int(nullable: false),
                        Enable = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyBy = c.String(maxLength: 50),
                        LastModifyTime = c.DateTime(),
                        Remark = c.String(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.t_department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.String(nullable: false, maxLength: 50),
                        DepartmentCode = c.String(nullable: false, maxLength: 200),
                        Sort = c.Int(nullable: false),
                        DepartmentName = c.String(nullable: false, maxLength: 50),
                        ParentId = c.String(maxLength: 50),
                        Icon = c.String(maxLength: 200),
                        Enable = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyBy = c.String(maxLength: 50),
                        LastModifyTime = c.DateTime(),
                        Remark = c.String(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.t_department_application",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.String(nullable: false, maxLength: 50),
                        ApplicationId = c.String(nullable: false, maxLength: 50),
                        Enable = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyBy = c.String(maxLength: 50),
                        LastModifyTime = c.DateTime(),
                        Remark = c.String(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.t_departmentrole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.String(nullable: false, maxLength: 50),
                        RoleId = c.String(nullable: false, maxLength: 50),
                        Enable = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyBy = c.String(maxLength: 50),
                        LastModifyTime = c.DateTime(),
                        Remark = c.String(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.t_departmentroleapplication",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.String(nullable: false, maxLength: 50),
                        RoleId = c.String(nullable: false, maxLength: 50),
                        ApplicationId = c.String(nullable: false, maxLength: 50),
                        Enable = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyBy = c.String(maxLength: 50),
                        LastModifyTime = c.DateTime(),
                        Remark = c.String(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.t_dictionary",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DictionaryId = c.String(nullable: false, maxLength: 50),
                        DictionaryTypeId = c.String(nullable: false, maxLength: 50),
                        VarName = c.String(nullable: false, maxLength: 50),
                        VarValue = c.Int(nullable: false),
                        Enable = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyBy = c.String(maxLength: 50),
                        LastModifyTime = c.DateTime(),
                        Remark = c.String(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.t_dictionarytype",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DictionaryTypeId = c.String(nullable: false, maxLength: 50),
                        DictionaryTypeName = c.String(nullable: false, maxLength: 50),
                        Enable = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyBy = c.String(maxLength: 50),
                        LastModifyTime = c.DateTime(),
                        Remark = c.String(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.t_employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.String(nullable: false, maxLength: 50),
                        EmployeeNo = c.String(nullable: false, maxLength: 50),
                        EmployeeName = c.String(nullable: false, maxLength: 50),
                        Sex = c.Int(nullable: false),
                        DepartmentId = c.String(nullable: false, maxLength: 50),
                        RoleId = c.String(nullable: false, maxLength: 50),
                        Birthday = c.DateTime(),
                        EmployeeAddress = c.String(maxLength: 200),
                        Enable = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyBy = c.String(maxLength: 50),
                        LastModifyTime = c.DateTime(),
                        Remark = c.String(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.t_employeeapplication",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.String(nullable: false, maxLength: 50),
                        ApplicationId = c.String(nullable: false, maxLength: 50),
                        Enable = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyBy = c.String(maxLength: 50),
                        LastModifyTime = c.DateTime(),
                        Remark = c.String(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.t_employeedepartment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.String(nullable: false, maxLength: 50),
                        DepartmentId = c.String(nullable: false, maxLength: 50),
                        Enable = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyBy = c.String(maxLength: 50),
                        LastModifyTime = c.DateTime(),
                        Remark = c.String(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.t_log",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LogId = c.String(nullable: false, maxLength: 50),
                        LogType = c.Int(nullable: false),
                        LogContent = c.String(nullable: false, maxLength: 200),
                        Ip = c.String(maxLength: 50),
                        UserAgent = c.String(maxLength: 200),
                        Enable = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyBy = c.String(maxLength: 50),
                        LastModifyTime = c.DateTime(),
                        Remark = c.String(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.t_login",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.String(nullable: false, maxLength: 50),
                        LoginAccount = c.String(nullable: false, maxLength: 20),
                        LoginPassword = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Salt = c.String(maxLength: 10),
                        Enable = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyBy = c.String(maxLength: 50),
                        LastModifyTime = c.DateTime(),
                        Remark = c.String(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.t_role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.String(nullable: false, maxLength: 50),
                        RoleName = c.String(nullable: false, maxLength: 50),
                        RoleCode = c.String(nullable: false, maxLength: 200),
                        Sort = c.Int(nullable: false),
                        Icon = c.String(maxLength: 200),
                        Enable = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyBy = c.String(maxLength: 50),
                        LastModifyTime = c.DateTime(),
                        Remark = c.String(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.t_role");
            DropTable("dbo.t_login");
            DropTable("dbo.t_log");
            DropTable("dbo.t_employeedepartment");
            DropTable("dbo.t_employeeapplication");
            DropTable("dbo.t_employee");
            DropTable("dbo.t_dictionarytype");
            DropTable("dbo.t_dictionary");
            DropTable("dbo.t_departmentroleapplication");
            DropTable("dbo.t_departmentrole");
            DropTable("dbo.t_department_application");
            DropTable("dbo.t_department");
            DropTable("dbo.t_application");
        }
    }
}
