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
    public partial class formProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["Parametro"] != null)
            {
                parametro = Request.Params["Parametro"];
                metSeparador(parametro);
            }
        }

        private string parametro;
        private int idProducto;
        private int idComercio;
        private int idEmpleado;

        private void metSeparador(string par)
        {
            char[] sep = { '_' };
            string[] temp = par.Split(sep);
            try
            {
                idProducto = Convert.ToInt32(temp[0]);
                idComercio = Convert.ToInt32(temp[1]);
                idEmpleado = Convert.ToInt32(temp[2]);
            }
            catch (Exception ex) { par = ex.Message; }
        }

        private void buscarInsert()
        {
            DProducto temp = NProducto.buscarID(idProducto);
            if (temp != null)
            {
                this.nombreT.Text = temp.Nombre;
                this.descripcionT.Text = temp.Descripcion;
                this.ofertaT.Text = temp.Oferta;
                this.precioT.Text = temp.Precio.ToString();
                this.urlPT.Text = temp.DocMultimedia;
                string tpp = temp.TipoProducto.ToLower();

                this.Image1.ImageUrl = temp.DocMultimedia;

                for (int i = 0; i < DropDownList1.Items.Count; i++)
                {
                    string tp = DropDownList1.Items[i].Text.ToLower();
                    if (tp.Equals(tpp))
                    {
                        this.DropDownList1.Items[i].Selected = true;
                        break;
                    }
                }
            }
        }

        protected void enviar_Click(object sender, EventArgs e)
        {
            //actualizar datos
            if (!(this.nombreT.Text.Equals("") && this.descripcionT.Text.Equals("") && this.ofertaT.Text.Equals("") && this.precioT.Text.Equals("") && this.urlPT.Text.Equals("")))
            {

                double price;
                try
                {
                    price = Convert.ToDouble(this.precioT.Text);
                    if (!NProducto.update(idProducto, this.nombreT.Text, this.DropDownList1.SelectedItem.Text, this.descripcionT.Text, this.ofertaT.Text, price, this.urlPT.Text))
                    {
                        this.Mensaje.Text = "No se pudo cambiar el Email del usuario";
                    }
                }
                catch (Exception ex)
                {
                    this.Mensaje.Text = "Dato erroneo en precio";
                }
            }
            else
            {
                this.Mensaje.Text = "Todos los campos son obligatorios";
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                this.buscarInsert();
            }
            else
            {
                this.nombreT.Text = "";
                this.descripcionT.Text = "";
                this.ofertaT.Text = "";
                this.precioT.Text = "";
                this.urlPT.Text = "";
                this.Image1.ImageUrl = "";
            }
        }


        protected void regresar_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("responsableCom.aspx?Parametro=" + idEmpleado.ToString() + "_" + idComercio.ToString());
        }
    }
}