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
    
    public partial class TelefonoProveedor
    {
        public int ID_TelefonoProveedor { get; set; }
        public long Telefono { get; set; }
        public int ID_Proveedor { get; set; }
    
        public virtual Proveedor Proveedor { get; set; }
    }
}
