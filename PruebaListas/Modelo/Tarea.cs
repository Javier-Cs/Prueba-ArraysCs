using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PruebaListas.Modelo
{
    public class Tarea
    {
        public int id { get; set; }
        string materia { get; set; }

        double calificacion {  get; set; }

        public Tarea(int id, string materia, double calificacion)
        {
            this.id = id;
            this.materia = materia;
            this.calificacion = calificacion;
        }

        public Tarea()
        {
        }

        public override string ToString()
        {
            return $"ID: {id}, Nombre: {materia}, Calificación: {calificacion}";
        }



    }
}
