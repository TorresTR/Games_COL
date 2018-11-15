<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile ="~/View/MasterAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Administrador_SWcolegio.aspx.cs" Inherits="View_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table class="w-100">
        <tr>
            <td class="auto-style2">
                <asp:GridView ID="GV_estudiantes" runat="server">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="BT_invitar" runat="server" OnClick="BT_invitar_Click" Text="Invitar" CssClass="btn btn-outline-warning" />
                                <asp:Label ID="Label1" runat="server" Text="<%# Bind('correo') %>" Visible="False"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Button ID="BT_voler" runat="server" Text="Volver" CssClass="btn btn-outline-danger" OnClick="BT_voler_Click"/>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>

