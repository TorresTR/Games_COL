﻿<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/MasterAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Administrador_listado_user.aspx.cs" Inherits="View_Administrador_listado_user" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <style type="text/css">
        .auto-style2 {
            width: 57px;
        }
    </style>
    
</asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <table class="w-100">
        <tr>
            <td class="text-center">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Label ID="LB_titUsarios" runat="server" Text="USUARIOS"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="DL_usuarios" runat="server" BorderColor="White" DataSourceID="ODS_usuarios" Font-Bold="True" Font-Italic="False" 
                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" GridLines="Both" OnItemDataBound="DL_usuarios_RowDataBound">
                    <ItemTemplate>
                        <table class="w-100">
                            <caption>
                                <h1>
                                    <tr>
                                        <b>
                                        <td>
                                            <asp:Label ID="LB_titNombre" runat="server" Text="Nombre:"></asp:Label>
                                            <asp:Label ID="LB_id" runat="server" Text='<%# Eval("id") %>' Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="LB_nombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp;&nbsp;</td>
                                        <td>
                                            <asp:Label ID="LB_titNick" runat="server" Text="Nick:"></asp:Label>
                                        </td>
                                        </b>
                                        <td>
                                            <asp:Label ID="LB_nick" runat="server" Text='<%# Bind("nick") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp;&nbsp;</td>
                                        <b>
                                        <td>
                                            <asp:Label ID="LB_titPuntos" runat="server" Text="Puntos:"></asp:Label>
                                        </td>
                                        </b>
                                        <td>
                                            <asp:Label ID="LB_puntos" runat="server" Text='<%# Bind("puntos") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                        <b>
                                        <td>
                                            <asp:Label ID="LB_titRango" runat="server" Text="Rango:"></asp:Label>
                                        </td>
                                        </b>
                                        <td>
                                            <%--<asp:Label ID="LB_rango" runat="server" Text='<%# Bind("tipo") %>'></asp:Label>--%>
                                        </td>
                                        <td>&nbsp; </td>
                                        <td class="auto-style2">
                                            <asp:Label ID="LB_titCorreo" runat="server" Text="Correo:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="LB_correo" runat="server" Text='<%# Bind("correo") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button ID="BT_editar" runat="server" CssClass="btn btn-outline-info" OnClick="BT_editar_Click" Text="Editar" />
                                        </td>
                                        <td>
                                            <asp:Button ID="BT_eliminar" runat="server" CssClass="btn btn-outline-danger" OnClick="BT_eliminar_Click" Text="Eliminar" />
                                        </td>
                                        <caption>
                                            <h1></h1>
                                        </caption>
                                        <caption>
                                            <h1></h1>
                                        </caption>
                                    </tr>
                                    <tr>
                                        <td colspan="14">
                                            <hr />
                                            &nbsp; &nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <caption>
                                        <h1></h1>
                                    </caption>
                                    <caption>
                                        <h1></h1>
                                    </caption>
                                    <caption>
                                        <h1></h1>
                                    </caption>
                                    <caption>
                                        <h1></h1>
                                    </caption>
                                    <caption>
                                        <h1></h1>
                                    </caption>
                                </h1>
                            </caption>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ODS_usuarios" runat="server" SelectMethod="obtenerUsuario" TypeName="Logica.L_persistencia"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="text-center">
                <asp:Label ID="LB_titModer" runat="server" Text="MODERADORES"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <asp:DataList ID="DL_moder" runat="server" 
                    BorderColor="White" DataSourceID="ODS_usuarios0" Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                    Font-Strikeout="False" Font-Underline="False" GridLines="Both" OnItemDataBound="DL_moder_RowDataBound">
                    <ItemTemplate>
                        <table class="w-100">
                            <caption>
                                <h1>
                                    <tr>
                                        <b>
                                        <td>
                                            <asp:Label ID="LB_titNombre" runat="server" Text="Nombre:"></asp:Label>
                                            <asp:Label ID="LB_id" runat="server" Text='<%# Eval("id") %>' Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="LB_nombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp;&nbsp;</td>
                                        <td>
                                            <asp:Label ID="LB_titNick" runat="server" Text="Nick:"></asp:Label>
                                        </td>
                                        </b>
                                        <td>
                                            <asp:Label ID="LB_nick" runat="server" Text='<%# Bind("nick") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp;&nbsp;</td>
                                        <b>
                                        <td>
                                            <asp:Label ID="LB_titPuntos" runat="server" Text="Puntos:"></asp:Label>
                                        </td>
                                        </b>
                                        <td>
                                            <asp:Label ID="LB_puntos" runat="server" Text='<%# Bind("puntos") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                        <b>
                                        <td>
                                            <asp:Label ID="LB_titRango" runat="server" Text="Rango:"></asp:Label>
                                        </td>
                                        </b>
                                        <td>
                                       
                                        </td>
                                        <td>&nbsp; </td>
                                        <td class="auto-style2">
                                            <asp:Label ID="LB_titCorreo" runat="server" Text="Correo:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="LB_correo" runat="server" Text='<%# Bind("correo") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button ID="BT_editar" runat="server" CssClass="btn btn-outline-info" OnClick="BT_editar_moder_Click" Text="Editar" />
                                        </td>
                                        <td>
                                            <asp:Button ID="BT_eliminar" runat="server" CssClass="btn btn-outline-danger" OnClick="BT_eliminar_Click" Text="Eliminar" />
                                        </td>
                                        <caption>
                                            <h1></h1>
                                        </caption>
                                        <caption>
                                            <h1></h1>
                                        </caption>
                                    </tr>
                                    <tr>
                                        <td colspan="14">
                                            <hr />
                                            &nbsp; &nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <caption>
                                        <h1></h1>
                                    </caption>
                                    <caption>
                                        <h1></h1>
                                    </caption>
                                </h1>
                            </caption>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ODS_usuarios0" runat="server" SelectMethod="obtenerModerador" TypeName="Logica.L_persistencia"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="text-center">
                <asp:Label ID="LB_titAdministradores" runat="server" Text="ADMINISTRADORES"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="DL_admin" runat="server" 
                    BorderColor="White" DataSourceID="ODS_usuarios1" Font-Bold="True" 
                    Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" GridLines="Both" OnItemDataBound="DL_admin_RowDataBound">
                    <ItemTemplate>
                        <table class="w-100">
                            <caption>
                                <h1>
                                    <tr>
                                        <b>
                                        <td>
                                            <asp:Label ID="LB_titNombre" runat="server" Text="Nombre:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="LB_nombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp;&nbsp;</td>
                                        <td>
                                            <asp:Label ID="LB_titNick" runat="server" Text="Nick:"></asp:Label>
                                        </td>
                                        </b>
                                        <td>
                                            <asp:Label ID="LB_nick" runat="server" Text='<%# Bind("nick") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp;&nbsp;</td>
                                        <b>
                                        <td>
                                            <asp:Label ID="LB_titPuntos" runat="server" Text="Puntos:"></asp:Label>
                                        </td>
                                        </b>
                                        <td>
                                            <asp:Label ID="LB_puntos" runat="server" Text='<%# Bind("puntos") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                        <b>
                                        <td>
                                            <asp:Label ID="LB_titRango" runat="server" Text="Rango:"></asp:Label>
                                        </td>
                                        </b>
                                        <td>
                                            <asp:Label ID="LB_rango" runat="server" Text='<%# Bind("id_rango") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp; </td>
                                        <td>
                                            <asp:Label ID="LB_titCorreo" runat="server" Text="Correo:"></asp:Label>
&nbsp;</td>
                                        <td>
                                            <asp:Label ID="LB_correo" runat="server" Text='<%# Bind("correo") %>'></asp:Label>
                                        </td>
                                        <caption>
                                            <h1></h1>
                                        </caption>
                                        <caption>
                                            <h1></h1>
                                        </caption>
                                    </tr>
                                    <tr>
                                        <td colspan="14">
                                            <hr />
                                            &nbsp; &nbsp;</td>
                                    </tr>
                                </h1>
                            </caption>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ODS_usuarios1" runat="server" SelectMethod="obtenerAdmin" TypeName="Logica.L_persistencia"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BT_reporUser" runat="server" OnClick="BT_reporUser_Click" Text="Reporte Usuarios" CssClass="btn btn-outline-info" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BT_reporModer" runat="server" OnClick="BT_reporModer_Click" Text="Reporte Moderadores" CssClass="btn btn-outline-info" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BT_reporAdmin" runat="server" OnClick="BT_reporAdmin_Click" Text="Reporte Administradores" CssClass="btn btn-outline-info" />
&nbsp;
                <asp:Button ID="BT_volver" runat="server" OnClick="BT_volver_Click" Text="Volver" CssClass="btn btn-outline-danger" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>




