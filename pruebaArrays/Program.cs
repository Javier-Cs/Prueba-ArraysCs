class Program
{
    static void Main(string[] args)
    {
        IRepositorio<Productos> repoProductos = new RepositorioProductos();
        repoProductos.agregar(new Productos { idProducto = 1, Nombre = "Laptop", Precio = 1200 });
        repoProductos.agregar(new Productos { idProducto = 2, Nombre = "Raton", Precio = 25 });

        Productos laptop = repoProductos.obtenerPorId(1);

        if (laptop != null)
        {
            Console.WriteLine($"Producto encontrado: {laptop.Nombre}");
        }
        Console.ReadLine();
    }
}


public class Productos {
    public int idProducto { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
}

public interface IRepositorio<T>{
    void agregar(T cantidad);
    T obtenerPorId(int id);
    IEnumerable<T> obtenerTodos();
    void actualizar(T entidad);
    void eliminar(T entidad);
}

public class RepositorioProductos : IRepositorio<Productos> { 
    private List<Productos> listaProductos = new List<Productos>();

    public void actualizar(Productos entidad)
    {
        throw new NotImplementedException();
    }

    public void agregar(Productos producto)
    {
        listaProductos.Add(producto);
        Console.WriteLine($"Producto agregado: {producto.Nombre}");

    }

    public void eliminar(Productos entidad)
    {
        throw new NotImplementedException();
    }

    public Productos obtenerPorId(int id)
    {
        return listaProductos.FirstOrDefault(p => p.idProducto == id);
    }

    public IEnumerable<Productos> obtenerTodos()
    {
        return listaProductos;
    }
}


//Pila<int> pilaDeEnteros = new Pila<int>();
//pilaDeEnteros.Push(10);
//pilaDeEnteros.Push(20);

//Console.WriteLine($"Elemento sacado: {pilaDeEnteros.Pop()}"); // 20
//Console.WriteLine($"Cantidad de elementos: {pilaDeEnteros.ContarElementos()}"); //


//Pila<string> pilaCadenas = new Pila<string>();
//pilaCadenas.Push("hola");
//pilaCadenas.Push("Que");
//Console.WriteLine($"Elemento sacado: {pilaCadenas.Pop()}"); // Mundo
//Console.WriteLine($"Elemento sacado: {pilaCadenas.Pop()}"); // Hola
//Console.WriteLine($"Cantidad de elementos: {pilaCadenas.ContarElementos()}");


//int x = 5;
//int y = 10;

//Console.WriteLine($"Antes del intercambio: x = {x}, y ={y}");
//Utilidades.Intercambiar<int>(ref x, ref y);
//Console.WriteLine($"despues del intercambio: x = {x}, y ={y}");

//string h = "hola";
//string g = "bien";
//Console.WriteLine($"Antes del intercambio: h = {h}, g ={g}");
//Utilidades.Intercambiar<string>(ref h, ref g);
//Console.WriteLine($"despues del intercambio: h = {h}, g ={g}");

//public class Utilidades { 
//    public static void Intercambiar<T>(ref T a, ref T b)
//    {
//        T temp = a;
//        a = b;
//        b = temp;
//        Console.WriteLine($"Intercambio: a ={a}, b ={b}");
//    }
//}



//public class Pila<T>
//{
//    private T[] elementos;
//    private int contador;
//    private const int CapacidadInicial = 10;

//    public Pila() {
//        elementos = new T[CapacidadInicial];
//        contador = 0;
//    }


//    //______________________________-
//    public void Push(T item) {
//        if (contador < elementos.Length)
//        {
//            elementos[contador] = item;
//            contador++;
//        }
//        else {
//            Console.WriteLine("La pila está llena. No se puede agregar más.");
//        }
//    }


//    //______________________________-
//    public T Pop() {
//        if (contador > 0)
//        {
//            contador--;
//            return elementos[contador];
//        }
//        else {
//            Console.WriteLine("La pila está vacía.");
//            return default(T);
//        }
//    }


//    //______________________________-
//    public int ContarElementos() {
//        return contador;
//    }

//}
