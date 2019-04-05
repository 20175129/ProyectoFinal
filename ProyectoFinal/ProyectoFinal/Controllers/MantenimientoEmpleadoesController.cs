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
    public class MantenimientoEmpleadoesController : Controller
    {
        private sistemaNominaEntities db = new sistemaNominaEntities();

        // GET: MantenimientoEmpleadoes
        public ActionResult Index()
        {
            return View(db.MantenimientoEmpleados.ToList());
        }

        // GET: MantenimientoEmpleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MantenimientoEmpleado mantenimientoEmpleado = db.MantenimientoEmpleados.Find(id);
            if (mantenimientoEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(mantenimientoEmpleado);
        }

        // GET: MantenimientoEmpleadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MantenimientoEmpleadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodigoEmpleado,NombreEmpleado,ApellidoEmpleado,TelefonoEmpleado,DepartamentoEmpleado,CargoEmpleado,FechaIngresoEmpleado,SalarioEmpleado,Estatus")] MantenimientoEmpleado mantenimientoEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.MantenimientoEmpleados.Add(mantenimientoEmpleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mantenimientoEmpleado);
        }

        // GET: MantenimientoEmpleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MantenimientoEmpleado mantenimientoEmpleado = db.MantenimientoEmpleados.Find(id);
            if (mantenimientoEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(mantenimientoEmpleado);
        }

        // POST: MantenimientoEmpleadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodigoEmpleado,NombreEmpleado,ApellidoEmpleado,TelefonoEmpleado,DepartamentoEmpleado,CargoEmpleado,FechaIngresoEmpleado,SalarioEmpleado,Estatus")] MantenimientoEmpleado mantenimientoEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mantenimientoEmpleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mantenimientoEmpleado);
        }

        // GET: MantenimientoEmpleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MantenimientoEmpleado mantenimientoEmpleado = db.MantenimientoEmpleados.Find(id);
            if (mantenimientoEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(mantenimientoEmpleado);
        }

        // POST: MantenimientoEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MantenimientoEmpleado mantenimientoEmpleado = db.MantenimientoEmpleados.Find(id);
            db.MantenimientoEmpleados.Remove(mantenimientoEmpleado);
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
