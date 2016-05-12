using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public class Movie : BaseEntity
    {
        #region Properties

        public String Name { get; set; }

        public virtual ICollection<Director> Directors { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }

        public int Year { get; set; }

        public virtual ICollection<Genre> ListOfGenres { get; set; }

        public int Price { get; set; }

        public int Rating { get; set; } 

        public string Logo { get; set; }
        
        public int Count { get; set; }

        public string Description { get; set; }

        #endregion
        #region Methods

        public Movie()
        {
            Directors = new List<Director>();
            Actors = new List<Actor>();
            ListOfGenres = new List<Genre>();
        }

        #endregion
    }
}