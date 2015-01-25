using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    using System.ComponentModel.DataAnnotations;
    using BikeRental.Resources.Models;
    public class Bike
    {
        [Display(Name = "Id", ResourceType = typeof(BikeRes))]
        public int Id { get; set; }

        [Display(Name = "Model", ResourceType = typeof(BikeRes))]
        public string Model { get; set; }

        [Display(Name = "Orders", ResourceType = typeof(BikeRes))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}