<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mapas01.aspx.cs" Inherits="Cai2020.Mapas01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
 			function medio()
            {
                var cadena01 = document.getElementById('MainContent_TextBox1').value;
                //var cuestionario = document.all('cuest').src = "https://cic.inegi.org.mx/igc_esp_int/faces/filterInit.jsp?def=qwe.q.xml&id_usuario=" + cadena01;
                var cuestionario = document.all('cuest').src = "http://10.103.1.96/mapas";
                
            }
</script>
    <br />
    <br />
<iframe id="cuest"  scrolling="yes" style="border:none; width:100%; height:625px;"></iframe>
<asp:TextBox ID="TextBox1" runat="server" ReadOnly="True" ForeColor="White" BackColor="White" BorderStyle="None"></asp:TextBox>
</asp:Content>
