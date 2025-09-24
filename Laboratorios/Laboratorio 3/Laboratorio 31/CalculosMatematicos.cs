using System;
   
namespace Laboratorio31{
    
    public class CalculosMatematicos{
        
        public int Calcular(int a, int b)
        {
            int operacion = (a + b) * (a - b);
            return operacion;
        }
        
    }
}