using EntregasADomicilio.BusinessLayer.Bl;
using EntregasADomicilio.Core.Entidades;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EntregasADomicilio.Mvc.Publica.Controllers
{
    public class CarritoController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public CarritoController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Index(string carrito)
        {
            List<int> lista = JsonConvert.DeserializeObject<List<int>>(carrito);
            List<Platillo> platillos;

            platillos = new List<Platillo>();
            foreach (var platilloId in lista)
            {
                Platillo platillo;

                platillo = _unitOfWork.Platillo.Obtener(platilloId);

                platillos.Add(platillo);
            }

            return View(platillos);
        }

        [HttpPost]
        public IActionResult RealizarPedido(Pedido pedido)
        {
            pedido.ClienteId = (int)HttpContext.Session.GetInt32("clienteId");
            foreach (var detalle in pedido.DetalleDelPedido)
            {
                Platillo platillo = _unitOfWork.Platillo.Obtener(detalle.PlatilloId);
                detalle.Precio =platillo.Precio;
            }
            _unitOfWork.Pedido.Agregar(pedido);            
            
            return RedirectToAction("Details", new { Id = pedido.Id });
        }

        public IActionResult Details(int id)
        {
            Pedido pedido;

            pedido = _unitOfWork.Pedido.Obtener(id);
            if (pedido == null)
            {
                pedido = _unitOfWork.Pedido.ObtenerUltimoDelClienteId((int)HttpContext.Session.GetInt32("clienteId"));
            }

            return View(pedido);
        }

    }//end class
}
