using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaOnlineConsole.Entity;
using TiendaOnlineConsole.Repository;
using TiendaOnlineConsole.Validation;

namespace TiendaOnlineConsole.Controller
{
    public class ProductoController
    {
        private readonly ProductoRepository productoRepository = new ProductoRepository();

        

        internal void SaveProducto()
        {
            Console.WriteLine("\n--- Crear Nuevo Producto ---");
            Console.Write("Nombre del producto: ");
            string nombre = Console.ReadLine();
            Console.Write("Descripción: ");
            string descripcion = Console.ReadLine();
            decimal precio = ValidacionNum.obtenerDecimal("Precio: ");
            int stock = ValidacionNum.ObtenerInt("Stock inicial: ");
            Console.Write("Categoría: ");
            string categoria = Console.ReadLine();

            ProductoEntity nuevoproducto = new ProductoEntity
            {
                nombreProducto = nombre,
                descripcionProducto = descripcion,
                precioProducto = precio,
                stockProducto = stock,
                categoriaProducto = categoria
            };
            productoRepository.Guardar(nuevoproducto);
        }
        
        internal void VerAllProducto()
        {
            Console.WriteLine("\n--- Lista de Productos ---");
            List<ProductoEntity> listaProductos = productoRepository.ObtenerTodo();
            if (listaProductos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados.");
            }
            else
            {
                foreach (var producto in listaProductos)
                {
                    Console.WriteLine(producto);
                }
            }
        }

        internal void VerProductoeById()
        {
            int id = ValidacionNum.ObtenerInt("Ingrese el ID del producto a buscar: ");
            ProductoEntity producto = productoRepository.ObtenerPorId(id);
            if (producto != null)
            {
                Console.WriteLine($"\nProducto encontrado: {producto}");
            }
            else
            {
                Console.WriteLine($"No se encontró ningún producto con el ID {id}.");
            }
        }

        internal void UpdateProducto()
        {
            Console.WriteLine("\n--- Actualizar Producto ---");
            int id = ValidacionNum.ObtenerInt("Ingrese el ID del producto a actualizar: ");
            ProductoEntity productoExistente = productoRepository.ObtenerPorId(id);

            if (productoExistente != null) {
                Console.WriteLine($"No se encontró ningún producto con el ID {id}.");
                return;
            }

            Console.WriteLine($"\nProducto actual: {productoExistente}");
            Console.Write($"Nuevo nombre (actual: {productoExistente.nombreProducto}, dejar en blanco para no cambiar): ");
            string nuevoNombre = Console.ReadLine();
            Console.Write($"Nueva descripción (actual: {productoExistente.descripcionProducto}, dejar en blanco para no cambiar): ");
            string nuevaDescripcion = Console.ReadLine();
            decimal nuevoPrecio = ValidacionNum.obtenerDecimal($"Nuevo precio (actual: {productoExistente.precioProducto:C}): ");
            int nuevoStock = ValidacionNum.ObtenerInt($"Nuevo stock (actual: {productoExistente.stockProducto}): ");
            Console.Write($"Nueva categoría (actual: {productoExistente.categoriaProducto}, dejar en blanco para no cambiar): ");
            string nuevaCategoria = Console.ReadLine();

            productoExistente.nombreProducto = string.IsNullOrWhiteSpace(nuevoNombre) ? productoExistente.nombreProducto : nuevoNombre;
            productoExistente.descripcionProducto = string.IsNullOrWhiteSpace(nuevaDescripcion) ? productoExistente.descripcionProducto : nuevaDescripcion;
            productoExistente.precioProducto = nuevoPrecio;
            productoExistente.stockProducto = nuevoStock;
            productoExistente.categoriaProducto = string.IsNullOrWhiteSpace(nuevaCategoria) ? productoExistente.categoriaProducto : nuevaCategoria;

            productoRepository.Actualizar(productoExistente);

        }

        internal void DeleteProducto()
        {
            Console.WriteLine("\n--- Eliminar Producto ---");
            int id = ValidacionNum.ObtenerInt("Ingrese el ID del producto a eliminar: ");
            productoRepository.Eliminar(id);
        }
    }
}
