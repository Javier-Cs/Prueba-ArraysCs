using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnlineConsole.Validation
{
    public  static class ValidacionNum
    {

        // para enteros
        private static bool esInts( string valor) {
            return int.TryParse(valor, out _);
        }

        public static int ObtenerInt(string message) {
            string valor;
            bool loop = false;
            do
            {
                Console.Write(message);
                valor = Console.ReadLine();
                if (!esInts(valor))
                {
                    Console.WriteLine("El valor ingresado es invalido...");
                    loop = false;
                }
                else {
                    loop = true;
                }
            }
            while (!loop);
            return Convert.ToInt32(valor);
        }

        // para decimales
        private static bool EsDecimal(string valor)
        {
            return decimal.TryParse(valor, out _);
        }

        public static decimal obtenerDecimal(string message)
        {
            string valor;
            bool loop = false;

            do
            {
                Console.Write(message);
                valor = Console.ReadLine();
                if (!EsDecimal(valor))
                {
                    Console.WriteLine("El valor ingresado es inválido. Por favor, ingrese un número decimal (ej. 10.50).");
                    loop = false;
                }
                else
                {
                    loop = true;
                }
            } while (!loop);
            return Convert.ToDecimal(valor);
        }
    }
}
