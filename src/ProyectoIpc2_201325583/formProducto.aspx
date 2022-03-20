<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formProducto.aspx.cs" Inherits="ProyectoIpc2_201325583.formProducto" %>


<!DOCTYPE html>
<!--[if lt IE 7 ]> <html lang="en" class="ie6 ielt8"> <![endif]-->
<!--[if IE 7 ]>    <html lang="en" class="ie7 ielt8"> <![endif]-->
<!--[if IE 8 ]>    <html lang="en" class="ie8"> <![endif]-->
<!--[if (gte IE 9)|!(IE)]><!--> <html lang="en"> <!--<![endif]-->
<head>
<meta charset="utf-8">
<title>Solicitud on-line</title>
<link rel="stylesheet" type="text/css" href="registro/style.css" />
</head>
<body>
<div class="container">
	<section id="content">
		<form id="form1" runat="server">
			<h1>Producto</h1>
            <div>
			    <asp:Label ID="nombre" runat="server" dir="rtl" Width="290px" Text="Nombre"></asp:Label>
			</div>
			<div>
			    <asp:TextBox ID="nombreT" runat="server" Width="290px" Height="15px"></asp:TextBox>
			</div>
            <div>
			    <asp:Label ID="descripcion" runat="server" dir="rtl" Width="290px" Text="Descripcion"></asp:Label>
			</div>
			<div>
                <asp:TextBox ID="descripcionT" runat="server" Width="290px" Height="15px"></asp:TextBox>
			</div>
            <div>
			    <asp:Label ID="tipoProducto" runat="server" dir="rtl" Width="290px" Text="Tipo Producto"></asp:Label>
			</div>
			<div>
                <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="340px">
                    <asp:ListItem>Propio</asp:ListItem>
                    <asp:ListItem>Comun</asp:ListItem>
                    <asp:ListItem>Propio y Comun</asp:ListItem>
                </asp:DropDownList>
			</div>
            <div>
			    <asp:Label ID="oferta" runat="server" dir="rtl" Width="290px" Text="Oferta"></asp:Label>
			</div>
            <div>
                <asp:TextBox ID="ofertaT" runat="server" Width="290px" Height="15px"></asp:TextBox>
			</div>
            <div>
			    <asp:Label ID="precio" runat="server" dir="rtl" Width="290px" Text="Precio"></asp:Label>
			</div>
            <div>
                <asp:TextBox ID="precioT" runat="server" Width="290px" Height="15px"></asp:TextBox>
			</div>
            
            <div>
			    <asp:Label ID="urlP" runat="server" dir="rtl" Width="290px" Text="Multimedia"></asp:Label>
			</div>
            <div>
                <asp:TextBox ID="urlPT" runat="server" Width="290px" Height="15px"></asp:TextBox>
			</div>
            <div>
                <asp:Image ID="Image1" runat="server" Width="150" Height="150"/>
            </div>
             <div>
                <br />
                <asp:Label ID="Label1" runat="server" Text="Mostrar Datos"></asp:Label>
            </div>
            <div>
                <br />
                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" ViewStateMode="Enabled" />
            &nbsp;</div>
            <div>
                <asp:Label ID="Mensaje" runat="server" Text=""></asp:Label>
            </div>
            <div>
			    <asp:Button ID="guardar" runat="server" Text="Guardar Cambios" OnClick="enviar_Click" OnClientClick="return confirm(&quot;¿Desea Guardar los Cambios?&quot;);" />

			    <asp:Button ID="regresar" runat="server" Text="Back" OnClick="regresar_Click" />
			</div>
		</form>
        <!-- form -->
        <!-- button -->
	</section><!-- content -->
</div><!-- container -->
</body>
</html>