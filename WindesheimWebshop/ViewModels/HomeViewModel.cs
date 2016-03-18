using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WindesheimWebshop.Models;

namespace WindesheimWebshop.ViewModels {
    public class HomeViewModel {
        public List<Aanbieding> Aanbiedingen;
        public List<Product> Producten;
        public List<Categorie> Categorieen;
    }
}