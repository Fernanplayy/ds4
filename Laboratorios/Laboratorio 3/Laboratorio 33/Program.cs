using Laboratorio33;

internal class Program
{
    private static void Main(string[] args)
    {
        int bases, altura;

        Console.WriteLine("Introduce el tamaño de la base del rectangulo: ");
        bases = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Introduce el tamaño de la altura del rectangulo: ");
        altura = Convert.ToInt32(Console.ReadLine());

        CalculosMatematicos calc = new CalculosMatematicos();

        Console.WriteLine("El area del circulo es: " + calc.Calcular(bases, altura));
    }
}