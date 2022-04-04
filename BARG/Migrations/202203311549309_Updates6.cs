namespace BARG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Regions", "Assessment_Id", "dbo.Assessments");
            DropIndex("dbo.Regions", new[] { "Assessment_Id" });
            DropColumn("dbo.Assessments", "ShareRegion");
            DropTable("dbo.Regions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Assessment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Assessments", "ShareRegion", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Regions", "Assessment_Id");
            AddForeignKey("dbo.Regions", "Assessment_Id", "dbo.Assessments", "Id");
        }
    }
}
