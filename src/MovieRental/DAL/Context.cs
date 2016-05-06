using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using MovieRental.Models;
using MovieRental.DAL.Mapping;

namespace MovieRental.DAL
{
    public class Context : DbContext
    {
        public Context() : base("name=DbConnectionString")
        {
            Database.SetInitializer<Context>(new MoviesDbInitializer());
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using Fluent API here
            /*modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Movie>().ToTable("Movies");

            modelBuilder.Entity<Movie>().HasKey<int>(x => x.Id);
            modelBuilder.Entity<Movie>().Property(x => x.Name).HasMaxLength(255).IsRequired();*/
            //modelBuilder.Entity<Movie>().Map(delegate(EntityMappingConfiguration<Movie>))

            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new MovieConfiguration());
        }
    }
}