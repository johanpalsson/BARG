namespace BARG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Regions", "Assessment_Id", "dbo.Assessments");
            DropIndex("dbo.Regions", new[] { "Assessment_Id" });
            CreateTable(
                "dbo.SavingPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssessmentUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AssessmentUser_Id)
                .Index(t => t.AssessmentUser_Id);
            
            AddColumn("dbo.Regions", "SavingPlan_Id", c => c.Int());
            CreateIndex("dbo.Regions", "SavingPlan_Id");
            AddForeignKey("dbo.Regions", "SavingPlan_Id", "dbo.SavingPlans", "Id");
            DropColumn("dbo.Regions", "Assessment_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Regions", "Assessment_Id", c => c.Int());
            DropForeignKey("dbo.Regions", "SavingPlan_Id", "dbo.SavingPlans");
            DropForeignKey("dbo.SavingPlans", "AssessmentUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.SavingPlans", new[] { "AssessmentUser_Id" });
            DropIndex("dbo.Regions", new[] { "SavingPlan_Id" });
            DropColumn("dbo.Regions", "SavingPlan_Id");
            DropTable("dbo.SavingPlans");
            CreateIndex("dbo.Regions", "Assessment_Id");
            AddForeignKey("dbo.Regions", "Assessment_Id", "dbo.Assessments", "Id");
        }
    }
}
