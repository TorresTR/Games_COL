<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/MasterAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Administrador-idioma.aspx.cs" Inherits="View_Default" %>

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
        <td class="auto-style2">
&nbsp;&nbsp;
            &nbsp;&nbsp;
            <asp:Button ID="BT_agregar" runat="server" CssClass="btn btn-outline-success" OnClick="BT_agregar_Click" Text="Agregar idioma" />
        </td>
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
            <asp:DropDownList ID="DDL_IdiomaEl" runat="server" DataSourceID="ODS_cargaridioma" DataTextField="nombre" DataValueField="id"  AutoPostBack="True" ViewStateMode="Enabled" OnSelectedIndexChanged="DDL_elimina_SelectedIndexChanged">
                        </asp:DropDownList>

            &nbsp;&nbsp;
            <asp:Label ID="LB_idiomaEli" runat="server" Visible="False"></asp:Label>
            &nbsp;
            <asp:Button ID="BT_eliminar" runat="server" OnClick="BT_eliminar_Click" Text="Eliminar" CssClass="btn btn-outline-success" />
            &nbsp;
            <br />
            <asp:Label ID="LB_idEli" runat="server" Visible="False"></asp:Label>
            <br />
            <asp:TextBox ID="TB_cont" runat="server" Visible="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="BT_guardar" runat="server" OnClick="BT_guardar_Click" Text="Guardar" Visible="False" CssClass="btn btn-outline-success" />
&nbsp;&nbsp;
            <br />
            <asp:Label ID="LB_id" runat="server" Visible="False"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        <td class="text-center">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="text-center" colspan="3">
            <asp:GridView ID="GV_controles" runat="server" AutoGenerateColumns="False" DataKeyNames="id,contenido" OnPageIndexChanging="changePage" PageIndex="1" PageSize="1" OnRowDataBound="GV_Idioma_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="formulario">
                                <HeaderTemplate>
                                    <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LB_formulario" runat="server" Text='<%# Bind("formulario") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="control">
                                <HeaderTemplate>
                                    <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LB_control" runat="server" Text='<%# Bind("control") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="contenido">
                                <HeaderTemplate>
                                    <asp:Label ID="LB_titCont" runat="server"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LB_contenido" runat="server" Text='<%# Bind("contenido") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="id_formulario">
                                <HeaderTemplate>
                                    <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LB_idForm" runat="server" Text='<%# Bind("id_form") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="idioma">
                                <HeaderTemplate>
                                    <asp:Label ID="Label4" runat="server" Visible="False"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LB_idioma" runat="server" Text='<%# Bind("idioma") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="id">
                                <HeaderTemplate>
                                    <asp:Label ID="Label5" runat="server" Visible="False"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LB_id0" runat="server" Text='<%# Bind("id") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Editar">
                                <HeaderTemplate>
                                    <asp:Label ID="LB_titEdit" runat="server"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Button ID="BT_editar" runat="server" OnClick="BT_editar_Click" Text="Editar" CssClass="btn btn-outline-success" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings NextPageText="1" />
                    </asp:GridView>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="2" class="text-center">
            <asp:Button ID="BT_volver" runat="server" CssClass="btn btn-outline-success" OnClick="BT_volver_Click" Text="Volver" />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>

