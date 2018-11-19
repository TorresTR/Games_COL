<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterUsuario.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="~/Controller/usuarios.aspx.cs" Inherits="View_usuarios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style4 {
            width: 70%;
        }
        .auto-style7 {
            margin-left: 0px;
        }
        .auto-style8 {
            width: 50%;
        }
        .auto-style9 {
            margin-right: 0px;
        }
        .auto-style10 {
            width: 79%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="fb-root"></div>
<script>(function(d, s, id) {
  var js, fjs = d.getElementsByTagName(s)[0];
  if (d.getElementById(id)) return;
  js = d.createElement(s); js.id = id;
  js.src = 'https://connect.facebook.net/es_LA/sdk.js#xfbml=1&version=v3.2&appId=184076195845739&autoLogAppEvents=1';
  fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>
    <div>

        &nbsp;&nbsp;
        <asp:Button ID="BT_pc" runat="server" Text="PC" OnClick="BT_pc_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_xbox" runat="server" Text="XBOX" OnClick="BT_xbox_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_ps" runat="server" Text="PlayStation" OnClick="BT_ps_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;
        <asp:Button ID="BT_android" runat="server" Text="Android" OnClick="BT_android_Click" CssClass="btn btn-secondary" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TB_buscador" runat="server" MaxLength="20"  onpaste = "return false;"></asp:TextBox>
        <cc1:filteredtextboxextender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars=" 'ñ" TargetControlID="TB_buscador" />
       
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BT_buscar" runat="server" CssClass="btn btn-outline-info" OnClick="BT_Buscar_Click" Text="Buscar" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
                        
    &nbsp;&nbsp;<asp:HyperLink ID="HL_noticias" runat="server">Noticias</asp:HyperLink>
                        
    &nbsp;</div>
    <table class="w-100">
        <tr>
            <td class="auto-style8">
                
                <asp:Panel ID="Panel1" runat="server">
                    <asp:DataList ID="DL_noticias" runat="server" DataSourceID="ODS_noticas" CssClass="auto-style9" Width="363px" OnItemDataBound="DL_noticias_RowDataBound" >
                        <ItemTemplate>
                            <br />
                            <table class="table-active">
                                <tr>
                                    <td class="auto-style10">
                                        <asp:Label ID="LB_titulo" runat="server" Text="Titulo"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="LB_muestraTitulo" runat="server" Text='<%# Bind("titulo") %>'></asp:Label>
                                        <br />
                                      
                                        <br />
                                        <asp:Label ID="LB_id" runat="server" visible="false" Text='<%# Bind("id_noticia") %>'></asp:Label>
                                        <br />
                                        <asp:Label ID="LB_etiqueta" runat="server" Text="Etiqueta:"></asp:Label>
                                        &nbsp;
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
                
    <asp:DataList ID="DL_resultado" runat="server" CssClass="auto-style7" OnItemDataBound="DL_resul_RowDataBound" >
        <ItemTemplate>
            <br />
            <table class="auto-style2">
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="LB_titulo" runat="server" Text="Titulo:"></asp:Label>
                        <asp:Label ID="LB_muestraTitulo" runat="server" Text='<%# Bind("titulo") %>'></asp:Label>
                        <br />
                        <asp:Label ID="LB_id" runat="server" Text='<%# Bind("id") %>' Visible="false" ></asp:Label>
                        <br />
                        <asp:Label ID="LB_autor" runat="server" Text="Autor:"></asp:Label>
                        <asp:Label ID="LB_muestraAutor" runat="server" Text='<%# Bind("autor") %>'></asp:Label>
                        <br />
                        <asp:Label ID="LB_etiqueta" runat="server" Text="Etiqueta:"></asp:Label>
                        <asp:Label ID="LB_etiquetaMuestra" runat="server" Text='<%# Bind("etiqueta") %>'></asp:Label>
                        <br />
                      
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="BT_vermas" runat="server" Text="Ver mas"  CommandName="vermas" CommandArgument='<%# Eval("id") %>' OnClick="BT_vermas_Click" CssClass="btn btn-outline-info"/>
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
            <td class="auto-style8">
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
                                        <asp:Label ID="LB_id" runat="server" Text='<%# Bind("id") %>' Visible="false" ></asp:Label>
                                        <br />
                                        <asp:Label ID="LB_autor" runat="server" Text="Autor:"></asp:Label>
                                        <asp:Label ID="LB_muestraAutor" runat="server" Text='<%# Bind("contenido") %>'></asp:Label>
                                        <br />
                                  
                                    </td>
                                    <td class="auto-style3">
                                        <asp:Button ID="BT_vermas" runat="server" Text="Ver mas"  CommandName="vermas" CommandArgument='<%# Eval("id") %>' OnClick="BT_vermas_Click" CssClass="btn btn-outline-info" style="height: 31px"/>
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
                <ajaxToolkit:CollapsiblePanelExtender ID="Panel2_CollapsiblePanelExtender" runat="server" BehaviorID="Panel2_CollapsiblePanelExtender" CollapseControlID="HL_post" Collapsed="True" CollapsedSize="30" ExpandControlID="HL_post" ExpandedSize="1000" TargetControlID="Panel2" />
    <asp:ObjectDataSource ID="ODS_datauser" runat="server" SelectMethod="obtenerPost" TypeName="Logica.L_persistencia"></asp:ObjectDataSource>
                <script src= "https://player.twitch.tv/js/embed/v1.js"></script>
<div id="SamplePlayerDivID"></div>
<script type="text/javascript">
  var options = {
    width: 854,
    height: 480,
    channel: "stodeh",
  };
  var player = new Twitch.Player("SamplePlayerDivID", options);
  player.setVolume(0.5);
</script>
                <br />
            </td>
            <td>
                &nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <iframe src="https://www.facebook.com/plugins/post.php?href=https%3A%2F%2Fwww.facebook.com%2Fpermalink.php%3Fstory_fbid%3D130196221197267%26id%3D130192821197607&width=500" width="500" height="163" style="border:none;overflow:hidden" scrolling="no" frameborder="0" allowTransparency="true" allow="encrypted-media"></iframe>
            </td>
        </tr>
    </table>
</asp:Content>

