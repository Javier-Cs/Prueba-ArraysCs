using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnlineConsole.Entity
{
    public class PedidoEntity
    {
        public int idPedido { get; set; }
        public int id_Cliente { get; set; }
        public DateTime fechaPedido { get; set; }
        public string estadoPedido { get; set; }
        public decimal totalPedido { get; set; }

        public override string ToString()
        {
            return $"Pedido ID: {idPedido}, Cliente ID: {id_Cliente}, Fecha: {fechaPedido.ToShortDateString()}, Estado: {estadoPedido}, Total: {totalPedido:C}";
        }

        // en el presente caso no existe un campo para detalles del pedido se lo implementara en una lista
        public  List<DetallePedidoEntity> detalles { get; set; } = new List<DetallePedidoEntity>();

    }
}
