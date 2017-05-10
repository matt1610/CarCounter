namespace CarCounter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SensorReadingsModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        sensor = c.String(),
                        interval = c.Int(nullable: false),
                        apiKey = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SensorReadingsModels");
        }
    }
}
