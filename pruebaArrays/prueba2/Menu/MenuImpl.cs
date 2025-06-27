using pruebaArrays.prueba2.Data;
using pruebaArrays.prueba2.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaArrays.prueba2.Menu
{
    public class MenuImpl
    {
        Validar valid = new Validar();
        bool loop = false;

        public int  menu() {
            Console.WriteLine("");
            Console.WriteLine("Juego vC");
            Console.WriteLine("- Menu -");
            Console.WriteLine("1. Jugar");
            Console.WriteLine("2. salir");
            return valid.validarInt("Ingrese una opcion: ");
        
        }

        public void presentarM() {
            do
            {
              int opcion =  menu();
                switch (opcion)
                {
                    case 1:
                        logica.juego();
                        break;
                    case 2:
                        loop = true;
                        break;
                    default:
                        Console.WriteLine("opcion fuera del menu...");

                        break;


                }
            }
            while (!loop);
            
        }
    }

    
}
