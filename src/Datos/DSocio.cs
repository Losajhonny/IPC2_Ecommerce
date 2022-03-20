using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Datos
{
    public class DSocio
    {
        private int idsocio;
        private string password;
        private string nombre;
        private string telefono;
        private string direccion;
        private string email;
        private string noCuenta;
        private int idcarrocompra;
        private string textoBuscar;

        //constructor vacio
        public DSocio()
        {

        }

        //Constructor con parametros
        public DSocio(string password, string nombre, string telefono, string email, string noCuenta, int idcarrocompra)
        {
            this.password = password;
            this.nombre = nombre;
            this.telefono = telefono;
            this.email = email;
            this.noCuenta = noCuenta;
            this.idcarrocompra = idcarrocompra;
        }

        public DSocio(string password, string nombre, string telefono, string email, string noCuenta, int idcarrocompra, string direccion)
        {
            this.password = password;
            this.nombre = nombre;
            this.telefono = telefono;
            this.email = email;
            this.noCuenta = noCuenta;
            this.idcarrocompra = idcarrocompra;
            this.direccion = direccion;
        }

        public Boolean insertar(DSocio Socio)
        {
            Boolean respuesta = false;
            SqlConnection sqlconection = new SqlConnection();
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("insert into Socio(passwor, nombre, telefono, direccion, email, noCuenta, CarroCompra_idCarro)"
                    + "values(@passwor, @nombre, @telefono, @direccion, @email, @noCuenta, @CarroCompra_idCarro);", sqlconection);
                comando.Parameters.AddWithValue("@passwor", Socio.Password);
                comando.Parameters.AddWithValue("@nombre", Socio.Nombre);
                comando.Parameters.AddWithValue("@telefono", Socio.Telefono);
                comando.Parameters.AddWithValue("@direccion", Socio.Direccion);
                comando.Parameters.AddWithValue("@email", Socio.Email);
                comando.Parameters.AddWithValue("@noCuenta", Socio.NoCuenta);
                comando.Parameters.AddWithValue("@carroCompra_idCarro", Socio.Idcarrocompra);
                int rows = comando.ExecuteNonQuery();
                if (rows == 1)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
            }
            catch (Exception ex)
            {

            }
            Conexion.cerrarConexion(sqlconection);
            return respuesta;
        }

        public string editar(DSocio Socio)
        {
            string respuesta = "";
            SqlConnection sqlconection = new SqlConnection();
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("update Socio set password = @passwor, nombre = @nombre" +
                    ", telefono = @telefono, direccion = @direccion, email = @email, noCuenta = @noCuenta where idSocio = @idSocio", sqlconection);//, sqlconection);
                comando.Parameters.AddWithValue("@idSocio", Socio.Idsocio);
                comando.Parameters.AddWithValue("@passwor", Socio.Password);
                comando.Parameters.AddWithValue("@nombre", Socio.Nombre);
                comando.Parameters.AddWithValue("@telefono", Socio.Telefono);
                comando.Parameters.AddWithValue("@direccion", Socio.Direccion);
                comando.Parameters.AddWithValue("@email", Socio.Email);
                comando.Parameters.AddWithValue("@noCuenta", Socio.NoCuenta);
                comando.Parameters.AddWithValue("@carroCompra_idCarro", Socio.Idcarrocompra);
                int rows = comando.ExecuteNonQuery();
                if (rows == 1)
                {
                    respuesta = "ok";
                }
                else
                {
                    respuesta = "No se actualizo ningun registro";
                }
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            Conexion.cerrarConexion(sqlconection);
            return respuesta;
        }

        public Boolean encontrar(DSocio socio)
        {
            SqlConnection sqlconection = new SqlConnection();
            Boolean b = false;
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("select * from Socio where email = '" + socio.Email
                    + "' and passwor = '" + socio.Password + "';", sqlconection);

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    b = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            Conexion.cerrarConexion(sqlconection);
            return b;
        }

        public DSocio buscar(DSocio socio)
        {
            SqlConnection sqlconection = new SqlConnection();
            DSocio s = new DSocio();
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("select * from Socio where email = '" + socio.Email
                    + "' and passwor = '" + socio.Password + "';", sqlconection);

                SqlDataReader reader = comando.ExecuteReader();
                Boolean leo = reader.Read();
                if (leo)
                {
                    s.Idsocio = reader.GetInt32(0);
                    s.Password = reader.GetString(1);
                    s.Nombre = reader.GetString(2);
                    s.Telefono = reader.GetString(3);
                    s.Direccion = reader.GetString(4);
                    s.Email = reader.GetString(5);
                    s.NoCuenta = reader.GetString(6);
                    reader.Close();
                    Conexion.cerrarConexion(sqlconection);
                    return s;
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            Conexion.cerrarConexion(sqlconection);
            return null;
        }

        public DSocio buscar(int idSocio)
        {
            DSocio socio = new DSocio();

            SqlConnection sqlconection = new SqlConnection();
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("select * from Socio where idSocio = " + idSocio.ToString() , sqlconection);

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    socio.Idsocio = idSocio;
                    socio.Password = reader["passwor"].ToString();
                    socio.Nombre = reader["nombre"].ToString();
                    socio.Telefono = reader["telefono"].ToString();
                    socio.Telefono = reader["direccion"].ToString();
                    socio.Telefono = reader["email"].ToString();
                    socio.Telefono = reader["noCuenta"].ToString();
                    socio.Idcarrocompra = Convert.ToInt32(reader["CarroCompra_idCarro"].ToString());
                }
                else
                {
                    socio = null;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
            }
            Conexion.cerrarConexion(sqlconection);
            return socio;
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public int Idcarrocompra
        {
            get { return idcarrocompra; }
            set { idcarrocompra = value; }
        }

        public string TextoBuscar
        {
            get { return textoBuscar; }
            set { textoBuscar = value; }
        }

        public int Idsocio
        {
            get { return idsocio; }
            set { idsocio = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
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

        public string NoCuenta
        {
            get { return noCuenta; }
            set { noCuenta = value; }
        }
    }
}