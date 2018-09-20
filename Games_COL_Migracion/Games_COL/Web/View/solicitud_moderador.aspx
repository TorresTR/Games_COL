<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/MasterUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/solicitud_moderador.aspx.cs" Inherits="View_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
    <tr>
        <td class="text-center">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            &nbsp;<asp:Label ID="LB_titulo" runat="server" Text="FORMULARIO DE SOLICITUD A MODERADOR"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text-center">
            <asp:Label ID="LB_mensaje" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text-justify">
            <asp:Label ID="LB_info" runat="server" Text="GamesCol es tu pagina de juegos, durante la interaccion con nuestro proyecto has podido ganar cierta cantidad de puntos, los cuales son necesarios para poder ascender y obtener un mayor rango, estos rangos son titulos de prestigio ganados por tu constancia y fidelidad. Al registrarte en nuestro proyecto te identificas como un usuario comun, sin embargo al llegar a 3700 puntos tienes la opcion de solicitar un ascenso a Moderador, te daremos una breve explicacion de lo que esto significa. Un moderador es un usuario con atributos especiales, tiene la oportunidad de atender preguntas, quejas y reclamos echos por los usuarios, tambien es deber de los moderadores el reportar los post que no tengan contenido apropiado para nuestros usuarios o simplemente no se relacionen a la tematica del proyecto, pero no todo es trabajo para el moderador, ademas de las funciones propias de todo usuario(crear post, comentarios, entre otros), podra obtener cierta informacion de los usuarios registrados, sin embargo no se perite la divulgacion, alteracion o manipulacion de dichos datos."></asp:Label>
            <br />
        </td>
    </tr>
    <tr>
        <td class="text-center">
            <asp:Button ID="B_solicitud" runat="server" CssClass="btn btn-outline-success" Text="Enviar Solicitud" OnClick="B_solicitud_Click" />
&nbsp;&nbsp;
            <asp:Button ID="B_volver" runat="server" CssClass="btn btn-outline-danger" Text="Volver" OnClick="B_volver_Click" />
        </td>
    </tr>
</table>
</asp:Content>

