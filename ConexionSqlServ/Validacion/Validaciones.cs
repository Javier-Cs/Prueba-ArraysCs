using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionSqlServ.Validacion
{
    public class Validaciones
    {

        private bool EsNumero(string valor) {
            return int.TryParse(valor, out _);
        }

        public int obtenerNumero(string message) {
            string valor;
            bool loop = false;


            do {
                Console.Write(message);
                valor = Console.ReadLine();
                if (!EsNumero(valor))
                {
                    Console.WriteLine("El valor ingresado es invalido...");
                    loop = false;
                }
                else
                {
                    loop = true;
                }
            } while (!loop);
            return Convert.ToInt32(valor);
        }


    }
}
