using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaRepuestosAuto_BD1_WEB.Models.DataBaseModelForApp
{
    public class DetalleModel
    {
        public int ID_Parte { get; set; }
        public int ID_Proveedor { get; set; }

        public int Cantidad { get; set; }

        public int ID_Orden { get; set; }

    }
}