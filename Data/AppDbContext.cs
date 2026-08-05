using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaRMA.Entities;

namespace SistemaRMA.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<PedidoRMA> PedidosRma { get; set; }

    public DbSet<Estado> Estados {get; set;}

}