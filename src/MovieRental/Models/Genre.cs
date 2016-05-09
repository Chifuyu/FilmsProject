using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public class Genre : BaseEntity
    {
        public Genre(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}