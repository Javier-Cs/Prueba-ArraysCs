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
        public int optenerNumero(string mensaje) {

            string valor;
            bool n = false;

            do {
                Console.WriteLine(mensaje);
                valor = Console.ReadLine();
                if (!esEntero(valor) {
                    Console.WriteLine("El valor ingresado es invalido...");
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
