namespace BARG.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RemoveMy : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Assessments", "MyProperty");
        }

        public override void Down()
        {
            AddColumn("dbo.Assessments", "MyProperty", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
