<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/MasterUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/usuario_verRespuestas.aspx.cs" Inherits="View_usuario_verRespuestas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
        <tr>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" colspan="2">
                <asp:Label ID="LB_verRespuesta" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="text-center" colspan="2">
                
                                <asp:Button ID="BT_volver" runat="server" Text="Volver" CssClass="btn btn-outline-success" OnClick="BT_volver_Click"/>
                </td>
        </tr>
    </table>
</asp:Content>

