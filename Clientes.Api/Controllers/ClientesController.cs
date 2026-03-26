using Clientes.Application.DTO;
using Clientes.Application.Services;
using Clientes.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.Api.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly CrearClienteService _crear;
        private readonly ObtenerClienteService _obtener;

        public ClientesController(CrearClienteService crear, ObtenerClienteService obtener)
        {
            _crear = crear;
            _obtener = obtener;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearClienteDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (dto.TipoDocumento != "CC" && dto.TipoDocumento != "TI")
                throw new Exception("Tipo de documento inválido");

            var id = await _crear.Ejecutar(dto);
            return Ok(new { mensaje = "Cliente creado", id });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var cliente = await _obtener.Ejecutar(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }
    }
}
