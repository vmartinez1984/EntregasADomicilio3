namespace EntregasADomicilio.ServicioMobile.Servicios
{
    public class ConfiguracionDeServicio
    {
        public readonly string _url;
        public readonly string _urlDeCodigoPostal;

        public ConfiguracionDeServicio()
        {
            _url = "http://192.168.1.86:9081/api/";
            _urlDeCodigoPostal = "https://codigospostalex.000webhostapp.com/api/v2/index.php/";
        }

    }
}
