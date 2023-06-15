namespace Clases;

public class Personaje
{
    private string? tipo;
    private string? nombre;
    private string? apodo;
    private DateTime fechaNac;
    private int edad;

    public string? Tipo { get => tipo; set => tipo = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
    public int Edad { get => edad; set => edad = value; }

    
}