using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzeriaInForno.Controllers
{
    public class BackOfficeController : Controller
    {
        [Authorize (Roles ="Admin")]
        public ActionResult BackOffice()
        {
            return View();
        }
    }
}