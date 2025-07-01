using pruebaArrays.prueba1.Menu;
using pruebaArrays.prueba3.logica;
using pruebaArrays.prueba4.Menu;

namespace pruebaArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MenuTer menu = new MenuTer();
            //menu.menuInporta();
            //MenuImpl menu = new MenuImpl();
            //menu.presentarM();

            //Menu03 menu = new Menu03();
            //menu.mostrarMenu();
            MostrarMenu menu = new MostrarMenu();
            menu.implementaMenu();

            Console.ReadKey();
        }

       
    }
}
