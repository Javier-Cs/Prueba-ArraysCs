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
            Console.Write("Introduce el nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Introduce el apellido: ");
            string apellido = Console.ReadLine();

            int edad = Validacion.Validaciones.obtenerNumero("Introduce la edad: ");

            PersonaEntity persona = new PersonaEntity
            {
                NombrePersona = nombre,
                ApellidoPersona = apellido,
                Edad = edad
            };
            personaRepository.InsertarPersona(persona);            
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
            int id = Validacion.Validaciones.obtenerNumero("Ingresa el id de la persona a obtener: ");
            PersonaEntity persona = personaRepository.ObtenerPersonaByID(id);
            if (persona != null)
            {
                Console.WriteLine($"\nPersona encontrada: {persona}");
            }
            else
            {
                Console.WriteLine($"No se encontró ninguna persona con el ID {id}.");
            }
        }


        public void UpdatePersona()
        {
            int id = Validacion.Validaciones.obtenerNumero("Escriba id de la persona a actualizar");
            PersonaEntity personaExistente = personaRepository.ObtenerPersonaByID(id);
            if (personaExistente == null)
            {
                Console.WriteLine($"No se encontró ninguna persona con el ID {id}.");
                return;
            }

            Console.WriteLine($"\nActualizando persona: {personaExistente}");
            Console.Write($"Nuevo nombre (actual: {personaExistente.NombrePersona}, dejar en blanco para no cambiar): ");
            string nuevoNombre = Console.ReadLine();
            Console.Write($"Nuevo apellido (actual: {personaExistente.ApellidoPersona}, dejar en blanco para no cambiar): ");
            string nuevoApellido = Console.ReadLine();
            Console.Write($"Nueva edad (actual: {personaExistente.Edad}, introduce un número): ");
            int edad = Validacion.Validaciones.obtenerNumero("Escribe la edad: ");

            personaExistente.NombrePersona = string.IsNullOrWhiteSpace(nuevoNombre) ? personaExistente.NombrePersona : nuevoNombre;
            personaExistente.ApellidoPersona = string.IsNullOrWhiteSpace(nuevoApellido) ? personaExistente.ApellidoPersona : nuevoApellido;
            personaExistente.Edad = edad;

            personaRepository.ActualizarPersona(personaExistente);
        }
        
        public void DeleteByIdPersona()
        {
            int id = Validacion.Validaciones.obtenerNumero("Ingresa el id de la persona a eliminar: ");
            personaRepository.EliminarPersona(id);
        }

    }
}
