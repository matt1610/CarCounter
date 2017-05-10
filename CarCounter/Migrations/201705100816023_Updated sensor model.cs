namespace CarCounter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedsensormodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SensorReadingsModels", "InternalData", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SensorReadingsModels", "InternalData");
        }
    }
}
