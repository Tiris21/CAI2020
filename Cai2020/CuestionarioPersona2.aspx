<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CuestionarioPersona2.aspx.cs" Inherits="Cai2020.CuestionarioPersona2" %>
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
<asp:ScriptManager ID="ScriptManager1" runat="server">
    <Scripts>
        <asp:ScriptReference Path="~/Scripts/myFunctions.js" />
    </Scripts>
</asp:ScriptManager>
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
</script>
<style type="text/css">
.Mibk
    {
    background-color:lightgrey;
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
</style>
    <br />
    <br />
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
 	               	                <td style="align-content:center; align-items:center; vertical-align:top;">
                                            <asp:Label ID="Label1" runat="server" Text="SECCIÓN: LISTA DE PERSONAS" Font-Size="X-Large" ForeColor="CadetBlue" Font-Names="Arial"></asp:Label>
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
                        <asp:Label ID="lb_IIe1e" runat="server" Text="¿Cuántas personas viven normalmente en su vivienda, incluya a los niños chiquitos y a los ancianos, también a los empleados domésticos que duermen en la misma vivienda?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
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
                                    <asp:Label ID="lb_IIe11" runat="server" Text="NÚMERO DE PERSONAS" Font-Names="Arial" Font-Size="Small" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                    <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="3">
                        <%--OnClick="agregar01a_Click" data-whatever="@mdo" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal"--%>
                       <%-- <asp:LinkButton ID="agregar01a" OnClick="agregar01a_Click" runat="server" Text="" CssClass="btn btn-default btn-sm" >Siguiente&nbsp;<img src="images/16x16-Siguiente.png" alt="" /></asp:LinkButton>--%>
                        <%--<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal" data-whatever="@mdo">Open modal for @mdo</button>--%>
                        <button type="button" id="add" class="btn btn-info">Siguiente&nbsp;<img src="images/16x16-Siguiente.png" alt="" /></button>
                        <button type="button" id="agregaotro" class="btn btn-info" style="display:none;">Agregar otro&nbsp;<img src="images/16x16-Siguiente.png" alt="" /></button>
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

        <div id="Sec004" class="col-sm-6" style="display:none;">
<%--           <div id="Div3" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
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
                                </td>
                </tr>
                <tr>
                                <td style='text-align:Left;vertical-align:top;border-top:none;width:20%;'>
                                    <asp:Label ID="lb_IIe22" runat="server" Text="Sexo" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>--%>

                                   <%-- <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="35%" Font-Bold="true" >
                                     <asp:ListItem>Hombre</asp:ListItem>
                                     <asp:ListItem>Mujer</asp:ListItem>
                                    </asp:RadioButtonList>--%>

<%--                                    <asp:Label ID="lb_IIe221" runat="server" Text="Hombre" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioA1" GroupName="radioA" AutoPostBack="False"/>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lb_IIe222" runat="server" Text="Mujer" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioA2" GroupName="radioA" AutoPostBack="False"/>
                                </td>
                </tr>
                <tr>
                                <td style='text-align:Left;vertical-align:top;border-top:none;width:20%;'>
                                    <asp:Label ID="lb_IIe23" runat="server" Text="Edad" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:TextBox ID="tb_IIe23" runat="server" MaxLength="3" Width="36px" Font-Names="Arial" Font-Size="medium" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>
                                </td>
                </tr>
                <tr>
                                <td style='text-align:Left;vertical-align:top;border-top:none;width:20%;'>
                                    <asp:Label ID="lb_IIe24" runat="server" Text="Parentesco" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>--%>

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
                                    
<%--                                    <asp:Label ID="lb_IIe241" runat="server" Text="Jefa(e)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB1" GroupName="radioB" AutoPostBack="True"/><br />
                                    <asp:Label ID="lb_IIe242" runat="server" Text="Esposa(o) o pareja" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB2" GroupName="radioB" AutoPostBack="True"/><br />
                                    <asp:Label ID="lb_IIe243" runat="server" Text="Hija(o)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB3" GroupName="radioB" AutoPostBack="True"/><br />
                                    <asp:Label ID="lb_IIe244" runat="server" Text="Nieta(o)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB4" GroupName="radioB" AutoPostBack="True"/><br />
                                    <asp:Label ID="lb_IIe245" runat="server" Text="Nuera o yerno" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB5" GroupName="radioB" AutoPostBack="True"/><br />
                                    <asp:Label ID="lb_IIe246" runat="server" Text="Madre o padre" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB6" GroupName="radioB" AutoPostBack="True"/><br />
                                    <asp:Label ID="lb_IIe247" runat="server" Text="Suegra (o)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB7" GroupName="radioB" AutoPostBack="True"/><br />
                                    <asp:Label ID="lb_IIe248" runat="server" Text="Sin parentesco" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB8" GroupName="radioB" AutoPostBack="True"/><br />
                                    <asp:Label ID="lb_IIe249" runat="server" Text="Otro (especifique)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:RadioButton runat="server" id="radioB9" GroupName="radioB" AutoPostBack="True"/>
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
           </div>--%>
        </div>
        <div id="Sec005" class="col-sm-12" style="display:none; ">
           <div id="Div4" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
<%--               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                   <tr>
                        <td style='text-align:center;vertical-align:top;border-top:none;width:100%;'>
                            <asp:Panel ID="Panel1" runat="server" Height="100%" ScrollBars="Auto" Width="100%" Visible="True">
                            <asp:GridView ID="Gvresulta" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="Medium"
                                DataKeyNames="NOMBRE" ForeColor="#333333"  
                                    AllowPaging="False" AllowSorting="False" onrowdatabound="Gvresulta_RowDataBound">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Informante">
                                       <ItemTemplate>
                                        <input name="MyRadioButton" type="radio" />
                                       </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CUENTA" DataFormatString="{0:###}" ItemStyle-Font-Size="Medium"
                                        HeaderText="No." SortExpression="CUENTA" 
                                        ItemStyle-HorizontalAlign="Right" HeaderStyle-Wrap="false">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NOMBRE" 
                                        HeaderText="Nombre" SortExpression="NOMBRE" ItemStyle-Font-Size="Medium" 
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Wrap="false">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SEXO" 
                                        HeaderText="Sexo" SortExpression="SEXO" ItemStyle-Font-Size="Medium"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Wrap="false">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EDAD" DataFormatString="{0:###}" ItemStyle-Font-Size="Medium"
                                        HeaderText="Edad" SortExpression="EDAD" 
                                        ItemStyle-HorizontalAlign="Right" HeaderStyle-Wrap="false">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PARENTESCO" ItemStyle-Font-Size="Medium"
                                        HeaderText="Parentesco" SortExpression="PARENTESCO" 
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Wrap="false">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton3" runat="server" ToolTip="Eliminar persona"
                                                ImageUrl="~/images/ico_BORRAR_chico.gif" OnCommand="ImageButton3_Command" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CUENTA") + "@" + DataBinder.Eval(Container.DataItem,"NOMBRE") + "@" + DataBinder.Eval(Container.DataItem,"SEXO") %> ' /><br />Borrar
                                        </ItemTemplate>
                                        <ItemStyle Width="25px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton4" runat="server" ToolTip="Abrir cuestionario"
                                                ImageUrl="~/images/ico_editar_chico.gif" OnCommand="ImageButton4_Command" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CUENTA") + "@" + DataBinder.Eval(Container.DataItem,"NOMBRE") + "@" + DataBinder.Eval(Container.DataItem,"SEXO") %> ' /><br />Cuestionario
                                        </ItemTemplate>
                                        <ItemStyle Width="25px" />
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
                   </tr>
               </table>--%>
                        <table id="tabla"  class="table table-striped table-bordered" >
                            <!-- Cabecera de la tabla -->
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
                                    
                                    <asp:Button id="btn_lanzarc1" class="btn btn-info" runat="server" Text="Comenzar Cuestionario(s)"  OnClick="btn_lanzarc_Click"></asp:Button>
                                </td>
                            </tr>
                        </table>
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

                        <asp:TemplateField HeaderText="NOMBRE" InsertVisible="False" SortExpression="NOMBRE">
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
                        </asp:TemplateField>
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

    </div>

    <div id="Sec0010" class="row" >
        <div id="Sec006" class="col-sm-12" style="display:none;">
          <div id="DivIIIe1enc" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:left; min-width:250px; background-color:lightgray;">
               <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                   <tr>
                       <td style='text-align:left;vertical-align:top;border-top:none;width:100%;'>
                           <asp:Label ID="lb_III" runat="server" Text="SECCIÓN: CARACTERÍSTICAS DE LAS PERSONAS" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                       </td>
                       <td style='text-align:right;vertical-align:top;border-top:none;width:100%;'>
                           <%--<asp:LinkButton ID="ayuda01" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="ayuda01_Click"><img src="images/16x16-Info.png" alt="" /></asp:LinkButton>--%>
                           <button type="button" class="btn btn-default btn-sm" id="ayuda01" runat="server"
                                   data-html="true" 
                                   data-toggle="popover" 
                                   data-placement="left"
                                    data-trigger="focus"
                                   title="<b>Ayuda</b>" 
                                   data-content="Some content">
                                   <img src="images/16x16-Info.png" alt="" />
                            </button>
                       </td>
                   </tr>
                   <tr>
                       <td colspan="2">
                           <div id="barraavance1" class="col-md-12">
                                <table id="barr" style="width:100%;" border="0" >
                                    <tr>
                                        <td style="width:70%; vertical-align:bottom">
                                            <div class="progress">
                                              <div id="barra_tot" runat="server" class="progress-bar" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax ="100" ></div>
                                            </div>
                                        </td>
                                        <td style="width:30%; vertical-align:text-top">
                                            <asp:label id="avance_tot" runat="server" style="font-size:medium; color:#3E78B3; font-family:Arial"></asp:label>
                                        </td>
                                    </tr>
                                </table>
                          </div>
                       </td>
                   </tr>
                    <tr>
                       <td colspan="2">
                           <div id="barraavance2" class="col-md-12">
                                <table id="barr2" style="width:100%;" border="0" >
                                    <tr>
                                        <td style="width:70%; vertical-align:bottom">
                                            <div class="progress">
                                              <div id="barra" runat="server" class="progress-bar progress-bar-info" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax ="100" ></div>
                                            </div>
                                        </td>
                                        <td style="width:30%; vertical-align:text-top">
                                            <asp:label id="avance" runat="server" style="font-size:medium; color:#3E78B3; font-family:Arial"></asp:label>
                                        </td>
                                    </tr>
                                </table>
                          </div>
                       </td>
                   </tr>
                   <tr>
                       <td style='text-align:center;vertical-align:top;border-top:none;width:100%;'>
                           <asp:Label ID="lb_III01" runat="server" Text="Persona elegida" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
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
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe11" runat="server" Text="el Seguro Popular o para una Nueva Generación (Siglo XXI)?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioC1" GroupName="radioC" AutoPostBack="False"/>
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
                                    <asp:RadioButton runat="server" id="radioC2" GroupName="radioC" AutoPostBack="False"/>
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
                                    <asp:RadioButton runat="server" id="radioC3" GroupName="radioC" AutoPostBack="False"/>
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
                                    <asp:RadioButton runat="server" id="radioC4" GroupName="radioC" AutoPostBack="False"/>
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
                                    <asp:RadioButton runat="server" id="radioC5" GroupName="radioC" AutoPostBack="False"/>
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
                                    <asp:RadioButton runat="server" id="radioC6" GroupName="radioC" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe17" runat="server" Text="de otra institución?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioC7" GroupName="radioC" AutoPostBack="False"/>
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
                                    <asp:RadioButton runat="server" id="radioC8" GroupName="radioC" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
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
                                    <asp:TextBox ID="tb_IIIe31" runat="server" MaxLength="50" Width="60%" Font-Names="Arial" Font-Size="Small" onkeyup="soloLetrasY(this);mayusculas(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:90%;'>
                                    <asp:Label ID="lb_IIIe31" runat="server" Text="ANOTE TEXTUAL EL NOMBRE DE LA LENGUA" Font-Names="Arial" Font-Size="Small" ForeColor="Black" BorderStyle="None"></asp:Label>
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
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe61" runat="server" Text="Ninguno (ANOTE 0)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:TextBox ID="tb_IIIe61" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>&nbsp;
                                    <%--<asp:RadioButton runat="server" id="radioG1" GroupName="radioG" AutoPostBack="False"/>--%>
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
                                    <asp:TextBox ID="tb_IIIe62" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>&nbsp;
                                    <%--<asp:RadioButton runat="server" id="radioG2" GroupName="radioG" AutoPostBack="False"/>--%>
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
                                    <asp:TextBox ID="tb_IIIe63" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>&nbsp;
                                    <%--<asp:RadioButton runat="server" id="radioG3" GroupName="radioG" AutoPostBack="False"/>--%>
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
                                    <asp:TextBox ID="tb_IIIe64" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>&nbsp;
                                    <%--<asp:RadioButton runat="server" id="radioG4" GroupName="radioG" AutoPostBack="False"/>--%>
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
                                    <asp:TextBox ID="tb_IIIe65" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>&nbsp;
                                    <%--<asp:RadioButton runat="server" id="radioG5" GroupName="radioG" AutoPostBack="False"/>--%>
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
                                    <asp:TextBox ID="tb_IIIe66" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>&nbsp;
                                    <%--<asp:RadioButton runat="server" id="radioG6" GroupName="radioG" AutoPostBack="False"/>--%>
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
                                    <asp:TextBox ID="tb_IIIe67" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>&nbsp;
                                    <%--<asp:RadioButton runat="server" id="radioG7" GroupName="radioG" AutoPostBack="False"/>--%>
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
                                    <asp:TextBox ID="tb_IIIe68" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>&nbsp;
                                    <%--<asp:RadioButton runat="server" id="radioG8" GroupName="radioG" AutoPostBack="False"/>--%>
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
                                    <asp:TextBox ID="tb_IIIe69" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>&nbsp;
                                    <%--<asp:RadioButton runat="server" id="radioG9" GroupName="radioG" AutoPostBack="False"/>--%>
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
                                    <asp:TextBox ID="tb_IIIe610" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>&nbsp;
                                    <%--<asp:RadioButton runat="server" id="radioG10" GroupName="radioG" AutoPostBack="False"/>--%>
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
                                    <asp:TextBox ID="tb_IIIe611" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>&nbsp;
                                    <%--<asp:RadioButton runat="server" id="radioG11" GroupName="radioG" AutoPostBack="False"/>--%>
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
                                    <asp:TextBox ID="tb_IIIe612" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>&nbsp;
                                    <%--<asp:RadioButton runat="server" id="radioG12" GroupName="radioG" AutoPostBack="False"/>--%>
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
                                    <asp:TextBox ID="tb_IIIe613" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>&nbsp;
                                    <%--<asp:RadioButton runat="server" id="radioG13" GroupName="radioG" AutoPostBack="False"/>--%>
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
                                    <asp:TextBox ID="tb_IIIe614" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>&nbsp;
                                    <%--<asp:RadioButton runat="server" id="radioG14" GroupName="radioG" AutoPostBack="False"/>--%>
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
                                    <asp:TextBox ID="tb_IIIe615" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>&nbsp;
                                    <%--<asp:RadioButton runat="server" id="radioG15" GroupName="radioG" AutoPostBack="False"/>--%>
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
                        <asp:Label ID="lb_IIIe7e1" runat="server" Text="¿" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label><asp:Label ID="lb_IIIe7e2" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe7e3" runat="server" Text="sabe leer y escribir un recado?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
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
        <div id="Sec014" class="col-sm-12" style="display:none;">
           <div id="DivIIIp8" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_IIIe8e1" runat="server" Text="¿La semana pasada(" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe8e2" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>&nbsp;<asp:Label ID="lb_IIIe8e3" runat="server" Text="):" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe81" runat="server" Text="trabajó?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
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
                                    <asp:Label ID="lb_IIIe82" runat="server" Text="hizo o vendió algún producto?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
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
                                    <asp:Label ID="lb_IIIe83" runat="server" Text="ayudó en algún negocio? (Familiar o de otra persona)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
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
                                    <asp:Label ID="lb_IIIe84" runat="server" Text="crió animales o cultivó algo? (En el terreno o casa, para autoconsumo o venta)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
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
                                    <asp:Label ID="lb_IIIe85" runat="server" Text="ofreció algún servicio por un pago? (Cargó bolsas, lavó autos, cuidó niñas(os), etcétera)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
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
                                    <asp:Label ID="lb_IIIe86" runat="server" Text="atendió su propio negocio?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
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
                                    <asp:Label ID="lb_IIIe87" runat="server" Text="tenía trabajo, pero no trabajó? (Por licencia, incapacidad o vacaciones)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
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
                                    <asp:Label ID="lb_IIIe88" runat="server" Text="buscó trabajo?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioI8" GroupName="radioI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe89" runat="server" Text="¿Es estudiante?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioI9" GroupName="radioI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe810" runat="server" Text="¿Es jubilada(o) o pensionada(o)?." Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioI10" GroupName="radioI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe811" runat="server" Text="¿Se dedica a los quehaceres de su hogar?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioI11" GroupName="radioI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_IIIe812" runat="server" Text="¿Tiene alguna limitación física o mental que le impide trabajar?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioI12" GroupName="radioI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_IIIe813" runat="server" Text="¿No trabajó?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioI13" GroupName="radioI" AutoPostBack="False"/>
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
              <asp:LinkButton ID="guarda01" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="guarda01_Click" ><img src="images/32x32-Guardar.png" alt="" />&nbsp;Guardar</asp:LinkButton>
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
</asp:Content>
