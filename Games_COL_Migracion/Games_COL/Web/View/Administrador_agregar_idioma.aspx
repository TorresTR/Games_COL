<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Administrador_agregar_idioma.aspx.cs" Inherits="View_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="LB_idiomaA" runat="server" Text="Idioma"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="LB_terminacion" runat="server" Text="Terminacion"></asp:Label>
                <br />
                <asp:TextBox ID="TB_idioma" runat="server"></asp:TextBox>
&nbsp;
                <asp:TextBox ID="TB_terminacion" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                <asp:Button ID="BT_agregar" runat="server" OnClick="BT_agregar_Click" Text="Agregar" CssClass="btn btn-outline-success" />
            </td>
            <td>
                 <script type="text/javascript">
        function isAlphaNumeric(keyCode)

    {

        return (((keyCode >= 48 && keyCode <= 57)&& isShift == false) ||                     

               (keyCode >= 65 && keyCode <= 90) || keyCode == 8 ||

            (keyCode >= 96 && keyCode <= 105) || keyCode == 32 )

    }               
    </script>
                        
            <asp:DropDownList ID="DDL_forms" runat="server" DataSourceID="ODS_forms" DataTextField="nombre" DataValueField="id" AutoPostBack="true" ViewStateMode="Enabled" EnableViewState="true" OnSelectedIndexChanged="DDL_traduir_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ODS_forms" runat="server" SelectMethod="formularios" TypeName="Datos.D_User"></asp:ObjectDataSource>
                         
                <br />
                <asp:Label ID="LB_cont" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Underline="True" ForeColor="White"></asp:Label>
&nbsp;<asp:TextBox ID="TB_contenido" runat="server" onkeyup = "keyUP(event.keyCode)"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RFV_nombre" runat="server" ControlToValidate="TB_contenido" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
&nbsp;
                <asp:Button ID="BT_traduccion" runat="server" Text="Aceptar" CssClass="btn btn-outline-success" OnClick="BT_traduccion_Click" />
&nbsp;<asp:Label ID="LB_idform" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            <asp:GridView ID="GV_agregar" runat="server" AutoGenerateColumns="False" DataKeyNames="id,contenido" PageIndex="1" PageSize="1"  OnRowDataBound="GV_Idioma_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="formulario">
                                <ItemTemplate>
                                    <asp:Label ID="LB_formulario" runat="server" Text='<%# Bind("formulario") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="control">
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
                                <ItemTemplate>
                                    <asp:Label ID="LB_idForm" runat="server" Text='<%# Bind("id_form") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="idioma">
                                <ItemTemplate>
                                    <asp:Label ID="LB_idioma" runat="server" Text='<%# Bind("idioma") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="id">
                                <ItemTemplate>
                                    <asp:Label ID="LB_id0" runat="server" Text='<%# Bind("id") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Editar">
                                <HeaderTemplate>
                                    <asp:Label ID="LB_titTrad" runat="server"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Button ID="BT_traducir" runat="server"  Text="Traducir" OnClick="BT_traducir_Click" CssClass="btn btn-outline-success" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings NextPageText="1" />
                    </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

