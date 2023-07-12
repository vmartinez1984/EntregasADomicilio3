using EntregasADomicilio.BusinessLayer.Bl;
using EntregasADomicilio.BusinessLayer.Dtos;
using EntregasADomicilio.Core.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public ClientesController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            Cliente cliente;

            cliente = _unitOfWork.Cliente.Obtener(id);

            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Post(Cliente cliente)
        {
            int id;

            id = _unitOfWork.Cliente.Agregar(cliente);

            return Created($"/Clientes/{id}", new { Id = id });
        }

        [HttpPost("Login")]
        public IActionResult Login(Login login)
        {
            Cliente cliente;

            cliente = _unitOfWork.Cliente.Login(login);
            if(cliente == null)
                return NotFound("Correo y/o contraseña incorrectas");
            return Ok(cliente);
        }
    }
}
