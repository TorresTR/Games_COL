<%@ Page Title="" Language="C#" MasterPageFile="~/View/Paguina_principal.master" AutoEventWireup="true" CodeFile="~/Controller/contactenos.aspx.cs" Inherits="View_contactenos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style5 {
            width: 50%;
        }
    .auto-style6 {
        width: 50%;
        text-align: right;
    }
    .auto-style7 {
        text-align: left;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        function isAlphaNumeric(keyCode)

    {

        return (((keyCode >= 48 && keyCode <= 57)&& isShift == false) ||                     

               (keyCode >= 65 && keyCode <= 90) || keyCode == 8 ||

            (keyCode >= 96 && keyCode <= 105) || keyCode == 32 )

    }               
    </script>
    <table class="auto-style1">
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="LB_contactenos" runat="server" Text="Contactenos"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="LB_titulo" runat="server" Text="En este espacio es donde se puden enviar las dudas que se tengan o cualquien inquietud a los Administradores solamente ingresa el correo y tu duda"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="LB_correo" runat="server" Text="Correo:"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="TB_correo" runat="server" TextMode="Email" Width="206px" ValidationGroup="1" MaxLength="50" onkeyup = "keyUP(event.keyCode)" 
            onkeydown = "return isAlphaNumeric(event.keyCode);" onpaste = "return false;"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RFV_correo" runat="server" ControlToValidate="TB_correo" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="LB_duda" runat="server" Text="Duda/inquietud/sugerencia:"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:RegularExpressionValidator ID="validator_sugerencias" runat="server"
                    ControlToValidate="TB_sugerencias" 
                    ErrorMessage="*" 
                    ForeColor="Red" ValidationExpression="^[A-Za-z0-9 ñÑ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
                 <asp:RequiredFieldValidator ID="RFV_sugerencias" runat="server" ControlToValidate="TB_sugerencias"
                     ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="REV_max" runat="server"
                    ControlToValidate="TB_sugerencias" 
                    ErrorMessage="*" 
                    ForeColor="Red" ValidationExpression="^[\s\S]{0,150}$" ValidationGroup="1"></asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td class="auto-style4" colspan="2">
                <asp:TextBox ID="TB_sugerencias" runat="server" Height="154px" TextMode="MultiLine" Width="381px" ValidationGroup="1" MaxLength="70" onkeyup = "keyUP(event.keyCode)" 
            onkeydown = "return isAlphaNumeric(event.keyCode);" onpaste = "return false;"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td class="auto-style4" colspan="2">
                <asp:Button ID="BT_envioContacto" runat="server" OnClick="BT_envioContacto_Click" Text="Enviar" CssClass="btn btn-outline-secondary" ValidationGroup="1" />
                <asp:Button ID="B_volver" runat="server" CssClass="btn btn-outline-secondary" OnClick="B_volver_Click" Text="Volver" />
            </td>
        </tr>
    </table>
</asp:Content>

