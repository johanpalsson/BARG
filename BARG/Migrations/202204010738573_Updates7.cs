namespace BARG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assessments", "SavingPlan_Id", "dbo.SavingPlans");
            DropIndex("dbo.Assessments", new[] { "SavingPlan_Id" });
            AddColumn("dbo.Regions", "Assessment_Id", c => c.Int());
            CreateIndex("dbo.Regions", "Assessment_Id");
            AddForeignKey("dbo.Regions", "Assessment_Id", "dbo.Assessments", "Id");
            DropColumn("dbo.Assessments", "SavingPlan_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Assessments", "SavingPlan_Id", c => c.Int());
            DropForeignKey("dbo.Regions", "Assessment_Id", "dbo.Assessments");
            DropIndex("dbo.Regions", new[] { "Assessment_Id" });
            DropColumn("dbo.Regions", "Assessment_Id");
            CreateIndex("dbo.Assessments", "SavingPlan_Id");
            AddForeignKey("dbo.Assessments", "SavingPlan_Id", "dbo.SavingPlans", "Id");
        }
    }
}
