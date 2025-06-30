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
                promedioGeneral = promedioGeneral + notas[j];
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
            throw new NotImplementedException();
        }

        public void mostrarTodasLasNotas()
        {
            throw new NotImplementedException();
        }
    }
}
