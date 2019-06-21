<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default_cat.aspx.cs" Inherits="Cai2020.Default_cat" %>
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
<div id="contenedor">
   <div class="container-fluid">
        <div id="Sec001" class="col-sm-12" style="display:inline;">
            <div id="Invitacion" class="MiDiv" runat="server" visible="true" style="width:100%;">
                    <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                    <tr>
                        <td style="align-content:center; align-items:center; text-align:center; vertical-align:top; width:100%;" >
                            <table style="width:100%;">
                                <tr>
 	               	                <td style="align-content:center; align-items:center; vertical-align:top;">
                                            <asp:Label ID="Lbinvita" runat="server" Text="Datos de la invitación" Font-Size="X-Large" ForeColor="CadetBlue" Font-Names="Arial"></asp:Label>
    <%--<asp:Panel ID="Panel1" runat="server" Width="125px" BorderWidth="1px" BackColor="Yellow" style="float: left;"> 
    Pasa por encima mío y luego vete. 
    También puedes hacerme clic ;) 
    </asp:Panel> 
    <cc1:AnimationExtender id="MyExtender" runat="server" 
    TargetControlID="Panel1"> 
    <Animations> 
    <OnMouseOver> 
    <FadeOut Duration="2.5" Fps="20" /> 
    </OnMouseOver> 
    <OnMouseOut> 
    <FadeIn Duration=".5" Fps="20" /> 
    </OnMouseOut> 
    <OnClick> 
    <Sequence> 
    <Pulse Duration=".1" /> 
    <Parallel Duration=".5" Fps="30"> 
    <FadeOut /> 
    <Scale ScaleFactor="5" Unit="px" Center="true" 
    ScaleFont="true" FontUnit="pt" /> 
    </Parallel> 
    </Sequence> 
    </OnClick> 
    </Animations> 
    </cc1:AnimationExtender>--%>

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
                    <tr>
                        <td style="align-content:center; align-items:center; text-align:center; vertical-align:top; width:100%;">
                            <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                                <tr>
                                    <td style='text-align:center;vertical-align:top;border-top:none;width:20%;'>

                                    </td>
                                    <td style='text-align:left;vertical-align:top;border-top:none;border-left:none;width:60%;'>
                                            <p style="font-size:medium; color:Black;">
                                                Usuario: <asp:TextBox ID="tb_qr_viv" runat="server" MaxLength="6" Width="72px" Height="30px" Font-Names="Arial" Font-Size="Small" onkeyup="mayusculas(this);"></asp:TextBox>
                                                    <br />
                                                    <br />
                                                Contraseña: <asp:TextBox ID="tb_contra_viv" runat="server" MaxLength="6" Width="72px" Height="30px" Font-Names="Arial" Font-Size="Small" onkeyup="mayusculas(this);"></asp:TextBox>
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
        <div id="Sec002" class="col-sm-12" style="display:inline;">
            <div id="Etiqueta" class="MiDiv" runat="server" visible="true" style="width:100%;">
                    <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                    <tr>
                        <td style="align-content:center; align-items:center; text-align:center; vertical-align:top; width:100%;" >
                            <table style="width:100%;">
                                <tr>
 	               	                <td style="align-content:center; align-items:center; vertical-align:top;">
                                            <asp:Label ID="Lbetiqueta" runat="server" Text="Datos de la etiqueta" Font-Size="X-Large" ForeColor="CadetBlue" Font-Names="Arial"></asp:Label>
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
                    <tr>
                        <td style="align-content:center; align-items:center; text-align:center; vertical-align:top; width:100%;">
                            <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                                <tr>
                                    <td style='text-align:center;vertical-align:top;border-top:none;width:20%;'>

                                    </td>
                                    <td style='text-align:left;vertical-align:top;border-top:none;border-left:none;width:60%;'>
                                            <p style="font-size:medium; color:Black;">
                                                Código de la etiqueta: <asp:TextBox ID="tb_etiqueta" runat="server" MaxLength="6" Width="72px" Height="30px" Font-Names="Arial" Font-Size="Small" onkeyup="mayusculas(this);"></asp:TextBox>
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
        <div id="Sec003" class="col-sm-12" style="display:inline;">
            <div id="Domicilio" class="MiDiv" runat="server" visible="true" style="width:100%;">
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
                    <tr>
                        <td style="align-content:center; align-items:center; text-align:center; vertical-align:top; width:100%;">
                            <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                                <tr>
                                    <td style='text-align:center;vertical-align:top;border-top:none;width:20%;'>

                                    </td>
                                    <td style='text-align:left;vertical-align:top;border-top:none;border-left:none;width:60%;'>
                                            <p style="font-size:medium; color:Black;">
                                                Entidad: <asp:TextBox ID="tb_entidad" runat="server" MaxLength="60" Width="60%" Height="30px" Font-Names="Arial" Font-Size="Small" onkeyup="mayusculas(this);"></asp:TextBox>
                                                    <br />
                                                    <br />
                                                Municipio: <asp:TextBox ID="tb_municipio" runat="server" MaxLength="50" Width="60%" Height="30px" Font-Names="Arial" Font-Size="Small" onkeyup="mayusculas(this);"></asp:TextBox>
                                                    <br />
                                                    <br />
                                                Localidad: <asp:TextBox ID="tb_localidad" runat="server" MaxLength="70" Width="60%" Height="30px" Font-Names="Arial" Font-Size="Small" onkeyup="mayusculas(this);"></asp:TextBox>
                                                    <br />
                                                    <br />
                                                Calle: <asp:TextBox ID="tb_calle" runat="server" MaxLength="250" Width="60%" Height="30px" Font-Names="Arial" Font-Size="Small" onkeyup="mayusculas(this);"></asp:TextBox>
                                                    <br />
                                                    <br />
                                                Número Exterior: <asp:TextBox ID="tb_numext" runat="server" MaxLength="6" Width="72px" Height="30px" Font-Names="Arial" Font-Size="Small" onkeyup="mayusculas(this);"></asp:TextBox>
                                                    <br />
                                                    <br />
                                                Número Interior: <asp:TextBox ID="tb_numint" runat="server" MaxLength="6" Width="72px" Height="30px" Font-Names="Arial" Font-Size="Small" onkeyup="mayusculas(this);"></asp:TextBox>
                                                    <br />
                                                    <br />
                                                Fraccionamiento o Colonia: <asp:TextBox ID="tb_colonia" runat="server" MaxLength="70" Width="60%" Height="30px" Font-Names="Arial" Font-Size="Small" onkeyup="mayusculas(this);"></asp:TextBox>
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
        <div id="Sec004" class="col-sm-12" style="display:inline;">
            <div id="Boton" class="MiDiv" runat="server" visible="true" style="width:100%;">
                    <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                    <tr>
                        <td style="align-content:center; align-items:center; text-align:center; vertical-align:top; width:100%;">
                            <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                                <tr>
                                    <td style='text-align:center;vertical-align:top;border-top:none;width:20%;'>

                                    </td>
                                    <td style='text-align:center;vertical-align:top;border-top:none;border-left:none;width:60%;'>
                                        <asp:LinkButton ID="LinkButton1" runat="server" Text="" CssClass="btn btn-default btn-sm" OnClick="LinkButton1_Click" >Continuar</asp:LinkButton>
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
   </div>
</div>
</asp:Content>
