using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaRepuestosAuto_BD1_WEB.Models.DataBaseModelForApp
{
    public class TelefonoModel
    {
        public int ID_Telefono { get; set; }

        [Display(Name = "Cedula")]
        public int Cedula { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Número de Teléfono")]
        [Range(10000000, 99999999, ErrorMessage = "Número inválido")]
        [Required(ErrorMessage = "Ingrese un número de teléfono")]
        public long NumeroDeTelefono { get; set; }
    }
}