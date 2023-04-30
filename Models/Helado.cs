namespace TP2.Models;

public class Helado
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Sabor { get; set; }
     public List<Heladeria> Heladerias { get; } = new();

}