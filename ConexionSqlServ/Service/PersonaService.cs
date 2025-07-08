using ConexionSqlServ.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionSqlServ.Service
{
    public interface PersonaService
    {
        public void InsertarPersona(PersonaEntity persona);
        public List<PersonaEntity> ObtenerAllPersonas();
        public PersonaEntity ObtenerPersonaByID(int id);
        public void ActualizarPersona(PersonaEntity persona);
        public void EliminarPersona(int id);
    }
}
