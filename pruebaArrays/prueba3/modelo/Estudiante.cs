using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaArrays.prueba3.modelo
{
    public class Estudiante
    {
        public string nombre { get; set; }
        public double[] notas { get; set; }
        public double promedioGeneral { get; set; }

        public Estudiante(string nombre, double[] notas, double promedioGeneral) {
            this.nombre = nombre;
            this.notas = notas;
            this.promedioGeneral = promedioGeneral;
        }

    }
}
