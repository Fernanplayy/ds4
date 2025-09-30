using System;

class Program
{
    private int[] sueldos;

    private void Cargar() 
    {
        sueldos = new int[6];
        for (int f = 1; f < 5; f++)
        {
            Console.Write("Ingrese el sueldo del operario "+f+": ");
            String linea;
            linea = Console.ReadLine();
            sueldos[f] = int.Parse(linea);
        }
    }

    public void Imprimir() 
    {
        Console.Write("Los 5 sueldos de los operarops \n");
        for (int f = 1; f < 5; f++)
        {
            Console.Write("[" + sueldos[f]+"] ");
        }
        Console.ReadKey();  
    }

    static void Main(string[] args)
    {
        Program pv = new Program();
        pv.Cargar();
        pv.Imprimir();
    }
}