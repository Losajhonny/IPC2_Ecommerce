using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio
{
    public class NCategoriaProducto
    {
        public static Boolean Insertar(int idComercio, int idProducto, int idCategoria)
        {
            DCategoriaProducto obj = new DCategoriaProducto();
            obj.IdCategoria = idCategoria;
            obj.IdProducto = idProducto;
            obj.IdComercio = idComercio;
            return obj.insertar(obj);
        }
    }
}