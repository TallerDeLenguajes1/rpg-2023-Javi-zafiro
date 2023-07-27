
using Clases;
using usarApi;
using System.IO;
using System.Net;
using System.Text.Json;
string? archivo = "Json";
bool bandera;
string? caracter="a";
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

batalla.EscribirMensajePorLetras("desea crear un nuevo personaje(aleatorio)? (Y/N)", TimeSpan.FromMilliseconds(30));
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
                    Console.ReadKey();
                }
            }
        }
    }
    catch (WebException ex)
    {
        Console.WriteLine("Problemas de acceso a la API");
    }
    Console.Clear();
    batalla.EscribirMensajePorLetras("Desea juagar con el personaje creado? (Y/N)", TimeSpan.FromMilliseconds(30));
    batalla.EscribirMensajePorLetras("Tenga en cuenta lo siguiente:", TimeSpan.FromMilliseconds(30));
    batalla.EscribirMensajePorLetras("- Su contrincante sera seleccionado de manera aleatoria", TimeSpan.FromMilliseconds(30));
    batalla.EscribirMensajePorLetras("- Si no desea jugar con el personaje que se creo, su personaje sera elegido aleatoriamente", TimeSpan.FromMilliseconds(30));
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
        bandera=true;
    }else
    {
        bandera=false;
    }
}else
{
    Console.Clear();
    batalla.EscribirMensajePorLetras("Como no desea crear nuevos personajes usaremos los ya existentes", TimeSpan.FromMilliseconds(30));
    Console.ReadKey();
    bandera=false;
}



List<Personaje> listaObtenida = new List<Personaje>();

bool existe = persojanesJson.Existe(archivo);
if (existe)
{
    listaObtenida=persojanesJson.LeerPersonaje(archivo);
    Personaje principal;
    int n=listaObtenida.Count;
    int x;
    int y;
    int i=1;
    bool cambio=true;
    double daño;
    if (bandera)
    {
        x=n-1;
    }else
    {
        x=batalla.rdm(0, n);
    }
    principal=listaObtenida[x];
    listaObtenida.Remove(principal);
    do
    {
        y=batalla.rdm(0,n);
        while (y==x)
        {
            y=batalla.rdm(0, n);
        }
        Personaje secundario= listaObtenida[y];
        listaObtenida.Remove(secundario);
        
        
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
        } while (principal.Salud>0 && secundario.Salud>0 && listaObtenida.Count>0); 
        i++;
        if (principal.Salud>0)
        {
            principal.Salud=100;
            if (principal.Nivel<10)
            {
                principal.Nivel++;
            }
        }
    } while (principal.Salud>0 && i<n);
}else
{
    Console.Write("el archivo no existe");
}
