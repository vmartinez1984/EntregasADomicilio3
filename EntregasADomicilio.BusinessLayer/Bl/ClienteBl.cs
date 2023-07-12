using EntregasADomicilio.BusinessLayer.Contexts;
using EntregasADomicilio.BusinessLayer.Dtos;
using EntregasADomicilio.Core.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EntregasADomicilio.BusinessLayer.Bl
{
    public class ClienteBl
    {
        private readonly AppDbContext _appDbContext;

        public ClienteBl(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Cliente Obtener(int id)
        {
            Cliente cliente;

            cliente = _appDbContext.Cliente
                .Include(x => x.Direcciones)
                .Where(c => c.Id == id).FirstOrDefault();

            return cliente;
        }

        public int Agregar(Cliente cliente)
        {
            _appDbContext.Cliente.Add(cliente);
            _appDbContext.SaveChanges();

            return cliente.Id;
        }

        public Cliente Login(Login login)
        {
            Cliente cliente;

            cliente = _appDbContext.Cliente
                .Include(x => x.Direcciones)
                .Where(x => x.Correo == login.Correo && x.Contrasenia == login.Contrasenia).FirstOrDefault();

            return cliente;
        }
    }
}
