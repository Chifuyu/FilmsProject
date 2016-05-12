using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public class Order : BaseEntity
    {
        #region Properties

        public virtual Client Owner { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public virtual Movie Movie { get; set; }

        public int Rent { get; set; }

        public string Comment { get; set; }

        #endregion
        #region Methods


        #endregion
    }
}