using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    public class Office
    {
        public int Id { get; set; }

        public string Address { get; set; }

      //  public virtual ICollection<Order> Start { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}