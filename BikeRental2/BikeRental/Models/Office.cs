using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    using System.ComponentModel.DataAnnotations;
    using BikeRental.Resources.Models;
    public class Office
    {
        [Display(Name = "Id", ResourceType = typeof(OfficeRes))]
        public int Id { get; set; }

        [Display(Name = "Address", ResourceType = typeof(OfficeRes))]
        public string Address { get; set; }

        [Display(Name = "Orders", ResourceType = typeof(OfficeRes))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}