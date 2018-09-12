<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterModerador.master" AutoEventWireup="true" CodeFile="~/Controller/Moderador_reportar_coment.aspx.cs" Inherits="View_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
        <tr>
            <td class="text-center" colspan="2">&nbsp;<asp:Label ID="LB_titulo" runat="server" Text="REPOTAR COMENTARIOS"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right">&nbsp;<asp:Label ID="LB_titComentRepor" runat="server" Text="Comentario a reportar:"></asp:Label>
&nbsp;</td>
            <td>
                <asp:Label ID="LB_Id_comentario" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="text-center" colspan="2">Motivo:
                <asp:Label ID="LB_motivo" runat="server" Text="Motivo:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="text-center" colspan="2">
                <asp:TextBox ID="TB_motivoR" runat="server" Height="151px" Width="281px" MaxLength="50" ValidationGroup="1"></asp:TextBox>
                <asp:RegularExpressionValidator ID="validator_reporte" 
                    runat="server" 
                    ControlToValidate="TB_motivoR" 
                    ErrorMessage="*" 
                    ForeColor="Red" 
                    ValidationExpression="^[A-Za-z0-9 ñÑ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RFV_reportecontent" runat="server" 
                    ControlToValidate="TB_motivoR" ErrorMessage="*" ForeColor="Red"
                    ValidationGroup="1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="text-center" colspan="2">
                <asp:Button ID="BT_reportar" runat="server" CssClass="btn btn-outline-danger" OnClick="BT_reportar_Click" Text="Reportar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BT_volver" runat="server" CssClass="btn btn-outline-info" Text="Volver" OnClick="BT_volver_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

