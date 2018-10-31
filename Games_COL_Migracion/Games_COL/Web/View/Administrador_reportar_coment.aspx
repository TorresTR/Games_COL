<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/MasterAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Administrador_reportar_coment.aspx.cs" Inherits="View_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
        <tr><asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
            <td class="text-center" colspan="2">
                <asp:Label ID="LB_titReportCom" runat="server" Text="REPORTAR COMENTARIOS"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right">
                <asp:Label ID="LB_titComentRepor" runat="server" Text="Comentario a reportar"></asp:Label>
                : </td>
            <td>
                <asp:Label ID="LB_Id_comentario" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="text-center" colspan="2">
                <asp:Label ID="LB_titMotivo" runat="server" Text="Motivo:"></asp:Label>
            </td>
        </tr>
      
        <tr>
            <td class="text-center" colspan="2">
                <asp:TextBox ID="TB_motivoR" runat="server" Height="151px" Width="281px" 
                    MaxLength="60" ValidationGroup="1"  onpaste = "return false;"></asp:TextBox>
            <cc1:filteredtextboxextender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars=" 'ñ" TargetControlID="TB_motivoR" />
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

