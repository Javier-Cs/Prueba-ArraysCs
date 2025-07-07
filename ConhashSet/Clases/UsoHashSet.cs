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
            Console.WriteLine("Ejercicio de Queue");
            Queue<int> listaDePedidos = new Queue<int>();

            // añadir a la cola
            listaDePedidos.Enqueue(1001);
            listaDePedidos.Enqueue(1002);
            listaDePedidos.Enqueue(1003);
            listaDePedidos.Enqueue(1004);


            //impresion
            Console.WriteLine("Pedidos en cola: "+string.Join(",", listaDePedidos));
            Console.WriteLine($"Pedidos pendientes: {listaDePedidos.Count}");


            Console.WriteLine("\nProcesando pedidos:");
            while (listaDePedidos.Count  > 0) {
                int pedidoActual = listaDePedidos.Dequeue();
                Console.WriteLine($"Procesando pedidos: {pedidoActual}. pedidos restantes: {listaDePedidos.Count}");
            }
            Console.WriteLine("Cola de pedidos vacía.");
            Console.WriteLine("-------------------------------------------------");
        }
    }
}
