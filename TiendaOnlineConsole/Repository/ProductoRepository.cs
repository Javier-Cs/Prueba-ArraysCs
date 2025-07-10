using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaOnlineConsole.Entity;
using TiendaOnlineConsole.Service;

namespace TiendaOnlineConsole.Repository
{
    public class ProductoRepository : IServiceCrud<ProductoEntity>
    {
        public void Guardar(ProductoEntity entity)
        {
            throw new NotImplementedException();
        }


        public List<ProductoEntity> ObtenerTodo()
        {
            throw new NotImplementedException();
        }


        public ProductoEntity ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }


        public void Actualizar(ProductoEntity entity)
        {
            throw new NotImplementedException();
        }


        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void ActualizarstockProductos(int idProducto, int cantidad) {
            
        }

    }
}
