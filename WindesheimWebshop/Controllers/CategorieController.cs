using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WindesheimWebshop.DAL;
using WindesheimWebshop.Models;
using WindesheimWebshop.ViewModels;

namespace WindesheimWebshop.Controllers
{
    public class CategorieController : Controller
    {
        private WebshopContext db = new WebshopContext();

        // GET: Categorie
        public ActionResult Index()
        {
            return View(db.Categorieen.ToList());
        }

        // GET: Categorie/{id}
        public ActionResult Details(int categorieId) {
            Categorie categorie = db.Categorieen.Find(categorieId);
            List<Product> producten = (from queryProduct in db.Producten
                                       where queryProduct.Categorieen.Any(c => c.ID == categorie.ID)
                                       select queryProduct).ToList();

            CategoryProductListViewModel vm = new CategoryProductListViewModel();
            vm.Categorieen = db.Categorieen.ToList();
            vm.Producten = producten;

            if (categorie == null) {
                return HttpNotFound();
            }

            return View(vm);
        }

        /*
        // GET: Categorie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie categorie = db.Categorieen.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        // GET: Categorie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Plaatje,Naam,Omschrijving")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                db.Categorieen.Add(categorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categorie);
        }

        // GET: Categorie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie categorie = db.Categorieen.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        // POST: Categorie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Plaatje,Naam,Omschrijving")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorie);
        }

        // GET: Categorie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie categorie = db.Categorieen.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        // POST: Categorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categorie categorie = db.Categorieen.Find(id);
            db.Categorieen.Remove(categorie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        */

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
