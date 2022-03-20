using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Datos
{
    public class DEmpleado
    {
        private string puesto;
        private string nombre;
        private string telefono;
        private int comercio_idcomercio;
        private int idEmpleado;
        private string email;
        private string password;

        public DEmpleado(string puesto, string nombre, string telefono, int comercio_idcomercio, string email, string password)
        {
            this.puesto = puesto;
            this.nombre = nombre;
            this.telefono = telefono;
            this.comercio_idcomercio = comercio_idcomercio;
            this.email = email;
            this.password = password;
        }

        public DEmpleado()
        {

        }
        public int IdEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }

        public Boolean actualizar(DEmpleado empleado)
        {
            SqlConnection sqlconection = new SqlConnection();
            Boolean actualizado = false;
            try
            {   //seguir con encontrar
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                string consulta = "update Empleado set email = '" + empleado.Email +
                    "' where Comercio_idComercio = " + empleado.Comercio_idcomercio +
                    " and idEmpleado = " + empleado.IdEmpleado + " ;";
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

        public Boolean actualizar2(DEmpleado empleado)
        {
            SqlConnection sqlconection = new SqlConnection();
            Boolean actualizado = false;
            try
            {   //seguir con encontrar
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                string consulta = "update Empleado set nombre = '" + empleado.Nombre +
                    "', telefono = '" + empleado.Telefono + 
                    "', email = '" + empleado.Email + 
                    "', passwor = '" + empleado.Password + "' where Comercio_idComercio = " + empleado.Comercio_idcomercio +
                    " and idEmpleado = " + empleado.IdEmpleado + " ;";
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

        public DEmpleado buscarID(DEmpleado empleado)
        {
            SqlConnection sqlconection = new SqlConnection();
            DEmpleado temp = new DEmpleado();
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("select * from Empleado where idEmpleado = " + empleado.IdEmpleado
                    + " and Comercio_idComercio = " + empleado.Comercio_idcomercio + ";", sqlconection);

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    temp.IdEmpleado = reader.GetInt32(0);
                    temp.Puesto = reader.GetString(1);
                    temp.Nombre = reader.GetString(2);
                    temp.Telefono = reader.GetString(3);
                    temp.Comercio_idcomercio = reader.GetInt32(4);
                    temp.Email = reader.GetString(5);
                    temp.Password = reader.GetString(6);
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

        public Boolean insertar(DEmpleado empleado)
        {
            SqlConnection sqlconection = new SqlConnection();
            Boolean correcto = false;
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("insert into Empleado(puesto, nombre, telefono, Comercio_idComercio, email, passwor)"
                    + "values(@puesto, @nombre, @telefono, @Comercio_idcomercio, @email, @passwor)", sqlconection);
                comando.Parameters.AddWithValue("@puesto", empleado.Puesto);
                comando.Parameters.AddWithValue("@nombre", empleado.Nombre);
                comando.Parameters.AddWithValue("@telefono", empleado.Telefono);
                comando.Parameters.AddWithValue("@Comercio_idcomercio", empleado.Comercio_idcomercio);
                comando.Parameters.AddWithValue("@email", empleado.Email);
                comando.Parameters.AddWithValue("@passwor", empleado.Password);

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

        public Boolean encontrar(DEmpleado empleado)
        {
            SqlConnection sqlconection = new SqlConnection();
            Boolean b = false;
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("select * from Empleado where email = '" + empleado.Email
                    + "' and passwor = '" + empleado.Password + "';", sqlconection);

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

        public DEmpleado buscar(DEmpleado empleado)
        {
            SqlConnection sqlconection = new SqlConnection();
            DEmpleado temp = new DEmpleado();
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("select * from Empleado where email = '" + empleado.Email
                    + "' and passwor = '" + empleado.Password + "';", sqlconection);

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    temp.Comercio_idcomercio = reader.GetInt32(4);
                    temp.IdEmpleado = reader.GetInt32(0);
                    temp.Puesto = reader.GetString(1);
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

        public string Puesto
        {
            get { return puesto; }
            set { puesto = value; }
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
        public int Comercio_idcomercio
        {
            get { return comercio_idcomercio; }
            set { comercio_idcomercio = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}