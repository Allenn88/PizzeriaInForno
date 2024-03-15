using PizzeriaInForno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzeriaInForno.Controllers
{
    public class BackOfficeController : Controller
    {
        private DBContext db = new DBContext();

        [Authorize (Roles ="Admin")]
        public ActionResult BackOffice()
        {
             var ordini = db.Ordines.Where(o => o.Stato == false).ToList();

            return View (ordini);   
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Evaso(int IDOrdine)
        {
            var ordine = db.Ordines.Find(IDOrdine);
            if (ordine != null)
            {
                ordine.Stato = true;
                db.SaveChanges();
            }

            return RedirectToAction("BackOffice");
        }
        [HttpGet]
        public ActionResult GestionePizzeria()
        {
            var ordiniEvasi = db.Ordines
                //.Include(o => o.Articolo)
                //.Include(o => o.Utente)
                                .Where(o => o.Stato == true)
                                .ToList();

            foreach (var ordine in ordiniEvasi)
            {
                db.Entry(ordine).Reference(o => o.Articolo).Load();
               // db.Entry(ordine).Reference(o => o.Utente).Load();
            }


            decimal totaleOrdiniEvasi = ordiniEvasi.Sum(o => o.Quantita * o.Articolo.Prezzo);
            ViewBag.TotaleOrdiniEvasi = totaleOrdiniEvasi;

            return View(ordiniEvasi);
        }
    }
}