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
    public class MantenimientoCargosController : Controller
    {
        private SistemaNominaEntities db = new SistemaNominaEntities();

        // GET: MantenimientoCargos
        public ActionResult Index()
        {
            return View(db.MantenimientoCargos.ToList());
        }

        // GET: MantenimientoCargos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MantenimientoCargo mantenimientoCargo = db.MantenimientoCargos.Find(id);
            if (mantenimientoCargo == null)
            {
                return HttpNotFound();
            }
            return View(mantenimientoCargo);
        }

        // GET: MantenimientoCargos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MantenimientoCargos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodigoCargo,Cargo")] MantenimientoCargo mantenimientoCargo)
        {
            if (ModelState.IsValid)
            {
                db.MantenimientoCargos.Add(mantenimientoCargo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mantenimientoCargo);
        }

        // GET: MantenimientoCargos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MantenimientoCargo mantenimientoCargo = db.MantenimientoCargos.Find(id);
            if (mantenimientoCargo == null)
            {
                return HttpNotFound();
            }
            return View(mantenimientoCargo);
        }

        // POST: MantenimientoCargos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodigoCargo,Cargo")] MantenimientoCargo mantenimientoCargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mantenimientoCargo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mantenimientoCargo);
        }

        // GET: MantenimientoCargos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MantenimientoCargo mantenimientoCargo = db.MantenimientoCargos.Find(id);
            if (mantenimientoCargo == null)
            {
                return HttpNotFound();
            }
            return View(mantenimientoCargo);
        }

        // POST: MantenimientoCargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MantenimientoCargo mantenimientoCargo = db.MantenimientoCargos.Find(id);
            db.MantenimientoCargos.Remove(mantenimientoCargo);
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
