using Microsoft.EntityFrameworkCore;
using SistemaRMA.Data;
using SistemaRMA.Entities;

namespace SistemaRMA.Services;

public class RmaService
{
    public readonly AppDbContext _context;

    public RmaService (AppDbContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(PedidoRMA pedido)
    {
        _context.PedidosRma.Add(pedido);  //aqui so adiciona

        await _context.SaveChangesAsync(); // aqui garda mesmo
    }

    public async Task UpdateAsync(PedidoRMA pedido)
    {
        _context.PedidosRma.Update(pedido);

        await _context.SaveChangesAsync();    
    }

    public async Task<List<PedidoRMA>> GetAllAsync()
    {
        var pedidos = _context.PedidosRma.Include(p => p.Estado);

        return await pedidos.ToListAsync();
    }

    public async Task<List<PedidoRMA>> GetByUserAsync(string userId)
    {
        var pedidos = _context.PedidosRma.Include(p => p.Estado).Where(p => p.CriadoPorID == userId);

        return await pedidos.ToListAsync();
    }

    public async Task<List<PedidoRMA>> GetByEstadoAsync(int estadoId)
    {
        var pedidos = _context.PedidosRma.Include(p => p.Estado).Where(p => p.EstadoId == estadoId);

        return await pedidos.ToListAsync();
    }

}

//duas tabelas uma com o estado e depois so passo o ID. 
 


