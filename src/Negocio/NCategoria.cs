using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datos;

namespace Negocio
{
    public class NCategoria
    {
        public static Boolean Insertar(string tipo, string nombre, int noCategoria)
        {
            DCategoria obj = new DCategoria(tipo, nombre, noCategoria);
            return obj.insertar(obj);
        }

        public static Boolean Insertar(int idProducto, int idCategoria, int idComercio)
        {
            DCategoriaProducto obj = new DCategoriaProducto(idProducto, idCategoria, idComercio);
            return obj.insertar(obj);
        }

        public static DCategoria Buscar(int noCategoria)
        {
            DCategoria obj = new DCategoria();
            obj.NoCategoria = noCategoria;
            return obj.buscar(obj);
        }

        public static DCategoria buscar(string nombre)
        {
            DCategoria obj = new DCategoria();
            obj.Nombre = nombre;
            return obj.buscarNombre(obj);
        }
    }
}