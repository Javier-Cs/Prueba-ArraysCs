using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TiendaOnlineConsole.Config;
using TiendaOnlineConsole.Entity;
using TiendaOnlineConsole.Service;

namespace TiendaOnlineConsole.Repository
{
    public class PedidoRepository : IServiceCrud<PedidoEntity>
    {
        private readonly string conectar = "Data Source=JAVIERCS;Initial Catalog=Tiendaonline_DB; User ID=sa; Password=21427711; TrustServerCertificate=True;";
        private readonly DetallePedidoService detallePedidoRepository;


        public PedidoRepository(DetallePedidoService detallePedidoService)
        {
            this.detallePedidoRepository = detallePedidoService;
        }

        public PedidoRepository()
        {
        }

        public void Guardar(PedidoEntity pedido)
        {
            return;
        }


        public List<PedidoEntity> ObtenerTodo()
        {
            List<PedidoEntity> listaDePedidos = new List<PedidoEntity>();
            using (SqlConnection conexion = new SqlConnection(conectar))
            {
                using (SqlCommand command = new SqlCommand(ConsultasSQL.Pedido_SelectAll, conexion))
                {
                    try
                    {
                        conexion.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            while (reader.Read())
                            {
                                PedidoEntity pedido = new PedidoEntity
                                {
                                    idPedido = reader.GetInt32(reader.GetOrdinal("PedidoId")),
                                    id_Cliente = reader.GetInt32(reader.GetOrdinal("Cliente_id")),
                                    fechaPedido = reader.GetDateTime(reader.GetOrdinal("FechaPedido")),
                                    estadoPedido = reader.GetString(reader.GetOrdinal("Estado")),
                                    totalPedido = reader.GetDecimal(reader.GetOrdinal("Total"))
                                };
                                listaDePedidos.Add(pedido);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error al eliminar cliente: {ex.Message}");
                    }
                }
            };
            return listaDePedidos;
        }


        public PedidoEntity ObtenerPorId(int id)
        {
            PedidoEntity pedido = null;
            using (SqlConnection conexion = new SqlConnection(conectar))
            {
                using (SqlCommand command = new SqlCommand(ConsultasSQL.Pedido_SelectByClienteId, conexion))
                {
                    command.Parameters.AddWithValue("PedidoId", id);
                    try
                    {
                        conexion.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) {
                                pedido = new PedidoEntity {
                                    idPedido = reader.GetInt32(reader.GetOrdinal("PedidoId")),
                                    id_Cliente = reader.GetInt32(reader.GetOrdinal("Cliente_id")),
                                    fechaPedido = reader.GetDateTime(reader.GetOrdinal("FechaPedido")),
                                    estadoPedido = reader.GetString(reader.GetOrdinal("Estado")),
                                    totalPedido = reader.GetDecimal(reader.GetOrdinal("Total"))
                                };
                                pedido.detalles = detallePedidoRepository.ObtenerDetallesPorPedidoId(pedido.idPedido);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error al eliminar cliente: {ex.Message}");
                    }
                }
            };
            return pedido;
        }

        public void Eliminar(int id)
        {
            using (SqlConnection conexion = new SqlConnection(conectar)) {
                conexion.Open();
                SqlTransaction transaction = conexion.BeginTransaction();
                try {
                    using (SqlCommand deletedetailsCommand = new SqlCommand(ConsultasSQL.DetallePedido_DeleteByPedidoId, conexion,transaction))
                    {
                        deletedetailsCommand.Parameters.AddWithValue("@PedidoId", id);
                        deletedetailsCommand.ExecuteNonQuery();
                    }
                    using (SqlCommand deletePedidoCommand = new SqlCommand(ConsultasSQL.Pedido_Delete, conexion, transaction))
                    {
                        deletePedidoCommand.Parameters.AddWithValue("@PedidoId", id);
                        int filasCaptur = deletePedidoCommand.ExecuteNonQuery();
                        if (filasCaptur > 0)
                        {
                            transaction.Commit();
                            Console.WriteLine("Cliente eliminado exitosamente.");
                        }
                        else
                        {
                            transaction.Rollback();
                            Console.WriteLine("No se encontró el cliente con el ID especificado para eliminar.");
                        }
                    }
                }
                catch (SqlException ex) {
                    transaction.Rollback();
                    Console.WriteLine($"Error al eliminar pedido: {ex.Message}");
                }
                
            };
        }


        public List<PedidoEntity> ObtenerPedidoPorClienteId(int id) {
            List<PedidoEntity> listadePedidosporId = new List<PedidoEntity> ();
            using (SqlConnection conexion = new SqlConnection(conectar))
            {
                using (SqlCommand command = new SqlCommand(ConsultasSQL.Pedido_SelectByClienteId, conexion)) {
                    command.Parameters.AddWithValue("@ClienteId", id);
                    try
                    {
                        conexion.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PedidoEntity pedido = new PedidoEntity
                                {
                                    idPedido = reader.GetInt32(reader.GetOrdinal("PedidoId")),
                                    id_Cliente = reader.GetInt32(reader.GetOrdinal("Cliente_id")),
                                    fechaPedido = reader.GetDateTime(reader.GetOrdinal("FechaPedido")),
                                    estadoPedido = reader.GetString(reader.GetOrdinal("Estado")),
                                    totalPedido = reader.GetDecimal(reader.GetOrdinal("Total"))
                                };
                                listadePedidosporId.Add(pedido);
                            }
                        }
                    }
                    catch (SqlException ex) {
                        Console.WriteLine($"Error al obtener pedidos por cliente ID: {ex.Message}");
                    }
                }
            }
            return listadePedidosporId;
        }

        public void ActualizarEstadoPedido(int pedidoId, string nuevoEstado) {
            using (SqlConnection conexion = new SqlConnection(conectar))
            {
                using (SqlCommand command = new SqlCommand(ConsultasSQL.Pedido_UpdateEstado))
                {
                    command.Parameters.AddWithValue("@Estado", nuevoEstado);
                    command.Parameters.AddWithValue("@PedidoId", pedidoId);

                    try {
                        conexion.Open();
                        int filasAfectadas = command.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            Console.WriteLine($"Estado del pedido {pedidoId} actualizado a '{nuevoEstado}' exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine($"No se encontró el pedido con el ID {pedidoId} para actualizar el estado.");
                        }

                    }
                    catch(SqlException ex){
                        Console.WriteLine($"Error al actualizar estado del pedido: {ex.Message}");
                    }

                }
            }
        }


        public int insertar(PedidoEntity pedido)
        {
            int pedidoId = -1;
            using (SqlConnection conexion = new SqlConnection(conectar))
            {
                conexion.Open();
                SqlTransaction transaccion = conexion.BeginTransaction();
                try
                {
                    using (SqlCommand command = new SqlCommand(ConsultasSQL.Pedido_Insert, conexion))
                    {
                        command.Parameters.AddWithValue("@ClienteId", pedido.idPedido);
                        command.Parameters.AddWithValue("@Estado", pedido.estadoPedido);
                        command.Parameters.AddWithValue("@Total", pedido.totalPedido);
                        pedidoId = Convert.ToInt32(command.ExecuteScalar());

                        foreach (var detalle in pedido.detalles)
                        {
                            detalle.id_Pedido = pedidoId;
                            detallePedidoRepository.InsertarDetallePedido(detalle);
                        }
                        transaccion.Commit();
                        Console.WriteLine($"Pedido {pedidoId} creado exitosamente.");
                    }
                }
                catch (SqlException ex)
                {
                    transaccion.Rollback(); // Revertir la transacción si algo falla
                    Console.WriteLine($"Error al crear el pedido: {ex.Message}");
                    pedidoId = -1;
                }
            }
            return pedidoId;
        }


        public void Actualizar(PedidoEntity entity)
        {
            
        }


    }
}
