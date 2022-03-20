<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="ProyectoIpc2_201325583.inicio" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="content-type" content="text/html; charset=utf-8" />
<title>Asociacion C.C.</title>
<meta name="keywords" content="" />
<meta name="description" content="" />
<link href="inicio/style.css" rel="stylesheet" type="text/css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
<div id="header-wrapper">
	<div id="header">
		<div id="menu">
			<ul>
				<li><a href="login.aspx" class="first">Login</a></li>
				<li class="current_page_item"><a href="registrar.aspx">registrar socio</a></li>
				<li><a href="formComercio.aspx">Solicitud on-line</a></li><!-- class="current_page_item" -->
				<li><a href="#">registrar Personal</a></li>
			</ul>
		</div>
		<div id="search">
				<fieldset>
					<input type="text" name="s" id="search-text" size="15" />
					<input type="submit" id="search-submit" value="GO" />
				</fieldset>
			</div>
	</div>
</div>
<div id="logo">
	<h1><a href="responsableCom.aspx">As</a>ociacion</h1>
	<p>centro comercial</p>
</div><hr />
<div id="page"><div class="inner_copy"></div>
	<div id="page-bgtop">
		<div id="content">
			<div class="post">
				<p class="meta">&nbsp;</p>
				<h2 class="title"><a href="#">Productos</a></h2>
				<div class="entry">
					<p>
                        <center>
                        <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="243px" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="nombre" DataValueField="nombre" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" ViewStateMode="Enabled">
                        </asp:DropDownList>
                        </center>
                    </p>
                    <asp:Panel ID="Panel1" runat="server" Height="644px" Width="620px" ScrollBars="Horizontal">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="580px" Height="300px" HorizontalAlign="Center">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Image ID="Image1" runat="server" Height="80px" ImageUrl='<%# Eval("docMultimedia") %>' Width="80px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                                <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                                <asp:BoundField DataField="oferta" HeaderText="oferta" SortExpression="oferta" />
                                <asp:BoundField DataField="precio" HeaderText="precio" SortExpression="precio" />
                                <asp:TemplateField HeaderText="Agregar">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:ImageButton ID="ImageButton2" runat="server" Height="30px" ImageUrl="\inicio\images\agregarCarro.png" OnClick="ImageButton2_Click" Width="40px" Enabled="False" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" SelectText="Select" />
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </asp:Panel>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:proyectoConnectionString %>" SelectCommand="SELECT [nombre] FROM [Categoria]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:proyectoConnectionString %>" SelectCommand="SELECT Producto.nombre, Producto.precio, Producto.descripcion, Producto.oferta, Producto.docMultimedia FROM CategoriaProducto INNER JOIN Producto ON CategoriaProducto.Producto_idProducto = Producto.idProducto INNER JOIN Categoria ON CategoriaProducto.Categoria_idCategoria = Categoria.idCategoria WHERE (Categoria.nombre = @nombre)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList1" Name="nombre" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
					<p>&nbsp;</p>
                    <p>&nbsp;</p>
                    <p>&nbsp;</p>
                    <p>&nbsp;</p>
				</div>
			</div>
			<div class="post">
				<p class="meta">&nbsp;</p>
				<h2 class="title"><a href="#">Lorem ipsum sed aliquam	</a></h2>
                <div class="entry">
					<p>&nbsp;</p>
                    <p>&nbsp;</p>
                    <p>&nbsp;</p>
                    <p>&nbsp;</p>
				</div>
			</div>
			<div class="post">
				<p class="meta">&nbsp;</p>
				<h2 class="title"><a href="#">Lorem ipsum sed aliquam</a></h2>
				<div class="entry">
					<p>&nbsp;</p>
                    <p>&nbsp;</p>
                    <p>&nbsp;</p>
                    <p>&nbsp;</p>
                    <p>&nbsp;</p>
                    <p>&nbsp;</p>
				</div>
			</div>
		</div>
		
		<div id="sidebar">
			<ul>
				<li>
					<h2>Carro De Compra</h2>
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="64px" ImageUrl="\inicio\images\carro.png" Width="77px" />
                        
                    </p>
                    <p></p>
                    <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center" ScrollBars="Horizontal">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="idProducto" DataSourceID="SqlDataSource3" HorizontalAlign="Center" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" style="margin-right: 0px">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton3" runat="server" Height="30px" ImageUrl='<%# Eval("docMultimedia") %>' Width="30px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                                <asp:BoundField DataField="precio" HeaderText="precio" SortExpression="precio" />
                                <asp:TemplateField HeaderText="Cantidad">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" Enabled="False" Height="18px" OnTextChanged="TextBox1_TextChanged" Text='<%# Bind("cantidad") %>' ViewStateMode="Enabled" Width="40px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Eliminar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton4" runat="server" Enabled="False" Height="30px" ImageUrl="\inicio\images\eliminar.png" OnClick="ImageButton4_Click" Width="30px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField SelectText="Select" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <p>
                        
                    </p>
                    <p>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:proyectoConnectionString %>" SelectCommand="SELECT CarroProducto.cantidad, Producto.idProducto, Producto.precio, Producto.nombre, Producto.tipoProducto, Producto.existencia, Producto.descripcion, Producto.docMultimedia, Producto.oferta FROM CarroProducto INNER JOIN Producto ON CarroProducto.Producto_idProducto = Producto.idProducto WHERE (CarroProducto.CarroCompra_idCarro = @idCarro)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="1" Name="idCarro" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </p>
				</li>
				<li>
					<h2>&nbsp;</h2>
					<ul>
						<li><a href="#"> Nec metus sed donecef Magna lacus bibendum maurisnecef Magna lacus bibendum mauris</a></li>
						<li><a href="#">Velit semper nisi molestie</a></li>
						<li><a href="#">Eget tempor eget nonummy</a></li>
						<li><a href="#">Nec metus sed donec</a></li>
						<li><a href="#">Velit semper nisi molestie</a></li>
						<li><a href="#">Eget tempor eget nonummy</a></li>
						<li><a href="#">Nec metus sed donec</a></li>
					</ul>
				</li>
				<li>
					<h2>Turpis nulla</h2>
					<ul>
						<li><a href="#">Nec metus sed donec</a></li>
						<li><a href="#">Magna lacus bibendum mauris</a></li>
						<li><a href="#">Velit semper nisi molestie</a></li>
						<li><a href="#">Eget tempor eget nonummy</a></li>
						<li><a href="#">Nec metus sed donec</a></li>
						<li><a href="#">Nec metus sed donec</a></li>
						<li><a href="#">Magna lacus bibendum mauris</a></li>
						<li><a href="#">Velit semper nisi molestie</a></li>
						<li><a href="#">Eget tempor eget nonummy</a></li>
						<li><a href="#">Nec metus sed donec</a></li>
					</ul>
				</li>
			</ul>
		</div>
		<div style="clear:both">&nbsp;</div>
	</div>
	<div id="footer"><div class="fleft"><p>Copyright statement.</p></div><div class="fright"><p>Busque m&aacute;s plantillas web gratis <a href="http://www.mejoresplantillasgratis.es" target="_blank">en MPG.es</a>.</p></div><div class="fcenter"><p>Design by: Design by <a href="http://www.freecsstemplates.org/">Free CSS Templates</a></p></div><div class="fclear"></div></div>
</div>
    </form>
</body>
</html>