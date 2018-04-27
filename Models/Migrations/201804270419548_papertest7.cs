namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class papertest7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.t_application", "ParentId", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.t_application", "ParentId", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
