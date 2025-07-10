using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnlineConsole.Entity
{
    public class ProductoEntity
    {
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public string descripcionProducto { get; set; }
        public decimal precioProducto { get; set; }
        public int stockProducto { get; set; }
        public string categoriaProducto { get; set; }
        public DateTime fechaActualizacionProduct { get; set; }

        public override string ToString()
        {
            return $"ID: {idProducto}, Nombre: {nombreProducto}, Descripcion: {descripcionProducto}, Precio: {precioProducto:C},\n Stock: {stockProducto}, Categoría: {categoriaProducto}, Fecha producto: {fechaActualizacionProduct}";
        }
    }
}
