﻿using EntregasADomicilio.BusinessLayer.Bl;
using EntregasADomicilio.Core.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public PedidosController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Post(Pedido pedido)
        {
            int id;

            id = _unitOfWork.Pedido.Agregar(pedido);

            return Created($"/Pedidos/{id}", new { Id = id });
        }

        [HttpGet("{clienteId}")]
        public IActionResult ObtenerPedidosPorCliente(int clienteId)
        {
            List<Pedido> lista;

            lista = _unitOfWork.Pedido.ObtenerPedidorPorClienteId(clienteId);

            return Ok(lista);
        }

        //[HttpGet("{id}/Estatus")]
        //public IActionResult ObtenerStatusDelPedido(int id)
        //{
        //    string estatus;

        //    estatus = _unitOfWork.Pedido.ObtenerEstatus(id);

        //    return Ok(new { Estatus = estatus });
        //}

        [HttpGet("{id}")]
        public IActionResult Obtener(int id)
        {
            Pedido pedido;

            pedido = _unitOfWork.Pedido.Obtener(id);

            return Ok(pedido);
        }
    }
}
