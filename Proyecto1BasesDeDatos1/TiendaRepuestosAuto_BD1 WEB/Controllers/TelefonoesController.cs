using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaRepuestosAuto_BD1_WEB.Models;
using TiendaRepuestosAuto_BD1_WEB.Models.DataBaseModelForApp;

namespace TiendaRepuestosAuto_BD1_WEB.Controllers
{
    public class TelefonoesController : Controller
    {
        private TiendaRepuestosAuto_BD1Entities4 db = new TiendaRepuestosAuto_BD1Entities4();

        // GET: Telefonoes
        public ActionResult Index()
        {
            var telefono = db.Telefono.Include(t => t.Persona);
            return View(telefono.ToList());
        }

        // GET: Telefonoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono telefono = db.Telefono.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        // GET: Telefonoes/Create
        public ActionResult Create(int Cedula,string nombre )
        {
            TelefonoModel telf = new TelefonoModel
            {
                Nombre = nombre,
                Cedula = Cedula,

            };

            return View(telf);
        }

        // POST: Telefonoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Telefono,NumeroDeTelefono,Cedula")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.Telefono.Add(telefono);
                db.SaveChanges();
                return RedirectToAction("Edit", new { Controller="Personas", id = telefono.Cedula });  
                return RedirectToAction("Index");
            }

            ViewBag.Cedula = new SelectList(db.Persona, "Cedula", "nombre", telefono.Cedula);
            return View(telefono);
        }

        // GET: Telefonoes/Edit/5
        public ActionResult Edit(int? id, string Nombre)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono telefono = db.Telefono.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            TelefonoModel tel = new TelefonoModel
            {
                Cedula = telefono.Cedula,
                ID_Telefono = telefono.ID_Telefono,
                Nombre = Nombre,
                NumeroDeTelefono = telefono.NumeroDeTelefono
            };
            return View(tel);
        }

        // POST: Telefonoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Telefono,NumeroDeTelefono,Cedula")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefono).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cedula = new SelectList(db.Persona, "Cedula", "nombre", telefono.Cedula);
            return View(telefono);
        }

        // GET: Telefonoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono telefono = db.Telefono.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        // POST: Telefonoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telefono telefono = db.Telefono.Find(id);
            db.Telefono.Remove(telefono);
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
