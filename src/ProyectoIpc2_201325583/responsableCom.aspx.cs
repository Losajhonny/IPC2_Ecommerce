using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace ProyectoIpc2_201325583
{
    public partial class responsableCom : System.Web.UI.Page
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

        protected void salir_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            NRegistro.insertar("responsable de comercio cerro sesion --" + DateTime.Now.ToString() + "--", idEmpleado, -1);
            Response.Redirect("inicio.aspx");
        }

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
            this.confiIdComercio.Text = idComercio.ToString();
        }

        protected void perfil_Click(object sender, EventArgs e)
        {
            NRegistro.insertar("responsable de comercio visito formulario de cambio en su perfil --" + DateTime.Now.ToString() + "--", idEmpleado, -1);
            this.Response.Redirect("perfilComercio.aspx?Parametro=" + idEmpleado.ToString() + "_" + idComercio.ToString());
        }

        protected void enviar_Click(object sender, EventArgs e)
        {
            if (this.fileseleccion.PostedFiles.Count > 1)
            {
                for (int i = 0; i < fileseleccion.PostedFiles.Count; i++)
                {
                    string fn = System.IO.Path.GetFileName(this.fileseleccion.PostedFiles[i].FileName);
                    this.fileseleccion.SaveAs(@"C:\SAC\CATALOGOPRODUCTOS\" + fn);
                    char[] sep = { '_' };
                    string[] al = fn.Split(sep);

                    if (this.isArchivoCorrecto(fn))
                    {
                        producto(@"C:\SAC\CATALOGOPRODUCTOS\" + fn, al[0], fn);
                    }
                }
            }
            else
            {
                string fn = System.IO.Path.GetFileName(this.fileseleccion.PostedFile.FileName);
                this.fileseleccion.SaveAs(@"C:\SAC\CATALOGOPRODUCTOS\" + fn);
                char[] sep = { '_' };
                string[] al = fn.Split(sep);
                if (this.isArchivoCorrecto(fn))
                {
                    producto(@"C:\SAC\CATALOGOPRODUCTOS\" + fn, al[0], fn);
                }
            }

            NRegistro.insertar("responsable de comercio carga productos --" + DateTime.Now.ToString() + "--", idEmpleado, -1);
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
                    DComercio tempco = NComercio.buscar(idComercio);
                    DProducto aux = NProducto.buscar(precio, nombrepd, tipoProducto, descripcion, multimedia, oferta);

                    if (aux == null)
                    {
                        NProducto.Insertar(precio, nombrepd, tipoProducto, descripcion, multimedia, oferta);
                        DProducto tempP = NProducto.buscar(precio, nombrepd, tipoProducto, descripcion, multimedia, oferta);
                        NCategoriaProducto.Insertar(tempco.IdComercio, tempP.IdProducto, nocategoria);

                        if (tempco != null)
                        {
                            DInventario tempi = NInventario.buscar(tempco.Siglas, idComercio);
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
                    else
                    {
                        DInventario tempi = NInventario.buscar(tempco.Siglas, idComercio);
                        if (tempi != null)
                        {
                            SqlConnection sqlconection = new SqlConnection();
                            sqlconection = Conexion.conect();
                            Conexion.abrirConexion(sqlconection);
                            SqlCommand comando = new SqlCommand("insert into InventarioProducto(Inventario_idInventario, Producto_idProducto, existencia)"
                                + "values(@Inventario_idInventario, @Producto_idProducto, @existencia)", sqlconection);
                            comando.Parameters.AddWithValue("@Inventario_idInventario", tempi.IdInventario);
                            comando.Parameters.AddWithValue("@Producto_idProducto", System.Data.SqlDbType.Int).Value = aux.IdProducto;
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
                this.Mensaje.Text = "Error al cargar los productos";
                try
                {
                    if (!Directory.Exists(@"C:\SAC\ERRORES\" + fn))
                    {
                        Directory.Move(file, @"C:\SAC\ERRORES\" + fn);
                    }
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                    }
                }
                catch (Exception exe)
                {
                    //<FONT FACE="arial" SIZE=5 COLOR=red>Tipo para formatear</FONT>
                    //string mensaje = "<p class=" + (char)34 + "title" + (char)34 + ">Error al pasar archivo</p>";
                    string mensaje = "<p><font face=" + (char)34 + "arial" + (char)34 + " size=2 color=white>Error al pasar archivo</font></p>";
                    HttpContext.Current.Response.Write(mensaje);
                }
            }
            return cat;
        }

        public void insertarDetalleInvP(int idInventario, int idProducto, int existencia)
        {
            //NInventario.insertarD(tempi.IdInventario, tempP.IdProducto, existencia);
            
        }

        public Boolean isArchivoCorrecto(string file)
        {
            //Regex exp = new Regex(@"^\w+_\d{6}\.\w+"); //aslkdf_230123.xml
            Regex exp = new Regex(@"^[\w+|\.]+_\d{6}\.\w+");
            if (exp.IsMatch(file))
            {
                this.fileseleccion.SaveAs(@"C:\SAC\CATALOGOPRODUCTOS\" + file);
                return true;
            }
            else
            {
                this.Mensaje.Text = "Archivo no cumple con el formato establecido";
                this.fileseleccion.SaveAs(@"C:\SAC\ERRORES\" + file);
                return false;
            }
        }

        protected void SqlDataSource3_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.GridView6.Rows.Count; i++)
            {
                CheckBox temp = (CheckBox)GridView6.Rows[i].FindControl("CheckBox1");
                if (temp.Checked)
                {
                    string nombrepr = GridView6.Rows[i].Cells[0].Text;
                    string descripcion = GridView6.Rows[i].Cells[1].Text;
                    string tipoPr = GridView6.Rows[i].Cells[2].Text;
                    string oferta = GridView6.Rows[i].Cells[3].Text;
                    double precioP = Convert.ToDouble(GridView6.Rows[i].Cells[4].Text);

                    DProducto ptemp = NProducto.buscarT(precioP, nombrepr, tipoPr, descripcion, oferta);

                    try
                    {
                        ptemp.Existencia = 1;
                        NProducto.update(ptemp);
                    }
                    catch (Exception exs) { }
                }
                else
                {
                    string nombrepr = GridView6.Rows[i].Cells[0].Text;
                    string descripcion = GridView6.Rows[i].Cells[1].Text;
                    string tipoPr = GridView6.Rows[i].Cells[2].Text;
                    string oferta = GridView6.Rows[i].Cells[3].Text;
                    double precioP = Convert.ToDouble(GridView6.Rows[i].Cells[4].Text);
                    
                    DProducto ptemp = NProducto.buscarT(precioP, nombrepr, tipoPr, descripcion, oferta);
                    try
                    {
                        ptemp.Existencia = 0;
                        NProducto.update(ptemp);
                    }
                    catch (Exception exs) { }
                    
                }
            }
        }

        public void cargarImagen()
        {
            for (int i = 0; i < this.GridView6.Rows.Count; i++)
            {
                Image temp = (Image)GridView6.Rows[i].FindControl("Image1");
                string nombrepr = GridView6.Rows[i].Cells[0].Text;
                string descripcion = GridView6.Rows[i].Cells[1].Text;
                string tipoPr = GridView6.Rows[i].Cells[2].Text;
                string oferta = GridView6.Rows[i].Cells[3].Text;
                double precioP = Convert.ToDouble(GridView6.Rows[i].Cells[4].Text);

                DProducto ptemp = NProducto.buscarT(precioP, nombrepr, tipoPr, descripcion, oferta);
                if (ptemp != null)
                {
                    temp.ImageUrl = ptemp.DocMultimedia;
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //editar grid6 propios
            //this.Response.Redirect("responsableCom.aspx?Parametro=" + temp.IdEmpleado.ToString() + "_" + temp.Comercio_idcomercio.ToString());
            
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            if (GridView6.SelectedIndex != -1)
            {
                string nombrepr = GridView6.SelectedRow.Cells[0].Text;
                string descripcion = GridView6.SelectedRow.Cells[1].Text;
                string tipoPr = GridView6.SelectedRow.Cells[2].Text;
                string oferta = GridView6.SelectedRow.Cells[3].Text;
                double precioP = Convert.ToDouble(GridView6.SelectedRow.Cells[4].Text);

                DProducto ptemp = NProducto.buscarT(precioP, nombrepr, tipoPr, descripcion, oferta);
                if (ptemp != null)
                {

                    NRegistro.insertar("responsable de comercio realiza cambios en los datos de un producto --" + DateTime.Now.ToString() + "--", idEmpleado, -1);
                    this.Response.Redirect("formProducto.aspx?Parametro=" + ptemp.IdProducto.ToString() + "_" + idComercio.ToString() + "_" + idEmpleado.ToString());
                }
            }
            else
            {
                string mensaje = "<p><font face=" + (char)34 + "arial" + (char)34 + " size=2 color=white>Seleccione un producto</font></p>";
                HttpContext.Current.Response.Write(mensaje);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (!(GridView2.SelectedIndex == -1))
            {
                string nombrepr = GridView2.SelectedRow.Cells[0].Text;
                string descripcion = GridView2.SelectedRow.Cells[1].Text;
                string tipoPr = GridView2.SelectedRow.Cells[2].Text;
                string oferta = GridView2.SelectedRow.Cells[3].Text;
                double precioP = Convert.ToDouble(GridView2.SelectedRow.Cells[4].Text);

                DProducto ptemp = NProducto.buscarT(precioP, nombrepr, tipoPr, descripcion, oferta);
                if (ptemp != null)
                {
                    NRegistro.insertar("responsable de comercio realiza cambios en los datos de un producto --" + DateTime.Now.ToString() + "--", idEmpleado, -1);
                    this.Response.Redirect("formProducto.aspx?Parametro=" + ptemp.IdProducto.ToString() + "_" + idComercio.ToString() + "_" + idEmpleado.ToString());
                }
            }
            else
            {
                string mensaje = "<p><font face=" + (char)34 + "arial" + (char)34 + " size=2 color=white>Seleccione un producto</font></p>";
                HttpContext.Current.Response.Write(mensaje);
            }
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.GridView2.Rows.Count; i++)
            {
                CheckBox temp = (CheckBox)GridView2.Rows[i].FindControl("CheckBox1");
                if (temp.Checked)
                {
                    string nombrepr = GridView2.Rows[i].Cells[0].Text;
                    string descripcion = GridView2.Rows[i].Cells[1].Text;
                    string tipoPr = GridView2.Rows[i].Cells[2].Text;
                    string oferta = GridView2.Rows[i].Cells[3].Text;
                    double precioP = Convert.ToDouble(GridView2.Rows[i].Cells[4].Text);

                    DProducto ptemp = NProducto.buscarT(precioP, nombrepr, tipoPr, descripcion, oferta);

                    try
                    {
                        ptemp.Existencia = 1;
                        NProducto.update(ptemp);
                    }
                    catch (Exception exs) { }
                }
                else
                {
                    string nombrepr = GridView2.Rows[i].Cells[0].Text;
                    string descripcion = GridView2.Rows[i].Cells[1].Text;
                    string tipoPr = GridView2.Rows[i].Cells[2].Text;
                    string oferta = GridView2.Rows[i].Cells[3].Text;
                    double precioP = Convert.ToDouble(GridView2.Rows[i].Cells[4].Text);

                    DProducto ptemp = NProducto.buscarT(precioP, nombrepr, tipoPr, descripcion, oferta);
                    try
                    {
                        ptemp.Existencia = 0;
                        NProducto.update(ptemp);
                    }
                    catch (Exception exs) { }

                }
            }
        }
    }
}