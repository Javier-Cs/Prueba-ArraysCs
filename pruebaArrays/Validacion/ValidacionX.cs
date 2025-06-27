using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaArrays.Validacion
{
    public static class ValidacionX
    {
        public static bool ValidarNumero(string n) {
            int validar = 0;
            return int.TryParse(n, out validar);
        }

        public static int Valor( string message,string valor) {

            return 7;
        }
    }
}
