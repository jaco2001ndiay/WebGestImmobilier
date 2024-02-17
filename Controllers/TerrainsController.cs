using Microsoft.Ajax.Utilities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using WebGestImmobilier.Models;

namespace WebGestImmobilier.Controllers
{
    public class TerrainsController : Controller
    {
        private ImmobilierContext db = new ImmobilierContext();

        // GET: Terrains
        public ActionResult Index(string sortOrder, string currentFilder, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.LocalisationSortParm = sortOrder == "Localisation" ? "loca_desc" : "Localisation";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilder;
            }
            ViewBag.CurrentFilter = searchString;
            var terrains = db.Terrains.Include(t => t.Proprietaire);
            if (!String.IsNullOrEmpty(searchString))
            {
                terrains = terrains.Where(s => s.Description.Contains(searchString) || s.Localisation.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc" :
                    terrains = terrains.OrderByDescending(s=>s.Description)   ;
                    break;
                case "Localisation": 
                    terrains = terrains.OrderBy(s=>s.Localisation) ;
                    break;
                case "loca_desc": 
                    terrains = terrains.OrderByDescending((s)=>s.Localisation) ;
                    break;
                default:
                    terrains = terrains.OrderBy((s)=>s.Description) ;
                    break; 

                    
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1); 
            return View(terrains.ToPagedList(pageNumber, pageSize));
        } 
       

        // GET: Terrains/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terrain terrain = db.Terrains.Find(id);
            if (terrain == null)
            {
                return HttpNotFound();
            }
            return View(terrain);
        }

        // GET: Terrains/Create
        public ActionResult Create()
        {
            ViewBag.IdProprio = new SelectList(db.Proprietaires, "Idproprietarie", "NomPropri");
            return View();
        }

        // POST: Terrains/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idterrain,Description,Prix,Superficie,Localisation,IdProprio,typeterrain")] Terrain terrain)
        {
            if (ModelState.IsValid)
            {
                    if(terrain.IdProprio == null)
                {
                    ModelState.AddModelError("IdProprio", "Veuiller chosir le proprietaire");

                    return RedirectToAction("Create"); 
                }


                    db.Terrains.Add(terrain);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                } 
            

            ViewBag.IdProprio = new SelectList(db.Proprietaires, "Idproprietarie", "NomPropri", terrain.IdProprio);
            return View(terrain);
        }

        // GET: Terrains/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terrain terrain = db.Terrains.Find(id);
            if (terrain == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProprio = new SelectList(db.Proprietaires, "Idproprietarie", "NomPropri", terrain.IdProprio);
            return View(terrain);
        }

        // POST: Terrains/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idterrain,Description,Prix,Superficie,Localisation,IdProprio,typeterrain")] Terrain terrain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(terrain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProprio = new SelectList(db.Proprietaires, "Idproprietarie", "NomPropri", terrain.IdProprio);
            return View(terrain);
        }

        // GET: Terrains/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terrain terrain = db.Terrains.Find(id);
            if (terrain == null)
            {
                return HttpNotFound();
            }
            return View(terrain);
        }

        // POST: Terrains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Terrain terrain = db.Terrains.Find(id);
            db.Terrains.Remove(terrain);
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
