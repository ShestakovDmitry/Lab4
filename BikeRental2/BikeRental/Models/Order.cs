using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    using System.ComponentModel.DataAnnotations;
    using BikeRental.Resources.Models;
    public class Order
    {
        public int Id { get; set; }

        public int BikeId { get; set; }

        public int OfficeId { get; set; }

        [Display(Name = "OfficeFinish", ResourceType = typeof(OrderRes))]
        public string OfficeFinish { get; set; }

        [Display(Name = "DateStart", ResourceType = typeof(OrderRes))]
        public DateTime DateStart { get; set; }

        [Display(Name = "DateFinish", ResourceType = typeof(OrderRes))]
        public DateTime DateFinish { get; set; }

        public int ClientId { get; set; }

        [Display(Name = "Cost", ResourceType = typeof(OrderRes))]
        public int Cost { get; set; }

        /// <summary>Gets or sets a value indicating whether
        /// the bike is free (true) or not (false).</summary>
        [Display(Name = "IsFree", ResourceType = typeof(OrderRes))]
        public bool IsFree { get; set; }

        [Display(Name = "Bike", ResourceType = typeof(OrderRes))]
        public virtual Bike Bike { get; set; }

        //[InverseProperty("Start")]
        //[ForeignKey("OfficeStartId")]
        [Display(Name = "Office", ResourceType = typeof(OrderRes))]
        public virtual Office Office { get; set; }

        //[InverseProperty("Finish")]
        //[ForeignKey("OfficeFinishId")]
        //public virtual Office FinishOffice { get; set; }
        [Display(Name = "Client", ResourceType = typeof(OrderRes))]
        public virtual Client Client { get; set; }
    }
}