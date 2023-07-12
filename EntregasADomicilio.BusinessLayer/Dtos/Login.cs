using System.ComponentModel.DataAnnotations;

namespace EntregasADomicilio.BusinessLayer.Dtos
{
    public class Login
    {
        [StringLength(50)]
        public string Correo { get; set; }

        [StringLength(10)]
        public string Contrasenia { get; set; }
    }
}
