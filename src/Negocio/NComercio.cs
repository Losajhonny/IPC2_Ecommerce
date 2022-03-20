using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datos;
using System.Data;

namespace Negocio
{
    public class NComercio
    {
        /**
         * 1 verdadero... 0 false
         * **/
        public static Boolean Insertar(string nombre, string siglas, string direccion,
            string email, string telefono, int autorizacion, string tipoProducto, string fax)
        {
            DComercio obj = new DComercio(nombre, siglas, direccion, email, telefono, autorizacion, tipoProducto, fax);
            return obj.insertar(obj);
        }

        public static DComercio buscar(string nombre, string siglas, string direccion,
            string email, string telefono, int autorizacion, string tipoProducto, string fax)
        {
            DComercio obj = new DComercio();
            obj.Nombre = nombre;
            obj.Siglas = siglas;
            obj.Direccion = direccion;
            obj.Email = email;
            obj.Telefono = telefono;
            obj.Autorizacion = autorizacion;
            obj.TipoProducto = tipoProducto;
            obj.Fax = fax;
            return obj.encontrar(obj);
        }

        public static DComercio buscar(string nombre, string siglas, string direccion,
            string email, string telefono, string tipoProducto, string fax)
        {
            DComercio obj = new DComercio();
            obj.Nombre = nombre;
            obj.Siglas = siglas;
            obj.Direccion = direccion;
            obj.Email = email;
            obj.Telefono = telefono;
            obj.TipoProducto = tipoProducto;
            obj.Fax = fax;
            return obj.encontrar(obj);
        }

        public static DComercio buscar(int idComercio)
        {
            DComercio obj = new DComercio();
            obj.IdComercio = idComercio;
            return obj.buscarID(obj);
        }

        public static DComercio buscarS(string siglas)
        {
            DComercio obj = new DComercio();
            obj.Siglas = siglas;
            return obj.encontrarS(obj);
        }

        public static Boolean actualizar(DComercio obj)
        {
            return obj.actualizar(obj);
        }

        public static Boolean update(int idcomercio, string direccion, string email, string telefono, string fax)
        {
            DComercio obj = new DComercio();
            obj.IdComercio = idcomercio;
            obj.Direccion = direccion;
            obj.Email = email;
            obj.Telefono = telefono;
            obj.Fax = fax;
            return obj.actualizar2(obj);
        }

        public static DataSet actList()
        {
            DComercio obj = new DComercio();
            return obj.loadData();
        }
    }
}