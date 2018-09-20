namespace CinemaFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoImage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Image", c => c.Binary());
        }
    }
}
