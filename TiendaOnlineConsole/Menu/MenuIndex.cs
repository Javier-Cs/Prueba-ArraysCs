using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaOnlineConsole.Controller;
using TiendaOnlineConsole.Validation;

namespace TiendaOnlineConsole.Menu
{
    public class MenuIndex
    {
        private readonly ClienteController clienteController = new ClienteController();
        private readonly ProductoController productoController = new ProductoController();
        private readonly PedidoController pedidoController = new PedidoController();


        public void MenuPrincipal()
        {
            bool loop = false; 
            do{
                Console.Clear();
                Console.WriteLine("===================================");
                Console.WriteLine("  APLICACIÓN DE TIENDA ONLINE");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Gestión de Clientes");
                Console.WriteLine("2. Gestión de Productos");
                Console.WriteLine("3. Gestión de Pedidos");
                Console.WriteLine("4. Salir");
                Console.WriteLine("===================================");
                int opcion = ValidacionNum.ObtenerInt("Seleccione una opción: ");

                switch (opcion)
                {
                    case 1:
                        MenuClientes();
                        break;
                    case 2:
                        MenuProducto();
                        break;
                    case 3:
                        MenuPedido();
                        break;
                    case 4:
                        loop = true;
                        Console.WriteLine("¡Gracias por usar la aplicación! Hasta luego.");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (!loop);
        }


        ///  Menu Clientes ---------------------
        private void MenuClientes()
        {
            bool loop = false;
            do{
                Console.Clear();
                Console.WriteLine("===================================");
                Console.WriteLine("       GESTIÓN DE CLIENTES");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Crear Cliente");
                Console.WriteLine("2. Ver Todos los Clientes");
                Console.WriteLine("3. Ver Cliente por ID");
                Console.WriteLine("4. Actualizar Cliente");
                Console.WriteLine("5. Eliminar Cliente");
                Console.WriteLine("6. Volver al Menú Principal");
                Console.WriteLine("===================================");
                int opcion = ValidacionNum.ObtenerInt("Seleccione una opción: ");

                switch (opcion)
                {
                    case 1:
                        clienteController.SaveCliente();
                        break;
                    case 2:
                        clienteController.VerAllClientes();
                        break;
                    case 3:
                        clienteController.VerClienteById();
                        break;
                    case 4:
                        clienteController.UpdateCliente();
                        break;
                    case 5:
                        clienteController.DeleteCliente();
                        break;
                    case 6:
                        loop = true;
                        Console.WriteLine("¡Gracias por usar la aplicación! Hasta luego.");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (!loop);
        }



        ///  Menu Productos ---------------------
        private void MenuProducto()
        {
            bool loop = false;
            do{
                Console.Clear();
                Console.WriteLine("===================================");
                Console.WriteLine("       GESTIÓN DE PRODUCTOS");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Crear Producto");
                Console.WriteLine("2. Ver Todos los Productos");
                Console.WriteLine("3. Ver Producto por ID");
                Console.WriteLine("4. Actualizar Producto");
                Console.WriteLine("5. Eliminar Producto");
                Console.WriteLine("6. Volver al Menú Principal");
                Console.WriteLine("===================================");
                int opcion = ValidacionNum.ObtenerInt("Seleccione una opción: ");

                switch (opcion)
                {
                    case 1:
                        productoController.SaveProducto();
                        break;
                    case 2:
                        productoController.VerAllProducto();
                        break;
                    case 3:
                        productoController.VerProductoeById();
                        break;
                    case 4:
                        productoController.UpdateProducto();
                        break;
                    case 5:
                        productoController.DeleteProducto();
                        break;
                    case 6:
                        loop = true;
                        Console.WriteLine("¡Gracias por usar la aplicación! Hasta luego.");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (!loop);
        }



        ///  Menu Pedidos ---------------------
        private void MenuPedido()
        {
            bool loop = false;
            do{
                Console.Clear();
                Console.WriteLine("===================================");
                Console.WriteLine("        GESTIÓN DE PEDIDOS");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Realizar Nuevo Pedido");
                Console.WriteLine("2. Ver Todos los Pedidos");
                Console.WriteLine("3. Ver Pedido por ID (con detalles)");
                Console.WriteLine("4. Ver Pedidos por Cliente");
                Console.WriteLine("5. Actualizar Estado de Pedido");
                Console.WriteLine("6. Eliminar Pedido");
                Console.WriteLine("7. Volver al Menú Principal");
                Console.WriteLine("===================================");
                int opcion = ValidacionNum.ObtenerInt("Seleccione una opción: ");

                switch (opcion)
                {
                    case 1:
                        pedidoController.NewPedido();
                        break;
                    case 2:
                        pedidoController.VerAllPedido();
                        break;
                    case 3:
                        pedidoController.VerPedidoById_Detalle();
                        break;
                    case 4:
                        pedidoController.VerPedidoByCliente();
                        break;
                    case 5:
                        pedidoController.UpdateStatusPedido();
                        break;
                    case 6:
                        pedidoController.DeletePedido();
                        break;
                    case 7:
                        loop = true;
                        Console.WriteLine("¡Gracias por usar la aplicación! Hasta luego.");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (!loop);
        }



    }
}
