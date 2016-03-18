using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WindesheimWebshop.Models;

namespace WindesheimWebshop.ViewModels {
    public class CartViewModel {
        public List<Categorie> Categorieen { get; set; }
        public Winkelmand Winkelmand { get; set; }
    }
}