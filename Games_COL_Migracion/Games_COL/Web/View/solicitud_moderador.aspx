<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/solicitud_moderador.aspx.cs" Inherits="View_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
    <tr>
        <td class="text-center">FORMULARIO DE SOLICITUD A MODERADOR</td>
    </tr>
    <tr>
        <td class="text-center">
            <asp:Label ID="LB_mensaje" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>GamesCol es tu pagina de juegos, durante la interaccion con nuestro proyecto has podido ganar cierta cantidad de puntos, los cuales son necesarios para poder ascender y obtener un mayor rango, estos rangos son titulos de prestigio ganados por tu constancia y fidelidad.<br />
            <br />
            Al registrarte en nuestro proyecto te identificas como un usuario comun, sin embargo al llegar a 3700 puntos tienes la opcion de solicitar un ascenso a Moderador, te daremos una breve explicacion de lo que esto significa.<br />
            <br />
            Un moderador es un usuario con atributos especiales, tiene la oportunidad de atender preguntas, quejas y reclamos echos por los usuarios, tambien es deber de los moderadores el reportar los post que no tengan contenido apropiado para nuestros usuarios o simplemente no se relacionen a la tematica del proyecto, pero no todo es trabajo para el moderador, ademas de las funciones propias de todo usuario(crear post, comentarios, entre otros), podra obtener cierta informacion de los usuarios registrados, sin embargo no se perite la divulgacion, alteracion o manipulacion de dichos datos.<br />
            <br />
            Un moderador ayudara a mantener la &quot;calma&quot; en este proyecto, ayudara a los usuarios menos experimentados a manejar de una mejor manera las partes del proyecto.<br />
            <br />
            Si crees que estas dispuesto a asumir esta responsabilidad y cumples con los requisitos, presiona el boton&nbsp; &quot;enviar solicitud&quot; y una solicitud sera enviada directamente a los administradores, los cuales en el menor tiempo posible daran respuesta.<br />
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

