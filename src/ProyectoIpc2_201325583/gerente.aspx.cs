using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Negocio;
using System.Text.RegularExpressions;
using System.IO;
using Datos;
using System.Data.SqlClient;

namespace ProyectoIpc2_201325583
{
    public partial class gerente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"].ToString().Equals(""))
                {
                    Response.Redirect("inicio.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("inicio.aspx");
            }
            if (Request.Params["Parametro"] != null)
            {
                parametro = Request.Params["Parametro"];
                metSeparador(parametro);
            }
        }
        private string parametro = "";
        private int idEmpleado;
        private int idComercio;

        private void metSeparador(string par)
        {
            char[] sep = { '_' };
            string[] temp = par.Split(sep);
            try
            {
                idEmpleado = Convert.ToInt32(temp[0]);
                idComercio = Convert.ToInt32(temp[1]);
            }
            catch (Exception ex) { par = ex.Message; }
        }

        protected void salir_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            NRegistro.insertar("gerente cerro sesion --" + DateTime.Now.ToString() + "--", idEmpleado, -1);
            Response.Redirect("inicio.aspx");
        }
        
        public String urlArchi(string file)
        {
            string archi = "";
            Regex exp = new Regex(@"^[\w+|\.]+_\d{6}\.\w+");
            if (exp.IsMatch(file))
            {
                 archi = @"C:\SAC\CATALOGOPRODUCTOS\" + file;
            }
            return archi;
        }

        public Boolean isArchivoCorrecto(string file)
        {
            //Regex exp = new Regex(@"^\w+_\d{6}\.\w+"); //aslkdf_230123.xml
            Regex exp = new Regex(@"^[\w+|\.]+_\d{6}\.\w+");
            if (exp.IsMatch(file))
            {
                this.filecategoria.SaveAs(@"C:\SAC\CATALOGOPRODUCTOS\" + file);
                return true;
            }
            else
            {
                this.Mensaje.Text = "Archivo no cumple con el formato establecido";
                this.filecategoria.SaveAs(@"C:\SAC\ERRORES\" + file);
                return false;
            }
        }

        public void EnviarCarpeta(string file)
        {
            this.filecategoria.SaveAs(@"C:\SAC\CATALOGOPRODUCTOS\" + file);
        }

        public Boolean producto(string file, string nombre, string fn)
        {
            Boolean cat = false;
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(file);
                XmlNodeList productos = doc.GetElementsByTagName("PRODUCTOS");
                XmlNodeList lista = ((XmlElement)productos[0]).GetElementsByTagName("PRODUCTO");
                
                foreach (XmlElement nodo in lista)
                {
                    XmlNodeList nombreP = nodo.GetElementsByTagName("nombre_producto");
                    string nombrepd = nombreP[0].InnerText;
                    
                    XmlNodeList tipoP = nodo.GetElementsByTagName("tipo_producto");
                    string tipoProducto = tipoP[0].InnerText;

                    XmlNodeList descripcionP = nodo.GetElementsByTagName("descripcion");
                    string descripcion = descripcionP[0].InnerText;

                    XmlNodeList ofertaP = nodo.GetElementsByTagName("ofertado");
                    string oferta = ofertaP[0].InnerText;

                    XmlNodeList multP = nodo.GetElementsByTagName("multimedia");
                    string multimedia = multP[0].InnerText;

                    XmlNodeList precioP = nodo.GetElementsByTagName("precio");
                    double precio = Convert.ToDouble(precioP[0].InnerText);

                    XmlNodeList existen = nodo.GetElementsByTagName("existencia");
                    int existencia = Convert.ToInt32(existen[0].InnerText);

                    XmlNodeList noCatP = nodo.GetElementsByTagName("CATEGORIA_PRODUCTO_no_categoria");
                    int nocategoria = Convert.ToInt32(noCatP[0].InnerText);

                    DCategoria tempca = NCategoria.Buscar(nocategoria);
                    DComercio tempco = NComercio.buscar(0);

                    NProducto.Insertar(precio, nombrepd, tipoProducto, descripcion, multimedia, oferta);
                    DProducto tempP = NProducto.buscar(precio, nombrepd, tipoProducto, descripcion, multimedia, oferta);

                    if (tempco != null)
                    {
                        DInventario tempi = NInventario.buscar("A.C.C", 0);
                        if (tempi != null)
                        {
                            SqlConnection sqlconection = new SqlConnection();
                            sqlconection = Conexion.conect();
                            Conexion.abrirConexion(sqlconection);
                            SqlCommand comando = new SqlCommand("insert into InventarioProducto(Inventario_idInventario, Producto_idProducto, existencia)"
                                + "values(@Inventario_idInventario, @Producto_idProducto, @existencia)", sqlconection);
                            comando.Parameters.AddWithValue("@Inventario_idInventario", tempi.IdInventario);
                            comando.Parameters.AddWithValue("@Producto_idProducto", System.Data.SqlDbType.Int).Value = tempP.IdProducto;
                            comando.Parameters.AddWithValue("@existencia", existencia);

                            comando.ExecuteNonQuery();
                            Conexion.cerrarConexion(sqlconection);
                        }
                    }
                }
                cat = true;
            }
            catch (Exception ex)
            {
                this.Mensaje.Text = "Error al cargar productos";
                if (!Directory.Exists(@"C:\SAC\ERRORES\" + fn))
                {
                    Directory.Move(file, @"C:\SAC\ERRORES\" + fn);
                }
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }
            return cat;
        }

        public Boolean categoria(string file, string fn)
        {
            Boolean cat = false;
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(file);
                XmlNodeList categoria = doc.GetElementsByTagName("CATEGORIAS_PRODUCTO");
                XmlNodeList lista = ((XmlElement)categoria[0]).GetElementsByTagName("CATEGORIA");

                foreach (XmlElement nodo in lista)
                {
                    XmlNodeList noCategoria = nodo.GetElementsByTagName("no_categoria");
                    int nocategoria = Convert.ToInt32(noCategoria[0].InnerText);

                    XmlNodeList nombreCategoria = nodo.GetElementsByTagName("nombre_categoria");
                    string nombre = nombreCategoria[0].InnerText;

                    NCategoria.Insertar("", nombre, nocategoria);
                }
                cat = true;
            }
            catch (Exception ex)
            {
                //if (!Directory.Exists(@"C:\SAC\ERRORES\" + fn))
                //{
                //    Directory.Move(file, @"C:\SAC\ERRORES\" + fn);
                //}
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
                cat = false;
            }
            return cat;
        }

        
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void alta_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox temp = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                if (temp.Checked)
                {
                    string nombre = GridView1.Rows[i].Cells[0].Text;
                    string siglas = GridView1.Rows[i].Cells[1].Text;
                    string direccion = GridView1.Rows[i].Cells[2].Text;
                    string email = GridView1.Rows[i].Cells[3].Text;
                    string telefono = GridView1.Rows[i].Cells[4].Text;
                    string tipoProducto = GridView1.Rows[i].Cells[5].Text;
                    string fax = GridView1.Rows[i].Cells[6].Text;

                    DComercio cTemp = NComercio.buscar(nombre, siglas, direccion, email, telefono, tipoProducto, fax);
                    cTemp.Autorizacion = 1;
                    NComercio.actualizar(cTemp);
                    temp.Enabled = false;
                    
                    //break;
                }
            }
            NRegistro.insertar("gerente presiono boton de dar de alta a a comercios --" + DateTime.Now.ToString() + "--", idEmpleado, -1);
        }

        protected void actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                GridView1.DataBind();
            }
            catch (Exception ex) { }
            NRegistro.insertar("gerente actualizo la tabla de la solicitudes de alta --" + DateTime.Now.ToString() + "--", idEmpleado, -1);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        protected void cargaC_Click(object sender, EventArgs e)
        {
            if (this.filecategoria.PostedFiles.Count > 1)
            {
                for (int i = 0; i < this.filecategoria.PostedFiles.Count; i++)
                {
                    string fn = System.IO.Path.GetFileName(this.filecategoria.PostedFiles[i].FileName);
                    this.filecategoria.SaveAs(@"C:\SAC\CATEGORIAS\" + fn);
                    if (!categoria(@"C:\SAC\CATEGORIAS\" + fn, fn))
                    {
                        this.filecategoria.SaveAs(@"C:\SAC\CATALOGOPRODUCTOS\" + fn);
                        char[] sep = { '_' };
                        string[] al = fn.Split(sep);

                        if (this.isArchivoCorrecto(fn))
                        {
                            producto(@"C:\SAC\CATALOGOPRODUCTOS\" + fn, al[0], fn);
                        }
                    }
                }
            }
            else
            {
                string fn = System.IO.Path.GetFileName(this.filecategoria.PostedFile.FileName);
                this.filecategoria.SaveAs(@"C:\SAC\CATEGORIAS\" + fn);
                if (!categoria(@"C:\SAC\CATEGORIAS\" + fn, fn))
                {
                    this.filecategoria.SaveAs(@"C:\SAC\CATALOGOPRODUCTOS\" + fn);
                    char[] sep = { '_' };
                    string[] al = fn.Split(sep);

                    if (this.isArchivoCorrecto(fn))
                    {
                        producto(@"C:\SAC\CATALOGOPRODUCTOS\" + fn, al[0], fn);
                    }
                }
            }
            NRegistro.insertar("gerente carga archivos --" + DateTime.Now.ToString() + "--", idEmpleado, -1);
        }

        protected void perfil_Click(object sender, EventArgs e)
        {
            NRegistro.insertar("gerente visito formulario de cambio en su perfil --" + DateTime.Now.ToString() + "--", idEmpleado, -1);
            this.Response.Redirect("perfilUsuario.aspx?Parametro=" + idEmpleado.ToString() + "_" + idComercio.ToString());
        }

    }
}