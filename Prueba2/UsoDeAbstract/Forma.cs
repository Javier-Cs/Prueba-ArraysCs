using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Prueba2.UsoDeAbstract
{
    public abstract class Forma
    {
        string nombre { get; set; }

        public Forma(string nombre) {
            this.nombre = nombre;
            this.nombre = nombre;
        }

        // Método no abstracto (con implementación)
        public string ObtenerNombre()
        {
            return $"Soy una forma: {nombre}";
        }

        // Método abstracto: No tiene implementación aquí.
        // Cualquier clase que herede de Forma DEBE implementar CalcularArea().
        public abstract double calcularAres();

        // También puede haber propiedades abstractas
        public abstract int numeroDeLados {get;}


    }
}
