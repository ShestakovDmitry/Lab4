using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int BikeId { get; set; }

        public int OfficeId { get; set; }

        public string OfficeFinish { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateFinish { get; set; }

        public int ClientId { get; set; }

        public int Cost { get; set; }

        /// <summary>Gets or sets a value indicating whether
        /// the bike is free (true) or not (false).</summary>
        public bool IsFree { get; set; }

        public virtual Bike Bike { get; set; }

        //[InverseProperty("Start")]
        //[ForeignKey("OfficeStartId")]
        public virtual Office Office { get; set; }

        //[InverseProperty("Finish")]
        //[ForeignKey("OfficeFinishId")]
        //public virtual Office FinishOffice { get; set; }

        public virtual Client Client { get; set; }
    }
}