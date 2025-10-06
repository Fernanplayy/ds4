using System;

internal class Program { 
    private static void Main(string[] args) { 
        Console.WriteLine("Corrio la aplicacion");
        Console.ReadKey();
    }
}

public class ClaseBase //No se puede heredar una clase sealed
{
    public void test() 
    {
        
    }

    public void MoreTesting() 
    {
    
    }
}

class ClaseHijo : ClaseBase
{
}