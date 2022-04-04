namespace BARG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Regions", "Share");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Regions", "Share", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
