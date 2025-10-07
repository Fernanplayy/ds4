using System;

namespace Laboratorio_93 { 
class Program
{
    static void Main(string[] args)
    {
        int lado1, lado2, lado3;
        int suma;

        Console.WriteLine("Introduzca el tamaño del lado 1:");
        lado1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Introduzca el tamaño del lado 2:");
        lado2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Introduzca el tamaño del lado 3:");
        lado3 = Convert.ToInt32(Console.ReadLine());

        if (lado1 == lado2 && lado1 == lado3)
        {
            Console.WriteLine("El triángulo es equilátero");
        }
        else if (lado1 == lado2 || lado1 == lado3 || lado2 == lado3)
        {
            Console.WriteLine("El triángulo es isósceles");
        }
        else
        {
            Console.WriteLine("El triángulo es escaleno");

        }
        suma= lado1 + lado2 + lado3;
        Console.WriteLine("El perimetro es: "+suma);
        }
    }
}