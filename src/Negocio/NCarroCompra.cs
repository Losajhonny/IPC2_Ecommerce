using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datos;
using System.Data;

namespace Negocio
{
    public class NCarroCompra
    {
        public static Boolean insertar(string nombre)
        {
            DCarroCompra obj = new DCarroCompra(nombre);
            return obj.insertar(obj);
        }
        public static DCarroCompra buscar(string nombre)
        {
            DCarroCompra obj = new DCarroCompra();
            obj.Nombre = nombre;
            return obj.encontrar(obj);
        }

        public static Boolean insertar(int idCarro, int idProducto)
        {
            DCarroProducto obj = new DCarroProducto();
            obj.IdCarro = idCarro;
            obj.IdProducto = idProducto;
            return obj.insertar(obj);
        }

        public static DCarroProducto buscarR(int idCarro, int idProducto)
        {
            DCarroProducto obj = new DCarroProducto();
            obj.IdCarro = idCarro;
            obj.IdProducto = idProducto;
            return obj.buscarR(obj);
        }

        public static DCarroProducto buscar(int idCarro, int idProducto)
        {
            DCarroProducto obj = new DCarroProducto();
            obj.IdCarro = idCarro;
            obj.IdProducto = idProducto;
            return obj.buscarR(obj);
        }

        public static Boolean updateMC(int idCarro, int idProducto, int cantidad)
        {
            DCarroProducto obj = new DCarroProducto();
            obj.IdProducto = idProducto;
            obj.IdCarro = idCarro;
            obj.Cantidad = cantidad;
            return obj.updateCantidadMas(obj);
        }

        public static Boolean updateC(int idCarro, int idProducto, int cantidad)
        {
            DCarroProducto obj = new DCarroProducto();
            obj.IdCarro = idCarro;
            obj.IdProducto = idProducto;
            obj.Cantidad = cantidad;
            return obj.updateCantidad(obj);
        }

        public static Boolean deleteDetalle(int idCarro, int idProducto)
        {
            DCarroProducto obj = new DCarroProducto();
            obj.IdProducto = idProducto;
            obj.IdCarro = idCarro;
            return obj.deleteI(obj);
        }
    }
}