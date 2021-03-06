﻿<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/MasterAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Administrador.aspx.cs" Inherits="View_Administrador" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style4 {
            width: 329px;
        }
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
        <asp:Button ID="BT_pc" runat="server" Text="PC" OnClick="BT_pc_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_xbox" runat="server" Text="XBOX" OnClick="BT_xbox_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_ps" runat="server" Text="PlayStation" OnClick="BT_ps_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_android" runat="server" Text="Android" OnClick="BT_android_Click" CssClass="btn btn-secondary" />
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TB_buscador" runat="server" onpaste = "return false;"></asp:TextBox>
         <cc1:filteredtextboxextender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars=" 'ñ" TargetControlID="TB_buscador" />
        <asp:RegularExpressionValidator ID="validatorBusq" runat="server"
                    ControlToValidate="TB_buscador" 
                    ErrorMessage="*" 
                    ForeColor="Red" ValidationExpression="^[A-Za-z0-9 ñÑ']*$"></asp:RegularExpressionValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BT_buscar" runat="server" CssClass="btn btn-outline-info" OnClick="Button3_Click" Text="Buscar" />
&nbsp;</div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
                        
        <asp:HyperLink ID="HL_noticias" runat="server">Noticias</asp:HyperLink>
                        
    &nbsp;&nbsp;
        <table class="w-100">
        <tr>
            <td class="auto-style6">
                
                <asp:Panel ID="Panel1" runat="server">
                    <asp:DataList ID="DL_noticias" runat="server" DataSourceID="ODS_noticas" OnItemDataBound="DL_noticias_RowDataBound" >
                        <ItemTemplate>
                            <br />
                            <table class="table-active">
                                <tr>
                                    <td class="auto-style5">
                                        <asp:Label ID="LB_titulo" runat="server" Text="Titulo"></asp:Label>
                                        <asp:Label ID="LB_muestraTitulo" runat="server" Text='<%# Bind("titulo") %>'></asp:Label>
                                        <br />
                                        
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
                <ajaxToolkit:CollapsiblePanelExtender ID="Panel1_CollapsiblePanelExtender" runat="server" BehaviorID="Panel1_CollapsiblePanelExtender" CollapseControlID="HL_noticias" Collapsed="True" CollapsedSize="30" ExpandControlID="HL_noticias" ExpandedSize="1000" SuppressPostBack="True" TargetControlID="Panel1" />
                <br />
                <asp:ObjectDataSource ID="ODS_noticas" runat="server" SelectMethod="obtenerNoticia" TypeName="Logica.L_persistencia"></asp:ObjectDataSource>
        <asp:HyperLink ID="HL_post" runat="server">Post</asp:HyperLink>
            </td>
            <td>
                
                <asp:Label ID="LB_busq" runat="server"></asp:Label>
                
                <br />
    <asp:DataList ID="DL_resultado" runat="server" OnItemDataBound="DL_resul_RowDataBound">
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
                        <br />
                       
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
            <td class="auto-style6">
                <asp:Panel ID="Panel2" runat="server">
                    <asp:DataList ID="DL_post" runat="server" DataSourceID="ODS_datauser" OnItemDataBound="DL_post_RowDataBound">
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
                                        <asp:Label ID="LB_muestraAutor" runat="server" Text='<%# Bind("contenido") %>'></asp:Label>
                                        <br />
                                     
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
                </asp:Panel>
                <ajaxToolkit:CollapsiblePanelExtender ID="Panel2_CollapsiblePanelExtender" runat="server" BehaviorID="Panel2_CollapsiblePanelExtender" CollapseControlID="HL_post" Collapsed="True" CollapsedSize="30" CollapsedText="HL_post" ExpandedSize="1000" SuppressPostBack="True" TargetControlID="Panel2" ExpandControlID="HL_post" />
    <asp:ObjectDataSource ID="ODS_datauser" runat="server" SelectMethod="obtenerPost" TypeName="Logica.L_persistencia"></asp:ObjectDataSource>
            </td>
            <td>
                                                <script src= "https://player.twitch.tv/js/embed/v1.js"></script>
<div id="SamplePlayerDivID"></div>
<script type="text/javascript">
  var options = {
    width: 854,
    height: 480,
    channel: "ninja",
  };
  var player = new Twitch.Player("SamplePlayerDivID", options);
  player.setVolume(0.5);
</script>&nbsp;</td>
        </tr>
</table>
</asp:Content>




