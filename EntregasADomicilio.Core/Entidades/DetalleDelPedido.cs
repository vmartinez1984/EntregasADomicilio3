using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregasADomicilio.Core.Entidades
{
    public class DetalleDelPedido
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public int PedidoId { get; set; }

        public decimal Precio { get; set; }

        public int PlatilloId { get; set; }

        [JsonIgnore]
        [ForeignKey("PlatilloId")]
        public virtual Platillo Platillo { get; set; }
    }
}
