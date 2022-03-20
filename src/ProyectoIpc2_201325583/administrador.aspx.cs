using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace ProyectoIpc2_201325583
{
    public partial class administrador : System.Web.UI.Page
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
            NRegistro.insertar("administrador cerro sesion --" + DateTime.Now.ToString() + "--", idEmpleado, -1);
            Response.Redirect("inicio.aspx");
        }

        protected void perfil_Click(object sender, EventArgs e)
        {
            NRegistro.insertar("administrador visito formulario de cambio en su perfil --" + DateTime.Now.ToString() + "--", idEmpleado, -1);
            this.Response.Redirect("perfilUsuario.aspx?Parametro=" + idEmpleado.ToString() + "_" + idComercio.ToString());
        }

        protected void cargarzonas_Click(object sender, EventArgs e)
        {
            if (filezonas.PostedFiles.Count > 1)
            {
                for (int i = 0; i < filezonas.PostedFiles.Count; i++)
                {
                    string fn = System.IO.Path.GetFileName(this.filezonas.PostedFiles[i].FileName);
                    this.filezonas.SaveAs(@"C:\SAC\ZONAS\" + fn);
                    if (!zona(@"C:\SAC\ZONAS\" + fn, fn))
                    {
                        zonaSE(@"C:\SAC\ZONAS\" + fn, fn);
                    }
                }
            }
            else
            {
                string fn = System.IO.Path.GetFileName(this.filezonas.PostedFile.FileName);
                this.filezonas.SaveAs(@"C:\SAC\ZONAS\" + fn);
                if (!zona(@"C:\SAC\ZONAS\" + fn, fn))
                {
                    zonaSE(@"C:\SAC\ZONAS\" + fn, fn);
                }
            }
            NRegistro.insertar("administrador carga las zonas --" + DateTime.Now.ToString() + "--", idEmpleado, -1);
        }

        public Boolean zona(string file, string fn)
        {
            XmlDocument doc = new XmlDocument();
            Boolean error = false;
            XmlNodeList zonas = null;
            XmlNodeList zona = null;
            try
            {
                doc.Load(file);
                zonas = doc.GetElementsByTagName("ZONAS");
                zona = ((XmlElement)zonas[0]).GetElementsByTagName("ZONA");
            }
            catch (Exception ex1)
            {
                moveArchivo(file, fn);
                error = true;
            }

            if (!error)
            {
                foreach (XmlElement nodo in zona)
                {
                    XmlNodeList noZona = nodo.GetElementsByTagName("no_zona");
                    int nozona;
                    try
                    {
                        nozona = Convert.ToInt32(noZona[0].InnerText);
                    }
                    catch (Exception ex2)
                    {
                        moveArchivo(file, fn);
                        error = true;
                        break;
                    }
                    XmlNodeList nombreZona = nodo.GetElementsByTagName("nombre_zona");
                    string nombrezona = "";
                    try
                    {
                        nombrezona = nombreZona[0].InnerText;
                    }
                    catch (Exception ex3)
                    {
                        moveArchivo(file, fn);
                        error = true;
                        break;
                    }

                    XmlNodeList nozonaSup = nodo.GetElementsByTagName("ZONA_no_zona_superior");
                    int zonaSup = -1;
                    try
                    {
                        zonaSup = Convert.ToInt32(nozonaSup[0].InnerText);
                    }
                    catch (Exception ex4) 
                    { 
                        zonaSup = -1; 
                    }
                    //NZonaDis.insertar("", "ZONA", zonaSup, nozona, -1, nombrezona, -1);
                }
            }
            
            return error;
        }

        public Boolean zonaSE(string file, string fn)
        {
            XmlDocument doc = new XmlDocument();
            Boolean ingresado = false;
            XmlNodeList zonas = null;
            XmlNodeList zona = null;
            try
            {
                doc.Load(file);
                zonas = doc.GetElementsByTagName("ZONAS");
                zona = ((XmlElement)zonas[0]).GetElementsByTagName("ZONA");
            }
            catch (Exception ex1){ }

                foreach (XmlElement nodo in zona)
                {
                    XmlNodeList noZona = nodo.GetElementsByTagName("no_zona");
                    int nozona = Convert.ToInt32(noZona[0].InnerText);

                    XmlNodeList nombreZona = nodo.GetElementsByTagName("nombre_zona");
                    string nombrezona = nombreZona[0].InnerText;

                    XmlNodeList nozonaSup = nodo.GetElementsByTagName("ZONA_no_zona_superior");
                    int zonaSup = -1;

                    try
                    {
                        zonaSup = Convert.ToInt32(nozonaSup[0].InnerText);
                    }
                    catch (Exception ex4)
                    {
                        zonaSup = -1;
                    }
                    NZonaDis.insertar("", "ZONA", zonaSup, nozona, -1, nombrezona, -1);
                    ingresado = true;
                }

            return ingresado;
        }

        public void moveArchivo(string file, string fn)
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

        public Boolean zonaVecina(string file, string fn)
        {
            Boolean cat = false;
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(file);
                XmlNodeList zonas = doc.GetElementsByTagName("ZONAS_VECINAS");
                XmlNodeList zona = ((XmlElement)zonas[0]).GetElementsByTagName("ZONA_VECINA");

                foreach (XmlElement nodo in zona)
                {
                    XmlNodeList noZona = nodo.GetElementsByTagName("ZONA_no_zona");
                    int nozona = Convert.ToInt32(noZona[0].InnerText);

                    XmlNodeList nombreZona = nodo.GetElementsByTagName("ZONA_zona_vecina");
                    int zonaV = Convert.ToInt32(nombreZona[0].InnerText);

                    NZonaDis.insertar("", "ZONA_VECINA", -1, nozona, zonaV, "", -1);
                }
                cat = true;
            }
            catch (Exception ex) 
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
            return cat;
        }

        protected void cargarvecinas_Click(object sender, EventArgs e)
        {
            if (filezonasV.PostedFiles.Count > 1)
            {
                for (int i = 0; i < filezonasV.PostedFiles.Count; i++)
                {
                    string fn = System.IO.Path.GetFileName(this.filezonasV.PostedFiles[i].FileName);
                    this.filezonasV.SaveAs(@"C:\SAC\ZONASVECINAS\" + fn);
                    zonaVecina(@"C:\SAC\ZONASVECINAS\" + fn, fn);
                }
            }
            else
            {
                string fn = System.IO.Path.GetFileName(this.filezonasV.PostedFile.FileName);
                this.filezonasV.SaveAs(@"C:\SAC\ZONASVECINAS\" + fn);
                zonaVecina(@"C:\SAC\ZONASVECINAS\" + fn, fn);
            }
            NRegistro.insertar("administrador cargo zonas vecinas --" + DateTime.Now.ToString() + "--", idEmpleado, -1);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //redireccionar al registrarPersonal
            NRegistro.insertar("administrador visito formulario de registro de personal --" + DateTime.Now.ToString() + "--", idEmpleado, -1);
            this.Response.Redirect("registrarPersonal.aspx?Parametro=" + idEmpleado.ToString() + "_" + idComercio.ToString());
        }
    }
}