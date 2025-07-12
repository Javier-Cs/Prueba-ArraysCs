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
    public class ProductoRepository : IServiceCrud<ProductoEntity>
    {

        private readonly string conectar = "Data Source=JAVIERCS;Initial Catalog=Tiendaonline_DB; User ID=sa; Password=21427711; TrustServerCertificate=True;";

        public void Guardar(ProductoEntity producto)
        {
            using (SqlConnection conexion = new SqlConnection(conectar))
            {
                using (SqlCommand command = new SqlCommand(ConsultasSQL.Producto_Insert, conexion))
                {
                    command.Parameters.AddWithValue("@NombreProducto", producto.nombreProducto);
                    command.Parameters.AddWithValue("@DescripcionProducto", producto.descripcionProducto);
                    command.Parameters.AddWithValue("@Precio", producto.precioProducto);
                    command.Parameters.AddWithValue("@Stock", producto.stockProducto);
                    command.Parameters.AddWithValue("@Categoria", producto.categoriaProducto);
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


        public List<ProductoEntity> ObtenerTodo()
        {
            List<ProductoEntity> listaProductos = new List<ProductoEntity>();
            using (SqlConnection conexion = new SqlConnection(conectar))
            {
                using (SqlCommand command = new SqlCommand(ConsultasSQL.Producto_SelectAll, conexion))
                {
                    try {
                        conexion.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            while (reader.Read())
                            {
                                listaProductos.Add(new ProductoEntity
                                {
                                    idProducto = reader.GetInt32(reader.GetOrdinal("ProductoId")),
                                    nombreProducto = reader.GetString(reader.GetOrdinal("Nombre_producto")),
                                    descripcionProducto = reader.GetString(reader.GetOrdinal("descrpcion_producto")),
                                    precioProducto = reader.GetDecimal(reader.GetOrdinal("precio")),
                                    stockProducto = reader.GetInt32(reader.GetOrdinal("stock")),
                                    categoriaProducto = reader.GetString(reader.GetOrdinal("categoria")),
                                    fechaActualizacionProduct = reader.GetDateTime(reader.GetOrdinal("Fecha_actualizacion"))
                                });
                            }
                        }
                    }
                    catch (SqlException ex) {
                        Console.WriteLine($"Error al obtener clientes: {ex.Message}");
                    }

                };
            };

            return listaProductos;
        }


        public ProductoEntity ObtenerPorId(int id)
        {
            ProductoEntity producto = null;
            using (SqlConnection conexion = new SqlConnection(conectar))
            {
                using (SqlCommand command = new SqlCommand(ConsultasSQL.Producto_SelectById, conexion))
                {
                    command.Parameters.AddWithValue("ProductoId", id);
                    try
                    {
                        conexion.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read())
                            {
                                producto = new ProductoEntity
                                {
                                    idProducto = reader.GetInt32(reader.GetOrdinal("ProductoId")),
                                    nombreProducto = reader.GetString(reader.GetOrdinal("Nombre_producto")),
                                    descripcionProducto = reader.GetString(reader.GetOrdinal("descrpcion_producto")),
                                    precioProducto = reader.GetDecimal(reader.GetOrdinal("precio")),
                                    stockProducto = reader.GetInt32(reader.GetOrdinal("stock")),
                                    categoriaProducto = reader.GetString(reader.GetOrdinal("categoria")),
                                    fechaActualizacionProduct = reader.GetDateTime(reader.GetOrdinal("Fecha_actualizacion"))
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al obtener cliente por ID: {ex.Message}");
                    }
                };
            };
            return producto;
        }


        public void Actualizar(ProductoEntity producto)
        {
            using (SqlConnection conexion = new SqlConnection(conectar)) { 
                using (SqlCommand command = new SqlCommand(ConsultasSQL.Producto_Update, conexion))
                {
                    command.Parameters.AddWithValue("@NombreProducto", producto.nombreProducto);
                    command.Parameters.AddWithValue("@DescripcionProducto", producto.descripcionProducto);
                    command.Parameters.AddWithValue("@Precio", producto.precioProducto);
                    command.Parameters.AddWithValue("@Stock", producto.stockProducto);
                    command.Parameters.AddWithValue("@Categoria", producto.categoriaProducto);
                    command.Parameters.AddWithValue("@ProductoId", producto.idProducto);
                    try
                    {
                        conexion.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Producto actualizado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró el producto con el ID especificado para actualizar.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error al actualizar cliente: {ex.Message}");
                    }
                };
            }
        }


        public void Eliminar(int id)
        {
            using (SqlConnection conexion = new SqlConnection(conectar))
            {
                using (SqlCommand command = new SqlCommand(ConsultasSQL.Producto_Delete, conexion))
                {
                    command.Parameters.AddWithValue("ProductoId", id);
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
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al eliminar cliente: {ex.Message}");
                    }
                }
                ;
            };
        }

        public void ActualizarstockProductos(int idProducto, int cantidad) {
            
        }

    }
}
