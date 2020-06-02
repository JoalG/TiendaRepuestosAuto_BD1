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
    public class OrdenController : Controller
    {
        private TiendaRepuestosAuto_BD1Entities4 db = new TiendaRepuestosAuto_BD1Entities4();

        // GET: Orden
        public ActionResult Index()
        {

            List<OrdenModel> ordenes = new List<OrdenModel>();  

            var ordenesPersona = db.spGetOrdenesPersona().ToList();
            foreach(var item in ordenesPersona)
            {
                OrdenModel ordenActual = new OrdenModel
                {
                    ID_Orden = item.ID_Orden,
                    ID_Cliente = item.ID_Cliente,
                    Fecha = item.Fecha,
                    nombreDeCliente = item.Nombre,
                    IVA = item.IVA
                };
                ordenes.Add(ordenActual);
            }

            var ordenesOrganizacion = db.spGetOrdenesOrganizacion().ToList();
            foreach (var item in ordenesOrganizacion)
            {
                OrdenModel ordenActual = new OrdenModel
                {
                    ID_Orden = item.ID_Orden,
                    ID_Cliente = item.ID_Cliente,
                    Fecha = item.Fecha,
                    nombreDeCliente = item.Nombre,
                    IVA = item.IVA
                };
                ordenes.Add(ordenActual);
            }

            return View(ordenes);
        }

        // GET: Orden/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.Orden.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }

            OrdenModel ordenModel = new OrdenModel
            {
                ID_Orden = orden.ID_Orden,
                IVA = orden.IVA,
                ID_Cliente = orden.ID_Cliente,
                Fecha = orden.Fecha,
                nombreDeCliente = getNombreFromClienteInOrden(orden.ID_Orden),
                detalles = db.Detalle.Include(p => p.Parte).Include(p => p.Proveedor).Where(d => d.ID_Orden == orden.ID_Orden).ToList()
            };
            return View(ordenModel);
        }


        public string getNombreFromClienteInOrden(int ID_Orden)
        {
            var clientesPersona = db.spGetOrdenesPersona().ToList();
            foreach(var item in clientesPersona)
            {
                if (item.ID_Orden == ID_Orden)
                {
                    return item.Nombre;
                }
            }

            var clientesOrganizacion = db.spGetOrdenesOrganizacion().ToList();
            foreach (var item in clientesPersona)
            {
                if (item.ID_Orden == ID_Orden)
                {
                    return item.Nombre;
                }
            }

            return "Not Found";
        }



        public ActionResult CreateParaPersona()
        {
            ViewBag.ID_Cliente = new SelectList(db.Persona, "ID_ClientePersona", "Nombre");
            return View();
        }



        public ActionResult CreateParaOrganizacion()
        {
            ViewBag.ID_Cliente = new SelectList(db.Organizacion, "ID_Cliente", "Nombre");
            return View();
        }



        // POST: Orden/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateParaPersona(OrdenModel orden)
        {
            if (ModelState.IsValid)
            {

                db.spAddOrden(orden.ID_Cliente, orden.Fecha);

                return RedirectToAction("Index");
            }

            ViewBag.ID_Cliente = new SelectList(db.Persona, "ID_ClientePersona", "Nombre");
            return View(orden);
        }


        // POST: Orden/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateParaOrganizacion(OrdenModel orden)
        {
            if (ModelState.IsValid)
            {

                db.spAddOrden(orden.ID_Cliente, orden.Fecha);

                return RedirectToAction("Index");
            }

            ViewBag.ID_Cliente = new SelectList(db.Organizacion, "ID_Cliente", "Nombre");
            return View(orden);
        }


        // GET: Orden/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.Orden.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Direccion", orden.ID_Cliente);
            return View(orden);
        }

        // POST: Orden/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Orden,Fecha,IVA,ID_Cliente")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orden).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Direccion", orden.ID_Cliente);
            return View(orden);
        }

        // GET: Orden/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.Orden.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            return View(orden);
        }

        // POST: Orden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orden orden = db.Orden.Find(id);
            db.Orden.Remove(orden);
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