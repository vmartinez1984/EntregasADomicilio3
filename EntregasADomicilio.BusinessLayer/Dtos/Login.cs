using System.ComponentModel.DataAnnotations;

namespace EntregasADomicilio.BusinessLayer.Dtos
{
    public class Login
    {
        [Required(ErrorMessage = "El correo es obligatorio")]
        [StringLength(50)]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(10)]
        public string Contrasenia { get; set; }
    }
}
