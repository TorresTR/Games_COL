<%@ Page Title="" Language="C#" MasterPageFile="~/View/Paguina_principal.master" AutoEventWireup="true" CodeFile="~/Controller/Recuperar_contra.aspx.cs" Inherits="View_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style5 {
            text-align: center;
            font-size: medium;
        }
        .auto-style7 {
            width: 50%;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style5" colspan="2">Restablecer Contraseña</td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Label ID="L_digite_nueva" runat="server" Text="Digite su Nueva Contraseña:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TB_digite_nueva_contraseña" runat="server" ValidationGroup="1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV_contra" runat="server" ControlToValidate="TB_digite_nueva_contraseña" 
                    ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="valitar_contra"
                            runat="server" 
                            ControlToValidate="TB_digite_nueva_contraseña" 
                            ErrorMessage="*no valido" 
                            ForeColor="Red" 
                            ValidationExpression="^[A-Za-z0-9_-ñÑ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Label ID="L_Repita_Contraseña" runat="server" Text="Repita su Contraseña:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TB_repita_contraseña" runat="server" ValidationGroup="1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV_repitaContra" runat="server" 
                    ErrorMessage="*" ControlToValidate="TB_repita_contraseña"  ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="REV_repita"
                            runat="server" 
                            ControlToValidate="TB_repita_contraseña" 
                            ErrorMessage="*no valido" 
                            ForeColor="Red" 
                            ValidationExpression="^[A-Za-z0-9_-ñÑ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4" colspan="2">
                <asp:Button ID="BT_cambiar_contraseña" runat="server" OnClick="BT_cambiar_contraseña_Click" Text="Cambiar" CssClass="btn btn-outline-warning" ValidationGroup="1" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="LB_mensaje" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

