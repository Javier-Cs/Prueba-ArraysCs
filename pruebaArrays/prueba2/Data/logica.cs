using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaArrays.prueba2.Data
{
    public class Logica
    {
        string[] palabras = {"linda", "camila", "luciana",
            "beatriz", "aleja", "mariana", "melisa", "carla", "andreina" };

        public void juego()
        {
            string palabraABuscar = obtenerPalabraRandom();
            char[] arrayPalabra = palabraABuscar.ToCharArray();
        }


        private string obtenerPalabraRandom() {
            Random random = new Random();
            int indi = random.Next(palabras.Length);
            return palabras[indi];
        }

        


    }
}
