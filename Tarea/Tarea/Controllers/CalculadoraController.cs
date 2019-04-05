using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tarea.Models;

namespace Tarea.Controllers
{
    public class CalculadoraController : Controller
    {
        // GET: Calculadora
        public ActionResult Calculadora()
        {
            var calcu = new Calculadora();
            return View();
        }
        [HttpPost]
        public ActionResult Index(Calculadora calcula, string operacion)
        {
            if (operacion == "Sumar")
            {
                calcula.numeroTres = calcula.numeroUno + calcula.numeroDos;
            }
            if (operacion == "Restar")
            {
                calcula.numeroTres = calcula.numeroUno - calcula.numeroDos;
            }
            if (operacion == "Multiplicar")
            {
                calcula.numeroTres = calcula.numeroUno * calcula.numeroDos;
            }
            if (operacion == "Dividir")
            {
                calcula.numeroTres = calcula.numeroUno / calcula.numeroDos;
            }
            return View(calcula);
        }
    }
}