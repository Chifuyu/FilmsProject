using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public class Order : BaseEntity
    {
        #region Properties

        public int Price { get; set; }

        #endregion
        #region Methods

        public Order()
        {

        }

        #endregion
    }
}