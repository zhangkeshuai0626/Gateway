namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class papertest8 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.t_departmentroleapplication", newName: "t_departmentrole_application");
            RenameTable(name: "dbo.t_dictionarytype", newName: "t_dictionary_type");
            RenameTable(name: "dbo.t_employeeapplication", newName: "t_employee_application");
            RenameTable(name: "dbo.t_employeedepartment", newName: "t_employee_department");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.t_employee_department", newName: "t_employeedepartment");
            RenameTable(name: "dbo.t_employee_application", newName: "t_employeeapplication");
            RenameTable(name: "dbo.t_dictionary_type", newName: "t_dictionarytype");
            RenameTable(name: "dbo.t_departmentrole_application", newName: "t_departmentroleapplication");
        }
    }
}
