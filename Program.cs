
using Clases;
using usarApi;
using System.IO;
using System.Net;
using System.Text.Json;
string? archivo = "Json";
string? archivo2 = "Contrincantes";
bool bandera;
string? caracter="a";
Personaje principal=null;

Console.Clear();

Console.WriteLine("|''||''|                                                                 '||'  '|'          ||    .   '||       ||                   ");
Console.WriteLine("   ||      ...   ... ..  .. ...     ....    ...        ....  .. ...       ||    |  ... ..  ...  .||.   || ..   ...  ... ..  ... ...  ");
Console.WriteLine("   ||    .|  '|.  ||' ''  ||  ||  .|...|| .|  '|.    .|...||  ||  ||      ||    |   ||' ''  ||   ||    ||' ||   ||   ||' ''  ||  ||  ");
Console.WriteLine("   ||    ||   ||  ||      ||  ||  ||      ||   ||    ||       ||  ||      ||    |   ||      ||   ||    ||  ||   ||   ||      ||  ||  ");
Console.WriteLine("  .||.    '|..|' .||.    .||. ||.  '|...'  '|..|'     '|...' .||. ||.      '|..'   .||.    .||.  '|.' .||. ||. .||. .||.     '|..'|. ");
Console.WriteLine(" ");
batalla.EscribirMensajePorLetras("Presione enter para continuar", TimeSpan.FromMilliseconds(30));
Console.ReadKey();
Console.Clear();

batalla.EscribirMensajePorLetras("BIENVENIDO COMBATIENTE", TimeSpan.FromMilliseconds(30));
batalla.EscribirMensajePorLetras("En este torneo te enfrentaras con los campeones de cada orden de Caballeros Radientes", TimeSpan.FromMilliseconds(30));
batalla.EscribirMensajePorLetras("En cada nivel te enfrentaras con el campeon de una orden distinta", TimeSpan.FromMilliseconds(30));
batalla.EscribirMensajePorLetras("Si lo derrotas avanzas de nivel, si el te derrota seras eliminado del torneo", TimeSpan.FromMilliseconds(30));
batalla.EscribirMensajePorLetras("Vence a los 10 campeones, lleva la gloria a tu orden y coronate como El Campeon de Urithiru", TimeSpan.FromMilliseconds(30));
batalla.EscribirMensajePorLetras("Vamos Muchach@, di las palabras", TimeSpan.FromMilliseconds(30));
Console.ReadKey();
Console.Clear();
batalla.EscribirMensajePorLetras("Viaje antes que destino", TimeSpan.FromMilliseconds(30));
Thread.Sleep(50);
batalla.EscribirMensajePorLetras("Fuerza antes que debilidad", TimeSpan.FromMilliseconds(30));
Thread.Sleep(50);
batalla.EscribirMensajePorLetras("Vida antes que muerte", TimeSpan.FromMilliseconds(30));
Console.ReadKey();
batalla.EscribirMensajePorLetras("desea crear un personaje nuevo?", TimeSpan.FromMilliseconds(30));
batalla.EscribirMensajePorLetras("Tenga en cuenta lo siguiente:", TimeSpan.FromMilliseconds(30));
batalla.EscribirMensajePorLetras("-El personaje sera creado de manera aleatoria y este sera con el que jugara", TimeSpan.FromMilliseconds(30));
batalla.EscribirMensajePorLetras("-Si no desea crear uno nuevo se le asignara uno aleatorio", TimeSpan.FromMilliseconds(30));
batalla.EscribirMensajePorLetras("desea crear un personaje nuevo? (Y/N)", TimeSpan.FromMilliseconds(30));
do
{
    caracter=Console.ReadLine();
    if (caracter!="y" && caracter!="Y" && caracter!="n" && caracter!="N")
    {
        batalla.EscribirMensajePorLetras("el caracter ingresado es incorrecto, intentelo de nuevo", TimeSpan.FromMilliseconds(30));
        
    }
} while (caracter!="y" && caracter!="Y" && caracter!="n" && caracter!="N");

if (caracter=="y" || caracter=="Y")
{
    
    string nombre;
    DateTime fec;
    int edad;
    string apodo;
    List<Personaje> agregar= new List<Personaje>();
    Personaje nuevo;
    var url = $"https://randomuser.me/api/";
    var request = (HttpWebRequest)WebRequest.Create(url);
    request.Method = "GET";
    request.ContentType = "application/json";
    request.Accept = "application/json";
    try
    {
        using (WebResponse response = request.GetResponse())
        {
            using (Stream strReader = response.GetResponseStream())
            {
                if (strReader == null) return;
                using (StreamReader objReader = new StreamReader(strReader))
                {
                    string responseBody = objReader.ReadToEnd();
                    Root resultado = JsonSerializer.Deserialize<Root>(responseBody);
                    nombre=resultado.results[0].name.first;
                    fec=resultado.results[0].dob.date;
                    edad=resultado.results[0].dob.age;
                    apodo=resultado.results[0].login.username;
                    nuevo=FabricaDePersonajes.crear(nombre, fec, edad, apodo);
                    agregar.Add(nuevo);
                    persojanesJson.GuardarPersonaje(agregar, archivo);
                    Console.Clear();
                    batalla.EscribirMensajePorLetras("El personaje fue creado! veamos sus datos", TimeSpan.FromMilliseconds(30));
                    batalla.EscribirMensajePorLetras("Nombre: "+nuevo.Nombre, TimeSpan.FromMilliseconds(30));
                    batalla.EscribirMensajePorLetras("Edad: "+nuevo.Edad, TimeSpan.FromMilliseconds(30));
                    batalla.EscribirMensajePorLetras("Apodo: "+nuevo.Apodo, TimeSpan.FromMilliseconds(30));
                    batalla.EscribirMensajePorLetras("Tipo: "+nuevo.Tipo, TimeSpan.FromMilliseconds(30));
                    batalla.EscribirMensajePorLetras("Nivel: "+nuevo.Nivel, TimeSpan.FromMilliseconds(30));
                    principal=nuevo;
                    Console.ReadKey();
                }
            }
        }
    }
    catch (WebException ex)
    {
        Console.WriteLine("Problemas de acceso a la API");
    }
    
}else
{
    Console.Clear();
    batalla.EscribirMensajePorLetras("Como no desea crear nuevos personajes usaremos los ya existentes", TimeSpan.FromMilliseconds(30));
    Console.ReadKey();
    bandera=false;
}



List<Personaje> listaContrincantes = new List<Personaje>();
List<Personaje> listaPersonajes = new List<Personaje>();
if (persojanesJson.Existe(archivo2) && persojanesJson.Existe(archivo))
{
    listaContrincantes=persojanesJson.LeerPersonaje(archivo2);
    listaPersonajes=persojanesJson.LeerPersonaje(archivo);
    int x;
    double salud;
    int y;
    int i=1;
    bool cambio=true;
    double daño;
    if (principal==null)
    {
        x=batalla.rdm(0, listaPersonajes.Count);
        principal=listaPersonajes[x];
    }
    
    do
    {
        salud=principal.Salud;
        y=batalla.rdm(0,listaContrincantes.Count);
        while (listaContrincantes[y].Nivel!=principal.Nivel)
        {
            y=batalla.rdm(0, listaContrincantes.Count);
        }
        Personaje secundario= listaContrincantes[y];
        listaContrincantes.Remove(secundario);
        
        Console.Clear();
        Console.WriteLine("Comencemos el "+i+"° combate");
        Console.WriteLine("El primer combatiente: ");
        Console.WriteLine("Nombre: "+ principal.Nombre);
        Console.WriteLine("Apodo: "+ principal.Apodo);
        Console.WriteLine("Nivel: "+ principal.Nivel);
        Console.WriteLine("Tipo: "+ principal.Tipo);
        Console.ReadKey();
        Console.WriteLine("El segundo combatiente: ");
        Console.WriteLine("Nombre: "+ secundario.Nombre);
        Console.WriteLine("Apodo: "+ secundario.Apodo);
        Console.WriteLine("Nivel: "+ secundario.Nivel);
        Console.WriteLine("Tipo: "+ secundario.Tipo);
        Console.ReadKey();
        do
        {
            if (cambio)
            {
                daño=batalla.combate(principal, secundario);
                Console.WriteLine("daño causado por el primer combatiente: "+daño);
                secundario.Salud-=daño;
                cambio=false;
            }else
            {
                daño=batalla.combate(secundario, principal);
                Console.WriteLine("daño causado por el segundo combatiente: "+daño);
                principal.Salud-=daño;
                cambio=true;
            }
            
            Console.WriteLine("salud del primer combatiente: "+principal.Salud);
            Console.WriteLine("salud del segundo combatiente: "+secundario.Salud);
            Console.WriteLine("==========fin de round==========");
            if (principal.Salud<=0)
            {
                Console.WriteLine("FUISTE VENCIDO");
            }
            if (secundario.Salud<=0)
            {
                Console.WriteLine("VENCISTE A TU CONTRINCATE");
            }
            Console.WriteLine("...enter para continuar...");
            Console.ReadLine();
        } while (principal.Salud>0 && secundario.Salud>0 && listaContrincantes.Count>0); 
        i++;
        if (principal.Salud>0)
        {
            principal.Salud=salud;
            if (principal.Nivel<10)
            {
                principal.Nivel++;
                batalla.EscribirMensajePorLetras("Felicidades! como venciste a tu oponente subiste un nivel", TimeSpan.FromMilliseconds(30));
                int j=batalla.rdm(1,10);
                switch (j)
                {
                    case 1:
                    if (principal.Fuerza<10)
                    {
                        principal.Fuerza++;
                        batalla.EscribirMensajePorLetras("Y como recompenzas subes un punto en tu nivel de Fuerza", TimeSpan.FromMilliseconds(30));
                    }else
                    {
                        batalla.EscribirMensajePorLetras("Wow, ya tienes tu nivel de Fuerza al maximo, no puedes subir mas niveles", TimeSpan.FromMilliseconds(30));
                        batalla.EscribirMensajePorLetras("Ganaste un bonificacion de 5 puntos extra de vida", TimeSpan.FromMilliseconds(30));
                        principal.Salud+=5;
                    }
                    break;
                    case 3:
                    if (principal.Velocidad<10)
                    {
                        principal.Velocidad++;
                        batalla.EscribirMensajePorLetras("Y como recompenzas subes un punto en tu nivel de Velocidad", TimeSpan.FromMilliseconds(30));
                    }else
                    {
                        batalla.EscribirMensajePorLetras("Wow, ya tienes tu nivel de Velocidad al maximo, no puedes subir mas niveles", TimeSpan.FromMilliseconds(30));
                        batalla.EscribirMensajePorLetras("Ganaste un bonificacion de 5 puntos extra de vida", TimeSpan.FromMilliseconds(30));
                        principal.Salud+=5;
                    }
                    break;
                    case 2:
                    if (principal.Destreza<5)
                    {
                        principal.Destreza++;
                        batalla.EscribirMensajePorLetras("Y como recompenzas subes un punto en tu nivel de Destreza", TimeSpan.FromMilliseconds(30));
                    }else
                    {
                        batalla.EscribirMensajePorLetras("Wow, ya tienes tu nivel de Destreza al maximo, no puedes subir mas niveles", TimeSpan.FromMilliseconds(30));
                        batalla.EscribirMensajePorLetras("Ganaste un bonificacion de 5 puntos extra de vida", TimeSpan.FromMilliseconds(30));
                        principal.Salud+=5;
                    }
                    break;
                    case 7:
                    case 4:
                    if (principal.Armadura<10)
                    {
                        principal.Armadura++;
                        batalla.EscribirMensajePorLetras("Y como recompenzas subes un punto en tu nivel de Armadura", TimeSpan.FromMilliseconds(30));
                    }else
                    {
                        batalla.EscribirMensajePorLetras("Wow, ya tienes tu nivel de Armadura al maximo, no puedes subir mas niveles", TimeSpan.FromMilliseconds(30));
                        batalla.EscribirMensajePorLetras("Ganaste un bonificacion de 5 puntos extra de vida", TimeSpan.FromMilliseconds(30));
                        principal.Salud+=5;
                    }
                    break;
                    default:
                    batalla.EscribirMensajePorLetras("Ganaste un bonificacion de 5 puntos extra de vida", TimeSpan.FromMilliseconds(30));
                    principal.Salud+=5;
                    break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    } while (principal.Salud>0 && listaContrincantes.Count>0);
}else
{
    Console.Write("el archivo no existe");
}
