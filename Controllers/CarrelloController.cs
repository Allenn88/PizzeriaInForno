using PizzeriaInForno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzeriaInForno.Controllers
{
    public class CarrelloController : Controller
    {
       private DBContext db = new DBContext();
       
        public ActionResult Carrello()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Login");
            }

            int userID = Convert.ToInt32(User.Identity.Name);

            
            List<Ordine> ordiniCarrello = db.Ordines                                           
                                            .Where(o => o.IDUtente == userID && o.Stato == false)
                                            .ToList();
            foreach(var ordine in ordiniCarrello) 
            {
                db.Entry(ordine).Reference(o=> o.Articolo).Load();
            }

            return View(ordiniCarrello);
        }

    }
}