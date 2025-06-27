using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaArrays.Model
{
    public class Producto
    {
        private int idProducto { get; set; }
        private string nombre { get; set; }
        private decimal precio { get; set; }

        public Producto(int idProducto, string nombre, decimal precio) {
            this.idProducto = idProducto;
            this.nombre = nombre;
            this.precio = precio;
        }

    }
}
