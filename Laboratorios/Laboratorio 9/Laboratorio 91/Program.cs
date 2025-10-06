using System;

namespace Laboratorio_91
{
    class Program
    {
        static void Main(string[] args)
        {
            double precio;
            int opcion;
            string numCuenta;

            Console.WriteLine("Precio del producto: ");
            precio = double.Parse(Console.ReadLine());

            Console.WriteLine("Seleccione el método de pago:");
            Console.WriteLine("1. Efectivo");
            Console.WriteLine("2. Tarjeta");

            opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                Console.WriteLine("Introduzca el dinero en la ranuera de billetes. ----->");
            }
            else if (opcion == 2)
            {
                Console.WriteLine("Introduzca el numero de cuenta");
                numCuenta = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Opción no válida");
            }
        }
    }
}
