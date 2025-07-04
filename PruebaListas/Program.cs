using PruebaListas.Modelo;

namespace PruebaListas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.guardar();
            menu.mostrar();
            Console.WriteLine("---");
            menu.eliminarTarea(2);
            Console.WriteLine("---");
            menu.mostrar();



            


        }
    }

    public class Menu {
        
        List<Tarea> tareas = new List<Tarea>();
        
       
        

        public void guardar() { 
            tareas.Add(new Tarea(1, "matematicas", 7.80));
            tareas.Add(new Tarea(2, "ciencias", 7.20));
            tareas.Add(new Tarea(3, "historia", 8.70));
            tareas.Add(new Tarea(4, "quimica", 4.88));
            tareas.Add(new Tarea(5, "lenguaje", 7.40));


        }


        public void mostrar()
        {

            Console.WriteLine("--- Ejercicio 1: Gestión de Tareas (List<T>) ---");
            Console.WriteLine("Tareas iniciales:");
            tareas.ForEach(tarea => Console.WriteLine(tarea.ToString()));

        }



        public void eliminarTarea(int id) {

            Tarea tareaAEliminar = tareas.FirstOrDefault(t => t.id == id);

            if (tareaAEliminar != null)
            {
                tareas.Remove(tareaAEliminar);
                Console.WriteLine($"\nTarea '{id}' eliminada.");
            }
            else
            {
                Console.WriteLine($"\nTarea '{id}' no encontrada.");
            }
        }
        

    }
}
