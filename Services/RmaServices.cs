using Microsoft.EntityFrameworkCore;
using SistemaRMA.Data;
using SistemaRMA.Models;

namespace SistemaRMA.Services;

public class RmaService
{
    public readonly AppDbContext _context;

    public RmaService (AppDbContext context)
    {
        _context = context;
    }
  public async Task CreateAsync(PedidoRMA request)
    {
        _context.PedidosRma.Add(request);

        await _context.SaveChangesAsync();
    }

}


