using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaRepuestosAuto_BD1_WEB.Models.DataBaseModelForApp
{
    public class ParteParaTipoDeAutomovilModel
    {
        [Display(Name = "Parte")]
        public int ID_Parte { get; set; }

        [Display(Name = "Tipo de Automovil")]
        public int ID_TipoDeAutomovil { get; set; }

        public string nombreParte { get; set; }

    }
}