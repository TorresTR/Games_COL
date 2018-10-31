<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/MasterAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Administrador_editar_usuario.aspx.cs" Inherits="View_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100"><asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LB_titNombre" runat="server" Text="Nombre:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LB_nombre" runat="server"></asp:Label>
            </td>
          
            <td>
                <asp:TextBox ID="TB_nombre" runat="server" ValidationGroup="1" MaxLength="30" onpaste = "return false;"></asp:TextBox>
                <cc1:filteredtextboxextender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars=" 'ñ" TargetControlID="TB_nombre" />
            
                        <asp:RequiredFieldValidator ID="RFV_nombre" runat="server" ControlToValidate="TB_nombre" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LB_titNick" runat="server" Text="Nick:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LB_nick" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TB_nick" runat="server" ValidationGroup="1" MaxLength="12" onpaste = "return false;"></asp:TextBox>
                <cc1:filteredtextboxextender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars=" 'ñ" TargetControlID="TB_nick" />
            
                        <asp:RequiredFieldValidator ID="RFV_nombre0" runat="server" ControlToValidate="TB_nick" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LB_titPuntos" runat="server" Text="Puntos"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LB_puntos" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TB_puntos" runat="server" ValidationGroup="1" MaxLength="5"  onpaste = "return false;"></asp:TextBox>
                <cc1:filteredtextboxextender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars=" 'ñ" TargetControlID="TB_puntos" />
                 
            
                        <asp:RequiredFieldValidator ID="RFV_nombre1" runat="server" ControlToValidate="TB_puntos" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LB_titRango" runat="server" Text="Rango:"></asp:Label>
                <br />
                <asp:Label ID="LB_id" runat="server" Visible="False"></asp:Label>
            </td>
            <td>&nbsp;
                <asp:Label ID="LB_rango" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td>
                <asp:DropDownList ID="DDL_rango" runat="server" DataSourceID="ODS_rangoU" DataTextField="tipo" DataValueField="id">
                </asp:DropDownList>
                &nbsp;
                <asp:RequiredFieldValidator ID="RFV_rango" runat="server" ControlToValidate="DDL_rango" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:ObjectDataSource ID="ODS_rangoU" runat="server" SelectMethod="obtenerRangousuario" TypeName="Logica.L_persistencia"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="LB_titCorreo" runat="server" Text="Correo:"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:Label ID="LB_correo" runat="server"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="TB_correo" runat="server" MaxLength="50" TextMode="Email" onkeyup = "keyUP(event.keyCode)" onkeydown = "return isAlphaNumeric(event.keyCode);" onpaste = "return false;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV_correo" runat="server" ControlToValidate="TB_correo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="text-center" colspan="3">
                <asp:Button ID="BT_editar" runat="server" CssClass="btn btn-outline-info" OnClick="BT_editar_Click" Text="Editar" />
            </td>
        </tr>
        <tr>
            <td class="text-center" colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BT_guardar" runat="server" CssClass="btn btn-outline-warning" OnClick="BT_guardar_Click" Text="Guardar Cambios" ValidationGroup="1"/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BT_volver" runat="server" CssClass="btn btn-outline-success" OnClick="BT_volver_Click" Text="Volver" />
            </td>
        </tr>
    </table>
</asp:Content>

