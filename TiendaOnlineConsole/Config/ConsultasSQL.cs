using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnlineConsole.Config
{
    public static class ConsultasSQL
    {
        // Clientes
        public static string Cliente_Insert = "INSERT INTO practica.Clientes_tbl (Nombre, Apellido, Email) VALUES (@Nombre, @Apellido, @Email)";
        public static string Cliente_SelectAll = "SELECT ClienteId, Nombre, Apellido, Email, Fecha_Registro, Activo FROM practica.Clientes_tbl";
        public static string Cliente_SelectById = "SELECT ClienteId, Nombre, Apellido, Email, Fecha_Registro, Activo FROM practica.Clientes_tbl WHERE ClienteId = @ClienteId";
        public static string Cliente_Update = "UPDATE practica.Clientes_tbl SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Activo = @Activo WHERE ClienteId = @ClienteId";
        public static string Cliente_Delete = "DELETE FROM practica.Clientes_tbl WHERE ClienteId = @ClienteId";
        public static string Cliente_ExistsByEmail = "SELECT COUNT(1) FROM practica.Clientes_tbl WHERE Email = @Email"; // Para verificar email único

        // Productos
        public static string Producto_Insert = "INSERT INTO practica.Productos_tbl (Nombre_producto, descrpcion_producto, precio, stock, categoria) VALUES (@NombreProducto, @DescripcionProducto, @Precio, @Stock, @Categoria)";
        public static string Producto_SelectAll = "SELECT ProductoId, Nombre_producto, descrpcion_producto, precio, stock, categoria, Fecha_actualizacion FROM practica.Productos_tbl";
        public static string Producto_SelectById = "SELECT ProductoId, Nombre_producto, descrpcion_producto, precio, stock, categoria, Fecha_actualizacion FROM practica.Productos_tbl WHERE ProductoId = @ProductoId";
        public static string Producto_Update = "UPDATE practica.Productos_tbl SET Nombre_producto = @NombreProducto, descrpcion_producto = @DescripcionProducto, precio = @Precio, stock = @Stock, categoria = @Categoria WHERE ProductoId = @ProductoId";
        public static string Producto_Delete = "DELETE FROM practica.Productos_tbl WHERE ProductoId = @ProductoId";
        public static string Producto_UpdateStock = "UPDATE practica.Productos_tbl SET stock = @Stock WHERE ProductoId = @ProductoId";

        // Pedidos
        public static string Pedido_Insert = "INSERT INTO practica.Pedido_tbl (Cliente_id, Total) VALUES (@ClienteId, @Total); SELECT SCOPE_IDENTITY();"; // Retorna el ID del pedido
        public static string Pedido_SelectAll = "SELECT PedidoId, Cliente_id, FechaPedido, Estado, Total FROM practica.Pedido_tbl";
        public static string Pedido_SelectById = "SELECT PedidoId, Cliente_id, FechaPedido, Estado, Total FROM practica.Pedido_tbl WHERE PedidoId = @PedidoId";
        public static string Pedido_SelectByClienteId = "SELECT PedidoId, Cliente_id, FechaPedido, Estado, Total FROM practica.Pedido_tbl WHERE Cliente_id = @ClienteId";
        public static string Pedido_UpdateEstado = "UPDATE practica.Pedido_tbl SET Estado = @Estado WHERE PedidoId = @PedidoId";
        public static string Pedido_Delete = "DELETE FROM practica.Pedido_tbl WHERE PedidoId = @PedidoId";

        // DetallesPedido
        public static string DetallePedido_Insert = "INSERT INTO practica.DetallesPedido_tbl (Pedido_Id, Producto_Id, Cantidad, PrecioUnitario) VALUES (@PedidoId, @ProductoId, @Cantidad, @PrecioUnitario)";
        public static string DetallePedido_SelectByPedidoId = "SELECT dp.DetalleId, dp.Pedido_Id, dp.Producto_Id, dp.Cantidad, dp.PrecioUnitario, p.Nombre_producto, p.categoria " +
                                                            "FROM practica.DetallesPedido_tbl dp " +
                                                            "JOIN practica.Productos_tbl p ON dp.Producto_Id = p.ProductoId " +
                                                            "WHERE dp.Pedido_Id = @PedidoId";
        public static string DetallePedido_DeleteByPedidoId = "DELETE FROM practica.DetallesPedido_tbl WHERE Pedido_Id = @PedidoId"; // Para eliminar detalles al eliminar un pedido
    }
}
