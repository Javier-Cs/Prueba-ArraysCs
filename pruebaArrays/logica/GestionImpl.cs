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
        private Producto[] listaProductos;
        private int contador;


        public GestionImpl()
        {
        }
        public GestionImpl(int numeroPr) {
            listaProductos = new Producto[numeroPr];
            contador = 0;
        }


        //Producto[] inventario = Producto[];


        //---------------------------------
        public Producto[] obtenerAll()
        {
            Producto[] productoss = new Producto[contador];
            for (int i = 0; i < contador; i++)
            {
                productoss[i] = listaProductos[i];
            }
            return productoss;
        }


        //---------------------------------
        public void eliminar(int id)
        {
            for (int i = 0; i < contador; i++)
            {
                if (listaProductos[i] != null && listaProductos[i].idProducto == id)
                {
                    for (int j = 0; j < contador - 1; j++)
                    {
                        listaProductos[j] = listaProductos[j + 1];
                    }
                    listaProductos[contador - 1] = null;
                    contador--;
                    break;
                }
            }
        }


        //---------------------------------
        public Producto obtenerById(int id)
        {
            for (int i = 0; i < contador; i++)
            {
                if (listaProductos[i] != null && listaProductos[i].idProducto == id)
                {
                    return listaProductos[i];
                }
            }
            return null;
        }


        //---------------------------------
        public Producto save(Producto producto)
        {
            for (int i = 0; i < contador; i++)
            {
                if (listaProductos[i] != null && listaProductos[i].idProducto == producto.idProducto) {
                    listaProductos[i] = producto;
                    return producto;
                }
            }
            listaProductos[contador] = producto;
            contador++;
            return producto;

        }
    }
}
