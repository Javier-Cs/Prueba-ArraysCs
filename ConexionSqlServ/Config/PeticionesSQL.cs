using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionSqlServ.Config
{
    public static class PeticionesSQL
    {
        public static string queriSave = "INSERT INTO conect.Persona_tbl (nombrePersona, apellidoPersona, edad) VALUES (@nombre, @apellido, @edad)";
        public static string querySelect = "SELECT idPersona, nombrePersona, apellidoPersona, edad FROM conect.Persona_tbl";
        public static string queriObtenById = "SELECT idPersona, nombrePersona, apellidoPersona, edad FROM conect.Persona_tbl WHERE idPersona = @id";
        public static string queriUpdate = "UPDATE conect.Persona_tbl SET nombrePersona = @nombre, apellidoPersona = @apellido, edad = @edad WHERE idPersona = @id";
        public static string queridelete = "DELETE FROM conect.Persona_tbl WHERE idPersona = @id";
    }
}
