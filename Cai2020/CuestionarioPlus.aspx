<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CuestionarioPlus.aspx.cs" Inherits="Cai2020.CuestionarioPlus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
<%--<asp:ScriptManager ID="ScriptManager1" runat="server">
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
	/*justify-content: center;
	align-items: center;
	align-content: center;
    background-color:lightgrey;*/
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
        <div id="Sec002" class="col-sm-12">
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
                                                Fraccionamiento o Colonia: <asp:Label ID="lb_colonia" runat="server" Text="Desplegar colonia" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                                    <br />
                                                Localidad: <asp:Label ID="lb_localidad" runat="server" Text="Desplegar localidad" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                                    <br />
                                                Municipio: <asp:Label ID="lb_municipio" runat="server" Text="Desplegar municipio" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
                                                    <br />
                                                Eentidad: <asp:Label ID="lb_entidad" runat="server" Text="Desplegar entidad" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="DarkBlue" BorderStyle="None"></asp:Label>
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

        <div id="Sec003" class="col-sm-12">
           <asp:Label ID="lb_6" runat="server" Text="Clase de vivienda particular" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
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
                                <td style='text-align:center;vertical-align:top;border-top:none;width:20%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                                    <asp:Label ID="lb_61" runat="server" Text="Casa única en el terreno" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioA1" GroupName="radioA" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:20%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:20%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                                    <asp:Label ID="lb_62" runat="server" Text="Casa que comparte terreno con otra(s)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioA2" GroupName="radioA" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:20%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:20%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                                    <asp:Label ID="Label2" runat="server" Text="Casa dúplex, triple o cuádruple" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioA3" GroupName="radioA" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:20%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:20%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                                    <asp:Label ID="Label3" runat="server" Text="Departamento en edificio" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioA4" GroupName="radioA" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:20%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:20%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                                    <asp:Label ID="Label4" runat="server" Text="Vivienda en vecindad o cuartería" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioA5" GroupName="radioA" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:20%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:20%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:50%;'>
                                    <asp:Label ID="Label5" runat="server" Text="Cuarto en la azotea de un edificio" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioA6" GroupName="radioA" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:20%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
    </div>
    <div id="Sec0010" class="row">
        <div id="Sec004" class="col-sm-12">
           <asp:Label ID="lb_I" runat="server" Text="Características de la vivienda" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
        </div>

        <div id="Sec005" class="col-sm-3">
           <div id="DivIe1" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie1" runat="server" Text="1. PISOS" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>
           <div id="DivIp1" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_Ie1e" runat="server" Text="¿De qué material es la mayor parte del piso de esta vivienda?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
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
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie11" runat="server" Text="Tierra" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioB1" GroupName="radioB" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie12" runat="server" Text="Cemento o firme" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioB2" GroupName="radioB" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie13" runat="server" Text="Mosaico, madera u otro recubrimiento" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioB3" GroupName="radioB" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec006" class="col-sm-3">
           <div id="DivIe2" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie2" runat="server" Text="2. DORMITORIOS" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>
           <div id="DivIp2" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="3">
                        <asp:Label ID="lb_Ie2e" runat="server" Text="¿Cuántos cuartos se usan para dormir sin contar pasillos?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:90%;' colspan="3">
                                    <asp:TextBox ID="tb_Ie21" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:90%;'>
                                    <asp:Label ID="lb_Ie21" runat="server" Text="NÚMERO DE CUARTOS" Font-Names="Arial" Font-Size="Small" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec007" class="col-sm-3">
           <div id="DivIe3" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie3" runat="server" Text="3. CUARTOS" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>
           <div id="DivIp3" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="3">
                        <asp:Label ID="lb_Ie3e" runat="server" Text="¿Cuántos cuartos tiene en total esta vivienda contando la cocina?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:90%;' colspan="3">
                                    <asp:TextBox ID="tb_Ie31" runat="server" MaxLength="2" Width="24px" Font-Names="Arial" Font-Size="Small" onkeyup="soloNumeros(this);calle(this);"></asp:TextBox>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:90%;'>
                                    <asp:Label ID="lb_Ie31" runat="server" Text="NÚMERO DE CUARTOS" Font-Names="Arial" Font-Size="Small" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec008" class="col-sm-3">
           <div id="DivIe4" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie4" runat="server" Text="4. ELECTRICIDAD" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>
           <div id="DivIp4" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_Ie4e" runat="server" Text="¿Hay luz eléctrica en esta vivienda?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:35%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:Label ID="lb_Ie41" runat="server" Text="Sí." Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie42" runat="server" Text="No" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:15%;'>
                                    <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Vertical" TextAlign="Left" Width="100%" >
                                     <asp:ListItem></asp:ListItem>
                                     <asp:ListItem></asp:ListItem>
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
        <div id="Sec009" class="col-sm-4">
           <div id="DivIe5" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie5" runat="server" Text="5. AGUA ENTUBADA" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>
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
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie51" runat="server" Text="dentro de la vivienda?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioC1" GroupName="radioC" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie52" runat="server" Text="sólo en el patio o terreno?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioC2" GroupName="radioC" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie53" runat="server" Text="¿No tienen agua entubada?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioC3" GroupName="radioC" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec010" class="col-sm-4">
           <div id="DivIe6" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie6" runat="server" Text="6. ABASTECIMIENTO DE AGUA" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>
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
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie61" runat="server" Text="del servicio público de agua?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioD1" GroupName="radioD" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie62" runat="server" Text="de un pozo comunitario?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioD2" GroupName="radioD" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie63" runat="server" Text="de un pozo particular?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioD3" GroupName="radioD" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie64" runat="server" Text="de una pipa?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioD4" GroupName="radioD" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie65" runat="server" Text="de otra vivienda?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioD5" GroupName="radioD" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie66" runat="server" Text="de otro lugar?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioD6" GroupName="radioD" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec011" class="col-sm-4">
           <div id="DivIe7" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie7" runat="server" Text="7. DOTACIÓN DE AGUA" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>
           <div id="DivIp7" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_Ie7e" runat="server" Text="¿Cuántos días a la semana les llega el agua?" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
<%--                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:85%;'>
                                    <asp:Label ID="lb_Ie71" runat="server" Text="Diario" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie72" runat="server" Text="Cada tercer día" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie73" runat="server" Text="Dos veces por semana" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie74" runat="server" Text="Una vez por semana" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                    <asp:Label ID="lb_Ie75" runat="server" Text="De vez en cuando" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                    <br />
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:5%;'>
                                    <asp:RadioButtonList ID="RadioButtonList6" runat="server" RepeatDirection="Vertical" TextAlign="Left" Width="100%" >
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
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie71" runat="server" Text="Diario" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioE1" GroupName="radioE" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie72" runat="server" Text="Cada tercer día" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioE2" GroupName="radioE" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie73" runat="server" Text="Dos veces por semana" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioE3" GroupName="radioE" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie74" runat="server" Text="Una vez por semana" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioE4" GroupName="radioE" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie75" runat="server" Text="De vez en cuando" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioE5" GroupName="radioE" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>

    </div>
    <div id="Sec0012" class="row">
        <div id="Sec012" class="col-sm-3">
           <div id="DivIe8" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie8" runat="server" Text="8. AGUA NO ENTUBADA" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>
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
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie81" runat="server" Text="un pozo?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioF1" GroupName="radioF" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie82" runat="server" Text="una llave comunitaria?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioF2" GroupName="radioF" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie83" runat="server" Text="otra vivienda?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioF3" GroupName="radioF" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie84" runat="server" Text="un río, arroyo o lago?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioF4" GroupName="radioF" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie85" runat="server" Text="¿La trae una pipa?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioF5" GroupName="radioF" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie86" runat="server" Text="¿La captan de la lluvia?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioF6" GroupName="radioF" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec013" class="col-sm-5">
           <div id="DivIe9" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie9" runat="server" Text="9. EQUIPAMIENTO" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>
           <div id="DivIp9" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_Ie9e" runat="server" Text="¿En esta vivienda tienen:" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:65%;'>
                                    <asp:Label ID="lb_Ie91" runat="server" Text="tinaco?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButtonList ID="RadioButtonList8" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:65%;'>
                                    <asp:Label ID="lb_Ie92" runat="server" Text="cisterna o aljibe?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButtonList ID="RadioButtonList9" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:65%;'>
                                    <asp:Label ID="lb_Ie93" runat="server" Text="bomba de agua?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButtonList ID="RadioButtonList10" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:65%;'>
                                    <asp:Label ID="lb_Ie94" runat="server" Text="regadera?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButtonList ID="RadioButtonList11" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:65%;'>
                                    <asp:Label ID="lb_Ie95" runat="server" Text="boiler o calentador de agua? (Gas, eléctrico, leña)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButtonList ID="RadioButtonList12" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:65%;'>
                                    <asp:Label ID="lb_Ie96" runat="server" Text="calentador solar de agua?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButtonList ID="RadioButtonList13" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:65%;'>
                                    <asp:Label ID="lb_Ie97" runat="server" Text="aire acondicionado?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButtonList ID="RadioButtonList14" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:65%;'>
                                    <asp:Label ID="lb_Ie98" runat="server" Text="panel solar para tener electricidad?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButtonList ID="RadioButtonList15" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:65%;'>
                                    <asp:Label ID="lb_Ie99" runat="server" Text="lámpara solar? (Lámpara de Prospera)?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButtonList ID="RadioButtonList16" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec014" class="col-sm-4">
           <div id="DivIe10" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie10" runat="server" Text="10. SANITARIO" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>
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
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie101" runat="server" Text="taza de baño (excusado o sanitario)?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioG1" GroupName="radioG" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie111" runat="server" Text="letrina (pozo u hoyo)?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioG2" GroupName="radioG" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie121" runat="server" Text="¿No tienen taza de baño ni letrina?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioG3" GroupName="radioG" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>

    </div>
    <div id="Sec0013" class="row">
        <div id="Sec015" class="col-sm-4">
           <div id="DivIe11" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie11a" runat="server" Text="11. ADMISIÓN DE AGUA" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>
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
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie111a" runat="server" Text="tiene descarga directa de agua?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioH1" GroupName="radioH" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie112" runat="server" Text="le echan agua con cubeta?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioH2" GroupName="radioH" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie113" runat="server" Text="¿No se le puede echar agua?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioH3" GroupName="radioH" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec016" class="col-sm-5">
           <div id="DivIe12" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie12a" runat="server" Text="12. DRENAJE" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>
           <div id="DivIp12" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_Ie12e" runat="server" Text="¿Esta vivienda tiene drenaje o desagüe conectado a:" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
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
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie121a" runat="server" Text="la red pública?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioI1" GroupName="radioI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie122" runat="server" Text="una fosa séptica o tanque séptico (biodigestor)?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioI2" GroupName="radioI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie123" runat="server" Text="una tubería que va a dar a una barranca o grieta?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioI3" GroupName="radioI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie124" runat="server" Text="una tubería que va a dar a un río, lago o mar?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioI4" GroupName="radioI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie125" runat="server" Text="¿No tiene drenaje?." Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioI5" GroupName="radioI" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>
        <div id="Sec017" class="col-sm-3">
           <div id="DivIe13" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie13a" runat="server" Text="13. DESTINO DE LA BASURA" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>
           <div id="DivIp13" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="4">
                        <asp:Label ID="lb_Ie13e" runat="server" Text="¿La basura de esta vivienda:" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
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
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie131a" runat="server" Text="se la dan a un camión o carrito de basura?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioJ1" GroupName="radioJ" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie132" runat="server" Text="la queman?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioJ2" GroupName="radioJ" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie133" runat="server" Text="la entierran?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioJ3" GroupName="radioJ" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie134" runat="server" Text="la llevan al basurero público?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioJ4" GroupName="radioJ" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:80%;'>
                                    <asp:Label ID="lb_Ie135" runat="server" Text="la tiran en otro lugar? (Calle, baldío, río)" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:10%;'>
                                    <asp:RadioButton runat="server" id="radioJ5" GroupName="radioJ" AutoPostBack="False"/>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:5%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>

    </div>
    <div id="Sec0014" class="row">
        <div id="Sec018" class="col-sm-12">
           <div id="DivIe14" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:center; min-width:250px;">
               <asp:Label ID="lb_Ie14" runat="server" Text="14. BIENES Y TIC" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
           </div>
           <div id="DivIp14" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; min-width:250px;">
               <table  style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                <tr>
                    <td style='text-align:left;vertical-align:top;border-top:none;width:100%;' colspan="12">
                        <asp:Label ID="lb_Ie14e" runat="server" Text="¿En esta vivienda tienen:" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:55%;'>
                                    <asp:Label ID="lb_Ie141" runat="server" Text="refrigerador?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButtonList ID="RadioButtonList21" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:55%;'>
                                    <asp:Label ID="lb_Ie142" runat="server" Text="lavadora?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButtonList ID="RadioButtonList22" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:55%;'>
                                    <asp:Label ID="lb_Ie143" runat="server" Text="automóvil o camioneta?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButtonList ID="RadioButtonList23" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:55%;'>
                                    <asp:Label ID="lb_Ie144" runat="server" Text="algún aparato para oír radio?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButtonList ID="RadioButtonList24" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:55%;'>
                                    <asp:Label ID="lb_Ie145" runat="server" Text="televisor?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButtonList ID="RadioButtonList25" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:55%;'>
                                    <asp:Label ID="lb_Ie146" runat="server" Text="televisor de pantalla plana?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButtonList ID="RadioButtonList26" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:55%;'>
                                    <asp:Label ID="lb_Ie147" runat="server" Text="computadora?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButtonList ID="RadioButtonList27" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:55%;'>
                                    <asp:Label ID="lb_Ie148" runat="server" Text="línea telefónica fija?." Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButtonList ID="RadioButtonList28" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:55%;'>
                                    <asp:Label ID="lb_Ie149" runat="server" Text="teléfono celular?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButtonList ID="RadioButtonList29" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:55%;'>
                                    <asp:Label ID="lb_Ie1410" runat="server" Text="Internet?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButtonList ID="RadioButtonList30" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
                <tr>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:55%;'>
                                    <asp:Label ID="lb_Ie1411" runat="server" Text="servicio de televisión de paga?" Font-Names="Arial" Font-Size="medium" ForeColor="Black" BorderStyle="None"></asp:Label>
                                </td>
                                <td style='text-align:left;vertical-align:top;border-top:none;width:25%;'>
                                    <asp:RadioButtonList ID="RadioButtonList31" runat="server" RepeatDirection="Horizontal" TextAlign="Left" Width="100%" >
                                     <asp:ListItem>Sí</asp:ListItem>
                                     <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style='text-align:center;vertical-align:top;border-top:none;width:10%;'>

                                </td>
                </tr>
               </table>
           </div>
        </div>

    </div>

   </div>
</div>
</asp:Content>
