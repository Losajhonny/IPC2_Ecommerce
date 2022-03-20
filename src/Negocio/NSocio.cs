using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datos;
using System.Data;

namespace Negocio
{
    public class NSocio
    {
        public static Boolean insertar(string password, string nombre, string telefono, string email, string noCuenta, int idcarrocompra)
        {
            DSocio obj = new DSocio(password, nombre, telefono, email, noCuenta, idcarrocompra);
            return obj.insertar(obj);
        }

        public static Boolean insertar(string password, string nombre, string telefono, string email, string noCuenta, int idcarrocompra, string direccion)
        {
            DSocio obj = new DSocio(password, nombre, telefono, email, noCuenta, idcarrocompra, direccion);
            return obj.insertar(obj);
        }

        public static Boolean buscar(string email, string password)
        {
            DSocio obj = new DSocio();
            obj.Email = email;
            obj.Password = password;
            return obj.encontrar(obj);
        }
    }
}