using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaOnlineConsole.Entity;

namespace TiendaOnlineConsole.Service
{
    public interface DetallePedidoService
    {
        void InsertarDetallePedido(DetallePedidoEntity detalle);
        List<DetallePedidoEntity> ObtenerDetallesPorPedidoId(int pedidoId);
    }
}
