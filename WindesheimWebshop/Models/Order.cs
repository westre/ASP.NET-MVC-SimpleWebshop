using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WindesheimWebshop.Models {
    public class Order {
        public int ID { get; set; }

        [ForeignKey("Klant")]
        public int KlantID { get; set; }

        public virtual ICollection<OrderRegel> OrderRegels { get; set; }
        public virtual Klant Klant { get; set; }
    }
}