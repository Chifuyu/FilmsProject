namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_dm2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "FirstName", c => c.String());
            AddColumn("dbo.Actors", "LastName", c => c.String());
            AddColumn("dbo.Directors", "FirstName", c => c.String());
            AddColumn("dbo.Directors", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Directors", "LastName");
            DropColumn("dbo.Directors", "FirstName");
            DropColumn("dbo.Actors", "LastName");
            DropColumn("dbo.Actors", "FirstName");
        }
    }
}
