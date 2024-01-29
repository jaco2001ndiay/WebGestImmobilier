using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebGestImmobilier.Models;

namespace WebGestImmobilier.Controllers
{
    public class MaisonsController : Controller
    {
        private ImmobilierContext db = new ImmobilierContext();

        // GET: Maisons
        public ActionResult Index()
        {
            var maisons = db.Maisons.Include(m => m.Proprietaire);
            return View(maisons.ToList());
        }

        // GET: Maisons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maison maison = db.Maisons.Find(id);
            if (maison == null)
            {
                return HttpNotFound();
            }
            return View(maison);
        }

        // GET: Maisons/Create
        public ActionResult Create()
        {
            ViewBag.IdProprio = new SelectList(db.Proprietaires, "Idproprietarie", "NomPropri");
            return View();
        }

        // POST: Maisons/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idmaison,Description,Prix,Superficie,Localisation,IdProprio,Nbre_chambres,Nbre_douche,Nbre_cuisine,NbreToilette")] Maison maison)
        {
            if (ModelState.IsValid)
            {
                db.Maisons.Add(maison);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProprio = new SelectList(db.Proprietaires, "Idproprietarie", "NomPropri", maison.IdProprio);
            return View(maison);
        }

        // GET: Maisons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maison maison = db.Maisons.Find(id);
            if (maison == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProprio = new SelectList(db.Proprietaires, "Idproprietarie", "NomPropri", maison.IdProprio);
            return View(maison);
        }

        // POST: Maisons/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idmaison,Description,Prix,Superficie,Localisation,IdProprio,Nbre_chambres,Nbre_douche,Nbre_cuisine,NbreToilette")] Maison maison)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maison).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProprio = new SelectList(db.Proprietaires, "Idproprietarie", "NomPropri", maison.IdProprio);
            return View(maison);
        }

        // GET: Maisons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maison maison = db.Maisons.Find(id);
            if (maison == null)
            {
                return HttpNotFound();
            }
            return View(maison);
        }

        // POST: Maisons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maison maison = db.Maisons.Find(id);
            db.Maisons.Remove(maison);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
