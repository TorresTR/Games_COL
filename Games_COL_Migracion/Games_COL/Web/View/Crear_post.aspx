﻿<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" ValidateRequest="false" CodeFile="~/Controller/Crear_post.aspx.cs" Inherits="View_Crear_post" %>
<%@ Register Assembly="CKEditor.NET"  Namespace="CKEditor.NET" TagPrefix="CKEditor"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Styles/Estilos.css" rel="stylesheet" type="text/css" />
    <script src="../Contenido/CKEditor/ckeditor.js"></script>
    <script src="../Contenido/ckfinder/ckfinder.js"></script>
  

    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 50%;
        }
        .auto-style3 {
            width: 50%;
            text-align: right;
        }
        .auto-style4 {
            text-align: right;
        }
    </style>

</head>
<body>
   
    <form id="form1" runat="server">
        <div>
        
        <table class="auto-style1">
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="text-center">
   
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

                <asp:Label ID="LB_mensaje" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="LB_tiitulo" runat="server" Text="Titulo:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TB_titulo" runat="server" Width="307px" ValidationGroup="1" 
                    MaxLength="20" onpaste = "return false;"></asp:TextBox>
                <cc1:filteredtextboxextender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars=" 'ñ" TargetControlID="TB_titulo" />
                <asp:RequiredFieldValidator ID="RFV_titulo" runat="server" ControlToValidate="TB_titulo" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                
                
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <asp:Label ID="LB_interacciones" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="LB_etiqueta" runat="server" Text="Etiquetas"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DDL_etiquetas" runat="server" DataSourceID="ODS_etiquetas" DataTextField="nombre_etiqueta" DataValueField="id_etiqueta" CssClass="btn btn-primary dropdown-toggle" ValidationGroup="1">
                    <asp:ListItem Value="0">---selecione---</asp:ListItem>
             
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ODS_etiquetas" runat="server" SelectMethod="obtenerEtiquetas" TypeName="Logica.L_persistencia"></asp:ObjectDataSource>
                <asp:RangeValidator ID="RV_DDLetiquetas" runat="server" ControlToValidate="DDL_etiquetas" ErrorMessage="*" ForeColor="Red" MaximumValue="5" MinimumValue="2" ValidationGroup="1"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="LB_Contenido" runat="server" Text="Contenido:"></asp:Label>
                <asp:RequiredFieldValidator ID="RFV_Contenido" runat="server" 
                    ControlToValidate="Ckeditor1" ErrorMessage="*"
                    ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="REV_max" runat="server"
                    ControlToValidate="Ckeditor1" 
                    ErrorMessage="*" 
                    ForeColor="Red" ValidationExpression="^[\s\S]{0,5000}$" ValidationGroup="1"></asp:RegularExpressionValidator>
                
            </td>
        </tr>
        <tr>
            <td colspan="2">
             <CKEditor:CKEditorControl ID="Ckeditor1" BasePath="/ckeditor/" runat="server" BackColor="Black" ValidationGroup="1" ></CKEditor:CKEditorControl>
            </td>
        </tr>
            <tr>
            <td colspan="2">
                <asp:Button ID="BT_guardar" runat="server" Text="Guardar" OnClick="BT_guardar_Click" CssClass="btn btn-outline-success" ValidationGroup="1" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BT_vistaPrevia" runat="server" Text="Vista Previa" OnClick="BT_vistaPrevia_Click" CssClass="btn btn-outline-warning" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="B_volver" runat="server" CssClass="btn btn-outline-danger" OnClick="B_volver_Click" Text="Volver" />
                </td>
        </tr>
            <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>

                 <asp:Label ID="LB_vistaPrev" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>

        </div>
    </form>
</body>
</html>
