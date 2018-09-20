namespace CinemaFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Halls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RowsCount = c.Int(nullable: false),
                        SeatsInRow = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Director = c.String(maxLength: 100),
                        Description = c.String(maxLength: 200),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShowDate = c.DateTime(nullable: false),
                        ShowTime = c.String(nullable: false),
                        bookedSeats = c.String(),
                        MovieId = c.Int(nullable: false),
                        HallId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Halls", t => t.HallId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.HallId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookedSeats = c.String(nullable: false),
                        NumOfTickets = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        SessionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessions", t => t.SessionId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.SessionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Password = c.String(nullable: false, maxLength: 80),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.Sessions", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Sessions", "HallId", "dbo.Halls");
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "SessionId" });
            DropIndex("dbo.Sessions", new[] { "HallId" });
            DropIndex("dbo.Sessions", new[] { "MovieId" });
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Sessions");
            DropTable("dbo.Movies");
            DropTable("dbo.Halls");
        }
    }
}
