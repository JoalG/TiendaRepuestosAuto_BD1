//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class ParteParaTipoDeAutomovil
    {
        public int ID_ParteParaTipoDeAutomovil { get; set; }
        public int ID_Parte { get; set; }
        public int ID_TipoDeAutomovil { get; set; }
        public int ID_FabricanteDeAutos { get; set; }
    
        public virtual Parte Parte { get; set; }
        public virtual TipoDeAutomovil TipoDeAutomovil { get; set; }
    }
}
