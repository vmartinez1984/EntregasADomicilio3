using EntregasADomicilio.Core.Dto;
using EntregasADomicilio.Core.Entidades;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace EntregasADomicilio.ServicioMobile.Servicios
{
    public class ClienteServicio: ConfiguracionDeServicio
    {
        public async Task<Cliente> IniciarSesion(string correo, string contasenia)
        {
            HttpClient client;
            HttpRequestMessage request;
            HttpResponseMessage response;
            Cliente cliente;

            client = new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            request = new HttpRequestMessage(HttpMethod.Post, _url + "Clientes/Login");
            var body = new {Correo = correo, Contrasenia = contasenia };
            request.Content = new StringContent(JsonConvert.SerializeObject(body),null, "application/json");
            response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
                cliente = JsonConvert.DeserializeObject<Cliente>(await response.Content.ReadAsStringAsync());
            else
                cliente = null;

            return cliente;
        }

        public async Task<int> Agregar(Cliente cliente)
        {
            IdDto idDto;
            HttpClient client;
            HttpRequestMessage request;
            HttpResponseMessage response;            

            client = new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            request = new HttpRequestMessage(HttpMethod.Post, _url + "Clientes");            
            request.Content = new StringContent(JsonConvert.SerializeObject(cliente), null, "application/json");
            response = await client.SendAsync(request);
            idDto = JsonConvert.DeserializeObject<IdDto>(await response.Content.ReadAsStringAsync());

            return idDto.Id;
        }
    }
}
