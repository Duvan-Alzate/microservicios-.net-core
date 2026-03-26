using Microsoft.AspNetCore.Mvc;
using Pagos.Application.DTO;
using Pagos.Application.Services;

namespace Pagos.Api.Controllers
{
    [ApiController]
    [Route("api/pagos")]
    public class PagosController : ControllerBase
    {
        private readonly CrearPagoService _crear;
        private readonly ObtenerPagosService _listar;

        public PagosController(
            CrearPagoService crear,
            ObtenerPagosService listar)
        {
            _crear = crear;
            _listar = listar;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearPagoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _crear.Ejecutar(dto);

            return Ok(new { mensaje = "Pago registrado" });
        }

        [HttpGet("{clienteId}")]
        public async Task<IActionResult> Listar(int clienteId)
        {
            var pagos = await _listar.Ejecutar(clienteId);
            return Ok(pagos);
        }
    }
}
