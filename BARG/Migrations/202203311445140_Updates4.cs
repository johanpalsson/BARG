namespace BARG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assessments", "ShareRegion", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assessments", "ShareRegion");
        }
    }
}
