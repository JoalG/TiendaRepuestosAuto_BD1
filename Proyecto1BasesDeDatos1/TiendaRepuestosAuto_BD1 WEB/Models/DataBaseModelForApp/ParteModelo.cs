using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaRepuestosAuto_BD1_WEB.Models.DataBaseModelForApp
{
    public class ParteModelo
    {
        //hola
        [Display(Name = "Nombre de parte")]
        [MaxLength(50, ErrorMessage = "Nombre de parte debe ser menor a 50 caracteres")]
        [Required(ErrorMessage = "Tiene que ingresar nombre de parte")]
        public string Nombre { get; set; }

        [Display(Name = "Marca")]
        [MaxLength(50, ErrorMessage = "La marca debe ser menor a 50 caracteres")]
        [Required(ErrorMessage = "Debe ingresar el nombre de la marca")]
        public string Marca { get; set; }

        [Display(Name = "Fabricante")]
        public int ID_FabricanteDePiezas { get; set; }

        public int ID_Parte { get; set; }

        public List<TipoDeAutomovil> tiposDeAuto { get; set; }

        public FabricanteDePiezas FabricanteDePiezas { get; set; }
    }
}