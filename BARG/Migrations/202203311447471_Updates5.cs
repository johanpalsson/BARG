namespace BARG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Regions", "Name", c => c.String());
            DropColumn("dbo.Regions", "RegionName");
            DropColumn("dbo.Regions", "ShareRegion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Regions", "ShareRegion", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Regions", "RegionName", c => c.String());
            DropColumn("dbo.Regions", "Name");
        }
    }
}
