﻿<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/MasterAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Administrador_admin_coment.aspx.cs" Inherits="View_Administrador_admin_coment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 158px;
        }
        .auto-style3 {
            width: 133px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    &nbsp;<br />
    <asp:Label ID="LB_mensaje" runat="server" ForeColor="Red"></asp:Label>
    <asp:DataList ID="DL_coment" runat="server" DataSourceID="ODS_reporte_comentarios" Width="448px" OnItemDataBound="DL_admin_coment_RowDataBound">
        <ItemTemplate>
            <table class="w-100">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="LB_titComentario" runat="server" Text="Comentario:"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="LB_comentario" runat="server" Text='<%# Bind("comentario") %>'></asp:Label>
                        <br />
                        <asp:Label ID="LB_id" runat="server" Text='<%# Bind("id_com_reportado") %>' Visible="False"></asp:Label>
                    </td>
                    <td rowspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="BT_bloquear" runat="server" CssClass="btn btn-outline-danger" OnClick="BT_bloquear_Click" Text="Bloquear" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="LB_titmotivo" runat="server" Text="Motivo del reporte:"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="LB_motivo" runat="server" Text='<%# Bind("contenido") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="LB_titUser" runat="server" Text="Usuario que reporto"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="LB_user" runat="server" Text='<%# Bind("nick") %>'></asp:Label>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <br />
&nbsp;
    <asp:ObjectDataSource ID="ODS_reporte_comentarios" runat="server" SelectMethod="obtenercomnetReport" TypeName="Logica.L_Usercs"></asp:ObjectDataSource>
    <asp:Button ID="Bt_volver" runat="server" CssClass="btn btn-outline-info" OnClick="Bt_volver_Click" Text="Volver" />
</asp:Content>



