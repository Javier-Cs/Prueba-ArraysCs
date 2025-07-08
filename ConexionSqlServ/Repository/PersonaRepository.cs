using ConexionSqlServ.Config;
using ConexionSqlServ.Entity;
using ConexionSqlServ.Service;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionSqlServ.Repository
{
    //clase de las operaciones crud
    public class PersonaRepository : PersonaService
    {

        private readonly string _conexioSqlServer = "Data Source=JAVIERCS;Initial Catalog=ConexionCs_db; User ID=sa; Password=21427711;";

        //constructor
        public PersonaRepository() { }

        //------------------------------------------------------------------------------------------
        public void InsertarPersona(PersonaEntity persona)
        {
            using (SqlConnection conexion = new SqlConnection(_conexioSqlServer)) {
                using(SqlCommand command = new SqlCommand(PeticionesSQL.Query_SavePersona, conexion)) {

                    command.Parameters.AddWithValue("@nombre", persona.NombrePersona);
                    command.Parameters.AddWithValue("@apellido", persona.ApellidoPersona);
                    command.Parameters.AddWithValue("@edad", persona.Edad);

                    try
                    {
                        conexion.Open();
                        command.ExecuteNonQuery();
                        Console.WriteLine("Persona guardada exitosamente");
                    }
                    catch (SqlException ex) {
                        Console.WriteLine($"Error al guardar una persona {ex.Message}");
                    }
                }
            }
        }


        //------------------------------------------------------------------------------------------
        public List<PersonaEntity> ObtenerAllPersonas()
        {
            List<PersonaEntity> ListaPersonas = new List<PersonaEntity>();

            using (SqlConnection conexion = new SqlConnection(_conexioSqlServer)) {
                using (SqlCommand command = new SqlCommand(PeticionesSQL.Query_SelectPersona, conexion)) {
                    try
                    {
                        conexion.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            while (reader.Read())
                            {
                                PersonaEntity persona = new PersonaEntity
                                {
                                    IdPersona = reader.GetInt32(reader.GetOrdinal("idPersona")),
                                    NombrePersona = reader.GetString(reader.GetOrdinal("nombrePersona")),
                                    ApellidoPersona = reader.GetString(reader.GetOrdinal("apellidoPersona")),
                                    Edad = reader.GetInt32(reader.GetOrdinal("edad"))
                                };
                                ListaPersonas.Add(persona);
                            }
                        }
                    }
                    catch (SqlException ex) {
                        Console.WriteLine($"No se pudo obtener la lista de personas${ex.Message}");
                    }
                }
            }
            return ListaPersonas;
        }


        //------------------------------------------------------------------------------------------
        public void ActualizarPersona(PersonaEntity persona)
        {
            using (SqlConnection conexion = new SqlConnection(_conexioSqlServer)) {
                using (SqlCommand command = new SqlCommand(PeticionesSQL.Query_UpdatePersona, conexion)) {
                    
                    command.Parameters.AddWithValue("@nombre", persona.NombrePersona);
                    command.Parameters.AddWithValue("@apellido", persona.ApellidoPersona);
                    command.Parameters.AddWithValue("@edad", persona.Edad);
                    command.Parameters.AddWithValue("@id", persona.IdPersona);
                    try {
                        conexion.Open();
                        int rowAffect = command.ExecuteNonQuery();
                        if (rowAffect > 0)
                        {
                            Console.WriteLine("Persona actualizada exitosamente.");
                        }
                        else {
                            Console.WriteLine("No se encontró la persona con el ID especificado para actualizar.");
                        }
                    }
                    catch (SqlException ex) {
                        Console.WriteLine($"Error al actualizar persona: {ex.Message}");
                    }
                }
            }
        }


        //------------------------------------------------------------------------------------------
        public PersonaEntity ObtenerPersonaByID(int id)
        {
            PersonaEntity persona = null;
            using (SqlConnection conexion = new SqlConnection(_conexioSqlServer)) {
                using (SqlCommand command = new SqlCommand(PeticionesSQL.Query_ObtenByIdPersona, conexion)) {
                    command.Parameters.AddWithValue("@id", id);
                    try
                    {
                        conexion.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) {

                            if (reader.Read()) {
                                persona = new PersonaEntity { 
                                    IdPersona = reader.GetInt32(reader.GetOrdinal("idPersona")),
                                    NombrePersona = reader.GetString(reader.GetOrdinal("nombrePersona")),
                                    ApellidoPersona = reader.GetString(reader.GetOrdinal("apellidoPersona")),
                                    Edad = reader.GetInt32(reader.GetOrdinal("edad"))
                                };
                            }
                        }
                    }
                    catch (SqlException ex) {
                        Console.WriteLine($"Error al obtener persona por ID: {ex.Message}");
                    }
                }
            }
            return persona;
        }


        //------------------------------------------------------------------------------------------
        public void EliminarPersona(int id)
        {
            using (SqlConnection conexion = new SqlConnection(_conexioSqlServer)) {
                using (SqlCommand command = new SqlCommand(PeticionesSQL.Query_DeletePersona, conexion)) {
                    command.Parameters.AddWithValue("@id", id);
                    try {
                        conexion.Open();
                        int rowsAffect = command.ExecuteNonQuery();
                        if (rowsAffect > 0) {
                            Console.WriteLine("Persona eliminada exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró la persona con el ID especificado para eliminar.");
                        }
                    }
                    catch (SqlException ex) {
                        Console.WriteLine($"Error al eliminar persona: {ex.Message}");
                    }
                }
            }
        }

    }
}
