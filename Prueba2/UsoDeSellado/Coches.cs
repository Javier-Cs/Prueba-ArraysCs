using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2.UsoDeSellado
{
    public class Coches : Vehiculon
    {
        public override sealed void Conducir()
        {
            Console.WriteLine("Vehículo conduciendo.");
        }

    }

    public class CocheDeportivo : Coches {
        // Error: 'Coche.Conducir()' is sealed and cannot be overridden
        public override void Conducir() {
            Console.WriteLine("Coche deportivo acelerando.");
        }
    }
}
