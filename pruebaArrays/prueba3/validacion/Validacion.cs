using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaArrays.prueba3.validacion
{
    public class Validacion
    {
        private bool esEntero(string n) {
            int validar = 0;
            return int.TryParse(n, out validar);
        }

        public double optenerDouble(string mensaje)
        {
            string valor;
            bool n = false;
            do
            {
                Console.Write(mensaje);
                valor = Console.ReadLine();
                object obj = Convert.ToDouble(valor);
                if (obj is double) {
                    n = true;
                }
                else
                {
                    Console.WriteLine("El valor ingresado es invalido...");
                    n = false;
                }
            } while (!n);
            return Convert.ToDouble(valor);
        }


        public int optenerNumero(string mensaje)
        {
            string valor;
            bool n = false;
            do
            {
                Console.Write(mensaje);
                valor = Console.ReadLine();
                if (!esEntero(valor)) {
                    Console.WriteLine("El valor ingresado es invalido...");
                    n = false;
                }
                else
                {
                    n = true;
                }
            } while (!n);
            return Convert.ToInt32(valor);
        }
    }
}
