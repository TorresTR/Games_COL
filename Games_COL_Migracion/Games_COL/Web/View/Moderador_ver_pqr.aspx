﻿<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/MasterModerador.master" AutoEventWireup="true" CodeFile="~/Controller/Moderador_ver_pqr.aspx.cs" Inherits="View_Moderador_ver_pqr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style5 {
            width: 90%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
        <tr>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <br />
                <asp:DataList ID="DL_PQR" runat="server" DataSourceID="ODS_pqr" OnItemDataBound="DL_noticias_RowDataBound">
                    <ItemTemplate>
                        <table class="w-100">
                            <tr>
                                <td class="auto-style5">
                                    <asp:Label ID="LB_autor" runat="server" Text="autor:" Visible="false"></asp:Label>
                                    <asp:Label ID="LB_muestraAutor" runat="server" Visible="false" Text='<%# Bind("usuario") %>'></asp:Label>
                                    <br />
                                    <asp:Label ID="LB_idPQR" runat="server" Text="ID PQR:" Visible="false"></asp:Label>
                                    <asp:Label ID="LB_muestraId" runat="server" Visible="false" Text='<%# Bind("id_pqr") %>'></asp:Label>
                                    <br />
                                    <asp:Label ID="LB_tipoSolicitud" runat="server" Text="Tipo de Solicitud:" Visible="false"></asp:Label>
                                    <asp:Label ID="LB_muestraSolicitud" runat="server" Visible="false" Text='<%# Bind("solicitud") %>'></asp:Label>
                                    <br />
                                    <asp:Label ID="LB_tituloPost" runat="server" Text="Asunto PQR:"></asp:Label>
                                    <asp:Label ID="LB_muestraAsuntoPQR" runat="server" Text='<%# Bind("asunto") %>'></asp:Label>
                                    <br />
                                    <br />
                                </td>
                                <td>
                                    <asp:Button ID="BT_resolver" runat="server" Text="Resolver" CommandName="resolver" CommandArgument='<%# Eval("id_pqr") %>' CssClass="btn btn-outline-info" OnClick="BT_resolver_Click"/>
                                    <br />
                                    <br />
                                    <asp:Button ID="BT_ignorar" runat="server" Text="Ignorar" Width="90px" CommandName="ignorar" CommandArgument='<%# Eval("id_pqr") %>' CssClass="btn btn-outline-danger" OnClick="BT_ignorar_Click" />
                                </td>
                            </tr>
                        </table>
                        <hr />
                        <br />
                        <br />
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ODS_pqr" runat="server" SelectMethod="obtenerPQR" TypeName="Logica.L_persistencia"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BT_volver" runat="server" CssClass="btn btn-outline-danger" OnClick="BT_volver_Click" Text="Volver" />
            </td>
        </tr>
    </table>
</asp:Content>

