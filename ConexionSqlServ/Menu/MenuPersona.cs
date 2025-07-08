using ConexionSqlServ.Controller;
using ConexionSqlServ.Validacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionSqlServ.Menu
{
    public class MenuPersona
    {
        PersonaController controller = new PersonaController();

        public void mostrarMenu() {
            bool loop = false;
            int opcion = 0;
            do {
                opcion = menu();
                switch (opcion) {
                    case 1:
                        controller.SavePersona();
                        break;
                    case 2:
                        controller.GetAllPersonas();
                        break;
                    case 3:
                        controller.GetByIdPersona();
                        break;
                    case 4:
                        controller.UpdatePersona();
                        break;
                    case 5:
                        controller.DeleteByIdPersona();
                        break;
                    case 6:
                        Console.WriteLine("Hasta luego.");
                        loop = true;
                        break;
                    default:
                        Console.WriteLine("Elija una opcion valida.");
                        loop = false;
                        break;            
                }
            } while (!loop);

            
        }




        private int menu() {
            Console.WriteLine("\nSelecciona una opción:");
            Console.WriteLine("1. Crear Persona");
            Console.WriteLine("2. Ver Todas las Personas");
            Console.WriteLine("3. Ver Persona por ID");
            Console.WriteLine("4. Actualizar Persona");
            Console.WriteLine("5. Eliminar Persona");
            Console.WriteLine("6. Salir");
            return Validaciones.obtenerNumero("Escoja una Opcion: ");
        }
    }
}
