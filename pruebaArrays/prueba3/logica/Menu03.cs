using pruebaArrays.prueba3.modelo;
using pruebaArrays.prueba3.validacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaArrays.prueba3.logica
{
    public class Menu03
    {
        Validacion valid = new Validacion();
        Metodos metodos = new Metodos();    
        

        public int Menu1() {
            Console.WriteLine("Menu estudiantes ");
            Console.WriteLine("1. agregar estudiante.");
            Console.WriteLine("2. mostrar notas de los estudiantes.");
            Console.WriteLine("3. calificacion mas alta y baja de la clase.");
            Console.WriteLine("4. salir.");
            return valid.optenerNumero("Digite una opcion");
        }



        public void mostrarMenu()
        {
            bool loop = false;
            double promedioGeneral = 0;

            do
            {
                switch (Menu1())
                {
                    case 1:
                        metodos.guardarEstudiante();
                        break;

                    case 2:
                        metodos.mostrarTodasLasNotas();
                        break;

                    case 3:
                        metodos.mostrar2Notas();
                        break;

                    case 4:
                        Console.WriteLine("Adios..");
                        loop = true;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida o fuera del menu escoja una correcta.");
                        break;
                }
            }
            while (!loop);
        }

    }
}
