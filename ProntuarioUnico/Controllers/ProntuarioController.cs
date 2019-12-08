using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProntuarioUnico.Controllers
{
    public class ProntuarioController : Controller
    {
        // GET: Prontuario
        public ActionResult Index()
        {
            return View();
        }
    }
}