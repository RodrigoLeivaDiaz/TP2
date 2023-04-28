namespace TP2.Models;

public class Direccion
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual Heladeria? Heladeria { get; set; }

}