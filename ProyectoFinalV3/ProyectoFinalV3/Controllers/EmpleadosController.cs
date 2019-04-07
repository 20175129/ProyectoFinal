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
    public class EmpleadosController : Controller
    {
        private SistemaNominaEntities db = new SistemaNominaEntities();

        // GET: Empleados
     
        public ActionResult Index(string opcion, string busqueda)
        {
            var empleados = db.Empleados.Include(e => e.Cargo1).Include(e => e.Departamento1);
            var empleadosSearch = from s in db.Empleados
                                  select s;
            int month = 0;
            

            switch (opcion)
            {
                case "Departamento":
                    return View(db.Empleados.Where(x => x.Departamento1.Departamento1.Contains(busqueda) || busqueda == null).ToList());
                    break;

                case "Nombre":
                    return View(db.Empleados.Where(x => x.Nombre.Contains(busqueda) || busqueda == null).ToList());
                    break;

                case "Inactivo":
                    return View(db.Empleados.Where(x => x.Estatus.Equals("Inactivo") || busqueda == null).ToList());
                    break;
                case "Activo":
                    return View(db.Empleados.Where(x => x.Estatus.Equals("Activo") || busqueda == null).ToList());
                    break;

                case "Entrada":
                    try
                    {
                        month = Int32.Parse(busqueda);
                    }catch(FormatException e)
                    {

                    }
                    return View(db.Empleados.Where(x => x.Fecha_Ingreso.Month.Equals(month)).ToList());
                        break;

                default:
                    return View(db.Empleados.ToList());
                    break;

            }

        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.Cargo = new SelectList(db.Cargos, "Id_Cargo", "Cargo1");
            ViewBag.Departamento = new SelectList(db.Departamentos, "Codigo_Departamento", "Departamento1");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Empleado,Codigo_Empleado,Nombre,Apellido,Telefono,Departamento,Cargo,Fecha_Ingreso,Salario,Estatus")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cargo = new SelectList(db.Cargos, "Id_Cargo", "Cargo1", empleado.Cargo);
            ViewBag.Departamento = new SelectList(db.Departamentos, "Codigo_Departamento", "Departamento1", empleado.Departamento);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cargo = new SelectList(db.Cargos, "Id_Cargo", "Cargo1", empleado.Cargo);
            ViewBag.Departamento = new SelectList(db.Departamentos, "Codigo_Departamento", "Departamento1", empleado.Departamento);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Empleado,Codigo_Empleado,Nombre,Apellido,Telefono,Departamento,Cargo,Fecha_Ingreso,Salario,Estatus")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cargo = new SelectList(db.Cargos, "Id_Cargo", "Cargo1", empleado.Cargo);
            ViewBag.Departamento = new SelectList(db.Departamentos, "Codigo_Departamento", "Departamento1", empleado.Departamento);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleados.Find(id);
            db.Empleados.Remove(empleado);
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
