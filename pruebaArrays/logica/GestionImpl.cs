using pruebaArrays.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaArrays.logica
{
    public class GestionImpl : Gestion
    {
        int numeroPr = 0;
        public GestionImpl()
        {
        }
        public GestionImpl(int numeroPr) {
            this.numeroPr = numeroPr;
        }
        


        //Producto[] inventario = Producto[];

        public Producto[] obtenerAll(int n)
        {
            Producto[] productos = new Producto[n];

            return productos;

        }
        public void eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Producto obtenerById(int id)
        {
            throw new NotImplementedException();
        }

        public void save(Producto producto)
        {
            throw new NotImplementedException();
        }
    }
}
