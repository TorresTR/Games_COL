﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/Administrador_verpqrCompleto.aspx.cs" Inherits="View_Administrador_verpqrCompleto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Styles/Estilos.css" rel="stylesheet" type="text/css" />&nbsp;<style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
                                                                                     width: 706px;
                                                                                 }
        </style></head><body><form id="form1" runat="server">
        <div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>


            <tr class="jumbotron">
                
                <td class="auto-style3">
                    <h2>Autor:</h2>
                    <h3 class="display-3">
                    <asp:Label ID="LB_autor" runat="server"></asp:Label>
                        </h3>

                </td>

                <td class="jumbotron">
                    <h2>&nbsp;</h2>
                    <h3 class="display-3">
                        &nbsp;</h3></td>
            </tr>
            <tr>
                
                <td class="auto-style3">
                    <h2>Contenido:</h2>
                    <h4>
                    <asp:Label ID="LB_muestraPag" runat="server"></asp:Label>
                    </h4>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                
                <td class="auto-style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    
                    <h4>

                            
                    </h4>
                    <h5>
                    
                    </h5>
                </td>
            </tr>
            <tr>



               <td class="text-center" colspan="2">
                    <asp:Label ID="LB_comentar" runat="server" Text="Responder:"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:TextBox ID="TB_respuestapqr" runat="server" Height="79px" TextMode="MultiLine" Width="344px" ValidationGroup="1" MaxLength="150"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RFV_respuesta" runat="server" ControlToValidate="TB_respuestapqr" ErrorMessage="*" 
                         ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="REV_max" runat="server"
                    ControlToValidate="TB_respuestapqr" 
                    ErrorMessage="*Ingrese el maximo de caracteres 150" 
                    ForeColor="Red" ValidationExpression="^[\s\S]{0,150}$" ValidationGroup="1"></asp:RegularExpressionValidator>
                     <asp:RegularExpressionValidator ID="validator_comentario" runat="server" 
                         ControlToValidate="TB_respuestapqr" ErrorMessage="*Ingrese solo letras Y Numeros" 
                         ForeColor="Red" ValidationExpression="^[A-Za-z0-9 ñÑ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Button ID="BT_responder" runat="server"  Text="Responder" CssClass="btn btn-outline-danger" OnClick="BT_responder_Click" ValidationGroup="1" />
                &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="B_volver" runat="server" CssClass="btn btn-outline-info"  Text="Volver" OnClick="B_volver_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" class="text-center">
                    &nbsp;</td>
            </tr>
        </table>
        
        </div>
    </form>
</body>
</html>

