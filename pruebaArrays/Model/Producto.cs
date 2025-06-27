using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace pruebaArrays.Model
{
    public class Producto
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }

        public Producto(int idProducto, string nombre, decimal precio) {
            this.idProducto = idProducto;
            this.nombre = nombre;
            this.precio = precio;
        }
        public override string ToString()
        {
            return $"ID: {idProducto} - Nombre: {nombre} - Precio: {precio}";
        }

    }
}
