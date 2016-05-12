namespace MovieRental.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MovieRental.Models.DataProviders;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieRental.DAL.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieRental.DAL.Context context)
        {
            var movies = DebugDataProvider.GetMovies().ToArray();
            context.Movies.AddOrUpdate(movies);
        }
    }
}
