<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Administrador_editar_noticia.aspx.cs" Inherits="View_Administrador_editar_noticia" %>

<%@ Register Assembly="CKEditor.NET"  Namespace="CKEditor.NET" TagPrefix="CKEditor"%>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Styles/Estilos.css" rel="stylesheet" type="text/css" />
    <script src="../Contenido/CKEditor/ckeditor.js"></script>
    <script src="../Contenido/ckfinder/ckfinder.js"></script>
    <style type="text/css">
        .auto-style2 {
            width: 50%;
            text-align: right;
        }
        .auto-style3 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
        <tr>
            <td colspan="2">
                <asp:Label ID="LB_autor" runat="server" Text="Autor:"></asp:Label>
                <asp:Label ID="LB_verAutor" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style3">
                <asp:Label ID="LB_muestraContenido" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style3">
                <asp:Button ID="Bt_editarCk" runat="server" OnClick="Bt_editarCk_Click" Text="Editar" CssClass="btn btn-outline-success" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <CKEditor:CKEditorControl ID="Ck_editar" BasePath="/ckeditor/" runat="server" BackColor="Black" ValidationGroup="1" ></CKEditor:CKEditorControl>
                 <asp:RegularExpressionValidator ID="REV_max" runat="server"
                    ControlToValidate="Ck_editar" 
                    ErrorMessage="*" 
                    ForeColor="Red" ValidationExpression="^[\s\S]{0,5000}$" ValidationGroup="1"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RFV_Contenido" runat="server" ControlToValidate="Ck_editar" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Button ID="BT_editar" runat="server" Text="Guardar Edicion" OnClick="BT_editar_Click" CssClass="btn btn-outline-success" ValidationGroup="1" />
            </td>
            <td><asp:Button ID="BT_volver" runat="server" CssClass="btn btn-outline-danger"  Text="Volver" OnClick="BT_volver_Click" /></td>
        </tr>
    </table>
</asp:Content>





