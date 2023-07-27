namespace Clases;
using usarApi;
using System.IO;
using System.Net;
using System.Text.Json;

public class Personaje
{
    private string? tipo;
    private string? nombre;
    private string? apodo;
    private DateTime fechaNac;
    private int edad;
    private int destreza;
    private int fuerza;
    private int velocidad;
    private int nivel;
    private int armadura;
    private double salud;

    public string? Tipo { get => tipo; set => tipo = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
    public int Edad { get => edad; set => edad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public double Salud { get => salud; set => salud = value; }
}

public static class FabricaDePersonajes
{
    private static string[] tipos={"Danzante del filo", "Corredor del viento", "Rompedor del cielo", "Forjador de vinculos", "Escultor de voluntad", "Vigilante de la verdad", "Nominador de lo otro", "Tejedor de luz", "Custodio de piedra", "Portador de polvo"};
    
    public static  Personaje crear(string nombre, DateTime fec, int edad, string apodo){
        
        Personaje nuevo=new Personaje();
        int numero;
        numero=rdm(0,6);
        nuevo.Tipo=tipos[numero];
        nuevo.Nombre=nombre;
        nuevo.Apodo=apodo;
        nuevo.FechaNac=fec;
        nuevo.Edad = edad;
        switch (nuevo.Tipo)
        {
            case "Dazante del filo":
                nuevo.Destreza=5;
                nuevo.Armadura=5;
                nuevo.Velocidad=8;
                nuevo.Fuerza=4;
            break;
            case "Corredor del viento":
                nuevo.Destreza=4;
                nuevo.Armadura=6;
                nuevo.Velocidad=10;
                nuevo.Fuerza=7;
            break;
            case "Rompedor del cielo":
                nuevo.Destreza=4;
                nuevo.Armadura=5;
                nuevo.Velocidad=10;
                nuevo.Fuerza=8;
            break;
            case "Forjador de vinculos":
                nuevo.Destreza=2;
                nuevo.Armadura=8;
                nuevo.Velocidad=4;
                nuevo.Fuerza=10;
            break;
            case "Escultor de voluntad":
                nuevo.Destreza=2;
                nuevo.Armadura=10;
                nuevo.Velocidad=2;
                nuevo.Fuerza=5;
            break;
            case "Vigilante de la verdad":
                nuevo.Destreza=3;
                nuevo.Armadura=8;
                nuevo.Velocidad=7;
                nuevo.Fuerza=3;
            break;
            case "Nominador de lo otro":
                nuevo.Destreza=5;
                nuevo.Armadura=6;
                nuevo.Velocidad=6;
                nuevo.Fuerza=9;
            break;
            case "Tejedor de luz":
                nuevo.Destreza=4;
                nuevo.Armadura=2;
                nuevo.Velocidad=6;
                nuevo.Fuerza=4;
            break;
            case "Custodio de piedra":
                nuevo.Destreza=4;
                nuevo.Armadura=10;
                nuevo.Velocidad=5;
                nuevo.Fuerza=8;
            break;
            case "Portador de polvo":
                nuevo.Destreza=2;
                nuevo.Armadura=5;
                nuevo.Velocidad=9;
                nuevo.Fuerza=9;
            break;
            default:
            break;
        }
        nuevo.Nivel=rdm(1,6);
        nuevo.Salud=100;
        return nuevo;
    }
    private static int rdm(int min, int max){
        Random random = new Random();
        int numero;
        numero = random.Next(min, max);
        return numero;
    }
}

public static class persojanesJson
{
    public static void GuardarPersonaje(List<Personaje> lista, string nombre){
        string rutaProyecto = Directory.GetCurrentDirectory();
        string rutaArchivo = Path.Combine(rutaProyecto, nombre);
        if (File.Exists(rutaArchivo))
        {
            string existente = File.ReadAllText(rutaArchivo);
            List<Personaje> listaExistente = JsonSerializer.Deserialize<List<Personaje>>(existente);
            List<Personaje> final = listaExistente.Concat(lista).ToList();
            string json=JsonSerializer.Serialize(final, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText( rutaArchivo,json);
        }else
        {
            string json=JsonSerializer.Serialize(lista, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText( rutaArchivo,json);
            Console.WriteLine("se guardo la lista de personajes");
        }
        
    }
    public static List<Personaje> LeerPersonaje(string archivo){
        string rutaProyecto = Directory.GetCurrentDirectory();
        string rutaArchivo = Path.Combine(rutaProyecto, archivo);
        string json = File.ReadAllText(rutaArchivo);
        List<Personaje> lista = JsonSerializer.Deserialize<List<Personaje>>(json);
        if (lista!=null)
        {
            return lista;
        }else
        {
            Console.WriteLine("el archivo esta vacio");
            return null;
        }
        
    }

    public static bool Existe(string archivo){
        string rutaProyecto = Directory.GetCurrentDirectory();
        string rutaArchivo = Path.Combine(rutaProyecto, archivo);
        return File.Exists(rutaArchivo);
    }
}

public static class batalla
{
    public static double combate(Personaje num1, Personaje num2){
        if (num2.Salud>=0)
        {
            int Ataque= num1.Destreza*num1.Fuerza*(num1.Nivel*2);
            int Efectividad= rdm(30,101);
            int Defenza=num2.Armadura*num2.Velocidad;
            int constAjuste=500;
            double Daño=((Ataque*Efectividad)-Defenza)/constAjuste;
            return Daño;
        }else
        {
            return 0;
        }
    }
    public static int rdm(int min, int max){
        Random random = new Random();
        int numero;
        numero = random.Next(min, max);
        return numero;
    }
    public static void EscribirMensajePorLetras(string mensaje, TimeSpan tiempoDeEspera)
    {
        foreach (char letra in mensaje)
        {
            Console.Write(letra);
            Thread.Sleep(tiempoDeEspera);
        }
        Console.WriteLine("");
    }
}