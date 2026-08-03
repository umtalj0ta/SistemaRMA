namespace SistemaRMA.Models;

public class PedidoRMA
{
    public int ID { get; set; }

    public string Equipamento {get; set; } = "";

    public string NumeroSerie {get; set; } = "";

    public string DescricaoProblema {get; set;} = "";

    public DateTime CriadoA {get; set;} = DateTime.UtcNow;

    public string Estado {get; set;} = "Pendente";
}