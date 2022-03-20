using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datos;

namespace Negocio
{
    public class NZonaDis
    {
        public static Boolean insertar(string descripcion, string tipoZona, int noZonaSuperior, int noZona, int noZonaVecina, string nombre, int ZonaDis_idZona)
        {
            DZonasDis obj = new DZonasDis();
            obj.Descripcion = descripcion;
            obj.TipoZona = tipoZona;
            obj.NoZonaSuperior = noZonaSuperior;
            obj.NoZona = noZona;
            obj.NoZonaVecina = noZonaVecina;
            obj.Nombre = nombre;
            obj.ZonaDis_idZona = ZonaDis_idZona;
            return obj.insertarZona(obj);
        }
    }
}