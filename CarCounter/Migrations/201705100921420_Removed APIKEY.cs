namespace CarCounter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedAPIKEY : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SensorReadingsModels", "apiKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SensorReadingsModels", "apiKey", c => c.String());
        }
    }
}
