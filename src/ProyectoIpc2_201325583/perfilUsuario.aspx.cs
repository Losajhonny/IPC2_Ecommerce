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
    public partial class formUsuario : System.Web.UI.Page
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

        public void buscarInsert()
        {
            DEmpleado temp = NEmpleado.buscarID(idComercio, idEmpleado);
            this.TextBox1.Text = temp.Nombre;
            this.TextBox2.Text = temp.Telefono;
            this.email.Text = temp.Email;
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

        protected void enviar_Click(object sender, EventArgs e)
        {
            string nom = this.TextBox1.Text;
            string correo = this.email.Text;
            string pass = this.password.Text;
            string tel = this.TextBox2.Text;

            if (!(nom.Equals("") && correo.Equals("") && pass.Equals("") && tel.Equals("")))
            {
                if (!NEmpleado.update(idComercio, idEmpleado, nom, tel, correo, pass))
                {
                    this.Mensaje.Text = "No se pudo cambiar el Email del usuario";
                }
            }
            else
            {
                this.Mensaje.Text = "Todos los campos son obligatorios";
            }
        }

        protected void regresar_Click(object sender, EventArgs e)
        {
            DEmpleado temp = NEmpleado.buscarID(idComercio, idEmpleado);
            string rol = temp.Puesto.ToLower();
            if (rol.Equals("administrador"))
            {
                this.Response.Redirect("administrador.aspx?Parametro=" + idEmpleado.ToString() + "_" + idComercio.ToString());
            }
            else
            {
                if (rol.Equals("socio"))
                {
                    this.Response.Redirect("socio.aspx?Parametro=" + idEmpleado.ToString() + "_" + idComercio.ToString());
                }
                else
                {
                    if (rol.Equals("gerente"))
                    {
                        this.Response.Redirect("gerente.aspx?Parametro=" + idEmpleado.ToString() + "_" + idComercio.ToString());
                    }
                    else
                    {
                        if (rol.Equals("operario"))
                        {
                            this.Response.Redirect("operario.aspx?Parametro=" + idEmpleado.ToString() + "_" + idComercio.ToString());
                        }
                        else
                        {
                            if (rol.Equals("responsable abastecimiento"))
                            {
                                this.Response.Redirect("responsableAbas.aspx?Parametro=" + idEmpleado.ToString() + "_" + idComercio.ToString());
                            }
                        }
                    }
                }
            }

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                this.buscarInsert();
            }
            else
            {
                this.TextBox1.Text = "";
                this.TextBox2.Text = "";
                this.email.Text = "";
                this.password.Text = "";
            }
        }
    }
}