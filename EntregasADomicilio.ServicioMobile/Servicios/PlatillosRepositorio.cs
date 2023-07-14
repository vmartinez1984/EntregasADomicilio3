using EntregasADomicilio.Core.Entidades;
using EntregasADomicilio.ServicioMobile.Servicios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Repositories
{
    public class PlatillosRepositorio: ConfiguracionDeServicio
    {
        
        public async Task<List<Platillo>> ObtenerTodos()
        {
            HttpClient client;
            HttpRequestMessage request;
            HttpResponseMessage response;
            List<Platillo> platillos;

            client = new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            request = new HttpRequestMessage(HttpMethod.Get, _url + "Platillos");
            response = await client.SendAsync(request);
            platillos = JsonConvert.DeserializeObject<List<Platillo>>(await response.Content.ReadAsStringAsync());

            return platillos;
        }
        
        public async Task<List<Platillo>> ObtenerPorCategoria(int categoriaId)
        {
            HttpClient client;
            HttpRequestMessage request;
            HttpResponseMessage response;
            List<Platillo> platillos;

            client = new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            request = new HttpRequestMessage(HttpMethod.Get, $"{_url}Platillos/Categorias/{categoriaId}");
            response = await client.SendAsync(request);
            platillos = JsonConvert.DeserializeObject<List<Platillo>>(await response.Content.ReadAsStringAsync());

            return platillos;
        }

        public async Task<Func<Stream>> ObtenerPortada()
        {
            HttpClient client;
            HttpRequestMessage request;
            HttpResponseMessage response;
            byte[] bytes;
            Stream stream;

            client = new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            request = new HttpRequestMessage(HttpMethod.Get, "http://192.168.1.86:9080/img/Portada.jpeg");
            //request = new HttpRequestMessage(HttpMethod.Get, "https://images.pexels.com/photos/214574/pexels-photo-214574.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1");
            response = await client.SendAsync(request);
            bytes = await response.Content.ReadAsByteArrayAsync();
            stream = new MemoryStream(bytes);

            return () => stream;
        }

        public async Task<Func<Stream>> ObtenerStreamDeImagen(string ruta)
        {
            HttpClient client;
            HttpRequestMessage request;
            HttpResponseMessage response;
            byte[] bytes;
            Stream stream;

            client = new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            request = new HttpRequestMessage(HttpMethod.Get, _url + ruta.Substring(1));
            //request = new HttpRequestMessage(HttpMethod.Get, "https://images.pexels.com/photos/214574/pexels-photo-214574.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1");
            response = await client.SendAsync(request);
            bytes = await response.Content.ReadAsByteArrayAsync();
            stream = new MemoryStream(bytes);

            return () => stream;            
        }

    }//end class
}
