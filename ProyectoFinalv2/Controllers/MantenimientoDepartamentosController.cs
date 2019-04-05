using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalv2.Models;

namespace ProyectoFinalv2.Controllers
{
    public class MantenimientoDepartamentosController : Controller
    {
        private SistemaNominaEntities db = new SistemaNominaEntities();

        // GET: MantenimientoDepartamentos
        public ActionResult Index()
        {
            return View(db.MantenimientoDepartamentos.ToList());
        }

        // GET: MantenimientoDepartamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MantenimientoDepartamento mantenimientoDepartamento = db.MantenimientoDepartamentos.Find(id);
            if (mantenimientoDepartamento == null)
            {
                return HttpNotFound();
            }
            return View(mantenimientoDepartamento);
        }

        // GET: MantenimientoDepartamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MantenimientoDepartamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodigoDepartamento,Nombre,Encargado")] MantenimientoDepartamento mantenimientoDepartamento)
        {
            if (ModelState.IsValid)
            {
                db.MantenimientoDepartamentos.Add(mantenimientoDepartamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mantenimientoDepartamento);
        }

        // GET: MantenimientoDepartamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MantenimientoDepartamento mantenimientoDepartamento = db.MantenimientoDepartamentos.Find(id);
            if (mantenimientoDepartamento == null)
            {
                return HttpNotFound();
            }
            return View(mantenimientoDepartamento);
        }

        // POST: MantenimientoDepartamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodigoDepartamento,Nombre,Encargado")] MantenimientoDepartamento mantenimientoDepartamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mantenimientoDepartamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mantenimientoDepartamento);
        }

        // GET: MantenimientoDepartamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MantenimientoDepartamento mantenimientoDepartamento = db.MantenimientoDepartamentos.Find(id);
            if (mantenimientoDepartamento == null)
            {
                return HttpNotFound();
            }
            return View(mantenimientoDepartamento);
        }

        // POST: MantenimientoDepartamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MantenimientoDepartamento mantenimientoDepartamento = db.MantenimientoDepartamentos.Find(id);
            db.MantenimientoDepartamentos.Remove(mantenimientoDepartamento);
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
