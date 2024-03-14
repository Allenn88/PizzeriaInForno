using PizzeriaInForno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Configuration;
using System.Data.Entity;

namespace PizzeriaInForno.Controllers
{
    public class LoginController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Login
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult Login(Utente utente)
        {
            Utente dbUtente = db.Utentes.FirstOrDefault(u => u.NomeUtente == utente.NomeUtente && u.Password == utente.Password);

            if (dbUtente != null)
            {
                FormsAuthentication.SetAuthCookie(dbUtente.IDUtente.ToString(), true);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Nome utente o password non validi.");
            return View();
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
          
            FormsAuthentication.SignOut();

           
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Registrati()
        { 
            return View(); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrati(Utente utente)
        {
            if (ModelState.IsValid)
            {
             
                if (db.Utentes.Any(u => u.NomeUtente == utente.NomeUtente))
                {
                    ModelState.AddModelError("", "Questo nome utente è già stato utilizzato.");
                }
                else
                {
                    utente.Role = "Utente";                 
                    db.Utentes.Add(utente);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
            }
            return View(utente);
        }
    }
}
