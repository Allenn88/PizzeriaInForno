﻿using PizzeriaInForno.Models;
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
        public ActionResult CreaOrdine(Ordine ordine)
        {
            if (!User.Identity.IsAuthenticated)
            {
                ViewBag.Messaggio = "Effettua prima il login";
                return RedirectToAction("Login", "Login");
            }

            if (ordine.Quantita <= 0 || ordine.Quantita == null)
            {
                ModelState.AddModelError("", "La quantità deve essere un numero maggiore di 0.");
                var articoliCTR = db.Articolos.ToList();
                ViewBag.Articoli = new SelectList(articoliCTR, "IDArticolo", "Nome", ordine.IDArticolo);
                return View("Ordine", ordine);
            }
            var userID = Convert.ToInt32(User.Identity.Name);
            var dataOrdine = DateTime.Now;

            try
            {
                ordine.IDUtente = userID;
                ordine.Data = dataOrdine;
                ordine.Stato = false;

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
            ViewBag.Articoli = new SelectList(articoli, "IDArticolo", "Nome", ordine.IDArticolo);

            return View("Ordine");
        }

    }
}
