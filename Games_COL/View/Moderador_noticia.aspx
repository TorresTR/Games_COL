﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/Moderador_noticia.aspx.cs" Inherits="View_Moderador_noticia" %>

<%@ Register Assembly="CKEditor.NET"  Namespace="CKEditor.NET" TagPrefix="CKEditor"%>

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
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="LB_tiitulo" runat="server" Text="Titulo:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TB_titulo" runat="server" Width="307px" ValidationGroup="1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV_titulo" runat="server" ControlToValidate="TB_titulo" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="validator_titulo" runat="server"
                    ControlToValidate="TB_titulo" 
                    ErrorMessage="*Ingrese solo letras Y Numeros" 
                    ForeColor="Red" ValidationExpression="^[A-Za-z0-9 ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="LB_Contenido" runat="server" Text="Contenido:"></asp:Label>
                <asp:RequiredFieldValidator ID="RFV_Contenido" runat="server" ControlToValidate="Ckeditor1" ErrorMessage="* Ingrese un Contenido no puede ir vacio" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
             <CKEditor:CKEditorControl ID="Ckeditor1" BasePath="/ckeditor/" runat="server" BackColor="Black" ValidationGroup="1"></CKEditor:CKEditorControl>
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

