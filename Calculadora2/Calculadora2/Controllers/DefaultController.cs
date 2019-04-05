using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using ExcelDataReader;


namespace Calculadora2.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Calculadora()
        {
            return View();
        }

        public ActionResult Formulario()
        {
            return View();
        }

        public ActionResult Grados()
        {
            return View();
        }

        public ActionResult Excel()
        {
            return View();   
        }
        [HttpPost]
        public ActionResult LectorDeArchivos(HttpPostedFileBase archivo)
        {
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(archivo.InputStream);
            DataSet result = excelReader.AsDataSet();
            return View(result);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Como contactarme.";

            return View();
        }
    }
}