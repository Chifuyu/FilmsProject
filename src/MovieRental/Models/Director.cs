using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public class Director : Person
    {
        public Director()
        {
            Movies = new List<Movie>();
        }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}