using EntregasADomicilio.BusinessLayer.Bl;
using EntregasADomicilio.Core.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Mvc.Comandas.Controllers
{
    public class PedidosController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public PedidosController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: PedidosController
        public ActionResult Index(string estatus = "Solicitud")
        {
            List<Pedido> pedidos;

            pedidos = _unitOfWork.Pedido.ObtenerTodos(estatus);
            ViewBag.Estatus = estatus;

            return View("Index", pedidos);            
        }

        // GET: PedidosController/Edit/5
        public ActionResult CambiarEstado(int id,string anterior, string actual)
        {
            _unitOfWork.Pedido.CambiarEstatus(id, actual);

            return RedirectToAction(nameof(Index), new { Estatus = anterior});
        }

        // GET: PedidosController/Details/5
        public ActionResult Details(int id, string estatus)
        {
            Pedido pedido;

            pedido = _unitOfWork.Pedido.Obtener(id);
            ViewBag.Estatus = estatus;

            return View(pedido);
        }       

        // GET: PedidosController/Edit/5
        public ActionResult Edit(int id)
        {
            Pedido pedido;

            pedido = _unitOfWork.Pedido.Obtener(id);

            return View(pedido);
        }


        // POST: PedidosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
      
    }
}
