namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class papertest1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.t_application", "Sort", c => c.Int(nullable: false));
            AddColumn("dbo.t_department", "Sort", c => c.Int(nullable: false));
            AddColumn("dbo.t_role", "Sort", c => c.Int(nullable: false));
            DropColumn("dbo.t_application", "Order");
            DropColumn("dbo.t_department", "Order");
            DropColumn("dbo.t_role", "Order");
        }
        
        public override void Down()
        {
            AddColumn("dbo.t_role", "Order", c => c.Int(nullable: false));
            AddColumn("dbo.t_department", "Order", c => c.Int(nullable: false));
            AddColumn("dbo.t_application", "Order", c => c.Int(nullable: false));
            DropColumn("dbo.t_role", "Sort");
            DropColumn("dbo.t_department", "Sort");
            DropColumn("dbo.t_application", "Sort");
        }
    }
}
