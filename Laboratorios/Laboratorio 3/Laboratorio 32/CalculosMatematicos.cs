using System;
   
namespace Laboratorio32{
    
    public class CalculosMatematicos{
        
        public double Calcular(float radio)
        {
            double operacion = (Math.PI * Math.Pow(radio, 2));
            return operacion;
        }
    }
}