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
    public class PermisoController : Controller
    {
        private SistemaNominaEntities db = new SistemaNominaEntities();

        // GET: Permiso
        public ActionResult Index()
        {
            var permisos = db.Permisos.Include(p => p.Empleado1);
            return View(permisos.ToList());
        }

        // GET: Permiso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permiso permiso = db.Permisos.Find(id);
            if (permiso == null)
            {
                return HttpNotFound();
            }
            return View(permiso);
        }

        // GET: Permiso/Create
        public ActionResult Create()
        {
            ViewBag.Empleado = new SelectList(db.Empleados, "Codigo_Empleado", "Nombre");
            return View();
        }

        // POST: Permiso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Permiso_ID,Empleado,Desde,Hasta,Comentarios")] Permiso permiso)
        {
            if (ModelState.IsValid)
            {
                db.Permisos.Add(permiso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empleado = new SelectList(db.Empleados, "Codigo_Empleado", "Nombre", permiso.Empleado);
            return View(permiso);
        }

        // GET: Permiso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permiso permiso = db.Permisos.Find(id);
            if (permiso == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empleado = new SelectList(db.Empleados, "Codigo_Empleado", "Nombre", permiso.Empleado);
            return View(permiso);
        }

        // POST: Permiso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Permiso_ID,Empleado,Desde,Hasta,Comentarios")] Permiso permiso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permiso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empleado = new SelectList(db.Empleados, "Codigo_Empleado", "Nombre", permiso.Empleado);
            return View(permiso);
        }

        // GET: Permiso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permiso permiso = db.Permisos.Find(id);
            if (permiso == null)
            {
                return HttpNotFound();
            }
            return View(permiso);
        }

        // POST: Permiso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Permiso permiso = db.Permisos.Find(id);
            db.Permisos.Remove(permiso);
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
