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
  public async Task CreateAsync(PedidoRMA pedido)
    {
        _context.PedidosRma.Add(pedido);  //aqui so adiciona

        await _context.SaveChangesAsync(); // aqui garda mesmo
    }

    public async Task<List<PedidoRMA>> GetAllAsync()
    {
        return await _context.PedidosRma.ToListAsync();   //tolist = select * from pedidosrma
    }

    public async Task UpdateAsync(PedidoRMA pedido)
    {
        _context.PedidosRma.Update(pedido);

        await _context.SaveChangesAsync();
    }

    public async Task<List<PedidoRMA>> GetByUserAsync (string UserId)
    {
        var pedidos = _context.PedidosRma.Where(pedido => pedido.CriadoPorID == UserId);

        return await pedidos.ToListAsync();
    }

}


