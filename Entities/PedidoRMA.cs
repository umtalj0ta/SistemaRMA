using Microsoft.AspNetCore.Identity;

namespace SistemaRMA.Entities;

public class PedidoRMA
{
    public int ID { get; set; }

    public string Equipamento {get; set; } = "";

    public string NumeroSerie {get; set; } = "";

    public string DescricaoProblema {get; set;} = "";

    public DateTime CriadoA {get; set;} = DateTime.UtcNow;

    public int EstadoId {get; set;}

    public Estado Estado {get; set;} = null!;

    public string CriadoPorID {get; set;} = "";

    public IdentityUser CriadoPor{get; set;} =null!;
}