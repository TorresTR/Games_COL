﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterModerador.master" AutoEventWireup="true" CodeFile="~/Controller/Moderador_pc.aspx.cs" Inherits="View_Moderador_pc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style4 {
            width: 329px;
        }
        .auto-style5 {
            width: 50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>

        &nbsp;&nbsp;
        <asp:Button ID="BT_home" runat="server" Text="HOME" OnClick="BT_home_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_xbox" runat="server" Text="XBOX" OnClick="BT_xbox_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_ps" runat="server" Text="PlayStation" OnClick="BT_ps_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_android" runat="server" Text="Android" OnClick="BT_android_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
         &nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:TextBox ID="TB_buscador" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="validatorBusq" runat="server"
                    ControlToValidate="TB_buscador" 
                    ErrorMessage="*Ingrese solo letras Y Numeros" 
                    ForeColor="Red" ValidationExpression="^[A-Za-z0-9 ñÑ]*$"></asp:RegularExpressionValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BT_buscar" runat="server" CssClass="btn btn-outline-info" OnClick="Button3_Click" Text="Buscar" />


    </div>
    <table class="w-100">
        <tr>
            <td class="auto-style5">
                
    <asp:DataList ID="DataList2" runat="server" DataSourceID="ODS_noticas" >
        <ItemTemplate>
            <br />
            <table class="table-active">
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="LB_titulo" runat="server" Text="Titulo"></asp:Label>
                        <asp:Label ID="LB_muestraTitulo" runat="server" Text='<%# Bind("titulo") %>'></asp:Label>
                        <br />
                        <asp:Label ID="LB_autor" runat="server" Text="autor"></asp:Label>
                        <asp:Label ID="LB_muestraAutor" runat="server" Text='<%# Bind("autor") %>'></asp:Label>
                        <br />
                        <asp:Label ID="LB_id" runat="server" visible="False" Text='<%# Bind("id") %>'></asp:Label>
                        <br />
                        <asp:Label ID="LB_etiqueta" runat="server" Text="Etiqueta:"></asp:Label>
                        <asp:Label ID="LB_noticiaNombre" runat="server" Text="Noticia"></asp:Label>
                        <br />
                    </td>
                    <td>
                        <asp:Button ID="BT_verNoticas" runat="server" CssClass="btn btn-outline-danger" OnClick="BT_verNoticas_Click" Text="Ver mas" style="height: 31px" />
                    </td>
                </tr>
            </table>
            <br />
            <hr />
        </ItemTemplate>
    </asp:DataList>
                <asp:ObjectDataSource ID="ODS_noticas" runat="server" SelectMethod="ObtenerNoticias" TypeName="DAOUsuario"></asp:ObjectDataSource></td>
            <td>
                
                <asp:Label ID="LB_busq" runat="server"></asp:Label>
                
    <asp:DataList ID="DL_resultado" runat="server" >
        <ItemTemplate>
            <br />
            <table class="auto-style2">
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="LB_titulo" runat="server" Text="Titulo:"></asp:Label>
                        <asp:Label ID="LB_muestraTitulo" runat="server" Text='<%# Bind("titulo") %>'></asp:Label>
                        <br />
                        <asp:Label ID="LB_id" runat="server" Text='<%# Bind("id") %>'  visible="False"></asp:Label>
                        <br />
                        <asp:Label ID="LB_autor" runat="server" Text="Autor:"></asp:Label>
                        <asp:Label ID="LB_muestraAutor" runat="server" Text='<%# Bind("autor") %>'></asp:Label>
                        <br />
                        <asp:Label ID="LB_etiqueta" runat="server" Text="Etiqueta:"></asp:Label>
                        <asp:Label ID="LB_etiquetaMuestra" runat="server" Text='<%# Bind("etiqueta") %>'></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="BT_vermas" runat="server" Text="Ver mas"  CommandName="vermas" CommandArgument='<%# Eval("id") %>' OnClick="BT_vermas_Click" CssClass="btn btn-outline-warning"/>
                    </td>
                </tr>
            </table>
            <br />
            <hr />
            <br />
            <br />
        </ItemTemplate>
    </asp:DataList>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
    <asp:DataList ID="DataList1" runat="server" DataSourceID="ODS_datauser">
        <ItemTemplate>
            <br />
            <table class="auto-style2">
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="LB_titulo" runat="server" Text="Titulo:"></asp:Label>
                        <asp:Label ID="LB_muestraTitulo" runat="server" Text='<%# Bind("titulo") %>'></asp:Label>
                        <br />
                        <asp:Label ID="LB_id" runat="server" Text='<%# Bind("id") %>'  visible="False"></asp:Label>
                        <br />
                        <asp:Label ID="LB_autor" runat="server" Text="Autor:"></asp:Label>
                        <asp:Label ID="LB_muestraAutor" runat="server" Text='<%# Bind("autor") %>'></asp:Label>
                        <br />
                        <asp:Label ID="LB_etiqueta" runat="server" Text="Etiqueta:"></asp:Label>
                        <asp:Label ID="LB_etiquetaMuestra" runat="server" Text='<%# Bind("etiqueta") %>'></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="BT_vermas" runat="server" Text="Ver mas"  CommandName="vermas" CommandArgument='<%# Eval("id") %>' OnClick="BT_vermas_Click" CssClass="btn btn-outline-warning"/>
                    </td>
                </tr>
            </table>
            <br />
            <hr />
            <br />
            <br />
        </ItemTemplate>
    </asp:DataList>
    <asp:ObjectDataSource ID="ODS_datauser" runat="server" SelectMethod="ObtenerpsotPc" TypeName="DAOUsuario"></asp:ObjectDataSource>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
