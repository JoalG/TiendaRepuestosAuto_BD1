﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace TiendaRepuestosAuto_BD1_WEB.Models.DataBaseModelForApp
{
    public class OrdenModel
    {
        public int ID_Cliente { get; set; }
        public DateTime Fecha { get; set; }

        public string nombreDeCliente { get; set; }

        public int ID_Orden { get; set; }


    }
}