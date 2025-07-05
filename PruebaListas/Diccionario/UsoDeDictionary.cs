using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PruebaListas.Diccionario
{
    public class UsoDeDictionary
    {
        Dictionary<int, string> catalogoDeProductos = new();
        public void Mostrar() { 
            Console.WriteLine("Ejercicio 1: Catálogo de Productos (Dictionary<TKey, TValue>)");
        
            // agregacion de algunos productos
            catalogoDeProductos.Add(101, "Laptop");
            catalogoDeProductos.Add(102, "Teclado");
            catalogoDeProductos.Add(103, "Monitor");
            catalogoDeProductos.Add(104, "Mouse");

            Console.WriteLine("Productos por catalogo:");
            foreach (var producto in catalogoDeProductos)
            {
                Console.WriteLine($"ID: {producto.Key}, Nombre: {producto.Value}");
            }
        }

        public void BuscarProductosById(int id) {
            if (catalogoDeProductos.TryGetValue(id, out string nombreProd))
            {
                Console.WriteLine($"\nProducto con ID {id}: {nombreProd}");
            }
            else
            {
                Console.WriteLine($"\nProducto con ID: {id} no fue encontrado");
            }

        }

        public void ConprobarSiProductExiste(string producto) {
            if (catalogoDeProductos.ContainsValue(producto))
            {
                Console.WriteLine($"\nEl catálogo contiene el producto '{producto}'.");
            }
            else
            {
                Console.WriteLine($"\nEl catálogo NO contiene el producto '{producto}'.");
            }
        }
        
    }
}
