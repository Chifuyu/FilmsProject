using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MovieRental.Models;

namespace MovieRental.DAL
{
    public class MoviesDbInitializer : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context)
        {
            for (int i = 0; i < 10; i++)
                context.Movies.Add(new Movie() { Name = String.Format("Movie {0}", i + 1) });
            context.SaveChanges();
            //base.Seed(context);
        }
    }
}