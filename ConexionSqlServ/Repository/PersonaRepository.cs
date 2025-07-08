using ConexionSqlServ.Entity;
using ConexionSqlServ.Service;
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

        private readonly string _conexioSqlServer = "Data Source=JAVIERCS;" +
            " Initial Catalog=conect.Persona_tbl;" +
            "Integrated Security=True;";

        //constructor
        public PersonaRepository() { }

        public void ActualizarPersona(PersonaEntity persona)
        {
            throw new NotImplementedException();
        }

        public void EliminarPersona(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertarPersona(PersonaEntity persona)
        {
            throw new NotImplementedException();
        }

        public List<PersonaEntity> ObtenerAllPersonas()
        {
            throw new NotImplementedException();
        }

        public PersonaEntity ObtenerPersonaByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
