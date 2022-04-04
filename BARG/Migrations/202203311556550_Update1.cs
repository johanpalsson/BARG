namespace BARG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SavingPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Share = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SavingPlan_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SavingPlans", t => t.SavingPlan_Id)
                .Index(t => t.SavingPlan_Id);
            
            AddColumn("dbo.Assessments", "SavingPlan_Id", c => c.Int());
            CreateIndex("dbo.Assessments", "SavingPlan_Id");
            AddForeignKey("dbo.Assessments", "SavingPlan_Id", "dbo.SavingPlans", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assessments", "SavingPlan_Id", "dbo.SavingPlans");
            DropForeignKey("dbo.Regions", "SavingPlan_Id", "dbo.SavingPlans");
            DropIndex("dbo.Regions", new[] { "SavingPlan_Id" });
            DropIndex("dbo.Assessments", new[] { "SavingPlan_Id" });
            DropColumn("dbo.Assessments", "SavingPlan_Id");
            DropTable("dbo.Regions");
            DropTable("dbo.SavingPlans");
        }
    }
}
