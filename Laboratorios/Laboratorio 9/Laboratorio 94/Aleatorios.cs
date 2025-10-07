using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_94
{
    internal class Aleatorios
    {
        private static Random random = new Random();

        public Aleatorios()
        { 
            random = new Random();
        }

        public void generarNumero(int a, int b)
        { 
            int numero = random.Next(a + 1, b);
            Console.WriteLine(numero);
        }

        public void generarArray()
        { 
            int num1 = random.Next(1, 25);
            int num2 = random.Next(1, 25);

            if (num1 > num2)
            {
                int ssd = num1;
                num1 = num2;
                num2 = ssd;
            }

            int num3;
            int tamaño = num2 - num1;
            int [] array = new int[tamaño];

            for (int i = 0; i < tamaño; i++)
            {
                num3= random.Next(num1 + 1, num2);
                array[i] = num3;
            
                Console.WriteLine(array[i]);
            }
            

        }
    }
}
