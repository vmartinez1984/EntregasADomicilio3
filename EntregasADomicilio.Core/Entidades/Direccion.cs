using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace EntregasADomicilio.Core.Entidades
{
    public class Direccion
    {
        [JsonIgnore]
        public int Id { get; set; }
        [StringLength(250)]
        public string CalleYNumero { get; set; }

        [StringLength(250)]
        public string Referencias { get; set; }

        [StringLength(5)]
        public string CodigoPostal { get; set; }

        [StringLength(50)]
        public string Colonia { get; set; }

        [JsonIgnore]
        public int ClienteId { get; set; }

        public bool EsPrincipal { get; set; }
    }
}
