﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterModerador.master" AutoEventWireup="true" CodeFile="~/Controller/Moderador_listado_user.aspx.cs" Inherits="View_Default" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <table class="w-100">
        <tr>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="DataList1" runat="server" DataSourceID="ODS_usuarios" BorderColor="White" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" GridLines="Both">
                    <ItemTemplate>
                        <table class="w-100">
                            <caption>
                                <h1>
                                    <tr>
                                        <b>
                                        <td>Nick:<asp:Label ID="LB_id" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                        </td>
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
                                        <td>
                                            <asp:Button ID="BT_eliminar" runat="server" CssClass="btn btn-outline-warning" OnClick="BT_eliminar_Click" Text="Eliminar" />
                                        </td>
                                        <caption>
                                            <h1></h1>
                                        </caption>
                                        <caption>
                                            <h1></h1>
                                        </caption>
                                    </tr>
                                    <tr>
                                        <td colspan="9">
                                            <hr />
                                        </td>
                                    </tr>
                                </h1>
                            </caption>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="ODS_usuarios" runat="server" SelectMethod="ListarUsuarios" TypeName="DAOUsuario"></asp:ObjectDataSource>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <CR:CrystalReportViewer ID="CRV_reporte_moderador" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" ReportSourceID="CRS_moderador" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" />
                <CR:CrystalReportSource ID="CRS_moderador" runat="server">
                    <Report FileName="~/Reportes/Reporte_Moderador.rpt">
                    </Report>
                </CR:CrystalReportSource>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BT_volver" runat="server" CssClass="btn btn-outline-danger" OnClick="BT_volver_Click" Text="Volver" />
            </td>
        </tr>
    </table>
</asp:Content>



