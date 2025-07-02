using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2.prueb1
{
    internal class Animal
    {
        public string nombre { get; set; }
        public int edad { get; set; }

        public void comer()
        {
            Console.WriteLine($"{nombre} está comiendo.");
        }

        public void dormir()
        {
            Console.WriteLine($"{nombre} está durmiendo.");
        }
    }
}
