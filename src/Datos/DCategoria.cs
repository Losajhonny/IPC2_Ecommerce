using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Datos
{
    public class DCategoria
    {
        private int idCategoria;
        private string tipo;
        private string nombre;
        private int noCategoria;

        public DCategoria()
        {

        }

        public DCategoria(string tipo, string nombre, int noCategoria)
        {
            this.tipo = tipo;
            this.nombre = nombre;
            this.noCategoria = noCategoria;
        }

        public Boolean insertar(DCategoria categoria)
        {
            SqlConnection sqlconection = new SqlConnection();
            Boolean correcto = false;
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("insert into Categoria(tipo, nombre, noCategoria)" +
                    "values(@tipo, @nombre, @noCategoria)", sqlconection);
                comando.Parameters.AddWithValue("@tipo", categoria.Tipo);
                comando.Parameters.AddWithValue("@nombre", categoria.Nombre);
                comando.Parameters.AddWithValue("@noCategoria", NoCategoria);

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

        public DCategoria buscar(DCategoria cate)
        {
            SqlConnection sqlconection = new SqlConnection();
            DCategoria temp = new DCategoria();
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("select * from Categoria where noCategoria = '" + cate.NoCategoria + "';", sqlconection);

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    temp.IdCategoria = reader.GetInt32(0);
                    temp.Tipo = reader.GetString(1);
                    temp.Nombre = reader.GetString(2);
                    temp.noCategoria = reader.GetInt32(3);

                    Conexion.cerrarConexion(sqlconection);
                    reader.Close();
                    return temp;
                }

            }
            catch (Exception e)
            {

            }
            Conexion.cerrarConexion(sqlconection);
            return null;
        }

        public DCategoria buscarNombre(DCategoria cate)
        {
            SqlConnection sqlconection = new SqlConnection();
            DCategoria temp = new DCategoria();
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("select * from Categoria where nombre = '" + cate.Nombre + "';", sqlconection);

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    temp.IdCategoria = reader.GetInt32(0);
                    temp.Tipo = reader.GetString(1);
                    temp.Nombre = reader.GetString(2);
                    temp.noCategoria = reader.GetInt32(3);

                    Conexion.cerrarConexion(sqlconection);
                    reader.Close();
                    return temp;
                }

            }
            catch (Exception e)
            {

            }
            Conexion.cerrarConexion(sqlconection);
            return null;
        }

        public int NoCategoria
        {
            get { return noCategoria; }
            set { noCategoria = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public int IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }
    }
}