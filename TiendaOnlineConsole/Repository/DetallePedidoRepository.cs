using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaOnlineConsole.Config;
using TiendaOnlineConsole.Entity;
using TiendaOnlineConsole.Service;

namespace TiendaOnlineConsole.Repository
{
    public class DetallePedidoRepository : DetallePedidoService
    {
        private readonly string conectar = "Data Source=JAVIERCS;Initial Catalog=Tiendaonline_DB; User ID=sa; Password=21427711; TrustServerCertificate=True;";
        private readonly ProductoRepository productoRepository;

        public DetallePedidoRepository(ProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }

        public void InsertarDetallePedido(DetallePedidoEntity detalle)
        {
            using (SqlConnection conexion = new SqlConnection(conectar))
            {
                using (SqlCommand command = new SqlCommand(ConsultasSQL.DetallePedido_Insert, conexion))
                {
                    command.Parameters.AddWithValue("@PedidoId", detalle.id_Pedido);
                    command.Parameters.AddWithValue("@ProductoId", detalle.id_Producto);
                    command.Parameters.AddWithValue("@Cantidad", detalle.cantidad);
                    command.Parameters.AddWithValue("@PrecioUnitario", detalle.precioUnitario);

                    try {
                        conexion.Open();
                        command.ExecuteNonQuery();
                        ProductoEntity producto = productoRepository.ObtenerPorId(detalle.id_Producto);

                        if (producto != null)
                        {
                            productoRepository.ActualizarstockProductos(detalle.id_Producto, producto.stockProducto - detalle.cantidad);
                        }
                        Console.WriteLine($"  Detalle de pedido para Producto ID {detalle.id_Producto} agregado exitosamente. Stock actualizado.");
                    } catch (SqlException ex) {
                        Console.WriteLine($"Error al insertar detalle de pedido: {ex.Message}");
                    }
                }
            }
        }

        public List<DetallePedidoEntity> ObtenerDetallesPorPedidoId(int pedidoId)
        {
            throw new NotImplementedException();
        }
    }
}
