using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaRepuestosAuto_BD1_WEB.Models;

namespace TiendaRepuestosAuto_BD1_WEB.Controllers
{
    public class PersonasController : Controller
    {
        private TiendaRepuestosAuto_BD1Entities db = new TiendaRepuestosAuto_BD1Entities();

        // GET: Personas
        public ActionResult Index()
        {
            var personas = db.Personas.Include(p => p.Cliente);
            return View(personas.ToList());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            ViewBag.ID_ClientePersona = new SelectList(db.Clientes, "ID_Cliente", "Direccion");
            ViewBag.ID_EstadoDeCliente = new SelectList(db.EstadoDeClientes, "ID_EstadoDeCliente", "Tipo");
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente, Persona persona)
        {
            if (ModelState.IsValid )
            {
                /*
                db.Clientes.Add(cliente);
                db.SaveChanges();
                persona.ID_ClientePersona = cliente.ID_Cliente;
                db.spAddPersonaOnly(persona.Cedula, persona.nombre, persona.ID_ClientePersona);
                */
               db.spAddClienteAndPersona(persona.Cedula, persona.nombre, cliente.Direccion, cliente.Ciudad, cliente.ID_EstadoDeCliente);
               return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

            ViewBag.ID_ClientePersona = new SelectList(db.Clientes, "ID_Cliente", "Direccion", persona.ID_ClientePersona);
            return View(persona);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ClientePersona = new SelectList(db.Clientes, "ID_Cliente", "Direccion", persona.ID_ClientePersona);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cedula,nombre,ID_ClientePersona")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ClientePersona = new SelectList(db.Clientes, "ID_Cliente", "Direccion", persona.ID_ClientePersona);
            return View(persona);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Personas.Find(id);
            db.Personas.Remove(persona);
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

        private bool isCedulaValida(int cedula)
        {
            var personas = db.Personas.Include(p => p.Cliente);
            personas.ToList();
            foreach (var item in personas)
            {
                if(item.Cedula == cedula)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
