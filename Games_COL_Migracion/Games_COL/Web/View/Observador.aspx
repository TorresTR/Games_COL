<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/Paguina_principal.master" AutoEventWireup="true" CodeFile="~/Controller/Observador.aspx.cs" Inherits="View_Observador" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style5 {
            width: 70%;
        }
        .auto-style6 {
            width: 50%;
        }
        .auto-style7 {
            border-radius: 0.3rem;
            text-align: left;
            margin-bottom: 2rem;
            background-color: #1c1e22;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="auto-style7">
        &nbsp;&nbsp;
        <asp:Button ID="BT_pc" runat="server" Text="PC" OnClick="BT_pc_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_xbox" runat="server" Text="XBOX" OnClick="BT_xbox_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_plasyStation" runat="server" Text="PlayStation" OnClick="BT_plasyStation_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_andrioid" runat="server" Text="ANDROID" OnClick="BT_andrioid_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TB_buscador" runat="server" MaxLength="20" 
             onpaste = "return false;"></asp:TextBox>
         <cc1:filteredtextboxextender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-`$'ñ" TargetControlID="TB_buscador" />
        <asp:RegularExpressionValidator ID="valitar_confirmapasss"
                            runat="server" 
                            ControlToValidate="TB_buscador" 
                            ErrorMessage="*" 
                            ForeColor="Red" 
                            ValidationExpression="^[A-Za-z0-9_-ñÑ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BT_Buscar" runat="server" CssClass="btn btn-outline-info" OnClick="BT_Buscar_Click" Text="Buscar"  />

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DDL_Idioma" runat="server" DataSourceID="ODS_cargaridioma" DataTextField="nombre" DataValueField="id"  OnSelectedIndexChanged="DDL_lenguaje_SelectedIndexChanged" AutoPostBack="true" ViewStateMode="Enabled" EnableViewState="true">
                        </asp:DropDownList>

            &nbsp;<asp:ObjectDataSource ID="ODS_cargaridioma" runat="server" SelectMethod="obtenerIdiomaActivo" TypeName="Logica.L_Usercs"></asp:ObjectDataSource>
                        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
                        
    &nbsp;&nbsp;
                                
    </div>
    <table class="w-100">
        <tr>
            <td class="auto-style6">
                <asp:Panel ID="Panel1" runat="server" BorderColor="White">
                    <asp:HyperLink ID="HL_noticias" runat="server">Noticias</asp:HyperLink>
                    <br />
                    <asp:DataList ID="DL_noticias" runat="server" DataSourceID="ODS_noticia" OnItemDataBound="DL_noticias_RowDataBound" >
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
                </asp:Panel>
                <ajaxToolkit:CollapsiblePanelExtender ID="Panel1_CollapsiblePanelExtender" runat="server" BehaviorID="Panel1_CollapsiblePanelExtender" CollapsedText="Noticias" TargetControlID="Panel1" TextLabelID="Noticias" Collapsed="True" CollapseControlID="HL_noticias" CollapsedSize="30" ExpandControlID="HL_noticias" ExpandedText="Ultima hora" SuppressPostBack="True" ExpandedSize="500" />
                <asp:ObjectDataSource ID="ODS_noticia" runat="server" SelectMethod="obtenerPostNoticia" TypeName="Logica.L_Usercs"></asp:ObjectDataSource>
        <asp:HyperLink ID="HL_post" runat="server">Post</asp:HyperLink>
                        
                <asp:Panel ID="Panel2" runat="server">
                    <br />
                    <asp:DataList ID="DL_post" runat="server" DataSourceID="ODS_dataobs" OnItemDataBound="DL_post_RowDataBound">
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
                                        <asp:Label runat="server" Text="Etiquetas:" ID="LB_Etiqueta0"></asp:Label>
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
                <ajaxToolkit:CollapsiblePanelExtender ID="Panel2_CollapsiblePanelExtender" runat="server" BehaviorID="Panel2_CollapsiblePanelExtender" CollapseControlID="HL_post" Collapsed="True" CollapsedSize="30" CollapsedText="Post" ExpandControlID="HL_post" ExpandedSize="500" ExpandedText="prueba" SuppressPostBack="True" TargetControlID="Panel2" TextLabelID="Post" />
                <br />
                </td>
       
            <td>
                <asp:Label ID="LB_resulbusq" runat="server"></asp:Label>
    <asp:DataList ID="DL_resultado" runat="server" OnItemDataBound="DL_resul_RowDataBound">
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
                        <asp:Label runat="server" Text="Etiquetas:"   ID="LB_Etiqueta"></asp:Label>
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
                <asp:ObjectDataSource ID="ODS_dataobs" runat="server" SelectMethod="obtenerPostObservador" TypeName="Logica.L_Usercs"></asp:ObjectDataSource>
            </td>
            <td>
                    &nbsp;</td>
        </tr>
    </table>
</asp:Content>

