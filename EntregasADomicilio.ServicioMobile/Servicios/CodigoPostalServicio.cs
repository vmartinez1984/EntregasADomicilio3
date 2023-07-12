using EntregasADomicilio.Core.Dto;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EntregasADomicilio.ServicioMobile.Servicios
{
    public class CodigoPostalServicio : ConfiguracionDeServicio
    {
        public async Task<List<CodigoPostalDto>> Obtener(string codigoPostal)
        {
            List<CodigoPostalDto> lista;
            HttpClient client;
            HttpRequestMessage request;
            HttpResponseMessage response;

            client = new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            request = new HttpRequestMessage(HttpMethod.Get, _urlDeCodigoPostal + "CodigosPostales/" + codigoPostal);
            response = await client.SendAsync(request);
            lista = JsonConvert.DeserializeObject<List<CodigoPostalDto>>(await response.Content.ReadAsStringAsync());

            return lista;
        }

    }//end class
}