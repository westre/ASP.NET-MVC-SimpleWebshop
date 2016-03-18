using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WindesheimWebshop.Models;

namespace WindesheimWebshop.DAL {
    public class WebshopInitializer : DropCreateDatabaseAlways<WebshopContext> {
        //DropCreateDatabaseIfModelChanges
        protected override void Seed(WebshopContext context) {

            var categorieen = new List<Categorie> {
                new Categorie { Naam = "Processors", Omschrijving = "Hardware dingen voor je systeem", Plaatje = "http://www.delicentieman.nl/wp-content/uploads/2015/02/core.jpg" },
                new Categorie { Naam = "Software", Omschrijving = "Hardware dingen voor je systeem", Plaatje = "http://www.chopinsoftware.nl/media/1001/welcome_1.jpg" },
                new Categorie { Naam = "Videokaarten", Omschrijving = "Hardware dingen voor je systeem", Plaatje = "http://images.anandtech.com/doci/8069/geforce-gtx-titan-z-3qtr-top.jpg" },
                new Categorie { Naam = "Harde schijven", Omschrijving = "Hardware dingen voor je systeem", Plaatje = "http://img.tomshardware.com/us/2007/01/16/2007-hdd-rundown/western-digital-wd1600aajs-pers.jpg" },
                new Categorie { Naam = "USB's", Omschrijving = "Hardware dingen voor je systeem", Plaatje = "https://www.conrad.nl/medias/global/ce/4000_4999/4100/4170/4171/417166_LB_00_FB.EPS_1000.jpg" },
                new Categorie { Naam = "Nieuw", Omschrijving = "Nieuw!!!", Plaatje = "https://www.conrad.nl/medias/global/ce/4000_4999/4100/4170/4171/417166_LB_00_FB.EPS_1000.jpg" },
            };

            var producten = new List<Product> {
                new Product { Naam = "Windows 10", Omschrijving = "Windows 10 voor uw PC!", Plaatje = "http://www.v3.co.uk/IMG/701/318701/windows-10-logo-2-540x334.jpg?1446716802", Prijs = "50,00", Categorieen = new List<Categorie> { categorieen[1] } },
                new Product { Naam = "Windows 8", Omschrijving = "Windows 8 voor uw PC!", Plaatje = "http://www.logodesignlove.com/images/evolution/windows-8-logo.jpg", Prijs = "50,00", Categorieen = new List<Categorie> { categorieen[1] } },
                new Product { Naam = "i5-2500k", Omschrijving = "Windows 10 voor uw PC!", Plaatje = "http://cdn1.expertreviews.co.uk/sites/expertreviews/files/images/dir_279/er_photo_139831.jpg", Prijs = "50,00", Categorieen = new List<Categorie> { categorieen[0] } },
                new Product { Naam = "i7-920", Omschrijving = "Windows 10 voor uw PC!", Plaatje = "http://ic.tweakimg.net/ext/i/1231673830.jpg", Prijs = "50,00", Categorieen = new List<Categorie> { categorieen[0] } },
                new Product { Naam = "GTX 970", Omschrijving = "Windows 10 voor uw PC!", Plaatje = "http://ic.tweakimg.net/ext/i/2000546305.png", Prijs = "50,00", Categorieen = new List<Categorie> { categorieen[2] } },
            };

            var aanbiedingen = new List<Aanbieding> {
                new Aanbieding { Product = producten[0], DatumVan = DateTime.Now, DatumTot = DateTime.Now, Aanbiedingsprijs = "40,00", ReclameTekst = "Beste prijs ooit win10!" },
                new Aanbieding { Product = producten[1], DatumVan = DateTime.Now, DatumTot = DateTime.Now, Aanbiedingsprijs = "40,00", ReclameTekst = "Beste prijs ooit win8!" },
            };

            foreach (Categorie categorie in categorieen)
                context.Categorieen.Add(categorie);

            foreach (Product product in producten)
                context.Producten.Add(product);

            foreach (Aanbieding aanbieding in aanbiedingen)
                context.Aanbiedingen.Add(aanbieding);

            context.SaveChanges();
        }
    }
}