using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WindesheimWebshop.DAL;
using WindesheimWebshop.Models;
using WindesheimWebshop.ViewModels;

namespace WindesheimWebshop.Controllers
{
    public class WinkelmandController : Controller
    {
        private WebshopContext db = new WebshopContext();

        // GET: Winkelmand
        public ActionResult Index()
        {
            CartViewModel vm = new CartViewModel();
            vm.Categorieen = db.Categorieen.ToList();

            if (Session["Cart"] == null)
                Session["Cart"] = new Dictionary<int, int>();

            vm.Winkelmand = new Winkelmand();

            foreach(var kvp in (Dictionary<int, int>)Session["Cart"]) {
                Product product = db.Producten.Find(kvp.Key);
                int amount = kvp.Value;

                vm.Winkelmand.Producten[product] = amount;
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(int pid, int pamount) {
            if (Session["Cart"] == null)
                Session["Cart"] = new Dictionary<int, int>();

            Dictionary<int, int> winkelmand = (Dictionary<int, int>)Session["Cart"];

            if (pamount > 0)
                winkelmand[pid] = pamount;
            else
                winkelmand.Remove(pid);

            return Json(pid);
        }

        public ActionResult Bestellen() {
            OrderViewModel ovm = new OrderViewModel();
            ovm.Categorieen = db.Categorieen.ToList();
            
            return View(ovm);
        }

        [HttpPost]
        public ActionResult Bestellen(OrderViewModel ovm) {
            if(ModelState.IsValid) {
                TempData["Klant"] = ovm.Klant;
                return RedirectToAction("Overzicht");
            }

            ovm.Categorieen = db.Categorieen.ToList();
            return View(ovm);
        }

        public ActionResult Overzicht() {
            OrderViewModel ovm = new OrderViewModel();
            ovm.Categorieen = db.Categorieen.ToList();
            ovm.Klant = (Klant)TempData["Klant"];
            ovm.Winkelmand = new Winkelmand();

            foreach (var kvp in (Dictionary<int, int>)Session["Cart"]) {
                Product product = db.Producten.Find(kvp.Key);
                int amount = kvp.Value;

                ovm.Winkelmand.Producten[product] = amount;
            }

            return View(ovm);
        }

        [HttpPost]
        public ActionResult Overzicht(OrderViewModel ovm) {
            Klant klant = db.Klanten.Add(ovm.Klant);
            db.SaveChanges();

            Order order = new Order();
            order.Klant = klant;
            order.OrderRegels = new List<OrderRegel>();

            db.Orders.Add(order);
            db.SaveChanges();

            foreach (var kvp in (Dictionary<int, int>)Session["Cart"]) {
                Product product = db.Producten.Find(kvp.Key);
                int amount = kvp.Value;

                OrderRegel orderRegel = new OrderRegel();
                orderRegel.Order = order;
                orderRegel.Product = product;
                orderRegel.Aantal = amount;

                order.OrderRegels.Add(orderRegel);
            }

            db.SaveChanges();

            return RedirectToAction("Success");
        }

        public ActionResult Success() {
            return View();
        }
    }
}