<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Cai2020.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Cache-Control" content="no-store" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" /><%--para que tome el tamaño de la pantalla--%>
    <script type="text/javascript" src="Scripts/jquery-3.1.1.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui-1.12.1.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="Scripts/Captcha.js" ></script>
    <link type="text/css" rel="stylesheet" href="Styles/bootstrap.min.css"/>
    <link type="text/css" rel="stylesheet" href="Styles/bootstrap-theme.min.css"  />
    <title>Prueba de Registro de Información por Internet</title>
    <link rel="shortcut icon" type="image/x-icon" href="~/images/nube.ico" />
    <style type="text/css">
        #contenedor {
            height:100vh;/*toma el 100 vertical y horizontal de la pantalla*/
            display: flex;
	        flex-direction: row;
	        flex-wrap: nowrap;
	        justify-content: center;
	        align-items: stretch;
	        align-content: center;
            /*background-color:lightgrey;*/
        }
        #hijo{
            /*width:400px;*/
            height:375px;
            /*height:100vh;*/
            align-self: center;
            color:cadetblue;
            /*background-color:lightgrey;*/
            background-color:red;
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

        #foto,#cargando{
            text-align:center;
	        height:100px;
	        width:auto;
            margin:0px auto;
            background-color:#CCCCCC;
        }
        img {
            vertical-align:middle;
        }
        .auto-style1 {
            font-size: small;
            color: #000000;
        }
        .auto-style2 {
            width: 480px;
            height: 100px;
        }
    </style>
    <script type="text/javascript">
           //window.localStorage.clear();
        //localStorage.citas = localStorage.citas || JSON.stringify(Captcha);
          //localStorage.citas = JSON.stringify(Captcha);
        //var miscitas = JSON.parse(localStorage.citas);
        var t, actual, mifoto, minum;
        //$(function () {
        function abrirModal(tipo) {
               $("#<%=txtusuario.ClientID%>").val("");
                if (tipo === 0) {
                    $('#mensaje_error').removeClass("alert alert-danger").addClass("alert alert-success");
                }
                else {
                    $('#mensaje_error').removeClass("alert alert-success").addClass("alert alert-danger");
                }
                $('#vmodal_error').modal();
            }
        //});

            <%--function select(i) {
                actual = i;
                $("#persona").html(miscitas[i].persona);
                <%--$('#<%=TextBox1.ClientID%>').val(miscitas[i].persona);
                minum = miscitas[i].persona;
                $("#frase").html(miscitas[i].frase);
                $('#<%=TextBox2.ClientID%>').val(miscitas[i].foto);
                mifoto = miscitas[i].foto;
                $("#foto").css("background-image", mifoto);
                $("#foto").css("background-repeat", "no-repeat");

                //clearTimeout(t);
                //t = setTimeout(function () { select((i + 1) % miscitas.length); }, 20000);
            }--%>
            
            

            $(function () {
                //var a = Math.floor((Math.random() * 19) + 1);
                //select(a);
                $("Button1").click(function () {
                    $("TextBox1").toggle();
                    $("TextBox2").toggle();
                });

                $("#recaptcha").click(function () {
                    $("#form1").submit();
                });

               

                //$(window).load(function () {
                //    $("#cargando").delay(700).fadeOut("slow");
                //    $('#foto').css({ 'overflow': 'visible' });
                //});
                

                //// tu elemento que quieres activar.
                //var cargando = $("#cargando");

                //// evento ajax start
                //$(document).ajaxStart(function () {
                //    cargando.show();
                //});

                //// evento ajax stop
                //$(document).ajaxStop(function () {
                //    cargando.hide();
                //});

                //$('#Button1').click(function (e) {
                //    e.preventDefault();

                //    $.ajax({
                //        type: "POST",                                              // tipo de request que estamos generando
                //    url: 'Index1.aspx.cs/BuscarNumAleatorio',                    // URL al que vamos a hacer el pedido
                //        data: {mio: "hola"},                                                // data es un arreglo JSON que contiene los parámetros que
                //        // van a ser recibidos por la función del servidor
                //        contentType: "application/json; charset=utf-8",            // tipo de contenido
                //        dataType: "json",                                          // formato de transmición de datos
                //        async: true                                               // si es asincrónico o no
                //        //success: function (resultado) {                            // función que va a ejecutar si el pedido fue exitoso
                //            //var num = resultado.d;
                //            //$('#lblResultado').text('Número aleatorio es ' + num);
                //        //},
                //        //error: function (XMLHttpRequest, textStatus, errorThrown) { // función que va a ejecutar si hubo algún tipo de error en el pedido
                //        //    var error = eval("(" + XMLHttpRequest.responseText + ")");
                //        //    aler(error.Message);
                //        //}
                //    }).done(function (resp) {
                //        $("#vmodal").modal();
                //    });

                //});


            });
            
          

        function mayusculas(CampoTexto) {
            valorNuevo = CampoTexto.value.toUpperCase()
            if (CampoTexto.value != valorNuevo)
                CampoTexto.value = valorNuevo;
        }
        function calle(CampoTexto) {
                soloLetrasY(CampoTexto, " .0123456789");
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


        function enviar()
        {
            var num = minum;
            var imagen = mifoto;
            PageMethods.varlist(num, imagen);
        }
    </script>
</head>
<body >
    <form id="form1" runat="server">
   <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate>--%>
      <div id="contenedor">
        <div id="hijo" >
                            <div>
                             <table class="table" style="width:100%; border-spacing:0px; padding:0px;  margin-bottom:0px" border="1"  >

                              </table>
                            </div>
                   <table class="table" style="width:100%;  border-spacing:0; background-color:lightgrey; padding:0;  margin-bottom:0px " border="1"  >
                       <tr>
                           <td> 
                             <div id="foto" runat="server" >
                                 <img alt="Registra cuenta" class="auto-style2" src="Images/Imagen_reg_carta_480.jpg" /><br />
                           
                                 <%--<img src="Imagen2.aspx"  alt="prueba de imagen dinámica" />--%>
                                 <br />
                              </div>
                               <br />
                                 <div id="Div1" runat="server" >
                                 <center>
                                 <img src="imagen.aspx"  alt="captcha" id="Img1" runat="server" />
                                 <%--<img src="Imagen2.aspx"  alt="prueba de imagen dinámica" />--%>
                                 <br />
                                     </center>
                              </div>
                           </td>

                        </tr> 
                                <%--<tr>
                                    <td style="width:100%; text-align:center; background-color:rgb(235,236,239);  border-bottom-color:rgb(62,120,179); border-bottom-style:ridge; border-bottom-width:4px; border-top-color:rgb(62,120,179); border-top-style:ridge; border-top-width:4px; ">
                                        <asp:Label ID="Label1" runat="server" Text="Primer Prueba de Autoempadronamiento por Internet" Font-Size="X-Large" ForeColor="#3E78B3" Font-Names="Arial"></asp:Label>
                                    </td>
                                </tr> --%>
                                <tr>
                                    <td  class="input-group" style="border-style: none; border-color: inherit; border-width: 0px; Width: 100%; top: 1px; left: 1px;">
                                        <span class="input-group-addon" style="padding:0">
                                            <button type="button"  class="btn btn-default btn-sm"  id="recaptcha">
                                                <span class="glyphicon glyphicon-refresh"></span> 
                                            </button>
                                        </span>
                                        <span class="auto-style1">No soy robot (escriba aquí la palabra que aparece en el recuadro superior).</span>
                                        <asp:TextBox ID="txtusuario"  Width="100%"  placeholder="No soy robot (escriba aquí la palabra que aparece en el recuadro superior)" ToolTip="Captcha de verificación de humano"  CssClass="form-control" runat="server"  onkeyup="mayusculas(this);calle(this);"  Font-Names="Arial" Font-Size="Small" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="input-group" style="Width:100%; border:0px">
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                        <span class="auto-style1">Escriba aquí la clave de USUARIO que aparece en la carta - invitación.</span>
                                        <asp:TextBox ID="txtpassword"  Width="100%"  placeholder="Escriba aquí la clave de USUARIO que aparece en la carta - invitación" ToolTip="Código único de vivienda" CssClass="form-control" runat="server"  onkeyup="mayusculas(this);calle(this);"   Font-Names="Arial" Font-Size="Small" MaxLength="18"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="input-group" style="Width:100%; border:0px">
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                        <span class="auto-style1">Escriba aquí la CONTRASEÑA que aparece en su carta - invitación.</span>
                                        <asp:TextBox ID="txtcontra"  Width="100%"  placeholder="Escriba aquí la CONTRASEÑA que aparece en su carta - invitación" ToolTip="Contraseña" CssClass="form-control" runat="server"  onkeyup="mayusculas(this);calle(this);"   Font-Names="Arial" Font-Size="Small" MaxLength="18" TextMode="Password" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border-top-color:black; border-top:1px; Width:100%;  border:0px" >
                                        <asp:Button ID="Button1" runat="server" Text="Ingresar" Width="100%"  Height="25px" onclick="Butcon_Click" />
                                          <%--OnClientClick="javascript:enviar();"--%>
                                          <%--onclick="Butcon_Click"--%>
                                    </td>
                                </tr>  
                                 <%--<tr>
                                     <td>
                                         <asp:LinkButton ID="btnExample" runat="server" Text="<i class='glyphicon glyphicon-arrow-right'></i> " CssClass="btn btn-default btn-lg" ></asp:LinkButton>
                                         <asp:Button ID="btn_img" runat="server" Text="Ingresar" Width="50%"  Height="25px" onclick="btn_img_Click" />
                                         
                                         <asp:Label ID="img" runat="server" Text="l"></asp:Label>
                                     </td>
                                 </tr>              --%>    
                              </table>
            </div>
            <div id="vmodal_error" class = "modal fade"  runat="server">
                <div id="mensaje_error" class="alert alert-danger"  runat="server"></div>
            </div>
<%--            <asp:TextBox ID="TextBox1" runat="server" BackColor="White" BorderStyle="None" ForeColor="White" style="display: none;"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" BackColor="White" BorderStyle="None" ForeColor="White" style="display: none;"></asp:TextBox> --%>           
           </div>
      <%-- </ContentTemplate>
        </asp:UpdatePanel>
      <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div id="message"><img src="Images/cargando.gif" /></div>
            </ProgressTemplate>
        </asp:UpdateProgress>--%>
    </form>
</body>
</html>
