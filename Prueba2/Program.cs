using Prueba2.interfaces;
using Prueba2.Polimorfismo;
using Prueba2.prueba2;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Prueba2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IManejable vehiculo1 = new Bicicleta();
            vehiculo1.Mover();
            vehiculo1.Detener();
            Console.WriteLine($"Tipo de vehículo: {vehiculo1.TipoVehiculo}");

            Console.WriteLine("--------------------");

            IManejable vehiculo2 = new CocheElectrico();
            vehiculo2.Mover();
            vehiculo2.Detener();
            Console.WriteLine($"Tipo de vehículo: {vehiculo2.TipoVehiculo}");

            // Podemos ponerlos en una lista de la interfaz, lo que demuestra el polimorfismo con interfaces
            List<IManejable> vehiculos = new List<IManejable>();
            vehiculos.Add(new Bicicleta());
            vehiculos.Add(new CocheElectrico());

            Console.WriteLine("\nProbando con una lista de IManejable:");
            foreach (var v in vehiculos)
            {
                v.Mover();
            }

            // Declaramos una variable de tipo Figura (clase base)
            //Figura figura1 = new Circulo("Mi Círculo", 5.0);
            //Figura figura2 = new Rectangulo("Mi Rectángulo", 4.0, 6.0);
            //Figura figura3 = new Figura("Figura Abstracta"); // También podemos instanciar la base

            // A pesar de que las variables son de tipo Figura,
            // el método Dibujar() que se ejecuta es el de la clase derivada real
            //figura1.Dibujar(); // Llama a Dibujar() de Circulo
            //figura2.Dibujar(); // Llama a Dibujar() de Rectangulo
            //figura3.Dibujar(); // Llama a Dibujar() de Figura

            //Coche miCoche = new Coche("Toyota", "Corola");
            //miCoche.arrancar();

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
