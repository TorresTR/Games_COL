<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="~/Controller/Observador_ver_noticia.aspx.cs" Inherits="View_Observador_ver_noticia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            width: 50%;
        }
    </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Styles/Estilos.css" rel="stylesheet" type="text/css" />
</head>
    <body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="LB_id" runat="server" Visible="False"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="jumbotron">
                    <h2>
                        <asp:Label ID="LB_titAutor" runat="server" Text="Autor:"></asp:Label>
                    </h2>
                    <h3>
                        <asp:Label ID="LB_autor" runat="server"></asp:Label>
                    </h3>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="jumbotron">
                    <h2>
                        <asp:Label ID="LB_titContenido" runat="server" Text="Contenido:"></asp:Label>
                    </h2>
                    <h3>
                        <asp:Label ID="LB_verPost" runat="server"></asp:Label>
                    </h3>
                </td>
            </tr>
            
            <tr>
                <td class="auto-style2" colspan="2">
                    <h4>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </h4>
                    <h5>
                        &nbsp;</h5>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:Button ID="B_volver" runat="server" CssClass="btn btn-outline-danger" OnClick="B_volver_Click" Text="Volver" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div>
            <table class="w-100">
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style3">
                        <asp:GridView ID="GV_comentarios" runat="server">
                        </asp:GridView>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
