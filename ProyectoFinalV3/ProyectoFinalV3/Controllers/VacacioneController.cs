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
    public class VacacioneController : Controller
    {
        private SistemaNominaEntities db = new SistemaNominaEntities();

        // GET: Vacacione
        public ActionResult Index(string busqueda, string opcion)
        {
            var vacaciones = db.Vacaciones.Include(v => v.Empleado1);
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
                return View(db.Vacaciones.Where(x => x.Desde.Month.Equals(month) || busqueda == null).ToList());
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
                return View(db.Vacaciones.Where(x => x.Desde.Year.Equals(month) || busqueda == null).ToList());
            }
            else
            {
                return View(vacaciones.ToList());
            }
        }

        // GET: Vacacione/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacacione vacacione = db.Vacaciones.Find(id);
            if (vacacione == null)
            {
                return HttpNotFound();
            }
            return View(vacacione);
        }

        // GET: Vacacione/Create
        public ActionResult Create()
        {
            ViewBag.Empleado = new SelectList(db.Empleados, "Codigo_Empleado", "Nombre");
            return View();
        }

        // POST: Vacacione/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Vacaciones_ID,Empleado,Desde,Hasta,Correspondiente_A,Comentarios")] Vacacione vacacione)
        {
            if (ModelState.IsValid)
            {
                db.Vacaciones.Add(vacacione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empleado = new SelectList(db.Empleados, "Codigo_Empleado", "Nombre", vacacione.Empleado);
            return View(vacacione);
        }

        // GET: Vacacione/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacacione vacacione = db.Vacaciones.Find(id);
            if (vacacione == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empleado = new SelectList(db.Empleados, "Codigo_Empleado", "Nombre", vacacione.Empleado);
            return View(vacacione);
        }

        // POST: Vacacione/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vacaciones_ID,Empleado,Desde,Hasta,Correspondiente_A,Comentarios")] Vacacione vacacione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacacione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empleado = new SelectList(db.Empleados, "Codigo_Empleado", "Nombre", vacacione.Empleado);
            return View(vacacione);
        }

        // GET: Vacacione/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacacione vacacione = db.Vacaciones.Find(id);
            if (vacacione == null)
            {
                return HttpNotFound();
            }
            return View(vacacione);
        }

        // POST: Vacacione/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacacione vacacione = db.Vacaciones.Find(id);
            db.Vacaciones.Remove(vacacione);
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
