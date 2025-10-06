using System;

class ClaseBase
{
    public void test()
    { 
       
    }
    public virtual void masTests() //Sealed da el error de ejecucion, hay que cambiarlo por "virtual"
    { 
    
    }
}

class ClaseHijo : ClaseBase
{
    public override void masTests()
    { 
        
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Corrio la aplicacion");
    }
}
