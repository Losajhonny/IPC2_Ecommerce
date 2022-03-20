using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Datos
{
    public class DCarroProducto
    {
        private int idCarro;
        private int idProducto;
        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public DCarroProducto()
        {

        }

        public Boolean insertar(DCarroProducto dcp)
        {
            SqlConnection conn = new SqlConnection();
            Boolean correcto = false;

            try
            {
                conn = Conexion.conect();
                Conexion.abrirConexion(conn);

                string consulta = "insert into CarroProducto(CarroCompra_idCarro, Producto_idProducto, cantidad)"
                    + "values(@CarroCompra_idCarro, @Producto_idProducto, @cantidad)";
                SqlCommand cmd = new SqlCommand(consulta, conn);
                cmd.Parameters.AddWithValue("@CarroCompra_idCarro", System.Data.SqlDbType.Int).Value = dcp.IdCarro;
                cmd.Parameters.AddWithValue("@Producto_idProducto", System.Data.SqlDbType.Int).Value = dcp.IdProducto;
                cmd.Parameters.AddWithValue("@cantidad", System.Data.SqlDbType.Int).Value = 1;
                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                {
                    correcto = true;
                }
            }
            catch (Exception ex) { }
            Conexion.cerrarConexion(conn);
            return correcto;
        }

        public Boolean buscar(DCarroProducto dcp)
        {
            SqlConnection conn = new SqlConnection();
            Boolean correcto = false;

            try
            {
                conn = Conexion.conect();
                Conexion.abrirConexion(conn);

                string consulta = "select * from CarroProducto where CarroCompra_idCarro=@idCarro and "
                    + "Producto_idProducto = @idProducto";
                SqlCommand cmd = new SqlCommand(consulta, conn);
                cmd.Parameters.AddWithValue("@idCarro", System.Data.SqlDbType.Int).Value = dcp.IdCarro;
                cmd.Parameters.AddWithValue("@idProducto", System.Data.SqlDbType.Int).Value = dcp.IdProducto;

                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                {
                    correcto = true;
                }
            }
            catch (Exception ex) { }
            Conexion.cerrarConexion(conn);
            return correcto;
        }

        public DCarroProducto buscarR(DCarroProducto dcp)
        {
            SqlConnection conn = new SqlConnection();
            DCarroProducto temp = new DCarroProducto();
            try
            {
                conn = Conexion.conect();
                Conexion.abrirConexion(conn);

                string consulta = "select * from CarroProducto where CarroCompra_idCarro=@idCarro and "
                    + "Producto_idProducto = @idProducto";
                SqlCommand cmd = new SqlCommand(consulta, conn);
                cmd.Parameters.AddWithValue("@idCarro", System.Data.SqlDbType.Int).Value = dcp.IdCarro;
                cmd.Parameters.AddWithValue("@idProducto", System.Data.SqlDbType.Int).Value = dcp.IdProducto;

                SqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    temp.IdCarro = read.GetInt32(0);
                    temp.IdProducto = read.GetInt32(1);
                    temp.Cantidad = read.GetInt32(2);
                    read.Close();
                    Conexion.cerrarConexion(conn);
                    return temp;
                }
            }
            catch (Exception ex) { }
            Conexion.cerrarConexion(conn);
            return null;
        }

        public Boolean updateCantidadMas(DCarroProducto dcp)
        {
            SqlConnection conn = new SqlConnection();
            Boolean rigth = false;
            try
            {
                conn = Conexion.conect();
                Conexion.abrirConexion(conn);
                int can = dcp.Cantidad;
                string consulta = "update CarroProducto set cantidad = @cantidad"
                    + " where CarroCompra_idCarro = @idCarro and Producto_idProducto = @idProducto";
                SqlCommand cmd = new SqlCommand(consulta, conn);
                cmd.Parameters.AddWithValue("@cantidad", System.Data.SqlDbType.Int).Value = can + 1;
                cmd.Parameters.AddWithValue("@idCarro", System.Data.SqlDbType.Int).Value = dcp.IdCarro;
                cmd.Parameters.AddWithValue("@idProducto", System.Data.SqlDbType.Int).Value = dcp.IdProducto;

                int rows = cmd.ExecuteNonQuery();

                if (rows == 1)
                {
                    rigth = true;
                }
            }
            catch (Exception ex) { }
            Conexion.cerrarConexion(conn);
            return rigth;
        }

        public Boolean updateCantidad(DCarroProducto dcp)
        {
            SqlConnection conn = new SqlConnection();
            Boolean rigth = false;
            try
            {
                conn = Conexion.conect();
                Conexion.abrirConexion(conn);
                string consulta = "update CarroProducto set cantidad = @cantidad"
                    + " where CarroCompra_idCarro = @idCarro and Producto_idProducto = @idProducto";
                SqlCommand cmd = new SqlCommand(consulta, conn);
                cmd.Parameters.AddWithValue("@cantidad", System.Data.SqlDbType.Int).Value = dcp.Cantidad;
                cmd.Parameters.AddWithValue("@idCarro", System.Data.SqlDbType.Int).Value = dcp.IdCarro;
                cmd.Parameters.AddWithValue("@idProducto", System.Data.SqlDbType.Int).Value = dcp.IdProducto;

                int rows = cmd.ExecuteNonQuery();

                if (rows == 1)
                {
                    rigth = true;
                }
            }
            catch (Exception ex) { }
            Conexion.cerrarConexion(conn);
            return rigth;
        }

        public Boolean delete(DCarroProducto dcp)
        {
            SqlConnection conn = new SqlConnection();
            Boolean correcto = false;
            try
            {
                conn = Conexion.conect();
                Conexion.abrirConexion(conn);
                string consulta = "delecte from CarroProducto where CarroCompra_idCarro = @idCarro";

                SqlCommand cmd = new SqlCommand(consulta, conn);
                cmd.Parameters.AddWithValue("@idCarro", System.Data.SqlDbType.Int).Value = dcp.IdCarro;

                int rows = cmd.ExecuteNonQuery();

                if (rows >= 1)
                {
                    correcto = true;
                }
            }
            catch (Exception ex) { }
            Conexion.cerrarConexion(conn);
            return correcto;
        }

        public Boolean deleteI(DCarroProducto dcp)
        {
            SqlConnection conn = new SqlConnection();
            Boolean correcto = false;
            try
            {
                conn = Conexion.conect();
                Conexion.abrirConexion(conn);
                string consulta = "delete from CarroProducto where CarroCompra_idCarro = @idCarro " + 
                    "and Producto_idProducto = @idProducto";

                SqlCommand cmd = new SqlCommand(consulta, conn);
                cmd.Parameters.AddWithValue("@idCarro", System.Data.SqlDbType.Int).Value = dcp.IdCarro;
                cmd.Parameters.AddWithValue("@idProducto", System.Data.SqlDbType.Int).Value = dcp.IdProducto;

                int rows = cmd.ExecuteNonQuery();

                if (rows >= 1)
                {
                    correcto = true;
                }
            }
            catch (Exception ex) { }
            Conexion.cerrarConexion(conn);
            return correcto;
        }

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        public int IdCarro
        {
            get { return idCarro; }
            set { idCarro = value; }
        }
       
    }
}