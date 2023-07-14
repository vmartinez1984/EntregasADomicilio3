using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntregasADomicilio.Core.Entidades
{
    public class Cliente
    {        
        public int Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Correo { get; set; }

        [StringLength(50)]
        public string Telefono { get; set; }

        [StringLength(10)]
        public string Contrasenia { get; set; }

        [StringLength(50)]
        public string Apellidos { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaDeNacimiento { get; set; }

        public virtual List<Direccion> Direcciones { get; set; }        
    }
}