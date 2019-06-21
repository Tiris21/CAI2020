<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Llenado.aspx.cs" Inherits="Cai2020.Llenado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        /*#instructivo {
            color: black;
        }
        #instructivo:hover {
                color: white;
            }
        #cue {
            color: black;
        }
         #cue:hover {
                color: white;
            }*/


        /*#cue:visited {
            color: #000000;
            text-decoration: none;
        }
        #cue:link {
            color: red;
            text-decoration: none;
        }*/

            


        .MiDiv {
            float: left;
            padding: 5px;
            margin-right: 5px;
            margin-bottom: 5px;
            border: 1px solid #666;
            border-radius: 12px;
            background-color: lightgrey;
        }
    </style>
    <script type="text/javascript">
        function btncuest(opc) {
            if (opc === 1) {
                $(' #cue').css('display', 'none');;
            }
            else {
                $(' #cue').css('display', 'inline');
            }
        };

        $(function () {
            $('[data-toggle="popover"]').popover();
        });
    </script>
<%--    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>--%>
   <div id="inicio" class="jumbotron">
        <%--<h1 class="text-center">INEGI</h1>--%>
        <div class="text-center">
            <img src="Images/logo_Censo2020.png"/>&nbsp;&nbsp;
            <label id="tit" style="font-size:x-large; color:#3E78B3; font-family:Arial">Prueba de Registro de Información por Internet</label>
            <%--<h2 class="text-center">Primer Prueba de Autoempadronamiento por Internet</h2>--%>
        </div>
        <p class="small text-justify">Bienvenido(a):</p>
        <p class="small text-justify">El Censo de Población y Vivienda 2020 tiene la finalidad de suministrar a la sociedad y al Estado información 
            estadística de calidad, pertinente, veraz y oportuna, a afecto de contribuir al desarrollo nacional, por lo que le solicitamos leer cuidadosamente 
            las instrucciones de llenado y las preguntas de esta prueba para garantizar la correcta integración de sus datos.</p>
        <p class="small text-justify">El cuestionario debe ser contestado por la jefa o jefe, su cónyuje o pareja; de no ser posible, lo puede hacer una persona de 18 años o más de edad que conozca
            los datos de todos los residentes de la vivienda.</p>
        <p class="small text-justify">Los datos que nos aporte serán de carácter confidencial y se utilizarán sólo con fines estadísticos, la aplicación no solicita 
            datos de identificación personal, a excepción de los nombres de pila de los residentes de la vivienda que se registran para facilitar el llenado del cuestionario.</p>
       <p class="small text-justify">El tiempo estimado para su llenado es de 15 minutos, si no le es posible terminar el llenado del cuestionario en una sola sesión, puede continuar
            en otro momento, para ello ingrese nuevamente con su clave de usuario y contraseña.</p>
       <p class="small text-justify">Recuerde que tiene hasta el 30 de noviembre de 2017 para proporcionar su información.</p>
        <div class="text-center">
            <label id="tit2" style="font-size:xx-large;color:#3E78B3;font-family:Arial">Su infomación ya ha sido registrada</label>
        </div>
        <p><center>
            <asp:LinkButton ID="LinkButton1" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="LinkButton1_Click">Reimprimir acuse</asp:LinkButton>
<%--            <a id="instructivo" href="Enconstruccion.aspx" class="btn btn-default btn-lg" >Instructivo de llenado &raquo;</a>
            <a id="cue" href="CuestionarioVivienda.aspx" class="btn btn-default btn-lg" >Iniciar cuestionario &raquo;</a></center>--%>
        </p>
    </div>
    <div id="Sec001" class="row">
        <%--<p class="small text-justify">Artículos de confidencialidad y obligatoriedad</p>--%>
        <div id="Sec002" class="col-md-6">
            <div id="Div1" class="MiDiv" style="width:100%">
              <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                   <tr>
                       <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                           <asp:Label ID="lb_01" runat="server" Text="CONFIDENCIALIDAD" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                       </td>
                   </tr>
                  <tr>
                      <td>
                          <p class="small text-justify" style="font-size:large">Conforme a las disposiciones en vigor del <strong>Artículo 37, párrafo primero</strong>, de la <strong>Ley del Sistema Nacional de Información Estadística y Geográfica:</strong> &quot;Los datos que proporcionen para fines estadísticos los informantes del Sistema a las Unidades en términos de la presente Ley, serán estrictamente confidenciales y bajo ninguna circunstancia podrán utilizarse para otro fin que no sea el estadístico.&quot;</p>
                      </td>
                  </tr>
              </table>
            </div>
        </div>
        <div id="Sec003" class="col-md-6">
            <div id="Div2" class="MiDiv" style="width:100%">
              <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                   <tr>
                       <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                           <asp:Label ID="Label1" runat="server" Text="OBLIGATORIEDAD" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                       </td>
                   </tr>
                  <tr>
                      <td>
                          <p class="small text-justify" style="font-size:large">Conforme a las disposiciones en vigor del <strong>Artículo 45, párrafo primero</strong>, de la <strong>Ley del Sistema Nacional de Información Estadística y Geográfica:</strong> &quot;Los informantes del Sistema estarán obligados a proporcionar, con veracidad y oportunidad, los datos e informes que les soliciten las autoridades competentes para fines estadísticos, censales, geográficos, y prestarán apoyo a las mismas.&quot;</p>
                      </td>
                  </tr>
              </table>
            </div>
        </div>
     </div>
</asp:Content>
