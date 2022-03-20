using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Datos
{
    public class DInventario
    {
        private int idInventario;
        private string nombre;
        private int comercio_idComercio;

        public DInventario()
        {

        }

        public DInventario(string nombre, int idcomercio)
        {
            this.nombre = nombre;
            this.comercio_idComercio = idcomercio;
        }

        public Boolean insertar(DInventario inv)
        {
            SqlConnection sqlconection = new SqlConnection();
            Boolean correcto = false;
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("insert into Inventario(nombre, Comercio_idComercio)"
                    + "values(@nombre, @Comercio_idcomercio)", sqlconection);
                comando.Parameters.AddWithValue("@nombre", inv.Nombre);
                comando.Parameters.AddWithValue("@Comercio_idcomercio", inv.Comercio_idComercio);

                int rows = comando.ExecuteNonQuery();
                if (rows == 1)
                {
                    correcto = true;
                }
            }
            catch (Exception e)
            {

            }
            Conexion.cerrarConexion(sqlconection);
            return correcto;
        }

        public DInventario buscar(DInventario inv)
        {
            SqlConnection sqlconection = new SqlConnection();
            DInventario temp = new DInventario();
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("select * from Inventario where nombre = '" + inv.Nombre
                    + "' and Comercio_idComercio = " + inv.Comercio_idComercio + ";", sqlconection);

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    temp.IdInventario = reader.GetInt32(0);
                    temp.Nombre = reader.GetString(1);
                    temp.Comercio_idComercio = reader.GetInt32(2);
                }
                else
                {
                    temp = null;
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            Conexion.cerrarConexion(sqlconection);
            return temp;
        }

        public int Comercio_idComercio
        {
            get { return comercio_idComercio; }
            set { comercio_idComercio = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int IdInventario
        {
            get { return idInventario; }
            set { idInventario = value; }
        }
    }
}