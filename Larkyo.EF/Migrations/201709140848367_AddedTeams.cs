namespace Larkyo.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTeams : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Guid(nullable: false),
                        Title = c.String(),
                        JoinedConfirm = c.Boolean(nullable: false),
                        MaxUser = c.Int(nullable: false),
                        Tags = c.String(),
                        Description = c.String(),
                        Promoter_Id = c.String(maxLength: 128),
                        Trip_TripId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.AspNetUsers", t => t.Promoter_Id)
                .ForeignKey("dbo.Trips", t => t.Trip_TripId)
                .Index(t => t.Promoter_Id)
                .Index(t => t.Trip_TripId);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        TripId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        Views = c.Int(nullable: false),
                        EstimateCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TripId);
            
            AddColumn("dbo.AspNetUsers", "Team_TeamId", c => c.Guid());
            AddColumn("dbo.AspNetUsers", "Team_TeamId1", c => c.Guid());
            CreateIndex("dbo.AspNetUsers", "Team_TeamId");
            CreateIndex("dbo.AspNetUsers", "Team_TeamId1");
            AddForeignKey("dbo.AspNetUsers", "Team_TeamId", "dbo.Teams", "TeamId");
            AddForeignKey("dbo.AspNetUsers", "Team_TeamId1", "dbo.Teams", "TeamId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "Trip_TripId", "dbo.Trips");
            DropForeignKey("dbo.Teams", "Promoter_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Team_TeamId1", "dbo.Teams");
            DropForeignKey("dbo.AspNetUsers", "Team_TeamId", "dbo.Teams");
            DropIndex("dbo.AspNetUsers", new[] { "Team_TeamId1" });
            DropIndex("dbo.AspNetUsers", new[] { "Team_TeamId" });
            DropIndex("dbo.Teams", new[] { "Trip_TripId" });
            DropIndex("dbo.Teams", new[] { "Promoter_Id" });
            DropColumn("dbo.AspNetUsers", "Team_TeamId1");
            DropColumn("dbo.AspNetUsers", "Team_TeamId");
            DropTable("dbo.Trips");
            DropTable("dbo.Teams");
        }
    }
}
