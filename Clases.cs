namespace Clases;

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
    private int salud;

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
    public int Salud { get => salud; set => salud = value; }
}

public class FabricaDePersonajes
{
    private string[] tipos={"humano", "elfo", "mago", "troll", "vampiro", "hombre lobo"};
    private string[] nombres={"Luca", "Javier", "Celeste", "Luciana", "Valentina", "Francisco"};

    public Personaje crear(){
        
        Personaje nuevo=new Personaje();
        int numero;
        numero=rdm(0,6);
        nuevo.Tipo=tipos[numero];
        numero=rdm(0,6);
        nuevo.Nombre=nombres[numero];
        nuevo.Apodo="apodo"+numero;
        nuevo.FechaNac=new DateTime(rdm(1723, 2006), rdm(1, 31), rdm(1,13));
        nuevo.Edad = 2023 - nuevo.FechaNac.Year;
        nuevo.Destreza=rdm(1, 6);
        nuevo.Armadura=rdm(1,11);
        nuevo.Velocidad=rdm(1,11);
        nuevo.Fuerza=rdm(1,10);
        nuevo.Nivel=rdm(1,10);
        nuevo.Salud=100;
        return nuevo;
    }
    private int rdm(int min, int max){
        Random random = new Random();
        int numero;
        numero = random.Next(min, max);
        return numero;
    }
}

public class persojanesJson
{
    public void GuardarPersonaje(List<Personaje> lista, string nombre){

    }
    public List<Personaje> LeerPersonaje(string archivo){
        List<Personaje> lista = new List<Personaje>();
        return lista;
    }

    public bool Existe(string archivo){
        bool respuesta;

        return respuesta;
    }
}