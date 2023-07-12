using EntregasADomicilio.BusinessLayer.Bl;
using EntregasADomicilio.Core.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatillosController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public PlatillosController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get() {
            List<Platillo> platillos;

            platillos = _unitOfWork.Platillo.ObtenerTodos();

            return Ok(platillos);
        }

        [HttpGet("Categorias/{categoriaId}")]
        public IActionResult ObtenerPorCategoriaId(int categoriaId) {
            List<Platillo> platillos;

            platillos = _unitOfWork.Platillo.ObtenerPorCategoriaId(categoriaId);

            return Ok(platillos);
        }
    }
}
