<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Administrador_atencion_bloquer_post.aspx.cs" Inherits="View_Administrador_atencion_bloquer_post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style3 {
            margin-right: 276px;
        }
        .auto-style4 {
            width: 74%;
            text-align: left;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
        <tr>
            <td>
                
                
        <div>
            <div class="text-center">
            <asp:DataList ID="DL_postBloqueado" runat="server" DataSourceID="ODS_obtenerPostReportados" CssClass="auto-style3" Width="400px">
        <ItemTemplate>
            <br />
            <table class="w-100">
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="LB_idReporte" runat="server" Text="ID Reporte:" Visible="False"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="LB_muestraIDreporte" runat="server" Text='<%# Bind("id_reporte") %>' Visible="False"></asp:Label>
                        &nbsp;&nbsp;
                        <br />
                        <asp:Label ID="LB_idReporte0" runat="server" Text="ID post Reportado:" Visible="False"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="LB_idPost" runat="server" Text='<%# Bind("id_post") %>' Visible="False"  ></asp:Label>
                        <br />
                        <asp:Label ID="LB_titulo" runat="server" Text="Titulo:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="LB_muestraTitulo" runat="server" Text='<%# Bind("titulo") %>'></asp:Label>
                        <br />
                        <asp:Label ID="LB_contenido" runat="server" Text="Contenido:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="LB_muestraContenido" runat="server" Text='<%# Bind("contenido") %>'></asp:Label>
                        <br />
                        <asp:Label ID="LB_userRepo" runat="server" Text="User reportador:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="LB_userReportador" runat="server" Text='<%# Bind("nick") %>'></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="BT_vermas" runat="server" Text="Ver mas"  CommandName="vermas" CommandArgument='<%# Eval("id_post") %>' OnClick="BT_vermas_Click" CssClass="btn btn-outline-warning"/>
                        <br />
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
            </div>
&nbsp;
            <asp:ObjectDataSource ID="ODS_obtenerPostReportados" runat="server" SelectMethod="obtenerpostReport" TypeName="Logica.L_Usercs"></asp:ObjectDataSource>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Bt_volver" runat="server" CssClass="btn btn-outline-info" OnClick="Bt_volver_Click" Text="Volver" />
            <br />
        </div>

            </td>
        </tr>
    </table>
</asp:Content>



