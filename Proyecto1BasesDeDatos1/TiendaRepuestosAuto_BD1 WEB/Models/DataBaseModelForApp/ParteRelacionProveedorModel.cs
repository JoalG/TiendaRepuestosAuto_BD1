using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaRepuestosAuto_BD1_WEB.Models.DataBaseModelForApp
{
    public class ParteRelacionProveedorModel
    {
        [Display(Name = "Parte")]
        public int ID_Parte { get; set; }

        [Display(Name = "Proveedor")]
        public int ID_Proveedor { get; set; }

        [Display(Name = "Ganancia")]
        [RegularExpression(@"^\d+\.\d{0,4}$", ErrorMessage = "Solo se admiten 4 decimales de precision")]
        [Range(0, 100.0000, ErrorMessage = "Tamaño maximo excedido")]
        public decimal Ganancia { get; set; }

        [Display(Name = "Precio")]
        [RegularExpression(@"^\d+\.\d{0,4}$", ErrorMessage = "Solo se admiten 4 decimales de precision")]
        [Range(0, 999999999999999.9999, ErrorMessage = "Tamaño maximo excedido")]
        public decimal Precio { get; set; }

        public string nombreParte { get; set; }
        public string nombreProveedor { get; set; }
    }
}