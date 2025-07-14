using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaOnlineConsole.Entity;
using TiendaOnlineConsole.Service;

namespace TiendaOnlineConsole.Repository
{
    public class DetallePedidoRepository
    {
        private readonly string conectar = "Data Source=JAVIERCS;Initial Catalog=Tiendaonline_DB; User ID=sa; Password=21427711; TrustServerCertificate=True;";
        private readonly PedidoRepository pedidoRepository;

        public DetallePedidoRepository(PedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }

        public void InsertarDetallePedido(DetallePedidoEntity detalle) { }
        public List<DetallePedidoEntity> ObtenerDetallesPorPedidoId(int pedidoId) {
            return null;
        }
    }
}
