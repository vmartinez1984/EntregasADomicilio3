using EntregasADomicilio.BusinessLayer.Bl;
using EntregasADomicilio.Core.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;

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
        public IActionResult Get()
        {
            List<Platillo> platillos;

            platillos = _unitOfWork.Platillo.ObtenerTodos();

            return Ok(platillos);
        }

        [HttpGet("Categorias/{categoriaId}")]
        public IActionResult ObtenerPorCategoriaId(int categoriaId)
        {
            List<Platillo> platillos;

            platillos = _unitOfWork.Platillo.ObtenerPorCategoriaId(categoriaId);

            return Ok(platillos);
        }

        [HttpGet("{platilloId}/Imagen")]
        public ActionResult ObtenerIamgen(int platilloId)
        {
            Platillo platillo;

            platillo = _unitOfWork.Platillo.Obtener(platilloId);

            return File(platillo.ImagenEnBytes, platillo.ContentType);
        }
    }
}
