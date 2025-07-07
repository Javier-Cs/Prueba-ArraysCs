using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConhashSet.Clases
{
    public class UsoHashSet
    {
        public void mostrar() {
            Console.WriteLine("--- Ejercicio 2: Historial de Navegación (Queue<T>) ---");

            Queue<string> historialBusqueda = new Queue<string>();

            historialBusqueda.Enqueue("google.com");
            historialBusqueda.Enqueue("youtube.com");
            historialBusqueda.Enqueue("microsoft.com");
            historialBusqueda.Enqueue("github.com");

            Console.WriteLine("Historial de Navegacion, del mas antiguo al mas reciente");

            foreach (var item in historialBusqueda)
            {
                Console.WriteLine($"-{item}");
                
            }

            Console.WriteLine($"\nPróxima página a visitar (peek): {historialBusqueda.Peek()}");
            Console.WriteLine($"Visitando: {historialBusqueda.Dequeue()}");
            Console.WriteLine($"Visitando: {historialBusqueda.Dequeue()}");

            Console.WriteLine("\nHistorial restante:");
            foreach (string pagina in historialBusqueda)
            {
                Console.WriteLine($"- {pagina}");
            }

            Console.WriteLine("-------------------------------------------------");
        }
    }
}
