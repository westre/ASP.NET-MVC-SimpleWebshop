using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WindesheimWebshop.Models {
    public class Aanbieding {
        public int ID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }

        public string Aanbiedingsprijs { get; set; }
        public DateTime DatumVan { get; set; }
        public DateTime DatumTot { get; set; }
        public string ReclameTekst { get; set; }

        public virtual Product Product { get; set; }
    }
}