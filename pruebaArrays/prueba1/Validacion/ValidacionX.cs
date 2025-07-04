﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaArrays.prueba1.Validacion
{
    public class ValidacionX
    {
        public bool ValidarNumero(string n) {
            int validar = 0;
            return int.TryParse(n, out validar);
        }




        public int SolicitarNumero( string message) {
            string valor;

            bool n = false;
            do {
                Console.Write(message);
                valor = Console.ReadLine();

                if (!ValidarNumero(valor))
                {
                    Console.WriteLine("El valor ingresado es invalido...");
                    n = false;
                }
                else {
                    n = true;                 
                }
            } while (!n);
            return Convert.ToInt32(valor);
        }
    }
}
