<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="CuestionarioPersona.aspx.cs" Inherits="Cai2020.CuestionarioPersona" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <script type="text/javascript">
        $(function () {
            $("form").keypress(function (e) {
                //Enter key
                if (e.which == 13) {
                    return false;
                }
            });
        });
    </script>
     <script type="text/javascript">
        $(function () {
            $('#exampleModal').on('show.bs.modal', function (event) {
                var button = $(event.relatedTarget) // Button that triggered the modal
                var recipient = button.data('whatever') // Extract info from data-* attributes
                // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
                // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
                var modal = $(this)
                modal.find('.modal-title').text('New message to ' + recipient)
                modal.find('.modal-body input').val(recipient)
            })
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('[data-toggle="popover"]').popover();
            //ensalamos los valores de la variables oculta para que se pueda redirigir
            //var url = $("#RedirectTo").val();
            //var url2 = $("#RedirectTo2").val();

            var ulttr=0;
            var tot_reg;
            var input_estacion = $("#MainContent_tb_IIe11");
            //input_estacion.focus();//ponemos el foco al campo de estacion al cargar la pagina

            // Clona la fila oculta que tiene los campos base, y la agrega al final de la tabla
            //$("#agregar").on('click', function () {
            //    $("#tabla tbody tr:eq(0)").clone().removeClass('fila-base').appendTo("#tabla tbody");
            //});
            //$("#parentesco").change(function () {
            //    var valor = $("#parentesco option:selected").html();
            //    alert(valor);
            //    if (valor==="otro")
            //    {
            //        $("#Otros").show();
            //    }
            //});
            
            //var valor = $("#parentesco option:selected").html();

            //$("#add").click(function () {
            $("#add").click(function () {
                if (input_estacion.val() != "" && input_estacion.val() != "0") {
                    var divsec005 = document.getElementById('Sec005');
                    divsec005.style.display = 'inline';
                    //var tds = $("#tabla tr:first td").length;
                    //var trs = $("#tabla tr").length;

                    var parent = $("#tabla tbody tr");
                    //$(parent).empty();
                    $(parent).remove();
                    tot_reg = $("#tabla tbody tr").length;
                    ulttr = 0;
                    for (var i = 0; i < +input_estacion.val() ; i++) {
                        
                        var nuevaFila = "<tr>";
                        nuevaFila += " <td width='5%' align='center'><input name='MyRadioButton' type='radio' /></td>";
                        if (ulttr > tot_reg) {
                            //nuevaFila += "<td width='5%' align='center'><label class='lbid' style='font-size:large;font-family:Arial;' id='Id" + (+ulttr + 1) + "'/>" + (+ulttr + 1) + "</td>";
                            nuevaFila += "<td width='5%' align='center'><label class='lbid' style='font-size:large;font-family:Arial;' id='Id" + (+ulttr + 1) + "'/></td>";
                            ulttr = +ulttr + 1;
                        }
                        else {
                            //nuevaFila += "<td width='5%' align='center'><label class='lbid' style='font-size:large;font-family:Arial;' id='Id" + (+tot_reg + 1) + "'/>" + (+tot_reg + 1) + "</td>";
                            nuevaFila += "<td width='5%' align='center'><label class='lbid' style='font-size:large;font-family:Arial;' id='Id" + (+tot_reg + 1) + "'/></td>";
                            ulttr = +tot_reg + 1;
                        }
                        nuevaFila += " <td width='35%' align='center'><input type='text' id='Nombre' maxlength='50' class='form-control' style='font-size:medium;font-family:Arial;'/></td>";
                        nuevaFila += " <td width='10%' align='center'><select  class='selsex' id='sexo" + ulttr + "' style='font-size:medium;font-family:Arial;'><option value='inicio'>Sexo</option><option value='hombre'>Hombre</option><option value='mujer'>Mujer</option></select></td>";
                        nuevaFila += " <td width='10%' align='center'><input type='text' id='Edad' maxlength='3' class='form-control' style='font-size:medium;font-family:Arial;'/></td>";
                        nuevaFila += " <td width='15%' align='center'><select  class='selparen' id='parentesco" + ulttr + "' style='font-size:medium;font-family:Arial;'><option value='jefe'>Jefa(e)</option><option value='esposo'>Esposa(o) o pareja</option>";
                        nuevaFila += " <option value='hijo'>Hija(o)</option><option value='nieto'>Nieta(o)</option><option value='yerno'>Nuera o yerno</option><option value='padre'>Madre o padre</option>";
                        nuevaFila += " <option value='suegro'>Suegra (o)</option><option value='sinparentesco'>Sin parentesco</option><option value='otro'>Otro (especifique)</option>";
                        nuevaFila += " </select><input type='text' id='Otros" + ulttr + "' maxlength='50'  class='form-control'  style='font-size:medium;font-family:Arial;display:none; '/></td>";
                        nuevaFila += " <td width='20%' align='center' id='eliminarreg'><button type='button' id='eliminar' class='btn btn-danger'>Eliminar</button></td>";
                        nuevaFila += "</tr>";
                        $("#tabla tbody").append(nuevaFila);
                    }
                    $("input:text:eq(1):visible").focus();//poner el foco en el input que se agrego
                    var botadd = document.getElementById('add');
                    botadd.style.display = 'none';
                    var botagregar = document.getElementById('agregaotro');
                    botagregar.style.display = '';
                    var l=1;
                    $("label[class='lbid']").each(function () {
                        $(this).html(l);
                        ++l;
                    });
                }
                else {
                    $("#mensaje_error").html("¡El No. de personas tiene que ser mayor a 0!");
                    $("#vmodal_error").modal();
                }
            });

            $("#agregaotro").click(function () {
                 if (input_estacion.val() != "" && input_estacion.val() != "0") {
                    //var tds = $("#tabla tr:first td").length;
                    //var trs = $("#tabla tr").length;
                     tot_reg = $("#tabla tbody tr").length;
                        var nuevaFila = "<tr>";
                        nuevaFila += " <td width='5%' align='center'><input name='MyRadioButton' type='radio' /></td>";
                        if (ulttr > tot_reg) {
                            //nuevaFila += "<td width='5%' align='center'><label class='lbid' style='font-size:large;font-family:Arial;' id='Id" + (+ulttr + 1) + "'/>" + (+ulttr + 1) + "</td>";
                            nuevaFila += "<td width='5%' align='center'><label class='lbid' style='font-size:large;font-family:Arial;' id='Id" + (+ulttr + 1) + "'/></td>";
                            ulttr = +ulttr + 1;
                        }
                        else {
                            //nuevaFila += "<td width='5%' align='center'><label class='lbid' style='font-size:large;font-family:Arial;' id='Id" + (+tot_reg + 1) + "'/>" + (+tot_reg + 1) + "</td>";
                            nuevaFila += "<td width='5%' align='center'><label class='lbid' style='font-size:large;font-family:Arial;' id='Id" + (+tot_reg + 1) + "'/></td>";
                            ulttr = +tot_reg + 1;
                        }
                        nuevaFila += " <td width='35%' align='center'><input type='text' id='Nombre' maxlength='50' class='form-control' style='font-size:medium;font-family:Arial;'/></td>";
                        nuevaFila += " <td width='10%' align='center'><select class='selsex' id='sexo" + ulttr + "' style='font-size:medium;font-family:Arial;'><option value='inicio'>Sexo</option><option value='hombre'>Hombre</option><option value='mujer'>Mujer</option></select></td>";
                        nuevaFila += " <td width='10%' align='center'><input type='text' id='Edad' maxlength='3' class='form-control' style='font-size:medium;font-family:Arial;'/></td>";
                        nuevaFila += " <td width='15%' align='center'><select class='selparen' id='parentesco" + ulttr + "' style='font-size:medium;font-family:Arial;'><option value='jefe'>Jefa(e)</option><option value='esposo'>Esposa(o) o pareja</option>";
                        nuevaFila += " <option value='hijo'>Hija(o)</option><option value='nieto'>Nieta(o)</option><option value='yerno'>Nuera o yerno</option><option value='padre'>Madre o padre</option>";
                        nuevaFila += " <option value='suegro'>Suegra (o)</option><option value='sinparentesco'>Sin parentesco</option><option value='otro'>Otro (especifique)</option>";
                        nuevaFila += " </select><input type='text' id='Otros" + ulttr + "' maxlength='50'  class='form-control'  style='font-size:medium;font-family:Arial; display:none; '/></td>";
                        nuevaFila += " <td width='20%' align='center' id='eliminarreg'><button type='button' id='eliminar' class='btn btn-danger'>Eliminar</button></td>";
                        nuevaFila += "</tr>";
                        $("#tabla tbody").append(nuevaFila);
                        $("input:text:eq(" + ((+tot_reg * 3) + 1) + "):visible").focus();//poner el foco en el input que se agrego
                        input_estacion.val($("#tabla tbody tr").length);
                        var l = 1;
                        $("label[class='lbid']").each(function () {
                            $(this).html(l);
                            ++l;
                        });
                }
                else {
                    $("#mensaje_error").html("¡El No. de personas tiene que ser mayor a 0!");
                    $("#vmodal_error").modal();
                }
            });

           
            //var valor = $(".selparen option:selected").html();
            //$(".selparen").change(function () {
            //$(".selparen").on("change", function () {
            //revisa si hay cambio en el div en en el combo de parentesco
            $("#Sec005").on("change", ".selparen", function () {
                var n = 1;
                $("select[class='selparen']").each(function () {
                    if ($("#parentesco" + (+n)).val() === 'otro')
                    {
                        $("#Otros" + (+n)).css('display', 'inline');
                        //$("#Otros" + (+n)).css('visibility', 'visible');
                        $("#Otros" + (+n)).focus();
                    }
                    else
                    {
                        $("#Otros" + (+n)).css('display', 'none');
                    }
                    //alert($("#sexo1").val());
                    //var valor = $("#sexo1 option:selected").html();
                    ++n;
                });
            });


            // Evento que selecciona la fila y la elimina el renglon de la tabla
            $(document).on("click", "#eliminar", function () {
                if ($("#tabla tbody tr").length > 1) {
                    var parent = $(this).parents("#eliminarreg").parents().get(0);
                    $(parent).remove();
                    $("input:text:eq(1):visible").focus();//mandamos el foco al primer input de la tabla de piezas
                    var quedan= $("#tabla tbody tr").length;
                    input_estacion.val(quedan);
                    var x = 1;
                    $("label[class='lbid']").each(function () {
                        $(this).html(x);
                        ++x;
                    });

                }
            });

            $("#btn_lanzarc").click(function () {
                var data = [];
                var tot_vacios = 0;
                var tot_camp = 0;
                alert("entro");
                $("input[id='Nombre']").each(function () {
                    if ($(this).val() != "") {
                        //data.push({ nombrePersona: $(this).val() });
                        data.push("persona" + tot_camp);
                    }
                    else
                    { tot_vacios++; }
                    ++tot_camp;
                });
                $.ajax(
                            {
                                type: "POST", //HTTP POST Method
                                url: "/CuestionarioPersona.aspx/guardarPersona", // Controller/View
                                data: {
                                    persona: data//leyendo los valores del text box usando Jquery
                                },
                                datatype: 'json',
                                ContentType: 'application/json;utf-8'
                            }).done(function (resp) {
                                $("#vmodal").modal();
                            }).error(function (err) {
                                $("#mensaje_error").html("Error " + err.status);
                                $("#vmodal_error").modal();
                            });
            });

            //function will be called on button click having id btnsave
            $("#Btn_guardar").click(function () {
                var $btn = $(this).button('loading');// lo usamos para dar el efecto de "Guardando..." en el boton
                var data = [];
                var tot_vacios = 0;
                var tot_camp = 0;
                //recorremos todos los checkbox seleccionados con .each
                $("input[id='NombredePieza']").each(function () {
                    if ($(this).val() != "") {
                        data.push({ NombreDePieza: $(this).val() });
                    }
                    else
                    { tot_vacios++; }
                    ++tot_camp;
                });
                //if (tot_camp > tot_vacios) {
                if (input_estacion.val() != "") {
                    if (+tot_vacios === 0) {
                        if (tot_camp > 0) {
                            var reques = $.ajax(
                            {
                                type: "POST", //HTTP POST Method
                                url: "/Estacion/AddEstacion", // Controller/View
                                data: {
                                    Nombre: $("#TB_estacion").val(), //leyendo los valores del text box usando Jquery
                                    Piezas: data
                                },
                                datatype: 'json',
                                ContentType: 'application/json;utf-8'
                            }).done(function (resp) {
                                $("#vmodal").modal();
                            }).error(function (err) {
                                $("#mensaje_error").html("Error " + err.status);
                                $("#vmodal_error").modal();
                            });
                        }//fin del if de tot_camp
                        else {
                            $("#mensaje_error").html("No se han registrado <b>Piezas</b> para la Estación: <b>" + input_estacion.val() + "</b>");
                            $("#vmodal_error").modal();
                        }
                    }//fin del if de tot_vacios
                    else {
                        $("#mensaje_error").html("Hay un(os) renglon(es) sin <b>Nombre de Pieza</b> para la Estación: <b>" + input_estacion.val() + "</b></br>Llene los campos o elimine los renglones vacios e intente guardar de nuevo");
                        $("#vmodal_error").modal();
                    }
                }//fin del primer if
                else
                {
                    $("#mensaje_error").html("¡El Campo <b>Estación</b> es obligatorio!");
                    $("#vmodal_error").modal();
                }
                $btn.button('reset');//para que ya no muestro lo de "Guardando......"
              });


                //funciones de las opciones de la ventana modal
                $("#aceptar").on("click", function () {//se redirecciona a la misma pagina
                    location.href = url2;
                });

                $("#salir").on("click", function () {//se redirecciona a la pagina de inicio
                    location.href = url;
                });

        });

    </script>
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
   <%-- <script type="text/javascript">
        var bPreguntar = true;
        window.onbeforeunload = preguntarAntesDeSalir;
        function preguntarAntesDeSalir()
        {
        if (bPreguntar)
            return "¿Está seguro de abandonar la aplicación?";
        }
    </script>--%>
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
        function soloNumeros1(CampoTexto) {
            valorNuevo = "";
            for (x = 0; x < CampoTexto.value.length; x++) {
                c = CampoTexto.value.charAt(x);
                if (("1" <= c && c <= "9"))
                    valorNuevo += c;
            }
            if (CampoTexto.value != valorNuevo)
                CampoTexto.value = valorNuevo;
        }
     function RadioCheck(rb) {
        var gv = document.getElementById("<%=GridView1.ClientID%>");
        var rbs = gv.getElementsByTagName("input");
        var row = rb.parentNode.parentNode;
        for (var i = 0; i < rbs.length; i++) {
            if (rbs[i].type == "radio") {
                if (rbs[i].checked && rbs[i] != rb) {
                    rbs[i].checked = false;
                    break;
                }
            }
        }
    }

</script>
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
.ChkBoxClass input {width:16px; height:16px;}
.Imagen {
        display: block;
        margin: 0 auto;
        width: 86%;
        /*height: 50%;*/
}
</style>
    <br />
    <br />
    <br />
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
        OnCancelScript="hideModalPopupViaClient" CancelControlID="LinkButton6" />
    <asp:Panel runat="server"  ID="programmaticPopup" Style="display: none;
        padding: 0px; top: 10% !important; " HorizontalAlign="Center" Width="450px" Height="250px">
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
                       <td>
                           <br />
                       </td>
                   </tr>
				   <tr>
				    <td style='text-align:center;vertical-align:top;border-top:none;'><h2 class="modal-title"><asp:label id="Label17" runat="server" Text="¡Precaución!"></asp:label></h2></td>
				   </tr>
                   <tr>
                       <td>
                           <br />
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <br />
                       </td>
                   </tr>
				   <tr>
				    <td style='text-align:center;vertical-align:top;border-top:none;'><asp:label id="Label10" runat="server" Text="Dejó la pregunta en blanco." style="font-size:large; color:black; font-family:Arial"></asp:label></td>
				   </tr>
                   <tr>
                       <td>
                           <br />
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <br />
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <br />
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <br />
                       </td>
                   </tr>
				   <tr>
				    <td style='text-align:center;vertical-align:top;border-top:none;'><asp:LinkButton ID="LinkButton6" runat="server" Text="" CssClass="btn btn-default btn-sm" >Cerrar</asp:LinkButton></td>
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
    <asp:Button runat="server" ID="hiddenTargetControlForModalPopup2" Style="display: none"/>
    <cc1:ModalPopupExtender runat="server" 
                            ID="programmaticModalPopup2" 
                            BehaviorID="programmaticModalPopupBehavior2"
                            TargetControlID="hiddenTargetControlForModalPopup2" 
                            PopupControlID="programmaticPopup2"
                            BackgroundCssClass="modalBackground" 
                            DropShadow="false" PopupDragHandleControlID="programmaticPopupDragHandle2"
                            RepositionMode="RepositionOnWindowScroll" 
                            DynamicControlID="ContentUpdatePanel2"
        DynamicServiceMethod="GetContent2" DynamicContextKey="" 
        OnCancelScript="hideModalPopupViaClient2" CancelControlID="LinkButton13" />
            <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup2" Style="display: none;
                padding: 0px; background-color:white;border:1px solid #666; " HorizontalAlign="Justify" Width="80%" Height="60%" ScrollBars="Auto" >
                <%-- top: 10% !important;--%>
                <div id="Div200" runat="server" visible="true" style="height:100%; width:100%;">
                  <div style="text-align:right;"><a href="#" onclick="javascript:hideModalPopupViaClient2()"><img src="Images/32x32-Cerrar.png" alt="" border="0"/></a></div>
				  <table style="border:0;width:100%;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
				   <tr>
				    <td style='text-align:center;vertical-align:top;border-top:none;width:100%;'><asp:Image ID="Image1" CssClass="Imagen" runat="server"/><%--<a title="Residente habitual" href="ImagenResidente.html" target="_blank"><asp:Image ID="Image1" CssClass="Imagen" runat="server"/></a>--%><%--<asp:LinkButton ID="LinkButton1" runat="server" Text="" CssClass="btn btn-default btn-sm" >Cerrar</asp:LinkButton>--%></td>
				   </tr>
				   <tr>
				    <td style='text-align:center;vertical-align:top;border-top:none;'><asp:LinkButton ID="LinkButton13" runat="server" Text="" CssClass="btn btn-default btn-sm" >Cerrar ayuda</asp:LinkButton></td>
				   </tr>
				  </table>
                    <%--<img alt="Brand" src="Images/Cortinilla1.JPG"/>--%>
                </div>
     	           <asp:UpdatePanel ID="ContentUpdatePanel2" runat="server">
     	           </asp:UpdatePanel>
            </asp:Panel>
<script type="text/javascript">
function showModalPopupViaClient2() {
   var modalPopupBehavior2 = $find('programmaticModalPopupBehavior2');
   modalPopupBehavior2.show();
}
function hideModalPopupViaClient2() 
{
   var modalPopupBehavior2 = $find('programmaticModalPopupBehavior2');
   modalPopupBehavior2.hide();
}
function myfunction1()
{
    setTimeout(function () { hideModalPopupViaClient2(); }, 5000);
}
</script>
    <asp:Button runat="server" ID="hiddenTargetControlForModalPopup3" Style="display: none"/>
    <cc1:ModalPopupExtender runat="server" 
                            ID="programmaticModalPopup3" 
                            BehaviorID="programmaticModalPopupBehavior3"
                            TargetControlID="hiddenTargetControlForModalPopup3" 
                            PopupControlID="programmaticPopup3"
                            BackgroundCssClass="modalBackground" 
                            DropShadow="false" PopupDragHandleControlID="programmaticPopupDragHandle3"
                            RepositionMode="RepositionOnWindowScroll" 
                            DynamicControlID="ContentUpdatePanel3"
        DynamicServiceMethod="GetContent3" DynamicContextKey="" 
        OnCancelScript="hideModalPopupViaClient3" CancelControlID="LinkButton14" />
            <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup3" Style="display: none;
                padding: 0px;  " HorizontalAlign="Justify" Width="100%" Height="100%" ScrollBars="Auto" >
                <%-- top: 10% !important;--%>
				  <table style="border:0;width:100%;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
				   <tr>
				    <td style='text-align:center;vertical-align:top;border-top:none;' colspan="3"><asp:Image ID="Image2" CssClass="Imagen" runat="server"/><%--<asp:LinkButton ID="LinkButton1" runat="server" Text="" CssClass="btn btn-default btn-sm" >Cerrar</asp:LinkButton>--%></td>
				   </tr>
				   <tr>
                       <td style='width:7%;'>

                       </td>
				    <td style='text-align:center;vertical-align:top;border-top:none;border-bottom:none; background-image:url("Images/Cortinilla3B.JPG"); width:86%;'><br /></td>
                       <td style='width:7%;'>

                       </td>
				   </tr>
				   <tr>
                       <td style='width:7%;'>

                       </td>
				    <td style='text-align:center;vertical-align:top;border-top:none;border-bottom:none; background-image:url("Images/Cortinilla3B.JPG"); width:86%;'><br /></td>
                       <td style='width:7%;'>

                       </td>
				   </tr>
				   <tr>
                       <td style='width:7%;'>

                       </td>
				    <td style='text-align:center;vertical-align:top;border-top:none;border-bottom:none; background-image:url("Images/Cortinilla3B.JPG"); width:86%;'><br /></td>
                       <td style='width:7%;'>

                       </td>
				   </tr>
				   <tr>
                       <td style='width:7%;'>

                       </td>
				    <td style='text-align:center;vertical-align:top;border-top:none;border-bottom:none; background-image:url("Images/Cortinilla3B.JPG"); width:86%;'><asp:label id="Label20" runat="server" Text="Persona" style='font-size:x-large; color:darkblue; font-family:Arial;'></asp:label></td>
                       <td style='width:7%;'>

                       </td>
				   </tr>
				   <tr>
                       <td style='width:7%;'>

                       </td>
				    <td style='text-align:center;vertical-align:top;border-top:none;border-bottom:none; background-image:url("Images/Cortinilla3B.JPG"); width:86%;'><br /></td>
                       <td style='width:7%;'>

                       </td>
				   </tr>
				   <tr>
                       <td style='width:7%;'>

                       </td>
				    <td style='text-align:center;vertical-align:top;border-top:none;border-bottom:none; background-image:url("Images/Cortinilla3B.JPG"); width:86%;'><br /></td>
                       <td style='width:7%;'>

                       </td>
				   </tr>
				   <tr>
                       <td style='width:7%;'>

                       </td>
				    <td style='text-align:center;vertical-align:top;border-top:none;border-bottom:none; background-image:url("Images/Cortinilla3B.JPG"); width:86%;'><br /></td>
                       <td style='width:7%;'>

                       </td>
				   </tr>
				   <tr>
                       <td style='width:7%;'>

                       </td>
				    <td style='text-align:center;vertical-align:top;border-top:none;border-bottom:none; background-image:url("Images/Cortinilla3B.JPG"); width:86%;'><br /></td>
                       <td style='width:7%;'>

                       </td>
				   </tr>
				   <tr>
                       <td style='width:7%;'>

                       </td>
				    <td style='text-align:center;vertical-align:top;border-top:none;border-bottom:none; background-image:url("Images/Cortinilla3B.JPG"); width:86%;'><br /></td>
                       <td style='width:7%;'>

                       </td>
				   </tr>
				   <tr>
				    <td style='text-align:center;vertical-align:top;border-top:none;' colspan="3"><asp:LinkButton ID="LinkButton14" runat="server" Text="" CssClass="btn btn-default btn-sm" >Continuar</asp:LinkButton></td>
				   </tr>
				  </table>
                    <%--<img alt="Brand" src="Images/Cortinilla1.JPG"/>--%>
     	           <asp:UpdatePanel ID="ContentUpdatePanel3" runat="server">
     	           </asp:UpdatePanel>
            </asp:Panel>
<script type="text/javascript">
    function showModalPopupViaClient3() {
        //fondo1 = document.getElementById("programmaticPopup2");
        //fondo1.style.left = "250px";
        //alert();
   var modalPopupBehavior3 = $find('programmaticModalPopupBehavior3');
   modalPopupBehavior3.show();
}
function hideModalPopupViaClient3() 
{
   var modalPopupBehavior3 = $find('programmaticModalPopupBehavior3');
   modalPopupBehavior3.hide();
}
</script>
<div id="contenedor">
   <div class="container-fluid">
    <div id="Sec001" class="row">
        <div id="Sec002" class="col-sm-12" style="display:none;">
            <div id="Div1" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; background-color:lightgray;">
                    <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                    <tr>
                        <td style="align-content:center; align-items:center; text-align:center; vertical-align:top; width:100%;" >
                            <table style="width:100%;">
                                <tr>
                                    <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                                            <%--<asp:Label ID="Label1" runat="server" Text="SECCIÓN: II. LISTA DE PERSONAS" Font-Size="X-Large" ForeColor="CadetBlue" Font-Names="Arial"></asp:Label>--%>
                                            <asp:Label ID="Label1" runat="server" Text="SECCIÓN II. LISTA DE PERSONAS Y DATOS GENERALES" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    </td>
 	               	                <td style="text-align:left; vertical-align:top; width:45%">
                                       <div id="barraavance2" >
                                            <table id="barras" style="width:100%; height:33px" border="0" >
                                                <tr>
                                                    <td style="width:69%; vertical-align:text-top; padding:0px;">
                                                        <div class="progress" style="margin:0">
                                                          <div id="barra1" runat="server" class="progress-bar progress-bar-custom2" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax ="100" ></div>
                                                        </div>
                                                    </td>
                                                    <td style="width:2%; vertical-align:text-top; padding:0px;"></td>
                                                    <td style="width:29%; vertical-align:text-top; padding:0px; ">
                                                        <asp:label id="avance1" runat="server" style="font-size:smaller; color:#3E78B3; font-family:Arial"></asp:label>
                                                    </td>
                                                </tr>
                                            </table>
                                      </div>
                                    </td>
                                    <td style='text-align:right;vertical-align:top;border-top:none;width:5%;'>
                                       <%--<asp:LinkButton ID="ayuda01" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="ayuda01_Click"><img src="images/16x16-Info.png" alt="" /></asp:LinkButton>--%>
                                        <%--data-trigger="focus"--%>
                                        <button type="button" id="ayuda01" runat="server" style="border:none;background-color:transparent;"
                                               data-html="true" 
                                               data-toggle="popover" 
                                               data-placement="bottom"
                                               title="<b>Ayuda</b>" 
                                               data-content="Some content">
                                               <img src="images/informacion30.png" alt="" style="border:none; background:none;"/>
                                        </button>
                                        <%--<button type="button" id="ayuda01" runat="server" style="border:none;background-color:transparent;" onclick="showModalPopupViaClient2()" title="Ayuda">
                                               <img src="images/informacion30.png" alt="" style="border:none; background:transparent;"/>
                                        </button>--%>
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
                    </table>
            </div>
        </div>
                            <%--<asp:LinkButton ID="btnExample" runat="server" Text="<i class='glyphicon glyphicon-circle-arrow-right'></i> " CssClass="btn btn-primary btn-xs" ></asp:LinkButton>--%>
                            <%--<asp:Button ID="Button1" runat="server" Text="<i class='glyphicon glyphicon-circle-arrow-right'></i>" CssClass="btn btn-primary btn-xs" Height="25px" onclick="Button1_Click"/>--%>

        <div id="Sec003" class="col-sm-12" style="display:none;">
           <div id="Div2" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="3">
                        <%--<asp:Label ID="lb_IIe1e" runat="server" Text="¿Cuántas son las personas que viven aquí?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>--%>
                        <asp:Label ID="lb_IIe1e" runat="server" Text="¿Cuántas personas viven normalmente en su vivienda? Incluya a las niñas y niños chiquitos y a las personas ancianas, considere también al personal doméstico que duerme en la misma." Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:90%;'>
                                    <asp:TextBox ID="tb_IIe11" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>
                                    
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:90%;'>
                                    <asp:Label ID="lb_IIe11" runat="server" Text="NÚMERO DE PERSONAS" Font-Names="Arial" Font-Size="X-Small" ForeColor="Gray" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                    <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="3">
                        <%--OnClick="agregar01a_Click" data-whatever="@mdo" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal"--%>
                        <asp:LinkButton ID="siguienteini1" OnClick="agregar01b2_Click" runat="server" Text="" CssClass="btn btn-default btn-sm" >Siguiente&nbsp;<img src="images/16x16-Siguiente.png" alt="" /></asp:LinkButton>
                        <%--<asp:LinkButton ID="agregar01a" OnClick="agregar01a_Click" runat="server" Text="" CssClass="btn btn-default btn-sm" >Agregar persona&nbsp;<img src="images/32x32-AgregarPersona.png" alt="" /></asp:LinkButton>--%>
                        <%--<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal" data-whatever="@mdo">Open modal for @mdo</button>--%>

                        <%--<button type="button" id="add" class="btn btn-info">Siguiente&nbsp;<img src="images/16x16-Siguiente.png" alt="" /></button>--%>
                        <%--<button type="button" id="agregaotro" class="btn btn-info" style="display:none;">Agregar otro&nbsp;<img src="images/16x16-Siguiente.png" alt="" /></button>--%>
                    </td>
                </tr>
                
               </table>
           </div>
        </div>
        <div id="Sec003a" class="col-sm-12" style="display:none;">
           <div id="Div7" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
<%--                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="3">
                        <asp:Label ID="Label5" runat="server" Text="SE RECOMIENDA LEER LOS TEXTOS DE AYUDA IMPLEMENTADOS PARA ESTA SECCIÓN ANTES DE INICIAR CON SU LLENADO." Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>--%>
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="3">
                        <asp:Label ID="Label7" runat="server" Text="Por favor continúe registrando los datos (nombre, sexo, edad y parentesco) de todas las personas que viven normalmente en la vivienda (residentes habituales), incluya a las niñas y niños chiquitos y a las personas ancianas, considere también al personal doméstico que duerme en la misma." Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                        <%--Por favor registre los datos  (nombre, sexo , edad y parentesco) de todas las personas que viven normalmente en la vivienda (residentes habituales), incluya a las niñas y niños chiquitos y a las personas ancianas. Considere también al personal doméstico que duerme aquí e inicie el registro con la persona identificada como jefa o jefe de la vivienda.--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="3">
                        <asp:LinkButton ID="siguienteini" OnClick="agregar01b_Click" runat="server" Text="" CssClass="btn btn-default btn-sm" >Siguiente&nbsp;<img src="images/16x16-Siguiente.png" alt="" /></asp:LinkButton>
                        <asp:LinkButton ID="agregar01a" OnClick="agregar01a_Click" runat="server" Text="" CssClass="btn btn-default btn-sm" >Agregar persona&nbsp;<img src="images/32x32-AgregarPersona.png" alt="" /></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton3" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="LinkButton3bis_Click" >Finalizar lista y continuar&nbsp;<img src="images/32x32-Siguiente.png" alt="" /></asp:LinkButton>
                    </td>
                </tr>
                
               </table>
           </div>
        </div>        

<%--<div class="modal fade" id="exampleModal" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
    <div class="modal-content">
        <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">New message</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
        </div>
        <div class="modal-body">
                <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="lb_IIe2e" runat="server" Text="Por favor, capture los datos de todas las personas que viven normalmente en esta vivienda, incluya a las niñas y niños chiquitos y a las personas ancianas. También al personal doméstico que duerme aquí" Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:Left;vertical-align:top;border-top:none;width:20%;'>
                                    <asp:Label ID="lb_IIe21" runat="server" Text="Nombre" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:TextBox ID="tb_IIe21" runat="server" MaxLength="50" Width="100%" Font-Names="Arial" Font-Size="medium" onkeyup="soloLetrasY(this,' ');mayusculas(this);"></asp:TextBox>
                                    <asp:Label ID="lb_IIe21a" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Red" BorderStyle="None"></asp:Label>
                                </td>
                </tr>
                <tr>
                                <td style='text-align:Left;vertical-align:top;border-top:none;width:20%;'>
                                    <asp:Label ID="lb_IIe22" runat="server" Text="Sexo" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                        <asp:Label ID="lb_IIe221" runat="server" Text="Hombre" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioA1" GroupName="radioA" AutoPostBack="False"/>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lb_IIe222" runat="server" Text="Mujer" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioA2" GroupName="radioA" AutoPostBack="False"/>
                                    <asp:Label ID="lb_IIe22a" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Red" BorderStyle="None"></asp:Label>
                                </td>
                </tr>
                <tr>
                                <td style='text-align:Left;vertical-align:top;border-top:none;width:20%;'>
                                    <asp:Label ID="lb_IIe23" runat="server" Text="Edad" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:TextBox ID="tb_IIe23" runat="server" MaxLength="3" Width="36px" Font-Names="Arial" Font-Size="medium" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>
                                    <asp:Label ID="lb_IIe23a" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Red" BorderStyle="None"></asp:Label>
                                </td>
                </tr>
                <tr>
                                <td style='text-align:Left;vertical-align:top;border-top:none;width:20%;'>
                                    <asp:Label ID="lb_IIe24" runat="server" Text="Parentesco" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:Label ID="lb_IIe24a" runat="server" Text="Parentesco" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                        <asp:Label ID="lb_IIe241" runat="server" Text="Jefa(e)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB1" GroupName="radioB" AutoPostBack="False"/><br />
                                    <asp:Label ID="lb_IIe242" runat="server" Text="Esposa(o) o pareja" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB2" GroupName="radioB" AutoPostBack="False"/><br />
                                    <asp:Label ID="lb_IIe243" runat="server" Text="Hija(o)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB3" GroupName="radioB" AutoPostBack="False"/><br />
                                    <asp:Label ID="lb_IIe244" runat="server" Text="Nieta(o)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB4" GroupName="radioB" AutoPostBack="False"/><br />
                                    <asp:Label ID="lb_IIe245" runat="server" Text="Nuera o yerno" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB5" GroupName="radioB" AutoPostBack="False"/><br />
                                    <asp:Label ID="lb_IIe246" runat="server" Text="Madre o padre" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB6" GroupName="radioB" AutoPostBack="False"/><br />
                                    <asp:Label ID="lb_IIe247" runat="server" Text="Suegra (o)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB7" GroupName="radioB" AutoPostBack="False"/><br />
                                    <asp:Label ID="lb_IIe248" runat="server" Text="Sin parentesco" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB8" GroupName="radioB" AutoPostBack="False"/><br />
                                    <asp:Label ID="lb_IIe249" runat="server" Text="Otro (especifique)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB9" GroupName="radioB" AutoPostBack="False"/>
                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:TextBox ID="tb_IIe24" runat="server" MaxLength="50" Width="100%" Font-Names="Arial" Font-Size="Small" onkeyup="soloLetrasY(this);calle(this);"></asp:TextBox>
                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="3">
                                    <asp:LinkButton ID="agregar01" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="agregar01_Click" ><img src="images/add2-32.png" alt="" />&nbsp;Agregar persona</asp:LinkButton>
                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="Guardar_todo" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Guardar_todo_Click" ><img src="images/32x32-Guardar.png" alt="" />&nbsp;Guardar y regresar a vivienda</asp:LinkButton>
                                </td>
                </tr>
                </table>
        </div>
        <div class="modal-footer">
        <asp:LinkButton ID="LinkButton1" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="agregar01_Click" class="btn btn-primary" ><img src="images/add2-32.png" alt="" />&nbsp;Agregar persona</asp:LinkButton>
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Send message</button>
        </div>
    </div>
    </div>
</div>--%>

        <div id="Sec004" class="col-sm-12" style="display:none;">
           <div id="Div3" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="lb_IIe2e" runat="server" Text="Por favor, registre los datos (nombre, sexo y edad) de la(el) jefa(e) de la vivienda" Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:Left;vertical-align:top;border-top:none;width:35%;'>
                                    <asp:Label ID="lb_IIe21" runat="server" Text="¿Cuál es el nombre de la(el) jefa(e)?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:65%;'>
                                    <asp:TextBox ID="tb_IIe21" runat="server" MaxLength="50" Width="100%" Font-Names="Arial" Font-Size="medium" onkeyup="soloLetrasY(this,' ');mayusculas(this);"></asp:TextBox>
                                </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:Left;vertical-align:top;border-top:none;width:35%;'>
                                    <asp:Label ID="lb_IIe22" runat="server" Text="La(el) jefa(e) es:" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:65%;'>
                                    <asp:RadioButton runat="server" id="radioA1" GroupName="radioA" AutoPostBack="False"/>&nbsp;<asp:Label ID="lb_IIe221" runat="server" Text="Hombre" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton runat="server" id="radioA2" GroupName="radioA" AutoPostBack="False"/>&nbsp;<asp:Label ID="lb_IIe222" runat="server" Text="Mujer" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:Left;vertical-align:top;border-top:none;width:35%;'>
                                    <asp:Label ID="lb_IIe23" runat="server" Text="¿Cuántos años cumplidos tiene la(el) jefa(e)?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:65%;'>
                                    <asp:TextBox ID="tb_IIe23" runat="server" MaxLength="3" Width="36px" Font-Names="Arial" Font-Size="medium" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>
                                </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
<%--                <tr>
                                <td style='text-align:Left;vertical-align:top;border-top:none;width:35%;'>
                                    <asp:Label ID="lb_IIe24" runat="server" Text="¿Qué es esta persona de la jefa(e)" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:65%;'>
                                    <asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" Visible="true" onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="100%" Font-Names="Arial" Font-Size="medium" Font-Bold="False"></asp:DropDownList> 
                                </td>
                </tr>
                <tr>
                                <td style='text-align:Left;vertical-align:top;border-top:none;width:35%;'>
                                    
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:65%;'>
                                    <asp:TextBox ID="tb_IIe24" runat="server" MaxLength="50" Width="100%" Font-Names="Arial" Font-Size="medium" onkeyup="soloLetrasY(this,' ');mayusculas(this);"></asp:TextBox>
                                </td>
                </tr>--%>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="agregar01" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="agregar01_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Aceptar</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="Guardar_todo" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Guardar_todo_Click" ><img src="images/32x32-Eliminar.png" alt="" />&nbsp;Cancelar</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004p" class="col-sm-12" style="display:none;">
           <div id="Div3p" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="lb_IIe2ep" runat="server" Text="Por favor registre los datos (nombre, sexo, edad y parentesco) de la persona" Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:Left;vertical-align:top;border-top:none;width:35%;'>
                                    <asp:Label ID="lb_IIe21p" runat="server" Text="¿Cuál es el nombre de esta persona?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:65%;'>
                                    <asp:TextBox ID="tb_IIe21p" runat="server" MaxLength="50" Width="100%" Font-Names="Arial" Font-Size="medium" onkeyup="soloLetrasY(this,' ');mayusculas(this);"></asp:TextBox>
                                </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:Left;vertical-align:top;border-top:none;width:35%;'>
                                    <asp:Label ID="lb_IIe22p" runat="server" Text="Esta persona es:" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:65%;'>

                                   <%-- <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="35%" Font-Bold="true" >
                                     <asp:ListItem>Hombre</asp:ListItem>
                                     <asp:ListItem>Mujer</asp:ListItem>
                                    </asp:RadioButtonList>--%>

                                    <asp:RadioButton runat="server" id="radioA1p" GroupName="radioAp" AutoPostBack="False"/>&nbsp;<asp:Label ID="lb_IIe221p" runat="server" Text="Hombre" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton runat="server" id="radioA2p" GroupName="radioAp" AutoPostBack="False"/>&nbsp;<asp:Label ID="lb_IIe222p" runat="server" Text="Mujer" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:Left;vertical-align:top;border-top:none;width:35%;'>
                                    <asp:Label ID="lb_IIe23p" runat="server" Text="¿Cuántos años cumplidos tiene esta persona?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:65%;'>
                                    <asp:TextBox ID="tb_IIe23p" runat="server" MaxLength="3" Width="36px" Font-Names="Arial" Font-Size="medium" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>
                                    <br />
                                    <asp:Label ID="lb_IIe23a" runat="server" Text="SI ES MENOR DE UN AÑO REGISTRE '0'" Font-Names="Arial" Font-Size="X-Small" ForeColor="Gray" BorderStyle="None"></asp:Label>
                                </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:Left;vertical-align:top;border-top:none;width:35%;'>
                                    <asp:Label ID="lb_IIe24" runat="server" Text="¿Qué es esta persona de la(del) jefa(e)" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:65%;'>

 <%--                                   <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Vertical" TextAlign="Left" Width="35%" Font-Bold="true" >
                                        <asp:ListItem>Jefa(e)</asp:ListItem>
                                        <asp:ListItem>Esposa(o) o pareja</asp:ListItem>
                                        <asp:ListItem>Hija(o)</asp:ListItem>
                                        <asp:ListItem>Nieta(o)</asp:ListItem>
                                        <asp:ListItem>Nuera o yerno</asp:ListItem>
                                        <asp:ListItem>Madre o padre</asp:ListItem>
                                        <asp:ListItem>Suegra (o)</asp:ListItem>
                                        <asp:ListItem>Sin parentesco</asp:ListItem>
                                        <asp:ListItem>Otro (especifique)</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    
                                    <%--<asp:Label ID="lb_IIe241" runat="server" Text="Jefa(e)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB1" GroupName="radioB" AutoPostBack="True"/><br />
                                    <asp:Label ID="lb_IIe242" runat="server" Text="Esposa(o) o pareja" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB2" GroupName="radioB" AutoPostBack="True"/><br />
                                    <asp:Label ID="lb_IIe243" runat="server" Text="Hija(o)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB3" GroupName="radioB" AutoPostBack="True"/><br />
                                    <asp:Label ID="lb_IIe244" runat="server" Text="Nieta(o)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB4" GroupName="radioB" AutoPostBack="True"/><br />
                                    <asp:Label ID="lb_IIe245" runat="server" Text="Nuera o yerno" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB5" GroupName="radioB" AutoPostBack="True"/><br />
                                    <asp:Label ID="lb_IIe246" runat="server" Text="Madre o padre" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB6" GroupName="radioB" AutoPostBack="True"/><br />
                                    <asp:Label ID="lb_IIe247" runat="server" Text="Suegra (o)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB7" GroupName="radioB" AutoPostBack="True"/><br />
                                    <asp:Label ID="lb_IIe248" runat="server" Text="Sin parentesco" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB8" GroupName="radioB" AutoPostBack="True"/><br />
                                    <asp:Label ID="lb_IIe249" runat="server" Text="Otro (especifique)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB9" GroupName="radioB" AutoPostBack="True"/>--%>
                                    <asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" Visible="true" onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="100%" Font-Names="Arial" Font-Size="medium" Font-Bold="False"></asp:DropDownList> 
                                </td>
                </tr>
                <tr>
                                <td style='text-align:Left;vertical-align:top;border-top:none;width:35%;'>
                                    
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:65%;'>
                                    <asp:TextBox ID="tb_IIe24" runat="server" MaxLength="50" Width="100%" Font-Names="Arial" Font-Size="medium" onkeyup="soloLetrasY(this,' ');mayusculas(this);"></asp:TextBox>
                                </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="agregar01p" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="agregar01p_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Aceptar</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="Guardar_todop" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Guardar_todop_Click" ><img src="images/32x32-Eliminar.png" alt="" />&nbsp;Cancelar</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004q" class="col-sm-12" style="display:none;">
           <div id="Div6" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label4" runat="server" Text="Esta persona es la(el) Jefa(e) de la vivienda, ¿está usted segura(o) de borrarla(o)?, al eliminarla(o) deberá registrar nuevamente a todas las personas." Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="agregar01b1_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Aceptar</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton2" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Guardar_todop_Click" ><img src="images/32x32-Eliminar.png" alt="" />&nbsp;Cancelar</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004q1" class="col-sm-12" style="display:none;">
           <div id="Div30" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label35" runat="server" Text="¿Desea eliminar el registro de la lista?" Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="LinkButton40" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="agregar01b3_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Aceptar</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton41" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Guardar_todop_Click" ><img src="images/32x32-Eliminar.png" alt="" />&nbsp;Cancelar</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004q2" class="col-sm-12" style="display:none;">
           <div id="Div8" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label8" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
<%--                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label9" runat="server" Text="" Font-Names="Arial" Font-Size="Large" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="LinkButton4" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="LinkButton3_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Sí</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton5" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Guardar_todop_Click" ><img src="images/32x32-Eliminar.png" alt="" />&nbsp;No</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004q3" class="col-sm-12" style="display:none;">
           <div id="Div12" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label18" runat="server" Text="" Font-Names="Arial" Font-Size="Large" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label19" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="LinkButton12" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="LinkButton3plus_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Cerrar</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004q4" class="col-sm-12" style="display:none;">
           <div id="Div14" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' >
                        <asp:Image ID="Image3" ImageUrl="Images/Cortinilla5B.JPG" style='display:block; margin: 0 auto; width: 100%;' runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;'>
                                    <asp:LinkButton ID="LinkButton15" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="LinkButton15_Click" >Continuar</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004q5" class="col-sm-12" style="display:none;">
           <div id="Div15" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' >
                        <asp:Image ID="Image4" ImageUrl="Images/Cortinilla2.JPG" style='display:block; margin: 0 auto; width: 100%;' runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;'>
                                    <asp:LinkButton ID="LinkButton16" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="LinkButton16_Click" >Continuar</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004q6" class="col-sm-12" style="display:none;">
           <div id="Div16" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:center;vertical-align:top;border-top:none;width:100%;padding:0px 0px 0px 0px;border-spacing:0px 0px;' >
                        <asp:Image ID="Image5" ImageUrl="Images/Cortinilla3A.JPG" style='display:block; margin: 0 auto; width: 100%;' runat="server"/>
                    </td>
                </tr>
				<tr>
				    <td style='text-align:center;vertical-align:top;border-top:none;border-bottom:none; background-image:url("Images/Cortinilla3B.JPG"); width:100%;padding:0px 0px 0px 0px;border-spacing:0px 0px;'><asp:label id="Label2" runat="server" Text="Ahora le solicitaremos la información de:" style='font-size:large; color:black; font-family:Arial;'></asp:label></td>
				</tr>
				<tr>
				    <td style='text-align:center;vertical-align:top;border-top:none;border-bottom:none; background-image:url("Images/Cortinilla3B.JPG"); width:100%;padding:0px 0px 0px 0px;border-spacing:0px 0px;'><br /></td>
				</tr>
				<tr>
				    <td style='text-align:center;vertical-align:top;border-top:none;border-bottom:none; background-image:url("Images/Cortinilla3B.JPG"); width:100%;padding:0px 0px 0px 0px;border-spacing:0px 0px;'><br /></td>
				</tr>
				<tr>
				    <td style='text-align:center;vertical-align:top;border-top:none;border-bottom:none; background-image:url("Images/Cortinilla3B.JPG"); width:100%;padding:0px 0px 0px 0px;border-spacing:0px 0px;'><asp:label id="Label21" runat="server" Text="Persona" style='font-size:large; color:darkblue; font-family:Arial;'></asp:label></td>
				</tr>
				<tr>
				    <td style='text-align:center;vertical-align:top;border-top:none;border-bottom:none; background-image:url("Images/Cortinilla3B.JPG"); width:100%;padding:0px 0px 0px 0px;border-spacing:0px 0px;'><br /></td>
				</tr>
				<tr>
				    <td style='text-align:center;vertical-align:top;border-top:none;border-bottom:none; background-image:url("Images/Cortinilla3B.JPG"); width:100%;padding:0px 0px 0px 0px;border-spacing:0px 0px;'><br /></td>
				</tr>
				<tr>
				    <td style='text-align:center;vertical-align:top;border-top:none;border-bottom:none; background-image:url("Images/Cortinilla3B.JPG"); width:100%;padding:0px 0px 0px 0px;border-spacing:0px 0px;'><br /></td>
				</tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;'>
                                    <asp:LinkButton ID="LinkButton17" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="LinkButton17_Click" >Continuar</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004q7" class="col-sm-12" style="display:none;">
           <div id="Div17" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' >
                        <asp:Image ID="Image6" ImageUrl="Images/Cortinilla4.JPG" style='display:block; margin: 0 auto; width: 100%;' runat="server"/>
                    </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004S" class="col-sm-12" style="display:none;">
           <div id="Div18" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label22" runat="server" Text="Usted contestó que en este domicilio vive o duerme normalmente alguna persona pero registró cero en el total de personas. Entonces, ¿la vivienda está deshabitada?" Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="LinkButton18" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Si02_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Si</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton19" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="No02_Click" ><img src="images/32x32-Eliminar.png" alt="" />&nbsp;No</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004S1" class="col-sm-12" style="display:none;">
           <div id="Div19" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label23" runat="server" Text="La edad de la(el) jefa(e) es menor de 12 años, ¿es correcto?" Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="LinkButton20" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Si03_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Si</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton21" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="No03_Click" ><img src="images/32x32-Eliminar.png" alt="" />&nbsp;No</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004S2" class="col-sm-12" style="display:none;">
           <div id="Div20" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label24" runat="server" Text="Existe ya una o más personas declaradas como esposa(o) o pareja de la(el) jefa(e), ¿también esta persona presenta el mismo parentesco?" Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="LinkButton22" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Si04_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Si</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton23" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="No04_Click" ><img src="images/32x32-Eliminar.png" alt="" />&nbsp;No</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004S3" class="col-sm-12" style="display:none;">
           <div id="Div21" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label25" runat="server" Text="La diferencia de edad entre una madre o padre y su hijas(os) consangíneas(os) debe ser mínimo de 11 años." Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label><br />
                        <asp:Label ID="Label39" runat="server" Text="Existe incongruencia en la edad que se declaró de la(el) hija(o) respecto de la(el) jefa(e), ¿el dato que proporcionó es correcto?" Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="LinkButton24" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Si05_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Si</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton25" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="No05_Click" ><img src="images/32x32-Eliminar.png" alt="" />&nbsp;No</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004S4" class="col-sm-12" style="display:none;">
           <div id="Div22" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label26" runat="server" Text="La diferencia de edad entre una(un) abuela(o) y sus nietas(os) consaguíneas(os) debe ser mínimo de 21 años." Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label><br />
                        <asp:Label ID="Label40" runat="server" Text="Existe incongruencia en la edad que se declaró de la(el) nieta(o) con respecto de la(el) jefa(e), ¿el dato que proporcionó es correcto?" Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="LinkButton26" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Si06_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Si</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton27" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="No06_Click" ><img src="images/32x32-Eliminar.png" alt="" />&nbsp;No</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004S5" class="col-sm-12" style="display:none;">
           <div id="Div23" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label27" runat="server" Text="La diferencia de edad entre una(un) hija(o) y sus padres consanguíneos debe ser mínimo de 11 años." Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label><br />
                        <asp:Label ID="Label41" runat="server" Text="Existe incongruencia en edad que se declaró de la madre o padre con respecto de la(el) jefa(e), ¿el dato que proporcionó es correcto?" Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="LinkButton28" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Si07_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Si</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton29" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="No07_Click" ><img src="images/32x32-Eliminar.png" alt="" />&nbsp;No</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004S6" class="col-sm-12" style="display:none;">
           <div id="Div24" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label28" runat="server" Text="La edad de la(el) esposa(o) o pareja de la(el) jefa(e) es menor de 12 años, ¿es correcto?" Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="LinkButton30" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Si08_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Si</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton31" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="No08_Click" ><img src="images/32x32-Eliminar.png" alt="" />&nbsp;No</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004S7" class="col-sm-12" style="display:none;">
           <div id="Div25" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label29" runat="server" Text="Todas las personas que integran la vivienda presentan una edad menor de 12 años, ¿es correcto?" Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="LinkButton32" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Si09_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Si</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton33" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="No09_Click" ><img src="images/32x32-Eliminar.png" alt="" />&nbsp;No</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004S8" class="col-sm-12" style="display:none;">
           <div id="Div26" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label30" runat="server" Text="Existen más de diez personas en la vivienda sin relación de parentesco directo con la(el) jefa(e), ¿es correcto?" Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="LinkButton34" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Si010_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Si</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton35" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="No010_Click" ><img src="images/32x32-Eliminar.png" alt="" />&nbsp;No</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004S9" class="col-sm-12" style="display:none;">
           <div id="Div27" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label16" runat="server" Text="Aviso" Font-Names="Arial" Font-Size="XX-Large" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label13" runat="server" Text="Las niñas y niños nacidos de enero de 2015 a la fecha, en estos momentos tienen menos de 3 años de edad." Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label31" runat="server" Text="El número que acaba de indicar no corresponde con el total de menores de 3 años que Usted registró en la lista de personas." Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label32" runat="server" Text="Por favor verifique la lista" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <%--<asp:LinkButton ID="LinkButton36" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="P91_Click" >&nbsp;Corregir el total de niñas(os)</asp:LinkButton>&nbsp;&nbsp;&nbsp;--%><asp:LinkButton ID="LinkButton37" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="P92_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Cerrar</asp:LinkButton><%--&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton38" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="P93_Click" >&nbsp;Información correcta, continuar con el cuestionario</asp:LinkButton>--%>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004S10" class="col-sm-12" style="display:none;">
           <div id="Div28" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label33" runat="server" Text="Existe ya una o más personas declaradas como esposa(o) o pareja de la(el) jefa(e); además, la edad del registro actual donde se seleccionó el mismmo parentesco es menor de 12 años, ¿los datos que proporcionó son correctos?" Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="LinkButton36" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Si11_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Si</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton38" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="No11_Click" ><img src="images/32x32-Eliminar.png" alt="" />&nbsp;No</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004S11" class="col-sm-12" style="display:none;">
           <div id="Div29" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label34" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="LinkButton39" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Si12_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Continuar</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004S12" class="col-sm-12" style="display:none;">
           <div id="Div31" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label36" runat="server" Text="La persona seleccionada como informante es menor de 18 años, ¿es correcto?" Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="LinkButton42" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Si13_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Si</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton43" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="No13_Click" ><img src="images/32x32-Eliminar.png" alt="" />&nbsp;No</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec005" class="col-sm-12" style="display:none; ">
           <div id="Div4" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;">
               <table  style="border:0;width:100%;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                   <tr>
                       <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                       </td>
                        <td style='text-align:center;vertical-align:top;border-top:none;width:90%;'>
                            <asp:Panel ID="Panel1" runat="server" Height="100%" ScrollBars="Auto" Width="100%" Visible="True">
                            <asp:GridView ID="Gvresulta" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="Medium"
                                DataKeyNames="NOMBRE" ForeColor="#333333" Width="100%" 
                                    AllowPaging="False" AllowSorting="False" onrowdatabound="Gvresulta_RowDataBound">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
<%--                                    <asp:TemplateField HeaderText="Informante" ItemStyle-Width="5%">
                                       <ItemTemplate>
                                        <input name="MyRadioButton" type="radio" style="width:24px;height:24px"/>
                                       </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:BoundField DataField="CUENTA" DataFormatString="{0:###}" ItemStyle-Font-Size="X-Large"
                                        HeaderText="No." SortExpression="CUENTA" 
                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false" ItemStyle-Width="5%">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NOMBRE" HtmlEncode ="false" 
                                        HeaderText="Nombre" SortExpression="NOMBRE" ItemStyle-Font-Size="X-Large"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Wrap="false" ItemStyle-Width="50%">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SEXO" 
                                        HeaderText="Sexo" SortExpression="SEXO" ItemStyle-Font-Size="X-Large"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Wrap="false" ItemStyle-Width="10%">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EDAD" DataFormatString="{0:###}" ItemStyle-Font-Size="X-Large"
                                        HeaderText="Edad" SortExpression="EDAD" 
                                        ItemStyle-HorizontalAlign="Right" HeaderStyle-Wrap="false" ItemStyle-Width="10%">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PARENTESCO" ItemStyle-Font-Size="X-Large" HtmlEncode ="false"
                                        HeaderText="Parentesco" SortExpression="PARENTESCO" 
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Wrap="false" ItemStyle-Width="20%">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Editar/Eliminar" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <%--<asp:Image ID="Image1" runat="server" ToolTip="imagen"/>&nbsp;&nbsp;--%>
                                            <asp:CheckBox ID="CHB_funciones" runat="server" Enabled="True" AutoPostBack="true" OnCheckedChanged="CHB_funciones_CheckedChanged" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  ToolTip="activar funciones"/>&nbsp;
                                            <asp:ImageButton ID="ImgBtn_editar" runat="server" ToolTip="Editar persona" Visible="false"
                                                ImageUrl="~/images/24x24-Edit.png" OnCommand="ImgBtn_editar_Command" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CUENTA") + "@" + DataBinder.Eval(Container.DataItem,"NOMBRE") + "@" + DataBinder.Eval(Container.DataItem,"SEXO") %> ' />&nbsp;
                                            <asp:ImageButton ID="ImgBtn_eliminar" runat="server" ToolTip="Eliminar persona" Visible="false"
                                                ImageUrl="~/images/24x24-Trash.png" OnCommand="ImgBtn_eliminar_Command" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CUENTA") + "@" + DataBinder.Eval(Container.DataItem,"NOMBRE") + "@" + DataBinder.Eval(Container.DataItem,"SEXO") %> ' />
                                        </ItemTemplate>    
                                        <ItemStyle Width="25px" />                            
                                     </asp:TemplateField> 

                                  <%--  <asp:TemplateField HeaderText="Borrar">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton3" runat="server" ToolTip="Eliminar persona"
                                                ImageUrl="~/images/46x46-Eliminar.png" OnCommand="ImageButton3_Command" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CUENTA") + "@" + DataBinder.Eval(Container.DataItem,"NOMBRE") + "@" + DataBinder.Eval(Container.DataItem,"SEXO") %> ' />
                                        </ItemTemplate>
                                        <ItemStyle Width="25px" />
                                    </asp:TemplateField>--%>
<%--                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton4" runat="server" ToolTip="Abrir cuestionario"
                                                ImageUrl="~/images/ico_editar_chico.gif" OnCommand="ImageButton4_Command" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CUENTA") + "@" + DataBinder.Eval(Container.DataItem,"NOMBRE") + "@" + DataBinder.Eval(Container.DataItem,"SEXO") %> ' />
                                        </ItemTemplate>
                                        <ItemStyle Width="25px" />
                                    </asp:TemplateField>--%>
                                </Columns>
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <EditRowStyle BackColor="#999999" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <EmptyDataTemplate>
                                    <strong>Aquí se mostrarán los habitantes de la vivienda...</strong>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            </asp:Panel>
                        </td>
                       <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                       </td>
                   </tr>
               </table>
<%--               <table  style="border:0;width:100%;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                    <tr>
                       <td style='text-align:center;vertical-align:top;border-top:none;width:100%;'>
                           <asp:LinkButton ID="LinkButton3" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="LinkButton3bis_Click" >Finalizar lista y continuar&nbsp;<img src="images/32x32-Siguiente.png" alt="" /></asp:LinkButton>
                       </td>
                    </tr>
               </table>--%>
 <%--                       <table id="tabla"  class="table table-striped table-bordered" >
                            <thead class="thead-inverse">
                                <tr>
                                    <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'><asp:Label ID="lb_0001" runat="server" Text="Informante" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label></td>
                                    <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'><asp:Label ID="lb_0002" runat="server" Text="No." Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label></td>
                                    <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'><asp:Label ID="lb_0003" runat="server" Text="Nombre" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label></td>
                                    <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'><asp:Label ID="lb_0004" runat="server" Text="Sexo" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label></td>
                                    <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'><asp:Label ID="lb_0005" runat="server" Text="Edad" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label></td>
                                    <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'><asp:Label ID="lb_0006" runat="server" Text="Parentesco" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label></td>
                                    <td style='text-align:center;vertical-align:top;border-top:none;width:20%;'><asp:Label ID="lb_0007" runat="server" Text="Opciones" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label></td>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>
                        <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                            <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;'>
                                    <asp:Button id="btn_lanzarc" class="btn btn-info" runat="server" Text="Comenzar Cuestionario(s)" OnClick="btn_lanzarc_Click"></asp:Button>
                                </td>
                            </tr>
                        </table>--%>
           </div>
        </div>
        <div id="Sec005a" class="col-sm-12" style="display:none;">
           <div id="Div5" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                   <tr>
                       <td style='text-align:center;vertical-align:top;border-top:none;width:100%;'>
                    <%--OnRowEditing="gv1_RowEditing" DataSourceID="SqlDataSource4" --%> 
                    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False" OnRowEditing="gv1_RowEditing" OnRowCancelingEdit="gv1_RowCancelingEdit"
                    OnRowUpdating="gv1_RowUpdating" CellPadding="4" ForeColor="#333333">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                    <asp:CommandField ShowEditButton="True" />
                                    <asp:BoundField DataField="CUENTA" DataFormatString="{0:###}" ItemStyle-Font-Size="Medium"
                                        HeaderText="No." SortExpression="CUENTA" 
                                        ItemStyle-HorizontalAlign="Right" HeaderStyle-Wrap="false">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>

<%--                        <asp:TemplateField HeaderText="NOMBRE" InsertVisible="False" SortExpression="NOMBRE">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Visible='<%# IsInEditMode %>' Text='<%# Bind("NOMBRE") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Visible='<%# !(bool) IsInEditMode %>' Text='<%# Bind("NOMBRE") %>'></asp:Label>
                                <asp:TextBox ID="TextBox6" runat="server" Visible='<%# IsInEditMode %>' Text='<%# Bind("NOMBRE") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SEXO" SortExpression="SEXO">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Visible='<%# IsInEditMode %>' Text='<%# Bind("SEXO") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Visible='<%# !(bool) IsInEditMode %>' Text='<%# Bind("SEXO") %>'></asp:Label>
                                <asp:TextBox ID="TextBox2" runat="server" Visible='<%# IsInEditMode %>' Text='<%# Bind("SEXO") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EDAD" SortExpression="EDAD">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox20" runat="server" Visible='<%# IsInEditMode %>' Text='<%# Bind("EDAD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Visible='<%# !(bool) IsInEditMode %>' Text='<%# Bind("EDAD") %>'></asp:Label>
                                <asp:TextBox ID="TextBox20" runat="server" Visible='<%# IsInEditMode %>' Text='<%# Bind("EDAD") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PARENTESCO" SortExpression="PARENTESCO">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Visible='<%# IsInEditMode %>' Text='<%# Bind("PARENTESCO") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Visible='<%# !(bool) IsInEditMode %>' Text='<%# Bind("PARENTESCO") %>'></asp:Label>
                                <asp:TextBox ID="TextBox3" runat="server" Visible='<%# IsInEditMode %>' Text='<%# Bind("PARENTESCO") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>


                       </td>
                   </tr>
               </table>
           </div>
        </div>

        <div id="Sec005b" class="col-sm-12" style="display:none; ">
           <div id="Div9" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;">
               <table  style="border:0;width:100%;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label9" runat="server" Text="Por favor, seleccione de la lista a la persona que está proporcionando la información." Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                   <tr>
                       <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                       </td>
                        <td style='text-align:center;vertical-align:top;border-top:none;width:90%;'>
                            <asp:Panel ID="Panel2" runat="server" Height="100%" ScrollBars="Auto" Width="100%" Visible="True">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="Medium"
                                DataKeyNames="NOMBRE" ForeColor="#333333" Width="100%" 
                                    AllowPaging="False" AllowSorting="False" onrowdatabound="GridView1_RowDataBound">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="CUENTA" DataFormatString="{0:###}" ItemStyle-Font-Size="X-Large"
                                        HeaderText="No." SortExpression="CUENTA" 
                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false" ItemStyle-Width="5%">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NOMBRE" HtmlEncode ="false" 
                                        HeaderText="Nombre" SortExpression="NOMBRE" ItemStyle-Font-Size="X-Large"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Wrap="false" ItemStyle-Width="50%">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SEXO" 
                                        HeaderText="Sexo" SortExpression="SEXO" ItemStyle-Font-Size="X-Large"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Wrap="false" ItemStyle-Width="10%">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EDAD" DataFormatString="{0:###}" ItemStyle-Font-Size="X-Large"
                                        HeaderText="Edad" SortExpression="EDAD" 
                                        ItemStyle-HorizontalAlign="Right" HeaderStyle-Wrap="false" ItemStyle-Width="10%">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PARENTESCO" ItemStyle-Font-Size="X-Large" HtmlEncode ="false"
                                        HeaderText="Parentesco" SortExpression="PARENTESCO" 
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Wrap="false" ItemStyle-Width="20%">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Informante" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <%--<asp:CheckBox ID="CHB_funciones1" runat="server" Enabled="True" AutoPostBack="true" OnCheckedChanged="CHB_funciones1_CheckedChanged" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'  ToolTip="Informante"/>&nbsp;--%>
                                            <%--<input name="MyRadioButton" type="radio" runat="server" style="width:24px;height:24px"/>--%>
                                            <asp:RadioButton ID="RadioButton1" runat="server"  onclick = "RadioCheck(this);"/>
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value = '<%#Eval("CUENTA")%>' />
                                        </ItemTemplate>    
                                        <ItemStyle Width="5%" />                            
                                     </asp:TemplateField> 
                                </Columns>
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <EditRowStyle BackColor="#999999" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <EmptyDataTemplate>
                                    <strong>Aquí se mostrarán los habitantes de la vivienda...</strong>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            </asp:Panel>
                        </td>
                       <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                       </td>
                   </tr>
               </table>
               <table  style="border:0;width:100%;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                    <tr>
                       <td style='text-align:center;vertical-align:top;border-top:none;width:100%;'>
                           <asp:LinkButton ID="LinkButton7" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="LinkButton3bis1_Click" >Siguiente&nbsp;<img src="images/16x16-Siguiente.png" alt="" /></asp:LinkButton>
                       </td>
                    </tr>
               </table>
            </div>
        </div>

        <div id="Sec005c" class="col-sm-12" style="display:none;">
            <div id="Div32" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; background-color:lightgray;">
                    <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                    <tr>
                        <td style="align-content:center; align-items:center; text-align:center; vertical-align:top; width:100%;" >
                            <table style="width:100%;">
                                <tr>
                                    <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                                            <%--<asp:Label ID="Label1" runat="server" Text="SECCIÓN: II. LISTA DE PERSONAS" Font-Size="X-Large" ForeColor="CadetBlue" Font-Names="Arial"></asp:Label>--%>
                                            <asp:Label ID="Label3" runat="server" Text="SECCIÓN II. LISTA DE PERSONAS Y DATOS GENERALES" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    </td>
 	               	                <td style="text-align:left; vertical-align:top; width:45%">
                                       <div id="barraavance22" >
                                            <table id="barras1" style="width:100%; height:33px" border="0" >
                                                <tr>
                                                    <td style="width:69%; vertical-align:text-top; padding:0px;">
                                                        <div class="progress" style="margin:0">
                                                          <div id="Div33" runat="server" class="progress-bar progress-bar-custom2" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax ="100" ></div>
                                                        </div>
                                                    </td>
                                                    <td style="width:2%; vertical-align:text-top; padding:0px;"></td>
                                                    <td style="width:29%; vertical-align:text-top; padding:0px; ">
                                                        <asp:label id="Label6" runat="server" style="font-size:smaller; color:#3E78B3; font-family:Arial"></asp:label>
                                                    </td>
                                                </tr>
                                            </table>
                                      </div>
                                    </td>
                                    <td style='text-align:right;vertical-align:top;border-top:none;width:5%;'>
                                       <%--<asp:LinkButton ID="ayuda01" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="ayuda01_Click"><img src="images/16x16-Info.png" alt="" /></asp:LinkButton>--%>
                                        <%--data-trigger="focus"--%>
                                        <button type="button" id="Button1" runat="server" style="border:none;background-color:transparent;"
                                               data-html="true" 
                                               data-toggle="popover" 
                                               data-placement="bottom"
                                               title="<b>Ayuda</b>" 
                                               data-content="Some content">
                                               <img src="images/informacion30.png" alt="" style="border:none; background:none;"/>
                                        </button>
                                        <%--<button type="button" id="ayuda01" runat="server" style="border:none;background-color:transparent;" onclick="showModalPopupViaClient2()" title="Ayuda">
                                               <img src="images/informacion30.png" alt="" style="border:none; background:transparent;"/>
                                        </button>--%>
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
                    </table>
            </div>

           <div id="Div10" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="Label11" runat="server" Text="De enero de 2015 a la fecha, ¿nació alguna niña o niño en su vivienda?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="Label14" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="rv01" GroupName="radioV1" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="Label15" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="rv02" GroupName="radioV1" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>
               </table>
           </div>
            <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:center;vertical-align:top;border-top:none;width:100%;'  colspan="4">
                        <asp:LinkButton ID="LinkButton10" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="LinkButton3bisa_Click" ><img src="images/16x16-Anterior.png" alt="" />&nbsp;Anterior</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton8" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="LinkButton3bis2_Click" >Siguiente&nbsp;<img src="images/16x16-Siguiente.png" alt="" /></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>

        <div id="Sec005d" class="col-sm-12" style="display:none;">
            <div id="Div34" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; background-color:lightgray;">
                    <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                    <tr>
                        <td style="align-content:center; align-items:center; text-align:center; vertical-align:top; width:100%;" >
                            <table style="width:100%;">
                                <tr>
                                    <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                                            <%--<asp:Label ID="Label1" runat="server" Text="SECCIÓN: II. LISTA DE PERSONAS" Font-Size="X-Large" ForeColor="CadetBlue" Font-Names="Arial"></asp:Label>--%>
                                            <asp:Label ID="Label42" runat="server" Text="SECCIÓN II. LISTA DE PERSONAS Y DATOS GENERALES" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    </td>
 	               	                <td style="text-align:left; vertical-align:top; width:45%">
                                       <div id="barraavance23" >
                                            <table id="barras2" style="width:100%; height:33px" border="0" >
                                                <tr>
                                                    <td style="width:69%; vertical-align:text-top; padding:0px;">
                                                        <div class="progress" style="margin:0">
                                                          <div id="Div35" runat="server" class="progress-bar progress-bar-custom2" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax ="100" ></div>
                                                        </div>
                                                    </td>
                                                    <td style="width:2%; vertical-align:text-top; padding:0px;"></td>
                                                    <td style="width:29%; vertical-align:text-top; padding:0px; ">
                                                        <asp:label id="Label43" runat="server" style="font-size:smaller; color:#3E78B3; font-family:Arial"></asp:label>
                                                    </td>
                                                </tr>
                                            </table>
                                      </div>
                                    </td>
                                    <td style='text-align:right;vertical-align:top;border-top:none;width:5%;'>
                                       <%--<asp:LinkButton ID="ayuda01" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="ayuda01_Click"><img src="images/16x16-Info.png" alt="" /></asp:LinkButton>--%>
                                        <%--data-trigger="focus"--%>
                                        <button type="button" id="Button2" runat="server" style="border:none;background-color:transparent;"
                                               data-html="true" 
                                               data-toggle="popover" 
                                               data-placement="bottom"
                                               title="<b>Ayuda</b>" 
                                               data-content="Some content">
                                               <img src="images/informacion30.png" alt="" style="border:none; background:none;"/>
                                        </button>
                                        <%--<button type="button" id="ayuda01" runat="server" style="border:none;background-color:transparent;" onclick="showModalPopupViaClient2()" title="Ayuda">
                                               <img src="images/informacion30.png" alt="" style="border:none; background:transparent;"/>
                                        </button>--%>
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
                    </table>
            </div>
           <div id="Div11" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="Label12" runat="server" Text="¿Cuántas(os) de estas(os) niñas(os) que nacieron de enero de 2015 a la fecha, viven actualmente en su vivienda?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
 <%--               <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="Label13" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="rv03" GroupName="radioV2" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="Label16" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="rv04" GroupName="radioV2" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>--%>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:TextBox ID="tb_LP8" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie21" runat="server" Text="REGISTRE CON NÚMERO" Font-Names="Arial" Font-Size="X-Small" ForeColor="Gray" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
            <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:center;vertical-align:top;border-top:none;width:100%;'  colspan="4">
                        <asp:LinkButton ID="LinkButton11" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="LinkButton4a_Click" ><img src="images/16x16-Anterior.png" alt="" />&nbsp;Anterior</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton9" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="LinkButton4_Click" >Siguiente&nbsp;<img src="images/16x16-Siguiente.png" alt="" /></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>

    </div>

    <div id="Sec0010" class="row" >
        <div id="Sec006" class="col-sm-12" style="display:none;">
          <div id="DivIIIe1enc" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:left; min-width:250px; background-color:lightgray;">
               <table style="width:100%;border:0 ;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                   <tr>
                       <td style='text-align:left;vertical-align:top;border-top:none;width:50%;' >
                           <asp:Label ID="lb_III" runat="server" Text="SECCIÓN III. CARACTERÍSTICAS DE LAS PERSONAS" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                       </td>
<%--                       <td style='text-align:right;vertical-align:top;border-top:none;width:100%;'>
                           <button type="button" class="btn btn-default btn-sm" id="ayuda01" runat="server" data-html="true" data-toggle="popover" data-placement="left" data-trigger="focus" title="<b>Ayuda</b>" data-content="Some content">
                                   <img src="images/16x16-Info.png" alt="" />
                            </button>
                       </td>--%>
                       <td style="text-align:center;vertical-align:top;border-top:none; width:45%; height:33px;">
                           <div id="barraavance1" >
                                <table id="barr" style="width:100%; height:33px" border="0" >
                                    <tr>
                                        <td style="width:70%; vertical-align:text-top; padding:0px;">
                                            <div class="progress" style="margin:0">
                                              <div id="barra_tot" runat="server" class="progress-bar progress-bar-custom2" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax ="100" ></div>
                                            </div>
                                        </td>
                                        <td style="width:30%; vertical-align:text-top; padding:0px; ">
                                            <asp:label id="avance_tot" runat="server" style="font-size:smaller; color:#3E78B3; font-family:Arial"></asp:label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:70%; vertical-align:text-top; padding:0px;">
                                             <div class="progress" style="margin:0">
                                              <div id="barra" runat="server" class="progress-bar progress-bar-custom" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax ="100" ></div>
                                            </div>
                                        </td>
                                        <td  style="width:30%; vertical-align:text-top; padding:0px; ">
                                            <asp:label id="avance" runat="server" style="font-size:smaller; color:#3E78B3; font-family:Arial"></asp:label>
                                        </td>
                                    </tr>
                                </table>
                          </div>
                       </td>
                       <td style='text-align:right;vertical-align:top;border-top:none;width:5%;' >
                           <%-- class="btn btn-default btn-sm"--%>
                           <%--data-trigger="focus"--%>
                           <button type="button" id="ayuda01a" runat="server" style="border:none;background-color:transparent;"
                                   data-html="true" 
                                   data-toggle="popover" 
                                   data-placement="bottom"
                                   title="<b>Ayuda</b>" 
                                   data-content="Some content">
                                   <img src="images/informacion30.png" alt="" />
                            </button>
<%--                           <button type="button" id="ayuda01a" runat="server" style="border:none;background-color:transparent;"  onclick="showModalPopupViaClient2()" title="Ayuda">
                                   <img src="images/informacion30.png" alt="" style="border:none;background-color:transparent;" />
                            </button>--%>
                       </td>
                   </tr>
                   <%-- <tr>
                       <td style='text-align:right;vertical-align:top;border-top:none;width:45%;'>
                           <div id="barraavance2" class="col-md-12">
                                <table id="barr2" style="width:100%;" border="0" >
                                    <tr>
                                        <td style="width:70%; vertical-align:bottom">
                                            
                                        </td>
                                        <td style="width:30%; vertical-align:text-top">
                                            
                                        </td>
                                    </tr>
                                </table>
                          </div>
                       </td>
                   </tr>--%>
                   <tr>
                       <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="3">
                           <asp:Label ID="lb_III01" runat="server" Text="Persona elegida" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                       </td>
                   </tr>
               </table>
           </div>
        </div>
        <div id="Sec00701" class="col-sm-12" style="display:none;">
           <div id="DivIIIp101" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_IIIe101e1" runat="server" Text="De acuerdo con su cultura, ¿" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label><asp:Label ID="lb_IIIe101e2" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe101e3" runat="server" Text=" se considera indígena?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_IIIe1011" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="radioC1011" GroupName="radioC101" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe1012" runat="server" Text="Sí, en parte" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioC1012" GroupName="radioC101" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_IIIe1013" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="radioC1013" GroupName="radioC101" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe1014" runat="server" Text="No sabe" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioC1014" GroupName="radioC101" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec00700" class="col-sm-12" style="display:none;">
           <div id="DivIIIp100" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_IIIe100e1" runat="server" Text="¿En qué estado de la República Mexicana o en qué país nació" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe100e2" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label><asp:Label ID="lb_IIIe100e3" runat="server" Text="?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:Label ID="lb_IIIe1001" runat="server" Text="Aquí en este estado" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButton runat="server" id="radioC1001" GroupName="radioC100" AutoPostBack="True" OnCheckedChanged="radioC1001_CheckedChanged"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe1002" runat="server" Text="En otro estado" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioC1002" GroupName="radioC100" AutoPostBack="True" OnCheckedChanged="radioC1002_CheckedChanged"/>&nbsp;
                                    <asp:TextBox ID="tb_IIIe1002" runat="server" MaxLength="50" Width="90%" Font-Names="Arial" Font-Size="Small" onkeyup="soloLetrasY(this,' ');mayusculas(this);" Visible="false"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:50%;' colspan="2">
                                    <asp:Label ID="lb_IIIe10021" runat="server" Text="REGISTRE TEXTUAL EL NOMBRE DEL ESTADO" Font-Names="Arial" Font-Size="X-Small" ForeColor="Gray" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:Label ID="lb_IIIe1003" runat="server" Text="En Estados Unidos de  América" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButton runat="server" id="radioC1003" GroupName="radioC100" AutoPostBack="True" OnCheckedChanged="radioC1003_CheckedChanged"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe1004" runat="server" Text="En otro país" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioC1004" GroupName="radioC100"  AutoPostBack="True" OnCheckedChanged="radioC1004_CheckedChanged"/>&nbsp;
                                    <asp:TextBox ID="tb_IIIe1004" runat="server" MaxLength="50" Width="90%" Font-Names="Arial" Font-Size="Small" onkeyup="soloLetrasY(this,' ');mayusculas(this);" Visible="false"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:50%;' colspan="2">
                                    <asp:Label ID="lb_IIIe10041" runat="server" Text="REGISTRE TEXTUAL EL NOMBRE DEL PAÍS" Font-Names="Arial" Font-Size="X-Small" ForeColor="Gray" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec007" class="col-sm-12" style="display:none;">
           <div id="DivIIIp1" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_IIIe1e1" runat="server" Text="¿" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label><asp:Label ID="lb_IIIe1e2" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe1e3" runat="server" Text="está afiliada(o) o tiene derecho a servicios médicos en:" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
               <tr>
                    <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_IIIe1e1bis" runat="server" Text="LEA LAS OPCIONES Y SELECCIONE HASTA DOS" Font-Names="Arial" Font-Size="X-Small" ForeColor="Gray" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe11" runat="server" Text="el Seguro Popular o para una Nueva Generación (Siglo XXI)?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <%--<asp:RadioButton runat="server" id="radioC1" GroupName="radioC" AutoPostBack="False"/>--%>
                                    <asp:CheckBox ID="CheckBox1" runat="server" Enabled="True" AutoPostBack="true" CssClass="ChkBoxClass" OnCheckedChanged="CheckBox1_CheckedChanged"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe12" runat="server" Text="el IMSS (Seguro Social)?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <%--<asp:RadioButton runat="server" id="radioC2" GroupName="radioC" AutoPostBack="False"/>--%>
                                    <asp:CheckBox ID="CheckBox2" runat="server" Enabled="True" AutoPostBack="true" CssClass="ChkBoxClass" OnCheckedChanged="CheckBox2_CheckedChanged"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe13" runat="server" Text="el ISSSTE?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <%--<asp:RadioButton runat="server" id="radioC3" GroupName="radioC" AutoPostBack="False"/>--%>
                                    <asp:CheckBox ID="CheckBox3" runat="server" Enabled="True" AutoPostBack="true" CssClass="ChkBoxClass" OnCheckedChanged="CheckBox3_CheckedChanged"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe14" runat="server" Text="el ISSSTE estatal?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <%--<asp:RadioButton runat="server" id="radioC4" GroupName="radioC" AutoPostBack="False"/>--%>
                                    <asp:CheckBox ID="CheckBox4" runat="server" Enabled="True" AutoPostBack="true" CssClass="ChkBoxClass" OnCheckedChanged="CheckBox4_CheckedChanged"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_Ie15" runat="server" Text="Pemex, Defensa o Marina?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <%--<asp:RadioButton runat="server" id="radioC5" GroupName="radioC" AutoPostBack="False"/>--%>
                                    <asp:CheckBox ID="CheckBox5" runat="server" Enabled="True" AutoPostBack="true" CssClass="ChkBoxClass" OnCheckedChanged="CheckBox5_CheckedChanged"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe16" runat="server" Text="un seguro privado?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <%--<asp:RadioButton runat="server" id="radioC6" GroupName="radioC" AutoPostBack="False"/>--%>
                                    <asp:CheckBox ID="CheckBox6" runat="server" Enabled="True" AutoPostBack="true" CssClass="ChkBoxClass" OnCheckedChanged="CheckBox6_CheckedChanged"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe17" runat="server" Text="otra institución? (DIF, IMSS-PROSPERA)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                   <%-- <asp:RadioButton runat="server" id="radioC7" GroupName="radioC" AutoPostBack="False"/>--%>
                                    <asp:CheckBox ID="CheckBox7" runat="server" Enabled="True" AutoPostBack="true" CssClass="ChkBoxClass" OnCheckedChanged="CheckBox7_CheckedChanged"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe18" runat="server" Text="Entonces, ¿no está afiliada(o) a servicios médicos?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <%--<asp:RadioButton runat="server" id="radioC8" GroupName="radioC" AutoPostBack="False"/>--%>
                                    <asp:CheckBox ID="CheckBox8" runat="server" Enabled="True" AutoPostBack="true" CssClass="ChkBoxClass" OnCheckedChanged="CheckBox8_CheckedChanged"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec00702" class="col-sm-12" style="display:none;">
           <div id="DivIIIp102" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="3">
                        <asp:Label ID="lb_IIIe102e1" runat="server" Text="¿Cuál es la religión de" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe102e2" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label><asp:Label ID="lb_IIIe102e3" runat="server" Text="?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:90%;'>
                                    <asp:TextBox ID="tb_IIIe1021" runat="server" MaxLength="50" Width="60%" Font-Names="Arial" Font-Size="Small" onkeyup="soloLetrasY(this,' ');mayusculas(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:90%;'>
                                    <asp:Label ID="lb_IIIe10211" runat="server" Text="REGISTRE TEXTUAL EL NOMBRE DE LA RELIGIÓN" Font-Names="Arial" Font-Size="X-Small" ForeColor="Gray" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec00703" class="col-sm-12" style="display:none;">
           <div id="DivIIIp103" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_IIIe103e1" runat="server" Text="De acuerdo con su cultura, historia y tradiciones, ¿" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label><asp:Label ID="lb_IIIe103e2" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe103e3" runat="server" Text=" se considera negra(o), es decir, afromexicana(o) o afrodescendiente?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_IIIe1031" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="radioC1031" GroupName="radioC103" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>
 <%--               <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe1032" runat="server" Text="Sí, en parte" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioC1032" GroupName="radioC103" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>--%>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_IIIe1033" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="radioC1033" GroupName="radioC103" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>
 <%--               <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe1034" runat="server" Text="No sabe" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioC1034" GroupName="radioC103" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>--%>
               </table>
           </div>
        </div>
        <div id="Sec008" class="col-sm-12" style="display:none;">
           <div id="DivIIIp2" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_IIIe2e1" runat="server" Text="¿" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label><asp:Label ID="lb_IIIe2e2" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe2e3" runat="server" Text="habla algún dialecto o lengua indígena?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_IIIe21" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="radioD1" GroupName="radioD" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_IIIe22" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="radioD2" GroupName="radioD" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec009" class="col-sm-12" style="display:none;">
           <div id="DivIIIp3" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="3">
                        <asp:Label ID="lb_IIIe3e1" runat="server" Text="¿Qué dialecto o lengua indígena habla" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe3e2" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label><asp:Label ID="lb_IIIe3e3" runat="server" Text="?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:90%;'>
                                    <asp:TextBox ID="tb_IIIe31" runat="server" MaxLength="50" Width="60%" Font-Names="Arial" Font-Size="Small" onkeyup="soloLetrasY(this,' ');mayusculas(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:90%;'>
                                    <asp:Label ID="lb_IIIe31" runat="server" Text="REGISTRE TEXTUAL EL NOMBRE DE LA LENGUA" Font-Names="Arial" Font-Size="X-Small" ForeColor="Gray" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec010" class="col-sm-12" style="display:none;">
           <div id="DivIIIp4" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_IIIe4e1" runat="server" Text="¿" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label><asp:Label ID="lb_IIIe4e2" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe4e3" runat="server" Text="habla también español?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_IIIe41" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="radioE1" GroupName="radioE" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_IIIe42" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="radioE2" GroupName="radioE" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec011" class="col-sm-12" style="display:none;">
           <div id="DivIIIp5" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_IIIe5e1" runat="server" Text="¿" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label><asp:Label ID="lb_IIIe5e2" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe5e3" runat="server" Text="asiste actualmente a la escuela?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_IIIe51" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="radioF1" GroupName="radioF" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_IIIe52" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="radioF2" GroupName="radioF" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec012" class="col-sm-12" style="display:none;">
           <div id="DivIIIp6" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_IIIe6e1" runat="server" Text="¿Cuál es el último año o grado que aprobó" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe6e2" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe6e3" runat="server" Text="en la escuela?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
               <tr>
                    <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_IIIe6e1bis" runat="server" Text="SELECCIONE EL NIVEL DE ESTUDIO Y REGISTRE EL ÚLTIMO GRADO APROBADO" Font-Names="Arial" Font-Size="X-Small" ForeColor="Gray" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:Label ID="Label5" runat="server" Text="NIVEL / GRADO" Font-Names="Arial" Font-Size="X-Small" ForeColor="Black" Font-Bold="True" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe61" runat="server" Text="Ninguno" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioG1" GroupName="radioG" AutoPostBack="True" OnCheckedChanged="radioG1_CheckedChanged"/>&nbsp;
                                    <asp:TextBox ID="tb_IIIe61" runat="server" MaxLength="1" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe62" runat="server" Text="Preescolar o kinder" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioG2" GroupName="radioG" AutoPostBack="True" OnCheckedChanged="radioG2_CheckedChanged"/>&nbsp;
                                    <asp:TextBox ID="tb_IIIe62" runat="server" MaxLength="1" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros1(this);calle(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe63" runat="server" Text="Primaria" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioG3" GroupName="radioG" AutoPostBack="True" OnCheckedChanged="radioG3_CheckedChanged"/>&nbsp;
                                    <asp:TextBox ID="tb_IIIe63" runat="server" MaxLength="1" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros1(this);calle(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe64" runat="server" Text="Secundaria" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioG4" GroupName="radioG" AutoPostBack="True" OnCheckedChanged="radioG4_CheckedChanged"/>&nbsp;
                                    <asp:TextBox ID="tb_IIIe64" runat="server" MaxLength="1" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros1(this);calle(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe65" runat="server" Text="Preparatoria o bachillerato general" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioG5" GroupName="radioG" AutoPostBack="True" OnCheckedChanged="radioG5_CheckedChanged"/>&nbsp;
                                    <asp:TextBox ID="tb_IIIe65" runat="server" MaxLength="1" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros1(this);calle(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe66" runat="server" Text="Bachillerato tecnológico" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioG6" GroupName="radioG" AutoPostBack="True" OnCheckedChanged="radioG6_CheckedChanged"/>&nbsp;
                                    <asp:TextBox ID="tb_IIIe66" runat="server" MaxLength="1" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros1(this);calle(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe67" runat="server" Text="Estudios técnicos o comerciales con primaria terminada" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioG7" GroupName="radioG" AutoPostBack="True" OnCheckedChanged="radioG7_CheckedChanged"/>&nbsp;
                                    <asp:TextBox ID="tb_IIIe67" runat="server" MaxLength="1" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros1(this);calle(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe68" runat="server" Text="Estudios técnicos o comerciales con secundaria terminada" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioG8" GroupName="radioG" AutoPostBack="True" OnCheckedChanged="radioG8_CheckedChanged"/>&nbsp;
                                    <asp:TextBox ID="tb_IIIe68" runat="server" MaxLength="1" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros1(this);calle(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe69" runat="server" Text="Estudios técnicos o comerciales con preparatoria terminada" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioG9" GroupName="radioG" AutoPostBack="True" OnCheckedChanged="radioG9_CheckedChanged"/>&nbsp;
                                    <asp:TextBox ID="tb_IIIe69" runat="server" MaxLength="1" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros1(this);calle(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe610" runat="server" Text="Normal con primaria o secundaria terminada" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioG10" GroupName="radioG" AutoPostBack="True" OnCheckedChanged="radioG10_CheckedChanged"/>&nbsp;
                                    <asp:TextBox ID="tb_IIIe610" runat="server" MaxLength="1" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros1(this);calle(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe6111" runat="server" Text="Normal de licenciatura" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioG11" GroupName="radioG" AutoPostBack="True" OnCheckedChanged="radioG11_CheckedChanged"/>&nbsp;
                                    <asp:TextBox ID="tb_IIIe611" runat="server" MaxLength="1" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros1(this);calle(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe612" runat="server" Text="Licenciatura" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioG12" GroupName="radioG" AutoPostBack="True" OnCheckedChanged="radioG12_CheckedChanged"/>&nbsp;
                                    <asp:TextBox ID="tb_IIIe612" runat="server" MaxLength="1" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros1(this);calle(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe6113" runat="server" Text="Especialidad" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioG13" GroupName="radioG" AutoPostBack="True" OnCheckedChanged="radioG13_CheckedChanged"/>&nbsp;
                                    <asp:TextBox ID="tb_IIIe613" runat="server" MaxLength="1" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros1(this);calle(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe614" runat="server" Text="Maestría" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioG14" GroupName="radioG" AutoPostBack="True" OnCheckedChanged="radioG14_CheckedChanged"/>&nbsp;
                                    <asp:TextBox ID="tb_IIIe614" runat="server" MaxLength="1" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros1(this);calle(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe615" runat="server" Text="Doctorado" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioG15" GroupName="radioG" AutoPostBack="True" OnCheckedChanged="radioG15_CheckedChanged"/>&nbsp;
                                    <asp:TextBox ID="tb_IIIe615" runat="server" MaxLength="1" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros1(this);calle(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec013" class="col-sm-12" style="display:none;">
           <div id="DivIIIp7" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_IIIe7e1" runat="server" Text="¿" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label><asp:Label ID="lb_IIIe7e2" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe7e3" runat="server" Text=" sabe leer y escribir un recado?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_IIIe71" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="radioH1" GroupName="radioH" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_IIIe72" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="radioH2" GroupName="radioH" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec01301" class="col-sm-12" style="display:none;">
           <div id="DivIIIp1301" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_IIIe1301e1" runat="server" Text="Hace 5 años, en octubre de 2012, ¿en qué estado de la República Mexicana o en qué país vivía" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe1301e2" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label><asp:Label ID="lb_IIIe1301e3" runat="server" Text="?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:Label ID="lb_IIIe1301" runat="server" Text="Aquí en este estado" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButton runat="server" id="radioC1301" GroupName="radioC130" AutoPostBack="True" OnCheckedChanged="radioC1301_CheckedChanged"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe1302" runat="server" Text="En otro estado" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioC1302" GroupName="radioC130" AutoPostBack="True" OnCheckedChanged="radioC1302_CheckedChanged"/>&nbsp;
                                    <asp:TextBox ID="tb_IIIe1302" runat="server" MaxLength="50" Width="90%" Font-Names="Arial" Font-Size="Small" onkeyup="soloLetrasY(this,' ');mayusculas(this);" Visible="false"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:50%;' colspan="2">
                                    <asp:Label ID="lb_IIIe13021" runat="server" Text="REGISTRE TEXTUAL EL NOMBRE DEL ESTADO" Font-Names="Arial" Font-Size="X-Small" ForeColor="Gray" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:Label ID="lb_IIIe1303" runat="server" Text="En Estados Unidos de  América" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButton runat="server" id="radioC1303" GroupName="radioC130" AutoPostBack="True" OnCheckedChanged="radioC1303_CheckedChanged"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe1304" runat="server" Text="En otro país" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioC1304" GroupName="radioC130"  AutoPostBack="True" OnCheckedChanged="radioC1304_CheckedChanged"/>&nbsp;
                                    <asp:TextBox ID="tb_IIIe1304" runat="server" MaxLength="50" Width="90%" Font-Names="Arial" Font-Size="Small" onkeyup="soloLetrasY(this,' ');mayusculas(this);" Visible="false"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:50%;' colspan="2">
                                    <asp:Label ID="lb_IIIe13041" runat="server" Text="REGISTRE TEXTUAL EL NOMBRE DEL PAÍS" Font-Names="Arial" Font-Size="X-Small" ForeColor="Gray" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec01302" class="col-sm-12" style="display:none;">
           <div id="DivIIIp1302" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_IIIe1302e1" runat="server" Text="¿Actualmente" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe1302e2" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe1302e3" runat="server" Text=":" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:35%;'>
                                    <asp:Label ID="lb_IIIe130201" runat="server" Text="vive con su pareja en unión libre?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="radioC13021" GroupName="radioC1302" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:35%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe130202" runat="server" Text="está separada(o)?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioC13022" GroupName="radioC1302" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:35%;'>
                                    <asp:Label ID="lb_IIIe130203" runat="server" Text="está divorciada(o)?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="radioC13023" GroupName="radioC1302" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:35%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe130204" runat="server" Text="es viuda(o)?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioC13024" GroupName="radioC1302" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:35%;'>
                                    <asp:Label ID="lb_IIIe130205" runat="server" Text="está casada(o) sólo por el civil?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="radioC13025" GroupName="radioC1302" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:35%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe130206" runat="server" Text="está casada(o) sólo religiosamente?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioC13026" GroupName="radioC1302" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:35%;'>
                                    <asp:Label ID="Label37" runat="server" Text="está casada(o) civil y religiosamente?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="radioC13027" GroupName="radioC1302" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:35%;' class="Mibk">
                                    <asp:Label ID="Label38" runat="server" Text="está soltera(o)?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioC13028" GroupName="radioC1302" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec01401" class="col-sm-12" style="display:none;">
           <div id="DivIIIp10" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_IIIe10e1" runat="server" Text="¿" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label><asp:Label ID="lb_IIIe10e2" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe10e3" runat="server" Text=" trabajó la semana pasada?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>
                                    <asp:Label ID="lb_IIIe101" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="radioI101" GroupName="radioI10" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>
                                    <asp:Label ID="lb_IIIe102" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButton runat="server" id="radioI102" GroupName="radioI10" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:25%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec014" class="col-sm-12" style="display:none;">
           <div id="DivIIIp8" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_IIIe8e1" runat="server" Text="Aunque ya indicó que " Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe8e2" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe8e3" runat="server" Text=" no trabajó, la semana pasada:" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe81" runat="server" Text="¿Hizo o vendió algún producto para ganar dinero?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioI1" GroupName="radioI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe82" runat="server" Text="¿Ayudó en algún negocio? (Familiar o de otra persona)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioI2" GroupName="radioI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe83" runat="server" Text="¿Crio animales o cultivó? (Para la familia o venta)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioI3" GroupName="radioI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe84" runat="server" Text="¿Ofreció algún servicio para ganar dinero?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioI4" GroupName="radioI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe85" runat="server" Text="¿Atendió su propio negocio?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioI5" GroupName="radioI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe86" runat="server" Text="¿Tenía trabajo, pero no trabajó? (Incapacidad, vacaciones, lluvia, etc.)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioI6" GroupName="radioI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe87" runat="server" Text="¿Buscó trabajo?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioI7" GroupName="radioI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe88" runat="server" Text="Ninguna de las anteriores" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioI8" GroupName="radioI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec01403" class="col-sm-12" style="display:none;">
           <div id="DivIIIp12" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_IIIe12e1" runat="server" Text="Si la semana pasada, " Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe12e2" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe12e3" runat="server" Text=" no trabajó ni hizo algo para obtener un pago o ganancia, entonces:" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe121" runat="server" Text="¿Es estudiante?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioI121" GroupName="radioI12" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe122" runat="server" Text="¿Es jubilada(o) o pensionada(o)?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioI122" GroupName="radioI12" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe123" runat="server" Text="¿Se dedica a los quehaceres de su hogar?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioI123" GroupName="radioI12" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe124" runat="server" Text="¿Tiene alguna limitación física o mental que le impide trabajar?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioI124" GroupName="radioI12" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe125" runat="server" Text="Ninguna de las anteriores" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioI125" GroupName="radioI12" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
    </div>
        <div id="Sec100" class="col-sm-12" style="display:none;">
                            <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                                <tr>
                                    <td style='text-align:center;vertical-align:top;border-top:none;border-left:none;width:100%;'>
 <%--                                       <asp:Button ID="Button2" runat="server" Text="Pregunta anterior" Height="25px" onclick="Button2_Click"/>
                                        <asp:Button ID="Button3" runat="server" Text="Ayuda" Height="25px" onclick="Button3_Click"/>
                                        <asp:Button ID="Button4" runat="server" Text="Pregunta siguiente" Height="25px" onclick="Button4_Click"/>--%>
               <%--<asp:Label ID="lb_Ie1" runat="server" Text="1. PISOS" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>--%>
               <asp:LinkButton ID="atras01" runat="server" Text="" style="display:none;" CssClass="btn btn-default btn-sm" OnClick="atras01_Click" ><img src="images/16x16-Anterior.png" alt="" />&nbsp;Anterior</asp:LinkButton>
              <%--<asp:LinkButton ID="guarda01" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="guarda01_Click" ><img src="images/32x32-Guardar.png" alt="" />&nbsp;Guardar</asp:LinkButton>--%>
               <asp:LinkButton ID="adelante01" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="adelante01_Click">Siguiente&nbsp;<img src="images/16x16-Siguiente.png" alt="" /></asp:LinkButton>
<%--OnClientClick="javascript:oculta01();"--%>
                                    </td>
                                </tr>
                            </table>
        </div>
   </div>
    <div id="vmodal_error" class="modal fade">
        <div id="mensaje_error" class="alert alert-danger">
            <strong>Danger!</strong> Indicates a dangerous or potentially negative action.
        </div>
    </div>
</div>
<%--        <script type="text/javascript">
            function pageLoad(){
                $find('programmaticModalPopupBehavior').add_shown(onMPEShown);
            }
            function onMPEShown(sender,args){
                $common.setLocation($get("<%=Panel1.ClientID %>"),new Sys.UI.Point(100 ,300));
            }
        </script>--%>

</asp:Content>
