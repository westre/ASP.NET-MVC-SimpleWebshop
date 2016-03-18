using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WindesheimWebshop.Models {
    public class OrderRegel {
        public int ID { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }

        public int Aantal { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}