using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Datos;
namespace ProyectoIpc2_201325583
{
    public partial class registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Mensaje.Text = "[Mensaje]";
        }
        private int carroCompra;

        protected void registro_Click(object sender, EventArgs e)
        {
            if ((!this.name.Text.Equals("")) && (!this.direccion.Text.Equals("")) && (!this.telefono.Text.Equals("")) && (!this.email.Text.Equals("")) &&
                (!this.nocuenta.Text.Equals("")) && (!this.password.Text.Equals("")))
            {
                NCarroCompra.insertar(this.name.Text);
                DCarroCompra temp = NCarroCompra.buscar(this.name.Text);
                if (temp != null)
                {
                    if (!NSocio.insertar(this.password.Text, this.name.Text, this.telefono.Text, this.email.Text, this.nocuenta.Text, temp.IdCarro, this.direccion.Text))
                    {
                        this.Mensaje.Text = "Error al momento de registrar";
                    }
                    else
                    {
                        this.name.Text = "";
                        this.direccion.Text = "";
                        this.telefono.Text = "";
                        this.email.Text = "";
                        this.nocuenta.Text = "";
                    }
                }
            }
            else
            {
                this.Mensaje.Text = "Falta un campo obligatorio en llenar";
            }
        }

        private string nombreCarro;

        public string NombreCarro
        {
            get { return nombreCarro; }
            set { nombreCarro = value; }
        }
    }
}