<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/Paguina_principal.master" AutoEventWireup="true" CodeFile="~/Controller/contactenos.aspx.cs" Inherits="View_contactenos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
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
                <asp:TextBox ID="TB_correo" runat="server" TextMode="Email" Width="206px" ValidationGroup="1" MaxLength="50" onpaste = "return false;"></asp:TextBox>
               
                <asp:RequiredFieldValidator ID="RFV_correo" runat="server" ControlToValidate="TB_correo" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="LB_duda" runat="server" Text="Duda/inquietud/sugerencia:"></asp:Label>
            </td>
            <td class="auto-style7">
               
                 <asp:RequiredFieldValidator ID="RFV_sugerencias" runat="server" ControlToValidate="TB_sugerencias"
                     ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
              
                </td>
        </tr>
        <tr>
            <td class="auto-style4" colspan="2">
                <asp:TextBox ID="TB_sugerencias" runat="server" Height="154px" TextMode="MultiLine" Width="381px" ValidationGroup="1" MaxLength="70"  onpaste = "return false;"></asp:TextBox>
                <cc1:filteredtextboxextender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars=" 'ñ" TargetControlID="TB_sugerencias" />

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

