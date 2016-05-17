namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order_movie_id : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Orders", new[] { "Movie_Id" });
            RenameColumn(table: "dbo.Orders", name: "Movie_Id", newName: "MovieId");
            AlterColumn("dbo.Orders", "MovieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "MovieId");
            AddForeignKey("dbo.Orders", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "MovieId", "dbo.Movies");
            DropIndex("dbo.Orders", new[] { "MovieId" });
            AlterColumn("dbo.Orders", "MovieId", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "MovieId", newName: "Movie_Id");
            CreateIndex("dbo.Orders", "Movie_Id");
            AddForeignKey("dbo.Orders", "Movie_Id", "dbo.Movies", "Id");
        }
    }
}
