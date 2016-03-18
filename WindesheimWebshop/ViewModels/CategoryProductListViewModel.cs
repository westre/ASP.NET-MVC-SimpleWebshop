using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WindesheimWebshop.Models;

namespace WindesheimWebshop.ViewModels {
    public class CategoryProductListViewModel {
        public List<Categorie> Categorieen { get; set; }
        public List<Product> Producten { get; set; }
    }
}