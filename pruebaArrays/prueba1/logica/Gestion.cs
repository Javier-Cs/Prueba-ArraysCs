using pruebaArrays.prueba1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaArrays.prueba1.logica
{
    interface Gestion
    {
        Producto[] obtenerAll();
        Producto obtenerById(int id);
        
        Producto save(Producto producto);
        public void eliminar(int id);
    }
}
