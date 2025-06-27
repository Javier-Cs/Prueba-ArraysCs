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

        private static void menuInporta()
        {
            
            GestionImpl imple = new GestionImpl();
            int opcion = 0;
            bool n = false;
            do {

                Console.WriteLine("Importadora vC");
                Console.WriteLine("- Menu -");
                Console.WriteLine("NOTA!!! - Para avanzar - Primero debe de asignar un numero de productos");
                Console.WriteLine("1. Crear Producto");
                Console.WriteLine("2. Listar Productos");
                Console.WriteLine("3. Eliminar Producto");
                Console.WriteLine("4. ingrese el numero de productos");
                Console.WriteLine("5. Salir");

            } while (!n);

            do {
                Console.Write("Seleccione una opción: ");
                string m = Console.ReadLine();
                if (!ValidacionX.ValidarNumero(m))
                {
                    Console.WriteLine("Ingreso un texto, ingrese un numero del menu.");
                    n = false;
                }
                else {
                    opcion = Convert.ToInt32(m);
                    n = true;
                }

            } while (!n);


            switch (opcion) {
                case 1:
                    Console.WriteLine("Ingrese el id del prosucto: ");
                    int idPr = Convert.ToInt32(Console.Read());
                    Console.ReadLine();

                    Console.WriteLine("Ingrese el nombre del producto: ");
                    string nombre = Console.ReadLine();

                    Console.WriteLine("Ingrese el precio del producto: ");
                    decimal price = Convert.ToDecimal(Console.ReadLine());

                    imple.save(new Producto(idPr, nombre, price ));


                    break;
                case 2:
                    break;
                case 3:
                    imple.eliminar(7);
                    break;
                case 4:
                    Console.WriteLine("ingrese el numero de productos que va a guardar: ");
                    int numeroPR = Convert.ToInt32(Console.ReadLine());
                    GestionImpl im = new GestionImpl(numeroPR);
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("el valor ingresado no es valido....");
                    break;
            
            }
        }
    }
}
