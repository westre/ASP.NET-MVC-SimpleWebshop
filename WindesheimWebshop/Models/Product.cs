using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WindesheimWebshop.Models {
    public class Product {
        public int ID { get; set; }
        public string Plaatje { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public string Prijs { get; set; }

        public virtual ICollection<Categorie> Categorieen { get; set; }
        public virtual ICollection<Aanbieding> Aanbiedingen { get; set; }
    }
}