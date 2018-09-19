<%@ Page Language="C#"  EnableEventValidation="false" AutoEventWireup="true" CodeFile="~/Controller/registro.aspx.cs" Inherits="View_registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="Styles/Estilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            text-align: center;
            height: 27px;
        }
        .auto-style4 {
            text-align: center;
            height: 33px;
        }
        .auto-style5 {
            text-align: center;
            width: 388px;
        }
        .auto-style6 {
            text-align: center;
            height: 33px;
            width: 388px;
        }

        .indicadorenlinea {
            border-style: solid;
            border-width: 2px;
            width: 190px;
            padding: 2px;
        }
        .muy_debil{
            background-color:gray;
            color:white;

        }
        .debil{
            background-color:red;
            color:white;
        }
        .media{
            background-color:orange;
            color:white;
        }
        .fuerte{
            background-color:yellow;
            color:white;
        }
        .irrompible{
            background-color:green;
            color:white;
        }

        </style>
</head>
<body>

     <script type="text/javascript">
        function isAlphaNumeric(keyCode)

    {

        return (((keyCode >= 48 && keyCode <= 57)&& isShift == false) ||                     

               (keyCode >= 65 && keyCode <= 90) || keyCode == 8 ||

            (keyCode >= 96 && keyCode <= 105) || keyCode == 32 )

    }               
    </script>

    <form id="form1" runat="server">
        <div>
            <table align="center" class="table-active">
                <tr>
                    <td class="auto-style2" colspan="2"><h2>
                        <asp:Label ID="LB_titReg" runat="server" Text="Registro"></asp:Label>
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="LB_nombre" runat="server" Text="Nombre:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TB_nombre" runat="server" ValidationGroup="1" MaxLength="30" onkeyup = "keyUP(event.keyCode)" 
            onkeydown = "return isAlphaNumeric(event.keyCode);" onpaste = "return false;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV_nombre" runat="server" ControlToValidate="TB_nombre" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="validator_nombre"
                            runat="server" 
                            ControlToValidate="TB_nombre" 
                            ErrorMessage="*" 
                            ForeColor="Red" 
                            ValidationExpression="^[A-Za-z ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="LB_nick" runat="server" Text="Nick:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TB_nick" runat="server" ValidationGroup="1" MaxLength="12" onkeyup = "keyUP(event.keyCode)" 
            onkeydown = "return isAlphaNumeric(event.keyCode);" onpaste = "return false;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV_nick" runat="server" ControlToValidate="TB_nick" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="validator_nick"
                            runat="server" 
                            ControlToValidate="TB_nick" 
                            ErrorMessage="*" 
                            ForeColor="Red" 
                            ValidationExpression="^[A-Za-z0-9_-ñÑ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="LB_correo" runat="server" Text="Correo:"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TB_email" runat="server" TextMode="Email" Width="179px" ValidationGroup="1" MaxLength="50" onkeyup = "keyUP(event.keyCode)" 
            onkeydown = "return isAlphaNumeric(event.keyCode);" onpaste = "return false;" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV_correo" runat="server" 
                            ControlToValidate="TB_email" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                       
                    &nbsp;
                       
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="LB_contra" runat="server" Text="Contraseña:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TB_pass" runat="server" TextMode="Password" ValidationGroup="1" MaxLength="12" onkeyup = "keyUP(event.keyCode)" 
            onkeydown = "return isAlphaNumeric(event.keyCode);" onpaste = "return false;"></asp:TextBox>
                        <ajaxToolkit:PasswordStrength StrengthIndicatorType="BarIndicator" 
                            ID="TB_pass_PasswordStrength" 
                            runat="server" 
                            BehaviorID="TB_pass_PasswordStrength" 
                            TargetControlID="TB_pass" 
                            MinimumLowerCaseCharacters="2" 
                            MinimumNumericCharacters="2" 
                            MinimumUpperCaseCharacters="1" 
                            MinimumSymbolCharacters="1"
                            PreferredPasswordLength="10" 
                            DisplayPosition="RightSide" 
                            BarBorderCssClass="indicadorenlinea"
                            TextStrengthDescriptionStyles="muy_debil;debil;media;fuerte;irrompible"
                            RequiresUpperAndLowerCaseCharacters="true"/>
                        <asp:RequiredFieldValidator ID="RFV_contraseña" runat="server" ControlToValidate="TB_pass" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="valitar_contra"
                            runat="server" 
                            ControlToValidate="TB_pass" 
                            ErrorMessage="*" 
                            ForeColor="Red" 
                            ValidationExpression="^[A-Za-z0-9_-ñÑ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="LB_confirma" runat="server" Text="Connfirme contraseña:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TB_confirmapass" runat="server" TextMode="Password" ValidationGroup="1" MaxLength="12" onkeyup = "keyUP(event.keyCode)" 
            onkeydown = "return isAlphaNumeric(event.keyCode);" onpaste = "return false;"></asp:TextBox>
                        <ajaxToolkit:PasswordStrength StrengthIndicatorType="BarIndicator" 
                            ID="TB_confirmapass_PasswordStrength" 
                            runat="server" 
                            BehaviorID="TB_confirmapass_PasswordStrength" 
                            TargetControlID="TB_confirmapass" 
                            MinimumLowerCaseCharacters="2" 
                            MinimumNumericCharacters="2" 
                            MinimumUpperCaseCharacters="1" 
                            MinimumSymbolCharacters="1"
                            PreferredPasswordLength="10" 
                            DisplayPosition="RightSide" 
                            BarBorderCssClass="indicadorenlinea"
                            TextStrengthDescriptionStyles="muy_debil;debil;media;fuerte;irrompible"
                            RequiresUpperAndLowerCaseCharacters="true"/>
                        <asp:RequiredFieldValidator ID="RFV_confirmapass" runat="server" ControlToValidate="TB_confirmapass" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="valitar_confirmapasss"
                            runat="server" 
                            ControlToValidate="TB_confirmapass" 
                            ErrorMessage="*" 
                            ForeColor="Red" 
                            ValidationExpression="^[A-Za-z0-9_-ñÑ]*$" ValidationGroup="1"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" colspan="2">
                        <asp:Label ID="LB_mensaje" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Button ID="B_registrar" runat="server" OnClick="B_registrar_Click" Text="Registrar" CssClass="btn btn-outline-success" ValidationGroup="1" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="B_volver" runat="server" CssClass="btn btn-outline-danger" OnClick="B_volver_Click" Text="Volver" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
