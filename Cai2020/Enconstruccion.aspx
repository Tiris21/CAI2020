<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Enconstruccion.aspx.cs" Inherits="Cai2020.Enconstruccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
#foto,#cargando{
            text-align:center;
	        /*height:100px;*/
            height:auto;
	        width:auto;
            margin:0px auto;
            background-color:#CCCCCC;
        }
img {
            vertical-align:middle;
        }   
</style>
<br />
<br />
<br />
<div id="contenedor">
   <div class="container-fluid">
    <div id="Sec001" class="row">
    </div>
        <div id="Sec004B" class="col-sm-12">
          <div id="Div11" class="MiDiv" runat="server" visible="true" style="height:100%; width:100%; text-align:left; min-width:250px; background-color:lightgray;">
               <table style="width:100%;border:0;padding:0px 0px 0px 0px;border-spacing:0px 0px;">
                   <tr>
                       <td style='text-align:center;vertical-align:top;border-top:none;width:100%;'>
                           <%--<asp:Label ID="Label11" runat="server" Text="CORTINILLA" Font-Names="Arial" Font-Size="medium" Font-Bold="True" ForeColor="Black" BorderStyle="None"></asp:Label>--%>
                           <img alt="Brand" id="foto" src="Images/encon.png"/>
                       </td>
                   </tr>
                   <tr>
                       <td style='text-align:center;vertical-align:top;border-top:none;width:100%;'>
                           <p><a id="cue" href="Default.aspx" class="btn btn-default btn-lg" >Inicio &raquo;</a></p>
                       </td>
                   </tr>
               </table>
           </div>
        </div>
   </div>
</div>
</asp:Content>
