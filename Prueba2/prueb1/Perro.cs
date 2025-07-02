using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Prueba2.prueb1
{
    internal class Perro:Animal
    {
        public string raza { get; set; }

        public void ladrar()
        {
            Console.WriteLine($"{nombre} está ladrando: ¡Guau guau!");
        }
    }
}
