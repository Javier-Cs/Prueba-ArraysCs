using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaListas.Diccionario
{
    public class ConteoPalabra
    {
        public void mostrarpalabras() {
            Console.WriteLine("--- Ejercicio 2: Conteo de Palabras (Dictionary<TKey, TValue>) ---");
            string frase = "Este es un ejemplo de un conteo de palabras en este ejemplo";
            string[] palabras = frase.ToLower().Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> conteoPalabras = new Dictionary<string, int>();

            foreach (string palabra in palabras)
            {
                if (conteoPalabras.ContainsKey(palabra))
                {
                    conteoPalabras[palabra]++;
                }
                else
                {
                    conteoPalabras.Add(palabra, 1);
                }
            }

            Console.WriteLine($"Frase original: \"{frase}\"");
            Console.WriteLine("Frecuencia de palabras:");
            foreach (var par in conteoPalabras)
            {
                Console.WriteLine($"- {par.Key}: {par.Value}");
            }

            Console.WriteLine("-------------------------------------------------");
        }
    }
}
