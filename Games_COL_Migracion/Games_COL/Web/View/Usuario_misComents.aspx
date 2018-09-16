<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/MasterUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/Usuario_misComents.aspx.cs" Inherits="View_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LB_titAutor" runat="server" Text="Autor:"></asp:Label>
&nbsp;<asp:Label ID="LB_autor" runat="server"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LB_titContenido" runat="server" Text="Contenido:"></asp:Label>
&nbsp;<asp:Label ID="LB_muestraPag" runat="server"></asp:Label>
                    </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                                <asp:GridView ID="GV_comentariosuser" runat="server" DataKeyNames="id" AutoGenerateColumns="False" OnRowDataBound="GV_Idioma_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Eliminar">
                                            <HeaderTemplate>
                                                <asp:Label ID="LB_eliminar" runat="server"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                &nbsp;<asp:Button ID="BT_eliminar" runat="server" CssClass="btn btn-outline-danger" OnClick="BT_eliminar_Click" Text="Eliminar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="LABEL" InsertVisible="False" ShowHeader="False" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
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
        </tr>
        <tr>
            <td>
                                &nbsp;</td>
        </tr>
        <tr>
            <td>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="BT_volver" runat="server" CssClass="btn btn-outline-danger" OnClick="BT_volver_Click" Text="Volver" />
                            </td>
        </tr>
    </table>
</asp:Content>

