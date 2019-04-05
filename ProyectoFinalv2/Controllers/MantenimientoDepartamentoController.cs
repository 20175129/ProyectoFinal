using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalv2.Models;

namespace ProyectoFinalv2.Controllers
{
    public class MantenimientoDepartamentoController : Controller
    {
        // GET: MantenimientoDepartamento
        private SistemaNominaEntities db = new SistemaNominaEntities();
        public ActionResult Index()
        {
            return View(db.MantenimientoDepartamentos.ToList());
        }
    }
}