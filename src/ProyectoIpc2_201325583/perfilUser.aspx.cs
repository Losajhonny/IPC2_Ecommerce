using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIpc2_201325583
{
    public partial class perfilUser : System.Web.UI.Page
    {
        private string parametro = "";
        private int idComercio;
        private int idEmpleado;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["Parametro"] != null)
            {
                parametro = Request.Params["Parametro"];
                metSeparador(parametro);
                buscarInsert();
            }
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
            this.Mensaje.Text = "[Mensaje]";
        }

        protected void enviar_Click(object sender, EventArgs e)
        {
            string nombreE = this.nombreApe.Text;
            string emailE = this.email.Text;
            string telefonoE = this.telefono.Text;
            string passE = this.password.Text;
        }

        public void buscarInsert()
        {
            DEmpleado temp = NEmpleado.buscarID(idComercio, idEmpleado);
            this.nombreApe.Text = temp.Nombre;
            this.email.Text = temp.Email;
            this.telefono.Text = temp.Telefono;
            this.password.Text = temp.Password;
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
        }
    }
}