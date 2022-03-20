using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIpc2_201325583
{
    public partial class registrarPersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void registro_Click(object sender, EventArgs e)
        {
            //registro de Personal Asociacion
            if (this.email.Text.Equals("") || this.password.Text.Equals(""))
            {
                this.Mensaje.Text = "Email y password son campos obligatorios";
            }
            else
            {
                //registrar
                string nombreE = this.name.Text;
                string telefonoE = this.telefono.Text;
                string puestoE = this.DropDownList1.SelectedItem.Text;
                string emailE = this.email.Text;
                string passwordE = this.password.Text;

                if (!NEmpleado.Insertar(puestoE, nombreE, telefonoE, idComercio, emailE, passwordE))
                {
                    this.Mensaje.Text = "Error al regitrar el Usuario";
                }
                else
                {
                    this.Mensaje.Text = "usuario registrado";
                    this.name.Text = "";
                    this.telefono.Text = "";
                    this.email.Text = "";
                    this.password.Text = "";
                }
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            //regresar
            this.Response.Redirect("administrador.aspx?Parametro=" + idEmpleado.ToString() + "_" + idComercio.ToString());
        }
    }
}