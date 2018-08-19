<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterAdministrador.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="~/Controller/Administrador_miPost.aspx.cs" Inherits="View_Administrador_miPost" %>

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
                
                    <ContentTemplate>
                        <asp:GridView ID="GV_miPost" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:Button ID="BT_editar" runat="server" OnClick="BT_editar_Click" Text="Editar" CssClass="btn btn-outline-info" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>
                                        <br />
                                        <asp:Label ID="LB_id" runat="server" Text='<%# Eval("id") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Eliminar">
                                    <ItemTemplate>
                                        <asp:Button ID="BT_eliminar" runat="server" Text="Eliminar" CssClass="btn btn-outline-info" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClick="BT_eliminar_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Titulo">
                                    <ItemTemplate>
                                        <asp:Label ID="LB_titulo" runat="server" Text='<%# Bind("titulo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Etiqueta">
                                    <ItemTemplate>
                                        <asp:Label ID="LB_etiqueta" runat="server" Text='<%# Bind("etiqueta") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-left" colspan="2">
                
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
                    <asp:Button ID="BT_volver" runat="server" CssClass="btn btn-outline-danger" OnClick="BT_volver_Click" Text="Volver" />
                
            </td>
        </tr>
    </table>
</asp:Content>
