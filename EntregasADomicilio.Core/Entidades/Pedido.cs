using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EntregasADomicilio.Core.Entidades
{
    public class Pedido
    {
        public Pedido()
        {
            DetalleDelPedido = new List<DetalleDelPedido>();
        }

        [JsonIgnore]
        public int Id { get; set; }

        public decimal Total { get { return DetalleDelPedido.Sum(x => x.Platillo.Id); } }

        public int ClienteId { get; set; }

        [JsonIgnore]
        [ForeignKey("ClienteId")]
        [Display(Name = "Cliente")]
        public virtual Cliente Cliente { get; set; }

        [Display(Name = "Detalle del pedido")]
        public List<DetalleDelPedido> DetalleDelPedido { get; set; }

        [StringLength(250)]
        public string Comentario { get; set; }

        [Display(Name = "Fecha")]
        public DateTime FechaDeRegistro { get; set; }

        public string Estatus { get; set; }
    }
}
