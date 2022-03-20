using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIpc2_201325583
{
    public partial class operario : System.Web.UI.Page
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


        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            NRegistro.insertar("operario cerro sesion --" + DateTime.Now.ToString() + "--", idEmpleado, -1);
            Response.Redirect("inicio.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            NRegistro.insertar("operario visito formulario de cambio en su perfil --" + DateTime.Now.ToString() + "--", idEmpleado, -1);
            this.Response.Redirect("perfilUsuario.aspx?Parametro=" + idEmpleado.ToString() + "_" + idComercio.ToString());
        }
    }
}