using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace EntregasADomicilio.Core.Entidades
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [JsonIgnore]
        [Display(Name = "¿Esta activo?")]
        public bool EstaActivo { get; set; } = true;
    }
}
