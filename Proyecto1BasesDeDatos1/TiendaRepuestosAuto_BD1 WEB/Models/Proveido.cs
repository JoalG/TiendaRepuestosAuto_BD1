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
    
    public partial class Proveido
    {
        public int C_Ganancia { get; set; }
        public decimal Precio { get; set; }
        public int ID_Proveedor { get; set; }
        public int ID_Parte { get; set; }
    
        public virtual Parte Parte { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}
