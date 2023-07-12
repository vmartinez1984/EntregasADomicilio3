namespace EntregasADomicilio.BusinessLayer.Bl
{
    public class UnitOfWork
    {
        public UnitOfWork(
            ClienteBl clienteBl,
            PedidoBl pedidoBl,
            CategoriaBl categoriaBl,
            PlatilloBl platilloBl
        )
        {
            Cliente = clienteBl;
            Pedido = pedidoBl;
            Categoria = categoriaBl;
            Platillo = platilloBl;
        }

        public ClienteBl Cliente { get; }
        public PedidoBl Pedido { get; }
        public CategoriaBl Categoria { get; }
        public PlatilloBl Platillo { get; set; }
    }
}
