using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregasADomicilio.Core.Entidades
{
    public class Platillo
    {
        public int Id { get; set; }

        [Required( ErrorMessage = "El nombre es requerido")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(250)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        public decimal Precio { get; set; }

        [NotMapped]
        public IFormFile FormFile { get; set; }

        public string ImagenEnBase64 { get; set; }

        public bool EstaActivo { get; set; } = true;

        [Required(ErrorMessage ="Seleccione una categoria")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }

        public string Ruta { get; set; }

        public string NombreDelArchivo  { get; set; }
    }
}
