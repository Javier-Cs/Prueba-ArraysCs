using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaArrays.prueba2.Validaciones
{
    public class Validar
    {
        public bool esInt(string valor) {
            int numero;
            return int.TryParse(valor,out numero);
        
        }

        public int validarInt(string message)
        {
            bool loop = false;
            string valor;

            do {

                Console.Write(message);
                valor = Console.ReadLine();

                if (!esInt(valor))
                {
                    Console.WriteLine("El valor ingresado es invalido...");
                    loop = false;
                }
                else { 
                    loop = true;
                }

            } while (!loop);
            return Convert.ToInt32(valor);
        }
    }
}
