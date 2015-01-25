using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    using System.ComponentModel.DataAnnotations;
    using BikeRental.Resources.Models;
    public class Client
    {
        [Display(Name = "Id", ResourceType = typeof(ClientRes))]
        public int Id { get; set; }

        [Display(Name = "FIO", ResourceType = typeof(ClientRes))]
        public string FIO { get; set; }

        [Display(Name = "Orders", ResourceType = typeof(ClientRes))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}