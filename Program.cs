using Clases;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Personaje nuevo;
FabricaDePersonajes fb =new FabricaDePersonajes();
nuevo=fb.crear();
Console.WriteLine(nuevo.Nombre);
Console.WriteLine(nuevo.Apodo);
Console.WriteLine(nuevo.FechaNac);
Console.WriteLine(nuevo.Fuerza);
Console.WriteLine(nuevo.Armadura);
Console.WriteLine(nuevo.Edad);
Console.WriteLine(nuevo.Velocidad);
Console.WriteLine(nuevo.Tipo);