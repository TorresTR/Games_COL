<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/Paguina_principal.master" AutoEventWireup="true" CodeFile="~/Controller/Ingresar.aspx.cs" Inherits="View_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
                <h2 class="auto-style4">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:Label ID="LB_ingresar" runat="server" Text="Ingresar"></asp:Label>
                </h2>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="L_UserName" runat="server" Text="Nick:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TB_UserName" runat="server" CssClass="exampleInputPassword1" ValidationGroup="1" MaxLength="12" 
             onpaste = "return false;"></asp:TextBox>
                 <cc1:filteredtextboxextender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars=" _-ñ" TargetControlID="TB_UserName" />
                <asp:RequiredFieldValidator ID="RFV_username" runat="server" ControlToValidate="TB_UserName" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="validator_username" 
                    runat="server" ControlToValidate="TB_UserName" 
                    ErrorMessage="*" 
                    ForeColor="Red" ValidationExpression="^[A-Za-z0-9_-ñÑ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="L_contraseña" runat="server" Text="Contraseña:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TB_Contraseña" runat="server" TextMode="Password" ValidationGroup="1" MaxLength="12" 
            onpaste = "return false;"></asp:TextBox>
                 <cc1:filteredtextboxextender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers,LowercaseLetters, UppercaseLetters, Custom" ValidChars=" _-ñ" TargetControlID="TB_Contraseña" />
                <asp:RequiredFieldValidator ID="RFV_Contraseña" runat="server" ControlToValidate="TB_Contraseña" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="Validator_contra" 
                    runat="server" ControlToValidate="TB_Contraseña"
                    ErrorMessage="*" 
                    ForeColor="Red" ValidationExpression="^[A-Za-z0-9_-ñÑ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
                
            </td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style4">
                <asp:HyperLink ID="HL_recuperar" runat="server" NavigateUrl="~/View/Generar_token.aspx">Olvido su contraseña?</asp:HyperLink>
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
        <tr>
            <td class="auto-style8">
                <asp:Button ID="BT_gmail" runat="server" OnClick="BT_gmail_Click" Text="Login con Gmail" CssClass="btn btn-outline-success" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnLogin" runat="server" OnClick="Login" Text="Login with FaceBook" CssClass="btn btn-outline-success" />
                <asp:Panel ID="pnlFaceBookUser" runat="server" Visible="false">
<hr />
                    <table>
                        <tr>
                            <td rowspan="5">
                                <asp:Image ID="ProfileImage" runat="server" Height="50" Width="50" Visible="false" />
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblId" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblUserName" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblName" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblEmail" runat="server" Text=""  Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">
                    <table>
                        <tr _>
                            <td rowspan="5">
                                <asp:Image ID="ProfileImageG" runat="server" Height="50" Width="50" Visible="false" />
                            </td>
                        </tr>
                        <tr >
                            <td ><asp:Label ID="Lb_idG" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr >
                            <td><asp:Label ID="lblUserNameG" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr >
                            <td ><asp:Label ID="lblNameG" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr >
                            <td ><asp:Label ID="lblEmailG" runat="server"  Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

