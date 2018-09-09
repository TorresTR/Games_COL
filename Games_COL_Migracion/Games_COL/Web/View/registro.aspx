<%@ Page Language="C#"   AutoEventWireup="true" CodeFile="~/Controller/registro.aspx.cs" Inherits="View_registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="Styles/Estilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            text-align: center;
            height: 27px;
        }
        .auto-style4 {
            text-align: center;
            height: 33px;
        }
        .auto-style5 {
            text-align: center;
            width: 388px;
        }
        .auto-style6 {
            text-align: center;
            height: 33px;
            width: 388px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center" class="table-active">
                <tr>
                    <td class="auto-style2" colspan="2"><h2>
                        <asp:Label ID="Label1" runat="server" Text="Registro"></asp:Label>
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TB_nombre" runat="server" ValidationGroup="1" MaxLength="30"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV_nombre" runat="server" ControlToValidate="TB_nombre" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="validator_nombre"
                            runat="server" 
                            ControlToValidate="TB_nombre" 
                            ErrorMessage="*Solo letras" 
                            ForeColor="Red" 
                            ValidationExpression="^[A-Za-z ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Text="Nick:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TB_nick" runat="server" ValidationGroup="1" MaxLength="12"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV_nick" runat="server" ControlToValidate="TB_nick" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="validator_nick"
                            runat="server" 
                            ControlToValidate="TB_nick" 
                            ErrorMessage="*no validos" 
                            ForeColor="Red" 
                            ValidationExpression="^[A-Za-z0-9_-ñÑ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label4" runat="server" Text="Correo:"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TB_email" runat="server" TextMode="Email" Width="179px" ValidationGroup="1" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV_correo" runat="server" 
                            ControlToValidate="TB_email" ErrorMessage="*necesario" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                       
                    &nbsp;
                       
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label5" runat="server" Text="Contraseña:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TB_pass" runat="server" TextMode="Password" ValidationGroup="1" MaxLength="12"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV_contraseña" runat="server" ControlToValidate="TB_pass" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="valitar_contra"
                            runat="server" 
                            ControlToValidate="TB_pass" 
                            ErrorMessage="*no valido" 
                            ForeColor="Red" 
                            ValidationExpression="^[A-Za-z0-9_-ñÑ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label7" runat="server" Text="Connfirme contraseña:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TB_confirmapass" runat="server" TextMode="Password" ValidationGroup="1" MaxLength="12"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV_confirmapass" runat="server" ControlToValidate="TB_confirmapass" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="valitar_confirmapasss"
                            runat="server" 
                            ControlToValidate="TB_confirmapass" 
                            ErrorMessage="*no valido" 
                            ForeColor="Red" 
                            ValidationExpression="^[A-Za-z0-9_-ñÑ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" colspan="2">
                        <asp:Label ID="LB_mensaje" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Button ID="B_registrar" runat="server" OnClick="B_registrar_Click" Text="Registrar" CssClass="btn btn-outline-success" ValidationGroup="1" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="B_volver" runat="server" CssClass="btn btn-outline-danger" OnClick="B_volver_Click" Text="Volver" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
