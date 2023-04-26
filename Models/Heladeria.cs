namespace TP2.Models;

public class Heladeria
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public string Marca { get; set; }

    public int DireccionId { get; set; }

    public virtual Direccion Direccion { get; set; }

}
