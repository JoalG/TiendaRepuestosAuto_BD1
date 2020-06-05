using Microsoft.Ajax.Utilities;
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
        private TiendaRepuestosAuto_BD1Entities4 db = new TiendaRepuestosAuto_BD1Entities4();

        // GET: Partes
        public ActionResult Index(string ModeloFind, int? AnnoFind)
        {
            
            if(ModeloFind != null && AnnoFind != null)
            {
                List<Parte> partes = new List<Parte>();
                var partesPorModeloAnno = db.spFindPartePorModeloAño(ModeloFind, AnnoFind).ToList();
                foreach(var item in partesPorModeloAnno)
                {
                    var parte = new Parte
                    {
                        ID_Parte = item.ID_Parte,
                        Nombre = item.Nombre,
                        Marca = item.Marca,
                        ID_FabricanteDePiezas = item.ID_FabricanteDePiezas,
                        FabricanteDePiezas = db.FabricanteDePiezas.Find(item.ID_FabricanteDePiezas)
                    };
                    partes.Add(parte);
                }
                return View(partes);
            }
            else
            {
                var partes = db.Parte.Include(f => f.FabricanteDePiezas).ToList();
                return View(partes);
            }
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
            var IDsTiposDeAutomovil = db.spFindTiposDeAutoMovilForParte(parte.ID_Parte).ToList();
            //IDsTiposDeAutomovil.ToList();

            List<TipoDeAutomovil> tipos = new List<TipoDeAutomovil>();

            foreach (var item in IDsTiposDeAutomovil)
            {
                tipos.Add(db.TipoDeAutomovil.Find(item.GetValueOrDefault()));
            }

            ParteModelo parteModelo = new ParteModelo
            {
                ID_Parte = parte.ID_Parte,
                FabricanteDePiezas = parte.FabricanteDePiezas,
                ID_FabricanteDePiezas = parte.ID_FabricanteDePiezas,
                Nombre = parte.Nombre,
                Marca = parte.Marca,
                tiposDeAuto = tipos
            };

            //ViewBag.tiposA = tipos;
            return View(parteModelo);
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

                if (result.Value.ToString() == "Record Inserted Successfully")
                {
                    ViewBag.Resultado = true;
                }
                else
                {
                    ViewBag.Resultado = false;
                }

                ViewBag.Message = result.Value.ToString();
                ViewBag.ID_FabricanteDePiezas = new SelectList(db.FabricanteDePiezas, "ID_FabricanteDePiezas", "Nombre");
                return View(parte);
            }

            ViewBag.ID_FabricanteDePiezas = new SelectList(db.FabricanteDePiezas, "ID_FabricanteDePiezas", "Nombre");
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

        // GET: Partes/Edit/5
        public ActionResult AsociarConTipoDeAutomovil(int? id)
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
            ParteParaTipoDeAutomovilModel parteT = new ParteParaTipoDeAutomovilModel
            {
                ID_Parte = parte.ID_Parte,
                ID_TipoDeAutomovil = 1,
                nombreParte = parte.Nombre
            };

            var tipos = db.TipoDeAutomovil
                .Where(x => x.ID_TipoDeAutomovil == x.ID_TipoDeAutomovil)
                .Select(x => new
                {
                    ID_TipoDeAutomovil = x.ID_TipoDeAutomovil,
                    Name = x.Modelo + " - " + x.Año.ToString()
                });


            ViewBag.ID_TipoDeAutomovil = new SelectList(tipos, "ID_TipoDeAutomovil", "Name");
            return View(parteT);
        }

        // POST: Partes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AsociarConTipoDeAutomovil(ParteParaTipoDeAutomovilModel parte)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter result = new ObjectParameter("OpReturn", typeof(string));
                TipoDeAutomovil tipo = db.TipoDeAutomovil.Find(parte.ID_TipoDeAutomovil);
                db.spAssociateParteConTipoDeAutomovil(parte.ID_Parte, parte.ID_TipoDeAutomovil, tipo.ID_FabricanteDeAutos,result);
                if (result.Value.ToString() == "Record Inserted Successfully")
                {
                    ViewBag.Resultado = true;
                }
                else
                {
                    ViewBag.Resultado = false;
                }
                ViewBag.Message = result.Value.ToString();

                var tipos = db.TipoDeAutomovil
                    .Where(x => x.ID_TipoDeAutomovil == x.ID_TipoDeAutomovil)
                    .Select(x => new
                    {
                        ID_TipoDeAutomovil = x.ID_TipoDeAutomovil,
                        Name = x.Modelo + " - " + x.Año.ToString()
                    });

                ViewBag.ID_TipoDeAutomovil = new SelectList(tipos, "ID_TipoDeAutomovil", "Name");
                return View(parte);
            }
            var tipos2 = db.TipoDeAutomovil
                .Where(x => x.ID_TipoDeAutomovil == x.ID_TipoDeAutomovil)
                .Select(x => new
                {
                    ID_TipoDeAutomovil = x.ID_TipoDeAutomovil,
                    Name = x.Modelo + " - " + x.Año.ToString()
                });

            ViewBag.ID_TipoDeAutomovil = new SelectList(tipos2, "ID_TipoDeAutomovil", "Name");
            return View(parte);
        }
    }
}
