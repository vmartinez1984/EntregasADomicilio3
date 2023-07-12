using Newtonsoft.Json;

namespace EntregasADomicilio.Core.Dto
{
    public class CodigoPostalDto
    {
        [JsonProperty("codigoPostal")]
        public string CodigoPostal { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("estadoId")]
        public int EstadoId { get; set; }

        [JsonProperty("alcaldia")]
        public string Alcaldia { get; set; }

        [JsonProperty("alcaldiaId")]
        public int AlcaldiaId { get; set; }

        [JsonProperty("tipoDeAsentamiento")]
        public string TipoDeAsentamiento { get; set; }

        [JsonProperty("asentamiento")]
        public string Asentamiento { get; set; }
    }
}
