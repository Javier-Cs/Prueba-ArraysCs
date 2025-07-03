using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2.UsoDeAbstract
{
    public class Rectangulos : Forma
    {
        public Rectangulos(string nombre, double ancho, double alto) : base(nombre)
        {
            this.Ancho = ancho;
            this.Alto = alto;
        }

        public double Ancho { get; set; }
        public double Alto { get; set; }

        public override int numeroDeLados => 4;

        public override double calcularAres()
        {
            return Ancho * Alto;
        }
    }
}
