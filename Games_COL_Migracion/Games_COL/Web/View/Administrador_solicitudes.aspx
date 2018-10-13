<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/MasterAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Administrador_solicitudes.aspx.cs" Inherits="View_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            height: 35px;
        }
        .auto-style3 {
            width: 87px;
        }
        .auto-style4 {
            height: 35px;
            width: 87px;
            font-size: large;
        }
        .auto-style5 {
            font-size: large;
        }
        .auto-style6 { 
            width: 87px;
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
        <tr>
            <td class="text-center" colspan="2">
                <asp:Label ID="LB_titulo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:DataList ID="DL_solicitudes" runat="server" DataSourceID="ODS_solicitudes" OnItemDataBound="DL_solicitudes_RowDataBound">
                    <ItemTemplate>
                        <table class="w-100">
                            <tr>
                                <td class="auto-style3"><strong><span class="auto-style5">
                                    <asp:Label ID="LB_titUsuario" runat="server" Text=" Id Usuario:"></asp:Label>
&nbsp;</span></strong></td>
                                <td>
                                    <asp:Label ID="LB_id" runat="server" Text='<%# Bind("id_user") %>'></asp:Label>
                                </td>
                                <td rowspan="3">
                                    <asp:Button ID="BT_ascender" runat="server" CssClass="btn btn-outline-success" Text="Ascender" OnClick="BT_ascender_Click" />
                                </td>
                                <td rowspan="3">
                                    <asp:Button ID="BT_ignorar" runat="server" CssClass="btn btn-outline-danger" Text="Ignorar" OnClick="BT_ignorar_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4"><strong>
                                    <asp:Label ID="LB_titPuntos" runat="server" Text="Puntos:"></asp:Label>
                                    </strong></td>
                                <td class="auto-style2">
                                    <asp:Label ID="LB_puntos" runat="server" Text='<%# Bind("puntos") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6"><strong><asp:Label ID="LB_titNick" runat="server" Text="Nick:"></asp:Label>
                                    </strong></td>
                                <td>
                                    <asp:Label ID="LB_nick" runat="server" Text='<%# Bind("nick") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <hr />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ODS_solicitudes" runat="server" SelectMethod="obtenerDatasolicitudesuser" TypeName="Logica.L_persistencia"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BT_volver" runat="server" OnClick="BT_volver_Click" Text="Volver" CssClass="btn btn-outline-danger" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

