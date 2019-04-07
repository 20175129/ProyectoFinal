using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalV3.Models;

namespace ProyectoFinalV3.Controllers
{
    public class SalidaController : Controller
    {
        private SistemaNominaEntities db = new SistemaNominaEntities();

        // GET: Salida
        [HttpGet]
        public ActionResult Index(string opcion, string busqueda)
        {
            var salidas = db.Salidas.Include(s => s.Empleado1);
            int month = 0;


            if (opcion == "Mes")
            {
                try
                {
                    month = Int32.Parse(busqueda);
                }
                catch (FormatException e)
                {

                }
                return View(db.Salidas.Where(x => x.Fecha_Salida.Month.Equals(month) || busqueda == null).ToList());
            }
            else if (opcion == "Año")
            {
                try
                {
                    month = Int32.Parse(busqueda);
                }
                catch (FormatException e)
                {

                }
                return View(db.Salidas.Where(x => x.Fecha_Salida.Year.Equals(month) || busqueda == null).ToList());
            }
            else
            {
                return View(db.Salidas.ToList());
            }
            }

        // GET: Salida/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida salida = db.Salidas.Find(id);
            if (salida == null)
            {
                return HttpNotFound();
            }
            return View(salida);
        }

        // GET: Salida/Create
        public ActionResult Create()
        {
            ViewBag.Empleado = new SelectList(db.Empleados, "Codigo_Empleado", "Nombre");
            return View();
        }

        // POST: Salida/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Salida_ID,Empleado,Tipo_Salida,Motivo,Fecha_Salida")] Salida salida)
        {
            if (ModelState.IsValid)
            {
                db.Salidas.Add(salida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empleado = new SelectList(db.Empleados, "Codigo_Empleado", "Nombre", salida.Empleado);
            return View(salida);
        }

        // GET: Salida/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida salida = db.Salidas.Find(id);
            if (salida == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empleado = new SelectList(db.Empleados, "Codigo_Empleado", "Nombre", salida.Empleado);
            return View(salida);
        }

        // POST: Salida/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Salida_ID,Empleado,Tipo_Salida,Motivo,Fecha_Salida")] Salida salida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empleado = new SelectList(db.Empleados, "Codigo_Empleado", "Nombre", salida.Empleado);
            return View(salida);
        }

        // GET: Salida/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida salida = db.Salidas.Find(id);
            if (salida == null)
            {
                return HttpNotFound();
            }
            return View(salida);
        }

        // POST: Salida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salida salida = db.Salidas.Find(id);
            db.Salidas.Remove(salida);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
