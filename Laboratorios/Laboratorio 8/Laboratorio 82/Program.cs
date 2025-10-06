using System;

public class Cuenta
{
    private string idCuenta;
    public Cuenta(String prmtIdCuenta)
    {
        this.idCuenta = prmtIdCuenta;
        System.Console.WriteLine("Constructor Clase Base para cuenta {0}", prmtIdCuenta);
    }

    public virtual void CalcularInteres()
    {
        System.Console.WriteLine("Cuenta.CalcularIntereses() efectuado para la cuenta {0}", this.idCuenta);
    }
    
    public string getIdCuenta()
    {
        return this.idCuenta;
    }
}

public class CuentaCorriente : Cuenta
{ 
    public CuentaCorriente(String prmtIdCuenta) : base(prmtIdCuenta)
    {
    }

    public override void CalcularInteres()
    {
        System.Console.WriteLine("CuentaCorriente.CalcularIntereses() efectuado para la cuenta {0}", this.getIdCuenta());
    }
}

public class CuentaAhorro : Cuenta
{
    public CuentaAhorro(String prmtIdCuenta) : base(prmtIdCuenta)
    {
    }
    public override void CalcularInteres()
    {
        System.Console.WriteLine("CuentaAhorro.CalcularIntereses() efectuado para la cuenta {0}", this.getIdCuenta());
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        const string CUENTA = "100";
        Cuenta cuenta = new Cuenta(CUENTA);
        CuentaCorriente cuentaCorriente = new CuentaCorriente(CUENTA);
        CuentaAhorro cuentaAhorro = new CuentaAhorro(CUENTA);
        cuenta.CalcularInteres();
        cuentaCorriente.CalcularInteres();
        cuentaAhorro.CalcularInteres(); 
    }
}
