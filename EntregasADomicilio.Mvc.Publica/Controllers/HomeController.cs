using EntregasADomicilio.BusinessLayer.Bl;
using EntregasADomicilio.Core.Entidades;
using EntregasADomicilio.Mvc.Publica.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EntregasADomicilio.Mvc.Publica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, UnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Platillo> platillos;
            string urlDelServidor;

            urlDelServidor = "http://localhost:9081/api";
            platillos = _unitOfWork.Platillo.ObtenerTodos();
            platillos.ForEach(platillo =>
            {
                platillo.Ruta = $"{urlDelServidor}{platillo.Ruta}";
            });
            ViewBag.Categorias = _unitOfWork.Categoria.ObtenerTodos();

            return View(platillos);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Service()
        {
            return View();
        }

        public IActionResult Menu()
        {
            List<Platillo> platillos;
            string urlDelServidor;

            urlDelServidor = "http://localhost:9081/api";
            platillos = _unitOfWork.Platillo.ObtenerTodos();
            platillos.ForEach(platillo =>
            {
                platillo.Ruta = $"{urlDelServidor}{platillo.Ruta}";
            });
            ViewBag.Categorias = _unitOfWork.Categoria.ObtenerTodos();

            return View(platillos);
        }

        public IActionResult Booking()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}