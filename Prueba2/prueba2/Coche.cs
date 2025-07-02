using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2.prueba2
{
    internal class Coche : Vehiculo
    {
        public string modelo {  get; set; }

        public Coche(string marca, string modelo) : base(marca)
        {
            this.modelo = modelo;
        }

        public override void arrancar()
        {
            // Llamando a la implementación de Arrancar de la clase base
            base.arrancar();
            Console.WriteLine("El coche está rugiendo.");

        }

    }
}
