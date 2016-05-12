using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using MovieRental.Models;
using MovieRental.DAL.Mapping;
using MovieRental.Migrations;

namespace MovieRental.DAL
{
    public class Context : DbContext
    {
        public Context() : base()
        {
            Database.SetInitializer<Context>(new MigrateDatabaseToLatestVersion<Context,Configuration>() );
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using Fluent API here
            /*modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Movie>().ToTable("Movies");

            modelBuilder.Entity<Movie>().HasKey<int>(x => x.Id);
            modelBuilder.Entity<Movie>().Property(x => x.Name).HasMaxLength(255).IsRequired();*/
            //modelBuilder.Entity<Movie>().Map(delegate(EntityMappingConfiguration<Movie>))
            //modelBuilder.Configurations.Add(new MovieConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}