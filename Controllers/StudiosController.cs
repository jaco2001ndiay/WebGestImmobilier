using System;
using System.Collections.Generic;
using System.Data;
using PagedList;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebGestImmobilier.Models;

namespace WebGestImmobilier.Controllers
{
    public class StudiosController : Controller
    {
        private ImmobilierContext db = new ImmobilierContext();

        // GET: Studios
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            // je donne le sort order actuel pour la garder a la pagination 
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "nom_desc" : "";
            ViewBag.LocaSortParm = sortOrder == "Localisation" ? "loca_desc" : "Localisation";
            // si la chaine de recherche est modifie su cours du changement de page  
            // alors on met page a 1 
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                // sinon on garde notre numeros de recherche  
                searchString = currentFilter;
            }
            var studios = db.Studios.Include(s => s.Proprietaire);

            // je defini le current filter pour garder le filtre actuel a la pagination 
            ViewBag.CurrentFilter = searchString;
            if(!String.IsNullOrEmpty(searchString))
            {
                studios = studios.Where(s => s.Localisation.Contains(searchString) || s.Proprietaire.NomPropri.Contains(searchString));  
               
            }
            switch (sortOrder)
            {
                case "nom_desc":
                    studios = studios.OrderByDescending(s => s.Proprietaire.NomPropri);
                    break;
                case "Localisation":
                    studios = studios.OrderBy(s => s.Localisation);
                    break;
                case "loca_desc":
                    studios = studios.OrderByDescending(s => s.Localisation);
                    break;
                default:
                    studios = studios.OrderBy(s => s.Proprietaire.NomPropri);
                    break;
            }
            // je donne le nombre d'element par page  
            int pageSize = 3;
            // on decrit le numeros de page en cours 
            int pageNumber = (page ?? 1);
            return View(studios.ToPagedList(pageNumber,pageSize)) ; 
        }

        // GET: Studios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studio = db.Studios.Find(id);
            if (studio == null)
            {
                return HttpNotFound();
            }
            return View(studio);
        }

        // GET: Studios/Create
        public ActionResult Create()
        {
            ViewBag.IdProprio = new SelectList(db.Proprietaires, "Idproprietarie", "NomPropri");
            return View();
        }

        // POST: Studios/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idstudio,Description,Prix,Superficie,Localisation,IdProprio,nbre_pieces")] Studio studio)
        {
            if (ModelState.IsValid)
            {
                db.Studios.Add(studio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProprio = new SelectList(db.Proprietaires, "Idproprietarie", "NomPropri", studio.IdProprio);
            return View(studio);
        }

        // GET: Studios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studio = db.Studios.Find(id);
            if (studio == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProprio = new SelectList(db.Proprietaires, "Idproprietarie", "NomPropri", studio.IdProprio);
            return View(studio);
        }

        // POST: Studios/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idstudio,Description,Prix,Superficie,Localisation,IdProprio,nbre_pieces")] Studio studio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProprio = new SelectList(db.Proprietaires, "Idproprietarie", "NomPropri", studio.IdProprio);
            return View(studio);
        }

        // GET: Studios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studio = db.Studios.Find(id);
            if (studio == null)
            {
                return HttpNotFound();
            }
            return View(studio);
        }

        // POST: Studios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Studio studio = db.Studios.Find(id);
            db.Studios.Remove(studio);
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
