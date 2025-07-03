using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2.UsoDeAbstract
{
    public class Circulos : Forma
    {
        public Circulos(string nombre, double radio):base(nombre)
        {
            this.radio = radio;
        }

        public double radio { get; set; }

        public override int numeroDeLados => 0;



        public override double calcularAres()
        {
            return Math.PI * radio * radio;
        }
    }
}
