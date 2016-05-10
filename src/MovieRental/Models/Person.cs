using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public abstract class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}