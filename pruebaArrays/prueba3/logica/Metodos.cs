using pruebaArrays.prueba3.modelo;
using pruebaArrays.prueba3.validacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaArrays.prueba3.logica
{
    public class Metodos
    {
        Validacion valid;
        List<Estudiante> estudiantes;
        double promedioGeneral = 0;
        double[] notas = new double[3];

        List<Double> notasFinales = new List<Double>();

        public Metodos()
        {
            estudiantes = new List<Estudiante>();
            this.valid = new Validacion();
        }

        public void guardarEstudiante()
        {

            Console.Write("Escribe tu nombre: ");
            string nombre = Console.ReadLine();

            for (int i = 0; i < notas.Length; i++)
            {
                notas[i] = valid.optenerDouble("Ingrese la nota: ");
            }

            for (int j = 0; j < notas.Length; j++)
            {
                promedioGeneral = notas[j] + promedioGeneral;
            }            

            Estudiante estudi = new Estudiante(nombre, notas, promedioGeneral);
            

            if (estudi != null)
            {
                estudiantes.Add(estudi);
                Console.WriteLine("Guardado exitoso;");
            }
            else {
                Console.WriteLine("esta mal el estudiante..");
            }
            
            
        }

        public void mostrar2Notas()
        {
            if (estudiantes.Count == 0) {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            double notaMayor = double.MinValue;
            double notaMenor = double.MaxValue;
            string alumnoMayor = "";
            string alumnoMenor = "";

            foreach (var estudiante in estudiantes)
            {
                foreach (var nota in estudiante.notas)
                {
                    if (nota > notaMayor)
                    {
                        notaMayor = nota;
                        alumnoMayor = estudiante.nombre;
                    }

                    if (nota < notaMenor)
                    {
                        notaMenor = nota;
                        alumnoMenor = estudiante.nombre;
                    }
                }
            }

            Console.WriteLine($"\nLa nota mayor es {notaMayor} y pertenece a {alumnoMayor}");
            Console.WriteLine($"La nota menor es {notaMenor} y pertenece a {alumnoMenor}\n");


        }

        public void mostrarTodasLasNotas()
        {
            double sumatota = 0;
            foreach (var item in estudiantes)
            {
                Console.WriteLine(item.nombre);
                for (int i = 0; i < item.notas.Length; i++)
                {
                    sumatota = (sumatota + item.notas[i])/3;

                }
                Console.WriteLine(sumatota);
            }
        }
    }
}
