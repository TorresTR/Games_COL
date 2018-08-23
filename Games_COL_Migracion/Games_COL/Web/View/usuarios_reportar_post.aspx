﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/usuarios_reportar_post.aspx.cs" Inherits="View_usuarios_reportar_post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 50%;
        }
        .auto-style2 {
            width: 50%;
            text-align: right;
        }
        .auto-style3 {
            width: 50%;
            height: 34px;
            text-align: right;
        }
        .auto-style4 {
            height: 34px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="LB_titilo" runat="server" Text="Post a reportar:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LB_tituloReportar" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="LB_motivo" runat="server" Text="Motivo:"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" colspan="2">
                <asp:TextBox ID="TB_reporte" runat="server" Height="166px" TextMode="MultiLine" Width="404px" ValidationGroup="1" MaxLength="60"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV_reportar" runat="server" ControlToValidate="TB_reporte" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="validator_reporte" 
                    runat="server" 
                    ControlToValidate="TB_reporte" 
                    ErrorMessage="*Ingrese solo Letras y Numeros" 
                    ForeColor="Red" 
                    ValidationExpression="^[A-Za-z0-9 ñÑ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="REV_max" runat="server"
                    ControlToValidate="TB_reporte" 
                    ErrorMessage="*Ingrese el maximo de caracteres 60" 
                    ForeColor="Red" ValidationExpression="^[\s\S]{0,60}$" ValidationGroup="1"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RFV_reportecontent" runat="server" ControlToValidate="TB_reporte" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Button ID="BT_enviarReporte" runat="server" Text="Enviar Reporte" CssClass="btn btn-secondary" OnClick="BT_enviarReporte_Click" ValidationGroup="1"/>
            </td>
            <td class="auto-style4">
                <asp:Button ID="BT_volver" runat="server" Text="Volver" CssClass="btn btn-secondary" OnClick="BT_volver_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
