﻿<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/MasterModerador.master" AutoEventWireup="true" CodeFile="~/Controller/Moderador_reportar_post.aspx.cs" Inherits="View_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

    <table class="w-100">
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right">
                <asp:Label ID="LB_titulo" runat="server" Text="Post a reportar:"></asp:Label>
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
            <td class="text-right">
                <asp:Label ID="LB_motivo" runat="server" Text="Motivo:"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" colspan="2">
                <asp:TextBox ID="TB_reporte" runat="server" Height="166px" TextMode="MultiLine" 
                    Width="404px" ValidationGroup="1" MaxLength="50"   onpaste = "return false;"></asp:TextBox>
                <cc1:filteredtextboxextender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars=" 'ñ" TargetControlID="TB_reporte" />
               
                <asp:RegularExpressionValidator ID="REV_max" runat="server"
                    ControlToValidate="TB_reporte" 
                    ErrorMessage="*" 
                    ForeColor="Red" ValidationExpression="^[\s\S']{0,50}$" ValidationGroup="1"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RFV_reportecontent" runat="server" ControlToValidate="TB_reporte" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right">
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

