<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/Paguina_principal.master" AutoEventWireup="true" CodeFile="~/Controller/Informacion.aspx.cs" Inherits="View_Informacionaspx" %>

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
        <td>
            <asp:Label ID="LB_informacion" runat="server" Text="INFORMACION"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="text-left">
            <asp:Label ID="LB_info" runat="server" Text="GamesCol es un proyecto donde podras encontrar publicaciones realizadas por otras personas acerca de videojuegos, del mismo modo podras realizar tus publicaciones sobre el mismo tema, una vez registrado en este proyecto tendras la posibilidad no solo de realizar publicaciones, tambien podras realizar comentarios sobre las mismas, ademas de poder puntuarlas, nuestro sistema registra cada una de estas interacciones como puntuacion tanto para ti como para la persona que realizo la publicacion, estos puntos son acumulables con el fin de obtener ciertos beneficios."></asp:Label>
            <br />
            <br />
            <table class="w-100">
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="LB_rango" runat="server" Text="Rango"></asp:Label>
                    </td>
                    <td class="text-center">
                        <asp:Label ID="LB_puntosNec" runat="server" Text="Puntos Necesarios"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        &nbsp;<asp:Label ID="LB_bebe" runat="server" Text="Bebe"></asp:Label>
                        <br />
                        &nbsp;<asp:Label ID="LB_iniciado" runat="server" Text="Iniciado"></asp:Label>
                        <br />
                        &nbsp;<asp:Label ID="LB_campesino" runat="server" Text="Campesino"></asp:Label>
                        <br />
                        &nbsp;<asp:Label ID="LB_caballero" runat="server" Text="Caballero"></asp:Label>
                        <br />
&nbsp;<asp:Label ID="LB_heroe" runat="server" Text="Heroe"></asp:Label>
                        <br />
                        &nbsp;<asp:Label ID="LB_ascendido" runat="server" Text="Ascendido"></asp:Label>

                    </td>
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
        <td class="text-left">
            <asp:Label ID="LB_info2" runat="server" Text="En un principio comenzaras como Bebe, realizando interacciones con el proyecto obtendras puntos que te ayudaran a avanzar en la escala, sin embargo hay una limitante, solo podras realizar 10 interacciones por dia (crear post, comentar, puntuar), de igual manera no podras puntuar tu propia publicacion, aun asi si la podras comentar; Cuando llegues al rango de Ascendido y completes 3700 puntos o mas, tendras la posibilidad de solicitar un ascenso a moderador, el cual tiene la responsabilidad de ayudar a controlar el contenido de la pagina, estos moderadores tambien tienen un rango propio de ellos el cual podras averiguar al&nbsp; llegar a ese puesto."></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="BT_volver" runat="server" OnClick="BT_volver_Click" Text="Volver" CssClass="btn btn-outline-danger" />
        </td>
    </tr>
</table>
</asp:Content>

