<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/MasterUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/usuarios_pqr.aspx.cs" Inherits="View_usuarios_pqr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style4 {
            text-align: right;
            width: 548px;
        }
        .auto-style5 {
            width: 50%;
        }
        .auto-style6 {
            width: 50%;
            height: 32px;
        }
        .auto-style7 {
            height: 32px;
        }
        .auto-style8 {
            width: 50%;
            text-align: right;
            height: 69px;
        }
        .auto-style9 {
            width: 50%;
            height: 23px;
            text-align: right;
        }
        .auto-style10 {
            height: 23px;
        }
        .auto-style11 {
            height: 23px;
            text-align: center;
        }
        .auto-style12 {
            height: 43px;
            text-align: center;
        }
        .auto-style13 {
            height: 69px;
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
    <table class="auto-style2">
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="LB_aunto" runat="server" Text="Asunto:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TB_asunto" runat="server" Width="261px" ValidationGroup="1" MaxLength="20" min="10" onkeyup = "keyUP(event.keyCode)" 
            onkeydown = "return isAlphaNumeric(event.keyCode);" onpaste = "return false;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV_asunto" runat="server" ControlToValidate="TB_asunto" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="validator_asunto" runat="server"
                    ControlToValidate="TB_asunto" 
                    ErrorMessage="*" 
                    ForeColor="Red" ValidationExpression="^[A-Za-z0-9 ñÑ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="LB_tipoSolicitud" runat="server" Text="Tipo de Solicitud:"></asp:Label>
            </td>
            <td class="auto-style13">
                <asp:DropDownList ID="DDL_tipoSolicitud" runat="server" DataSourceID="ODS_obtenerpqr" DataTextField="estado" DataValueField="id_pqrestados" CssClass="btn btn-primary dropdown-toggle" ValidationGroup="1">
                </asp:DropDownList>
                <asp:RangeValidator ID="RV_tiposolicitud" runat="server" ErrorMessage="*" ForeColor="Red" MaximumValue="4" MinimumValue="2" ControlToValidate="DDL_tipoSolicitud" ValidationGroup="1"></asp:RangeValidator>
                <asp:ObjectDataSource ID="ODS_obtenerpqr" runat="server" SelectMethod="retornoPqrData" TypeName="Logica.L_Usercs"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">
                <asp:Label ID="LB_solicitud" runat="server" Text="Solicitud:"></asp:Label>
            </td>
            <td class="auto-style10">
                <asp:RequiredFieldValidator ID="RFV_contenido" runat="server" ControlToValidate="TB_solicitud" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="REV_solicitud" runat="server"
                    ControlToValidate="TB_solicitud" 
                    ErrorMessage="*" 
                    ForeColor="Red" ValidationExpression="^[A-Za-z0-9 ¿?!¡ñÑ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="REV_max" runat="server"
                    ControlToValidate="TB_solicitud" 
                    ErrorMessage="*" 
                    ForeColor="Red" ValidationExpression="^[\s\S]{0,150}$" ValidationGroup="1"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style11" colspan="2">
                <asp:TextBox ID="TB_solicitud" runat="server" Height="200px" TextMode="MultiLine" Width="500px" ValidationGroup="1" MaxLength="150" onkeyup = "keyUP(event.keyCode)" 
            onkeydown = "return isAlphaNumeric(event.keyCode);" onpaste = "return false;"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td class="auto-style12" colspan="2">
                <asp:Button ID="BT_envio" runat="server" OnClick="BT_envio_Click" Text="Enviar Solicitud" CssClass="btn btn-outline-secondary" ValidationGroup="1" />
            &nbsp;&nbsp;&nbsp;
                <asp:Button ID="B_volver" runat="server" CssClass="btn btn-outline-secondary" OnClick="B_volver_Click" Text="Volver" ValidationGroup="0" />
            </td>
        </tr>
    </table>
</asp:Content>

