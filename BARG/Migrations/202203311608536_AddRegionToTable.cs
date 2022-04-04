﻿namespace BARG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegionToTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Regions (Name) VALUES ('Asia')");
            Sql("INSERT INTO Regions (Name) VALUES ('Europe')");
            Sql("INSERT INTO Regions (Name) VALUES ('USA')");


        }

        public override void Down()
        {
        }
    }
}