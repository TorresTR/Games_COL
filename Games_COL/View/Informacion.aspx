<%@ Page Title="" Language="C#" MasterPageFile="~/View/Paguina_principal.master" AutoEventWireup="true" CodeFile="~/Controller/Informacion.aspx.cs" Inherits="View_Informacionaspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

p.MsoListParagraphCxSpFirst
	{margin-top:0cm;
	margin-right:0cm;
	margin-bottom:0cm;
	margin-left:36.0pt;
	margin-bottom:.0001pt;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Arial",sans-serif;
	color:black;
    }
p.MsoListParagraphCxSpMiddle
	{margin-top:0cm;
	margin-right:0cm;
	margin-bottom:0cm;
	margin-left:36.0pt;
	margin-bottom:.0001pt;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Arial",sans-serif;
	color:black;
    }
p.MsoListParagraphCxSpLast
	{margin-top:0cm;
	margin-right:0cm;
	margin-bottom:0cm;
	margin-left:36.0pt;
	margin-bottom:.0001pt;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Arial",sans-serif;
	color:black;
    }
    .auto-style5 {
        text-align: center;
        width: 539px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="w-100">
    <tr>
        <td>INFORMACION</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="text-left">GamesCol es un proyecto donde podras encontrar publicaciones realizadas por otras personas acerca de videojuegos, del mismo modo podras realizar tus publicaciones sobre el mismo tema, una vez registrado en este proyecto tendras la posibilidad no solo de realizar publicaciones, tambien podras realizar comentarios sobre las mismas, ademas de poder puntuarlas, nuestro sistema registra cada una de estas interacciones como puntuacion tanto para ti como para la persona que realizo la publicacion, estos puntos son acumulables con el fin de obtener ciertos bemeficios.<br />
            <br />
            Al momento de registrarte se te asignara un rango, este con el fin de resaltar el trabajo de algunos en el proyecto, es decir, este rango es&nbsp; un titulo de respeto que se logra al alcanzar cierta cantidad de puntos, a continuacion te mostraremos los rangos existentes que puedes alcanzar y su puntuacion necesaria.<br />
            <br />
            <table class="w-100">
                <tr>
                    <td class="auto-style5">Rango</td>
                    <td class="text-center">Puntos necesarios</td>
                </tr>
                <tr>
                    <td class="auto-style5">Bebe<br />
                        Iniciado<br />
                        Campesino<br />
                        Caballero<br />
                        Heroe<br />
                        Ascendido</td>
                    <td class="text-center">0-150<br />
                        150-300<br />
                        300-700<br />
                        700-1700<br />
                        1700-2700<br />
                        2700-3700</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="text-left">En un principio comenzaras como Bebe, realizando interacciones con el proyecto obtendras puntos que te ayudaran a avanzar en la escala, sin embargo hay una limitante, solo podras realizar 10 interacciones por dia (crear post, comentar, puntuar), de igual manera no podras puntuar tu propia publicacion, aun asi si la podras comentar; Cuando llegues al rango de Ascendido y completes 3700 puntos o mas, tendras la posibilidad de solicitar un ascenso a moderador, el cual tiene la responsabilidad de ayudar a controlar el contenido de la pagina, estos moderadores tambien tienen un rango propio de ellos el cual podras averiguar al&nbsp; llegar a ese puesto.<br />
            <br />
            Animate a registrarte y poder interactuar con demas personas amantes de los videojuegos, poder ver opiniones de los&nbsp; demas y dejar las tuyas acerca de tus juegos favoritos.</td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="BT_volver" runat="server" OnClick="BT_volver_Click" Text="Volver" CssClass="btn btn-outline-danger" />
        </td>
    </tr>
</table>
</asp:Content>

