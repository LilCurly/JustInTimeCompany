using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JustInTimeCompany_MuzikantovRoman.Controllers
{
    public class PlanesController : Controller
    {
        public ActionResult Show()
        {
            return View();
        }

        public ActionResult Confirm()
        {
            return View();
        }
    }
}