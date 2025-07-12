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
    public class ClienteController
    {
        private readonly ClienteRepository clienteRepository = new ClienteRepository();

        internal void SaveCliente()
        {
            Console.WriteLine("\n--- Crear Nuevo Cliente ---");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();

            ClienteEntity nuevoCliente = new ClienteEntity { 
                nombreCliente = nombre,
                apellidoCliente = apellido,
                emailCliente = email

            };
            clienteRepository.Guardar(nuevoCliente);
        }

        internal void VerAllClientes()
        {
            Console.WriteLine("\n--- Lista de Clientes ---");
            List<ClienteEntity> listaClientes = clienteRepository.ObtenerTodo();
            if (listaClientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados.");
            }
            else
            {
                foreach (var cliente in listaClientes)
                {
                    Console.WriteLine(cliente);
                }
            }
        }

        internal void VerClienteById()
        {
            int id = ValidacionNum.ObtenerInt("Ingrese el ID del cliente a buscar: ");
            ClienteEntity cliente = clienteRepository.ObtenerPorId(id);
            if (cliente != null)
            {
                Console.WriteLine($"\nCliente encontrado: {cliente}");
            }
            else
            {
                Console.WriteLine($"No se encontró ningún cliente con el ID {id}.");
            }
        }

        internal void UpdateCliente()
        {
            Console.WriteLine("\n--- Actualizar Cliente ---");
            int id = ValidacionNum.ObtenerInt("Ingrese el ID del cliente a actualizar: ");
            ClienteEntity clienteExistente = clienteRepository.ObtenerPorId(id);

            if (clienteExistente == null)
            {
                Console.WriteLine($"No se encontró ningún cliente con el ID {id}.");
                return;
            }
            Console.WriteLine($"\nCliente actual: {clienteExistente}");
            Console.Write($"Nuevo nombre (actual: {clienteExistente.nombreCliente}, dejar en blanco para no cambiar): ");
            string nuevoNombre = Console.ReadLine();
            Console.Write($"Nuevo apellido (actual: {clienteExistente.apellidoCliente}, dejar en blanco para no cambiar): ");
            string nuevoApellido = Console.ReadLine();
            Console.Write($"Nuevo email (actual: {clienteExistente.emailCliente}, dejar en blanco para no cambiar): ");
            string nuevoEmail = Console.ReadLine();

            bool nuevoActivo = ValidacionNum.obtenerBool($"¿Está activo el cliente? (actual: {clienteExistente.activo}), puedes escojer true o false");

            clienteExistente.nombreCliente = string.IsNullOrWhiteSpace(nuevoNombre)? clienteExistente.nombreCliente : nuevoNombre;
            clienteExistente.apellidoCliente = string.IsNullOrWhiteSpace(nuevoApellido)? clienteExistente.apellidoCliente : nuevoApellido;
            clienteExistente.emailCliente = string.IsNullOrWhiteSpace(nuevoEmail)? clienteExistente.emailCliente : nuevoEmail;
            clienteExistente.activo = nuevoActivo;

            clienteRepository.Actualizar(clienteExistente);
        }



        internal void DeleteCliente()
        {
            Console.WriteLine("\n--- Eliminar Cliente ---");
            int id = ValidacionNum.ObtenerInt("Ingrese el ID del cliente a eliminar: ");
            clienteRepository.Eliminar(id);
        }
    }
}
