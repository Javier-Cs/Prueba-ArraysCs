using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaArrays.prueba4.Metodos
{
    public class Logica
    {
        string[] turnos = new string[10];
        int contador = 0; 

        public void sacarTurno() {
            Console.Write("escriba su nombre: ");
            string nombreTurno = Console.ReadLine();
            if (turnos != null) {
                turnos[contador] = nombreTurno;
                contador++;
            }
            
        }

        public void atenderTurno()
        {
            if (contador == 0)
            {
                Console.WriteLine("No hay turnos para atender.");
                return;
            }

            Console.WriteLine("Atendiendo a: " + turnos[0]);

            // Desplazar todos los turnos una posición a la izquierda
            for (int i = 0; i < contador - 1; i++)
            {
                turnos[i] = turnos[i + 1];
            }

            // Limpiar la última posición
            turnos[contador - 1] = null;

            // Reducir el contador
            contador--;
        }

        public void mostrarTurnosPendientes()
        {
            Console.WriteLine("\nturnos en espera: ");
            if (contador == 0) {
                Console.WriteLine("No existen turnos");
            }
            for (int i = 0; i < turnos.Length; i++)
            {
                if (turnos[i] != null) { 
                    Console.WriteLine(i+1+". "+turnos[i]);
                }

                
            }
        }
    }
}
