<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="perfilUser.aspx.cs" Inherits="ProyectoIpc2_201325583.perfilUser" %>

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
			<h1>Perfil Usuario</h1>
            <div>
			    <asp:Label ID="Label1" runat="server" dir="rtl" Width="290px" Text="Nombre y Apellido"></asp:Label>
			</div>
			<div>
                <asp:TextBox ID="nombreApe" runat="server" Width="290px" Height="15px"></asp:TextBox>
			</div>
            <div>
			    <asp:Label ID="Label4" runat="server" dir="rtl" Width="290px" Text="E-mail"></asp:Label>
			</div>
            <div>
                <asp:TextBox ID="email" runat="server" Width="290px" Height="15px"></asp:TextBox>
			</div>
            <div>
			    <asp:Label ID="Label6" runat="server" dir="rtl" Width="290px" Text="Telefono"></asp:Label>
			</div>
            <div>
                <asp:TextBox ID="telefono" runat="server" Width="290px" Height="15px"></asp:TextBox>
			</div>
            <div>
			    <asp:Label ID="Label8" runat="server" dir="rtl" Width="290px" Text="password"></asp:Label>
			</div>
            <div>
                <asp:TextBox ID="password" runat="server" Width="290px" Height="15px" AutoCompleteType="Disabled" TextMode="Password"></asp:TextBox>
			</div>
            <div>
                <asp:Label ID="Mensaje" runat="server" Text=""></asp:Label>
            </div>
            <div>

			    <asp:Button ID="guardaar" runat="server" Text="Guardar Cambios" OnClick="enviar_Click" />

			</div>
		</form>
        <!-- form -->
        <!-- button -->
	</section><!-- content -->
</div><!-- container -->
</body>
</html>
