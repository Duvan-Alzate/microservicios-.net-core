using Clientes.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
