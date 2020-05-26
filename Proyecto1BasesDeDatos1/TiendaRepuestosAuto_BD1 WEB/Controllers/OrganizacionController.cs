using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaRepuestosAuto_BD1_WEB.Models;
using TiendaRepuestosAuto_BD1_WEB.Models.DataBaseModelForApp;

namespace TiendaRepuestosAuto_BD1_WEB.Controllers
{
    public class OrganizacionController : Controller
    {
        private TiendaRepuestosAuto_BD1Entities1 db = new TiendaRepuestosAuto_BD1Entities1();

        // GET: Organizacion
        public ActionResult Index()
        {
            var organizacions = db.Organizacion.Include(o => o.Cliente).Include(o => o.Contacto);
            return View(organizacions.ToList());
        }

        // GET: Organizacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizacion organizacion = db.Organizacion.Find(id);
            if (organizacion == null)
            {
                return HttpNotFound();
            }
            return View(organizacion);
        }

        // GET: Organizacion/Create
        public ActionResult Create()
        {
            ViewBag.ID_EstadoDeCliente = new SelectList(db.EstadoDeCliente, "ID_EstadoDeCliente", "Tipo");
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Direccion");
            ViewBag.ID_Contacto = new SelectList(db.Contacto, "ID_Contacto", "Nombre");
            return View();
        }

        // POST: Organizacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente, Organizacion organizacion, Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter result = new ObjectParameter("opReturn", typeof(string));
                db.spAddClienteAndOrganizacion(organizacion.CedulaJuridica, organizacion.Nombre, cliente.Direccion, cliente.Ciudad, cliente.ID_EstadoDeCliente, contacto.Nombre, contacto.Telefono, contacto.Cargo, result);
                return RedirectToAction("Index");
            }

            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Direccion", organizacion.ID_Cliente);
            ViewBag.ID_Contacto = new SelectList(db.Contacto, "ID_Contacto", "Nombre", organizacion.ID_Contacto);
            return View(organizacion);
        }

        // GET: Organizacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizacion organizacion = db.Organizacion.Find(id);
            if (organizacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_EstadoDeCliente = new SelectList(db.EstadoDeCliente, "ID_EstadoDeCliente", "Tipo", organizacion.Cliente.ID_EstadoDeCliente);

            OrganizacionModel organizacionModel = new OrganizacionModel
            {
                CedulaJuridica = organizacion.CedulaJuridica,
                Nombre = organizacion.Nombre,
                Ciudad = organizacion.Cliente.Ciudad,
                Direccion = organizacion.Cliente.Direccion,
                ID_EstadoDeCliente = organizacion.Cliente.ID_EstadoDeCliente,
                Contacto = new ContactoModel
                {
                    Nombre = organizacion.Contacto.Nombre,
                    Telefono = organizacion.Contacto.Telefono,
                    Cargo = organizacion.Contacto.Cargo
                }
            };

            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Direccion", organizacion.ID_Cliente);
            ViewBag.ID_Contacto = new SelectList(db.Contacto, "ID_Contacto", "Nombre", organizacion.ID_Contacto);
            return View(organizacionModel);
        }

        // POST: Organizacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrganizacionModel organizacion)
        {
            if (ModelState.IsValid)
            {
                db.spModifyOrganizacion(organizacion.CedulaJuridica,organizacion.Nombre,organizacion.Direccion,organizacion.Ciudad,organizacion.ID_EstadoDeCliente,organizacion.Contacto.Nombre,organizacion.Contacto.Telefono,organizacion.Contacto.Cargo);
                return RedirectToAction("Index");
            }
            return View(organizacion);
        }

        // GET: Organizacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizacion organizacion = db.Organizacion.Find(id);
            if (organizacion == null)
            {
                return HttpNotFound();
            }
            return View(organizacion);
        }

        // POST: Organizacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organizacion organizacion = db.Organizacion.Find(id);
            db.Organizacion.Remove(organizacion);
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
