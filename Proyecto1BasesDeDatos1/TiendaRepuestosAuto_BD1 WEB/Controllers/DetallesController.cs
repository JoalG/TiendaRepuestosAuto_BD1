using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaRepuestosAuto_BD1_WEB.Models;
using TiendaRepuestosAuto_BD1_WEB.Models.DataBaseModelForApp;

namespace TiendaRepuestosAuto_BD1_WEB.Controllers
{
    public class DetallesController : Controller
    {
        private TiendaRepuestosAuto_BD1Entities4 db = new TiendaRepuestosAuto_BD1Entities4();

        // GET: Detalles
        public ActionResult Index()
        {
            var detalle = db.Detalle.Include(d => d.Orden).Include(d => d.Parte).Include(d => d.Proveedor);
            return View(detalle.ToList());
        }

        // GET: Detalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle detalle = db.Detalle.Find(id);
            if (detalle == null)
            {
                return HttpNotFound();
            }
            return View(detalle);
        }

        public JsonResult GetProveidoList(int? ID_Parte)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var proveidos = db.Proveido.Include(p => p.Proveedor).Where(p => p.ID_Parte == ID_Parte).ToList();

            List<ProveedorModel> proveedores = new List<ProveedorModel>();
            foreach (var item in proveidos)
            {
                ProveedorModel proveedor = new ProveedorModel
                {
                    ID_Proveedor = item.ID_Proveedor,
                    Nombre = item.Proveedor.Nombre
                };
                proveedores.Add(proveedor);
            }
            return Json(proveedores, JsonRequestBehavior.AllowGet);

        }

        // GET: Detalles/Create
        public ActionResult Create(int id)
        {
            ViewBag.ID_Orden = new SelectList(db.Orden, "ID_Orden", "ID_Orden");
            ViewBag.Partes = new SelectList(db.Parte, "ID_Parte", "Nombre");
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre");
            DetalleModel detalle = new DetalleModel
            {
                ID_Orden = id
            };
            return View(detalle);
        }

        // POST: Detalles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DetalleModel detalle)
        {
            if (ModelState.IsValid)
            {
                db.spAddDetalleOrden(detalle.ID_Orden, detalle.ID_Proveedor, detalle.ID_Parte, detalle.Cantidad);
                return RedirectToAction("Details", new { Controller = "Orden", id = detalle.ID_Orden });
            }

            ViewBag.ID_Orden = new SelectList(db.Orden, "ID_Orden", "ID_Orden", detalle.ID_Orden);
            ViewBag.ID_Parte = new SelectList(db.Parte, "ID_Parte", "Nombre", detalle.ID_Parte);
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre", detalle.ID_Proveedor);
            return View(detalle);
        }

        // GET: Detalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle detalle = db.Detalle.Find(id);
            if (detalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Orden = new SelectList(db.Orden, "ID_Orden", "ID_Orden", detalle.ID_Orden);
            ViewBag.ID_Parte = new SelectList(db.Parte, "ID_Parte", "Nombre", detalle.ID_Parte);
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre", detalle.ID_Proveedor);
            return View(detalle);
        }

        // POST: Detalles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Detalle,Cantidad,ID_Proveedor,ID_Parte,ID_Orden")] Detalle detalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Orden = new SelectList(db.Orden, "ID_Orden", "ID_Orden", detalle.ID_Orden);
            ViewBag.ID_Parte = new SelectList(db.Parte, "ID_Parte", "Nombre", detalle.ID_Parte);
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "Nombre", detalle.ID_Proveedor);
            return View(detalle);
        }

        // GET: Detalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle detalle = db.Detalle.Find(id);
            if (detalle == null)
            {
                return HttpNotFound();
            }
            return View(detalle);
        }

        // POST: Detalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle detalle = db.Detalle.Find(id);
            db.Detalle.Remove(detalle);
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

        public ActionResult GetProveedors(int ID_Parte)
        {
            List<Proveido> proveidos = db.Proveido.Where(x => x.ID_Parte == ID_Parte).ToList();
            List<Proveedor> proveedores = new List<Proveedor>();
            foreach( var proveido in proveidos)
            {
                proveedores.Add(db.Proveedor.Find( proveido.ID_Proveedor));
            }
            //ViewBag.ID_Orden = new SelectList(db.Orden, "ID_Orden", "ID_Orden");
            ViewBag.Proveedores = new SelectList(proveedores, "ID_Proveedor", "nombre");


            return PartialView("DisplayProveedores");
        }
    }
}
