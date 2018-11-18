<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/MasterAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Admin_contacto.aspx.cs" Inherits="View_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
        <tr>
            <td class="auto-style2">
                <asp:GridView ID="GV_contactenos" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="LB_correo" runat="server" Text="<%# Bind('correo') %>"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="LB_sugerencia" runat="server" Text="<%# Bind('sugerencia') %>"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="BT_responder" runat="server" Text="Responder" CssClass="btn btn-outline-danger" OnClick="BT_responder_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
            <td>
                <asp:Label ID="LB_cargaSugere" runat="server"></asp:Label>
                <br />
                <asp:Label ID="LB_corr" runat="server" Visible="False"></asp:Label>
                <br />
                <asp:TextBox ID="TB_respuesta" runat="server" Height="59px" Width="392px"></asp:TextBox>
                <cc1:filteredtextboxextender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars=" '_ñ" TargetControlID="TB_respuesta" />
                <asp:RequiredFieldValidator ID="RFV_titulo" runat="server" ControlToValidate="TB_respuesta" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                <br />
                <asp:Button ID="BT_respuestaContacto" runat="server" Text="Enviar Respuesta"  CssClass="btn btn-outline-danger" OnClick="BT_respuestaContacto_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

