<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterModerador.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="~/Controller/Moderador_miNoticia.aspx.cs" Inherits="View_Moderador_miNoticia" %>

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
                        <asp:GridView ID="GV_miPost" runat="server" AutoGenerateColumns="False" OnRowDataBound="GV_Idioma_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Editar">
                                    <HeaderTemplate>
                                        <asp:Label ID="LB_editar" runat="server"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Button ID="BT_editar" runat="server" OnClick="BT_editar_Click" Text="Editar" CssClass="btn btn-outline-info" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>
                                        <br />
                                        <asp:Label ID="LB_id" runat="server" Text='<%# Eval("id") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Eliminar">
                                    <HeaderTemplate>
                                        <asp:Label ID="LB_eliminar" runat="server"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Button ID="BT_eliminar" runat="server" Text="Eliminar" CssClass="btn btn-outline-info" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClick="BT_eliminar_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Titulo">
                                    <HeaderTemplate>
                                        <asp:Label ID="LB_tit" runat="server"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LB_titulo" runat="server" Text='<%# Bind("titulo") %>'></asp:Label>
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
                
                    <asp:Button ID="BT_volver" runat="server" CssClass="btn btn-outline-danger" OnClick="BT_volver_Click" Text="Volver" />
                
            </td>
        </tr>
    </table>
</asp:Content>




