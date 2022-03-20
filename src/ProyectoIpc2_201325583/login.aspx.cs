using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Datos;
using System.Data;

namespace ProyectoIpc2_201325583
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Mensaje.Text = "[Mensaje]";
        }

        protected void log_Click(object sender, EventArgs e)
        {
            
        }

        public void verificarDatos(string rol)
        {
            if (rol.Equals("Gerente"))
            {
                DEmpleado temp = NEmpleado.buscarE(this.name.Text, this.password.Text);
                if (temp != null)
                {
                    if (NEmpleado.buscar(this.name.Text, this.password.Text) && temp.Puesto.Equals("gerente"))
                    {
                        Session.Add("usuario", "gerente");
                        this.Response.Redirect("gerente.aspx?Parametro=" + temp.IdEmpleado.ToString() + "_" + temp.Comercio_idcomercio.ToString());
                    }
                    else
                    {
                        this.Mensaje.Text = "Usuario no encontrado";
                    }
                }
                else
                {
                    this.Mensaje.Text = "Usuario no encontrado";
                }                
            }
            else
            {
                if (rol.Equals("Socio"))
                {
                    //buscar socio
                    if (NSocio.buscar(this.name.Text, this.password.Text))
                    {
                        Session.Add("usuario", "socio");
                        this.Response.Redirect("socio.aspx");
                    }
                    else
                    {
                        this.Mensaje.Text = "Usuario no encontrado";
                    }
                }
                else
                {
                    if (rol.Equals("Responsable abastecimiento"))
                    {
                        DEmpleado temp = NEmpleado.buscarE(this.name.Text, this.password.Text);
                        if (temp != null)
                        {
                            if (NEmpleado.buscar(this.name.Text, this.password.Text) && temp.Puesto.Equals("responsable abastecimiento"))
                            {
                                if (NEmpleado.habilitado(this.name.Text, this.password.Text))
                                {
                                    Session.Add("usuario", "responsableAbas");
                                    this.Response.Redirect("responsableAbas.aspx?Parametro=" + temp.IdEmpleado.ToString() + "_" + temp.Comercio_idcomercio.ToString());
                                }
                                else
                                {
                                    this.Mensaje.Text = "Comercio sin habilitar";
                                }
                            }
                            else
                            {
                                this.Mensaje.Text = "Usuario no encontrado";
                            }
                        }
                        else
                        {
                            this.Mensaje.Text = "Usuario no encontrado";
                        }
                    }
                    else
                    {
                        if (rol.Equals("Responsable Comercio"))
                        {
                            DEmpleado temp = NEmpleado.buscarE(this.name.Text, this.password.Text);
                            if (temp != null)
                            {
                                if (NEmpleado.habilitado(this.name.Text, this.password.Text) && temp.Puesto.Equals("responsable comercio"))
                                {
                                    Session.Add("usuario", "responsablecom");
                                    this.Response.Redirect("responsableCom.aspx?Parametro=" + temp.IdEmpleado.ToString() + "_" + temp.Comercio_idcomercio.ToString());
                                }
                                else
                                {
                                    this.Mensaje.Text = "Comercio sin habilitar";
                                }
                            }
                            else
                            {
                                this.Mensaje.Text = "Usuario no encontrado";
                            }
                        }
                        else
                        {
                            if (rol.Equals("Operario"))
                            {
                                DEmpleado temp = NEmpleado.buscarE(this.name.Text, this.password.Text);
                                if (temp != null)
                                {
                                    if (NEmpleado.buscar(this.name.Text, this.password.Text) && temp.Puesto.Equals("operario"))
                                    {
                                        Session.Add("usuario", "operario");
                                        this.Response.Redirect("operario.aspx?Parametro=" + temp.IdEmpleado.ToString() + "_" + temp.Comercio_idcomercio.ToString());
                                    }
                                    else
                                    {
                                        this.Mensaje.Text = "Usuario no encontrado";
                                    }
                                }
                                else
                                {
                                    this.Mensaje.Text = "Usuario no encontrado";
                                }
                            }
                            else
                            {
                                if (rol.Equals("Administrador"))
                                {
                                    DEmpleado temp = NEmpleado.buscarE(this.name.Text, this.password.Text);
                                    if (temp != null)
                                    {
                                        if (NEmpleado.buscar(this.name.Text, this.password.Text) && temp.Puesto.Equals("administrador"))
                                        {
                                            Session.Add("usuario", "administrador");
                                            this.Response.Redirect("administrador.aspx?Parametro=" + temp.IdEmpleado.ToString() + "_" + temp.Comercio_idcomercio.ToString());
                                        }
                                        else
                                        {
                                            this.Mensaje.Text = "Usuario no encontrado";
                                        }
                                    }
                                    else
                                    {
                                        this.Mensaje.Text = "Usuario no encontrado";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void log_Click1(object sender, EventArgs e)
        {
            string contra = this.password.Text;
            Regex patron = new Regex(@"^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S{8,32}$");

            if (!patron.IsMatch(contra))
            {
                this.Mensaje.Text = "Requisitos contraseña: \n"
                    + "8 caracteres minimo \n"
                    + "Al menos una letra mayuscula \n"
                    + "Al menos una letra minuscula \n"
                    + "Al menos un numero";
            }
            else
            {
                //buscar usuaario y password coincidencia
                this.Mensaje.Text = "Correcto";
                this.verificarDatos(this.DropDownList1.SelectedItem.Text);
            }
        }
    }
}