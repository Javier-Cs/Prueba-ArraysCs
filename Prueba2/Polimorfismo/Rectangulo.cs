using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Prueba2.Polimorfismo
{
    internal class Rectangulo : Figura
    {
        public double Ancho { get; set; }
        public double Alto { get; set; }


        public Rectangulo(string nombre, double ancho, double alto) : base(nombre)
        {
            Ancho = ancho;
            Alto = alto;
        }



        // Sobreescribiendo el método Dibujar
        public override void Dibujar()
        {
            Console.WriteLine($"Dibujando un rectángulo: {nombre} con ancho {Ancho} y alto {Alto}");
        }
    }
}
