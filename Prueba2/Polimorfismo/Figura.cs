using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Prueba2.Polimorfismo
{
    internal class Figura
    {
        public string nombre { get; set; }

        public Figura(string nombre) {
            nombre = nombre;
        }

        // Método virtual: puede ser sobreescrito por clases derivadas
        public virtual void Dibujar()
        {
            Console.WriteLine($"Dibujando una figura genérica: {nombre}");
        }
    }
}
