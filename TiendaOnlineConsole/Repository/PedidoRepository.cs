using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaOnlineConsole.Entity;
using TiendaOnlineConsole.Service;

namespace TiendaOnlineConsole.Repository
{
    public class PedidoRepository : IServiceCrud<PedidoEntity>
    {
        public void Guardar(PedidoEntity entity)
        {
            throw new NotImplementedException();
        }


        public List<PedidoEntity> ObtenerTodo()
        {
            throw new NotImplementedException();
        }


        public PedidoEntity ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }


        public void Actualizar(PedidoEntity entity)
        {
            throw new NotImplementedException();
        }


        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }


        public List<PedidoEntity> ObtenerPedidoPorClienteId(int id) {
            return null;
        }

        public void ActualizarEstadoPedido(int pedidoId, string nuevoEstado) { 
        
        }

    }
}
