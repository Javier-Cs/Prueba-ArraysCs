using PruebaListas.Modelo;

namespace PruebaListas
{
    internal class Program
    {
        static void Main(string[] args) { 
            Juego juego = new Juego();
            juego.ordenarDeMayoAMenor();




        //    Menu menu = new Menu();
        //    menu.guardar();
        //    menu.mostrar();
        //    Console.WriteLine("---");
        //    menu.eliminarTarea(2);
        //    Console.WriteLine("---");
        //    menu.mostrar();

        }
    }
    public class Juego { 
        List<int> puntajes = new List<int> {21, 54, 2 , 34, 24, 17, 66 };


        public void ordenarDeMayoAMenor() {
            Console.WriteLine("Puntuaciones originales: "+ string.Join(",", puntajes));

            puntajes.Sort();
            puntajes.Reverse();
            Console.WriteLine("Puntuacion ordenada: "+ string.Join(",", puntajes));


            int valormax = puntajes.Max();
            Console.WriteLine("valor maximo de la lista: "+valormax);
            int valorMin = puntajes.Min();
            Console.WriteLine("valor minimo de la lista: "+valorMin);
        }


    }
}
