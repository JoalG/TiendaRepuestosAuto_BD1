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
    public class ProveidoController : Controller
    {
        private TiendaRepuestosAuto_BD1Entities2 db = new TiendaRepuestosAuto_BD1Entities2();

        // GET: Proveido
        public ActionResult Index()
        {
            var proveido = db.Proveido.Include(p => p.Parte).Include(p => p.Proveedor);
            return View(proveido.ToList());
        }

        // GET: Proveido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveido proveido = db.Proveido.Find(id);
            if (proveido == null)
            {
                return HttpNotFound();
            }
            return View(proveido);
        }

        // GET: Proveido/Create
        public ActionResult Create()
        {
            ViewBag.ID_Parte = new SelectList(db.Parte, "ID_Parte", "Nombre");
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre");
            return View();
        }

        // POST: Proveido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ganancia,Precio,ID_Proveedor,ID_Parte")] Proveido proveido)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter result = new ObjectParameter("opReturn", typeof(string));
                db.spAssociateParteConProveedor(proveido.ID_Parte, proveido.ID_Proveedor, proveido.Precio, 500000, result);
                return RedirectToAction("Index");
            }

            ViewBag.ID_Parte = new SelectList(db.Parte, "ID_Parte", "Nombre", proveido.ID_Parte);
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre", proveido.ID_Proveedor);
            return View(proveido);
        }

        // GET: Proveido/Edit/5
        public ActionResult Edit(int? id1, int? id2)
        {
            if (id1 == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveido proveido = db.Proveido.Find(id1,id2);
            if (proveido == null)
            {
                return HttpNotFound();
            }
            ParteRelacionProveedorModel proveidoModel = new ParteRelacionProveedorModel
            {
                ID_Parte = proveido.ID_Parte,
                ID_Proveedor = proveido.ID_Proveedor,
                Ganancia = proveido.Ganancia,
                Precio = proveido.Precio,
                nombreParte = proveido.Parte.Nombre,
                nombreProveedor = proveido.Proveedor.Nombre
            };
            ViewBag.ID_Parte = new SelectList(db.Parte, "ID_Parte", "Nombre", proveido.ID_Parte);
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre", proveido.ID_Proveedor);
            return View(proveidoModel);
        }

        // POST: Proveido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ganancia,Precio,ID_Proveedor,ID_Parte")] Proveido proveido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Parte = new SelectList(db.Parte, "ID_Parte", "Nombre", proveido.ID_Parte);
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre", proveido.ID_Proveedor);
            return View(proveido);
        }

        // GET: Proveido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveido proveido = db.Proveido.Find(id);
            if (proveido == null)
            {
                return HttpNotFound();
            }
            return View(proveido);
        }

        // POST: Proveido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proveido proveido = db.Proveido.Find(id);
            db.Proveido.Remove(proveido);
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
