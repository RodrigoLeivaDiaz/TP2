namespace TP2.Models;

public class Heladeria
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int DireccionId { get; set; }

    public virtual Direccion? Direccion { get; set; }

    public int  MarcaId { get; set; }

      public virtual Marca Marca { get; set; }

      public List<Helado> Helados { get; } = new();

}
