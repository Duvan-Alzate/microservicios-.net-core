using Clientes.Domain.Models;

namespace Clientes.Application.Interfaces
{
    public interface IClienteRepository
    {
        Task<int> Crear(Cliente cliente);
        Task<Cliente?> ObtenerPorId(int id);
    }
}
