using Prueba2.prueba2;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Prueba2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Coche miCoche = new Coche("Toyota", "Corola");
            miCoche.arrancar();
            
        }
    }
//Perro perro = new Perro();
            //// atributos heredados
            //perro.nombre = "palo";
            //perro.edad = 2;
            //// atributos propios
            //perro.raza = "velga";

            //// metodo propio
            //perro.ladrar();
            //// metodo heredados
            //perro.dormir();
            //perro.comer();




            //Console.WriteLine("---------------");
            //Gato gato = new Gato();
            //// atributos heredados
            //gato.nombre = "filo";
            //gato.edad = 2;
            //// atributos heredados
            //gato.colorPelo = "negro";


            //// metodo propio
            //gato.Miau();
            //// metodo heredados
            //gato.dormir();
            //gato.comer();
    


}
