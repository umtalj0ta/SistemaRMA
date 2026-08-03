using Microsoft.EntityFrameworkCore;
using SistemaRMA.Models;

namespace SistemaRMA.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<PedidoRMA> PedidosRma {get; set;}
}