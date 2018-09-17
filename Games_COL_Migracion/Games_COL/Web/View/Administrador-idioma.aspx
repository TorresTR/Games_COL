<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Administrador-idioma.aspx.cs" Inherits="View_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 50%;
        }
        .auto-style3 {
            text-align: center;
            width: 50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="text-center">
            <asp:Label ID="LB_titulo" runat="server" Text="ADMINISTRADOR DE IDIOMA"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:DropDownList ID="DDL_Idioma" runat="server" DataSourceID="ODS_cargaridioma" DataTextField="nombre" DataValueField="id"  AutoPostBack="true" ViewStateMode="Enabled" EnableViewState="true" OnSelectedIndexChanged="DDL_lenguaje_SelectedIndexChanged">
                        </asp:DropDownList>

            <asp:ObjectDataSource ID="ODS_cargaridioma" runat="server" SelectMethod="obtenerIdioma" TypeName="Logica.L_Usercs"></asp:ObjectDataSource>
                        
            <asp:DropDownList ID="DDL_forms" runat="server" DataSourceID="ODS_forms" DataTextField="nombre" DataValueField="id" AutoPostBack="true" ViewStateMode="Enabled" EnableViewState="true" OnSelectedIndexChanged="DDL_lenguaje_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ODS_forms" runat="server" SelectMethod="formularios" TypeName="Datos.D_User"></asp:ObjectDataSource>
                        
        </td>
        <td class="text-center">&nbsp;<asp:Label ID="LB_titElimina" runat="server" ForeColor="Red" Text="Eliminar Idioma"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DDL_IdiomaEl" runat="server" DataSourceID="ODS_cargaridioma" DataTextField="nombre" DataValueField="id"  AutoPostBack="True" ViewStateMode="Enabled" OnSelectedIndexChanged="DDL_lenguaje_SelectedIndexChanged">
                        </asp:DropDownList>

            &nbsp;&nbsp;
            <asp:Button ID="BT_eliminar" runat="server" OnClick="BT_eliminar_Click" Text="Eliminar" />
            <br />
            <br />
            <asp:TextBox ID="TB_cont" runat="server" Visible="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="BT_guardar" runat="server" OnClick="BT_guardar_Click" Text="Guardar" Visible="False" />
&nbsp;<br />
            <asp:Label ID="LB_id" runat="server" Visible="False"></asp:Label>
        </td>
        <td class="text-center">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="text-center" colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:GridView ID="GV_controles" runat="server" PageIndex="1" PageSize="1" OnPageIndexChanging="changePage" AutoGenerateColumns="False" DataKeyNames="id,contenido">
                <Columns>
                    <asp:TemplateField HeaderText="formulario">
                        <ItemTemplate>
                            <asp:Label ID="LB_formulario" runat="server" Text='<%# Bind("formulario") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="control">
                        <ItemTemplate>
                            <asp:Label ID="LB_control" runat="server" Text='<%# Bind("control") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="contenido">
                        <ItemTemplate>
                            <asp:Label ID="LB_contenido" runat="server" Text='<%# Bind("contenido") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="id_formulario">
                        <ItemTemplate>
                            <asp:Label ID="LB_idForm" runat="server" Text='<%# Bind("id_form") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="idioma">
                        <ItemTemplate>
                            <asp:Label ID="LB_idioma" runat="server" Text='<%# Bind("idioma") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="id">
                        <ItemTemplate>
                            <asp:Label ID="LB_id" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <asp:Button ID="BT_editar" runat="server" OnClick="BT_editar_Click" Text="Editar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings NextPageText="1" />
            </asp:GridView>
            </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>

