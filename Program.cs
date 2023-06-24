using Clases;
List<Personaje> listaDePersonaje = new List<Personaje>();
List<Personaje> listaObtenida = new List<Personaje>();
Personaje nuevo;
FabricaDePersonajes fb = new FabricaDePersonajes();
int n;
Console.WriteLine("ingrese la cantidad de personajes");
int.TryParse(Console.ReadLine(), out n);
for (int i = 0; i < n; i++)
{
    nuevo=fb.crear();
    listaDePersonaje.Add(nuevo);
}
persojanesJson js = new persojanesJson(); 
Console.WriteLine("ingrese el nombre del archivo");
string? archivo = Console.ReadLine();
js.GuardarPersonaje(listaDePersonaje, archivo);
bool existe = js.Existe("C:\\Users\\Javier\\Documents\\2023\\Taller\\"+archivo);
if (existe)
{
    listaObtenida=js.LeerPersonaje("C:\\Users\\Javier\\Documents\\2023\\Taller\\"+archivo);
    foreach (var item in listaObtenida)
    {
        Console.WriteLine("nombre:"+item.Nombre);
        Console.WriteLine("apodo:"+item.Apodo);
        Console.WriteLine("nivel:"+item.Nivel);
        Console.WriteLine("Fecha de Nacimiento"+item.FechaNac);
        Console.WriteLine("Salud"+item.Salud);
        Console.WriteLine("Fuerza"+item.Fuerza);
        Console.WriteLine("Edad"+item.Edad);
        Console.WriteLine("Destreza"+item.Destreza);
        Console.WriteLine("Armadura"+item.Armadura);
        Console.WriteLine("===========================");
    }
}else
{
    Console.Write("el archivo no existe");
}