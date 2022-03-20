using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Datos
{
    public class Conexion
    {
        public static SqlConnection conect()
        {
            return new SqlConnection("Data Source=USUARIO-PC\\SQLEXPRESS;Initial Catalog=proyecto;Integrated Security=True");
        }

        public static void abrirConexion(SqlConnection conexion)
        {
            if (conexion.State == System.Data.ConnectionState.Broken || conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();

            }
        }

        public static void cerrarConexion(SqlConnection conexion)
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}