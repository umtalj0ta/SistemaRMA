using Microsoft.EntityFrameworkCore;
using SistemaRMA.Data;
using SistemaRMA.Entities;

namespace SistemaRMA.Services;

public class RmaService
{
    //public readonly AppDbContext _context;

    private readonly IDbContextFactory<AppDbContext> _factory;

    public RmaService (IDbContextFactory<AppDbContext> factory)
    {
        _factory = factory;
    }
    public async Task CreateAsync(PedidoRMA pedido)
    {
        await using var context = await _factory.CreateDbContextAsync();

        context.PedidosRma.Add(pedido);

        await context.SaveChangesAsync();
    }   

    public async Task UpdateAsync(PedidoRMA pedido)
    {
        await using var context = await _factory.CreateDbContextAsync();

        var pedidoDb = await context.PedidosRma.FindAsync(pedido.ID);

        if (pedidoDb == null)
            return;

        pedidoDb.EstadoId = pedido.EstadoId;

        await context.SaveChangesAsync();
    }

    public async Task<List<PedidoRMA>> GetAllAsync()
    {
        await using var context = await _factory.CreateDbContextAsync();

        return await context.PedidosRma
            .Include(p => p.Estado)
            .ToListAsync();
    }

    public async Task<List<PedidoRMA>> GetByUserAsync(string userId)
    {
        await using var context = await _factory.CreateDbContextAsync();

        return await context.PedidosRma
            .Include(p => p.Estado)
            .Where(p => p.CriadoPorID == userId)
            .ToListAsync();
    }

    public async Task<List<PedidoRMA>> GetByEstadoAsync(int estadoId)
    {
        await using var context = await _factory.CreateDbContextAsync();

        return await context.PedidosRma
            .Include(p => p.Estado)
            .Where(p => p.EstadoId == estadoId)
            .ToListAsync();
    }

}

//duas tabelas uma com o estado e depois so passo o ID. 
 


