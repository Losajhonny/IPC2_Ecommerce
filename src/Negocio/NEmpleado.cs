using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datos;
using System.Data;

namespace Negocio
{
    public class NEmpleado
    {
        //metodo insertar
        public static Boolean Insertar(string puesto, string nombre, string telefono
            , int comercio_idcomercio, string email, string password)
        {
            DEmpleado obj = new DEmpleado(puesto, nombre, telefono, comercio_idcomercio, email, password);
            return obj.insertar(obj);
        }

        public static Boolean buscar(string email, string password)
        {
            DEmpleado obj = new DEmpleado();
            obj.Email = email;
            obj.Password = password;
            return obj.encontrar(obj);
        }

        public static Boolean update(int idcomercio, int idEmpleado, string email)
        {
            DEmpleado obj = new DEmpleado();
            obj.IdEmpleado = idEmpleado;
            obj.Comercio_idcomercio = idcomercio;
            obj.Email = email;
            return obj.actualizar(obj);
        }

        public static Boolean update(int idcomercio, int idEmpleado, string nombre, string telefono, string email, string password)
        {
            DEmpleado obj = new DEmpleado();
            obj.IdEmpleado = idEmpleado;
            obj.Comercio_idcomercio = idcomercio;
            obj.Nombre = nombre;
            obj.Telefono = telefono;
            obj.Email = email;
            obj.Password = password;
            return obj.actualizar2(obj);
        }

        public static DEmpleado buscarE(string email, string password)
        {
            DEmpleado obj = new DEmpleado();
            obj.Email = email;
            obj.Password = password;
            return obj.buscar(obj);
        }

        public static DEmpleado buscarID(int idcomercio, int idEmpleado)
        {
            DEmpleado obj = new DEmpleado();
            obj.IdEmpleado = idEmpleado;
            obj.Comercio_idcomercio = idcomercio;
            return obj.buscarID(obj);
        }

        public static Boolean habilitado(string email, string password)
        {
            DEmpleado obj = new DEmpleado();
            obj.Email = email;
            obj.Password = password;
            DEmpleado temp = obj.buscar(obj);
            return DComercio.isAutorizado(temp.Comercio_idcomercio);
        }
    }
}