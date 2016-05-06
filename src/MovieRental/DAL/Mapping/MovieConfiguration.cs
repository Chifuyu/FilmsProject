using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using MovieRental.Models;

namespace MovieRental.DAL.Mapping
{
    public class MovieConfiguration : EntityTypeConfiguration<Movie>
    {
        public MovieConfiguration()
        {
            ToTable("Movies");
            HasKey<int>(x => x.Id);
            Property(x => x.Name).HasMaxLength(255).IsRequired();
        }
    }
}