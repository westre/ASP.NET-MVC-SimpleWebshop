using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WindesheimWebshop.Models {
    public class Klant {
        public int ID { get; set; }

        [Required(ErrorMessage = "Naam AUB")]
        public string Naam { get; set; }
        [Required(ErrorMessage = "Adres AUB")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Woonplaats AUB")]
        public string Woonplaats { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}