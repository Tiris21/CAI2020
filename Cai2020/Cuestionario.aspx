<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cuestionario.aspx.cs" Inherits="Cai2020.Cuestionario" %>
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
        $(function () {
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
    <script type="text/javascript">
        var bPreguntar = true;
        window.onbeforeunload = preguntarAntesDeSalir;
        function preguntarAntesDeSalir()
        {
        if (bPreguntar)
            return "¿Está seguro de abandonar la aplicación?";
        }
    </script>
<script type="text/javascript">
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

               <div class="modal fade" id="myModal">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>

                        </div>
                        <div class="modal-body">
							<h4 class="modal-title" style="color:deepskyblue; text-align:center">
                                Su cuenta ha sido creada exitosamente</h4><br /><br />
                           <h4 class="modal-title" style="color:red; text-align:center">
                                Hemos enviado un mensaje a su correo electrónico,</h4>
							<h4 class="modal-title" style="color:red; text-align:center">
                                con la liga para ingresar al sitio INEGI</h4>
							<h4 class="modal-title" style="color:red; text-align:center">
                                en donde podrá contestar el cuestionario del censo</h4><br />
							<h5 class="modal-title" style="color:black; text-align:center">
                               Gracias por estar participando!</h5>
                        </div>
                        <div class="modal-footer">
                            <center><button type="button" class="btn btn-info" data-dismiss="modal">
                                Aceptar</button></center>
                            
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>


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
           <div id="Div7" runat="server" visible="true" style="height:100%; width:100%;">
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
           <div id="Div1" runat="server" visible="true" style="height:100%; width:100%;">
               <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                 <td align="center" valign="top" width="100%" colspan="3">
                  <table width="80%">
                   <tr>
 	               	<td align="center" valign="bottom">
                            <asp:Label ID="Label2" runat="server" Text="Domicilio de la Vivienda" Font-Size="X-Large" ForeColor="CadetBlue" Font-Names="Arial"></asp:Label>
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
<%--                <tr>
                    <td align="center" valign="top" colspan="3">
                        <asp:Label ID="Lblresp" runat="server" Text="Datos del responsable" Font-Names="Arial" Font-Size="Medium" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                    </td>
                </tr>--%>
                <%-- style='background-color:#F7F6F3;--%>
                <tr>
                    <td colspan="3" align="center" style='width:100%;'>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:80%;'>
                                        <p style="font-size:medium; color:Black;">
                                            Clave única de vivienda: <asp:Label ID="Lblnom" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                              <br />
                                            Clave del Centro de Captura: <asp:Label ID="Lblconscm" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
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
                <tr>
                    <td colspan="3" align="center" style='width:100%;'>
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
                    <td colspan="3" align="center" style='width:100%;'>
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
                <tr>
                    <td  colspan="3">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center" style='width:100%;'>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:80%;'>
                                       <p style="font-size:medium; color:Black;">
                                           SOFTWARE
                                           <br />
                                           <br />
                                           2. Las dificultades que se han presentado en Siseg Local responden a los siguientes temas:
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
                    <td colspan="3" align="center" style='width:100%;'>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;width:40%;'>
                                    <asp:Label ID="Lbldescarga" runat="server" Text="Descarga de Siseg Local" Font-Names="Arial" Font-Size="Small" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:40%;'>
                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" Height="16px" RepeatDirection="Horizontal" Width="85px">
                                     <asp:ListItem>Si</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;width:40%;'>
                                    <asp:Label ID="Lblconfimpre" runat="server" Text="Configuración de impresora" Font-Names="Arial" Font-Size="Small" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:40%;'>
                                    <asp:RadioButtonList ID="RadioButtonList3" runat="server" Height="16px" RepeatDirection="Horizontal" Width="85px">
                                     <asp:ListItem>Si</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;width:40%;'>
                                    <asp:Label ID="Lblconfrouter" runat="server" Text="Configuración de router" Font-Names="Arial" Font-Size="Small" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:40%;'>
                                    <asp:RadioButtonList ID="RadioButtonList4" runat="server" Height="16px" RepeatDirection="Horizontal" Width="85px">
                                     <asp:ListItem>Si</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;width:40%;'>
                                    <asp:Label ID="Lblkiosco" runat="server" Text="Kiosco" Font-Names="Arial" Font-Size="Small" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:40%;'>
                                    <asp:RadioButtonList ID="RadioButtonList5" runat="server" Height="16px" RepeatDirection="Horizontal" Width="85px">
                                     <asp:ListItem>Si</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;width:40%;'>
                                    <asp:Label ID="Label3" runat="server" Text="Envío de información" Font-Names="Arial" Font-Size="Small" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:40%;'>
                                    <asp:RadioButtonList ID="RadioButtonList6" runat="server" Height="16px" RepeatDirection="Horizontal" Width="85px">
                                     <asp:ListItem>Si</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;width:40%;'>
                                    <asp:Label ID="Label5" runat="server" Text="La integración de paquetes a Siseg Local (Archivo en USB del RA)" Font-Names="Arial" Font-Size="Small" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:40%;'>
                                    <asp:RadioButtonList ID="RadioButtonList7" runat="server" Height="16px" RepeatDirection="Horizontal" Width="85px">
                                     <asp:ListItem>Si</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;width:40%;'>
                                    <asp:Label ID="Label6" runat="server" Text="Otro, especifique:" Font-Names="Arial" Font-Size="Small" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:40%;'>
                                    <asp:TextBox ID="Tbxsoftotro" runat="server" MaxLength="60" Width="420px" onkeyup="mayusculas(this);calle(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>
                                    
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
                    <td colspan="3" align="center" style='width:100%;'>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:80%;'>
                                    <asp:Label ID="Lbltiempoenvio" runat="server" Text="3. ¿En qué tiempo (minutos) se realizó el envío de información a oficinas centrales?" Font-Names="Arial" Font-Size="Medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    &nbsp&nbsp
                                    <asp:TextBox ID="Tbxtiempoenvio" runat="server" ToolTip="Minutos" MaxLength="4" Width="28px" onkeyup="soloNumeros(this);"></asp:TextBox>
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
                    <td colspan="3" align="center" style='width:100%;'>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:80%;'>
                                       <p style="font-size:medium; color:Black;">
                                           INTEGRIDAD DE INSUMOS
                                           <br />
                                           <br />
                                           4. ¿Se presentó alguna situación que impactara o dificultara la recepción en la fecha programada (11 de marzo)?
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
                    <td colspan="3" align="center" style='width:100%;'>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;width:40%;'>
                                    <asp:Label ID="Lblf_equipo" runat="server" Text="Falta de equipo" Font-Names="Arial" Font-Size="Small" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:40%;'>
                                    <asp:CheckBox ID="CheckBox1" runat="server" Enabled="True"/> 
                                </td>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;width:40%;'>
                                    <asp:Label ID="Lblf_camara" runat="server" Text="Falta de cámara web" Font-Names="Arial" Font-Size="Small" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:40%;'>
                                    <asp:CheckBox ID="CheckBox2" runat="server" Enabled="True"/> 
                                </td>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;width:40%;'>
                                    <asp:Label ID="Lblf_conexion" runat="server" Text="Falta de conexión de voz y datos" Font-Names="Arial" Font-Size="Small" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:40%;'>
                                    <asp:CheckBox ID="CheckBox3" runat="server" Enabled="True"/>                                 
                                </td>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;width:40%;'>
                                    <asp:Label ID="Lblf_ra" runat="server" Text="Ausencia de RA" Font-Names="Arial" Font-Size="Small" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:40%;'>
                                    <asp:CheckBox ID="CheckBox4" runat="server" Enabled="True"/>
                                </td>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;width:40%;'>
                                    <asp:Label ID="Lblfalla_tra" runat="server" Text="Falla en la transferencia de información RA" Font-Names="Arial" Font-Size="Small" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:40%;'>
                                    <asp:CheckBox ID="CheckBox5" runat="server" Enabled="True"/>
                                </td>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;width:40%;'>
                                    <asp:Label ID="Lblintegriotro" runat="server" Text="Otro" Font-Names="Arial" Font-Size="Small" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:40%;'>
                                    <asp:TextBox ID="Tbxintegriotro" runat="server" MaxLength="60" Width="420px" onkeyup="mayusculas(this);calle(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>
                                    
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
                    <td colspan="3" align="center" style='width:100%;'>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:40%;'>
                                       <p style="font-size:medium; color:Black;">
                                           5. De ser así, ¿tomaste alguna estrategia alterna para realizar la recepción de paquetes?
                                       </p>
                                </td>
                                <td align="left" valign="bottom" style='border-top:none;border-left:none;width:40%;'>
                                    <asp:RadioButtonList ID="RadioButtonList8" runat="server" Height="16px" RepeatDirection="Horizontal" Width="85px">
                                     <asp:ListItem>Si</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>                        
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:10%;'>

                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center" style='width:100%;'>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;width:40%;'>
                                    <asp:Label ID="Lblestracual" runat="server" Text="¿Cual?" Font-Names="Arial" Font-Size="Small" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:40%;'>
                                    <asp:TextBox ID="Tbxestracual" runat="server" MaxLength="60" Width="420px" onkeyup="mayusculas(this);calle(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>
                                    
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
                    <td colspan="3" align="center" style='width:100%;'>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:80%;'>
                                       <p style="font-size:medium; color:Black;">
                                           CONDICIONES DE SEGURIDAD
                                           <br />
                                           <br />
                                           6. ¿Cómo percibes las condiciones de seguridad del inmueble?
                                       </p>
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:10%;'>

                                </td>
                            </tr>

                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center" style='width:100%;'>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:80%;'>
                                    <asp:RadioButtonList ID="RadioButtonList9" runat="server" Height="16px" RepeatDirection="Vertical" Width="224px">
                                     <asp:ListItem>a) Muy segura</asp:ListItem>
                                     <asp:ListItem>b) Buena seguridad</asp:ListItem>
                                     <asp:ListItem>c) Seguridad media</asp:ListItem>
                                     <asp:ListItem>d) Requiere medidas de seguridad</asp:ListItem>
                                    </asp:RadioButtonList>                        
                                </td>
                                <td align="center" valign="top" style='border-top:none;border-left:none;width:10%;'>

                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center" style='width:100%;'>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;width:40%;'>
                                    <asp:Label ID="Lblcondicionesotro" runat="server" Text="¿Cuáles?" Font-Names="Arial" Font-Size="Small" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:40%;'>
                                    <asp:TextBox ID="Tbxcondicionesotro" runat="server" MaxLength="60" Width="420px" onkeyup="mayusculas(this);calle(this);"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>
                                    
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
                    <td colspan="3" align="center" style='width:100%;'>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:80%;'>
                                       <p style="font-size:medium; color:Black;">
                                           OBSERVACIONES
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
                    <td colspan="3" align="center" style='width:100%;'>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>

                                </td>
                                <td align="left" valign="top" style='border-top:none;border-left:none;width:80%;'>
                                    <asp:TextBox ID="Tbxobservaciones" runat="server" MaxLength="3500" 
                                        Width="980px" onkeyup="mayusculas(this);calle(this);" TextMode="MultiLine" 
                                        Rows="10"></asp:TextBox>
                                </td>
                                <td align="center" valign="top" style='border-top:none;width:10%;'>
                                    
                                </td>
                            </tr>

                        </table>
                    </td>
                </tr>
               </table>
           </div>
           <div ID="Div8" runat="server" visible="true" style="height:100%; width:100%;">
                   <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                     <td>
                        <br />
                     </td>
                    </tr>
                    <tr>
                     <td align="center" valign="top" width="100%">
                             <asp:Button ID="Button1" runat="server" Text="Guardar" 
                                 ToolTip="Guardar los datos" OnClientClick="return confirm('¿Está seguro de guardar los datos?');"/>  <%--onclick="Button1_Click" --%>
                     </td>
                    </tr>
                   </table>           
           </div>
        </ContentTemplate>
        </asp:UpdatePanel>
</div>
</asp:Content>
