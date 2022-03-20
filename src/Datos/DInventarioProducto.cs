using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Datos
{
    public class DInventarioProducto
    {
        private int idInventario;
        private int idProducto;
        private int existencia;

        public DInventarioProducto()
        {

        }

        public DInventarioProducto(int existencia)
        {
            this.existencia = existencia;
        }

        public Boolean insertar(DInventarioProducto dip)
        {
            SqlConnection sqlconection = new SqlConnection();
            Boolean correcto = false;
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("insert into InventarioProducto(Inventario_idInventario, Producto_idProducto, existencia)"
                    + "values(@Inventario_idInventario, @Producto_idProducto, @existencia)", sqlconection);
                comando.Parameters.AddWithValue("@Inventario_idInventario", dip.IdInventario);
                comando.Parameters.AddWithValue("@Producto_idProducto", dip.IdProducto);
                comando.Parameters.AddWithValue("@existencia", dip.Existencia);

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

        public int IdInventario
        {
            get { return idInventario; }
            set { idInventario = value; }
        }

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        public int Existencia
        {
            get { return existencia; }
            set { existencia = value; }
        }


    }
}