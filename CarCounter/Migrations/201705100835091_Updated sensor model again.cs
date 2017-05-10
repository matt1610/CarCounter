namespace CarCounter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedsensormodelagain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SensorReadingsModels", "storedReadingsString", c => c.String());
            DropColumn("dbo.SensorReadingsModels", "InternalData");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SensorReadingsModels", "InternalData", c => c.String());
            DropColumn("dbo.SensorReadingsModels", "storedReadingsString");
        }
    }
}
