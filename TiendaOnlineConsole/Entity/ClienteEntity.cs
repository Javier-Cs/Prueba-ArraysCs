using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TiendaOnlineConsole.Entity
{
    public class ClienteEntity
    {
        public int idCliente { get; set; }
        public string nombreCliente { get; set; }
        public string apellidoCliente { get; set; }
        public string emailCliente { get; set; }
        public DateTime fechaRegistroCliente { get; set; }
        public bool activo {  get; set; }

        public override string ToString()
        {
            return $"ID: {idCliente}, Nombre: {nombreCliente} {apellidoCliente}, Email: {emailCliente}, Registro: {fechaRegistroCliente.ToShortDateString()}, Activo: {activo}";
        }
    }
}
