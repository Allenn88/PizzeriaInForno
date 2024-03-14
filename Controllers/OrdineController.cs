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
        private List<Ordine> pizzeInAttesa = new List<Ordine>(); 
        public ActionResult Ordine()
        {
            var articoli = db.Articolos.ToList();
            ViewBag.Articoli = new SelectList(articoli, "IDArticolo", "Nome");

            return View(new Ordine());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ordine(Ordine ordine)
        {
            ordine.IDUtente = Convert.ToInt32(User.Identity.Name);
            ordine.Data = DateTime.Now;

            try
            {
                if (ModelState.IsValid)
                {
                    
                    pizzeInAttesa.Add(ordine);
                    TempData["PizzeInAttesa"] = pizzeInAttesa; 

                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Si è verificato un errore durante la creazione dell'ordine.");
            }

            var articoli = db.Articolos.ToList();
            ViewBag.Articoli = new SelectList(articoli, "IDArticolo", "Nome", ordine.IDArticolo);

            return View(ordine);
        }

        [HttpPost]
        public ActionResult AddOrdine(Ordine ordine)
        {
            if (ModelState.IsValid)
            {
              
                pizzeInAttesa.Add(ordine);
                TempData["PizzeInAttesa"] = pizzeInAttesa; 

                return RedirectToAction("Index", "Home");
            }
            return View(ordine);
        }

        [HttpPost]
        public ActionResult ConfermaOrdine()
        {
            if (TempData["PizzeInAttesa"] != null)
            {
              
                List<Ordine> pizzeInAttesa = TempData["PizzeInAttesa"] as List<Ordine>;

                
                foreach (var pizza in pizzeInAttesa)
                {
                    db.Ordines.Add(pizza);
                }
                db.SaveChanges();

              
                TempData.Remove("PizzeInAttesa");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
