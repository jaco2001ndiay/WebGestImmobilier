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
    public class AppartementsController : Controller
    {
        private ImmobilierContext db = new ImmobilierContext();

        // GET: Appartements
        public ActionResult Index()
        {
            var appartements = db.Appartements.Include(a => a.maisons);
            return View(appartements.ToList());
        }

        // GET: Appartements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appartement appartement = db.Appartements.Find(id);
            if (appartement == null)
            {
                return HttpNotFound();
            }
            return View(appartement);
        }

        // GET: Appartements/Create
        public ActionResult Create()
        {
            ViewBag.Idmaison = new SelectList(db.Maisons, "Idmaison", "Description");
            return View();
        }

        // POST: Appartements/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAppartement,lib_Appartement,nbre_Salle,Idmaison")] Appartement appartement)
        {
            if (ModelState.IsValid)
            {
                db.Appartements.Add(appartement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Idmaison = new SelectList(db.Maisons, "Idmaison", "Description", appartement.Idmaison);
            return View(appartement);
        }

        // GET: Appartements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appartement appartement = db.Appartements.Find(id);
            if (appartement == null)
            {
                return HttpNotFound();
            }
            ViewBag.Idmaison = new SelectList(db.Maisons, "Idmaison", "Description", appartement.Idmaison);
            return View(appartement);
        }

        // POST: Appartements/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAppartement,lib_Appartement,nbre_Salle,Idmaison")] Appartement appartement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appartement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Idmaison = new SelectList(db.Maisons, "Idmaison", "Description", appartement.Idmaison);
            return View(appartement);
        }

        // GET: Appartements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appartement appartement = db.Appartements.Find(id);
            if (appartement == null)
            {
                return HttpNotFound();
            }
            return View(appartement);
        }

        // POST: Appartements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appartement appartement = db.Appartements.Find(id);
            db.Appartements.Remove(appartement);
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
