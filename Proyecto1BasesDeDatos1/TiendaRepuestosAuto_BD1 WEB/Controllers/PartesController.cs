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
    public class PartesController : Controller
    {
        private TiendaRepuestosAuto_BD1Entities2 db = new TiendaRepuestosAuto_BD1Entities2();

        // GET: Partes
        public ActionResult Index()
        {
            var parte = db.Parte.Include(p => p.FabricanteDePiezas);
            return View(parte.ToList());
        }

        // GET: Partes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parte parte = db.Parte.Find(id);
            if (parte == null)
            {
                return HttpNotFound();
            }
            return View(parte);
        }

        // GET: Partes/Create
        public ActionResult Create()
        {
            ViewBag.ID_FabricanteDePiezas = new SelectList(db.FabricanteDePiezas, "ID_FabricanteDePiezas", "Nombre");
            return View();
        }

        // POST: Partes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ParteModelo parte)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter result = new ObjectParameter("OpReturn", typeof(string));
                db.spAddParte(parte.Nombre, parte.Marca, parte.ID_FabricanteDePiezas, result);
                return RedirectToAction("Index");
            }

            ViewBag.ID_FabricanteDePiezas = new SelectList(db.FabricanteDePiezas, "ID_FabricanteDePiezas", "Nombre", parte.ID_FabricanteDePiezas);
            return View(parte);
        }

        // GET: Partes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parte parte = db.Parte.Find(id);
            if (parte == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_FabricanteDePiezas = new SelectList(db.FabricanteDePiezas, "ID_FabricanteDePiezas", "Nombre", parte.ID_FabricanteDePiezas);
            return View(parte);
        }

        // POST: Partes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Parte,Nombre,Marca,ID_FabricanteDePiezas")] Parte parte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_FabricanteDePiezas = new SelectList(db.FabricanteDePiezas, "ID_FabricanteDePiezas", "Nombre", parte.ID_FabricanteDePiezas);
            return View(parte);
        }

        // GET: Partes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parte parte = db.Parte.Find(id);
            if (parte == null)
            {
                return HttpNotFound();
            }
            return View(parte);
        }

        // POST: Partes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ObjectParameter result = new ObjectParameter("OpReturn", typeof(string));
            db.spBorrarParte(id, result);
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
