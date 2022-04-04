namespace BARG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assessments", "SavingPlan_Id", c => c.Int());
            CreateIndex("dbo.Assessments", "SavingPlan_Id");
            AddForeignKey("dbo.Assessments", "SavingPlan_Id", "dbo.SavingPlans", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assessments", "SavingPlan_Id", "dbo.SavingPlans");
            DropIndex("dbo.Assessments", new[] { "SavingPlan_Id" });
            DropColumn("dbo.Assessments", "SavingPlan_Id");
        }
    }
}
