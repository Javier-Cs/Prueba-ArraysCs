using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaArrays.prueba4.validacion
{
    public class Validaciones
    {
        public bool esNumero(string n) { 
            return int.TryParse(n, out _);  
        }


        public int obtenerNumero(string mensaje)
        {
            bool loop = false;
            Console.WriteLine(mensaje);
            string valor = Console.ReadLine();
            do
            {
                if (!esNumero(valor))
                {
                    Console.WriteLine("Escriba un valor correcto");
                    loop = false;
                }
            }
            while (!loop);
            return Convert.ToInt32(valor);
        }
    }
}
