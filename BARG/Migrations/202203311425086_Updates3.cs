namespace BARG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SavingPlans", "AssessmentUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Regions", "SavingPlan_Id", "dbo.SavingPlans");
            DropForeignKey("dbo.Assessments", "SavingPlan_Id", "dbo.SavingPlans");
            DropIndex("dbo.Assessments", new[] { "SavingPlan_Id" });
            DropIndex("dbo.SavingPlans", new[] { "AssessmentUser_Id" });
            DropIndex("dbo.Regions", new[] { "SavingPlan_Id" });
            AddColumn("dbo.Regions", "Assessment_Id", c => c.Int());
            CreateIndex("dbo.Regions", "Assessment_Id");
            AddForeignKey("dbo.Regions", "Assessment_Id", "dbo.Assessments", "Id");
            DropColumn("dbo.Assessments", "SavingPlan_Id");
            DropColumn("dbo.Regions", "SavingPlan_Id");
            DropTable("dbo.SavingPlans");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SavingPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssessmentUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Regions", "SavingPlan_Id", c => c.Int());
            AddColumn("dbo.Assessments", "SavingPlan_Id", c => c.Int());
            DropForeignKey("dbo.Regions", "Assessment_Id", "dbo.Assessments");
            DropIndex("dbo.Regions", new[] { "Assessment_Id" });
            DropColumn("dbo.Regions", "Assessment_Id");
            CreateIndex("dbo.Regions", "SavingPlan_Id");
            CreateIndex("dbo.SavingPlans", "AssessmentUser_Id");
            CreateIndex("dbo.Assessments", "SavingPlan_Id");
            AddForeignKey("dbo.Assessments", "SavingPlan_Id", "dbo.SavingPlans", "Id");
            AddForeignKey("dbo.Regions", "SavingPlan_Id", "dbo.SavingPlans", "Id");
            AddForeignKey("dbo.SavingPlans", "AssessmentUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
