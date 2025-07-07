using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConhashSet.Clases
{
    public class UsoHashSet
    {
        public void mostrar() {
            Console.WriteLine("Ejercicio 1 de prueba de usuarios");

            // creacion de HashSet de strings
            HashSet<string> usuariosConectados = new HashSet<string>();

            Console.WriteLine($"añadiendo 'usuario 1': {usuariosConectados.Add("user1")}");
            Console.WriteLine($"añadiendo 'usuario 2': {usuariosConectados.Add("user2")}");
            Console.WriteLine($"añadiendo 'usuario 3': {usuariosConectados.Add("user3")}");

            Console.WriteLine($"añadiendo 'usuario 1': {usuariosConectados.Add("user1")}");




            Console.WriteLine("\nUsuarios conectados" );
            foreach (var item in usuariosConectados)
            {
                Console.WriteLine($"item");
            }

            Console.WriteLine($"Número total de usuarios únicos: {usuariosConectados.Count}");

            // Comprobar si un usuario está conectado
            string usuarioChecar = "user2";
            Console.WriteLine($"\n¿'user2' está conectado? {usuariosConectados.Contains(usuarioChecar)}");
            usuarioChecar = "user3";
            Console.WriteLine($"¿'user3' está conectado? {usuariosConectados.Contains(usuarioChecar)}");
        }
    }
}
