﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TiendaRepuestosAuto_BD1_WEB.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TiendaRepuestosAuto_BD1Entities : DbContext
    {
        public TiendaRepuestosAuto_BD1Entities()
            : base("name=TiendaRepuestosAuto_BD1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Contacto> Contactoes { get; set; }
        public virtual DbSet<Detalle> Detalles { get; set; }
        public virtual DbSet<EstadoDeCliente> EstadoDeClientes { get; set; }
        public virtual DbSet<FabricanteDeAuto> FabricanteDeAutos { get; set; }
        public virtual DbSet<FabricanteDePieza> FabricanteDePiezas { get; set; }
        public virtual DbSet<Orden> Ordens { get; set; }
        public virtual DbSet<Organizacion> Organizacions { get; set; }
        public virtual DbSet<Parte> Partes { get; set; }
        public virtual DbSet<ParteParaTipoDeAutomovil> ParteParaTipoDeAutomovils { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Proveedor> Proveedors { get; set; }
        public virtual DbSet<Proveido> Proveidoes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Telefono> Telefonoes { get; set; }
        public virtual DbSet<TelefonoProveedor> TelefonoProveedors { get; set; }
        public virtual DbSet<TipoDeAutomovil> TipoDeAutomovils { get; set; }
    }
}
