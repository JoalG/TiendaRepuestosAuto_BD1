﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TiendaRepuestosAuto_BD1_WEB.Models.DataBaseModelForApp
{
    public class personaModel
    {
        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "Tiene que ingresar su cédula")]
        public int Cedula { get; set; }

        [Display(Name = "Nombre Completo")]
        [MaxLength(50, ErrorMessage = "Nombre completo debe ser menor a 50 caracteres")]
        [Required(ErrorMessage = "Tiene que ingresar su Nombre")]
        public string nombre { get; set; }

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

    }
}