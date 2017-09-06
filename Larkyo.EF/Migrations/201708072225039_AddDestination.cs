namespace Larkyo.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDestination : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Region = c.String(),
                        Country = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Destinations");
        }
    }
}
