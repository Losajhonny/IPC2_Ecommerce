using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Datos
{
    public class DCarroCompra
    {
        private int idCarro;
        private string nombre;

        public DCarroCompra()
        {

        }

        public DCarroCompra(string nombre)
        {
            this.nombre = nombre;
        }

        public Boolean insertar(DCarroCompra carro)
        {
            SqlConnection sqlconection = new SqlConnection();
            Boolean correcto = false;
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("insert into CarroCompra(nombre)" +
                    "values(@nombre)", sqlconection);
                comando.Parameters.AddWithValue("@nombre", carro.Nombre);

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

        public DCarroCompra encontrar(DCarroCompra carro)
        {
            SqlConnection sqlconection = new SqlConnection();
            DCarroCompra temp = new DCarroCompra();
            try
            {   //seguir con encontrar
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                string consulta = "select * from CarroCompra where nombre = '" + carro.Nombre + "';";
                SqlCommand comando = new SqlCommand(consulta, sqlconection);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    temp.IdCarro = reader.GetInt32(0);
                    temp.Nombre = reader.GetString(1);
                    Conexion.cerrarConexion(sqlconection);
                    reader.Close();
                    return temp;
                }

            }
            catch (Exception ex)
            {

            }
            Conexion.cerrarConexion(sqlconection);
            return null;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public int IdCarro
        {
            get { return idCarro; }
            set { idCarro = value; }
        }
    }
}