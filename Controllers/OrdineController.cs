using PizzeriaInForno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzeriaInForno.Controllers
{
    public class OrdineController : Controller
    {
        private DBContext db = new DBContext();

        public ActionResult Ordine()
        {
            var articoli = db.Articolos.ToList();
            ViewBag.Articoli = new SelectList(articoli, "IDArticolo", "Nome");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreaOrdine(int IDArticolo)
        {
            var userID = Convert.ToInt32(User.Identity.Name);
            var dataOrdine = DateTime.Now;

            try
            {
               
                var ordine = new Ordine
                {
                    IDUtente = userID,
                    IDArticolo = IDArticolo,
                    Data = dataOrdine,
                    Stato = false, 
                    Quantita = 1 
                };

             
                db.Ordines.Add(ordine);
                db.SaveChanges();

                ViewBag.Messaggio = "Ordine creato con successo!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Si è verificato un errore durante la creazione dell'ordine.");
            }

            var articoli = db.Articolos.ToList();
            ViewBag.Articoli = new SelectList(articoli, "IDArticolo", "Nome", IDArticolo);

            return View("Ordine");
        }
    }
}
