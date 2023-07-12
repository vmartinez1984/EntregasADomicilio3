using EntregasADomicilio.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntregasADomicilio.BusinessLayer.Contexts
{
    public class AppDbContext : DbContext
    {
        //private readonly IConfiguration _configuration;
        private readonly string _conectionString;

        public AppDbContext(IConfiguration configuration)
        {            
            _conectionString = configuration.GetConnectionString("SqlServer");
        }

        //public AppDbContext()
        //{
        //    _conectionString = "Data Source=192.168.1.86;Initial Catalog=EntregasADomicilio; Persist Security Info=True;User ID=sa;Password=Macross#2012; TrustServerCertificate=True;";
        //}

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<DetalleDelPedido> DetalleDelPedido { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Platillo> Platillo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_conectionString);
            }
        }
    }
}
