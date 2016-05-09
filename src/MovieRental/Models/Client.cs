using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public class Client : BaseEntity
    {
        public string PhoneNumber { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}