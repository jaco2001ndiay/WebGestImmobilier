using PagedList;
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
    public class UtilisateursController : Controller
    {
        private ImmobilierContext db = new ImmobilierContext();

        // GET: Utilisateurs
        public ViewResult Index(string sortOrder,string currentFilter, string searchString, int?page) 
        {
            // je donne le sort order actuel pour la garder a la pagination 
            ViewBag.CurrentSort = sortOrder; 
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "nom_desc" : "";
            ViewBag.MailSortParm = sortOrder == "Mail" ? "email_desc" : "Mail";
            // si la chaine de recherche est modifie su cours du changement de page  
            // alors on met page a 1 
            if(searchString != null)
            {
                page = 1; 
            }
            else
            {
                // sinon on garde notre numeros de recherche  
                searchString = currentFilter; 
            }
            // je defini le current filter pour garder le filtre actuel a la pagination 
            ViewBag.CurrentFilter = searchString;

            var utilisateurs = from s in db.Utilisateurs select s;

            /// verifier si la chaine de recherche est correcte ou non  
            if (!String.IsNullOrEmpty(searchString))
            {
                utilisateurs = utilisateurs.Where(s =>s.nomUsers.Contains(searchString) || s.prenom.Contains(searchString));
            }
            /// je mets en place un choix d'ordre de trie 
            switch (sortOrder)
            {
                case "nom_desc":
                    utilisateurs = utilisateurs.OrderByDescending(s => s.nomUsers); 
                    break;
                case "Mail": 
                    utilisateurs = utilisateurs.OrderBy(s => s.email);
                    break;
                case "email_desc":
                    utilisateurs = utilisateurs.OrderByDescending(s => s.email); 
                    break;
                default:
                    utilisateurs = utilisateurs.OrderBy(s => s.nomUsers); 
                    break; 
            }
            // je donne le nombre d'element par page  
            int pageSize = 3;
            // on decrit le numeros de page en cours 
            int pageNumber = (page ?? 1); 
            return View(utilisateurs.ToPagedList(pageNumber, pageSize));
        }

        // GET: Utilisateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateurs utilisateurs = db.Utilisateurs.Find(id);
            if (utilisateurs == null)
            {
                return HttpNotFound();
            }
            return View(utilisateurs);
        }

        // GET: Utilisateurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utilisateurs/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsers,nomUsers,prenom,login,email,addPhoneNumber2")] Utilisateurs utilisateurs)
        {
            if (ModelState.IsValid)
            {
                db.Utilisateurs.Add(utilisateurs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(utilisateurs);
        }

        // GET: Utilisateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateurs utilisateurs = db.Utilisateurs.Find(id);
            if (utilisateurs == null)
            {
                return HttpNotFound();
            }
            return View(utilisateurs);
        }

        // POST: Utilisateurs/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsers,nomUsers,prenom,login,email,addPhoneNumber2")] Utilisateurs utilisateurs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilisateurs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(utilisateurs);
        }

        // GET: Utilisateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateurs utilisateurs = db.Utilisateurs.Find(id);
            if (utilisateurs == null)
            {
                return HttpNotFound();
            }
            return View(utilisateurs);
        }

        // POST: Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilisateurs utilisateurs = db.Utilisateurs.Find(id);
            db.Utilisateurs.Remove(utilisateurs);
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
