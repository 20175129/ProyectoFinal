using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace codefirst.Models
{
    public class RegistroesController : Controller
    {
        private Clase2 db = new Clase2();

        // GET: Registroes
        public ActionResult Index()
        {
            return View(db.data.ToList());
        }

        // GET: Registroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.data.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // GET: Registroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,edad,nombre,carrera,cuatrimestre")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                db.data.Add(registro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registro);
        }

        // GET: Registroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.data.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // POST: Registroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,edad,nombre,carrera,cuatrimestre")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registro);
        }

        // GET: Registroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.data.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // POST: Registroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registro registro = db.data.Find(id);
            db.data.Remove(registro);
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
