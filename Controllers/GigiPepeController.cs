using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PizzeriaInForno.Models;

namespace PizzeriaInForno.Controllers
{
    public class GigiPepeController : Controller
    {
        private DBContext db = new DBContext();

        // GET: GigiPepe
        public ActionResult Index()
        {
            return View(db.Articolos.ToList());
        }

        // GET: GigiPepe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articolo articolo = db.Articolos.Find(id);
            if (articolo == null)
            {
                return HttpNotFound();
            }
            return View(articolo);
        }

        // GET: GigiPepe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GigiPepe/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDArticolo,Nome,Foto,Prezzo,TempoConsegna,Ingredienti")] Articolo articolo)
        {
            if (ModelState.IsValid)
            {
                db.Articolos.Add(articolo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articolo);
        }

        // GET: GigiPepe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articolo articolo = db.Articolos.Find(id);
            if (articolo == null)
            {
                return HttpNotFound();
            }
            return View(articolo);
        }

        // POST: GigiPepe/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDArticolo,Nome,Foto,Prezzo,TempoConsegna,Ingredienti")] Articolo articolo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articolo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articolo);
        }

        // GET: GigiPepe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articolo articolo = db.Articolos.Find(id);
            if (articolo == null)
            {
                return HttpNotFound();
            }
            return View(articolo);
        }

        // POST: GigiPepe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Articolo articolo = db.Articolos.Find(id);
            db.Articolos.Remove(articolo);
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
