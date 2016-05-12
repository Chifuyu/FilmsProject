using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public class Genre : BaseEntity
    {
        public Genre()
        {
            Movies = new List<Movie>();
        }

        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}