using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Prueba2.Polimorfismo
{
    internal class Circulo : Figura
    {
        public double radio { get; set; }

        public Circulo(string nombre, double radio) : base(nombre)
        {
            radio = radio;
        }


        // Sobreescribiendo el método Dibujar
        public override void Dibujar()
        {
            Console.WriteLine($"Dibujando un círculo: {nombre} con radio {radio}");
        }
    }
}
