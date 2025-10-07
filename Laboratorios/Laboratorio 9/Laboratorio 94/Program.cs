using System;

namespace Laboratorio_94 
{ 
    class Program 
    {
        static void Main(string[] args)
        {
            int a, b, opcion;
            Aleatorios aleatorio = new Aleatorios();

            Console.WriteLine("Seleccione una opcion:");
            Console.WriteLine("1. Generar un numero aleatorio entre dos numeros especificos");
            Console.WriteLine("2. Generar un array con numeros aleatorios entre dos numeros especificos");
            opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ingrese el valor del primer valor del rango:");
                    a = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Ingrese el valor del segundo valor del rango:");
                    b = Convert.ToInt32(Console.ReadLine());

                    aleatorio.generarNumero(a, b);

                    break;

                case 2:
                    aleatorio.generarArray();
            
                    break;
            }
        }
    }
}
