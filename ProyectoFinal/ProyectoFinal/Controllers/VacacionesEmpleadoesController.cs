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
    public class VacacionesEmpleadoesController : Controller
    {
        private sistemaNominaEntities db = new sistemaNominaEntities();

        // GET: VacacionesEmpleadoes
        public ActionResult Index()
        {
            var vacacionesEmpleados = db.VacacionesEmpleados.Include(v => v.MantenimientoEmpleado);
            return View(vacacionesEmpleados.ToList());
        }

        // GET: VacacionesEmpleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VacacionesEmpleado vacacionesEmpleado = db.VacacionesEmpleados.Find(id);
            if (vacacionesEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(vacacionesEmpleado);
        }

        // GET: VacacionesEmpleadoes/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpleado = new SelectList(db.MantenimientoEmpleados, "Id", "CodigoEmpleado");
            return View();
        }

        // POST: VacacionesEmpleadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdEmpleado,FechaDesde,FechaHasta,CorrespondienteAño,ComentarioVacacion")] VacacionesEmpleado vacacionesEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.VacacionesEmpleados.Add(vacacionesEmpleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpleado = new SelectList(db.MantenimientoEmpleados, "Id", "CodigoEmpleado", vacacionesEmpleado.IdEmpleado);
            return View(vacacionesEmpleado);
        }

        // GET: VacacionesEmpleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VacacionesEmpleado vacacionesEmpleado = db.VacacionesEmpleados.Find(id);
            if (vacacionesEmpleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpleado = new SelectList(db.MantenimientoEmpleados, "Id", "CodigoEmpleado", vacacionesEmpleado.IdEmpleado);
            return View(vacacionesEmpleado);
        }

        // POST: VacacionesEmpleadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdEmpleado,FechaDesde,FechaHasta,CorrespondienteAño,ComentarioVacacion")] VacacionesEmpleado vacacionesEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacacionesEmpleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpleado = new SelectList(db.MantenimientoEmpleados, "Id", "CodigoEmpleado", vacacionesEmpleado.IdEmpleado);
            return View(vacacionesEmpleado);
        }

        // GET: VacacionesEmpleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VacacionesEmpleado vacacionesEmpleado = db.VacacionesEmpleados.Find(id);
            if (vacacionesEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(vacacionesEmpleado);
        }

        // POST: VacacionesEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VacacionesEmpleado vacacionesEmpleado = db.VacacionesEmpleados.Find(id);
            db.VacacionesEmpleados.Remove(vacacionesEmpleado);
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
