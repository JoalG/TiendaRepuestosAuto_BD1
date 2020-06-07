using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaRepuestosAuto_BD1_WEB.Models.DataBaseModelForApp
{
    public class OrganizacionModel
    {
        [Display(Name = "Cédula Juridica")]
        [Range(1000000000, 9999999999, ErrorMessage = "Cédula Juridica inválida")]
        [Required(ErrorMessage = "Tiene que ingresar la cédula jurídica de la organización")]
        public long CedulaJuridica { get; set; }

        [Display(Name = "Nombre de Organización")]
        [MaxLength(50, ErrorMessage = "Nombre de la organización debe ser menor a 50 caracteres")]
        [Required(ErrorMessage = "Tiene que ingresar nombre de la organización")]
        public string Nombre { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(50, ErrorMessage = "Dirección debe ser menor a 50 caracteres")]
        [Required(ErrorMessage = "Tiene que ingresar su Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Ciudad")]
        [MaxLength(50, ErrorMessage = "Ciudad debe ser menor a 50 caracteres")]
        [Required(ErrorMessage = "Tiene que ingresar su ciudad")]
        public string Ciudad { get; set; }

        [Display(Name = "Estado")]
        public int ID_EstadoDeCliente { get; set; }

        public ContactoModel Contacto { get; set; }

    }
}