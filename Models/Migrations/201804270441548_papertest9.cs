namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class papertest9 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.t_departmentrole", newName: "t_department_role");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.t_department_role", newName: "t_departmentrole");
        }
    }
}
