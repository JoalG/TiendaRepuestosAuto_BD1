using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaRepuestosAuto_BD1_WEB.Models;

namespace TiendaRepuestosAuto_BD1_WEB.Controllers
{
    public class FabricanteDeAutoesController : Controller
    {
        private TiendaRepuestosAuto_BD1Entities db = new TiendaRepuestosAuto_BD1Entities();

        // GET: FabricanteDeAutoes
        public ActionResult Index()
        {
            return View(db.FabricanteDeAutos.ToList());
        }

        // GET: FabricanteDeAutoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FabricanteDeAuto fabricanteDeAuto = db.FabricanteDeAutos.Find(id);
            if (fabricanteDeAuto == null)
            {
                return HttpNotFound();
            }
            return View(fabricanteDeAuto);
        }

        // GET: FabricanteDeAutoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FabricanteDeAutoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_FabricanteDeAutos,Nombre")] FabricanteDeAuto fabricanteDeAuto)
        {
            if (ModelState.IsValid)
            {
                db.FabricanteDeAutos.Add(fabricanteDeAuto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fabricanteDeAuto);
        }

        // GET: FabricanteDeAutoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FabricanteDeAuto fabricanteDeAuto = db.FabricanteDeAutos.Find(id);
            if (fabricanteDeAuto == null)
            {
                return HttpNotFound();
            }
            return View(fabricanteDeAuto);
        }

        // POST: FabricanteDeAutoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_FabricanteDeAutos,Nombre")] FabricanteDeAuto fabricanteDeAuto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fabricanteDeAuto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fabricanteDeAuto);
        }

        // GET: FabricanteDeAutoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FabricanteDeAuto fabricanteDeAuto = db.FabricanteDeAutos.Find(id);
            if (fabricanteDeAuto == null)
            {
                return HttpNotFound();
            }
            return View(fabricanteDeAuto);
        }

        // POST: FabricanteDeAutoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FabricanteDeAuto fabricanteDeAuto = db.FabricanteDeAutos.Find(id);
            db.FabricanteDeAutos.Remove(fabricanteDeAuto);
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
