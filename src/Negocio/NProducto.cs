using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datos;

namespace Negocio
{
    public class NProducto
    {
        public static Boolean Insertar(double precio, string nombre, string tipoProducto, string descripcion, string docMultimedia, string oferta)
        {
            DProducto obj = new DProducto(precio, nombre, tipoProducto, descripcion, docMultimedia, oferta);
            return obj.insertar(obj);
        }

        public static DProducto buscar(double precio, string nombreP, string tipoP, string desc, string docMul, string of)
        {
            DProducto obj = new DProducto();
            obj.Precio = precio;
            obj.Nombre = nombreP;
            obj.TipoProducto = tipoP;
            obj.Descripcion = desc;
            obj.DocMultimedia = docMul;
            obj.Oferta = of;
            return obj.buscar(obj);
        }

        public static DProducto buscarC(string nombre, string descripcion, string oferta, double precio)
        {
            DProducto obj = new DProducto();
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            obj.Oferta = oferta;
            obj.Precio = precio;
            return obj.buscarC(obj);
        }

        public static DProducto buscarT(double precio, string nombreP, string tipoP, string desc, string of)
        {
            DProducto obj = new DProducto();
            obj.Precio = precio;
            obj.Nombre = nombreP;
            obj.TipoProducto = tipoP;
            obj.Descripcion = desc;
            return obj.buscarT(obj);
        }

        public static DProducto buscarID(int idProducto)
        {
            DProducto obj = new DProducto();
            obj.IdProducto = idProducto;
            return obj.buscarID(obj);
        }

        public static Boolean update(DProducto obj)
        {
            return obj.actualizar(obj);
        }

        public static Boolean update(int idProducto, string nombre, string tipoP, string descripcion, string oferta, double precio, string docMultimedia)
        {
            DProducto obj = new DProducto();
            obj.IdProducto = idProducto;
            obj.Nombre = nombre;
            obj.TipoProducto = tipoP;
            obj.Descripcion = descripcion;
            obj.Oferta = oferta;
            obj.Precio = precio;
            obj.DocMultimedia = docMultimedia;
            return obj.actualizar2(obj);
        }

        public static DProducto buscarr(double precio, string nombre)
        {
            DProducto obj = new DProducto();
            obj.Precio = precio;
            obj.Nombre = nombre;
            return obj.buscarPN(obj);
        }
    }
}