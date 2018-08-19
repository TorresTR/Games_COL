<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterUsuario.master" EnableEventValidation="false"  AutoEventWireup="true" CodeFile="~/Controller/usuarios_Respuestas.aspx.cs" Inherits="View_usuarios_Respuestas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 50%;
        }
        .auto-style3 {
            width: 50%;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
        <tr>
            <td class="auto-style2">
                
                                <asp:GridView ID="GV_comentariosuser" runat="server" DataKeyNames="id" AutoGenerateColumns="False"  >
                                    <Columns>
                                        <asp:TemplateField HeaderText="Reportar">
                                            <ItemTemplate>
                                                <asp:Button ID="BT_reportar" runat="server" Text="Ver Mas" CommandName="reportar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClick="BT_reportar_Click" CssClass="btn btn-outline-success"/>
                                                <br />
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>' Visible="False"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Autor">
                                            <ItemTemplate>
                                                <asp:Label ID="LB_autor" runat="server" Text='<%# Bind("autor") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Solicitud">
                                            <ItemTemplate>
                                                <asp:Label ID="LB_solicutud" runat="server" Text='<%# Bind("solicitud") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    
                                </asp:GridView>
                </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                
                                <asp:Button ID="BT_volver" runat="server" Text="Volver" CssClass="btn btn-outline-success" OnClick="BT_volver_Click"/>
                </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

