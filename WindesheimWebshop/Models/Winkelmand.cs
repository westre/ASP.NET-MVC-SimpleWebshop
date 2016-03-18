using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WindesheimWebshop.Models {
    public class Winkelmand {
        public Dictionary<Product, int> Producten { get; set; } = new Dictionary<Product, int>();
    }
}