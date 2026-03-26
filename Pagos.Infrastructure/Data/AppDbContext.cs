using Microsoft.EntityFrameworkCore;
using Pagos.Domain.Models;

namespace Pagos.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pago> Pagos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
