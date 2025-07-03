using Prueba2.interfaces;
using Prueba2.Polimorfismo;
using Prueba2.prueba2;
using Prueba2.UsoDeAbstract;
using Prueba2.UsoDeDelegado;
using Prueba2.UsoDeSellado;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Prueba2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Notificador notificador = new Notificador();

            // 2. Creación de instancias del delegado:
            // Opción A: Pasar el método directamente (C# infiere el delegado)
            ProcesarMensaje miManejador1 = notificador.EnviarPorConsola;
            miManejador1("Hola desde delegado 1!");

            // Opción B: Crear la instancia explícitamente (menos común ahora)
            ProcesarMensaje miManejador2 = new ProcesarMensaje(notificador.EnviarPorLog);
            miManejador2("Mensaje de log.");

            // 3. Multicast Delegates: Un delegado puede apuntar a múltiples métodos.
            // Cuando se invoca el delegado, todos los métodos suscritos se ejecutan en orden.
            ProcesarMensaje multicastManejador = notificador.EnviarPorConsola;
            multicastManejador += notificador.EnviarPorLog; // Añade otro método

            Console.WriteLine("\n--- Mensaje con Multicast Delegado ---");
            multicastManejador("Este mensaje va a varios lugares.");

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
