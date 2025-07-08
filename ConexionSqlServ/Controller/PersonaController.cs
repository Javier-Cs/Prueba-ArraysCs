using ConexionSqlServ.Entity;
using ConexionSqlServ.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionSqlServ.Controller
{
    public class PersonaController
    {
        PersonaRepository personaRepository;

        public PersonaController()
        {
            this.personaRepository = new PersonaRepository();
        }

        public void SavePersona()
        {
            throw new NotImplementedException();
        }
        
        
        public void GetAllPersonas()
        {
            List<PersonaEntity> listaPersonas = personaRepository.ObtenerAllPersonas();
            if (listaPersonas.Count == 0)
            {
                Console.WriteLine("No hay personas registradas.");
            }
            else {
                Console.WriteLine("\n--- Lista de Personas ---");
                foreach (var item in listaPersonas)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void GetByIdPersona()
        {
            throw new NotImplementedException();
        }


        public void UpdatePersona()
        {
            throw new NotImplementedException();
        }
        
        public void DeleteByIdPersona()
        {
            throw new NotImplementedException();
        }

    }
}
