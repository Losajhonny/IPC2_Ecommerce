using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Datos
{
    public class DCategoriaProducto
    {
        private int idProducto;
        private int idCategoria;
        private int idComercio;

        public DCategoriaProducto()
        {

        }

        public DCategoriaProducto(int idProducto, int idCategoria, int idComercio)
        {
            this.idProducto = idProducto;
            this.idCategoria = idCategoria;
            this.idComercio = idComercio;
        }

        public Boolean insertar(DCategoriaProducto dcp)
        {
            SqlConnection sqlconection = new SqlConnection();
            Boolean correcto = false;
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("insert into CategoriaProducto(Producto_idProducto, Categoria_idCategoria, Comercio_idComercio)" +
                    "values(@Producto_idProducto, @Categoria_idCategoria, @Comercio_idComercio)", sqlconection);
                comando.Parameters.AddWithValue("@Producto_idProducto", dcp.IdProducto);
                comando.Parameters.AddWithValue("@Categoria_idCategoria", dcp.IdCategoria);
                comando.Parameters.AddWithValue("@Comercio_idComercio", dcp.IdComercio);

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

        public int IdComercio
        {
            get { return idComercio; }
            set { idComercio = value; }
        }

        public int IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }
    }
}