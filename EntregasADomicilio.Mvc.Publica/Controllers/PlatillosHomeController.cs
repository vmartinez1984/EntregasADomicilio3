using EntregasADomicilio.Core.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Mvc.Publica.Controllers
{
    public class PlatillosHomeController : Controller
    {
        public IActionResult Index()
        {
            Platillo platillo;
            
            return View();
        }
    }
}
