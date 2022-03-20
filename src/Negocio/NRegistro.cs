using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio
{
    public class NRegistro
    {
        public static Boolean insertar(string descripcion, int idEmpleado, int idSocio)
        {
            DRegistro obj = new DRegistro(descripcion, idEmpleado, idSocio);
            return obj.insertar(obj);
        }
    }
}