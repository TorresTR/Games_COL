<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="~/Controller/verCompletoUserregistrado.aspx.cs" Inherits="View_verCompletoUserregistrado" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Styles/Estilos.css" rel="stylesheet" type="text/css" />&nbsp;<style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            width: 1170px;
        }
        .auto-style4 {
               width: 50%;
                                                                                     text-align: center;
                                                                                 }
                                                                                 .auto-style5 {
                                                                                     text-align: center;
                                                                                     height: 91px;
                                                                                 }
    </style></head><body><form id="form1" runat="server">

       
        <div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>


            <tr class="jumbotron">
                
                <td class="auto-style3">
                    <h2>&nbsp;<asp:Label ID="LB_titAutor" runat="server" Text="Autor:"></asp:Label>
                    </h2>
                    <h3 class="display-3">
                    <asp:Label ID="LB_autor" runat="server"></asp:Label>
                        </h3>

                </td>

                <td class="jumbotron">
                    &nbsp;</td>
            </tr>
            <tr>
                
                <td class="auto-style3">
                    <h2>
                        <asp:Label ID="LB_titCont" runat="server" Text="Contenido:"></asp:Label>
                    </h2>
                    <h4>
                    <asp:Label ID="LB_muestraPag" runat="server"></asp:Label>
                    </h4>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                
                <td class="text-center">
                            <asp:Label ID="LB_puntos" runat="server" Text="Puntos:"></asp:Label>
                            <br />
                            
                            <asp:Label ID="LB_motrarPuntos" runat="server"></asp:Label>
                            </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <br />
                    <asp:Button ID="Bt_uno" runat="server" Height="20px" OnClick="Bt_uno_Click" Text="1" Width="20px" />
                    <asp:Button ID="BT_dos" runat="server" Height="20px" OnClick="BT_dos_Click" Text="2" Width="20px" />
                    <asp:Button ID="BT_tres" runat="server" Height="20px" OnClick="BT_tres_Click" Text="3" Width="20px" />
                    <asp:Button ID="BT_cuatro" runat="server" Height="20px" OnClick="BT_cuatro_Click" Text="4" Width="20px" />
                    <asp:Button ID="BT_cinco" runat="server" Height="20px" OnClick="BT_cinco_Click" Text="5" Width="20px" />
                            <asp:Label ID="LB_prueba" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Bt_uno" EventName="Click" />
                            
                        </Triggers>
                    </asp:UpdatePanel>
                    <h4>

                            
                    </h4>
                    <h5>
                    
                    </h5>
                </td>
            </tr>
            <tr>



               <td class="auto-style2" colspan="2">
                    <asp:Label ID="LB_mensaje" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2">
                    <asp:Label ID="LB_comentar" runat="server" Text="Comentar:"></asp:Label>
                    <asp:TextBox ID="TB_comentarios" runat="server" Height="79px" TextMode="MultiLine" Width="224px" MaxLength="50" ValidationGroup="1"
                       onpaste = "return false;"></asp:TextBox>
                    <cc1:filteredtextboxextender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars="_-`$'ñ" TargetControlID="TB_comentarios" />
                     <asp:RequiredFieldValidator ID="RFV_comentar" runat="server" ControlToValidate="TB_comentarios" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="REV_max" runat="server"
                    ControlToValidate="TB_comentarios" 
                    ErrorMessage="*" 
                    ForeColor="Red" ValidationExpression="^[\s\S]{0,50}$" ValidationGroup="1"></asp:RegularExpressionValidator>
                     <asp:RegularExpressionValidator ID="validator_comentario" runat="server" ControlToValidate="TB_comentarios"
                         ErrorMessage="*" ForeColor="Red" ValidationExpression="^[A-Za-z0-9 ñÑ]*$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Button ID="BT_comentar" runat="server" OnClick="BT_comentar_Click" Text="Comentar" CssClass="btn btn-outline-danger" ValidationGroup="1" />
                &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="B_volver" runat="server" CssClass="btn btn-outline-info" OnClick="B_volver_Click" Text="Volver" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="BT_reporte" runat="server"   CssClass="btn btn-outline-danger" Text="Reportar" OnClick="BT_reporte_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2" class="text-center">
                    <table class="w-100">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="auto-style4">
                                <asp:GridView ID="GV_comentariosuser" runat="server" DataKeyNames="id" AutoGenerateColumns="False" OnRowDataBound="GV_Idioma_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Reportar">
                                            <HeaderTemplate>
                                                <asp:Label ID="LB_reportar" runat="server"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Button ID="BT_reportar" runat="server" Text="Reportar" CommandName="reportar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClick="BT_reportar_Click" CssClass="btn btn-outline-success"/>
                                                <br />
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Comentarios">
                                            <HeaderTemplate>
                                                <asp:Label ID="LB_coment" runat="server"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LB_comentario" runat="server" Text='<%# Bind("comentarios") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    
                                </asp:GridView>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        
        </div>
    </form>
</body>
</html>
