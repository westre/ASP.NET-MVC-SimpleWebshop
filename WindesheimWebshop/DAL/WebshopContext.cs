using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WindesheimWebshop.Models;

namespace WindesheimWebshop.DAL {
    public class WebshopContext : DbContext {
        public WebshopContext() : base("WebshopContext") {

        }

        public DbSet<Aanbieding> Aanbiedingen { get; set; }
        public DbSet<Categorie> Categorieen { get; set; }
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Producten { get; set; }
    }
}