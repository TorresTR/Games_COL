<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="~/Controller/Generar_token.aspx.cs" Inherits="View_Generar_token" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Styles/Estilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

                        <asp:Label ID="LB_digiteNick" runat="server" Text="Digite su nick:"></asp:Label>
                        <asp:TextBox ID="TB_nick" runat="server" ValidationGroup="1" MaxLength="12"
                           onpaste = "return false;"></asp:TextBox>
                        <cc1:filteredtextboxextender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars=" _-`$'ñ" TargetControlID="TB_nick" />
                       
                        <asp:RequiredFieldValidator ID="RFV_nick" runat="server" ControlToValidate="TB_nick" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="B_aceptar" runat="server" OnClick="B_aceptar_Click" Text="Aceptar" CssClass="btn btn-outline-success" ValidationGroup="1" />
                    &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="B_volver" runat="server" CssClass="btn btn-outline-danger" OnClick="B_volver_Click" Text="Volver" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="L_error" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
