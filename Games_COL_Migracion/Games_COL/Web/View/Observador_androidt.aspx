﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Paguina_principal.master" AutoEventWireup="true" CodeFile="~/Controller/Observador_androidt.aspx.cs" Inherits="View_Observador_androidt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">
        .auto-style5 {
            width: 70%;
        }
        .auto-style6 {
            width: 50%;
        }
         .auto-style7 {
             margin-left: 0%;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript">
        function isAlphaNumeric(keyCode)

    {

        return (((keyCode >= 48 && keyCode <= 57)&& isShift == false) ||                     

               (keyCode >= 65 && keyCode <= 90) || keyCode == 8 ||

            (keyCode >= 96 && keyCode <= 105) || keyCode == 32 )

    }               
    </script>

    <div>

        &nbsp;&nbsp;
        <asp:Button ID="BT_home" runat="server" Text="HOME" OnClick="BT_home_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_pc" runat="server" Text="PC" OnClick="BT_pc_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_plasyStation" runat="server" Text="PlayStation" OnClick="BT_plasyStation_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_xbox" runat="server" Text="XBOX" OnClick="BT_xbox_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:TextBox ID="TB_buscador" runat="server" MaxLength="20" onkeyup = "keyUP(event.keyCode)" 
            onkeydown = "return isAlphaNumeric(event.keyCode);" onpaste = "return false;"></asp:TextBox>
        <asp:RegularExpressionValidator ID="valitar_confirmapasss"
                            runat="server" 
                            ControlToValidate="TB_buscador" 
                            ErrorMessage="*" 
                            ForeColor="Red" 
                            ValidationExpression="^[A-Za-z0-9_-ñÑ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BT_buscar" runat="server" CssClass="btn btn-outline-info" OnClick="BT_Buscar_Click" Text="Buscar" />

    </div>

    <div>

        <table class="auto-style1">
            <tr>
                <td class="auto-style6">
                <asp:DataList ID="DL_noticias" runat="server" DataSourceID="ODS_noticia" OnItemDataBound="DL_noticias_RowDataBound"> 
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
                        <asp:Button ID="BT_verNoticias" runat="server" CssClass="btn btn-outline-danger" OnClick="BT_verNoticas_Click" Text="Ver mas" />
                    </td>
                </tr>
            </table>
            <br />
            <hr />
        </ItemTemplate>
    </asp:DataList>
                <asp:ObjectDataSource ID="ODS_noticia" runat="server" SelectMethod="obtenerPostNoticia" TypeName="Logica.L_Usercs"></asp:ObjectDataSource>
                </td>

                <td>
                <asp:Label ID="LB_resulbusq" runat="server"></asp:Label>
    <asp:DataList ID="DL_resultado" runat="server" CssClass="auto-style7"  OnItemDataBound="DL_resul_RowDataBound">
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
                        <asp:Label runat="server" Text="Etiquetas:"></asp:Label>
                        <asp:Label ID="LB_etiquetas" runat="server" Text='<%# Bind("etiqueta") %>'></asp:Label>
                        <br />
                    </td>
                    <td>
                        <asp:Button ID="BT_vermas" runat="server" Text="Ver mas" OnClick="BT_vermas_Click" CommandName="vermas" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-outline-danger" />
                    </td>
                </tr>
            </table>
            <br />
            <hr />
        </ItemTemplate>
    </asp:DataList>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:DataList ID="DL_post" runat="server" DataSourceID="ODS_treaListaData"  OnItemDataBound="DL_post_RowDataBound">
        <ItemTemplate>
            <br />
            <table class="auto-style1">
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
                        <asp:Label runat="server" Text="Etiquetas:"></asp:Label>
                        <asp:Label ID="LB_etiquetas" runat="server" Text='<%# Bind("etiqueta") %>'></asp:Label>
                        <br />
                    </td>
                    <td>
                        <asp:Button ID="BT_vermas" runat="server" Text="Ver mas" OnClick="BT_vermas_Click" CommandName="vermas" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-outline-danger" />
                    </td>
                </tr>
            </table>
            <br />
            <hr />
        </ItemTemplate>
    </asp:DataList>
    <asp:ObjectDataSource ID="ODS_treaListaData" runat="server" SelectMethod="obtenerPostandroid" TypeName="Logica.L_Usercs"></asp:ObjectDataSource>



                </td>

                <td>
                    &nbsp;</td>
            </tr>
        </table>

    </div>



</asp:Content>



