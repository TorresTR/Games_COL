<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/MasterAdministrador.master"  AutoEventWireup="true" CodeFile="~/Controller/Administrador_verMasPostReportado.aspx.cs" Inherits="View_Administrador_verMasPostReportado" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table class="w-100">
        <tr>
            <td class="text-center">
                <asp:Label ID="LB_mostrarAutor" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Label ID="LB_contenido" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="text-center">
                <asp:Button ID="BT_volver" runat="server" OnClick="BT_volver_Click" Text="Volver" CssClass="btn btn-outline-danger" />
            </td>
        </tr>
    </table>
    
</asp:Content>

