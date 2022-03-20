using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Datos
{
    public class DComercio
    {
        private int idComercio;
        private string nombre;
        private string siglas;
        private string direccion;
        private string email;
        private string telefono;
        private int autorizacion;
        private string tipoProducto;
        private string fax;
        private int baja = 0;

        public int Baja
        {
            get { return baja; }
            set { baja = value; }
        }

        public DComercio()
        {

        }

        public DComercio(string nombre, string siglas, string direccion,
            string email, string telefono, int autorizacion, string tipoProducto, string fax)
        {
            this.nombre = nombre;
            this.siglas = siglas;
            this.direccion = direccion;
            this.email = email;
            this.telefono = telefono;
            this.autorizacion = autorizacion;
            this.tipoProducto = tipoProducto;
            this.fax = fax;
        }

        public Boolean insertar(DComercio comercio)
        {
            SqlConnection sqlconection = new SqlConnection();
            Boolean correcto = false;
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("insert into Comercio(nombre, siglas, direccion, email, telefono, autorizacion, tipoProducto, fax, baja)"
                    + "values(@nombre, @siglas, @direccion, @email, @telefono, @autorizacion, @tipoProducto, @fax, @baja)", sqlconection);//, sqlconection);
                comando.Parameters.AddWithValue("@nombre", comercio.Nombre);
                comando.Parameters.AddWithValue("@siglas", comercio.Siglas);
                comando.Parameters.AddWithValue("@direccion", comercio.Direccion);
                comando.Parameters.AddWithValue("@email", comercio.Email);
                comando.Parameters.AddWithValue("@telefono", comercio.Telefono);
                comando.Parameters.AddWithValue("@autorizacion", comercio.Autorizacion);
                comando.Parameters.AddWithValue("@tipoProducto", comercio.TipoProducto);
                comando.Parameters.AddWithValue("@fax", comercio.Fax);
                comando.Parameters.AddWithValue("@baja", comercio.Baja);
                int rows = comando.ExecuteNonQuery();
                if (rows == 1)
                {
                    correcto = true;
                }
            }
            catch (Exception ex)
            { }
            Conexion.cerrarConexion(sqlconection);
            return correcto;
        }

        public DComercio encontrar(DComercio comercio)
        {
            SqlConnection sqlconection = new SqlConnection();
            DComercio temp = new DComercio();
            try
            {   //seguir con encontrar
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                string consulta = "select * from Comercio where nombre = '" + comercio.Nombre
                    + "' and siglas = '" + comercio.Siglas
                    + "' and email = '" + comercio.Email + "';";
                SqlCommand comando = new SqlCommand(consulta, sqlconection);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    temp.IdComercio = reader.GetInt32(0);
                    temp.Nombre = reader.GetString(1);
                    temp.Siglas = reader.GetString(2);
                    temp.Direccion = reader.GetString(3);
                    temp.Email = reader.GetString(4);
                    temp.Telefono = reader.GetString(5);
                    Boolean ver = reader.GetBoolean(6);
                    if (ver)
                    {
                        temp.Autorizacion = 1;
                    }
                    else
                    {
                        temp.Autorizacion = 0;
                    }
                    temp.TipoProducto = reader.GetString(7);
                    temp.Fax = reader.GetString(8);
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

        public DComercio buscarID(DComercio comercio)
        {
            SqlConnection sqlconection = new SqlConnection();
            DComercio temp = new DComercio();
            try
            {   //seguir con encontrar
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                string consulta = "select * from Comercio where idComercio = '" + comercio.IdComercio +"';";
                SqlCommand comando = new SqlCommand(consulta, sqlconection);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    temp.IdComercio = reader.GetInt32(0);
                    temp.Nombre = reader.GetString(1);
                    temp.Siglas = reader.GetString(2);
                    temp.Direccion = reader.GetString(3);
                    temp.Email = reader.GetString(4);
                    temp.Telefono = reader.GetString(5);
                    Boolean ver = reader.GetBoolean(6);
                    if (ver)
                    {
                        temp.Autorizacion = 1;
                    }
                    else
                    {
                        temp.Autorizacion = 0;
                    }
                    temp.TipoProducto = reader.GetString(7);
                    temp.Fax = reader.GetString(8);
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

        public static Boolean isAutorizado(int idcomercio)
        {
            SqlConnection sqlconection = new SqlConnection();
            Boolean autorizado = false;
            try
            {   //seguir con encontrar
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                string consulta = "select * from Comercio where idComercio = '" + idcomercio + "';";
                SqlCommand comando = new SqlCommand(consulta, sqlconection);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    autorizado = reader.GetBoolean(6);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            Conexion.cerrarConexion(sqlconection);
            return autorizado;
        }

        public DComercio encontrarS(DComercio comercio)
        {
            SqlConnection sqlconection = new SqlConnection();
            DComercio temp = new DComercio();
            try
            {   //seguir con encontrar
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                string consulta = "select * from Comercio where siglas = '" + comercio.Siglas + "';";
                SqlCommand comando = new SqlCommand(consulta, sqlconection);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    temp.IdComercio = reader.GetInt32(0);
                    temp.Nombre = reader.GetString(1);
                    temp.Siglas = reader.GetString(2);
                    temp.Direccion = reader.GetString(3);
                    temp.Email = reader.GetString(4);
                    temp.Telefono = reader.GetString(5);
                    Boolean ver = reader.GetBoolean(6);
                    if (ver)
                    {
                        temp.Autorizacion = 1;
                    }
                    else
                    {
                        temp.Autorizacion = 0;
                    }
                    temp.TipoProducto = reader.GetString(7);
                    temp.Fax = reader.GetString(8);
                    reader.Close();
                    Conexion.cerrarConexion(sqlconection);
                    return temp;
                }

            }
            catch (Exception ex)
            {

            }
            Conexion.cerrarConexion(sqlconection);
            return null;
        }

        public Boolean actualizar(DComercio comercio)
        {//modificar actualizar
            SqlConnection sqlconection = new SqlConnection();
            Boolean actualizado = false;
            try
            {   //seguir con encontrar
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                string consulta = "update Comercio set autorizacion = " + comercio.Autorizacion + " where idComercio = "+ comercio.IdComercio + " ;";
                SqlCommand comando = new SqlCommand(consulta, sqlconection);

                int rows = comando.ExecuteNonQuery();
                if (rows == 1)
                {
                    actualizado = true;
                }
            }
            catch (Exception ex)
            {

            }
            Conexion.cerrarConexion(sqlconection);
            return actualizado;
        }

        public Boolean actualizar2(DComercio comercio)
        {//modificar actualizar
            SqlConnection sqlconection = new SqlConnection();
            Boolean actualizado = false;
            try
            {   //seguir con encontrar
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                string consulta = "update Comercio set direccion = '" + comercio.Direccion 
                    + "', email = '"+ comercio.Email +"', fax = '" + comercio.Fax + "', telefono = '"
                    + comercio.Telefono + "' where idComercio = " + comercio.IdComercio + " ;";
                SqlCommand comando = new SqlCommand(consulta, sqlconection);

                int rows = comando.ExecuteNonQuery();
                if (rows == 1)
                {
                    actualizado = true;
                }
            }
            catch (Exception ex)
            {

            }
            Conexion.cerrarConexion(sqlconection);
            return actualizado;
        }

        public DataSet loadData()
        {
            SqlDataAdapter sdA = new SqlDataAdapter("Select nombre, siglas, direccion, email, telefono, fax from Comercio;", Conexion.conect());
            DataSet ds = new DataSet();

            sdA.Fill(ds);
            return ds;
        }

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public int IdComercio
        {
            get { return idComercio; }
            set { idComercio = value; }
        }
        public string TipoProducto
        {
            get { return tipoProducto; }
            set { tipoProducto = value; }
        }
        public int Autorizacion
        {
            get { return autorizacion; }
            set { autorizacion = value; }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public string Siglas
        {
            get { return siglas; }
            set { siglas = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}