using pruebaArrays.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaArrays.logica
{
    interface Gestion
    {
        Producto[] obtenerAll(int n);
        Producto obtenerById(int id);
        
        void save(Producto producto);
        public void eliminar(int id);
    }
}
