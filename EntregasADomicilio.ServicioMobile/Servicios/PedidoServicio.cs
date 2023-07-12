using EntregasADomicilio.Core.Dto;
using EntregasADomicilio.Core.Entidades;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EntregasADomicilio.ServicioMobile.Servicios
{
    public class PedidoServicio : ConfiguracionDeServicio
    {
        public async Task<int> Agregar(Pedido pedido)
        {
            IdDto idDto;
            HttpClient client;
            HttpRequestMessage request;
            HttpResponseMessage response;

            client = new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            request = new HttpRequestMessage(HttpMethod.Post, _url + "Pedidos");
            request.Content = new StringContent(JsonConvert.SerializeObject(pedido), null, "application/json");
            response = await client.SendAsync(request);
            idDto = JsonConvert.DeserializeObject<IdDto>(await response.Content.ReadAsStringAsync());

            return idDto.Id;
        }

        public async Task<List<Pedido>> ObtenerPorCliente(int clienteId)
        {
            HttpClient client;
            HttpRequestMessage request;
            HttpResponseMessage response;
            List<Pedido> pedidos;

            client = new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            request = new HttpRequestMessage(HttpMethod.Get, $"{_url}Pedidos/{clienteId}");
            response = await client.SendAsync(request);
            pedidos = JsonConvert.DeserializeObject<List<Pedido>>(await response.Content.ReadAsStringAsync());

            return pedidos;
        }

        public async Task<Pedido> Obtener(int pedidoId)
        {
            Pedido pedido;
            HttpClient client;
            HttpRequestMessage request;
            HttpResponseMessage response;

            client = new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            request = new HttpRequestMessage(HttpMethod.Get, _url + "Pedidos/" +pedidoId);
            
            response = await client.SendAsync(request);
            pedido = JsonConvert.DeserializeObject<Pedido>(await response.Content.ReadAsStringAsync());

            return pedido;
        }

    }
}
