
using pruebaArrays.prueba4.Metodos;
using pruebaArrays.prueba4.validacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaArrays.prueba4.Menu
{
    public class MostrarMenu
    {
        Validaciones valid = new Validaciones();
        Logica logica = new Logica();

        public int menu()
        {
            Console.WriteLine("");
            Console.WriteLine("BancaRed");
            Console.WriteLine("1. Sacer turno.");
            Console.WriteLine("2. Atender turno.");
            Console.WriteLine("3. Mostrar lista de turnos pendientes.");
            Console.WriteLine("4. Salir.");
            return valid.obtenerNumero("Escribe una opcion: ");
        }


        public void implementaMenu() {
        
            bool loop=false;
            do
            {
                switch (menu()) {

                    case 1:
                        logica.sacarTurno();
                        break;
                    case 2:
                        logica.atenderTurno();
                        break;
                    case 3:
                        logica.mostrarTurnosPendientes();
                        break;
                    case 4:
                        Console.WriteLine("Adios");
                        loop = true;
                        break;
                    default:
                        Console.WriteLine("el valor ingresado no es valido");
                        break;

                }
                
            }
            while (!loop);
        }
    }
}
