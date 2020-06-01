using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace TiendaRepuestosAuto_BD1_WEB.Models.DataBaseModelForApp
{
    public class ContactoModel
    {
        [Display(Name = "Nombre Completo de contacto")]
        [MaxLength(50, ErrorMessage = "Nombre completo debe ser menor a 50 caracteres")]
        [Required(ErrorMessage = "Tiene que ingresar su Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Número de telefono")]
        [Range(10000000, 99999999, ErrorMessage = "Número inválido")]
        [Required(ErrorMessage = "Tiene que ingresar su número de telefono")]
        public long Telefono { get; set; }

        [Display(Name = "Cargo")]
        [MaxLength(50, ErrorMessage = "Nombre completo debe ser menor a 50 caracteres")]
        [Required(ErrorMessage = "Tiene que ingresar su Nombre")]
        public string Cargo { get; set; }
    }
}