using System.ComponentModel.Design;
using pruebaArrays.prueba1.Validacion;
using pruebaArrays.prueba1.Model;
using pruebaArrays.prueba1.logica;

namespace pruebaArrays.prueba1.Menu
{
    public class MenuTer
    {
        GestionImpl imple;
        ValidacionX valid;
        Producto[] lista;
        int numeroPR = 0;

        public MenuTer()
        {
        }
        public MenuTer(GestionImpl imple, ValidacionX valid) {
            this.imple = imple;
            this.valid = valid;
        }


        private int presentarMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Importadora vC");
            Console.WriteLine("- Menu -");
            Console.WriteLine("NOTA!!! - Para avanzar - Primero debe de asignar un numero de productos");
            Console.WriteLine("1. Crear Producto");
            Console.WriteLine("2. Listar Productos");
            Console.WriteLine("3. Eliminar Producto");
            Console.WriteLine("4. ingrese el numero de productos");
            Console.WriteLine("5. Salir");
            return valid.SolicitarNumero("Seleccione una opción del menu: ");
        }



        public void menuInporta()
        {
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
                            //Console.WriteLine("Ingrese el id del producto: ");
                            int idPr = valid.SolicitarNumero("Ingrese el id del producto: ");
                            Console.ReadLine();

                            Console.WriteLine("Ingrese el nombre del producto: ");
                            string nombre = Console.ReadLine();

                            //Console.WriteLine("Ingrese el precio del producto: ");
                            decimal price = valid.SolicitarNumero("Ingrese el precio del producto: ");

                            Producto pro = imple.save(new Producto(idPr, nombre, price));

                            break;

                        case 2:
                            lista = imple.obtenerAll();
                            foreach (var item in lista)
                            {
                                   Console.WriteLine(item.ToString());
                            }

                            break;

                        case 3:
                            int idEliminar = valid.SolicitarNumero("Ingrese el ID del producto a eliminar: ");
                            imple.eliminar(idEliminar);
                            break;

                        case 4:
                            numeroPR = valid.SolicitarNumero("ingrese la cantidad de productos que va a guardar: ");
                            imple = new GestionImpl(numeroPR);
                            p = 2;
                            break;

                        case 5:
                            salir = true;
                            Console.WriteLine("presione cualquier tecla para cerrar la terminal.");
                            break;

                        default:
                            Console.WriteLine("el valor ingresado no es valido....");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("!! --- Primero debe de ingregar el numero de productos a guardar ---!!");
                }
            } while (!salir);
        }

    }
}
