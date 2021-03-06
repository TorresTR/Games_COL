﻿<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/Paguina_principal.master" AutoEventWireup="true" CodeFile="~/Controller/Observador.aspx.cs" Inherits="View_Observador" %>
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
<!-- Código de instalación Cliengo para gamescol.ddns.net/View/Observador.aspx --> 
    <script type="text/javascript">(function ()
{
    var ldk = document.createElement('script'); ldk.type = 'text/javascript'; ldk.async = true;
    ldk.src = 'https://s.cliengo.com/weboptimizer/5bf0bc96e4b040fccb7b7fec/5bf0c2b0e4b07dc90b161e01.js'; 
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ldk, s);
})();</script>
    <script src="https://embed.twitch.tv/embed/v1.js"></script>

   <script type="text/javascript">
      var embed = new Twitch.Embed("twitch-embed", {
        width: 854,
        height: 480,
        channel: "monstercat",
        layout: "video",
        autoplay: false
      });

      embed.addEventListener(Twitch.Embed.VIDEO_READY, () => {
        var player = embed.getPlayer();
        player.play();
      });
    </script>
    <div class="auto-style7">
        &nbsp;&nbsp;
        <asp:Button ID="BT_pc" runat="server" Text="PC" OnClick="BT_pc_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_xbox" runat="server" Text="XBOX" OnClick="BT_xbox_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_plasyStation" runat="server" Text="PlayStation" OnClick="BT_plasyStation_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_andrioid" runat="server" Text="ANDROID" OnClick="BT_andrioid_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TB_buscador" runat="server" MaxLength="20" 
             onpaste = "return false;"></asp:TextBox>
         <cc1:filteredtextboxextender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars=" 'ñ" TargetControlID="TB_buscador" />
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
 
</asp:Panel>
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
                <ajaxToolkit:CollapsiblePanelExtender ID="Panel1_CollapsiblePanelExtender" runat="server" BehaviorID="Panel1_CollapsiblePanelExtender" CollapsedText="Noticias" TargetControlID="Panel1" TextLabelID="Noticias" Collapsed="True" CollapseControlID="HL_noticias" CollapsedSize="30" ExpandControlID="HL_noticias" ExpandedText="Ultima hora" SuppressPostBack="True" ExpandedSize="1000" />
                <asp:ObjectDataSource ID="ODS_noticia" runat="server" SelectMethod="obtenerNoticia" TypeName="Logica.L_persistencia"></asp:ObjectDataSource>
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
                                        <asp:Label ID="LB_muestraAutor" runat="server" Text='<%# Bind("contenido") %>'></asp:Label>
                                        <br />
                                        <asp:Label ID="LB_id" runat="server" visible="False" Text='<%# Bind("id") %>'></asp:Label>
                                        <br />
                                        
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
                <ajaxToolkit:CollapsiblePanelExtender ID="Panel2_CollapsiblePanelExtender" runat="server" BehaviorID="Panel2_CollapsiblePanelExtender" CollapseControlID="HL_post" Collapsed="True" CollapsedSize="30" CollapsedText="Post" ExpandControlID="HL_post" ExpandedSize="1000" ExpandedText="prueba" SuppressPostBack="True" TargetControlID="Panel2" TextLabelID="Post" />
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
                         <asp:Label ID="LB_autor" runat="server" Text="Autor:"></asp:Label>
                        <asp:Label ID="LB_muestraAutor" runat="server" Text='<%# Bind("autor") %>'></asp:Label>
                        <br />
                        <asp:Label ID="LB_etiqueta" runat="server" Text="Etiqueta:"></asp:Label>
                        <asp:Label ID="LB_etiquetaMuestra" runat="server" Text='<%# Bind("etiqueta") %>'></asp:Label>
                        <br />
                        <asp:Label ID="LB_id" runat="server" visible="False" Text='<%# Bind("id") %>'></asp:Label>
                        <br />
                      
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
                <asp:ObjectDataSource ID="ODS_dataobs" runat="server" SelectMethod="obtenerPost" TypeName="Logica.L_persistencia"></asp:ObjectDataSource>
                <br />

<script src= "https://player.twitch.tv/js/embed/v1.js"></script>
<div id="SamplePlayerDivID"></div>
<script type="text/javascript">
  var options = {
    width: 854,
    height: 480,
    channel: "monstercat",
  };
  var player = new Twitch.Player("SamplePlayerDivID", options);
  player.setVolume(0.5);
</script>

            </td>
            <td>
               
                    <iframe id="ytplayer" type="text/html" width="720" height="405"
                    src="https://www.youtube.com/embed/UpqKLF4mnb0?cc_load_policy=1&disablekb=1&enablejsapi=1"
                    frameborder="0" allowfullscreen></iframe>
             
        </tr>
       
    </table>
</asp:Content>

