namespace BARG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Regions", "SavingPlan_Id", "dbo.SavingPlans");
            DropIndex("dbo.Regions", new[] { "SavingPlan_Id" });
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
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Regions", "SavingPlan_Id", c => c.Int());
            CreateIndex("dbo.Regions", "SavingPlan_Id");
            AddForeignKey("dbo.Regions", "SavingPlan_Id", "dbo.SavingPlans", "Id");
        }
    }
}
