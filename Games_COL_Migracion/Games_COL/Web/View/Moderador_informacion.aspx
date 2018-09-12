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
            <td class="text-left">
                <asp:Label ID="LB_info" runat="server" Text="Bienvenido a GamesCol!!        GamesCol es un proyecto donde podras encontrar publicaciones realizadas por otras personas acerca de videojuegos, del mismo modo podras realizar tus publicaciones sobre el mismo tema, en este espacio podras comentar y puntuar sobre diferentes publicaciones, dando a conocer asi tu opinion sobre diferentes videojuegos.     Ahora eres moderador, felicitaciones por tu ascenso, pero tambien debes saber que es importante tu rol en el proyecto, seras uno de los encargados de controlar el contenido publicado, como ya debes estar acostumbrado en tu nuevo rol tambien se manejaran rangos, claro que esta vez sera mas difici alcanzarlos, aun asi sabemos&nbsp; que haras lo posible por llegar al mas alto de ellos, a continuacion te mostramos los rangos de moderados y la puntuacion necesaria para poder alcanzarlos."></asp:Label>
                <br />
                <table class="w-100">
                    <tr>
                        <td class="text-center">&nbsp;<asp:Label ID="LB_rango" runat="server" Text="Rango"></asp:Label>
                        </td>
                        <td class="text-center">&nbsp;<asp:Label ID="LB_puntos" runat="server" Text="Puntos Necesarios"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text-center">&nbsp;
                            <asp:Label ID="LB_rey" runat="server" Text="Rey de la Horda"></asp:Label>
                            <br />
                            &nbsp;
                            <asp:Label ID="LB_dios" runat="server" Text="Dios de la Guerra"></asp:Label>
                            <br />
                            &nbsp;<asp:Label ID="LB_mano" runat="server" Text="Mano Derecha"></asp:Label>
                        </td>
                        <td class="text-center">3700-5800<br />
                            5800-7900<br />
                            7900</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="text-left">&nbsp;<asp:Label ID="LB_info2" runat="server" Text="Comenzando seras Rey de la horda, ya debes saber como funcionan las puntuaciones, sin embargo te lo recordamos, cada interaccion (crear post, comentar, puntuar), te dara puntos, sin embargo existen limitantes, no podras&nbsp; realizar mas de 10 interacciones diarias, no podras puntuar tus propias publicaciones, aunque si podras comentarlas. Al llegar a este punto es admirable tu dedicacion, por lo que estamos seguros&nbsp; que muuy pronto te veremos en lo mas alto de la escala ayudando a los usuarios para tener una mejor convivencia, Esfuerzate! "></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="text-center">
                <asp:Button ID="BT_volver" runat="server" OnClick="BT_volver_Click" Text="Volver" CssClass="btn btn-outline-danger" />
            </td>
        </tr>
    </table>
</asp:Content>

