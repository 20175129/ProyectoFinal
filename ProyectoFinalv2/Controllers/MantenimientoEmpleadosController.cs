using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalv2.Models;
using System.Data.Entity;
using System.Net;

namespace ProyectoFinalv2.Controllers
{
    public class MantenimientoEmpleadosController : Controller
    {
        // GET: MantenimientoEmpleados
        private SistemaNominaEntities db = new SistemaNominaEntities();
        public ActionResult Index()
        {
            return View(db.MantenimientoEmpleados.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Empleados()
        {
            var items = db.MantenimientoCargos.ToList();
            if (items != null)
            {

                ViewBag.data = items;
            }
            return View();



        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "CodigoEmpleado, NombreEmpleado, ApellidoEmpleado, TelefonoEmpleado, DepartamentoEmpleado, CargoEmpleado, FechaIngresoEmpleado, SalarioEmpleado, Estatus")] MantenimientoEmpleado mantenimientoEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.MantenimientoEmpleados.Add(mantenimientoEmpleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mantenimientoEmpleado);
        }

        public ActionResult Editar(int? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Id,CodigoEmpleado, NombreEmpleado, ApellidoEmpleado, TelefonoEmpleado, DepartamentoEmpleado, CargoEmpleado, FechaIngresoEmpelado, SalarioEmpleado, Estatus")] MantenimientoEmpleado mantenimientoEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mantenimientoEmpleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mantenimientoEmpleado);
        }

        public ActionResult Eliminar(int? id)
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
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmada(int id)
        {
            MantenimientoEmpleado mantenimientoEmpleado = db.MantenimientoEmpleados.Find(id);
            db.MantenimientoEmpleados.Remove(mantenimientoEmpleado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}