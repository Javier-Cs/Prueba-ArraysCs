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
        char[] arrayPalabra;
        char[] arrayBuscar;
        //string palabraABuscar;


        public void juego()
        {
            palabra = obtenerPalabraRandom();
            //palabraABuscar = palabra;
            arrayPalabra = palabra.ToCharArray();
            arrayBuscar = new char[arrayPalabra.Length];

            //palabraABuscar = palabraABuscar.Replace("a", "_");
            //palabraABuscar = palabraABuscar.Replace("l", "_");
            //palabraABuscar = palabraABuscar.Replace("r", "_");
            char[] letrasOcultas = { 'a', 'l', 'r' };
            for (int k = 0; k < arrayPalabra.Length;k ++)
            {
                if (Array.Exists(letrasOcultas, c => c == arrayPalabra[k]))
                {
                    arrayBuscar[k] = '_';
                }
                else {
                    arrayBuscar[k] = arrayPalabra[k];
                }

            }

            //arrayBuscar = palabraABuscar.ToCharArray();
            Console.WriteLine("\nEl nombre a buscar es:");
            Console.WriteLine(new string(arrayBuscar));

            for (int i = 0; i < 5; i++)
            {
                bool acierto = false;
                Console.Write("\nIngrese una caracter: ");
                char caracter = Char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();

                for (int j = 0; j < arrayPalabra.Length; j++)
                {
                    if (arrayPalabra[j] == caracter)
                    {
                        arrayBuscar[j] = caracter;
                        acierto = true;
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
                // para cerrar el bucle si ya completo la palabra y le sobran intentos
                if (new string(arrayPalabra) == new string(arrayBuscar))
                {
                    Console.WriteLine("\n|---- Ganaste pelado!! ----|\n");
                    break;
                }
            }
            if (new string(arrayPalabra) != new string(arrayBuscar))
            {
                Console.WriteLine("\n|---- Ya Perdiste pelado tonto!! ----|\n");
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
    }
}
