using Clientes.Application.Interfaces;
using Clientes.Domain.Models;

namespace Clientes.Application.Services
{
    public class ObtenerClienteService
    {
        private readonly IClienteRepository _repo;

        public ObtenerClienteService(IClienteRepository repo)
        {
            _repo = repo;
        }

        public async Task<Cliente?> Ejecutar(int id)
        {
            return await _repo.ObtenerPorId(id);
        }
    }
}
