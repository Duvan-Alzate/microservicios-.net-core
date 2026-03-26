using Clientes.Application.DTO;
using Clientes.Application.Interfaces;
using Clientes.Domain.Models;

namespace Clientes.Application.Services
{
    public class CrearClienteService
    {
        private readonly IClienteRepository _repo;

        public CrearClienteService(IClienteRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Ejecutar(CrearClienteDTO dto)
        {
            var cliente = new Cliente
            {
                Documento = dto.Documento,
                TipoDocumento = dto.TipoDocumento,
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                Email = dto.Email,
                Celular = dto.Celular,
                NumeroCuenta = dto.NumeroCuenta,
                TipoCuenta = dto.TipoCuenta,
                Estado = true
            };

            return await _repo.Crear(cliente);
        }
    }
}
