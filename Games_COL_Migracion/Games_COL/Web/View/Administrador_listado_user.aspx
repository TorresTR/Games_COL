<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Administrador_listado_user.aspx.cs" Inherits="View_Administrador_listado_user" %>

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
                USUARIOS</td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="DL_usuarios" runat="server" BorderColor="White" DataSourceID="ODS_usuarios" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" GridLines="Both">
                    <ItemTemplate>
                        <table class="w-100">
                            <caption>
                                <h1>
                                    <tr>
                                        <b>
                                        <td>Nombre:<asp:Label ID="LB_id" runat="server" Text='<%# Eval("id") %>' Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="LB_nombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp;&nbsp;</td>
                                        <td>Nick:</td>
                                        </b>
                                        <td>
                                            <asp:Label ID="LB_nick" runat="server" Text='<%# Bind("nick") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp;&nbsp;</td>
                                        <b>
                                        <td>Puntos:</td>
                                        </b>
                                        <td>
                                            <asp:Label ID="LB_puntos" runat="server" Text='<%# Bind("puntos") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                        <b>
                                        <td>Rango:</td>
                                        </b>
                                        <td>
                                            <asp:Label ID="LB_rango" runat="server" Text='<%# Bind("tipo") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp; </td>
                                        <td class="auto-style2">Correo: </td>
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
                                </h1>
                            </caption>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ODS_usuarios" runat="server" SelectMethod="listarUserAdmin" TypeName="Logica.L_Usercs"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="text-center">
                MODERADORES</td>
        </tr>
        <tr>
            <td>
                <br />
                <asp:DataList ID="DL_usuarios0" runat="server" BorderColor="White" DataSourceID="ODS_usuarios0" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" GridLines="Both">
                    <ItemTemplate>
                        <table class="w-100">
                            <caption>
                                <h1>
                                    <tr>
                                        <b>
                                        <td>Nombre:<asp:Label ID="LB_id" runat="server" Text='<%# Eval("id") %>' Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="LB_nombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp;&nbsp;</td>
                                        <td>Nick:</td>
                                        </b>
                                        <td>
                                            <asp:Label ID="LB_nick" runat="server" Text='<%# Bind("nick") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp;&nbsp;</td>
                                        <b>
                                        <td>Puntos:</td>
                                        </b>
                                        <td>
                                            <asp:Label ID="LB_puntos" runat="server" Text='<%# Bind("puntos") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                        <b>
                                        <td>Rango:</td>
                                        </b>
                                        <td>
                                            <asp:Label ID="LB_rango" runat="server" Text='<%# Bind("tipo") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp; </td>
                                        <td class="auto-style2">Correo: </td>
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
                                </h1>
                            </caption>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ODS_usuarios0" runat="server" SelectMethod="listarModerAdmin" TypeName="Logica.L_Usercs"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="text-center">
                ADMINISTRADORES</td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="DL_admin" runat="server" BorderColor="White" DataSourceID="ODS_usuarios1" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" GridLines="Both">
                    <ItemTemplate>
                        <table class="w-100">
                            <tr>
                                <caption>
                                    <h1><b>
                                        <td>Nombre:</td>
                                        <td>
                                            <asp:Label ID="LB_nombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp;&nbsp;</td>
                                        <td>Nick:</td>
                                        </b>
                                        <td>
                                            <asp:Label ID="LB_nick" runat="server" Text='<%# Bind("nick") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp;&nbsp;</td>
                                        <b>
                                        <td>Puntos:</td>
                                        </b>
                                        <td>
                                            <asp:Label ID="LB_puntos" runat="server" Text='<%# Bind("puntos") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                        <b>
                                        <td>Rango:</td>
                                        </b>
                                        <td>
                                            <asp:Label ID="LB_rango" runat="server" Text='<%# Bind("tipo") %>'></asp:Label>
                                        </td>
                                        <td>&nbsp; </td>
                                        <td>Correo: </td>
                                        <td>
                                            <asp:Label ID="LB_correo" runat="server" Text='<%# Bind("correo") %>'></asp:Label>
                                        </td>
                                        <caption>
                                            <h1></h1>
                                        </caption>
                                    </h1>
                                </caption>
                            </tr>
                            <tr>
                                <td colspan="14">
                                <hr />
                                    &nbsp; &nbsp;</td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ODS_usuarios1" runat="server" SelectMethod="listarAdministradoresAdmin" TypeName="Logica.L_Usercs"></asp:ObjectDataSource>
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




