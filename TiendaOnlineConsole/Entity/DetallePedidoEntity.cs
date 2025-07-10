using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnlineConsole.Entity
{
    public class DetallePedidoEntity
    {
        public int idDetallePedido { get; set; }
        public int id_Pedido { get; set; }
        public int id_Producto { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        // Propiedades para mostrar información del producto (no son columnas de la tabla DetallesPedido_tbl)
        public string nombreProducto { get; set; }
        public string categoriaProducto { get; set; }

        public override string ToString()
        {
            return $"  Detalle ID: {idDetallePedido}, Producto ID: {id_Pedido} ({nombreProducto}), Cantidad: {cantidad}, Precio Unitario: {precioUnitario:C}";
        }
    }
}
