using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio
{
    public class NInventario
    {
        public static Boolean insertar(string nombre, int idcomercio)
        {
            DInventario obj = new DInventario();
            obj.Nombre = nombre;
            obj.Comercio_idComercio = idcomercio;
            return obj.insertar(obj);
        }

        public static Boolean insertarD(int idInventario, int idProducto, int existencia)
        {
            DInventarioProducto obj = new DInventarioProducto();
            obj.IdInventario = idInventario;
            obj.IdProducto = idProducto;
            obj.Existencia = existencia;
            return obj.insertar(obj);
        }

        public static DInventario buscar(string nombre, int idcomercio)
        {
            DInventario obj = new DInventario();
            obj.Comercio_idComercio = idcomercio;
            obj.Nombre = nombre;
            return obj.buscar(obj);
        }
    }
}