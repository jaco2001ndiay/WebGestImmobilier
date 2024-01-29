﻿using System;
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
    public class ProprietairesController : Controller
    {
        private ImmobilierContext db = new ImmobilierContext();

        // GET: Proprietaires
        public ActionResult Index()
        {
            var proprietaires = db.Proprietaires.Include(p => p.Utilisateures);
            return View(proprietaires.ToList());
        }

        // GET: Proprietaires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietaire proprietaire = db.Proprietaires.Find(id);
            if (proprietaire == null)
            {
                return HttpNotFound();
            }
            return View(proprietaire);
        }

        // GET: Proprietaires/Create
        public ActionResult Create()
        {
            ViewBag.IdUsers = new SelectList(db.Utilisateurs, "IdUsers", "nomUsers");
            return View();
        }

        // POST: Proprietaires/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idproprietarie,NomPropri,IdUsers")] Proprietaire proprietaire)
        {
            if (ModelState.IsValid)
            {
                db.Proprietaires.Add(proprietaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsers = new SelectList(db.Utilisateurs, "IdUsers", "nomUsers", proprietaire.IdUsers);
            return View(proprietaire);
        }

        // GET: Proprietaires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietaire proprietaire = db.Proprietaires.Find(id);
            if (proprietaire == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsers = new SelectList(db.Utilisateurs, "IdUsers", "nomUsers", proprietaire.IdUsers);
            return View(proprietaire);
        }

        // POST: Proprietaires/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idproprietarie,NomPropri,IdUsers")] Proprietaire proprietaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proprietaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsers = new SelectList(db.Utilisateurs, "IdUsers", "nomUsers", proprietaire.IdUsers);
            return View(proprietaire);
        }

        // GET: Proprietaires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietaire proprietaire = db.Proprietaires.Find(id);
            if (proprietaire == null)
            {
                return HttpNotFound();
            }
            return View(proprietaire);
        }

        // POST: Proprietaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proprietaire proprietaire = db.Proprietaires.Find(id);
            db.Proprietaires.Remove(proprietaire);
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