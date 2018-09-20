<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/MasterModerador.master" AutoEventWireup="true" CodeFile="~/Controller/Moderador_atencion_bloquer_post.aspx.cs" Inherits="View_Moderador_atencion_bloquer_post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 50%;
        }
        .auto-style3 {
            margin-right: 276px;
        }
        .auto-style4 {
            width: 98%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
        <tr>
            <td class="auto-style2">
                
                
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <asp:DataList ID="DL_PostReport" runat="server" DataSourceID="ODS_obtenerPostReportados" CssClass="auto-style3" Width="362px" OnItemDataBound="DL_noticias_RowDataBound">
        <ItemTemplate>
            <br />
            <table class="auto-style4">
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="LB_idReporte" runat="server" Text="ID Reporte:" Visible="False"></asp:Label>
                        &nbsp;
                        <asp:Label ID="LB_muestraIDreporte" runat="server" Text='<%# Bind("id_reporte") %>' Visible="False"></asp:Label>
                        <br />
                        <asp:Label ID="LB_idPostReport" runat="server" Text="ID post Reportado:" Visible="False"></asp:Label>
                        &nbsp;
                        <asp:Label ID="LB_idPost" runat="server" Text='<%# Bind("id_post") %>' Visible="False"  ></asp:Label>
                        <br />
                        <asp:Label ID="LB_titulo" runat="server" Text="Titulo:"></asp:Label>
                        &nbsp;
                        <asp:Label ID="LB_muestraTitulo" runat="server" Text='<%# Bind("titulo") %>'></asp:Label>
                        <br />
                        <asp:Label ID="LB_contenido" runat="server" Text="Contenido:"></asp:Label>
                        &nbsp;
                        <asp:Label ID="LB_muestraContenido" runat="server" Text='<%# Bind("contenido") %>'></asp:Label>
                        <br />
                        <asp:Label ID="LB_userRepo" runat="server" Text="User reportador:"></asp:Label>
                        &nbsp;&nbsp;
                        <asp:Label ID="LB_userReportador" runat="server" Text='<%# Bind("nick") %>'></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="BT_vermas" runat="server" Text="Ver mas"  CommandName="vermas" CommandArgument='<%# Eval("id_post") %>' OnClick="BT_vermas_Click" CssClass="btn btn-outline-warning"/>
                        &nbsp;<br />
                        <br />
                        <asp:Button ID="BT_bloquear" runat="server" Text="Bloquear"  CommandName="Bloquear" CommandArgument='<%# Eval("id_post") %>' CssClass="btn btn-outline-warning" OnClick="BT_bloquear_Click"/>
                    </td>
                </tr>
            </table>
            <br />
            <hr />
            <br />
            <br />
        </ItemTemplate>
    </asp:DataList>
            <asp:ObjectDataSource ID="ODS_obtenerPostReportados" runat="server" SelectMethod="obtenerpostReport" TypeName="Logica.L_Usercs"></asp:ObjectDataSource>
        </div>

            </td>
            <td>
                <br />
                <asp:Button ID="Bt_volver" runat="server" CssClass="btn btn-outline-info" OnClick="Bt_volver_Click" Text="Volver" />
            </td>
        </tr>
    </table>
</asp:Content>

