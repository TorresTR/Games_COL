<%@ Page Title="" Language="C#" MasterPageFile="~/View/Paguina_principal.master" AutoEventWireup="true" CodeFile="~/Controller/Observar_playstation.aspx.cs" Inherits="View_Observar_playstation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">
        .auto-style5 {
            width: 70%;
        }
        .auto-style6 {
            width: 50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div>

        &nbsp;&nbsp;
        <asp:Button ID="BT_home" runat="server" Text="HOME" OnClick="BT_home_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_pc" runat="server" Text="PC" OnClick="BT_pc_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_xbox" runat="server" Text="XBOX" OnClick="BT_xbox_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_andrioid" runat="server" Text="ANDROID" OnClick="BT_andrioid_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
       <asp:TextBox ID="TB_buscador" runat="server" MaxLength="20"></asp:TextBox>
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
                <asp:DataList ID="DataList2" runat="server" DataSourceID="ODS_noticia" >
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
                        <asp:Button ID="BT_verNoticas" runat="server" CssClass="btn btn-outline-danger" OnClick="BT_verNoticas_Click" Text="Ver mas" />
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
    <asp:DataList ID="DL_resultado" runat="server">
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
                    <asp:DataList ID="DataList1" runat="server" DataSourceID="ODS_treaListaData">
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
    <asp:ObjectDataSource ID="ODS_treaListaData" runat="server" SelectMethod="obtenerPostps" TypeName="Logica.L_Usercs"></asp:ObjectDataSource>



                </td>

                <td>&nbsp;</td>
            </tr>
        </table>

    </div>



</asp:Content>



