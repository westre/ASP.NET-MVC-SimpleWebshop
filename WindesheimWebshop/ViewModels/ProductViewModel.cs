using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WindesheimWebshop.Models;

namespace WindesheimWebshop.ViewModels {
    public class ProductViewModel {
        public Product Product { get; set; }
        public Aanbieding Aanbieding { get; set; }
    }
}