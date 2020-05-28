using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaRepuestosAuto_BD1_WEB.Models;
using TiendaRepuestosAuto_BD1_WEB.Models.DataBaseModelForApp;

namespace TiendaRepuestosAuto_BD1_WEB.Controllers
{
    public class PersonasController : Controller
    {
        private TiendaRepuestosAuto_BD1Entities3 db = new TiendaRepuestosAuto_BD1Entities3();

        // GET: Personas
        public ActionResult Index(string Nombre, int? Cedula)
        {
            var personas = db.Persona.Include(p => p.Cliente).Where((p => p.nombre.StartsWith(Nombre) || Nombre == null)).Where(p => p.Cedula.ToString().StartsWith(Cedula.ToString()) || Cedula == null);
            return View(personas.ToList());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            ViewBag.ID_ClientePersona = new SelectList(db.Cliente, "ID_Cliente", "Direccion");
            ViewBag.ID_EstadoDeCliente = new SelectList(db.EstadoDeCliente, "ID_EstadoDeCliente", "Tipo");
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
                //string result1 = "";
                ObjectParameter result = new ObjectParameter("OpReturn",typeof(string));
                db.spAddClienteAndPersona2(persona.Cedula, persona.nombre, cliente.Direccion, cliente.Ciudad, cliente.ID_EstadoDeCliente, result);
                System.Diagnostics.Debug.WriteLine(result.ToString());
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

            //ViewBag.ID_ClientePersona = new SelectList(db.Clientes, "ID_Cliente", "Direccion", persona.ID_ClientePersona);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_EstadoDeCliente = new SelectList(db.EstadoDeCliente, "ID_EstadoDeCliente", "Tipo", persona.Cliente.ID_EstadoDeCliente);
            personaModel personaModel = new personaModel
            {
                Cedula = persona.Cedula,
                nombre = persona.nombre,
                Ciudad = persona.Cliente.Ciudad,
                Direccion = persona.Cliente.Direccion,
                ID_EstadoDeCliente = persona.Cliente.ID_EstadoDeCliente
            };
            return View(personaModel);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(personaModel personaModel)
        {
            if (ModelState.IsValid)
            {
                db.spModifyPersona(personaModel.Cedula, personaModel.nombre, personaModel.Direccion, personaModel.Ciudad, personaModel.ID_EstadoDeCliente);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ID_ClientePersona = new SelectList(db.Cliente, "ID_Cliente", "Direccion", persona.ID_ClientePersona);
            return View(personaModel);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
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
            Persona persona = db.Persona.Find(id);
            db.Persona.Remove(persona);
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
            var personas = db.Persona.Include(p => p.Cliente);
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

        public ActionResult suspenderPersona(int? id)
        {
            db.spSuspenderPersona(id);
            return RedirectToAction("Index");
        }
    }
}
