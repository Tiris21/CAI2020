<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acuse.aspx.cs" Inherits="Acuse.Acuse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script  type="text/javascript">
	function imprSelec(nombre) {
	  var ficha = document.getElementById(nombre);
	  var ventimp = window.open(' ', 'popimpr');
	  ventimp.document.write( ficha.innerHTML );
	  ventimp.document.close();
	  ventimp.print( );
	  ventimp.close();
	}

	function SaveSelec(nombre)
	{	    
	    var file = new File([ficha], "Acuse.pdf", { type: "application/pdf;charset=utf-8" });	    
	}

	

	function click() {
	    if (event.button == 2) {
	        alert(' Para obtener una vista previa del archivo, haga clic en el icono');
	    }
	}
	document.onmousedown = click;
	document.oncontextmenu = function () { return false }

	function disableselect(e) {
	    return false
	}
	function reEnable() {
	    return true
	}
	document.onselectstart = new Function("return false")
	if (window.sidebar) {
	    document.onmousedown = disableselect
	    document.onclick = reEnable
	}

	</script>


    <style type="text/css">
      .image { position: relative; width: 100%;}
      h2 { position: absolute; top: 282px;left: 257px; width: 16%; height: 23px; }
      h2 span { color: white; font: bold 18px Helvetica, Sans-Serif; letter-spacing: -1px; background: rgb(0, 0, 0); background: rgba(0, 0, 0, 0.5); padding: 4px; }
      h2 span.spacer {padding:0 4px;}
      h1 { position: absolute; top: 385px; left: 235px; width: 2%; height: 23px; }
      h1 span { color: white; font: bold 18px Helvetica, Sans-Serif; letter-spacing: -1px; background: rgb(0, 0, 0); background: rgba(0, 0, 0, 0.5); padding: 4px; }
      h1 span.spacer {padding:0 4px;}
      h3 { position: absolute; top: 399px; left: 377px; width: 2%; height: 23px; }
      h3 span { color: white; font: bold 18px Helvetica, Sans-Serif; letter-spacing: -1px; background: rgb(0, 0, 0); background: rgba(0, 0, 0, 0.5); padding: 4px; }
      h3 span.spacer {padding:0 4px;}
      h4 { position: absolute; top: 398px; left: 526px; width: 2%; height: 23px; }
      h4 span { color: white; font: bold 18px Helvetica, Sans-Serif; letter-spacing: -1px; background: rgb(0, 0, 0); background: rgba(0, 0, 0, 0.5); padding: 4px; }
      h4 span.spacer {padding:0 4px;}
        .font { font: bold 18px Arial , Sans-Serif;}    
    </style>

</head>
<body style="background-color:#aeaaaa;" "javascript:">    
    
     <table style="width:100%;">
         <tr>
             <td>

             </td>
             <td>
                 <table style="width:100%;">
                    <tr>
                        <td style="vertical-align:middle;text-align:left";>                                                                                                               
                            <button type="button" onclick="imprSelec('seleccion');" >
                                <table>
                                    <tr>
                                        <td><img src="ImagenesAcuse/Guardar.png"/></td>
                                        <td>Guardar</td>
                                    </tr>
                                </table>
                            </button>        
                            <button type="button" onclick="imprSelec('seleccion');" >
                                 <table>
                                    <tr>
                                        <td><img src="ImagenesAcuse/imprimir.png"/></td>
                                        <td>Imprimir</td>
                                    </tr>
                                </table>
                            </button>                                  
                        </td>         
                        <td style="vertical-align:middle;text-align:right";>                             
                            <button type="button" onclick="location.href='http://www.inegi.org.mx/est/contenidos/proyectos/ccpv/default.aspx'" >
                                <table>
                                    <tr>
                                        <td><img src="ImagenesAcuse/cerrar.png"/></td>
                                        <td>Cerrar</td>
                                    </tr>
                                </table>
                            </button>                               
                        </td>
                    </tr>
                 </table>                
             </td>
             <td>

             </td>
         </tr>
         <tr>
             <td style="width:25%"></td>
             <td style="width:50%;">
                 <div id="seleccion" class="image" style="align-content:center; background-color:white;">
                     <table style="width:100%;">
                         <tr>
                             <td>
                                 <img src="ImagenesAcuse/Captura1.PNG" style="width:850px" />
                             </td>
                         </tr>
                         <tr>
                             <td>
                             <table style="width:100%;">
                                 <tr>
                                    <td style="width:92%;vertical-align:middle;text-align:right";>
                                        <asp:Label ID="lbfecha" runat="server" Text="Label" Font-Bold="True" ForeColor="#5B5B5D" CssClass="font"></asp:Label>
                                    </td>
                                    <td style="width:8%">

                                    </td>
                                </tr>
                             </table>
                            </td>
                         </tr>
                         <tr>
                             <td>


                                 <img src="ImagenesAcuse/Captura2.PNG" style="width:850px" />
                             </td>
                         </tr>
                         <tr>
                             <td style="width:10%;vertical-align:middle;text-align:center";>
                                <asp:Label ID="lbfolio" runat="server" Text="Label" Font-Bold="True" BackColor="#CCCCCC" BorderColor="#CCCCCC" BorderStyle="Solid" Font-Size="X-Large" ForeColor="#5B5B5D" CssClass="font"></asp:Label>
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <img src="ImagenesAcuse/Captura3.PNG" style="width:850px" />
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <table style="width:100%">
                                     <tr>
                                        <td style="width:35%;vertical-align:middle;text-align:right";>
                                             <img src="ImagenesAcuse/Captura4.PNG" style="width:90px;height:99px; text-align: center;"  />
                                        </td>
                                         <td style="width:10%;vertical-align:middle;text-align:left";>
                                             <asp:Label ID="lbcuartos" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large" ForeColor="#5B5B5D" CssClass="font"></asp:Label>
                                        </td>
                                         <td style="width:10%;vertical-align:middle;text-align:right";>
                                              <img src="ImagenesAcuse/Captura5.PNG" style="width:90px;height:99px" />
                                        </td>
                                         <td style="width:10%;vertical-align:middle;text-align:left";>
                                             <asp:Label ID="lbmujeres" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large" ForeColor="#5B5B5D" CssClass="font"></asp:Label>
                                        </td>
                                         <td style="width:10%;vertical-align:middle;text-align:right";>
                                             <img src="ImagenesAcuse/Captura6.PNG" style="width:90px;height:99px" />
                                        </td>
                                         <td style="width:30%;vertical-align:middle;text-align:left";>
                                             <asp:Label ID="lbhombres" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large" ForeColor="#5B5B5D" CssClass="font"></asp:Label>
                                        </td>
                                     </tr>
                                 </table>

                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <img src="ImagenesAcuse/Captura7.PNG" style="width:850px" />
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <br /><br /><br />
                                 <img src="ImagenesAcuse/Captura8.PNG" style="width:850px" />
                             </td>
                         </tr>
                     </table>
                 </div>
             </td>
             <td style="width:25%"></td>
         </tr>
         
     </table>
        

    
</body>
</html>