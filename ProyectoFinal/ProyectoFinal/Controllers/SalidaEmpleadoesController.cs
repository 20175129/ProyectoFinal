using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class SalidaEmpleadoesController : Controller
    {
        private sistemaNominaEntities db = new sistemaNominaEntities();

        // GET: SalidaEmpleadoes
        public ActionResult Index()
        {
            var salidaEmpleados = db.SalidaEmpleados.Include(s => s.MantenimientoEmpleado);
            return View(salidaEmpleados.ToList());
        }

        // GET: SalidaEmpleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEmpleado salidaEmpleado = db.SalidaEmpleados.Find(id);
            if (salidaEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(salidaEmpleado);
        }

        // GET: SalidaEmpleadoes/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpleado = new SelectList(db.MantenimientoEmpleados, "Id", "CodigoEmpleado");
            return View();
        }

        // POST: SalidaEmpleadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSalida,IdEmpleado,TipoSalida,Motivo,FechaSalida")] SalidaEmpleado salidaEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.SalidaEmpleados.Add(salidaEmpleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpleado = new SelectList(db.MantenimientoEmpleados, "Id", "CodigoEmpleado", salidaEmpleado.IdEmpleado);
            return View(salidaEmpleado);
        }

        // GET: SalidaEmpleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEmpleado salidaEmpleado = db.SalidaEmpleados.Find(id);
            if (salidaEmpleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpleado = new SelectList(db.MantenimientoEmpleados, "Id", "CodigoEmpleado", salidaEmpleado.IdEmpleado);
            return View(salidaEmpleado);
        }

        // POST: SalidaEmpleadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSalida,IdEmpleado,TipoSalida,Motivo,FechaSalida")] SalidaEmpleado salidaEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salidaEmpleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpleado = new SelectList(db.MantenimientoEmpleados, "Id", "CodigoEmpleado", salidaEmpleado.IdEmpleado);
            return View(salidaEmpleado);
        }

        // GET: SalidaEmpleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEmpleado salidaEmpleado = db.SalidaEmpleados.Find(id);
            if (salidaEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(salidaEmpleado);
        }

        // POST: SalidaEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalidaEmpleado salidaEmpleado = db.SalidaEmpleados.Find(id);
            db.SalidaEmpleados.Remove(salidaEmpleado);
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
