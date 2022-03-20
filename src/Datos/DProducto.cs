using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Datos
{
    public class DProducto
    {
        private int idProducto;
        private double precio;
        private string nombre;
        private string tipoProducto;
        private int existencia;
        private string descripcion;
        private string docMultimedia;
        private string oferta;

        public DProducto()
        {

        }

        public DProducto(double precio, string nombre, string tipoProducto, string descripcion, string docMultimedia, string oferta)
        {
            this.precio = precio;
            this.nombre = nombre;
            this.tipoProducto = tipoProducto;
            this.descripcion = descripcion;
            this.docMultimedia = docMultimedia;
            this.oferta = oferta;
        }

        public Boolean insertar(DProducto producto)
        {
            SqlConnection sqlconection = new SqlConnection();
            Boolean correcto = false;
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("insert into Producto(precio, nombre, tipoProducto, existencia, descripcion, docMultimedia, oferta)"
                    + "values(@precio, @nombre, @tipoProducto, @existencia, @descripcion, @docMultimedia, @oferta)", sqlconection);
                comando.Parameters.AddWithValue("@precio", producto.Precio);
                comando.Parameters.AddWithValue("@nombre", producto.Nombre);
                comando.Parameters.AddWithValue("@tipoProducto", producto.TipoProducto);
                comando.Parameters.AddWithValue("@existencia", producto.Existencia);
                comando.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                comando.Parameters.AddWithValue("@docMultimedia", producto.DocMultimedia);
                comando.Parameters.AddWithValue("@oferta", producto.Oferta);

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

        public DProducto buscar(DProducto producto)
        {
            SqlConnection sqlconection = new SqlConnection();
            DProducto temp = new DProducto();
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("select * from Producto where precio = "
                    + producto.Precio + " and nombre = '"
                    + producto.Nombre + "' and tipoProducto = '"
                    + producto.TipoProducto + "' and descripcion = '"
                    + producto.Descripcion + "' and docMultimedia = '"
                    + producto.DocMultimedia + "' and oferta = '"
                    + producto.Oferta + "';", sqlconection);

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    temp.IdProducto = reader.GetInt32(0);
                    temp.Precio = reader.GetDouble(1);
                    temp.Nombre = reader.GetString(2);
                    temp.TipoProducto = reader.GetString(3);
                    temp.Descripcion = reader.GetString(5);
                    temp.DocMultimedia = reader.GetString(6);
                    temp.Oferta = reader.GetString(7);
                    reader.Close();
                    Conexion.cerrarConexion(sqlconection);
                    return temp;
                }

            }
            catch (Exception e)
            {

            }
            Conexion.cerrarConexion(sqlconection);
            return null;
        }

        public DProducto buscarPN(DProducto producto)
        {
            SqlConnection sqlconection = new SqlConnection();
            DProducto temp = new DProducto();
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("select * from Producto where precio = "
                    + producto.Precio + " and nombre = '"
                    + producto.Nombre + "';", sqlconection);

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    temp.IdProducto = reader.GetInt32(0);
                    temp.Precio = reader.GetDouble(1);
                    temp.Nombre = reader.GetString(2);
                    temp.TipoProducto = reader.GetString(3);
                    temp.Descripcion = reader.GetString(5);
                    temp.DocMultimedia = reader.GetString(6);
                    temp.Oferta = reader.GetString(7);
                    reader.Close();
                    Conexion.cerrarConexion(sqlconection);
                    return temp;
                }

            }
            catch (Exception e)
            {

            }
            Conexion.cerrarConexion(sqlconection);
            return null;
        }

        public DProducto buscarC(DProducto producto)
        {
            SqlConnection sqlconection = new SqlConnection();
            DProducto temp = new DProducto();
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("select * from Producto where precio = "
                    + producto.Precio + " and nombre = '"
                    + producto.Nombre + "' and descripcion = '"
                    + producto.Descripcion + "' and oferta = '"
                    + producto.Oferta + "';", sqlconection);

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    temp.IdProducto = reader.GetInt32(0);
                    temp.Precio = reader.GetDouble(1);
                    temp.Nombre = reader.GetString(2);
                    temp.TipoProducto = reader.GetString(3);
                    temp.Descripcion = reader.GetString(5);
                    temp.DocMultimedia = reader.GetString(6);
                    temp.Oferta = reader.GetString(7);
                    reader.Close();
                    Conexion.cerrarConexion(sqlconection);
                    return temp;
                }

            }
            catch (Exception e)
            {

            }
            Conexion.cerrarConexion(sqlconection);
            return null;
        }

        public DProducto buscarID(DProducto producto)
        {
            SqlConnection sqlconection = new SqlConnection();
            DProducto temp = new DProducto();
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("select * from Producto where idProducto = "
                    + producto.IdProducto + ";", sqlconection);

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    temp.IdProducto = reader.GetInt32(0);
                    temp.Precio = reader.GetDouble(1);
                    temp.Nombre = reader.GetString(2);
                    temp.TipoProducto = reader.GetString(3);
                    temp.Descripcion = reader.GetString(5);
                    temp.DocMultimedia = reader.GetString(6);
                    temp.Oferta = reader.GetString(7);
                    reader.Close();
                    Conexion.cerrarConexion(sqlconection);
                    return temp;
                }

            }
            catch (Exception e)
            {

            }
            Conexion.cerrarConexion(sqlconection);
            return null;
        }

        public DProducto buscarT(DProducto producto)
        {
            SqlConnection sqlconection = new SqlConnection();
            DProducto temp = new DProducto();
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("select * from Producto where precio = "
                    + producto.Precio + " and nombre = '"
                    + producto.Nombre + "' and tipoProducto = '"
                    + producto.TipoProducto + "' and descripcion = '"
                    + producto.Descripcion + "';", sqlconection);

                SqlDataReader reader = comando.ExecuteReader();
                Boolean tempB = reader.Read();
                if (tempB)
                {
                    temp.IdProducto = reader.GetInt32(0);
                    temp.Precio = reader.GetDouble(1);
                    temp.Nombre = reader.GetString(2);
                    temp.TipoProducto = reader.GetString(3);
                    temp.Descripcion = reader.GetString(5);
                    temp.DocMultimedia = reader.GetString(6);
                    temp.Oferta = reader.GetString(7);
                    reader.Close();
                    Conexion.cerrarConexion(sqlconection);
                    return temp;
                }

            }
            catch (Exception e)
            {

            }
            Conexion.cerrarConexion(sqlconection);
            return null;
        }

        public Boolean actualizar(DProducto producto)
        {
            SqlConnection sqlconection = new SqlConnection();
            Boolean actualizado = false;
            try
            {   //seguir con encontrar
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                string consulta = "update Producto set existencia = " + producto.Existencia + " where idProducto = " + producto.IdProducto + " ;";
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

        public Boolean actualizar2(DProducto pro)
        {
            SqlConnection sqlconection = new SqlConnection();
            Boolean actualizado = false;
            try
            {   //seguir con encontrar
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                string consulta = "update Producto set nombre = @nombre, descripcion = @descripcion, tipoProducto = @tipoProducto, oferta = @oferta, docMultimedia = @docMultimedia, precio = @precio where idProducto = @idProducto ;";
                //string consulta = "update Producto set nombre = '" + pro.Nombre + "', descripcion = '" +
                //    pro.Descripcion + "', tipoProducto = '" + pro.TipoProducto + "', oferta = '" + pro.Oferta + 
                //    "' precio = " + pro.Precio + ", docMultimedia = '"+ pro.DocMultimedia + "' where idProducto = " + pro.IdProducto + " ;";
                SqlCommand comando = new SqlCommand(consulta, sqlconection);
                comando.Parameters.AddWithValue("@idProducto", pro.IdProducto);
                comando.Parameters.AddWithValue("@nombre", pro.Nombre);
                comando.Parameters.AddWithValue("@docMultimedia", pro.DocMultimedia);
                comando.Parameters.AddWithValue("@descripcion", pro.Descripcion);
                comando.Parameters.AddWithValue("@tipoProducto", pro.TipoProducto);
                comando.Parameters.AddWithValue("@oferta", pro.Oferta);
                comando.Parameters.AddWithValue("@precio", pro.Precio);

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

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string TipoProducto
        {
            get { return tipoProducto; }
            set { tipoProducto = value; }
        }
        public int Existencia
        {
            get { return existencia; }
            set { existencia = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string DocMultimedia
        {
            get { return docMultimedia; }
            set { docMultimedia = value; }
        }
        public string Oferta
        {
            get { return oferta; }
            set { oferta = value; }
        }
    }
}