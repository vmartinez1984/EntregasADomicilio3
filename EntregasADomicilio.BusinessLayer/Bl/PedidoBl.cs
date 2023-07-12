using EntregasADomicilio.BusinessLayer.Contexts;
using EntregasADomicilio.Core.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EntregasADomicilio.BusinessLayer.Bl
{
    public class PedidoBl
    {
        private readonly AppDbContext _appDbContext;

        public PedidoBl(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }        

        public int Agregar(Pedido pedido)
        {
            pedido.Estatus = "Solicitud";
            pedido.FechaDeRegistro = DateTime.Now;
            _appDbContext.Pedido.Add(pedido);
            _appDbContext.SaveChanges();

            return pedido.Id;
        }

        public void CambiarEstatus(int id, string status)
        {
            Pedido pedido;
            
            pedido = Obtener(id);
            pedido.Estatus = status;
            _appDbContext.Pedido.Update(pedido);
            _appDbContext.SaveChanges();
        }

        public Pedido Obtener(int id)
        {
            return _appDbContext.Pedido
               .Include(x => x.Cliente)
               .Include(x => x.Cliente.Direcciones)
               .Include(x => x.DetalleDelPedido)
               .ThenInclude(x => x.Platillo)
               .Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Pedido> ObtenerDeDiaCorriente()
        {
            //return _appDbContext.Pedido.Where(x=> x.FechaDeRegistro.Date == DateTime.Now.Date).ToList();
            return _appDbContext.Pedido
                .Include(x=> x.Cliente)
                .Include(x =>x.Cliente.Direcciones)
                .Include(x=> x.DetalleDelPedido)
                .ThenInclude(x=> x.Platillo)
                .ToList();
        }

        public string ObtenerEstatus(int id)
        {
            string status;

            status = _appDbContext.Pedido.Where(x=> x.Id == id).FirstOrDefault().Estatus;

            return status;
        }

        public List<Pedido> ObtenerPedidorPorClienteId(int clienteId)
        {
            return _appDbContext.Pedido
                .Include(x=> x.DetalleDelPedido)
                .ThenInclude(x=> x.Platillo)
                .Where(x=>x.ClienteId == clienteId).ToList();               
        }

        public List<Pedido> ObtenerTodos(string estatus)
        {
            List<Pedido> pedidos;

            pedidos = _appDbContext.Pedido
               .Include(x => x.Cliente)
               .Include(x => x.Cliente.Direcciones)
               .Include(x => x.DetalleDelPedido)
               .ThenInclude(x => x.Platillo)
               .Where(x => x.Estatus == estatus).ToList();

            return pedidos;
        }
    }
}
