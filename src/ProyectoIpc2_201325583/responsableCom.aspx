<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="responsableCom.aspx.cs" Inherits="ProyectoIpc2_201325583.responsableCom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="content-type" content="text/html; charset=utf-8" />
<title>Asociacion C.C. Responsable comercio</title>
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
				<li><a href="#" class="first">Productos</a></li>
				<li class="current_page_item"><a href="#">Perfil</a></li>
				<li><a href="#">
                    <asp:Button ID="perfil" runat="server" BackColor="Black" BorderColor="Black" ForeColor="White" OnClick="perfil_Click" Text="Perfil" />
                    </a></li>
				<li><a href="#">
                    <asp:Button ID="salir" runat="server" BackColor="Black" ForeColor="White" OnClick="salir_Click" Text="Salir" BorderColor="Black" />
                    </a></li>
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
	<h1>responsable Comercio</h1>
	<p>asociacion centro comercial</p>
</div><hr />
<div id="page"><div class="inner_copy"></div>
	<div id="page-bgtop">
		<div id="content">
			<div class="post">
				<h2 class="title"><a href="#">Altas Bajas y Cambios</a></h2>
                <br />
                <br />
				<h2 class="title"><a href="#">Productos Propios</a></h2>
				<div class="entry">
                    <p>

                    </p>
					<asp:Panel ID="Panel1" runat="server" Height="250px" ScrollBars="Vertical" Width="610px">
                        <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" Width="602px">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                                <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                                <asp:BoundField DataField="tipoProducto" HeaderText="tipoProducto" SortExpression="tipoProducto" />
                                <asp:BoundField DataField="oferta" HeaderText="oferta" SortExpression="oferta" />
                                <asp:BoundField DataField="precio" HeaderText="precio" SortExpression="precio" />
                                <asp:TemplateField HeaderText="Alta">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" ViewStateMode="Enabled" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="Gray" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </asp:Panel>
					<p>
                        &nbsp;&nbsp;&nbsp;
                        </p>
                    <p>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:proyectoConnectionString %>" SelectCommand="SELECT Producto.nombre, Producto.descripcion, Producto.tipoProducto, Producto.oferta, Producto.precio, Producto.existencia FROM InventarioProducto 
INNER JOIN Producto ON InventarioProducto.Producto_idProducto = Producto.idProducto 
INNER JOIN Inventario ON InventarioProducto.Inventario_idInventario = Inventario.idInventario 
WHERE (Inventario.Comercio_idComercio = @Comercio_idComercio) and (Producto.tipoProducto = 'PROPIO')">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="confiIdComercio" Name="Comercio_idComercio" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </p>
                    <p>
                        <center>
                        <asp:Button ID="Button2" runat="server" Text="Editar" OnClick="Button2_Click1" />
                        </center>
                    </p>
				</div>
			</div>
            <div class="post">
				<p class="meta">&nbsp;</p>
				<h2 class="title"><a href="#">Productos Comunes</a></h2>
				<div class="entry">
                    <p>

                    </p>
					<asp:Panel ID="Panel2" runat="server" Height="250px" ScrollBars="Vertical" Width="610px">
                        <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="Vertical" Width="599px">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                                <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                                <asp:BoundField DataField="tipoProducto" HeaderText="tipoProducto" SortExpression="tipoProducto" />
                                <asp:BoundField DataField="oferta" HeaderText="oferta" SortExpression="oferta" />
                                <asp:BoundField DataField="precio" HeaderText="precio" SortExpression="precio" />
                                <asp:TemplateField HeaderText="Alta">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox2" runat="server" OnCheckedChanged="CheckBox2_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" />
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
					<p>
                        &nbsp;</p>
                    <p>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:proyectoConnectionString %>" SelectCommand="SELECT Producto.nombre, Producto.descripcion, Producto.tipoProducto, Producto.oferta, Producto.precio FROM InventarioProducto 
INNER JOIN Producto ON InventarioProducto.Producto_idProducto = Producto.idProducto 
INNER JOIN Inventario ON InventarioProducto.Inventario_idInventario = Inventario.idInventario 
WHERE (Inventario.Comercio_idComercio = @Comercio_idComercio) and (Producto.tipoProducto = 'COMUN')" UpdateCommand="UPDATE Producto SET precio = @precio, nombre = @nombre, tipoProducto = @tipoProducto, descripcion = @descripcion FROM Producto INNER JOIN InventarioProducto ON Producto.idProducto = InventarioProducto.Producto_idProducto INNER JOIN Inventario ON InventarioProducto.Inventario_idInventario = Inventario.idInventario WHERE (Inventario.Comercio_idComercio = @Comercio_idComercio)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="confiIdComercio" Name="Comercio_idComercio" PropertyName="Text" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="precio" />
                                <asp:Parameter Name="nombre" />
                                <asp:Parameter Name="tipoProducto" />
                                <asp:Parameter Name="descripcion" />
                                <asp:Parameter Name="Comercio_idComercio" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                    </p>
                    <p>
                        <center>
                        <asp:Button ID="Button3" runat="server" Text="Editar" OnClick="Button3_Click" />
                        </center>
                    </p>
				</div>
			</div>
			<div class="post">
				<p class="meta">&nbsp;</p>
				<h2 class="title"><a href="#">Listado General de Productos</a></h2>
				<div class="entry">

                    <p>

                    </p>
					<asp:Panel ID="Panel3" runat="server" Height="250px" ScrollBars="Vertical" Width="610px">
                        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource3" ForeColor="Black" GridLines="Vertical" Width="599px">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                                <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                                <asp:BoundField DataField="tipoProducto" HeaderText="tipoProducto" SortExpression="tipoProducto" />
                                <asp:BoundField DataField="oferta" HeaderText="oferta" SortExpression="oferta" />
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
					<p>
                        &nbsp;</p>
                    <p>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:proyectoConnectionString %>" OnSelecting="SqlDataSource3_Selecting" SelectCommand="SELECT Producto.nombre, Producto.descripcion, Producto.tipoProducto, Producto.oferta FROM InventarioProducto 
INNER JOIN Producto ON InventarioProducto.Producto_idProducto = Producto.idProducto 
INNER JOIN Inventario ON InventarioProducto.Inventario_idInventario = Inventario.idInventario">
                        </asp:SqlDataSource>
                    </p>
				</div>
			</div>
			<div class="post">
				<p class="meta">&nbsp;</p>
				<h2 class="title"><a href="#">Productos del Comercio</a></h2>
				<div class="entry">
                    <p>

                    </p>
					<asp:Panel ID="Panel4" runat="server" Height="250px" ScrollBars="Vertical" Width="610px">
                        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource4" ForeColor="Black" GridLines="Vertical" Width="603px">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                                <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                                <asp:BoundField DataField="tipoProducto" HeaderText="tipoProducto" SortExpression="tipoProducto" />
                                <asp:BoundField DataField="oferta" HeaderText="oferta" SortExpression="oferta" />
                                <asp:BoundField DataField="precio" HeaderText="precio" SortExpression="precio" />
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
					<p>
                        &nbsp;</p>
                    <p>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:proyectoConnectionString %>" SelectCommand="SELECT Producto.nombre, Producto.descripcion, Producto.tipoProducto, Producto.oferta, Producto.precio FROM InventarioProducto 
INNER JOIN Producto ON InventarioProducto.Producto_idProducto = Producto.idProducto 
INNER JOIN Inventario ON InventarioProducto.Inventario_idInventario = Inventario.idInventario 
WHERE (Inventario.Comercio_idComercio = @Comercio_idComercio)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="confiIdComercio" Name="Comercio_idComercio" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </p>
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
					<h2>Registrar Productos</h2>
					<p>&nbsp
					    <asp:FileUpload ID="fileseleccion" runat="server" />
                        <br />
					</p>
                    <p>&nbsp;

					</p>
                    <p>&nbsp;
                        <center>
					    <asp:Button ID="enviar" runat="server" Text="Cargar Productos" OnClick="enviar_Click" OnClientClick="return confirm(&quot;¿Esta seguro en cargar archivo(s)?&quot;);" />
                        </center>
					</p>
                    <p>
                        <br />
                        <center>
                        <asp:Label ID="Mensaje" runat="server"></asp:Label>
                        </center>
					</p>
				</li>
				<li>
					<h2>Pellenteque ornare </h2>
					<ul>
						<li>
                            <asp:Label ID="confiIdComercio" runat="server" Visible="False"></asp:Label>
                        </li>
						<li>
                            <asp:Label ID="li" runat="server" Visible="False"></asp:Label>
                        </li>
						<li>
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </li>
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

