class Program
{
    static void Main(string[] args)
    {
        Pila<int> pilaDeEnteros = new Pila<int>();
        pilaDeEnteros.Push(10);
        pilaDeEnteros.Push(20);

        Console.WriteLine($"Elemento sacado: {pilaDeEnteros.Pop()}"); // 20
        Console.WriteLine($"Cantidad de elementos: {pilaDeEnteros.ContarElementos()}"); //

    }

}



public class Pila<T>
{
    private T[] elementos;
    private int contador;
    private const int CapacidadInicial = 10;

    public Pila() {
        elementos = new T[CapacidadInicial];
        contador = 0;
    }


    //______________________________-
    public void Push(T item) {
        if (contador < elementos.Length)
        {
            elementos[contador] = item;
            contador++;
        }
        else {
            Console.WriteLine("La pila está llena. No se puede agregar más.");
        }
    }


    //______________________________-
    public T Pop() {
        if (contador > 0)
        {
            contador--;
            return elementos[contador];
        }
        else {
            Console.WriteLine("La pila está vacía.");
            return default(T);
        }
    }


    //______________________________-
    public int ContarElementos() {
        return contador;
    }

}
