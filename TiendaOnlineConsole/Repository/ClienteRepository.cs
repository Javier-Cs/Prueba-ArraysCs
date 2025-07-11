using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaOnlineConsole.Config;
using TiendaOnlineConsole.Entity;
using TiendaOnlineConsole.Service;

namespace TiendaOnlineConsole.Repository
{
    public class ClienteRepository : IServiceCrud<ClienteEntity>
    {
        private readonly string conectar = "Data Source=JAVIERCS; Initial Catalog=TiendaOnline_DB; Integrated Security=True;";
        
        // ----------------------------------------------------------
        public void Guardar(ClienteEntity cliente)
        {
            // verificamos que el email no exista
            using (SqlConnection conexion = new SqlConnection(conectar)) {
                using (SqlCommand checkCommand = new SqlCommand(ConsultasSQL.Cliente_ExistsByEmail ,conexion)) {
                    checkCommand.Parameters.AddWithValue("@Email", cliente.emailCliente);
                    conexion.Open();
                    int cantidad = (int)checkCommand.ExecuteScalar();
                    if (cantidad > 0) { 
                        Console.WriteLine($"Error: El email '{cliente.emailCliente}' ya está registrado.");
                        return; 
                    }
                }
                conexion.Close();

                using (SqlCommand command = new SqlCommand(ConsultasSQL.Cliente_Insert, conexion))
                {
                    command.Parameters.AddWithValue("@Nombre", cliente.nombreCliente);
                    command.Parameters.AddWithValue("@Apellido", cliente.apellidoCliente);
                    command.Parameters.AddWithValue("@Email", cliente.emailCliente);
                    try {
                        conexion.Open();
                        command.ExecuteNonQuery();
                        Console.WriteLine("Cliente insertado exitosamente.");
                    }
                    catch (SqlException ex) {
                        Console.WriteLine($"Error al insertar cliente: {ex.Message}");
                    }

                };
            };
        }



        // ----------------------------------------------------------
        public List<ClienteEntity> ObtenerTodo()
        {
            List<ClienteEntity> listaDeClientes = new List<ClienteEntity>();
            using (SqlConnection conexion = new SqlConnection(conectar)) {
                using (SqlCommand command = new SqlCommand(ConsultasSQL.Cliente_SelectAll, conexion) )
                {
                    try
                    {
                        conexion.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                listaDeClientes.Add(new ClienteEntity
                                {
                                    idCliente = reader.GetInt32(reader.GetOrdinal("ClienteId")),
                                    nombreCliente = reader.GetString(reader.GetOrdinal("Nombre")),
                                    apellidoCliente = reader.GetString(reader.GetOrdinal("Apellido")),
                                    emailCliente = reader.GetString(reader.GetOrdinal("Email")),
                                    fechaRegistroCliente = reader.GetDateTime(reader.GetOrdinal("Fecha_Registro")),
                                    activo = reader.GetBoolean(reader.GetOrdinal("Activo"))
                                }); 
                            }
                        }
                    }
                    catch (SqlException ex) {
                        Console.WriteLine($"Error al obtener clientes: {ex.Message}");
                    }
                };
            };
            return listaDeClientes;
        }



        // ----------------------------------------------------------
        public ClienteEntity ObtenerPorId(int id)
        {
            ClienteEntity cliente = null;
            using (SqlConnection conexion = new SqlConnection(conectar)) {
                using (SqlCommand command = new SqlCommand( ConsultasSQL.Cliente_SelectById, conexion)) {
                    command.Parameters.AddWithValue("@ClienteId", id);
                    try {
                        conexion.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            cliente = new ClienteEntity {
                                idCliente = reader.GetInt32(reader.GetOrdinal("ClienteId")),
                                nombreCliente = reader.GetString(reader.GetOrdinal("Nombre")),
                                apellidoCliente = reader.GetString(reader.GetOrdinal("Apellido")),
                                emailCliente = reader.GetString(reader.GetOrdinal("Email")),
                                fechaRegistroCliente = reader.GetDateTime(reader.GetOrdinal("Fecha_Registro")),
                                activo = reader.GetBoolean(reader.GetOrdinal("Activo"))
                            };   
                        }
                    } catch (SqlException ex) {
                        Console.WriteLine($"Error al obtener cliente por ID: {ex.Message}");
                    }
                };
            };
            return cliente;
        }



        // ----------------------------------------------------------
        public void Actualizar(ClienteEntity cliente)
        {
            using (SqlConnection conexion = new SqlConnection(conectar)) {
                ClienteEntity clienteExistente = ObtenerPorId(cliente.idCliente);
                if (clienteExistente != null && clienteExistente.emailCliente != cliente.emailCliente) {
                    using (SqlCommand checkCommand = new SqlCommand(ConsultasSQL.Cliente_ExistsByEmail, conexion)) {
                        checkCommand.Parameters.AddWithValue("@Email", cliente.emailCliente);
                        conexion.Open();
                        int cantidad = (int)checkCommand.ExecuteScalar();
                        if (cantidad > 0)
                        {
                            Console.WriteLine($"Error: El nuevo email '{cliente.emailCliente}' ya está registrado por otro cliente.");
                            return;
                        }
                    }
                    conexion.Close();
                }
                using (SqlCommand command = new SqlCommand (ConsultasSQL.Cliente_Update, conexion)) {
                    command.Parameters.AddWithValue("@Nombre", cliente.nombreCliente);
                    command.Parameters.AddWithValue("@Apellido", cliente.apellidoCliente);
                    command.Parameters.AddWithValue("@Email", cliente.emailCliente);
                    command.Parameters.AddWithValue("@Activo", cliente.activo);
                    command.Parameters.AddWithValue("@ClienteId", cliente.idCliente);

                    try
                    {
                        conexion.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Cliente actualizado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró el cliente con el ID especificado para actualizar.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error al actualizar cliente: {ex.Message}");
                    }
                }
                ;
            };
        }



        // ----------------------------------------------------------
        public void Eliminar(int id)
        {
            using (SqlConnection conexion = new SqlConnection(conectar)) {
                using (SqlCommand command = new SqlCommand(ConsultasSQL.Cliente_Delete,conexion)) {
                    command.Parameters.AddWithValue("ClienteId", id);
                    try
                    {
                        conexion.Open();
                        int filasAfectadas = command.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            Console.WriteLine("Cliente eliminado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró el cliente con el ID especificado para eliminar.");
                        }

                    }
                    catch (SqlException ex) {
                        Console.WriteLine($"Error al eliminar cliente: {ex.Message}");
                        if (ex.Number == 547) // Error de clave foránea (FK)
                        {
                            Console.WriteLine("Este cliente no puede ser eliminado porque tiene pedidos asociados.");
                        }
                    }
                    
                };
            };
        }

        
    }
}
