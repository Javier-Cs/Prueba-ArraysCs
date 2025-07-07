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
            Console.WriteLine("Ejercicio 2 hashSet");


            List<int> list1 = new List<int> { 1, 2, 3, 4, 5 };
            List<int> list2 = new List<int> { 4, 5, 6, 7, 8 };

            HashSet<int> listaNum1 = new HashSet<int> (list1);
            HashSet<int> listaNum2 = new HashSet<int> (list2);


            Console.WriteLine("Lista A: "+ string.Join(",", listaNum1));
            Console.WriteLine("Lista B: " + string.Join(",", listaNum2));

            listaNum1.IntersectWith(listaNum2);
            Console.WriteLine("\nElementos en común (intersección): " + string.Join(", ", listaNum1));


            listaNum1 = new HashSet<int>(listaNum2);
            listaNum1.UnionWith(listaNum2);

            Console.WriteLine("Todos los elementos únicos (unión): " + string.Join(", ", listaNum1));

            Console.WriteLine("-------------------------------------------------");



        }
    }
}
