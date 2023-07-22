using EntregasADomicilio.BusinessLayer.Bl;
using EntregasADomicilio.BusinessLayer.Dtos;
using EntregasADomicilio.Core.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Mvc.Publica.Controllers
{
    public class IniciarSesionController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public IniciarSesionController(UnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion(Login login)
        {
            Cliente cliente;

            cliente = _unitOfWork.Cliente.Login(login);
            if (cliente == null)
            {
                ViewBag.Error = "Correo y/o Contraseña no validos";
            return View();
            }
            else
            {
                HttpContext.Session.SetInt32("clienteId", cliente.Id);
                HttpContext.Session.SetString("clienteNombre", cliente.Nombre + " " + cliente.Apellidos);
                return RedirectToAction("Menu", "Home");
            }
        }

        public IActionResult Registrarse()
        {
            return View();
        }
    }
}
