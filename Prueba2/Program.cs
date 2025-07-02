using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Prueba2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Perro perro = new Perro();
            // atributos heredados
            perro.nombre = "palo";
            perro.edad = 2;
            // atributos propios
            perro.raza = "velga";

            // metodo propio
            perro.ladrar();
            // metodo heredados
            perro.dormir();
            perro.comer();




            Console.WriteLine("---------------");
            Gato gato = new Gato();
            // atributos heredados
            gato.nombre = "filo";
            gato.edad = 2;
            // atributos heredados
            gato.colorPelo = "negro";


            // metodo propio
            gato.Miau();
            // metodo heredados
            gato.dormir();
            gato.comer();
        }
    }

    // Clase base
    public class Animal
    {
        public string nombre {  get; set; }
        public int edad {  get; set; }

        public void comer() {
            Console.WriteLine($"{nombre} está comiendo.");
        }

        public void dormir() {
            Console.WriteLine($"{nombre} está durmiendo.");
        }
    }


    // Clase derivada de clase base
    public class Perro :Animal { 
        public string raza { get; set; }

        public void ladrar() {
            Console.WriteLine($"{nombre} está ladrando: ¡Guau guau!");
        }
        
    }

    // Clase derivada de clase base
    public class Gato: Animal {
        public string colorPelo { get; set; }

        public void Miau() {
            Console.WriteLine($"{nombre} está maullando: ¡Miau!");
        }
    }


}
