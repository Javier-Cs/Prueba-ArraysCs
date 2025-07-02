using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2.prueba2
{
    internal class Vehiculo
    {
        public string marca {  get; set; }

        public Vehiculo(string marca) {
            marca = marca;
        }

        // Usamos 'virtual' para permitir la sobreescritura
        public virtual void arrancar() {
            Console.WriteLine("Vehículo arrancando...");
        }
    }
}
