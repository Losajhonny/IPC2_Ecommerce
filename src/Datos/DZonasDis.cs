using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Datos
{
    public class DZonasDis
    {
        private int idZona;
        private string descripcion;
        private string tipoZona;
        private int noZonaSuperior;
        private int noZona;
        private int noZonaVecina;
        private string nombre;
        private int zonaDis_idZona;

        public DZonasDis()
        {

        }

        public DZonasDis(string descripcion, string tipoZona, int noZonaSuperior, int noZona, int noZonaVecina, string nombre, int ZonaDis_idZona)
        {
            this.descripcion = descripcion;
            this.tipoZona = tipoZona;
            this.noZonaSuperior = noZonaSuperior;
            this.noZona = noZona;
            this.noZonaVecina = noZonaVecina;
            this.nombre = nombre;
            this.zonaDis_idZona = ZonaDis_idZona;
        }

        public Boolean insertarZona(DZonasDis zona)
        {
            SqlConnection sqlconection = new SqlConnection();
            Boolean correcto = false;
            try
            {
                sqlconection = Conexion.conect();
                Conexion.abrirConexion(sqlconection);
                SqlCommand comando = new SqlCommand("insert into ZonaDis(descripcion, tipoZona, noZonaSuperior, noZona, noZonaVecina, nombre, ZonaDis_idZona)"
                    + "values(@descripcion, @tipoZona, @noZonaSuperior, @noZona, @noZonaVecina, @nombre, @ZonaDis_idZona)", sqlconection);//, sqlconection);
                comando.Parameters.AddWithValue("@descripcion", System.Data.SqlDbType.VarChar).Value = zona.Descripcion;
                comando.Parameters.AddWithValue("@tipoZona", System.Data.SqlDbType.VarChar).Value = zona.TipoZona;
                if (zona.NoZonaSuperior != -1)
                {
                    comando.Parameters.AddWithValue("@noZonaSuperior", System.Data.SqlDbType.Int).Value = zona.NoZonaSuperior;
                }
                else
                {
                    comando.Parameters.AddWithValue("@noZonaSuperior", System.Data.SqlDbType.Int).Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                comando.Parameters.AddWithValue("@noZona", System.Data.SqlDbType.Int).Value = zona.NoZona;
                if (zona.NoZonaVecina != -1)
                {
                    comando.Parameters.AddWithValue("@noZonaVecina", System.Data.SqlDbType.Int).Value = zona.NoZonaVecina;
                }
                else
                {
                    comando.Parameters.AddWithValue("@noZonaVecina", System.Data.SqlDbType.Int).Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                comando.Parameters.AddWithValue("@nombre", zona.Nombre);
                if (zona.ZonaDis_idZona != -1)
                {
                    comando.Parameters.AddWithValue("@ZonaDis_idZona", System.Data.SqlDbType.Int).Value = zona.ZonaDis_idZona;
                }
                else
                {
                    comando.Parameters.AddWithValue("@ZonaDis_idZona", System.Data.SqlDbType.Int).Value = System.Data.SqlTypes.SqlInt32.Null;
                }
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

        public int IdZona
        {
            get { return idZona; }
            set { idZona = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string TipoZona
        {
            get { return tipoZona; }
            set { tipoZona = value; }
        }

        public int NoZonaSuperior
        {
            get { return noZonaSuperior; }
            set { noZonaSuperior = value; }
        }

        public int NoZona
        {
            get { return noZona; }
            set { noZona = value; }
        }

        public int NoZonaVecina
        {
            get { return noZonaVecina; }
            set { noZonaVecina = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int ZonaDis_idZona
        {
            get { return zonaDis_idZona; }
            set { zonaDis_idZona = value; }
        }
    }
}