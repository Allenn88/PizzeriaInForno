using PizzeriaInForno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PizzeriaInForno.Controllers
{
    public class MenuController : Controller
    {
        private DBContext db = new DBContext();

        public ActionResult Menu()
        {
            List<Articolo> articoli = db.Articolos.ToList();

            return View(articoli);
        }
    }
}