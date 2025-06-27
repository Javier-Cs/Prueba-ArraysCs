using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaArrays.Validacion
{
    public static class ValidacionX
    {
        public static bool ValidarNumero(string n) {
            int validar = 0;
            return int.TryParse(n, out validar);
        }

        public static int Valor( string message,string valor) {
            bool n = false;
            do {
                if (!ValidarNumero(valor))
                {
                    Console.WriteLine("El valor ingresado es invalido...");
                    Console.WriteLine(message);
                    valor = Console.ReadLine();
                    n = false;
                }
                else {
                    n = true;                 
                }
            } while (!n);
            return Convert.ToInt32(valor);
        }
    }
}
