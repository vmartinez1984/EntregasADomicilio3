using EntregasADomicilio.Core.Entidades;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EntregasADomicilio.ServicioMobile.Servicios
{
    public class CategoriaServicio: ConfiguracionDeServicio
    {
        public async Task<List<Categoria>> ObtenerTodos()
        {
            HttpClient client;
            HttpRequestMessage request;
            HttpResponseMessage response;
            List<Categoria> categorias;

            client = new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            request = new HttpRequestMessage(HttpMethod.Get, _url+ "Categorias");
            response = await client.SendAsync(request);
            categorias = JsonConvert.DeserializeObject<List<Categoria>>(await response.Content.ReadAsStringAsync());

            return categorias;
        }
    }
}
