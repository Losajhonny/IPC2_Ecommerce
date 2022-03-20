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
    public partial class perfilComercio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["Parametro"] != null)
            {
                parametro = Request.Params["Parametro"];
                metSeparador(parametro);
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

        private string parametro = "";
        private int idComercio;
        private int idEmpleado;

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

        public void buscarInsert()
        {
            DComercio temp = NComercio.buscar(idComercio);
            this.direccion.Text = temp.Direccion;
            this.email.Text = temp.Email;
            this.fax.Text = temp.Fax;
            this.telefono.Text = temp.Telefono;
        }

        protected void enviar_Click(object sender, EventArgs e)
        {
            string dirF = this.direccion.Text;
            string correo = this.email.Text;
            string faX = this.fax.Text;
            string tel = this.telefono.Text;

            if (!(dirF.Equals("") && correo.Equals("") && faX.Equals("") && tel.Equals("")))
            {
                if (!NEmpleado.update(idComercio, idEmpleado, correo))
                {
                    this.Mensaje.Text = "No se pudo cambiar el Email del usuario";
                }
                if (NComercio.update(idComercio, dirF, correo, tel, faX))
                {
                    this.Mensaje.Text = "Actualizado";
                }
                else
                {
                    this.Mensaje.Text = "Intento de actualizar fallida";
                }
            }
            else
            {
                this.Mensaje.Text = "Todos los campos son obligatorios";
            }
            
        }

        protected void regresar_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("responsableCom.aspx?Parametro=" + idEmpleado.ToString() + "_" + idComercio.ToString());
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                this.buscarInsert();
            }
            else
            {
                this.direccion.Text = "";
                this.fax.Text = "";
                this.email.Text = "";
                this.telefono.Text = "";
            }
        }
    }
}