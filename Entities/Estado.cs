using SistemaRMA.Entities;

namespace SistemaRMA.Entities;

public class Estado
{
    public int Id {get; set;}

    public string Nome {get; set;} = "";

    public ICollection<PedidoRMA> Pedidos {get;set;} = new List<PedidoRMA>();

}