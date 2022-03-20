using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Negocio;

namespace ProyectoIpc2_201325583
{
    public partial class formComercio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void enviar_Click(object sender, EventArgs e)
        {
            if (this.email.Text.Equals(""))
            {
                this.Mensaje.Text = "Usuario Obligatorio";
            }
            else
            {
                Regex patron = new Regex(@"^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S{8,32}$");

                if (!patron.IsMatch(this.password.Text))
                {
                    this.Mensaje.Text = "Requisitos contraseña: \n"
                        + "8 caracteres minimo \n"
                        + "Al menos una letra mayuscula \n"
                        + "Al menos una letra minuscula \n"
                        + "Al menos un numero";
                }
                else
                {
                    if (this.password.Text.Equals(""))
                    {
                        this.Mensaje.Text = "Ingrese un password";
                    }
                    else
                    {
                        if (!this.listaradio.Items[0].Selected && !this.listaradio.Items[1].Selected && !this.listaradio.Items[2].Selected)
                        {
                            this.Mensaje.Text = "seleccione un tipo de producto";
                        }
                        else
                        {
                            for (int i = 0; i < listaradio.Items.Count; i++)
                            {
                                if (listaradio.Items[i].Selected)
                                {
                                    string min = listaradio.Items[i].Text.ToLower();
                                    this.ingresarComercio(min);
                                    break;
                                }

                            }
                        }
                    }
                }
            }
        }

        public void limpiarCampos()
        {
            this.name.Text = "";
            this.siglas.Text = "";
            this.direccion.Text = "";
            this.email.Text = "";
            this.telefono.Text = "";
            this.fax.Text = "";
            this.password.Text = "";
        }

        public void ingresarComercio(string tipoProducto)
        {
            if (NComercio.Insertar(this.name.Text, this.siglas.Text, this.direccion.Text, this.email.Text, this.telefono.Text, 0, tipoProducto, this.fax.Text))
            {
                DComercio temp = NComercio.buscar(this.name.Text, this.siglas.Text, this.direccion.Text, this.email.Text, this.telefono.Text, 0, tipoProducto, this.fax.Text);

                if (temp != null)
                {
                    NInventario.insertar(this.siglas.Text, temp.IdComercio);
                    NEmpleado.Insertar("responsable comercio", "", "", temp.IdComercio, this.email.Text, this.password.Text);
                    this.Mensaje.Text = "Solicitud Enviado";
                    limpiarCampos();
                    Response.Redirect("inicio.aspx");
                }
            }
            else
            {
                this.Mensaje.Text = "Ocurrio algun error en enviar";
            }
        }
    }
}