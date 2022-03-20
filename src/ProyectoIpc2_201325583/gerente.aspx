<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gerente.aspx.cs" Inherits="ProyectoIpc2_201325583.gerente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="content-type" content="text/html; charset=utf-8" />
<title>Asociacioin C.C. Gerente</title>
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
				<li><a href="#">productos</a></li>
				<li class="current_page_item"><a href="#">Productos</a></li>
				<li><a href="#">
                    <asp:Button ID="perfil" runat="server" BackColor="Black" BorderColor="Black" ForeColor="White" OnClick="perfil_Click" Text="Perfil" />
                    </a></li>
				<li><a href="#">
                    <asp:Button ID="salir" runat="server" BackColor="Black" ForeColor="White" OnClick="salir_Click" style="height: 26px" Text="Salir" BorderColor="Black" />
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
	<h1>gerente&nbsp;</h1>
	<p>asociacion centro comercial</p>
</div><hr />
<div id="page"><div class="inner_copy"></div>
	<div id="page-bgtop">
		<div id="content">
			<div class="post">
				<p class="meta">&nbsp;</p>
				<h2 class="title"><a href="#">Solicitudes Comercio De Alta</a></h2>
				<div class="entry">
                    <p>

                    </p>
					<asp:Panel ID="Panel3" runat="server" Height="250px" ScrollBars="Vertical" Width="610px">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="idComercio" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" Width="585px" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                                <asp:BoundField DataField="siglas" HeaderText="siglas" SortExpression="siglas" />
                                <asp:BoundField DataField="direccion" HeaderText="direccion" SortExpression="direccion" />
                                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                                <asp:BoundField DataField="telefono" HeaderText="telefono" SortExpression="telefono" />
                                <asp:BoundField DataField="tipoProducto" HeaderText="tipoProducto" SortExpression="tipoProducto" />
                                <asp:BoundField DataField="fax" HeaderText="fax" SortExpression="fax" />
                                <asp:TemplateField HeaderText="autorizar">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:proyectoConnectionString %>" DeleteCommand="DELETE FROM [Comercio] WHERE [idComercio] = @idComercio" InsertCommand="INSERT INTO [Comercio] ([nombre], [siglas], [direccion], [email], [telefono], [autorizacion], [tipoProducto], [fax]) VALUES (@nombre, @siglas, @direccion, @email, @telefono, @autorizacion, @tipoProducto, @fax)" SelectCommand="SELECT [nombre], [siglas], [direccion], [email], [telefono], [autorizacion], [tipoProducto], [fax], [idComercio] FROM [Comercio] WHERE (([idComercio] &gt; @idComercio) AND ([autorizacion] = @autorizacion))" UpdateCommand="UPDATE [Comercio] SET [nombre] = @nombre, [siglas] = @siglas, [direccion] = @direccion, [email] = @email, [telefono] = @telefono, [autorizacion] = @autorizacion, [tipoProducto] = @tipoProducto, [fax] = @fax WHERE [idComercio] = @idComercio">
                        <DeleteParameters>
                            <asp:Parameter Name="idComercio" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="nombre" Type="String" />
                            <asp:Parameter Name="siglas" Type="String" />
                            <asp:Parameter Name="direccion" Type="String" />
                            <asp:Parameter Name="email" Type="String" />
                            <asp:Parameter Name="telefono" Type="String" />
                            <asp:Parameter Name="autorizacion" Type="Boolean" />
                            <asp:Parameter Name="tipoProducto" Type="String" />
                            <asp:Parameter Name="fax" Type="String" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:Parameter DefaultValue="0" Name="idComercio" Type="Int32" />
                            <asp:Parameter DefaultValue="False" Name="autorizacion" Type="Boolean" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="nombre" Type="String" />
                            <asp:Parameter Name="siglas" Type="String" />
                            <asp:Parameter Name="direccion" Type="String" />
                            <asp:Parameter Name="email" Type="String" />
                            <asp:Parameter Name="telefono" Type="String" />
                            <asp:Parameter Name="autorizacion" Type="Boolean" />
                            <asp:Parameter Name="tipoProducto" Type="String" />
                            <asp:Parameter Name="fax" Type="String" />
                            <asp:Parameter Name="idComercio" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                         <br />
                        <br />
					    <center>
                        <asp:Button ID="alta" runat="server" Text="Dar de Alta" OnClick="alta_Click" OnClientClick="return confirm(&quot;¿Esta seguro en dar de Alta?&quot;);" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="actualizar" runat="server" OnClick="actualizar_Click" Text="Actualizar" />
                        </center>
                    &nbsp;
                        <p>
                            &nbsp;</p>
                        <h2 class="title"><a href="#">Solicitudes Comercio De Baja</a></h2>
                        <br />
                    <p>
                            <asp:GridView ID="GridView3" runat="server">
                            </asp:GridView>
                    </p>
                    <p>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server"></asp:SqlDataSource>
                    </p>
				</div>
			</div>
			<div class="post">
				<p class="meta">&nbsp;</p>
				<h2 class="title"><a href="#">Listado de Comercios</a></h2>
				<div class="entry">
                    <p>

                    </p>
					<asp:Panel ID="Panel2" runat="server" Height="250px" Width="600px" ScrollBars="Vertical">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="idComercio" DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="Vertical" Width="564px" Height="195px">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                                <asp:BoundField DataField="siglas" HeaderText="siglas" SortExpression="siglas" />
                                <asp:BoundField DataField="direccion" HeaderText="direccion" SortExpression="direccion" />
                                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                                <asp:BoundField DataField="telefono" HeaderText="telefono" SortExpression="telefono" />
                                <asp:BoundField DataField="tipoProducto" HeaderText="tipoProducto" SortExpression="tipoProducto" />
                                <asp:BoundField DataField="fax" HeaderText="fax" SortExpression="fax" />
                                <asp:CheckBoxField DataField="autorizacion" HeaderText="autorizacion" SortExpression="autorizacion" />
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
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:proyectoConnectionString %>" SelectCommand="SELECT [idComercio], [nombre], [siglas], [direccion], [email], [autorizacion], [telefono], [tipoProducto], [fax] FROM [Comercio] WHERE ([idComercio] &gt; @idComercio) ORDER BY [idComercio]">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="idComercio" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </p>
                    <p>&nbsp;</p>
                    <p>&nbsp;</p>
                    <p>&nbsp;</p>
				</div>
			</div>
			<div class="post">
				<p class="meta">&nbsp;</p>
				<h2 class="title"><a href="#">Lore</a></h2>
				<div class="entry">
					<p>&nbsp;</p>
                    <p></p>
                    <p>
                        &nbsp;</p>
                    <p>&nbsp;</p>
                    <p>&nbsp;</p>
                    <p>&nbsp;</p>
				</div>
			</div>
		</div>
		
		<div id="sidebar">
			<ul>
				<li>
                    <h2>Cargar Archivos</h2>
                    <p>
                        <br />
                        <asp:FileUpload ID="filecategoria" runat="server" AllowMultiple="True" />
                        <br />
                    </p>
					<p>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </p>
                    <p>
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="cargaC" runat="server" Text="Cargar" Width="128px" OnClick="cargaC_Click" />
                        <br />
                    </p>
                    <p>
                        <br />
                        <center>
                        <asp:Label ID="Mensaje" runat="server" Text="[Mensaje]"></asp:Label>
                        </center>
                    </p>
				</li>
				<li>
					<h2>Pellenteque ornare </h2>
					<ul>
						<li><a href="#">Nec metus sed donec</a></li>
						<li><a href="#">Magna lacus bibendum mauris</a></li>
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

