using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2.interfaces
{
    internal class Bicicleta : IManejable
    {
        public string TipoVehiculo { get; set ; }


        // Implementación del método Detener
        public void Detener()
        {
            Console.WriteLine("La bicicleta está pedaleando.");
        }


        // Implementación del método Mover
        public void Mover()
        {
            Console.WriteLine("La bicicleta se ha detenido.");
        }
        
    }
}
