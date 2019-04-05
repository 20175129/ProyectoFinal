using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseFirst.Models;

namespace DatabaseFirst.Controllers
{
    public class datosController : Controller
    {
        private registrosEntities db = new registrosEntities();

        // GET: datos
        public ActionResult Index()
        {
            return View(db.datos.ToList());
        }

        // GET: datos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            datos datos = db.datos.Find(id);
            if (datos == null)
            {
                return HttpNotFound();
            }
            return View(datos);
        }

        // GET: datos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: datos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Edad,Carrera,Cuatrimestre")] datos datos)
        {
            if (ModelState.IsValid)
            {
                db.datos.Add(datos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(datos);
        }

        // GET: datos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            datos datos = db.datos.Find(id);
            if (datos == null)
            {
                return HttpNotFound();
            }
            return View(datos);
        }

        // POST: datos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Edad,Carrera,Cuatrimestre")] datos datos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datos);
        }

        // GET: datos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            datos datos = db.datos.Find(id);
            if (datos == null)
            {
                return HttpNotFound();
            }
            return View(datos);
        }

        // POST: datos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            datos datos = db.datos.Find(id);
            db.datos.Remove(datos);
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
