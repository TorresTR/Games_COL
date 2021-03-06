﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Paguina_principal.master" AutoEventWireup="true" CodeFile="~/Controller/Ingresar.aspx.cs" Inherits="View_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style6 {
            width: 50%;
            text-align: right;
        }
        .auto-style8 {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td colspan="2">
                <h2 class="auto-style4">Ingresar</h2>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="L_UserName" runat="server" Text="Nick:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TB_UserName" runat="server" CssClass="exampleInputPassword1" ValidationGroup="1" MaxLength="12"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV_username" runat="server" ControlToValidate="TB_UserName" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="validator_username" 
                    runat="server" ControlToValidate="TB_UserName" 
                    ErrorMessage="*Ingrese solo letras Y Numeros" 
                    ForeColor="Red" ValidationExpression="^[A-Za-z0-9_-ñÑ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="L_contraseña" runat="server" Text="Contraseña:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TB_Contraseña" runat="server" TextMode="Password" ValidationGroup="1" MaxLength="12"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV_Contraseña" runat="server" ControlToValidate="TB_Contraseña" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="Validator_contra" 
                    runat="server" ControlToValidate="TB_Contraseña"
                    ErrorMessage="*Ingrese solo letras Y Numeros" 
                    ForeColor="Red" ValidationExpression="^[A-Za-z0-9_-ñÑ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
                
            </td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style4">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/Generar_token.aspx">Olvido su contraseña?</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style4">
                <asp:Label ID="L_error" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Button ID="BT_Ingresar" runat="server" Text="Ingresar" OnClick="BT_Ingresar_Click" CssClass="btn btn-outline-success" ValidationGroup="1" />
            </td>
            <td>
                <asp:Button ID="BT_registro" runat="server" Text="Registarce" OnClick="BT_registro_Click" CssClass="btn btn-outline-info" />
            &nbsp;&nbsp;&nbsp;
                <asp:Button ID="B_volver" runat="server" CssClass="btn btn-outline-danger" OnClick="B_volver_Click" Text="Volver" />
            </td>
        </tr>
    </table>
</asp:Content>

