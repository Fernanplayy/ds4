using Laboratorio31;

internal class Program
{ 
    private static void Main(string[] args)
    {
        int a, b;

        Console.WriteLine("Introduce el primer numero");
        a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Introduce el segundo numero");
        b = Convert.ToInt32(Console.ReadLine());

        CalculosMatematicos calc = new CalculosMatematicos();

        Console.WriteLine("Resultado: "+calc.Calcular(a, b));
    }


}