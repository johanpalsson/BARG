namespace BARG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assessments", "AssessmentUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            CreateIndex("dbo.Assessments", "AssessmentUser_Id");
            AddForeignKey("dbo.Assessments", "AssessmentUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assessments", "AssessmentUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Assessments", new[] { "AssessmentUser_Id" });
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.Assessments", "AssessmentUser_Id");
        }
    }
}
