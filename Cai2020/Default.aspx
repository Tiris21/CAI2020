<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Cai2020._Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <style type="text/css">
.Mibk
    {
    background-color:#f0f0f0;
    }
.MiBorde
    {
    border-color:Silver;
    border-style:solid;
    border-width:thin;
    }
.MiDiv
    {
	float: left;
	padding: 5px;
	margin-right: 5px;
	margin-bottom: 5px;
	border: 1px solid #666;
    border-radius: 12px;    
    }
#contenedor {
    height:100vh;/*toma el 100 vertical y horizontal de la pantalla*/
     display: flex;
	flex-direction: row;
	flex-wrap: nowrap;
	justify-content: center;
	align-items:stretch;
	align-content: stretch;
    /*background-color:lightgrey;*/
}
.Radios{
        font-family:Arial;
        font-Size:large;
        color:Black;
        border-style:none;
       }
#foto{
            text-align:center;
	        /*height:100px;*/
            height:auto;
	        width:auto;
            margin:0px auto;
            background-color:#CCCCCC;
        }
.Imagen{
    display: block;
    margin: 0 auto;
    width: 87%;
    /*height: 50%;*/
}
/*.popover{
   padding-top:250px;
   border: 1px solid #666;
   border-radius: 12px;
   min-width:100%;
   width:100%;
   max-width:600px;
   overflow-wrap:break-word;
}*/
  
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


<%--		function abrirModal(tipo) {
             //  $("#<%=txtcorreo.ClientID%>").val("");
                if (tipo === 0) {
                    $('#mensaje_error').removeClass("alert alert-danger").addClass("alert alert-success");
                }
                else {
                    $('#mensaje_error').removeClass("alert alert-success").addClass("alert alert-danger");
                }
                $('#vmodal_error').modal();
		}--%>

        function abrirModal(tipo) {
            //  $("#<%=txtcorreo.ClientID%>").val("");
            //if (tipo === 0) {
            //    $('#mensaje_error').removeClass("alert alert-danger").addClass("alert alert-success");
            //}
            //else {
            //    $('#mensaje_error').removeClass("alert alert-success").addClass("alert alert-danger");
            //}
            $('#vmodal_error').modal();
        }
        function abrirModal2()
        {
            $('#example').modal();
		}
		
        function ShowPopup() {
            $("#myModal").modal();
        }

        function confi() {
            $("#confidencialidad").modal();
        }

        function longitud()
        {
            $("#errorLongitug").modal();
        }

        function confirmacion() {
            $("#confirmacion").modal();
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
            
        // EN EL CLIENTE
        function cambiarIdioma(idioma) {            
            switch (idioma) {
                case "NUNCA ENTRARA AQUI":
                    //cambiar la imagen
                    $('#foto').html('<img alt="Registra cuenta" class="auto-style2" src="Images/Imagen_reg_carta_480.jpg" /> <br /> <br />');
                    break;
                case ("in"):
                    $("#HeadLoginView_HeadLoginStatus").text("Exit..");

                    $(".txt_correo").text("Write your email (the one you use the most).");
                    $(".txt_correo").attr("placeholder", "Write your email (the one you use the most).");
                    $(".txt_confirmacorreo").text("Confirm your email.");
                    $(".txt_confirmacorreo").attr("placeholder", "Confirm your email.");
                    $(".txt_contra").text("Password (minimum 8 characters).");
                    $(".txt_contra").attr("placeholder", "Password (minimum 8 characters).");
                    $(".txt_confirmacontra").text("Confirm your password.");
                    $(".txt_confirmacontra").attr("placeholder", "Confirm your password.");

                    $("#MainContent_Button2").val("See confidentiality notice.");
                    $("#MainContent_Button1").val("Enter");


                    break;
                case ("fr"):
                    $("#HeadLoginView_HeadLoginStatus").text("Sortie..");

                    $(".txt_correo").text("Ecrivez votre email (celui que vous utilisez le plus).");
                    $(".txt_correo").attr("placeholder", "Ecrivez votre email (celui que vous utilisez le plus).");
                    $(".txt_confirmacorreo").text("Confirmez votre email.");
                    $(".txt_confirmacorreo").attr("placeholder", "Confirmez votre email.");
                    $(".txt_contra").text("Mot de passe (minimum 8 caractères).");
                    $(".txt_contra").attr("placeholder", "Mot de passe (minimum 8 caractères).");
                    $(".txt_confirmacontra").text("Confirmer votre mot de passe.");
                    $(".txt_confirmacontra").attr("placeholder", "Confirmer votre mot de passe.");

                    $("#MainContent_Button2").val("voir avis de confidentialité.");
                    $("#MainContent_Button1").val("Entrer");

                    $("#<%= Label17.ClientID%>").text("Votre compte a été créé avec succès");
                    $("#<%= Label1.ClientID%>").text("Nous avons envoyé un message à votre adresse email, ");
                    $("#<%= Label5.ClientID%>").text("avec la ligue pour entrer sur le site INEGI");
                    $("#<%= Label6.ClientID%>").text("où vous pouvez répondre au questionnaire du recensement.");
                    $("#<%= Label4.ClientID%>").text("Important:");
                    $("#<%= Label7.ClientID%>").text("Si notre message n'apparaît pas dans votre bac");
                    $("#<%= Label8.ClientID%>").text("Entrant, s'il vous plaît vérifier le spam");
                    $("#<%= Label10.ClientID%>").text("Merci d'avoir participé.");                    
                    $("#<%= LinkButton3.ClientID %>").html("Fermer");

                    $("#<%= CompareValidator1.ClientID %>").text("Les emails sont différents.");
                    $("#<%= CompareValidator2.ClientID %>").text("Les mots de passe sont différents.");

                    $("#errorLongitud_btn_text").text("Fermer");
                    $("#errorLongitud_text").html('<p style="font-weight: bold;font-family: Arial; font-size: medium; color: black; border-style: none">ERREUR DE LONGUEUR</p> <p class="small text-justify" style="font-size:large">Le mot de passe doit comporter huit caractères ou plus.</p>');
                    break;
            }
        }

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

               // CAMBIA EL IDIOMA
                if (sessionStorage.getItem("idioma") != null) {
                    if (sessionStorage.getItem("idioma") != "es") {
                        cambiarIdioma(sessionStorage.getItem("idioma"));                        
                    }                    
                }

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
            
          

        //function mayusculas(CampoTexto) {
        //    valorNuevo = CampoTexto.value.toUpperCase()
        //    if (CampoTexto.value != valorNuevo)
        //        CampoTexto.value = valorNuevo;
        //}
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
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    <Scripts>
        <asp:ScriptReference Path="~/Scripts/myFunctions.js" />
    </Scripts>
</asp:ScriptManager>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server" >
</asp:ScriptManagerProxy>
   <script type="text/javascript">
       Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
   </script>

    <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none"/>
    <cc1:ModalPopupExtender runat="server" 
                            ID="programmaticModalPopup" 
                            BehaviorID="programmaticModalPopupBehavior"
                            TargetControlID="hiddenTargetControlForModalPopup" 
                            PopupControlID="programmaticPopup"
                            BackgroundCssClass="modalBackground" 
                            DropShadow="false" PopupDragHandleControlID="programmaticPopupDragHandle"
                            RepositionMode="RepositionOnWindowScroll" 
                            DynamicControlID="ContentUpdatePanel"
        DynamicServiceMethod="GetContent" DynamicContextKey="" 
        OnCancelScript="hideModalPopupViaClient" CancelControlID="LinkButton3" />
    <asp:Panel runat="server"  ID="programmaticPopup" Style="display: none;
        padding: 0px; top: 10% !important; " HorizontalAlign="Center" Width="450px" Height="450px">
                <%--<div style="text-align:right;"><a href="#" onclick="javascript:hideModalPopupViaClient()"><img src="Images/32x32-Cerrar.png" alt="" border="0"/></a></div>
				  <table class="form_table" style="width:100%">
				   <tr>
				    <td>Precaución: Dejo la pregunta en blanco</td>
				   </tr>
				  </table>--%>
                  <%--<div style="text-align:right;"><a href="#" onclick="javascript:hideModalPopupViaClient()"><img src="Images/32x32-Cerrar.png" alt="" border="0"/></a></div>--%>
            <div id="Div13" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; background-color:white;">
                 <%-- <div style="text-align:right;"><a href="#" onclick="javascript:hideModalPopupViaClient()"><img src="Images/32x32-Cerrar.png" alt="" border="0"/></a></div>--%>
				  <table style="border:0;width:100%;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
				   <tr>
				    <td style='text-align:center;vertical-align:top;border-top:none;'>
                            <h3 class="modal-title"><asp:label id="Label17" runat="server" Text="Su cuenta ha sido creada exitosamente" style="font-size:medium; color:black; font-family:Arial"></asp:label></td>
				   </tr>

                   <tr>
                       <td style='text-align:center;vertical-align:top;border-top:none;'>
                           <h3 class="modal-title"><asp:label id="Label1" runat="server" Text=" Hemos enviado un mensaje a su correo electrónico," style="font-size:medium; color:black; font-family:Arial"></asp:label></h3>
                       </td>
                   </tr> 

                   <tr>
                   <td style='text-align:center;vertical-align:top;border-top:none;'>
                           <h3 class="modal-title"><asp:label id="Label5" runat="server" Text=" con la liga para ingresar al sitio INEGI" style="font-size:medium; color:black; font-family:Arial"></asp:label></h3>
                   </td>
                   </tr>

                   <tr>
                   <td style='text-align:center;vertical-align:top;border-top:none;'>
                           <h3 class="modal-title"><asp:label id="Label6" runat="server" Text=" en donde podrá contestar el cuestionario del censo." style="font-size:medium; color:black; font-family:Arial"></asp:label></h3>
                       </td>
                   </tr>           

                   <tr>
                        <td style='text-align:center;vertical-align:top;border-top:none;'>
                           <h3 class="modal-title"><asp:label id="Label4" runat="server" Font-Bold="true" Text="Importante:" style="font-size:medium; color:black; font-family:Arial"></asp:label></h3>
                        </td>
                   </tr>
                   <tr>
                        <td>
                           <h3 class="modal-title"><asp:label id="Label7" runat="server" Text="Si nuestro mensaje no aparece en su bandeja " style="font-size:medium; color:black; font-family:Arial"></asp:label></h3>
                        </td>
                   </tr>
                   <tr>
                       <td>
                           <h3 class="modal-title"><asp:label id="Label8" runat="server" Text="de entrada, por favor revise la de correo no deseado." style="font-size:medium; color:black; font-family:Arial"></asp:label></h3>
                       </td>
                   </tr>                   
				   <tr>
				    <td style='text-align:center;vertical-align:top;border-top:none;'>
                        <h3 class="modal-title"><asp:label id="Label10" runat="server" Text="Gracias por estar participando" style="font-size:medium; color:black; font-family:Arial"></asp:label></td></h3>
				   </tr>
				   <tr>
				    <td style='text-align:center;vertical-align:top;border-top:none;'><asp:LinkButton ID="LinkButton3" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="LinkButton3_Click" >Cerrar</asp:LinkButton></td>
				   </tr>
				  </table>
             </div>
        
     	   <asp:UpdatePanel ID="ContentUpdatePanel" runat="server">
     	   </asp:UpdatePanel>
     </asp:Panel>
<script type="text/javascript">
function showModalPopupViaClient(){
   var modalPopupBehavior = $find('programmaticModalPopupBehavior');
   modalPopupBehavior.show();
}
function hideModalPopupViaClient() 
{
   var modalPopupBehavior = $find('programmaticModalPopupBehavior');
   modalPopupBehavior.hide();
}
</script>


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
                            <center><button type="button" class="btn btn-info" data-dismiss="modal">Aceptar</button></center>
                            
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>


<br />
<br />
<br />
<br />
    <div id="contenedor">
        <div id="hijo" >
            <div>
                <table class="table" style="width:100%; border-spacing:0px; padding:0px;  margin-bottom:0px" border="1"  >
                    <tr>
                        <td style="width:100%; background-color:white; border-bottom-color:rgb(62,120,179); border-bottom-style:ridge; border-bottom-width:4px; border-top-color:rgb(62,120,179); border-top-style:ridge; border-top-width:4px; padding-top:12px; padding-bottom:12px; border=1px">
                            <div class="row img-responsive h1 text-center " style="margin:1px">
							    <%--<img alt="Brand" src="images/database-lock1.png"/>&nbsp&nbsp CAI2020--%>
                                &nbsp;&nbsp;
                                <%--<a id="Label2" href="http://www.inegi.org.mx/" style="font-size:x-large; color:#3E78B3; font-family:Arial">Prueba de Registro de Información por Internet</a>--%>
                                &nbsp;<img alt="Crea cuenta" class="auto-style1" src="Images/Imagen_crea_cuenta_480.jpg" /><br />
							</div>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="foto" runat="server" >
                <!--<img src="imagen.aspx"  alt="captcha" id="captcha" runat="server" />-->
			    <%--<img src="Imagen2.aspx"  alt="prueba de imagen dinámica" />--%>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
            </div>
        
            <table class="table" style="width:100%;  border-spacing:0; background-color:lightgrey; padding:0;  margin-bottom:0px " border="1"  >
			    <%--<tr>
                    <td style="width:100%; text-align:center; background-color:rgb(235,236,239);  border-bottom-color:rgb(62,120,179); border-bottom-style:ridge; border-bottom-width:4px; border-top-color:rgb(62,120,179); border-top-style:ridge; border-top-width:4px; ">
                        <asp:Label ID="Label1" runat="server" Text="Primer Prueba de Autoempadronamiento por Internet" Font-Size="X-Large" ForeColor="#3E78B3" Font-Names="Arial"></asp:Label>
                    </td>
                </tr> --%>
                <tr>
                    <td  class="input-group" style="border-style: none; border-color: inherit; border-width: 0px; Width: 100%; top: 1px; left: 1px;">
                        <span class="input-group-addon" style="padding:0">
                            <!--<button type="button"  class="btn btn-default btn-sm"  id="correo">
                                <span class="glyphicon glyphicon-envelope"></span>
                            </button>-->
						    <span class="input-group-addon"><i class="glyphicon glyphicon-envelope"></i></span>
                        </span>
                        <span class="txt_correo">Escriba su correo electrónico (El que más utilice). </span>
                        
                        <asp:TextBox ID="txtcorreo"  Width="100%"  placeholder="Escriba su correo electrónico (El que más utilice)" ToolTip="Correo electrónico"  CssClass="form-control txt_correo" runat="server"  Font-Names="Arial" Font-Size="Small"></asp:TextBox>
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
                        <span class="txt_confirmacorreo"> Confirmar su correo electrónico.</span>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtcorreo" ControlToValidate="txtrepitecorreo" ErrorMessage="Los correos son diferentes." ForeColor="Red"></asp:CompareValidator>
                        &nbsp;<asp:TextBox ID="txtrepitecorreo"  Width="100%"  placeholder="Confirmar su correo electrónico." ToolTip="Confirmar su correo electrónico."  CssClass="form-control txt_confirmacorreo" runat="server"    Font-Names="Arial" Font-Size="Small"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="input-group" style="Width:100%; border:0px">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                        <span class="txt_contra">Contraseña (mínimo 8 caracteres).</span>
                        <asp:TextBox ID="txtpassword"  Width="100%"  placeholder="Contraseña (mínimo 8 caracteres)" ToolTip="Contraseña (mínimo 8 caracteres)" CssClass="form-control txt_contra" runat="server"     Font-Names="Arial" Font-Size="Small" MaxLength="18" TextMode="Password" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="input-group" style="Width:100%; border:0px">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                        <span class="txt_confirmacontra"> Confirmar contraseña. </span>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtpassword" ControlToValidate="txtcontra" ErrorMessage="Las contraseñas son diferentes." ForeColor="Red"></asp:CompareValidator>
                        &nbsp;<asp:TextBox ID="txtcontra"  Width="100%"  placeholder="Confirmar contraseña" ToolTip="Confirmar Contraseña" CssClass="form-control txt_confirmacontra" runat="server"    Font-Names="Arial" Font-Size="Small" MaxLength="18" TextMode="Password" ></asp:TextBox>
                    </td>
                </tr>
                <tr>                                 
                    <td class="input-group" style="Width:100%; border:0px">
                        <span class="input-group-addon"></span>                                        
                        <asp:HyperLink runat="server" id="HyperLink1" NavigateURL="Confidencialidad.html" Target="_blank" Visible="False">Ver aviso de confidencialidad</asp:HyperLink>    
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Text="Ver aviso de confidencialidad." />
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
                </tr>  --%>    
            </table>
        </div>



            <div id="vmodal_error" class = "modal fade"  runat="server">
                <div id="mensaje_error" class="alert alert-danger"  runat="server"></div>
            </div>

		    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
            <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
            <!-- Include all compiled plugins (below), or include individual files as needed -->
            <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>
          
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


          <div class="modal fade" id="errorLongitug" >
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body" id="errorLongitud_text">
                            <p style="font-weight: bold;font-family: Arial; font-size: medium; color: black; border-style: none">ERROR DE LONGITUD</p>
                             <p class="small text-justify" style="font-size:large">La contraseña debe ser de ocho o más caracteres.</p>
                        </div>
                        <div class="modal-footer">
                            <center><button type="button" class="btn btn-info" data-dismiss="modal" id="errorLongitud_btn_text">
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
                <div id="message"><img src="Images/cargando.gif"/></div>
            </ProgressTemplate>
        </asp:UpdateProgress>--%>


</asp:Content>
