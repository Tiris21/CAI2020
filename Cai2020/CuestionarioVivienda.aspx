<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CuestionarioVivienda.aspx.cs" Inherits="Cai2020.CuestionarioVivienda" %>
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
            $(':text').focus(function () {
                $(this).css("background-color", "LightSteelBlue");
            });
            $(':text').blur(function () {
                $(this).css("background-color", "white");
            });
            $('[data-toggle="popover"]').popover();
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
  <%--  <script type="text/javascript">
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

    //function openModal() {
    //    //$('#vmodal_error').modal('show');
    //    $('#vmodal_error').modal();
    //};
    function abrirModal(tipo) {
        //$('ayuda_modal').innerhtml = tipo;
        $('#vmodal_ayuda').modal();
    }
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
        OnCancelScript="hideModalPopupViaClient" CancelControlID="LinkButton3" />
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
				    <td style='text-align:center;vertical-align:top;border-top:none;'><h2 class="modal-title"><asp:label id="Label17" runat="server" Text="Aviso"></asp:label></h2></td>
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
				    <td style='text-align:center;vertical-align:top;border-top:none;'><asp:label id="Label10" runat="server" Text="No proporcionó respuesta a esta pregunta" style="font-size:large; color:black; font-family:Arial"></asp:label></td>
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
				    <td style='text-align:center;vertical-align:top;border-top:none;'><asp:LinkButton ID="LinkButton3" runat="server" Text="" CssClass="btn btn-default btn-sm" >Cerrar</asp:LinkButton></td>
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
        OnCancelScript="hideModalPopupViaClient2" CancelControlID="LinkButton1" />
            <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup2" Style="display: none;
                padding: 0px; " HorizontalAlign="Justify" Width="80%" Height="80%" ScrollBars="Auto" >
                <div id="Div20" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; background-color:white;">
				  <table style="border:0;width:100%;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
				   <tr>
				    <td style='text-align:center;vertical-align:top;border-top:none;width:30%;'><asp:Image ID="Image1" CssClass="Imagen" runat="server"/> </td>
				   </tr>
				   <tr>
				    <td style='text-align:center;vertical-align:top;border-top:none;'><asp:LinkButton ID="LinkButton1" runat="server" Text="" CssClass="btn btn-default btn-sm" >Continuar</asp:LinkButton></td>
				   </tr>
				  </table>
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
        OnCancelScript="hideModalPopupViaClient3" CancelControlID="LinkButton100" />
            <asp:Panel runat="server" CssClass="modalPopup" ID="programmaticPopup3" Style="display: none;
                padding: 0px; background-color:white;border:1px solid #666; " HorizontalAlign="Justify" Width="80%" Height="60%" ScrollBars="Auto" >
                <div id="Div200" runat="server" visible="true" style="height:100%; width:100%;">
                  <div style="text-align:right;"><a href="#" onclick="javascript:hideModalPopupViaClient3()"><img src="Images/32x32-Cerrar.png" alt="" border="0"/></a></div>
				  <table style="border:0;width:100%;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
				   <tr>
				    <td style='text-align:center;vertical-align:top;border-top:none;width:100%;'><asp:Image ID="Image100" CssClass="Imagen" runat="server"/> </td>
				   </tr>
				   <tr>
				    <td style='text-align:center;vertical-align:top;border-top:none;'><asp:LinkButton ID="LinkButton100" runat="server" Text="" CssClass="btn btn-default btn-sm" >Cerrar ayuda</asp:LinkButton></td>
				   </tr>
				  </table>
                </div>
     	           <asp:UpdatePanel ID="ContentUpdatePanel3" runat="server">
     	           </asp:UpdatePanel>
            </asp:Panel>
<script type="text/javascript">
function showModalPopupViaClient3() {
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
    <div id="vmodal_ayuda" class = "modal fade"  runat="server">
        <div id="ayuda_modal" class="alert alert-danger"  runat="server"></div>
    </div>
    <div id="Sec001" class="row">
        <div id="Sec004A" class="col-sm-12" style="display:none;">
          <div id="DivIe1enca" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:left; min-width:250px; background-color:lightgray;">
               <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                   <tr>
                       <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                           <asp:Label ID="lb_Ia" runat="server" Text="IDENTIFICACIÓN DEL DOMICILIO" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                       </td>
                       <td style='text-align:right;vertical-align:top;border-top:none;width:45%;'>
                           <div id="barraavance1" class="col-md-12">
                                <table id="barr" style="width:100%;" border="0" >
                                    <tr>
                                        <td style="width:70%; vertical-align:bottom">
                                            <div class="progress">
                                              <div id="barra" runat="server" class="progress-bar progress-bar-custom" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax ="100" ></div>
                                            </div>
                                        </td>
                                        <td style="width:30%; vertical-align:text-top;">
                                            <asp:label id="avance" runat="server" style="font-size:smaller; color:#3E78B3; font-family:Arial"></asp:label>
                                        </td>
                                    </tr>
                                </table>
                          </div>
                       </td>
                       <td style='text-align:right;vertical-align:top;border-top:none;width:5%;'>
                           <%--OnClick="ayuda01_Click" --%>
                           <%--data-trigger="focus"--%>
                           <%--class="btn btn-default btn-sm"--%>
                           <button type="button"  id="ayuda01a" runat="server" style="border:none;background-color:transparent;"
                                   data-html="true" 
                                   data-toggle="popover" 
                                   data-placement="bottom"
                                   title="<b>Ayuda</b>" 
                                   data-content="Some content">
                                   <img src="images/informacion30.png" alt="" style="border:none;background-color:transparent;" />
                            </button>
<%--                           <button type="button"  id="Button2" runat="server" style="border:none;background-color:transparent;" onclick="showModalPopupViaClient3()" title="Ayuda">
                                   <img src="images/informacion30.png" alt="" style="border:none;background-color:transparent;" />
                            </button>--%>
<%--                           <button type="button"  id="Button2" runat="server" style="border:none;background-color:transparent;" onclick="var ancho = window.innerWidth - 200;var alto = window.innerHeight - 300;var izquierda = (screen.width  / 2)-(ancho / 2);var arriba = (screen.height / 2)-(alto  / 2);window.open('Casa_Unica_A.html','_blank','height='+alto+',left='+izquierda+',location=no,menubar=no,resizable=yes,scrollbars=yes,status=no,titlebar=no,toolbar=no,top='+arriba+',width='+ancho);" title="Ayuda">
                                   <img src="images/informacion30.png" alt="" style="border:none;background-color:transparent;" />
                            </button>--%>
                          <%--<asp:LinkButton ID="ayuda01a" runat="server" Text="" CssClass="btn btn-default btn-sm" 
                                   data-html="true" 
                                   data-toggle="popover" 
                                   data-placement="left"
                                   title="<b>Ayuda</b>" 
                                   data-content="Some content">
                               <img src="images/16x16-Info.png" alt="" />
                           </asp:LinkButton>--%>
                       </td>
                   </tr>
               </table>
           </div>
        </div>

        <div id="Sec004B" class="col-sm-12" style="display:none;">
          <div id="Div11" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:left; min-width:250px; background-color:lightgray;">
               <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                   <tr>
                       <td style='text-align:center;vertical-align:top;border-top:none;width:100%;'>
                           <%--<asp:Label ID="Label11" runat="server" Text="CORTINILLA" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>--%>
                           <img alt="Brand" id="foto" src="Images/encon.png"/>
                       </td>
                   </tr>
               </table>
           </div>
        </div>

        <div id="Sec004C" class="col-sm-12" style="display:none;">
          <div id="Div12" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:left; min-width:250px; background-color:lightgray;">
               <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                   <tr>
                       <td style='text-align:center;vertical-align:top;border-top:none;width:100%;'>
                           <%--<asp:Label ID="Label11" runat="server" Text="CORTINILLA" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>--%>
                           <img alt="Brand" id="foto1" class="Imagen" src="Images/Cortinilla1.jpg"/>
                       </td>
                   </tr>
               </table>
           </div>
        </div>

        <div id="Sec004R" class="col-sm-12" style="display:none;">
           <div id="Div14" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label11" runat="server" Text="Seleccionó vivienda colectiva, ¿es correcta su respuesta?" Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="LinkButton2" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Si01_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Si</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton5" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="No01_Click" ><img src="images/32x32-Eliminar.png" alt="" />&nbsp;No</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>

        <div id="Sec004S" class="col-sm-12" style="display:none;">
           <div id="Div15" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label12" runat="server" Text="Entonces, ¿nadie vive o duerme en esta vivienda (local)?" Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="LinkButton6" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Si02_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Si</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton7" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="No02_Click" ><img src="images/32x32-Eliminar.png" alt="" />&nbsp;No</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>

        <div id="Sec004S1" class="col-sm-12" style="display:none;">
           <div id="Div17" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label13" runat="server" Text="El total de cuartos en la vivienda no puede ser menor al número de cuartos utilizados para dormir" Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="LinkButton8" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Si03_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Continuar</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>

        <div id="Sec004S2" class="col-sm-12" style="display:none;">
           <div id="Div19" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="2">
                        <asp:Label ID="Label14" runat="server" Text="Al no contar con personas que vivan o duerman normalmente en el domicilio, se da por concluido el cuestionario; este domicilio puede ser visitado posteriormente para su verificación" Font-Names="Arial" Font-Size="medium" Font-Bold="False" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' colspan="2">
                                    <asp:LinkButton ID="LinkButton10" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Si04_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Continuar</asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>

        <div id="Sec002" class="col-sm-12" style="display:none;">
            <div id="Div1" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;">
                    <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                    <tr>
                        <td style="align-content:center; align-items:center; text-align:center; vertical-align:top; width:100%;" >
                            <table style="width:100%;">
                                <tr>
 	               	                <td style="align-content:center; align-items:center; vertical-align:top;">
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
                        <td style="align-content:center; align-items:center; text-align:center; vertical-align:top; width:100%;">
                            <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                                <tr>
                                    <td style='text-align:center;vertical-align:top;border-top:none;width:20%;'>

                                    </td>
                                    <td style='text-align:left;vertical-align:top;border-top:none;border-left:none;width:60%;'>
                                            <p style="font-size:medium; color:Black;">
                                                Calle: <asp:Label ID="lb_calle" runat="server" Text="Desplegar nombre de calle" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                                    <br />
                                                Número Exterior: <asp:Label ID="lb_numext" runat="server" Text="Despelgar número exterior" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                                    <br />
                                                Número Interior: <asp:Label ID="lb_numint" runat="server" Text="Desplegar número interior" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                                    <br />
<%--                                                Fraccionamiento o Colonia: <asp:Label ID="lb_colonia" runat="server" Text="Desplegar colonia" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                                    <br />--%>
                                                Localidad: <asp:Label ID="lb_localidad" runat="server" Text="Desplegar localidad" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                                    <br />
                                                Municipio: <asp:Label ID="lb_municipio" runat="server" Text="Desplegar municipio" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                                    <br />
                                                Entidad: <asp:Label ID="lb_entidad" runat="server" Text="Desplegar entidad" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                            </p>
                                    </td>
                                    <td style='text-align:center;vertical-align:top;border-top:none;border-left:none;width:20%;'>

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    </table>
            </div>
        </div>
                            <%--<asp:LinkButton ID="btnExample" runat="server" Text="<i class='glyphicon glyphicon-circle-arrow-right'></i> " CssClass="btn btn-primary btn-xs" ></asp:LinkButton>--%>
                            <%--<asp:Button ID="Button1" runat="server" Text="<i class='glyphicon glyphicon-circle-arrow-right'></i>" CssClass="btn btn-primary btn-xs" Height="25px" onclick="Button1_Click"/>--%>
        <div id="Sec002a" class="col-sm-12" style="display:none;">
            <div id="Div9" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;">
                    <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                    <tr>
                        <td style="align-content:center; align-items:center; text-align:center; vertical-align:top; width:100%;" >
                            <table style="width:100%;">
                                <tr>
 	               	                <td style="align-content:center; align-items:center; vertical-align:top;">
                                            <asp:Label ID="Label7" runat="server" Text="Domicilio de la Vivienda" Font-Size="X-Large" ForeColor="CadetBlue" Font-Names="Arial"></asp:Label>
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
                        <td style="align-content:center; align-items:center; text-align:center; vertical-align:top; width:100%;">
                            <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                                <tr>
                                    <td style='text-align:center;vertical-align:top;border-top:none;width:20%;'>

                                    </td>
                                    <td style='text-align:left;vertical-align:top;border-top:none;border-left:none;width:60%;'>
                                            <p style="font-size:medium; color:Black;">
                                                Calle: <asp:TextBox ID="tb_calle" runat="server" MaxLength="250" Width="60%" Height="30px" Font-Names="Arial" Font-Size="Small" onkeyup="mayusculas(this);"></asp:TextBox>
                                                    <br />
                                                    <br />
                                                Número Exterior: <asp:TextBox ID="tb_numext" runat="server" MaxLength="6" Width="72px" Height="30px" Font-Names="Arial" Font-Size="Small" onkeyup="mayusculas(this);"></asp:TextBox>
                                                    <br />
                                                    <br />
                                                Número Interior: <asp:TextBox ID="tb_numint" runat="server" MaxLength="6" Width="72px" Height="30px" Font-Names="Arial" Font-Size="Small" onkeyup="mayusculas(this);"></asp:TextBox>
                                                    <br />
                                                    <br />
<%--                                                Fraccionamiento o Colonia: <asp:Label ID="lb_colonia" runat="server" Text="Desplegar colonia" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                                    <br />--%>
                                                Localidad: <asp:TextBox ID="tb_localidad" runat="server" MaxLength="70" Width="60%" Height="30px" Font-Names="Arial" Font-Size="Small" onkeyup="mayusculas(this);"></asp:TextBox>
                                                    <br />
                                                    <br />
                                                Municipio: <asp:TextBox ID="tb_municipio" runat="server" MaxLength="50" Width="60%" Height="30px" Font-Names="Arial" Font-Size="Small" onkeyup="mayusculas(this);"></asp:TextBox>
                                                    <br />
                                                    <br />
                                                Entidad: <asp:TextBox ID="tb_entidad" runat="server" MaxLength="60" Width="60%" Height="30px" Font-Names="Arial" Font-Size="Small" onkeyup="mayusculas(this);"></asp:TextBox>
                                            </p>
                                    </td>
                                    <td style='text-align:center;vertical-align:top;border-top:none;border-left:none;width:20%;'>

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    </table>
            </div>
        </div>
        <div id="Sec004" class="col-sm-12" style="display:none;">
          <div id="DivIe1enc" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:left; min-width:250px;  background-color:lightgray;">
               <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                   <tr>
                       <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                           <asp:Label ID="lb_I" runat="server" Text="SECCIÓN I. CARACTERÍSTICAS DE LA VIVIENDA" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                       </td>
<%--                       <td style='text-align:right;vertical-align:top;border-top:none;width:100%;'>
                           <asp:LinkButton ID="ayuda01" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="ayuda01_Click"><img src="images/16x16-Info.png" alt="" /></asp:LinkButton>
                       </td>
                   </tr>--%>
                       <td style='text-align:right;vertical-align:top;border-top:none;width:45%;'>
                           <div id="barraavance2" class="col-md-12">
                                <table id="barr2" style="width:100%;" border="0" >
                                    <tr>
                                        <td style="width:70%; vertical-align:bottom">
                                            <div class="progress">
                                              <div id="barra1" runat="server" class="progress-bar progress-bar-custom" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax ="100" ></div>
                                            </div>
                                        </td>
                                        <td style="width:30%; vertical-align:text-top">
                                            <asp:label id="avance1" runat="server" style="font-size:smaller; color:#3E78B3; font-family:Arial"></asp:label>
                                        </td>
                                    </tr>
                                </table>
                          </div>
                       </td>
                       <td style='text-align:right;vertical-align:top;border-top:none;width:15%;'>
                           <%--OnClick="ayuda01_Click" --%>
                           <%--data-trigger="focus"--%>
<%--                           <button type="button" class="btn btn-default btn-sm" id="Button1" runat="server"
                                   data-html="true" 
                                   data-toggle="popover" 
                                   data-placement="left"
                                    data-trigger="focus"
                                   title="<b>Ayuda</b>" 
                                   data-content="Some content">
                                   <img src="images/informacion24.png" alt="" />
                            </button>--%>
                            
                            <button type="button" id="Button1" runat="server" style="border:none;background-color:transparent;"
                                   data-html="true" 
                                   data-toggle="popover" 
                                   data-placement="bottom"
                                   title="<b>Ayuda</b>" 
                                   data-content="Some content">
                                   <img src="images/informacion30.png" alt="" style="border:none;background-color:transparent;"/>
                            </button>
<%--                            <button type="button" id="Button1" runat="server" style="border:none;background-color:transparent;" onclick="showModalPopupViaClient3()" title="Ayuda">
                                   <img src="images/informacion30.png" alt="" style="border:none;background-color:transparent;"/>
                            </button>--%>
                            <%--<asp:ImageButton ID="ImageButton1" ImageUrl='images/informacion30.png' ToolTip='Ayuda vivienda' runat="server" onclick="ImageButton101_Click"/>--%>
                          <%--<asp:LinkButton ID="ayuda01a" runat="server" Text="" CssClass="btn btn-default btn-sm" 
                                   data-html="true" 
                                   data-toggle="popover" 
                                   data-placement="left"
                                   title="<b>Ayuda</b>" 
                                   data-content="Some content">
                               <img src="images/informacion24.png" alt="" />
                           </asp:LinkButton>--%>
                       </td>
                   </tr>
               </table>
           </div>
        </div>
        <div id="Sec004q" class="col-sm-12" style="display:none;">
           <div id="Div10" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;'>
                        <asp:Label ID="Label9" runat="server" Text="" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
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
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;'>
                                    <asp:LinkButton ID="LinkButton4" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="LinkButton4_Click" ><img src="images/32x32-Aceptar.png" alt="" />&nbsp;Aceptar</asp:LinkButton><%--&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton5" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Guardar_todop_Click" ><img src="images/32x32-Eliminar.png" alt="" />&nbsp;No</asp:LinkButton>--%>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec004q2" class="col-sm-12" style="display:none;">
           <div id="Div16" runat="server" visible="true" style="height:100%; width:100%;align-content:center;align-items:center;align-self:center; text-align:center;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:center;vertical-align:top;border-top:none;width:100%;' >
                        <asp:Image ID="Image4" ImageUrl="Images/Cortinilla1.JPG" style='display:block; margin: 0 auto; width: 100%;' runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:100%;'>
                                   <%--<asp:LinkButton ID="LinkButton8" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="atras02_Click" ><img src="images/16x16-Anterior.png" alt="" />&nbsp;Anterior</asp:LinkButton>--%>
                                   <asp:LinkButton ID="LinkButton9" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="adelante02_Click">Siguiente&nbsp;<img src="images/16x16-Siguiente.png" alt="" /></asp:LinkButton>
                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec003" class="col-sm-12" style="display:none;">
           <%--<asp:Label ID="lb_6" runat="server" Text="Clase de vivienda particular" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>--%>
           <div id="Div2" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
<%--                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:20%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                                    <asp:Label ID="lb_61" runat="server" Text="Casa única en el terreno" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_62" runat="server" Text="Casa que comparte terreno con otra(s)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_63" runat="server" Text="Casa dúplex, triple o cuádruple" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_64" runat="server" Text="Departamento en edificio" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_65" runat="server" Text="Vivienda en vecindad o cuartería" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_66" runat="server" Text="Cuarto en la azotea de un edificio" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Vertical" TextAlign="Left" Width="100%">
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:20%;'>

                                </td>
                </tr>--%>
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="Label6" runat="server" Text="¿Con cuál de las siguientes opciones se identifica mejor el domicilio en donde recibió la invitación?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_61" runat="server" Text="Casa única en el terreno" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioA1" GroupName="radioA" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_62" runat="server" Text="Casa que comparte terreno con otra(s)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioA2" GroupName="radioA" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="Label2" runat="server" Text="Casa dúplex, triple o cuádruple" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioA3" GroupName="radioA" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="Label3" runat="server" Text="Departamento en edificio" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioA4" GroupName="radioA" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="Label4" runat="server" Text="Vivienda en vecindad o cuartería" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioA5" GroupName="radioA" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="Label5" runat="server" Text="Cuarto en la azotea de un edificio" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioA6" GroupName="radioA" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="Label8" runat="server" Text="Local no construido para habitación" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioA7" GroupName="radioA" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>

        <div id="Sec003A" class="col-sm-12" style="display:none;">
           <%--<asp:Label ID="lb_601" runat="server" Text="Identificación de la vivienda" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>--%>
           <div id="Div3" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;">
               <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_I01" runat="server" Text="¿El domicilio es correcto?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_I011" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_I012" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Vertical" TextAlign="Left" Width="100%" >
                                     <asp:ListItem Value="si"></asp:ListItem>
                                     <asp:ListItem Value="no"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec003B" class="col-sm-12" style="display:none;">
           <%--<asp:Label ID="lb_602" runat="server" Text="Identificación de la vivienda" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>--%>
           <div id="Div4" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;">
               <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_I02" runat="server" Text="Seleccione el tipo de inmueble" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_I021" runat="server" Text="Vivienda particular" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioZ11" GroupName="radioZ1" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_I022" runat="server" Text="Vivienda particular con local(es)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioZ12" GroupName="radioZ1" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_I023" runat="server" Text="Vivienda colectiva" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioZ13" GroupName="radioZ1" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_I024" runat="server" Text="Local" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioZ14" GroupName="radioZ1" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec003C" class="col-sm-12" style="display:none;">
           <%--<asp:Label ID="lb_603" runat="server" Text="Identificación de la vivienda" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>--%>
           <div id="Div5" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;">
               <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_I03" runat="server" Text="En el domicilio donde recibió la invitación, ¿cuántas viviendas hay?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:TextBox ID="tb_I031" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_I031" runat="server" Text="NÚMERO DE VIVIENDAS EN EL DOMICILIO" Font-Names="Arial" Font-Size="X-Small" ForeColor="Gray" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec003D" class="col-sm-12" style="display:none;">
           <%--<asp:Label ID="lb_604" runat="server" Text="Identificación de la vivienda" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>--%>
           <div id="Div6" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;">
               <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_I04" runat="server" Text="En este domicilio, considerando el número exterior e interior ¿cuántos locales hay?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:TextBox ID="tb_I041" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_I041bis" runat="server" Text="NÚMERO DE LOCALES EN EL DOMICILIO" Font-Names="Arial" Font-Size="X-Small" ForeColor="Gray" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec003E" class="col-sm-12" style="display:none;">
           <%--<asp:Label ID="lb_605" runat="server" Text="Identificación de la vivienda" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>--%>
           <div id="Div7" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;">
               <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_I05" runat="server" Text="En el domicilio donde recibió la invitación, ¿vive o duerme normalmente alguna persona?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_I051" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_I052" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Vertical" TextAlign="Left" Width="100%" >
                                     <asp:ListItem Value="si"></asp:ListItem>
                                     <asp:ListItem Value="no"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec003F" class="col-sm-12" style="display:none;">
           <%--<asp:Label ID="lb_606" runat="server" Text="Identificación de la vivienda" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>--%>
           <div id="Div8" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%;">
               <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_I06" runat="server" Text="Seleccione el motivo por el cual el domicilio donde recibió la invitación no se encuentra habitado." Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_I061" runat="server" Text="Sólo ocasionalmente o por temporada (vacaciones, fines de semana, etc.)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:right;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioZ21" GroupName="radioZ2" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_I062" runat="server" Text="Se encuentra desocupado actualmente (por reparación o espera para su venta, renta o futura ocupación, etc.)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:right;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioZ22" GroupName="radioZ2" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>

    </div>
    <div id="Sec0010" class="row" >
        <%--<asp:Label ID="lb_I" runat="server" Text="Características de la vivienda" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>--%>
<%--        <div id="Sec004" class="col-sm-12" style="display:none;">
           
          <div id="DivIe1enc" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:left; min-width:250px;  background-color:lightgray;">
               <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                   <tr>
                       <td style='text-align:left;vertical-align:top;border-top:none;width:100%;'>
                           <asp:Label ID="lb_I" runat="server" Text="SECCIÓN: CARACTERÍSTICAS DE LA VIVIENDA" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                       </td>
                       <td style='text-align:right;vertical-align:top;border-top:none;width:100%;'>
                           <asp:LinkButton ID="ayuda01" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="ayuda01_Click"><img src="images/16x16-Info.png" alt="" /></asp:LinkButton>
                       </td>
                   </tr>
               </table>
           </div>
        </div>--%>
            
        <%--<div id="Sec005" class="col-sm-3">--%>
        <div id="Sec005" class="col-sm-12" style="display:none;">
            <div id="DivIp1" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_Ie1e" runat="server" Text="¿De qué material es la mayor parte del piso de su vivienda?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
<%--                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:85%;'>
                                    <asp:Label ID="lb_Ie11" runat="server" Text="Tierra" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie12" runat="server" Text="Cemento o firme" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie13" runat="server" Text="Mosaico, madera u otro recubrimiento" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:5%;'>
                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Vertical" TextAlign="Left" Width="100%" >
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>--%>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_Ie11" runat="server" Text="Tierra" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioB1" GroupName="radioB" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_Ie12" runat="server" Text="Cemento o firme" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioB2" GroupName="radioB" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_Ie13" runat="server" Text="Mosaico, madera u otro recubrimiento" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioB3" GroupName="radioB" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
 <%--          <div id="DivIe1" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">

           </div>--%>
        </div>
        <%--<div id="Sec006" class="col-sm-3">--%>
        <div id="Sec006" class="col-sm-12" style="display:none;">
<%--           <div id="DivIe2" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie2" runat="server" Text="2. DORMITORIOS" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>--%>
           <div id="DivIp2" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="3">
                        <asp:Label ID="lb_Ie2e" runat="server" Text="¿Cuántos cuartos se usan para dormir sin contar pasillos?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:TextBox ID="tb_Ie21" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>
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
        </div>
        <%--<div id="Sec007" class="col-sm-3">--%>
        <div id="Sec007" class="col-sm-12" style="display:none;">
<%--           <div id="DivIe3" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie3" runat="server" Text="3. CUARTOS" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>--%>
           <div id="DivIp3" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="3">
                        <asp:Label ID="lb_Ie3e" runat="server" Text="¿Cuántos cuartos tiene en total su vivienda contando la cocina? (No cuente pasillos ni baños)" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:TextBox ID="tb_Ie31" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie31" runat="server" Text="REGISTRE CON NÚMERO" Font-Names="Arial" Font-Size="X-Small" ForeColor="Gray" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <%--<div id="Sec008" class="col-sm-3">--%>
        <div id="Sec008" class="col-sm-12" style="display:none;">
<%--           <div id="DivIe4" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie4" runat="server" Text="4. ELECTRICIDAD" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>--%>
           <div id="DivIp4" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_Ie4e" runat="server" Text="¿Hay luz eléctrica en su vivienda?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_Ie41" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie42" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Vertical" TextAlign="Left" Width="100%" >
                                     <asp:ListItem Value="si"></asp:ListItem>
                                     <asp:ListItem Value="no"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>

    </div>
    <div id="Sec0011" class="row">
        <%--<div id="Sec009" class="col-sm-4">--%>
        <div id="Sec009" class="col-sm-12" style="display:none;">
<%--           <div id="DivIe5" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie5" runat="server" Text="5. AGUA ENTUBADA" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>--%>
           <div id="DivIp5" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_Ie5e" runat="server" Text="¿El agua la obtienen de llaves o mangueras que están:" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
<%--                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:85%;'>
                                    <asp:Label ID="lb_Ie51" runat="server" Text="dentro de la vivienda?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie52" runat="server" Text="sólo en el patio o terreno?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie53" runat="server" Text="¿No tienen agua entubada?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:5%;'>
                                    <asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Vertical" TextAlign="Left" Width="100%" >
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>--%>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_Ie51" runat="server" Text="dentro de la vivienda?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
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
                                    <asp:Label ID="lb_Ie52" runat="server" Text="sólo en el patio o terreno?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
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
                                    <asp:Label ID="lb_Ie53" runat="server" Text="¿No tienen agua entubada?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioC3" GroupName="radioC" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <%--<div id="Sec010" class="col-sm-4">--%>
        <div id="Sec010" class="col-sm-12" style="display:none;">
<%--           <div id="DivIe6" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie6" runat="server" Text="6. ABASTECIMIENTO DE AGUA" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>--%>
           <div id="DivIp6" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_Ie6e" runat="server" Text="¿El agua entubada que llega a su vivienda viene:" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
<%--                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:85%;'>
                                    <asp:Label ID="lb_Ie61" runat="server" Text="del servicio público de agua?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie62" runat="server" Text="de un pozo comunitario?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie63" runat="server" Text="de un pozo particular?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie64" runat="server" Text="de una pipa?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie65" runat="server" Text="de otra vivienda?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie66" runat="server" Text="de otro lugar?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:5%;'>
                                    <asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatDirection="Vertical" TextAlign="Left" Width="100%" >
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>--%>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_Ie61" runat="server" Text="del servicio público de agua?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioD1" GroupName="radioD" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_Ie62" runat="server" Text="de un pozo comunitario?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioD2" GroupName="radioD" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_Ie63" runat="server" Text="de un pozo particular?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioD3" GroupName="radioD" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_Ie64" runat="server" Text="de una pipa?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioD4" GroupName="radioD" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_Ie65" runat="server" Text="de otra vivienda?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioD5" GroupName="radioD" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_Ie66" runat="server" Text="de otro lugar?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioD6" GroupName="radioD" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <%--<div id="Sec011" class="col-sm-4">--%>
        <div id="Sec011" class="col-sm-12" style="display:none;">
<%--           <div id="DivIe7" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie7" runat="server" Text="7. DOTACIÓN DE AGUA" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>--%>
           <div id="DivIp7" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_Ie7e" runat="server" Text="Entonces, ¿acarrean el agua de:" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_Ie71" runat="server" Text="un pozo?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioE1" GroupName="radioE" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_Ie72" runat="server" Text="una llave comunitaria?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioE2" GroupName="radioE" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_Ie73" runat="server" Text="otra vivienda?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioE3" GroupName="radioE" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_Ie74" runat="server" Text="un río, arroyo o lago?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioE4" GroupName="radioE" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_Ie75" runat="server" Text="¿La trae una pipa?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioE5" GroupName="radioE" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_Ie76" runat="server" Text="¿La captan de la lluvia?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioE6" GroupName="radioE" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>

    </div>
    <div id="Sec0012" class="row">
        <%--<div id="Sec012" class="col-sm-3">--%>
        <div id="Sec012" class="col-sm-12" style="display:none;">
<%--           <div id="DivIe8" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie8" runat="server" Text="8. AGUA NO ENTUBADA" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>--%>
           <div id="DivIp8" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_Ie8e" runat="server" Text="Entonces, ¿acarrean el agua de:" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
<%--                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:85%;'>
                                    <asp:Label ID="lb_Ie81" runat="server" Text="un pozo?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie82" runat="server" Text="una llave comunitaria?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie83" runat="server" Text="otra vivienda?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie84" runat="server" Text="un río, arroyo o lago?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie85" runat="server" Text="¿La trae una pipa?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie86" runat="server" Text="¿La captan de la lluvia?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:5%;'>
                                    <asp:RadioButtonList ID="RadioButtonList7" runat="server" RepeatDirection="Vertical" TextAlign="Left" Width="100%" >
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>--%>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_Ie81" runat="server" Text="un pozo?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioF1" GroupName="radioF" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_Ie82" runat="server" Text="una llave comunitaria?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioF2" GroupName="radioF" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_Ie83" runat="server" Text="otra vivienda?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioF3" GroupName="radioF" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_Ie84" runat="server" Text="un río, arroyo o lago?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioF4" GroupName="radioF" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_Ie85" runat="server" Text="¿La trae una pipa?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioF5" GroupName="radioF" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_Ie86" runat="server" Text="¿La captan de la lluvia?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioF6" GroupName="radioF" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <%--<div id="Sec013" class="col-sm-5">--%>
        <div id="Sec013" class="col-sm-12" style="display:none;">
<%--           <div id="DivIe9" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie9" runat="server" Text="9. EQUIPAMIENTO" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>--%>
           <div id="DivIp9" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="5">
                        <asp:Label ID="lb_Ie9e" runat="server" Text="¿En su vivienda tienen:" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                                    <asp:Label ID="lb_Ie91" runat="server" Text="tinaco?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie91a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioYA1" GroupName="radioYA" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_Ie91b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioYA2" GroupName="radioYA" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;' class="Mibk">
                                    <asp:Label ID="lb_Ie92" runat="server" Text="cisterna o aljibe?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie92a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioYB1" GroupName="radioYB" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:Label ID="lb_Ie92b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioYB2" GroupName="radioYB" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                                    <asp:Label ID="lb_Ie93" runat="server" Text="bomba de agua?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie93a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioYC1" GroupName="radioYC" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_Ie93b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioYC2" GroupName="radioYC" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;' class="Mibk">
                                    <asp:Label ID="lb_Ie94" runat="server" Text="regadera?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie94a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioYD1" GroupName="radioYD" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:Label ID="lb_Ie94b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioYD2" GroupName="radioYD" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                                    <asp:Label ID="lb_Ie95" runat="server" Text="lavabo?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie95a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioYE1" GroupName="radioYE" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_Ie95b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioYE2" GroupName="radioYE" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;' class="Mibk">
                                    <asp:Label ID="lb_Ie96" runat="server" Text="boiler o calentador de agua? (Gas, eléctrico, leña)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie96a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioYF1" GroupName="radioYF" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:Label ID="lb_Ie96b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioYF2" GroupName="radioYF" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                                    <asp:Label ID="lb_Ie97" runat="server" Text="calentador solar de agua?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie97a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioYG1" GroupName="radioYG" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_Ie97b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioYG2" GroupName="radioYG" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;' class="Mibk">
                                    <asp:Label ID="lb_Ie98" runat="server" Text="aire acondicionado?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie98a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioYH1" GroupName="radioYH" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:Label ID="lb_Ie98b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioYH2" GroupName="radioYH" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                                    <asp:Label ID="lb_Ie99" runat="server" Text="panel solar para tener electricidad?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'">
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie99a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioYI1" GroupName="radioYI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_Ie99b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioYI2" GroupName="radioYI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;' class="Mibk">
                                    <asp:Label ID="lb_Ie910" runat="server" Text="lámpara solar?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie910a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioYJ1" GroupName="radioYJ" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:Label ID="lb_Ie910b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioYJ2" GroupName="radioYJ" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <%--<div id="Sec014" class="col-sm-4">--%>
        <div id="Sec014" class="col-sm-12" style="display:none;">
<%--           <div id="DivIe10" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie10" runat="server" Text="10. SANITARIO" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>--%>
           <div id="DivIp10" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_Ie10e" runat="server" Text="¿Tienen:" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
<%--                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:85%;'>
                                    <asp:Label ID="lb_Ie101" runat="server" Text="taza de baño (excusado o sanitario)?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie111" runat="server" Text="letrina (pozo u hoyo)?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie121" runat="server" Text="¿No tienen taza de baño ni letrina?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:5%;'>
                                    <asp:RadioButtonList ID="RadioButtonList17" runat="server" RepeatDirection="Vertical" TextAlign="Left" Width="100%" >
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>--%>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_Ie101" runat="server" Text="taza de baño (excusado o sanitario)?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioG1" GroupName="radioG" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_Ie111" runat="server" Text="letrina (pozo u hoyo)?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioG2" GroupName="radioG" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_Ie121" runat="server" Text="¿No tienen taza de baño ni letrina?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioG3" GroupName="radioG" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>

    </div>
    <div id="Sec0013" class="row">
        <%--<div id="Sec015" class="col-sm-4">--%>
        <div id="Sec015" class="col-sm-12" style="display:none;">
<%--           <div id="DivIe11" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie11a" runat="server" Text="11. ADMISIÓN DE AGUA" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>--%>
           <div id="DivIp11" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_Ie11e" runat="server" Text="¿La taza de baño (letrina):" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
<%--                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:85%;'>
                                    <asp:Label ID="lb_Ie111a" runat="server" Text="tiene descarga directa de agua?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie112" runat="server" Text="le echan agua con cubeta?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie113" runat="server" Text="¿No se le puede echar agua?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:5%;'>
                                    <asp:RadioButtonList ID="RadioButtonList18" runat="server" RepeatDirection="Vertical" TextAlign="Left" Width="100%" >
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>--%>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_Ie111a" runat="server" Text="tiene descarga directa de agua?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioH1" GroupName="radioH" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_Ie112" runat="server" Text="le echan agua con cubeta?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioH2" GroupName="radioH" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_Ie113" runat="server" Text="¿No se le puede echar agua?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioH3" GroupName="radioH" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <%--<div id="Sec016" class="col-sm-5">--%>
        <div id="Sec016" class="col-sm-12" style="display:none;">
<%--           <div id="DivIe12" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie12a" runat="server" Text="12. DRENAJE" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>--%>
           <div id="DivIp12" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_Ie12e" runat="server" Text="¿Su vivienda tiene drenaje o desagüe conectado a:" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
<%--                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:85%;'>
                                    <asp:Label ID="lb_Ie121a" runat="server" Text="la red pública?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie122" runat="server" Text="una fosa séptica o tanque séptico (biodigestor)?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie123" runat="server" Text="una tubería que va a dar a una barranca o grieta?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie124" runat="server" Text="una tubería que va a dar a un río, lago o mar?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie125" runat="server" Text="¿No tiene drenaje?." Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:5%;'>
                                    <asp:RadioButtonList ID="RadioButtonList19" runat="server" RepeatDirection="Vertical" TextAlign="Left" Width="100%" >
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>--%>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_Ie121a" runat="server" Text="la red pública?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
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
                                    <asp:Label ID="lb_Ie122" runat="server" Text="una fosa séptica o tanque séptico (biodigestor)?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
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
                                    <asp:Label ID="lb_Ie123" runat="server" Text="una tubería que va a dar a una barranca o grieta?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
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
                                    <asp:Label ID="lb_Ie124" runat="server" Text="una tubería que va a dar a un río, lago o mar?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
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
                                    <asp:Label ID="lb_Ie125" runat="server" Text="¿No tiene drenaje?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioI5" GroupName="radioI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <%--<div id="Sec017" class="col-sm-3">--%>
        <div id="Sec017" class="col-sm-12" style="display:none;">
<%--           <div id="DivIe13" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie13a" runat="server" Text="13. DESTINO DE LA BASURA" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>--%>
           <div id="DivIp13" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_Ie13e" runat="server" Text="¿La basura de su vivienda:" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
<%--                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:85%;'>
                                    <asp:Label ID="lb_Ie131a" runat="server" Text="se la dan a un camión o carrito de basura?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie132" runat="server" Text="la queman?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie133" runat="server" Text="la entierran?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie134" runat="server" Text="la llevan al basurero público?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie135" runat="server" Text="la tiran en otro lugar? (Calle, baldío, río)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:5%;'>
                                    <br />
                                    <asp:RadioButtonList ID="RadioButtonList20" runat="server" RepeatDirection="Vertical" TextAlign="Left" Width="100%" >
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>--%>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_Ie131a" runat="server" Text="se la dan a un camión o carrito de basura?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioJ1" GroupName="radioJ" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_Ie132" runat="server" Text="la dejan en un contenedor o depósito?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioJ2" GroupName="radioJ" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_Ie133" runat="server" Text="la queman?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioJ3" GroupName="radioJ" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_Ie134" runat="server" Text="la entierran?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioJ4" GroupName="radioJ" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;'>
                                    <asp:Label ID="lb_Ie135" runat="server" Text="la llevan al basurero público?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioJ5" GroupName="radioJ" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:70%;' class="Mibk">
                                    <asp:Label ID="lb_Ie136" runat="server" Text="la tiran en otro lugar? (Calle, baldío, barranca, río)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;' class="Mibk">
                                    <asp:RadioButton runat="server" id="radioJ6" GroupName="radioJ" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>

    </div>
    <div id="Sec0014" class="row">
        <div id="Sec018" class="col-sm-12" style="display:none;">
<%--           <div id="DivIe14" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie14" runat="server" Text="14. BIENES Y TIC" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>--%>
           <div id="DivIp14" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="5">
                        <asp:Label ID="lb_Ie14e" runat="server" Text="¿En su vivienda tienen:" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                                    <asp:Label ID="lb_Ie141" runat="server" Text="refrigerador?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie141a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZA1" GroupName="radioZA" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_Ie141b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZA2" GroupName="radioZA" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;' class="Mibk">
                                    <asp:Label ID="lb_Ie142" runat="server" Text="lavadora?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie142a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZB1" GroupName="radioZB" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:Label ID="lb_Ie142b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZB2" GroupName="radioZB" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                                    <asp:Label ID="lb_Ie143" runat="server" Text="horno de microondas?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie143a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZC1" GroupName="radioZC" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_Ie143b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZC2" GroupName="radioZC" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;' class="Mibk">
                                    <asp:Label ID="lb_Ie144" runat="server" Text="automóvil o camioneta?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie144a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZD1" GroupName="radioZD" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:Label ID="lb_Ie144b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZD2" GroupName="radioZD" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                                    <asp:Label ID="lb_Ie145" runat="server" Text="algún aparato para oír radio?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie145a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZE1" GroupName="radioZE" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_Ie145b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZE2" GroupName="radioZE" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;' class="Mibk">
                                    <asp:Label ID="lb_Ie146" runat="server" Text="televisor?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie146a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZF1" GroupName="radioZF" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:Label ID="lb_Ie146b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZF2" GroupName="radioZF" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                                    <asp:Label ID="lb_Ie147" runat="server" Text="televisor de pantalla plana?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie147a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZG1" GroupName="radioZG" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_Ie147b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZG2" GroupName="radioZG" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;' class="Mibk">
                                    <asp:Label ID="lb_Ie148" runat="server" Text="computadora?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie148a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZH1" GroupName="radioZH" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:Label ID="lb_Ie148b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZH2" GroupName="radioZH" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                                    <asp:Label ID="lb_Ie149" runat="server" Text="línea telefónica fija?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie149a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZI1" GroupName="radioZI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_Ie149b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZI2" GroupName="radioZI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;' class="Mibk">
                                    <asp:Label ID="lb_Ie1410" runat="server" Text="teléfono celular?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie1410a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZJ1" GroupName="radioZJ" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:Label ID="lb_Ie1410b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZJ2" GroupName="radioZJ" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                                    <asp:Label ID="lb_Ie1411" runat="server" Text="Internet?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie1411a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZK1" GroupName="radioZK" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_Ie1411b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZK2" GroupName="radioZK" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;' class="Mibk">
                                    <asp:Label ID="lb_Ie1412" runat="server" Text="servicio de televisión de paga?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
<%--                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:Label ID="lb_Ie1412a" runat="server" Text="Sí" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZL1" GroupName="radioZL" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:15%;' class="Mibk">
                                    <asp:Label ID="lb_Ie1412b" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <asp:RadioButton runat="server" id="radioZL2" GroupName="radioZL" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
<%--            <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:center;vertical-align:top;border-top:none;width:100%;'>
                        <asp:LinkButton ID="Personas" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Personas_Click"><img src="images/24x32-Lapiz.png" alt="" />&nbsp;Ir a la captura de personas</asp:LinkButton>
                    </td>
                </tr>
            </table>--%>
        </div>

    </div>
        <div id="Sec100" class="col-sm-12">
                            <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                                <tr>
                                    <td style='text-align:center;vertical-align:top;border-top:none;border-left:none;width:100%;'>
 <%--                                       <asp:Button ID="Button2" runat="server" Text="Pregunta anterior" Height="25px" onclick="Button2_Click"/>
                                        <asp:Button ID="Button3" runat="server" Text="Ayuda" Height="25px" onclick="Button3_Click"/>
                                        <asp:Button ID="Button4" runat="server" Text="Pregunta siguiente" Height="25px" onclick="Button4_Click"/>--%>
               <%--<asp:Label ID="lb_Ie1" runat="server" Text="1. PISOS" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>--%>
               <asp:LinkButton ID="atras01" runat="server" Text="" style="display:none;" CssClass="btn btn-default btn-sm" OnClick="atras01_Click" ><img src="images/16x16-Anterior.png" alt="" />&nbsp;Anterior</asp:LinkButton>
               <%--<asp:LinkButton ID="Personas" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="Personas_Click"><img src="images/24x32-Lapiz.png" alt="" />&nbsp;Guardar y salir de la persona</asp:LinkButton>--%>
               <asp:LinkButton ID="adelante01" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="adelante01_Click">Siguiente&nbsp;<img src="images/16x16-Siguiente.png" alt="" /></asp:LinkButton>
<%--OnClientClick="javascript:oculta01();"--%>
                                    </td>
                                </tr>
                            </table>
        </div>
   </div>
</div>
    <div id="vmodal_error" class = "modal fade"  runat="server">
                <div id="mensaje_error" class="alert alert-succes"  runat="server"></div>
       </div>
</asp:Content>
