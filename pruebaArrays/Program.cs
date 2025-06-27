using pruebaArrays.prueba1.Menu;
using pruebaArrays.prueba2.Menu;

namespace pruebaArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MenuTer menu = new MenuTer();
            //menu.menuInporta();
            MenuImpl menu = new MenuImpl();
            menu.presentarM();

            Console.ReadKey();
        }

       
    }
}
