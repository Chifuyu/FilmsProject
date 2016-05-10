using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }
}