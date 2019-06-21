<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Cai2020.Registrar" %>

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
             //  $("#<%=txtcorreo.ClientID%>").val("");
                if (tipo === 0) {
                    $('#mensaje_error').removeClass("alert alert-danger").addClass("alert alert-success");
                }
                else {
                    $('#mensaje_error').removeClass("alert alert-success").addClass("alert alert-danger");
                }
                $('#vmodal_error').modal();
		}

        function abrirModal2()
        {

                $('#example').modal();
		}

        function confi() {
            $("#confidencialidad").modal();
        }



        function ShowPopup() {
            $("#myModal").modal();
        }



        function confirmacionCuenta() {
            $("#confirmacion").modal();
        }

       function contraDiferente() {
            $("#contrasenadiflenght").modal();
        }

        //});

            <%--function select(i) {
                actual = i;
                $("#persona").html(miscitas[i].persona);
                $('#<%=TextBox1.ClientID%>').val(miscitas[i].persona);
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
                    if (("A" <= c && c <= "Z") || ("a" <= c && c <= "z") || (simbolosValidos.indexOf(c) >= 0) || c == "@" || c == ".")
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
            
          
        


<!--------------------------------------------------------------------------->
            
      <div id="contenedor">
        <div id="hijo" >
                            <div>
                             <table class="table" style="width:100%; border-spacing:0px; padding:0px;  margin-bottom:0px" border="1"  >
                                 <tr>
                                     <td style="width:100%; background-color:white; border-bottom-color:rgb(62,120,179); border-bottom-style:ridge; border-bottom-width:4px; border-top-color:rgb(62,120,179); border-top-style:ridge; border-top-width:4px; padding-top:12px; padding-bottom:12px;">
                                        <div class="row img-responsive h1 text-center " style="margin:0px">
											<%--<img alt="Brand" src="images/database-lock1.png"/>&nbsp&nbsp CAI2020--%>
                                            .</div>
                                     </td>
                                 </tr>
                              </table>
                            </div>
                             <div id="foto" runat="server" >
                                 <!--<img src="imagen.aspx"  alt="captcha" id="captcha" runat="server" />-->
								 <%--<img src="Imagen2.aspx"  alt="prueba de imagen dinámica" />--%>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
                                 <img alt="Crea cuenta" class="auto-style1" src="Images/Imagen_crea_cuenta_480.jpg" /></div>
                             <table class="table" style="width:100%;  border-spacing:0; background-color:lightgrey; padding:0;  margin-bottom:0px " border="1"  >
								 <%--<tr>
                                    <td style="width:100%; text-align:center; background-color:rgb(235,236,239);  border-bottom-color:rgb(62,120,179); border-bottom-style:ridge; border-bottom-width:4px; border-top-color:rgb(62,120,179); border-top-style:ridge; border-top-width:4px; ">
                                        <asp:Label ID="Label1" runat="server" Text="Primer Prueba de Autoempadronamiento por Internet" Font-Size="X-Large" ForeColor="#3E78B3" Font-Names="Arial"></asp:Label>
                                    </td>
                                </tr> --%>
                                <tr>
                                    <td  class="input-group" style="Width: 100%; border:0px">
                                        <span class="input-group-addon" style="padding:0">
                                            <!--<button type="button"  class="btn btn-default btn-sm"  id="correo">
                                                <span class="glyphicon glyphicon-envelope"></span>
                                            </button>-->
											<span class="input-group-addon"><i class="glyphicon glyphicon-envelope"></i></span>
                                        </span>
                                        Escriba su correo electrónico (El que más utilice)
                                        <asp:TextBox ID="txtcorreo"  Width="100%"  placeholder="Escriba su correo electrónico (El que más utilice)" ToolTip="Correo electrónico"  CssClass="form-control" runat="server"  onkeyup="mayusculas(this);calle(this);"  Font-Names="Arial" Font-Size="Small"></asp:TextBox>
										
                                    </td>
	
                                </tr>
								<tr>
                                    <td  class="input-group" style="Width: 100%; border:0px">
                                        <span class="input-group-addon" style="padding:0">
                                        <!--    <button type="button"  class="btn btn-default btn-sm"  id="confcorreo">
                                                <span class="glyphicon glyphicon-envelope"></span> 
                                            </button>-->
											<span class="input-group-addon"><i class="glyphicon glyphicon-envelope"></i></span>
                                        </span>
                                        Confirmar correo electrónico
                                        <asp:TextBox ID="txtrepitecorreo"  Width="100%"  placeholder="Confirmar correo electrónico" ToolTip="Confirmar correo electrónico"  CssClass="form-control" runat="server"  onkeyup="mayusculas(this);calle(this);"  Font-Names="Arial" Font-Size="Small"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="input-group" style="Width:100%; border:0px">
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                        Contraseña (mínimo 8 caracteres)
                                        <asp:TextBox ID="txtpassword"  Width="100%"  placeholder="Contraseña (mínimo 8 caracteres)" ToolTip="Contraseña (minimo 8 caracteres)" CssClass="form-control" runat="server"  onkeyup="mayusculas(this);calle(this);"   Font-Names="Arial" Font-Size="Small" MaxLength="18" TextMode="Password" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="input-group" style="Width:100%; border:0px">
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                        Confirmar Contraseña
                                        <asp:TextBox ID="txtcontra"  Width="100%"  placeholder="Confirmar contraseña" ToolTip="Confirmar Contraseña" CssClass="form-control" runat="server"  onkeyup="mayusculas(this);calle(this);"   Font-Names="Arial" Font-Size="Small" MaxLength="18" TextMode="Password" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="input-group" style="Width:100%; border:0px">
                                        <span class="input-group-addon"></span>
                                        
                                    <asp:HyperLink runat="server" id="HyperLink1" NavigateURL="Confidencialidad.html" Target="_blank" Visible="False">Ver aviso de confidencialidad</asp:HyperLink>    
                                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Ver aviso de confidencialidad." />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border-top-color:black; border-top:1px; Width:100%;  border:0px" >
                                        <asp:Button ID="Button1" runat="server" Text="Ingresar" Width="100%"  Height="25px" onclick="Butcon_Click" />
										<%--OnClientClick="javascript:enviar();"--%><%--onclick="Butcon_Click"--%>
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

		    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
            <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
            <!-- Include all compiled plugins (below), or include individual files as needed -->
            <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>
            <div class="modal fade" id="confirmacioncuenta">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;      <span aria-hidden="true">&times;</span></button>

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


           <div class="modal fade" id="contradiflength">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;      <span aria-hidden="true">&times;</span></button>

                        </div>
                        <div class="modal-body">
							<h4 class="modal-title" style="color:deepskyblue; text-align:center">
                                Minimo 8 caracteres</h4><br /><br />
                           <h4 class="modal-title" style="color:red; text-align:center">
                                Favor de verificar</h4>

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



            
      <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
            <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
            <!-- Include all compiled plugins (below), or include individual files as needed -->
            <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>
            <div class="modal fade" id="confidencialidad">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>

                        </div>
                        <div class="modal-body">
                            <p style="font-weight: bold;font-family: Arial; font-size: medium; color: black; border-style: none">CONFIDENCIALIDAD</p>
                             <p class="small text-justify" style="font-size:large">Conforme a las disposiciones en vigor del <strong>Artículo 37, párrafo primero</strong>, de la <strong>Ley del Sistema Nacional de Información Estadística y Geográfica:</strong> &quot;Los datos que proporcionen para fines estadísticos los informantes del Sistema a las Unidades en términos de la presente Ley, serán estrictamente confidenciales y bajo ninguna circunstancia podrán utilizarse para otro fin que no sea el estadístico.&quot;</p>
                        </div>
          

                        <div class="modal-footer">
                            <center><button type="button" class="btn btn-info" data-dismiss="modal">
                                Cerrar</button></center>
                            
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>


      <!-------------------------------------------------------------->
    

		<%--  <div id="example" class="modal hide fade in" style="display: none;">
		     <div class="modal-header">
			 <a data-dismiss="modal" class="close">×</a>
			 <h3>Cabecera de la ventana</h3>
		  </div>
		  <div class="modal-body">
			 <h4>Texto de la ventana</h4>
			 <p>Mas texto en la ventana.</p>                
		  </div>
		  <div class="modal-footer">
			<a href="index.html" class="btn btn-success">Guardar</a>
			<a href="#" data-dismiss="modal" class="btn">Cerrar</a>
		  </div>
	     </div>--%>
		  
		  <%--            <asp:TextBox ID="TextBox1" runat="server" BackColor="White" BorderStyle="None" ForeColor="White" style="display: none;"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" BackColor="White" BorderStyle="None" ForeColor="White" style="display: none;"></asp:TextBox> --%>           
           </div>
		<%-- </ContentTemplate>
        </asp:UpdatePanel>
      <asp:UpdateProgress ID="UpdateProgress1" runat="server"     DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div id="message"><img src="Images/cargando.gif" /></div>
            </ProgressTemplate>
        </asp:UpdateProgress>--%>
    </form>
</body>
</html>
