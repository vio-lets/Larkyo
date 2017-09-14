namespace Larkyo.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeam : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        JoinedConfirm = c.Boolean(nullable: false),
                        MaxUser = c.Int(nullable: false),
                        Tags = c.String(),
                        Description = c.String(),
                        Promoter_Id = c.String(maxLength: 128),
                        trip_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Promoter_Id)
                .ForeignKey("dbo.Trips", t => t.trip_Id)
                .Index(t => t.Promoter_Id)
                .Index(t => t.trip_Id);
            
            CreateTable(
                "dbo.TeamRequirements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TeamId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        Views = c.Int(nullable: false),
                        EstimateCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TeamId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
            AddColumn("dbo.AspNetUsers", "Team_Id", c => c.Guid());
            AddColumn("dbo.AspNetUsers", "Team_Id1", c => c.Guid());
            CreateIndex("dbo.AspNetUsers", "Team_Id");
            CreateIndex("dbo.AspNetUsers", "Team_Id1");
            AddForeignKey("dbo.AspNetUsers", "Team_Id", "dbo.Teams", "Id");
            AddForeignKey("dbo.AspNetUsers", "Team_Id1", "dbo.Teams", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trips", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "trip_Id", "dbo.Trips");
            DropForeignKey("dbo.TeamRequirements", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "Promoter_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Team_Id1", "dbo.Teams");
            DropForeignKey("dbo.AspNetUsers", "Team_Id", "dbo.Teams");
            DropIndex("dbo.Trips", new[] { "TeamId" });
            DropIndex("dbo.TeamRequirements", new[] { "TeamId" });
            DropIndex("dbo.AspNetUsers", new[] { "Team_Id1" });
            DropIndex("dbo.AspNetUsers", new[] { "Team_Id" });
            DropIndex("dbo.Teams", new[] { "trip_Id" });
            DropIndex("dbo.Teams", new[] { "Promoter_Id" });
            DropColumn("dbo.AspNetUsers", "Team_Id1");
            DropColumn("dbo.AspNetUsers", "Team_Id");
            DropTable("dbo.Trips");
            DropTable("dbo.TeamRequirements");
            DropTable("dbo.Teams");
        }
    }
}
