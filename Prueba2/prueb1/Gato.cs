using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Prueba2.prueb1
{
    internal class Gato:Animal
    {
        public string colorPelo { get; set; }

        public void Miau()
        {
            Console.WriteLine($"{nombre} está maullando: ¡Miau!");
        }
    }
}
