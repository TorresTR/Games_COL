<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/usuario_informacion.aspx.cs" Inherits="View_usuario_informacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
    <tr>
        <td class="text-center">INFORMACION</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="text-left">&nbsp;<asp:Label ID="LB_info1" runat="server" Text="Gracias por registrarte en GamesCol!!     GamesCol es un proyecto donde podras encontrar publicaciones realizadas por otras personas acerca de videojuegos, del mismo modo podras realizar tus publicaciones sobre el mismo tema, en este espacio podras comentar y puntuar sobre diferentes publicaciones, dando a conocer asi tu opinion sobre diferentes videojuegos.   Al momento de registrarte se te asigno un rango, este con el fin de&nbsp; dar un prestigio a los&nbsp; diferentes usuarios, mientras realices interacciones (crear post, comentar, puntuar), obtendras puntos necesarios para poder ascender de rango, en la siguiente tabla podras observar los rangos disponibles y la puntuacion necesaria para llegar al mismo."></asp:Label>
            <br />
            <table class="w-100">
                <tr>
                    <td class="text-center">&nbsp;
                        <asp:Label ID="LB_rango" runat="server" Text="Rango"></asp:Label>
                    </td>
                    <td class="text-center">&nbsp;
                        <asp:Label ID="LB_puntos" runat="server" Text="Putos Necesarios"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text-center">&nbsp;
                        <asp:Label ID="LB_bebe" runat="server" Text="Bebe"></asp:Label>
                        <br />&nbsp;
                        <asp:Label ID="LB_iniciado" runat="server" Text="Iniciado"></asp:Label>
                        <br />&nbsp;
                        <asp:Label ID="LB_campesino" runat="server" Text="Campesino"></asp:Label>
                        <br />&nbsp;
                        <asp:Label ID="LB_caballero" runat="server" Text="Caballero"></asp:Label>
                        <br />&nbsp;
                        <asp:Label ID="LB_heroe" runat="server" Text="Heroe"></asp:Label>
                        <br />&nbsp;
                        <asp:Label ID="LB_ascendido" runat="server" Text="Ascendido"></asp:Label>
                    </td>
                    <td class="text-center">0-150<br />150-300<br />300-700<br />700-1700<br />1700-2700<br />2700-3700</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="text-left">&nbsp;
            <asp:Label ID="LB_info2" runat="server" Text="En un principio comenzaras como Bebe, realizando interacciones con el proyecto obtendras puntos que te ayudaran a avanzar en la escala, sin embargo hay una limitante, solo podras realizar 10 interacciones por dia (crear post, comentar, puntuar), de igual manera no podras puntuar tu propia publicacion, aun asi si la podras comentar; Cuando llegues al rango de Ascendido y completes 3700 puntos o mas, tendras la posibilidad de solicitar un ascenso a moderador, el cual tiene la responsabilidad de ayudar a controlar el contenido de la pagina, estos moderadores tambien tienen un rango propio de ellos el cual podras averiguar al&nbsp; llegar a ese puesto.   Animate a interactuar con los demas usuarios del proyecto y diviertete en el proceso, esperamos verte muy pronto entre los mas altos rangos."></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text-center">
            <asp:Button ID="BT_volver" runat="server" OnClick="BT_volver_Click" Text="Volver" CssClass="btn btn-outline-danger" />
        </td>
    </tr>
</table>
</asp:Content>

