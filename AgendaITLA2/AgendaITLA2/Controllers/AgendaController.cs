using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgendaITLA2.Models;

namespace AgendaITLA2.Controllers
{
    public class AgendaController : Controller
    {
        private AgendaContactosDBEntities db = new AgendaContactosDBEntities();

        // GET: Agenda
        public ActionResult Index(string buscar)
        {
            var contacto = from m in db.Agenda
                         select m;

            if (!String.IsNullOrEmpty(buscar))
            {
                contacto = contacto.Where(s => s.Nombre.Contains(buscar));
            }
            return View(db.Agenda.ToList());
        }

        // GET: Agenda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendum agendum = db.Agenda.Find(id);
            if (agendum == null)
            {
                return HttpNotFound();
            }
            return View(agendum);
        }

        // GET: Agenda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agenda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Telefono,Direccion,Evento,Lugar,Fecha")] Agendum agendum)
        {
            if (ModelState.IsValid)
            {
                db.Agenda.Add(agendum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agendum);
        }

        // GET: Agenda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendum agendum = db.Agenda.Find(id);
            if (agendum == null)
            {
                return HttpNotFound();
            }
            return View(agendum);
        }

        // POST: Agenda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Telefono,Direccion,Evento,Lugar,Fecha")] Agendum agendum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agendum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agendum);
        }

        // GET: Agenda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendum agendum = db.Agenda.Find(id);
            if (agendum == null)
            {
                return HttpNotFound();
            }
            return View(agendum);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agendum agendum = db.Agenda.Find(id);
            db.Agenda.Remove(agendum);
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
