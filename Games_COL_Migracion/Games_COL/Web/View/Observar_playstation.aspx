<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/Paguina_principal.master" AutoEventWireup="true" CodeFile="~/Controller/Observar_playstation.aspx.cs" Inherits="View_Observar_playstation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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

    
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

    <div>

        &nbsp;&nbsp;
        <asp:Button ID="BT_home" runat="server" Text="HOME" OnClick="BT_home_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_pc" runat="server" Text="PC" OnClick="BT_pc_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_xbox" runat="server" Text="XBOX" OnClick="BT_xbox_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_andrioid" runat="server" Text="ANDROID" OnClick="BT_andrioid_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
       <asp:TextBox ID="TB_buscador" runat="server" MaxLength="20" onpaste = "return false;"></asp:TextBox>
        <cc1:filteredtextboxextender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars=" 'ñ" TargetControlID="TB_buscador" />
     
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BT_buscar" runat="server" CssClass="btn btn-outline-info" OnClick="BT_Buscar_Click" Text="Buscar" />

    </div>

    <div>

        <table class="auto-style1">
            <tr>
                <td class="auto-style6">
                    <br />
                        
        <asp:HyperLink ID="HL_noticias" runat="server">Noticias</asp:HyperLink>
                        
                    <asp:Panel ID="Panel1" runat="server">
                        <asp:DataList ID="DL_niticias" runat="server" DataSourceID="ODS_noticia" OnItemDataBound="DL_noticias_RowDataBound">
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
                                            <asp:Label ID="LB_id" runat="server" visible="False" Text='<%# Bind("id_noticia") %>'></asp:Label>
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
                    </asp:Panel>
                    <cc1:CollapsiblePanelExtender ID="Panel1_CollapsiblePanelExtender" runat="server" BehaviorID="Panel1_CollapsiblePanelExtender" CollapseControlID="HL_noticias" ExpandControlID="HL_noticias" TargetControlID="Panel1" />
                <asp:ObjectDataSource ID="ODS_noticia" runat="server" SelectMethod="obtenerNoticia" TypeName="Logica.L_persistencia"></asp:ObjectDataSource>



        <asp:HyperLink ID="HL_post" runat="server">Post</asp:HyperLink>



                    <asp:Panel ID="Panel2" runat="server">
                        <asp:DataList ID="DL_post" runat="server" DataSourceID="ODS_treaListaData" OnItemDataBound="DL_post_RowDataBound">
                            <ItemTemplate>
                                <br />
                                <table class="auto-style1">
                                    <tr>
                                        <td class="auto-style5">
                                            <asp:Label ID="LB_titulo0" runat="server" Text="Titulo"></asp:Label>
                                            <asp:Label ID="LB_muestraTitulo0" runat="server" Text='<%# Bind("titulo") %>'></asp:Label>
                                            <br />
                                            <asp:Label ID="LB_autor0" runat="server" Text="autor"></asp:Label>
                                            <asp:Label ID="LB_muestraAutor0" runat="server" Text='<%# Bind("autor") %>'></asp:Label>
                                            <br />
                                            <asp:Label ID="LB_id0" runat="server" visible="False" Text='<%# Bind("id") %>'></asp:Label>
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
                    </asp:Panel>
                    <cc1:CollapsiblePanelExtender ID="Panel2_CollapsiblePanelExtender" runat="server" BehaviorID="Panel2_CollapsiblePanelExtender" CollapseControlID="HL_post" ExpandControlID="HL_post" ExpandedSize="500" TargetControlID="Panel2" />



                </td>

                <td>
                <asp:Label ID="LB_resulbusq" runat="server"></asp:Label>
    <asp:DataList ID="DL_resultado" runat="server"  OnItemDataBound="DL_resul_RowDataBound">
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
                    <br />
    <asp:ObjectDataSource ID="ODS_treaListaData" runat="server" SelectMethod="obtenerPostpS" TypeName="Logica.L_persistencia"></asp:ObjectDataSource>



                </td>

                <td>&nbsp;</td>
            </tr>
        </table>

    </div>



</asp:Content>



