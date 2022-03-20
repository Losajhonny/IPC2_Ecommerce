<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="perfilUsuario.aspx.cs" Inherits="ProyectoIpc2_201325583.formUsuario" %>

<!DOCTYPE html>
<!--[if lt IE 7 ]> <html lang="en" class="ie6 ielt8"> <![endif]-->
<!--[if IE 7 ]>    <html lang="en" class="ie7 ielt8"> <![endif]-->
<!--[if IE 8 ]>    <html lang="en" class="ie8"> <![endif]-->
<!--[if (gte IE 9)|!(IE)]><!--> <html lang="en"> <!--<![endif]-->
<head>
<meta charset="utf-8">
<title>Perfil Usuario</title>
<link rel="stylesheet" type="text/css" href="perfil/style.css" />
</head>
<body>
<div class="container">
	<section id="content">
		<form id="form1" runat="server">
			<h1>Perfil Usuario</h1>
            <div>
			    <asp:Label ID="Label3" runat="server" dir="rtl" Width="290px" Text="Nombre y apellido"></asp:Label>
			</div>
			<div>
			    <asp:TextBox ID="TextBox1" runat="server" Width="290px" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
			</div>
            <div>
			    <asp:Label ID="Label4" runat="server" dir="rtl" Width="290px" Text="Telefono"></asp:Label>
			</div>
            <div>
			    <asp:TextBox ID="TextBox2" runat="server" Width="290px"></asp:TextBox>
			</div>
            <div>
			    <asp:Label ID="Label5" runat="server" dir="rtl" Width="290px" Text="E-mail"></asp:Label>
			</div>
            <div>
			    <asp:TextBox ID="email" runat="server" Width="290px"></asp:TextBox>
			</div>
            <div>
			    <asp:Label ID="Label6" runat="server" dir="rtl" Width="290px" Text="Password"></asp:Label>
			</div>
            <div>
			    <asp:TextBox ID="password" runat="server" Width="290px"></asp:TextBox>
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
                <br />
                <asp:Label ID="Mensaje" runat="server" Text=""></asp:Label>
            </div>
            <div>
			    <asp:Button ID="guardar" runat="server" Text="Guardar Cambios" OnClick="enviar_Click" OnClientClick="return confirm(&quot;¿Desea Guardar los Cambios?&quot;);" />

			    <asp:Button ID="regresar" runat="server" OnClick="regresar_Click" Text="Back" />
			</div>
		</form>
        <!-- form -->
        <!-- button -->
	</section><!-- content -->
</div><!-- container -->
</body>
</html>
