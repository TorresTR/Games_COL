<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterModerador.master" AutoEventWireup="true" CodeFile="~/Controller/Moderador_informacion.aspx.cs" Inherits="View_Moderador_informacion" %>

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
            <td class="text-left">Bienvenido a GamesCol!!<br />
                <br />GamesCol es un proyecto donde podras encontrar publicaciones realizadas por otras personas acerca de videojuegos, del mismo modo podras realizar tus publicaciones sobre el mismo tema, en este espacio podras comentar y puntuar sobre diferentes publicaciones, dando a conocer asi tu opinion sobre diferentes videojuegos.<br />
                <br />Ahora eres moderador, felicitaciones por tu ascenso, pero tambien debes saber que es importante tu rol en el proyecto, seras uno de los encargados de controlar el contenido publicado, como ya debes estar acostumbrado en tu nuevo rol tambien se manejaran rangos, claro que esta vez sera mas difici alcanzarlos, aun asi sabemos&nbsp; que haras lo posible por llegar al mas alto de ellos, a continuacion te mostramos los rangos de moderados y la puntuacion necesaria para poder alcanzarlos.<br />
                <table class="w-100">
                    <tr>
                        <td class="text-center">Rango</td>
                        <td class="text-center">Puntos necesarios</td>
                    </tr>
                    <tr>
                        <td class="text-center">Rey de la Horda<br />
                            Dios de la guerra<br />
                            Mano derecha</td>
                        <td class="text-center">3700-5800<br />
                            5800-7900<br />
                            7900</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="text-left">Comenzando seras Rey de la horda, ya debes saber como funcionan las puntuaciones, sin embargo te lo recordamos, cada interaccion (crear post, comentar, puntuar), te dara puntos, sin embargo existen limitantes, no podras&nbsp; realizar mas de 10 interacciones diarias, no podras puntuar tus propias publicaciones, aunque si podras comentarlas.<br />
                <br />Al llegar a este punto es admirable tu dedicacion, por lo que estamos seguros&nbsp; que muuy pronto te veremos en lo mas alto de la escala ayudando a los usuarios para tener una mejor convivencia, Esfuerzate!</td>
        </tr>
        <tr>
            <td class="text-center">
                <asp:Button ID="BT_volver" runat="server" OnClick="BT_volver_Click" Text="Volver" CssClass="btn btn-outline-danger" />
            </td>
        </tr>
    </table>
</asp:Content>

