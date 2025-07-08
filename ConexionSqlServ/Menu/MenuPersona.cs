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

        public Validaciones validaciones;

        public MenuPersona(Validaciones validaciones)
        {
            this.validaciones = validaciones;
        }


        public void mostrarMenu() {
            bool loop = false;
            int opcion = 0;
            do {
                opcion = menu();
                switch (opcion) {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        loop = true;
                        break;
                    default:
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
            return validaciones.obtenerNumero("Escoja una Opcion: ");
        }
    }
}
