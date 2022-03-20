<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ProyectoIpc2_201325583.login" %>

<!DOCTYPE html>
<!--[if lt IE 7 ]> <html lang="en" class="ie6 ielt8"> <![endif]-->
<!--[if IE 7 ]>    <html lang="en" class="ie7 ielt8"> <![endif]-->
<!--[if IE 8 ]>    <html lang="en" class="ie8"> <![endif]-->
<!--[if (gte IE 9)|!(IE)]><!--> <html lang="en"> <!--<![endif]-->
<head>
<meta charset="utf-8">
<title>Log-In</title>
<link rel="stylesheet" type="text/css" href="login/style.css" />
</head>
<body>
<div class="container">
	<section id="content">
		<form id="form1" runat="server">
			<h1>Sign-Up</h1>
            <div>
			    <asp:Label ID="etiUser" runat="server" Text="Username"></asp:Label>
			</div>
			<div>
                 <asp:TextBox ID="name" runat="server" Width="282px"></asp:TextBox>
			</div>
            <div>
			    <asp:Label ID="etipass" runat="server" Text="Password"></asp:Label>
			</div>
			<div>
                <asp:TextBox ID="password" runat="server" Width="281px" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
			</div>
            <div>
                <br />
			</div>
            <div>
			    <asp:DropDownList ID="DropDownList1" runat="server" Height="37px" Width="325px">
                    <asp:ListItem>Administrador</asp:ListItem>
                    <asp:ListItem>Socio</asp:ListItem>
                    <asp:ListItem>Responsable Abastecimiento</asp:ListItem>
                    <asp:ListItem>Gerente</asp:ListItem>
                    <asp:ListItem>Responsable Comercio</asp:ListItem>
                    <asp:ListItem>Operario</asp:ListItem>
                </asp:DropDownList>
			</div>
            <div>
                <br />
			</div>
            <div>
                <center>
			    <asp:Label ID="Mensaje" runat="server" Text="[Mensaje]"></asp:Label>
                    </center>
			</div>
             <div>

			</div>
             <div>
                 <br />
                 <br />
			</div>
             <div>
                 <center>
			     <asp:Button ID="log" runat="server" Text="Login" OnClick="log_Click1" />
                     </center>
			</div>
		</form>
        <!-- button -->
	</section><!-- content -->
</div><!-- container -->
</body>
</html>
