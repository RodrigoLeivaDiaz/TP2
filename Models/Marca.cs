namespace TP2.Models;

public class Marca
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Heladeria> Heladerias { get; } = new List<Heladeria>();

}
