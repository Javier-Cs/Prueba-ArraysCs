using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnlineConsole.Service
{
    // Introducimos <TEntity>, donde TEntity es un parámetro de tipo.
    // Esto significa que cuando implementes esta interfaz, especificarás el tipo concreto
    // (por ejemplo, PersonaEntity, ProductoEntity, etc.) que TEntity representará.
    public interface IServiceCrud<TEntity> where TEntity : class
    {
        void Guardar(TEntity entity);
        List<TEntity> ObtenerTodo();
        TEntity ObtenerPorId(int id);
        void Actualizar(TEntity entity);
        void Eliminar(int id);
    }
}
