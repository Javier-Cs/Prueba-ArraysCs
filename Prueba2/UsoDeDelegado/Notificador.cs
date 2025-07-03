using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2.UsoDeDelegado
{

    public class Notificador
    {
        public void ProcesarMensaje(string mensaje);

        public void enviarPorConsola(string consola) {
            Console.WriteLine($"Consola: {consola}");
        }

        public void enviarPorLog(string texto) {
            Console.WriteLine($"Log: {DateTime.Now} - {texto}");
        }

        public void Reportar(ProcesarMensaje manejador, string mensaje) { 
            manejador( mensaje);
        }

    }
}
