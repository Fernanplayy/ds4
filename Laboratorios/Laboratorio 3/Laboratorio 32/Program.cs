using Laboratorio32;

internal class Program
{
    private static void Main(string[] args)
    {
        float radio, a;

        Console.WriteLine("Introduce el radio del circulo: ");
        radio = Convert.ToSingle(Console.ReadLine());

        CalculosMatematicos calc = new CalculosMatematicos();

        Console.WriteLine("El area del circulo es: " + calc.Calcular(radio));
    }
}