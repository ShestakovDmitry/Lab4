using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string FIO { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}