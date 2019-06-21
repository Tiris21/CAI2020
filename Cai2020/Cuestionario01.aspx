<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cuestionario01.aspx.cs" Inherits="Cai2020.Cuestionario01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <style type="text/css">
        #contenedor {
            /*height:100vh;toma el 100 vertical y horizontal de la pantalla*/
            display: flex;
	        flex-direction: row;
	        flex-wrap: nowrap;
	        justify-content: center;
	        align-items: center;
	        align-content: center;
            /*background-color:lightgrey;*/
        }
        #hijo{
            width:422px;
            height:558px;
            align-self: center;
            color:cadetblue;
            background-color:lightgrey;
        }
        #Butcon{
          text-align: center;
          /*border: rgba(62,120,179);*/
          background:-webkit-gradient(radial, 165 0, 0, 207 203, 295, from(rgb(235,236,239)), to(#808080));

          /*border:solid 1px #81abeb;*/
          -moz-border-radius-topleft: 5px;
          -moz-border-radius-topright:5px;
          -moz-border-radius-bottomleft:5px;
          -moz-border-radius-bottomright:5px;
          -webkit-border-top-left-radius:5px;
          -webkit-border-top-right-radius:5px;
          -webkit-border-bottom-left-radius:5px;
          -webkit-border-bottom-right-radius:5px;
          border-top-left-radius:5px;
          border-top-right-radius:5px;
          border-bottom-left-radius:5px;
          border-bottom-right-radius:5px;

          -moz-box-shadow: 5px 5px 15px #000000;
          -webkit-box-shadow: 5px 5px 15px #000000;
          box-shadow: 5px 5px 15px #000000;
          color: black;
        }
        /*#Butcon:hover{
           
            background:-webkit-gradient(radial, 165 0, 0, 207 203, 295, from(#808080), to(rgb(235,236,239)));
            transform: scale(1.01, 1);
            -webkit-transform: scale(1.01, 1);
            -moz-transform: scale(1.01, 1);
            -o-transform: scale(1.01, 1);
            -ms-transform: scale(1.01, 1);
            color: white;
        }*/

        #foto{
	        height:100%;
	        max-height:300px;
	        width:auto;
        }
    </style>
    <script type="text/javascript">
        function otro(){
            //alert("Has escrito: ");
           var d1 = document.getElementById('MainContent_Div1');
           d1.style.display = 'none';
        }

    </script>

    <script type="text/javascript">
        $(function () {
            //$("Button1").click(function () {
                //$("MainContent_Div1").toggle();
            //});
            $(':text').focus(function () {
                $(this).css("background-color", "LightSteelBlue");
            });
            $(':text').blur(function () {
                $(this).css("background-color", "white");
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('textarea').focus(function () {
                $(this).css("background-color", "LightSteelBlue");
            });
            $('textarea').blur(function () {
                $(this).css("background-color", "white");
            });
        });
    </script>
<asp:ScriptManager ID="ScriptManager1" runat="server">
    <Scripts>
        <asp:ScriptReference Path="~/Scripts/myFunctions.js" />
    </Scripts>
</asp:ScriptManager>
 <%--   <script type="text/javascript">
            var bPreguntar = true;
            window.onbeforeunload = preguntarAntesDeSalir;
            function preguntarAntesDeSalir() {
                    if (bPreguntar)
                        return "¿Está seguro de abandonar la aplicación?";
            }
    </script>
<script type="text/j--%>avascript">
    //    function uno(src, color_entrada) {
    //        src.bgColor = color_entrada; src.style.cursor = "hand";
    //    }
    //    function dos(src, color_default) {
    //        src.bgColor = color_default; src.style.cursor = "default";
    //    }
    function uno(src, color_entrada) {
        src.bgColor = color_entrada;
    }
    function dos(src, color_default) {
        src.bgColor = color_default;
    }
</script>
<script type="text/javascript">
        function mayusculas(CampoTexto) {
            valorNuevo = CampoTexto.value.toUpperCase()
            if (CampoTexto.value != valorNuevo)
                CampoTexto.value = valorNuevo;
        }
        function calle(CampoTexto) {
            soloLetrasY(CampoTexto, " ,-.0123456789");
        }
        function soloLetrasY(CampoTexto, simbolosValidos) {
            valorNuevo = "";
            simbolosValidos = simbolosValidos + "ñÑáéíóúüÁÉÍÓÚÜ";
            for (x = 0; x < CampoTexto.value.length; x++) {
                c = CampoTexto.value.charAt(x);
                if (("A" <= c && c <= "Z") || ("a" <= c && c <= "z") || (simbolosValidos.indexOf(c) >= 0))
                    valorNuevo += c;
            }
            if (CampoTexto.value != valorNuevo)
                CampoTexto.value = valorNuevo;
        }
        function soloNumeros(CampoTexto) {
            valorNuevo = "";
            for (x = 0; x < CampoTexto.value.length; x++) {
                c = CampoTexto.value.charAt(x);
                if (("0" <= c && c <= "9"))
                    valorNuevo += c;
            }
            if (CampoTexto.value != valorNuevo)
                CampoTexto.value = valorNuevo;
        }
</script>
<style type="text/css">
.MiBorde
    {
    border-color:Silver;
    border-style:solid;
    border-width:thin;
    }
</style>
<br />
<br />
<br />
<div id="contenedor">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
           <div id="Divprin" runat="server" visible="true" style="height:100%; width:100%;">
               <table width="100%" border="0" cellpadding="0" cellspacing="0"> <%-- style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;"--%>
                <tr>
                 <td align="center" valign="top" width="100%">
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <p>
                                <img src="images/loading.gif" alt="" />&nbsp; <strong>Espere...!!</strong></p>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                  </td>
                 </tr>
                </table>
           </div>
            <div  id="Div1" runat="server" visible="true" style="height:100%; width:100%;">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="center" valign="top" width="100%">
                        <table width="80%">
                        <tr>
 	               	    <td align="center" valign="bottom">
                                <asp:Label ID="Label1" runat="server" Text="Domicilio de la Vivienda" Font-Size="X-Large" ForeColor="CadetBlue" Font-Names="Arial"></asp:Label>
                        </td>
                        </tr>
                        </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
    <%--                <tr>
                        <td align="center" valign="top" colspan="3">
                            <asp:Label ID="Lblresp" runat="server" Text="Datos del responsable" Font-Names="Arial" Font-Size="Medium" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                        </td>
                    </tr>--%>
                    <%-- style='background-color:#F7F6F3;--%>
                    <tr>
                        <td align="center" style='width:100%;'>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="center" valign="top" style='border-top:none;width:10%;'>

                                    </td>
                                    <td align="left" valign="top" style='border-top:none;border-left:none;width:80%;'>
                                            <p style="font-size:medium; color:Black;">
                                                Clave única de vivienda: <asp:Label ID="Label4" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                                    <br />
                                                Clave del Centro de Captura: <asp:Label ID="Label7" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                                    <br />
                                                    <br />
                                                Con el fin de medir algunos aspectos durante la recepción de paquetes en los centros de captura municipal, te solicitamos contestar el siguiente cuestionario:
                                            </p>
                                    </td>
                                    <td align="center" valign="top" style='border-top:none;border-left:none;width:10%;'>

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    </table>
            </div>
           <div id="Div2" runat="server" visible="true" style="height:100%; width:100%;">
               <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center" style='width:100%;'>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:80%;'>
                                       <p style="font-size:medium; color:Black;">
                                           DURACIÓN
                                           <br />
                                           <br />
                                           1. Tiempo de recepción de paquetes aproximado en minutos contando desde la 
                                           recepción de la USB y paquetes de documentos físicos hasta la finalización de la 
                                           entrega.
                                       </p>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:10%;'>

                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td  colspan="3">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center" style='width:100%;'>
                        <table width="80%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:25%;'>
                                    <asp:Label ID="Lbloper" runat="server" Text="Clave Operativa RA" Font-Names="Arial" Font-Size="Small" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:Label ID="Lblnumpaq" runat="server" Text="Número de paquetes" Font-Names="Arial" Font-Size="Small" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:Label ID="Lblnumdoc" runat="server" Text="Número de documentos" Font-Names="Arial" Font-Size="Small" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:Label ID="Lbltiempo" runat="server" Text="Tiempo en minutos" Font-Names="Arial" Font-Size="Small" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:25%;'>
                                    <asp:TextBox ID="Tbxoper01" runat="server" MaxLength="8" Width="56px" onkeyup="mayusculas(this);calle(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:TextBox ID="Tbxnoext01" runat="server" MaxLength="9" Width="63px" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:TextBox ID="Tbxnoint01" runat="server" MaxLength="9" Width="63px" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:TextBox ID="Tbxtiempo01" runat="server" MaxLength="9" Width="63px" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:25%;'>
                                    <asp:TextBox ID="Tbxoper02" runat="server" MaxLength="8" Width="56px" onkeyup="mayusculas(this);calle(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:TextBox ID="Tbxnoext02" runat="server" MaxLength="9" Width="63px" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:TextBox ID="Tbxnoint02" runat="server" MaxLength="9" Width="63px" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:TextBox ID="Tbxtiempo02" runat="server" MaxLength="9" Width="63px" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:25%;'>
                                    <asp:TextBox ID="Tbxoper03" runat="server" MaxLength="8" Width="56px" onkeyup="mayusculas(this);calle(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:TextBox ID="Tbxnoext03" runat="server" MaxLength="9" Width="63px" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:TextBox ID="Tbxnoint03" runat="server" MaxLength="9" Width="63px" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:TextBox ID="Tbxtiempo03" runat="server" MaxLength="9" Width="63px" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:25%;'>
                                    <asp:TextBox ID="Tbxoper04" runat="server" MaxLength="8" Width="56px" onkeyup="mayusculas(this);calle(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:TextBox ID="Tbxnoext04" runat="server" MaxLength="9" Width="63px" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:TextBox ID="Tbxnoint04" runat="server" MaxLength="9" Width="63px" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:TextBox ID="Tbxtiempo04" runat="server" MaxLength="9" Width="63px" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:25%;'>
                                    <asp:TextBox ID="Tbxoper05" runat="server" MaxLength="8" Width="56px" onkeyup="mayusculas(this);calle(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:TextBox ID="Tbxnoext05" runat="server" MaxLength="9" Width="63px" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:TextBox ID="Tbxnoint05" runat="server" MaxLength="9" Width="63px" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:TextBox ID="Tbxtiempo05" runat="server" MaxLength="9" Width="63px" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:25%;'>
                                    <asp:TextBox ID="Tbxoper06" runat="server" MaxLength="8" Width="56px" onkeyup="mayusculas(this);calle(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:TextBox ID="Tbxnoext06" runat="server" MaxLength="9" Width="63px" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:TextBox ID="Tbxnoint06" runat="server" MaxLength="9" Width="63px" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:TextBox ID="Tbxtiempo06" runat="server" MaxLength="9" Width="63px" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:25%;'>
                                    <asp:TextBox ID="Tbxoper07" runat="server" MaxLength="8" Width="56px" onkeyup="mayusculas(this);calle(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:TextBox ID="Tbxnoext07" runat="server" MaxLength="9" Width="63px" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:TextBox ID="Tbxnoint07" runat="server" MaxLength="9" Width="63px" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:25%;'>
                                    <asp:TextBox ID="Tbxtiempo07" runat="server" MaxLength="9" Width="63px" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
               </table>
           </div>
           <div id="Div8" runat="server" visible="true" style="height:100%; width:100%;">
                   <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                     <td>
                        <br />
                     </td>
                    </tr>
                    <tr>
                     <td align="center" valign="top" width="100%">
                             <asp:Button ID="Button1" runat="server" Text="Guardar" 
                                 ToolTip="Guardar los datos" OnClientClick='$("#MainContent_Div1").toggle();$(document.getElementById("MainContent_Tbxoper01")).focus();'/>  <%--onclick="Button1_Click"  OnClientClick="return confirm('¿Está seguro de guardar los datos?')"--%>
                     </td>
                    </tr>
                   </table>           
           </div>
        </ContentTemplate>
        </asp:UpdatePanel>
</div>
</asp:Content>
