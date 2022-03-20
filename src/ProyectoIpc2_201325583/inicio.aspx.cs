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
    public partial class inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex != -1)
            {
                GridViewRow gvr = GridView1.SelectedRow;
                ImageButton temp = (ImageButton)gvr.FindControl("ImageButton2");
                temp.Enabled = true;
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (GridView1.SelectedIndex != -1)
            {
                GridViewRow gvr = GridView1.SelectedRow;
                ImageButton temp = (ImageButton)gvr.FindControl("ImageButton2");

                string nombre = gvr.Cells[1].Text;
                string des = gvr.Cells[2].Text;
                string of = gvr.Cells[3].Text;
                double price = 0.0;
                try
                {
                    price = Convert.ToDouble(gvr.Cells[4].Text);
                }
                catch (Exception ex) { }

                DProducto dp = NProducto.buscarC(nombre, des, of, price);

                if (dp != null)
                {
                    string mensaje = "<p><font size=1 color=white>" + dp.Nombre +"</font></p>";
                    DCarroCompra dcc = NCarroCompra.buscar("c1");

                    if (dcc != null)
                    {
                        DCarroProducto t = NCarroCompra.buscarR(dcc.IdCarro, dp.IdProducto);
                        if (t != null)
                        {
                            //si lo encontro actualizar la cantidad
                            NCarroCompra.updateMC(dcc.IdCarro, dp.IdProducto, t.Cantidad);                            
                        }
                        else
                        {
                            NCarroCompra.insertar(dcc.IdCarro, dp.IdProducto);
                        }
                        mensaje = "<p><font size=1 color=white>" + "agregado al carro de compra" + "</font></p>";
                        HttpContext.Current.Response.Write(mensaje);
                        GridView2.DataBind();
                    }
                    else
                    {
                        mensaje = "<p><font size=1 color=white>" + "no se encontro el carro" + "</font></p>";
                        HttpContext.Current.Response.Write(mensaje);
                    }
                }
                else
                {
                    string mensaje1 = "<p><font size=1 color=white>Error no se encontro producto</font></p>";
                    HttpContext.Current.Response.Write(mensaje1);
                }
                GridView1.SelectRow(-1);
                temp.Enabled = false;
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            int seleccion = GridView2.SelectedIndex;
            if (seleccion != -1)
            {
                int cantidad = -1;
                try
                {
                    TextBox txt = (TextBox)GridView2.SelectedRow.FindControl("TextBox1");
                    ImageButton temp = (ImageButton)GridView2.SelectedRow.FindControl("ImageButton4");
                    cantidad = Convert.ToInt32(txt.Text);
                    txt.Enabled = false;
                    temp.Enabled = false;
                    //modificar la cantidad
                    DCarroCompra dcc = NCarroCompra.buscar("c1");
                    //buscar producto por nombre, precio y cantidad
                    string at = GridView2.SelectedRow.Cells[2].Text;
                    double pre = Convert.ToDouble(at);
                    DProducto dp = NProducto.buscarr(pre, GridView2.SelectedRow.Cells[1].Text);

                    if (dp != null)
                    {
                        NCarroCompra.updateC(dcc.IdCarro, dp.IdProducto, cantidad);
                    }
                    GridView2.SelectRow(-1);
                }
                catch (Exception ex)
                {
                    string mensaje1 = "<p><font size=1 color=white>Error al convertir numero</font></p>";
                    HttpContext.Current.Response.Write(mensaje1);
                }
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView2.SelectedIndex != -1)
            {
                GridViewRow gvr = GridView2.SelectedRow;
                ImageButton temp = (ImageButton)gvr.FindControl("ImageButton4");
                TextBox txt = (TextBox)gvr.FindControl("TextBox1");
                txt.Enabled = true;
                temp.Enabled = true;
            }
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            //para eliminar producto en el carro de compra
            if (GridView2.SelectedIndex != -1)
            {
                ImageButton temp = (ImageButton)GridView2.SelectedRow.FindControl("ImageButton4");
                TextBox txt = (TextBox)GridView2.SelectedRow.FindControl("TextBox1");
                string nombre = GridView2.SelectedRow.Cells[1].Text;
                double price = Convert.ToDouble(GridView2.SelectedRow.Cells[2].Text);

                DProducto dp = NProducto.buscarr(price, nombre);
                DCarroCompra dcp = NCarroCompra.buscar("c1");

                if (dp != null && dcp != null)
                {
                    NCarroCompra.deleteDetalle(dcp.IdCarro, dp.IdProducto);
                }
                else
                {
                    string mensaje1 = "<p><font size=1 color=white>No se encontro producto o carro</font></p>";
                    HttpContext.Current.Response.Write(mensaje1);
                }
                temp.Enabled = false;
                txt.Enabled = false;
                GridView2.SelectRow(-1);
                GridView2.DataBind();
            }
        }
    }
}