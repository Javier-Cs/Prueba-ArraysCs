using pruebaArrays.logica;
using pruebaArrays.Model;
using pruebaArrays.Validacion;
using System.ComponentModel.Design;

namespace pruebaArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            menuInporta();

            Console.ReadKey();
        }

        private static int presentarMenu() {
            Console.WriteLine("");
            Console.WriteLine("Importadora vC");
            Console.WriteLine("- Menu -");
            Console.WriteLine("NOTA!!! - Para avanzar - Primero debe de asignar un numero de productos");
            Console.WriteLine("1. Crear Producto");
            Console.WriteLine("2. Listar Productos");
            Console.WriteLine("3. Eliminar Producto");
            Console.WriteLine("4. ingrese el numero de productos");
            Console.WriteLine("5. Salir");
            return ValidacionX.SolicitarNumero("Seleccione una opción del menu: ");
        }



        private static void menuInporta()
        {
            GestionImpl imple = new GestionImpl();
            int p = 0;
            int opcion = 0;
            bool salir = false;

            do
            {
                opcion = presentarMenu();


                if (opcion == 4 || p == 2)
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Ingrese el id del producto: ");
                            int idPr = Convert.ToInt32(Console.Read());
                            Console.ReadLine();

                            Console.WriteLine("Ingrese el nombre del producto: ");
                            string nombre = Console.ReadLine();

                            Console.WriteLine("Ingrese el precio del producto: ");
                            decimal price = Convert.ToDecimal(Console.ReadLine());

                            imple.save(new Producto(idPr, nombre, price));

                            break;
                        case 2:
                            break;
                        case 3:
                            imple.eliminar(7);
                            break;
                        case 4:
                            int numeroPR = ValidacionX.SolicitarNumero("ingrese la cantidad de profuctos que va a guardar: ");
                            GestionImpl im = new GestionImpl(numeroPR);
                            p = 2;

                            break;
                        case 5:
                            salir = true;
                            Console.WriteLine("precione cualquier tecla para cerrar la terminal.");
                            break;
                        default:
                            Console.WriteLine("el valor ingresado no es valido....");
                            break;
                    }
                }
                else {
                    Console.WriteLine("!! --- Primero debe de ingregar el numero de productos a guardar ---!!");
                }
            } while (!salir);
        }
    }
}
