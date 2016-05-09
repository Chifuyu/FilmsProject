namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_dm1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Movie_Id);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Movie_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Movie_Id);
            
            AddColumn("dbo.Movies", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Logo", c => c.String());
            AddColumn("dbo.Movies", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Genres", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Directors", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Actors", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Genres", new[] { "Movie_Id" });
            DropIndex("dbo.Directors", new[] { "Movie_Id" });
            DropIndex("dbo.Actors", new[] { "Movie_Id" });
            DropColumn("dbo.Movies", "Description");
            DropColumn("dbo.Movies", "Count");
            DropColumn("dbo.Movies", "Logo");
            DropColumn("dbo.Movies", "Rating");
            DropColumn("dbo.Movies", "Price");
            DropColumn("dbo.Movies", "Year");
            DropTable("dbo.Genres");
            DropTable("dbo.Directors");
            DropTable("dbo.Actors");
        }
    }
}
