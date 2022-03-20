<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="administrador.aspx.cs" Inherits="ProyectoIpc2_201325583.administrador" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="content-type" content="text/html; charset=utf-8" />
<title>Asociacion C.C. Administrador</title>
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
				<li class="current_page_item"><a href="#">
                    <asp:Button ID="Button1" runat="server" BackColor="Black" BorderColor="Black" ForeColor="White" Text="Registrar Personal" Width="120px" OnClick="Button1_Click" />
                    </a></li>
				<li><a href="#">
                    <asp:Button ID="perfil" runat="server" BackColor="Black" BorderColor="Black" ForeColor="White" OnClick="perfil_Click" Text="Perfil" />
                    </a></li>
				<li><a href="#">
                    <asp:Button ID="salir" runat="server" BackColor="Black" BorderColor="Black" ForeColor="White" OnClick="salir_Click" Text="Salir" />
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
	<h1>Administrador</h1>
	<p>asociacion centro comercial</p>
</div><hr />
<div id="page"><div class="inner_copy"></div>
	<div id="page-bgtop">
		<div id="content">
			<div class="post">
				<p class="meta">&nbsp;</p>
				<h2 class="title"><a href="#">Zonas</a></h2>
				<div class="entry">
                    <p>

                    </p>
					<asp:Panel ID="Panel1" runat="server" Height="250px" ScrollBars="Vertical" Width="600px">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="idZona" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" Width="555px">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                                <asp:BoundField DataField="tipoZona" HeaderText="tipoZona" SortExpression="tipoZona" />
                                <asp:BoundField DataField="noZonaSuperior" HeaderText="noZonaSuperior" SortExpression="noZonaSuperior" />
                                <asp:BoundField DataField="noZona" HeaderText="noZona" SortExpression="noZona" />
                                <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
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
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:proyectoConnectionString %>" DeleteCommand="DELETE FROM [ZonaDis] WHERE [idZona] = @idZona" InsertCommand="INSERT INTO [ZonaDis] ([descripcion], [tipoZona], [noZonaSuperior], [noZona], [noZonaVecina], [nombre], [ZonaDis_idZona]) VALUES (@descripcion, @tipoZona, @noZonaSuperior, @noZona, @noZonaVecina, @nombre, @ZonaDis_idZona)" SelectCommand="SELECT * FROM [ZonaDis] WHERE ([tipoZona] = @tipoZona)" UpdateCommand="UPDATE [ZonaDis] SET [descripcion] = @descripcion, [tipoZona] = @tipoZona, [noZonaSuperior] = @noZonaSuperior, [noZona] = @noZona, [noZonaVecina] = @noZonaVecina, [nombre] = @nombre, [ZonaDis_idZona] = @ZonaDis_idZona WHERE [idZona] = @idZona">
                            <DeleteParameters>
                                <asp:Parameter Name="idZona" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="descripcion" Type="String" />
                                <asp:Parameter Name="tipoZona" Type="String" />
                                <asp:Parameter Name="noZonaSuperior" Type="Int32" />
                                <asp:Parameter Name="noZona" Type="Int32" />
                                <asp:Parameter Name="noZonaVecina" Type="Int32" />
                                <asp:Parameter Name="nombre" Type="String" />
                                <asp:Parameter Name="ZonaDis_idZona" Type="Int32" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:Parameter DefaultValue="ZONA" Name="tipoZona" Type="String" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="descripcion" Type="String" />
                                <asp:Parameter Name="tipoZona" Type="String" />
                                <asp:Parameter Name="noZonaSuperior" Type="Int32" />
                                <asp:Parameter Name="noZona" Type="Int32" />
                                <asp:Parameter Name="noZonaVecina" Type="Int32" />
                                <asp:Parameter Name="nombre" Type="String" />
                                <asp:Parameter Name="ZonaDis_idZona" Type="Int32" />
                                <asp:Parameter Name="idZona" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                    </p>
				</div>
			</div>
			<div class="post">
				<p class="meta">&nbsp;</p>
				<h2 class="title"><a href="#">Zonas Vecinas</a></h2>
				<div class="entry">
                    <p>

                    </p>
					<asp:Panel ID="Panel2" runat="server" Height="250px" ScrollBars="Vertical" Width="590px">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="idZona" DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="Vertical" Width="553px">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                                <asp:BoundField DataField="tipoZona" HeaderText="tipoZona" SortExpression="tipoZona" />
                                <asp:BoundField DataField="noZona" HeaderText="noZona" SortExpression="noZona" />
                                <asp:BoundField DataField="noZonaVecina" HeaderText="noZonaVecina" SortExpression="noZonaVecina" />
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
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:proyectoConnectionString %>" SelectCommand="SELECT * FROM [ZonaDis] WHERE ([tipoZona] = @tipoZona)" DeleteCommand="DELETE FROM [ZonaDis] WHERE [idZona] = @idZona" InsertCommand="INSERT INTO [ZonaDis] ([descripcion], [tipoZona], [noZonaSuperior], [noZona], [noZonaVecina], [nombre], [ZonaDis_idZona]) VALUES (@descripcion, @tipoZona, @noZonaSuperior, @noZona, @noZonaVecina, @nombre, @ZonaDis_idZona)" UpdateCommand="UPDATE [ZonaDis] SET [descripcion] = @descripcion, [tipoZona] = @tipoZona, [noZonaSuperior] = @noZonaSuperior, [noZona] = @noZona, [noZonaVecina] = @noZonaVecina, [nombre] = @nombre, [ZonaDis_idZona] = @ZonaDis_idZona WHERE [idZona] = @idZona">
                            <DeleteParameters>
                                <asp:Parameter Name="idZona" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="descripcion" Type="String" />
                                <asp:Parameter Name="tipoZona" Type="String" />
                                <asp:Parameter Name="noZonaSuperior" Type="Int32" />
                                <asp:Parameter Name="noZona" Type="Int32" />
                                <asp:Parameter Name="noZonaVecina" Type="Int32" />
                                <asp:Parameter Name="nombre" Type="String" />
                                <asp:Parameter Name="ZonaDis_idZona" Type="Int32" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:Parameter DefaultValue="ZONA_VECINA" Name="tipoZona" Type="String" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="descripcion" Type="String" />
                                <asp:Parameter Name="tipoZona" Type="String" />
                                <asp:Parameter Name="noZonaSuperior" Type="Int32" />
                                <asp:Parameter Name="noZona" Type="Int32" />
                                <asp:Parameter Name="noZonaVecina" Type="Int32" />
                                <asp:Parameter Name="nombre" Type="String" />
                                <asp:Parameter Name="ZonaDis_idZona" Type="Int32" />
                                <asp:Parameter Name="idZona" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                    </p>
				</div>
			</div>
			<div class="post">
				<p class="meta">&nbsp;</p>
				<h2 class="title"><a href="#">Usuarios registrados</a></h2>
				<div class="entry">
                    <p>

                    </p>
					<asp:Panel ID="Panel3" runat="server" Height="250px" Width="600px" ScrollBars="Vertical">
                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="idEmpleado" DataSourceID="SqlDataSource3" ForeColor="Black" GridLines="Vertical" Width="559px">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                <asp:BoundField DataField="puesto" HeaderText="puesto" SortExpression="puesto" />
                                <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                                <asp:BoundField DataField="telefono" HeaderText="telefono" SortExpression="telefono" />
                                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                                <asp:BoundField DataField="passwor" HeaderText="passwor" SortExpression="passwor" />
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
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:proyectoConnectionString %>" DeleteCommand="DELETE FROM [Empleado] WHERE [idEmpleado] = @idEmpleado" InsertCommand="INSERT INTO [Empleado] ([puesto], [nombre], [telefono], [Comercio_idComercio], [email], [passwor]) VALUES (@puesto, @nombre, @telefono, @Comercio_idComercio, @email, @passwor)" SelectCommand="SELECT * FROM [Empleado]" UpdateCommand="UPDATE [Empleado] SET [puesto] = @puesto, [nombre] = @nombre, [telefono] = @telefono, [Comercio_idComercio] = @Comercio_idComercio, [email] = @email, [passwor] = @passwor WHERE [idEmpleado] = @idEmpleado">
                            <DeleteParameters>
                                <asp:Parameter Name="idEmpleado" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="puesto" Type="String" />
                                <asp:Parameter Name="nombre" Type="String" />
                                <asp:Parameter Name="telefono" Type="String" />
                                <asp:Parameter Name="Comercio_idComercio" Type="Int32" />
                                <asp:Parameter Name="email" Type="String" />
                                <asp:Parameter Name="passwor" Type="String" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="puesto" Type="String" />
                                <asp:Parameter Name="nombre" Type="String" />
                                <asp:Parameter Name="telefono" Type="String" />
                                <asp:Parameter Name="Comercio_idComercio" Type="Int32" />
                                <asp:Parameter Name="email" Type="String" />
                                <asp:Parameter Name="passwor" Type="String" />
                                <asp:Parameter Name="idEmpleado" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                    </p>
				</div>
			</div>
            <div class="post">
				<p class="meta">&nbsp;</p>
				<h2 class="title"><a href="#">Socios registrados</a></h2>
				<div class="entry">
                    <p>

                    </p>
					<asp:Panel ID="Panel4" runat="server" Height="250px" ScrollBars="Vertical" Width="590px">
                        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="idSocio" DataSourceID="SqlDataSource4" ForeColor="Black" GridLines="Vertical" Width="540px">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                                <asp:BoundField DataField="telefono" HeaderText="telefono" SortExpression="telefono" />
                                <asp:BoundField DataField="direccion" HeaderText="direccion" SortExpression="direccion" />
                                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                                <asp:BoundField DataField="passwor" HeaderText="passwor" SortExpression="passwor" />
                                <asp:BoundField DataField="noCuenta" HeaderText="noCuenta" SortExpression="noCuenta" />
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
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:proyectoConnectionString %>" DeleteCommand="DELETE FROM [Socio] WHERE [idSocio] = @idSocio" InsertCommand="INSERT INTO [Socio] ([passwor], [nombre], [telefono], [direccion], [email], [noCuenta], [CarroCompra_idCarro]) VALUES (@passwor, @nombre, @telefono, @direccion, @email, @noCuenta, @CarroCompra_idCarro)" SelectCommand="SELECT * FROM [Socio]" UpdateCommand="UPDATE [Socio] SET [passwor] = @passwor, [nombre] = @nombre, [telefono] = @telefono, [direccion] = @direccion, [email] = @email, [noCuenta] = @noCuenta, [CarroCompra_idCarro] = @CarroCompra_idCarro WHERE [idSocio] = @idSocio">
                            <DeleteParameters>
                                <asp:Parameter Name="idSocio" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="passwor" Type="String" />
                                <asp:Parameter Name="nombre" Type="String" />
                                <asp:Parameter Name="telefono" Type="String" />
                                <asp:Parameter Name="direccion" Type="String" />
                                <asp:Parameter Name="email" Type="String" />
                                <asp:Parameter Name="noCuenta" Type="String" />
                                <asp:Parameter Name="CarroCompra_idCarro" Type="Int32" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="passwor" Type="String" />
                                <asp:Parameter Name="nombre" Type="String" />
                                <asp:Parameter Name="telefono" Type="String" />
                                <asp:Parameter Name="direccion" Type="String" />
                                <asp:Parameter Name="email" Type="String" />
                                <asp:Parameter Name="noCuenta" Type="String" />
                                <asp:Parameter Name="CarroCompra_idCarro" Type="Int32" />
                                <asp:Parameter Name="idSocio" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                    </p>
				</div>
			</div>

            <div class="post">
				<p class="meta">&nbsp;</p>
				<h2 class="title"><a href="#">Acciones de usuarios</a></h2>
				<div class="entry">
                    <p>

                    </p>

					<asp:Panel ID="Panel5" runat="server" Height="250px" Width="590px">
                        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="idRegistro" DataSourceID="SqlDataSource5" ForeColor="Black" GridLines="Vertical" Width="530px">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="idRegistro" HeaderText="idRegistro" InsertVisible="False" ReadOnly="True" SortExpression="idRegistro" />
                                <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
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
                        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:proyectoConnectionString %>" SelectCommand="SELECT * FROM [Registro]"></asp:SqlDataSource>
                    </p>
                    <p>

                    </p>
				</div>
			</div>
		</div>
		
		<div id="sidebar">
			<ul>
				<li>
					<h2>Cargar zonas</h2>
					<p>
                        <asp:FileUpload ID="filezonas" runat="server" />
                    </p>
                    <p>

                    </p>
                    <p>
                        <br />
                        <center>
                        <asp:Button ID="cargarzonas" runat="server" Text="Cargar Zonas" OnClick="cargarzonas_Click" />
                        </center>
                    </p>
                    <h2>Cargar zonas vecinas</h2>
					<p>
                        <br />
                        <asp:FileUpload ID="filezonasV" runat="server" />
                    </p>
                    <p>

                    </p>
                    <p>
                        <br />
                        <center>
                        <asp:Button ID="cargarvecinas" runat="server" Text="Cargar Zonas" OnClick="cargarvecinas_Click" />
                        </center>
                    </p>
                    <p>
                        <br />
                        <center>
                        <asp:Label ID="Label1" runat="server" Text="Zonas Vecinas"></asp:Label>
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
