using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WindesheimWebshop.DAL;
using WindesheimWebshop.ViewModels;

namespace WindesheimWebshop.Controllers
{
    public class HomeController : Controller
    {
        private WebshopContext db = new WebshopContext();

        // GET: Home
        public ActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel();
            hvm.Aanbiedingen = db.Aanbiedingen.ToList();
            hvm.Producten = db.Producten.ToList();
            hvm.Categorieen = db.Categorieen.ToList();

            return View(hvm);
        }
    }
}