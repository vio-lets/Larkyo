namespace Larkyo.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeam1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeamRequirements", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Trips", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.AspNetUsers", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.AspNetUsers", "Team_Id1", "dbo.Teams");
            DropForeignKey("dbo.Teams", "trip_Id", "dbo.Trips");
            DropIndex("dbo.TeamRequirements", new[] { "TeamId" });
            DropIndex("dbo.Trips", new[] { "TeamId" });
            RenameColumn(table: "dbo.AspNetUsers", name: "Team_Id", newName: "Team_TeamId");
            RenameColumn(table: "dbo.AspNetUsers", name: "Team_Id1", newName: "Team_TeamId1");
            RenameColumn(table: "dbo.Teams", name: "trip_Id", newName: "Trip_TripId");
            RenameIndex(table: "dbo.Teams", name: "IX_trip_Id", newName: "IX_Trip_TripId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Team_Id", newName: "IX_Team_TeamId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Team_Id1", newName: "IX_Team_TeamId1");
            DropPrimaryKey("dbo.Teams");
            DropPrimaryKey("dbo.Trips");
            AddColumn("dbo.Teams", "TeamId", c => c.Guid(nullable: false));
            AddColumn("dbo.Trips", "TripId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Teams", "TeamId");
            AddPrimaryKey("dbo.Trips", "TripId");
            AddForeignKey("dbo.Teams", "Trip_TripId", "dbo.Trips", "TripId");
            AddForeignKey("dbo.AspNetUsers", "Team_TeamId", "dbo.Teams", "TeamId");
            AddForeignKey("dbo.AspNetUsers", "Team_TeamId1", "dbo.Teams", "TeamId");
            DropColumn("dbo.Teams", "Id");
            DropColumn("dbo.Trips", "Id");
            DropColumn("dbo.Trips", "TeamId");
            DropTable("dbo.TeamRequirements");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TeamRequirements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TeamId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Trips", "TeamId", c => c.Guid(nullable: false));
            AddColumn("dbo.Trips", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Teams", "Id", c => c.Guid(nullable: false));
            DropForeignKey("dbo.AspNetUsers", "Team_TeamId1", "dbo.Teams");
            DropForeignKey("dbo.AspNetUsers", "Team_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "Trip_TripId", "dbo.Trips");
            DropPrimaryKey("dbo.Trips");
            DropPrimaryKey("dbo.Teams");
            DropColumn("dbo.Trips", "TripId");
            DropColumn("dbo.Teams", "TeamId");
            AddPrimaryKey("dbo.Trips", "Id");
            AddPrimaryKey("dbo.Teams", "Id");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Team_TeamId1", newName: "IX_Team_Id1");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Team_TeamId", newName: "IX_Team_Id");
            RenameIndex(table: "dbo.Teams", name: "IX_Trip_TripId", newName: "IX_trip_Id");
            RenameColumn(table: "dbo.Teams", name: "Trip_TripId", newName: "trip_Id");
            RenameColumn(table: "dbo.AspNetUsers", name: "Team_TeamId1", newName: "Team_Id1");
            RenameColumn(table: "dbo.AspNetUsers", name: "Team_TeamId", newName: "Team_Id");
            CreateIndex("dbo.Trips", "TeamId");
            CreateIndex("dbo.TeamRequirements", "TeamId");
            AddForeignKey("dbo.Teams", "trip_Id", "dbo.Trips", "Id");
            AddForeignKey("dbo.AspNetUsers", "Team_Id1", "dbo.Teams", "Id");
            AddForeignKey("dbo.AspNetUsers", "Team_Id", "dbo.Teams", "Id");
            AddForeignKey("dbo.Trips", "TeamId", "dbo.Teams", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TeamRequirements", "TeamId", "dbo.Teams", "Id", cascadeDelete: true);
        }
    }
}
