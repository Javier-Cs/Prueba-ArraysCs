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

        private readonly string _conexioSqlServer = "Data Source=JAVIERCS; Initial Catalog=conect.Persona_tbl; Integrated Security=True";

        //constructor
        public PersonaRepository() { }

        //------------------------------------------------------------------------------------------
        public void InsertarPersona(PersonaEntity persona)
        {
            using (SqlConnection conexion = new SqlConnection(_conexioSqlServer)) {
                //esta peticion se la puede obtener y almacenar en una variable
                // o instanciarla directamente.
                //PeticionesSQL.Query_SavePersona;
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
                    conexion.Close();
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
                conexion.Close();
            }
            return ListaPersonas;
        }


        //------------------------------------------------------------------------------------------
        public void ActualizarPersona(PersonaEntity persona)
        {
            throw new NotImplementedException();
        }


        //------------------------------------------------------------------------------------------
        public PersonaEntity ObtenerPersonaByID(int id)
        {
            throw new NotImplementedException();
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
