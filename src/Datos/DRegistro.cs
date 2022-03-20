using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Datos
{
    public class DRegistro
    {
        private int idRegistro;
        private string descripcion;
        private int idEmpleado;

        public int IdEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }
        private int idSocio;

        public int IdSocio
        {
            get { return idSocio; }
            set { idSocio = value; }
        }

        public DRegistro()
        {

        }

        public DRegistro(string descripcion, int idEmpleado, int idSocio)
        {
            this.descripcion = descripcion;
            this.idEmpleado = idEmpleado;
            this.idSocio = idSocio;
        }

        public Boolean insertar(DRegistro registro)
        {
            SqlConnection sqlconection = new SqlConnection();
            Boolean correcto = false;
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);

                SqlCommand comando = new SqlCommand("insert into Registro(descripcion, fk_idempleado, fk_idsocio)" +
                "values(@descripcion, @fk_idempleado, @fk_idsocio)", sqlconection);

                comando.Parameters.AddWithValue("@descripcion", System.Data.SqlDbType.VarChar).Value = registro.Descripcion;
                if (registro.IdEmpleado == -1)
                {
                    comando.Parameters.AddWithValue("@fk_idempleado", System.Data.SqlDbType.Int).Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    comando.Parameters.AddWithValue("@fk_idempleado", System.Data.SqlDbType.Int).Value = registro.IdEmpleado;
                }
                if (registro.IdSocio == -1)
                {
                    comando.Parameters.AddWithValue("@fk_idsocio", System.Data.SqlDbType.Int).Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    comando.Parameters.AddWithValue("@fk_idsocio", System.Data.SqlDbType.Int).Value = registro.IdSocio;
                }

                int rows = comando.ExecuteNonQuery();
                if (rows == 1)
                {
                    correcto = true;
                }
            }
            catch (Exception ex)
            { }
            sqlconection.Close();
            return correcto;
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int IdRegistro
        {
            get { return idRegistro; }
            set { idRegistro = value; }
        }
    }
}