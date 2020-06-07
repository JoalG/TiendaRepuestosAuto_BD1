using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaRepuestosAuto_BD1_WEB.Models.DataBaseModelForApp
{
    public class DetalleModel
    {
        [Display(Name = "Parte")]
        public int ID_Parte { get; set; }

        [Display(Name = "Proveedor")]
        public int ID_Proveedor { get; set; }


        public int Cantidad { get; set; }

        [Display(Name = "Orden #")]
        public int ID_Orden { get; set; }

    }
}