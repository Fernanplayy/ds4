using System;
namespace Laboratorio_21;
class Program
{
    private static void Main(string[] args)
    {
        Client client = new Client();

        client.FirstName = "Su_Nombre";
        client.LastName = "Su_Apellido";
        client.Age = 15;
        client.Id = 1;

        Console.WriteLine(client.GetFullName());
    }
}

public class Client
{
    //Definir atributos de la clase
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    
    //Definir el método GetFullName que retorna el nombre completo del cliente
    public string GetFullName()
    {
        return FirstName +" "+ LastName;
    }
}