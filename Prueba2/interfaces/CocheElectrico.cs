using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2.interfaces
{
    internal class CocheElectrico : IManejable
    {
        public string TipoVehiculo { get; set; }

        public void Detener()
        {
            Console.WriteLine("El coche eléctrico está conduciendo silenciosamente.");
        }

        public void Mover()
        {
            Console.WriteLine("El coche eléctrico ha frenado.");
        }
    }
}
