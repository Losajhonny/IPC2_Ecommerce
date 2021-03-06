<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrarPersonal.aspx.cs" Inherits="ProyectoIpc2_201325583.registrarPersonal" %>

<!DOCTYPE html>
<!--[if lt IE 7 ]> <html lang="en" class="ie6 ielt8"> <![endif]-->
<!--[if IE 7 ]>    <html lang="en" class="ie7 ielt8"> <![endif]-->
<!--[if IE 8 ]>    <html lang="en" class="ie8"> <![endif]-->
<!--[if (gte IE 9)|!(IE)]><!--> <html lang="en"> <!--<![endif]-->
<head>
<meta charset="utf-8">
<title>Registrar Socio</title>
<link rel="stylesheet" type="text/css" href="registro/style.css" />
</head>
<body>
<div class="container">
	<section id="content">
		<form id="form1" runat="server">
			<h1>Registrarse Personal</h1>
            <div>
			    <asp:Label ID="Label1" runat="server" dir="rtl" Width="290px" Text="Nombre y Apellido"></asp:Label>
			</div>
			<div>
			    <asp:TextBox ID="name" runat="server" Width="290px" Height="10px"></asp:TextBox>
			</div>
            <div>
			    <asp:Label ID="Label3" runat="server" dir="rtl" Width="290px" Text="Telefono"></asp:Label>
			</div>
			<div>
                <asp:TextBox ID="telefono" runat="server" Width="290px" Height="10px"></asp:TextBox>
			</div>
            <div>
			    <asp:Label ID="Label4" runat="server" dir="rtl" Width="290px" Text="E-mail"></asp:Label>
			</div>
            <div>
                <asp:TextBox ID="email" runat="server" Width="290px" Height="10px"></asp:TextBox>
			</div>
            <div>
			    <asp:Label ID="Label5" runat="server" dir="rtl" Width="290px" Text="Puesto"></asp:Label>
			</div>
            <div>
                <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="336px">
                    <asp:ListItem>gerente</asp:ListItem>
                    <asp:ListItem>administrador</asp:ListItem>
                    <asp:ListItem>operario</asp:ListItem>
                    <asp:ListItem>responsable abastecimiento</asp:ListItem>
                </asp:DropDownList>
			</div>
            <div>
			    <asp:Label ID="Label6" runat="server" dir="rtl" Width="290px" Text="Password"></asp:Label>
			</div>
            <div>
                <asp:TextBox ID="password" runat="server" Width="290px" Height="10px" TextMode="Password"></asp:TextBox>
			</div>
            <div>
			    <asp:Label ID="Mensaje" runat="server" dir="rtl" Width="290px"></asp:Label>
			</div>
            <div>
			    <asp:Button ID="registro" runat="server" Text="Registrar" OnClick="registro_Click" />
                <asp:Button ID="back" runat="server" Text="Back" OnClick="back_Click"/>
			</div>
		</form>
        <!-- form -->
        <!-- button -->
	</section><!-- content -->
</div><!-- container -->
</body>
</html>
