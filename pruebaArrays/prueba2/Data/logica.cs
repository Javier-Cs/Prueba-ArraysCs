using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaArrays.prueba2.Data
{
    public class Logica
    {
        string[] palabras = {"linda", "camila", "luciana",
            "beatriz", "alejandra", "mariana", "melisa", "catalina", "andreina" };
        string palabra;
        string palabraABuscar;


        public void juego()
        {
            palabra = obtenerPalabraRandom();

            palabraABuscar = palabra;
            char[] arrayPalabra = palabraABuscar.ToCharArray();

            palabraABuscar = palabraABuscar.Replace("a", "_");
            palabraABuscar = palabraABuscar.Replace("l", "_");
            palabraABuscar = palabraABuscar.Replace("r", "_");

            char[] arrayBuscar = palabraABuscar.ToCharArray();
            Console.WriteLine("");
            Console.WriteLine("El nombre a buscar es:");
            Console.WriteLine(palabraABuscar);

            for (int i = 0; i < 5; i++)
            {
                bool acierto = false;
                Console.WriteLine("");
                Console.Write("Ingrese una caracter: ");
                char caracter = Console.ReadKey().KeyChar;
                Console.WriteLine();

                for (int j = 0; j < arrayPalabra.Length; j++)
                {
                    if (arrayPalabra[j] == caracter)
                    {
                        arrayBuscar[j] = caracter;
                        acierto = true;
                    }
                    else
                    {
                        acierto = false;
                    }
                }


                if (acierto)
                {
                    Console.WriteLine("Correcto");
                }
                else {
                    Console.WriteLine("Mal");
                }
                Console.WriteLine(new string(arrayBuscar));
            }
            Console.WriteLine("\nPalabra final:");
            Console.WriteLine(new string(arrayPalabra));
            Console.WriteLine("Progreso del jugador:");
            Console.WriteLine(new string(arrayBuscar));
            

        }
            

            
       


        private string obtenerPalabraRandom() {
            Random random = new Random();
            int indi = random.Next(palabras.Length);
            return palabras[indi];
        }

        //private void convertirCaracter(char a) {
        //    if () 
        //    {
        //    }
        //}



        


    }
}
