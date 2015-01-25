using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    public class Bike
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}