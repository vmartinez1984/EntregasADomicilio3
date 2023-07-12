using EntregasADomicilio.BusinessLayer.Bl;
using EntregasADomicilio.BusinessLayer.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace EntregasADomicilio.BusinessLayer.Helpers
{
    public static class ExtensorBl
    {
        public static void AgregarBl(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            services.AddScoped<UnitOfWork>();
            services.AddScoped<ClienteBl>();
            services.AddScoped<PedidoBl>();
            services.AddScoped<CategoriaBl>();
            services.AddScoped<PlatilloBl>();
        }
    }
}
