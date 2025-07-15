using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaOnlineConsole.Entity;
using TiendaOnlineConsole.Repository;
using TiendaOnlineConsole.Validation;

namespace TiendaOnlineConsole.Controller
{
    public class PedidoController
    {
        private readonly PedidoRepository pedidoRepository;
        private readonly ClienteRepository clienteRepository;
        private readonly ProductoRepository productoRepository;
        private readonly DetallePedidoRepository detallePedidoRepository;

        public PedidoController(PedidoRepository pedidoRepository, ClienteRepository clienteRepository, ProductoRepository productoRepository, DetallePedidoRepository detallePedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
            this.clienteRepository =  clienteRepository;
            this.productoRepository = productoRepository;
            this.detallePedidoRepository = detallePedidoRepository;
        }

        public PedidoController()
        {
        }

        internal void NewPedido()
        {
            Console.WriteLine("\n--- Realizar Nuevo Pedido ---");
            Console.WriteLine("--- Seleccionar Cliente ---");
            clienteRepository.ObtenerTodo().ForEach(c => Console.WriteLine(c));
            int clienteId = ValidacionNum.ObtenerInt("Ingrese el ID del cliente para el pedido: ");

            ClienteEntity cliente = clienteRepository.ObtenerPorId(clienteId);
            if (cliente ==null)
            {
                Console.WriteLine("Cliente no encontrado. No se puede crear el pedido.");
                return;
            }
            if (!cliente.activo)
            {
                Console.WriteLine("El cliente seleccionado no está activo. No se puede crear el pedido.");
                return;
            }

            List<DetallePedidoEntity> detallesdePedido = new List<DetallePedidoEntity>();
            decimal totalPedido = 0;
            bool agregarMasProductos = true;

            while (agregarMasProductos)
            {
                Console.WriteLine("\n--- Agregar Producto al Pedido ---");
                productoRepository.ObtenerTodo().ForEach(p => Console.WriteLine(p));
                int productoId = ValidacionNum.ObtenerInt("Ingrese el ID del producto a agregar (0 para terminar): ");

                if (productoId == 0)
                {
                    agregarMasProductos = false;
                    continue;
                }

                ProductoEntity producto = productoRepository.ObtenerPorId(productoId);
                if (producto == null)
                {
                    Console.WriteLine("Producto no encontrado.");
                    continue;
                }
                if (producto.stockProducto <= 0)
                {
                    Console.WriteLine($"El producto '{producto.nombreProducto}' está agotado.");
                    continue;
                }

                int cantidad = ValidacionNum.ObtenerInt($"Ingrese la cantidad para '{producto.nombreProducto}' (Stock disponible: {producto.stockProducto}): ");

                if (cantidad <= 0 || cantidad > producto.stockProducto)
                {
                    Console.WriteLine("Cantidad inválida o superior al stock disponible.");
                    continue;
                }


                // Verificar si el producto ya está en el pedido para actualizar la cantidad
                DetallePedidoEntity existingDetalle = detallesdePedido.FirstOrDefault(d => d.id_Producto == productoId);
                if (existingDetalle != null)
                {
                    if (existingDetalle.cantidad + cantidad > producto.stockProducto)
                    {
                        Console.WriteLine($"No se puede agregar más. Excede el stock disponible. Cantidad actual en pedido: {existingDetalle.cantidad}");
                        continue;
                    }
                    existingDetalle.cantidad += cantidad;
                    Console.WriteLine($"Cantidad de '{producto.nombreProducto}' actualizada en el pedido.");
                }
                else
                {
                    detallesdePedido.Add(new DetallePedidoEntity
                    {
                        id_Producto = productoId,
                        cantidad = cantidad,
                        precioUnitario = producto.precioProducto, // Tomar el precio actual del producto
                        nombreProducto = producto.nombreProducto, // Para mostrar en resumen
                        categoriaProducto = producto.categoriaProducto // Para mostrar en resumen
                    });
                    Console.WriteLine($"'{producto.nombreProducto}' agregado al pedido.");
                }

                totalPedido += (producto.precioProducto * cantidad);

                Console.WriteLine("¿Desea agregar otro producto? (s/n)");
                agregarMasProductos = ValidacionNum.obtenerBool("");
            }

            if (detallesdePedido.Count == 0)
            {
                Console.WriteLine("Pedido cancelado. No se agregaron productos.");
                return;
            }

            // 3. Crear el Pedido
            PedidoEntity nuevoPedido = new PedidoEntity
            {
                id_Cliente = clienteId,
                totalPedido = totalPedido,
                detalles = detallesdePedido
                // FechaPedido y Estado tienen valores por defecto en la DB
            };

            int pedidoId = pedidoRepository.insertar(nuevoPedido);
            if (pedidoId != -1)
            {
                Console.WriteLine($"\n--- Resumen del Pedido {pedidoId} ---");
                Console.WriteLine($"Cliente: {cliente.nombreCliente} {cliente.apellidoCliente}");
                Console.WriteLine($"Total: {totalPedido:C}");
                Console.WriteLine("Detalles:");
                foreach (var detalle in detallesdePedido)
                {
                    Console.WriteLine(detalle);
                }
            }
        }


        internal void DeletePedido()
        {
            Console.WriteLine("\n--- Eliminar Pedido ---");
            int pedidoId = ValidacionNum.ObtenerInt("Ingrese el ID del pedido a eliminar: ");
            pedidoRepository.Eliminar(pedidoId);
        }

        internal void UpdateStatusPedido()
        {
            Console.WriteLine("\n--- Actualizar Estado de Pedido ---");
            int pedidoId = ValidacionNum.ObtenerInt("Ingrese el ID del pedido a actualizar: ");
            PedidoEntity pedidoExistente = pedidoRepository.ObtenerPorId(pedidoId);

            if (pedidoExistente == null)
            {
                Console.WriteLine($"No se encontró el pedido con ID {pedidoId}.");
                return;
            }

            Console.WriteLine($"Pedido actual: {pedidoExistente}");
            Console.WriteLine("Estados disponibles: Pendiente, Procesando, Enviado, Entregado, Cancelado");
            Console.Write($"Nuevo estado (actual: {pedidoExistente.estadoPedido}): ");
            string nuevoEstado = Console.ReadLine();

            // Validar el estado si es necesario, o dejar que la DB lo maneje si hay restricciones
            pedidoRepository.ActualizarEstadoPedido(pedidoId, nuevoEstado);
        }

        internal void VerAllPedido()
        {
            Console.WriteLine("\n--- Lista de Pedidos ---");
            List<PedidoEntity> pedidos = pedidoRepository.ObtenerTodo();
            if (pedidos.Count == 0)
            {
                Console.WriteLine("No hay pedidos registrados.");
            }
            else
            {
                foreach (var pedido in pedidos)
                {
                    Console.WriteLine(pedido);
                }
            }
        }

        internal void VerPedidoByCliente()
        {
            Console.WriteLine("\n--- Ver Pedidos por Cliente ---");
            int clienteId = ValidacionNum.ObtenerInt("Ingrese el ID del cliente para ver sus pedidos: ");
            List<PedidoEntity> pedidos = pedidoRepository.ObtenerPedidoPorClienteId(clienteId);

            if (pedidos.Count == 0)
            {
                Console.WriteLine($"No hay pedidos para el cliente con ID {clienteId}.");
            }
            else
            {
                Console.WriteLine($"\n--- Pedidos del Cliente ID {clienteId} ---");
                foreach (var pedido in pedidos)
                {
                    Console.WriteLine(pedido);
                }
            }
        }

        internal void VerPedidoById_Detalle()
        {
            Console.WriteLine("\n--- Ver Pedido por ID ---");
            int pedidoId = ValidacionNum.ObtenerInt("Ingrese el ID del pedido a buscar: ");
            PedidoEntity pedido = pedidoRepository.ObtenerPorId(pedidoId);

            if (pedido != null)
            {
                Console.WriteLine($"\n{pedido}");
                Console.WriteLine("Detalles del Pedido:");
                if (pedido.detalles.Any())
                {
                    foreach (var detalle in pedido.detalles)
                    {
                        Console.WriteLine(detalle);
                    }
                }
                else
                {
                    Console.WriteLine("  No hay detalles para este pedido.");
                }
            }
            else
            {
                Console.WriteLine($"No se encontró el pedido con ID {pedidoId}.");
            }
        }
    }
}
