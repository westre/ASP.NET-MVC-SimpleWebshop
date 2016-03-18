using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WindesheimWebshop.Models {
    public class Categorie {
        public int ID { get; set; }
        public string Plaatje { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }

        public virtual ICollection<Product> Producten { get; set; }
    }
}