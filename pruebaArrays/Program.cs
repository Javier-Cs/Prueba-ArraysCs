namespace pruebaArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // formas de llenar un array
            int[] numeros = new int[5];
            numeros[0] = 21;
            numeros[1] = 25;
            numeros[2] = 30;
            Console.WriteLine(numeros[1]);


            string[] nombres = ["Juana", "Ana", "Martha", "karla", "Luisa"];
            Console.WriteLine(nombres.Length);

            Array.Sort(nombres);

            Console.WriteLine($"array ordenado: {string.Join(",", nombres)}");
            Array.Reverse(numeros);
            Console.WriteLine($"array alrrevés: {string.Join(",", numeros)}");



            Console.WriteLine("Escribe un nombre: ");
            string nombre = Console.ReadLine();
            if (nombres.Contains(nombre))
            {
                int inex = Array.IndexOf(nombres, nombre);
                Console.WriteLine($"el indice de {nombre} es: {inex}");
            }
            else {
                Console.WriteLine($"el nombre:{nombre} no existe");
            }


                Console.WriteLine();



            


            Console.ReadKey();
        }
        
    }
}
