namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class papertest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Application",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationId = c.String(nullable: false, maxLength: 50),
                        ApplicationName = c.String(nullable: false, maxLength: 50),
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
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_ApplicationButton",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationId = c.String(nullable: false, maxLength: 50),
                        ButtonId = c.String(nullable: false, maxLength: 50),
                        HandlerApplicationId = c.String(maxLength: 50),
                        Attr = c.String(),
                        ButtonPosition = c.Int(nullable: false),
                        Enable = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyBy = c.String(maxLength: 50),
                        LastModifyTime = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.String(nullable: false, maxLength: 50),
                        DepartmentType = c.Int(nullable: false),
                        DepartmentName = c.String(nullable: false, maxLength: 50),
                        ParentId = c.String(nullable: false, maxLength: 50),
                        Icon = c.String(maxLength: 200),
                        Enable = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyBy = c.String(maxLength: 50),
                        LastModifyTime = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_DepartmentApplication",
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
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_DepartmentJob",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.String(nullable: false, maxLength: 50),
                        JobId = c.String(nullable: false, maxLength: 50),
                        Enable = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyBy = c.String(maxLength: 50),
                        LastModifyTime = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_DepartmentJobApplication",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.String(nullable: false, maxLength: 50),
                        JobId = c.String(nullable: false, maxLength: 50),
                        ApplicationId = c.String(nullable: false, maxLength: 50),
                        Enable = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyBy = c.String(maxLength: 50),
                        LastModifyTime = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_Dictionary",
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
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_DictionaryType",
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
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.String(nullable: false, maxLength: 50),
                        EmployeeNo = c.String(nullable: false, maxLength: 50),
                        LoginAccount = c.String(nullable: false, maxLength: 20),
                        LoginPassword = c.String(nullable: false, maxLength: 50),
                        EmployeeName = c.String(nullable: false, maxLength: 50),
                        Sex = c.Int(nullable: false),
                        DepartmentId = c.String(nullable: false, maxLength: 50),
                        JobId = c.String(nullable: false, maxLength: 50),
                        Salt = c.String(maxLength: 10),
                        Email = c.String(nullable: false),
                        Birthday = c.DateTime(),
                        EmployeeAddress = c.String(maxLength: 200),
                        Enable = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyBy = c.String(maxLength: 50),
                        LastModifyTime = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_EmployeeApplication",
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
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_EmployeeDepartment",
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
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_Job",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobId = c.String(nullable: false, maxLength: 50),
                        JobName = c.String(nullable: false, maxLength: 50),
                        Icon = c.String(maxLength: 200),
                        Enable = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyBy = c.String(maxLength: 50),
                        LastModifyTime = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_Log",
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
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.T_Log");
            DropTable("dbo.T_Job");
            DropTable("dbo.T_EmployeeDepartment");
            DropTable("dbo.T_EmployeeApplication");
            DropTable("dbo.T_Employee");
            DropTable("dbo.T_DictionaryType");
            DropTable("dbo.T_Dictionary");
            DropTable("dbo.T_DepartmentJobApplication");
            DropTable("dbo.T_DepartmentJob");
            DropTable("dbo.T_DepartmentApplication");
            DropTable("dbo.T_Department");
            DropTable("dbo.T_ApplicationButton");
            DropTable("dbo.T_Application");
        }
    }
}
