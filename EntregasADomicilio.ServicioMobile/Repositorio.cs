using Mobile.Repositories;

namespace EntregasADomicilio.ServicioMobile.Servicios
{
    public class Repositorio
    {
        public Repositorio()
        {
            Categoria = new CategoriaServicio();
            Cliente = new ClienteServicio();
            Pedido = new PedidoServicio();      
            Platillo = new PlatillosRepositorio();
           CodigoPostal = new CodigoPostalServicio();
        }

        public CodigoPostalServicio CodigoPostal { get; set; }  
        public PedidoServicio Pedido { get; set; }
        public CategoriaServicio Categoria { get; set; }
        public PlatillosRepositorio Platillo { get; set; }
        public ClienteServicio Cliente { get; set; }
    }
}
