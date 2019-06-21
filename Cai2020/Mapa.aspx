<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mapa.aspx.cs" Inherits="Cai2020.Mapa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= "<link href=\"" + ResolveClientUrl( "~/Styles/bootstrap.css") + "\" rel=\"stylesheet\" type=\"text/css\" />" %>
    <script type="text/javascript" src="<%= ResolveClientUrl("~/Scripts/zepto.min.js")%>"></script>
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=true"></script>
    <script type="text/javascript" src="<%= ResolveClientUrl("~/Scripts/gmaps.js")%>"></script>
    <%= "<link href=\"" + ResolveClientUrl( "~/Styles/mypath.css") + "\" rel=\"stylesheet\" type=\"text/css\" />" %>
    <%= "<link href=\"" + ResolveClientUrl( "~/Styles/jquery-ui-1.9.2.custom.css") + "\" rel=\"stylesheet\" type=\"text/css\" />" %>
    <script type="text/javascript" src="<%= ResolveClientUrl("~/Scripts/bootstrap.js")%>"></script>
  <script type="text/javascript">
    var map, lat, lng;

    $(function(){
      var cordini = [{latitud_:null,longitud_:null}];
      localStorage.geocoord= localStorage.geocoord || JSON.stringify(cordini);
      var geocoord= JSON.parse (localStorage.geocoord);
      function enlazarMarcador(e){
       // muestra ruta entre marcas anteriores y actuales
        map.drawRoute({
          origin: [lat, lng],  // origen en coordenadas anteriores
          // destino en coordenadas del click o toque actual
          destination: [e.latLng.lat(), e.latLng.lng()],
          travelMode: 'driving',
          strokeColor: '#000000',
          strokeOpacity: 0.6,
          strokeWeight: 5
        });
        lat = e.latLng.lat();   // guarda coords para marca siguiente
        lng = e.latLng.lng();
        geocoord.push({
                   latitud_:lat,
                   longitud_:lng
                })
        localStorage.geocoord=JSON.stringify(geocoord);        
        map.addMarker({ lat: lat, lng: lng});  // pone marcador en mapa
      };
      function geolocalizar(){
        GMaps.geolocate({
          success: function(position){
            lat = position.coords.latitude;  // guarda coords en lat y lng
            lng = position.coords.longitude;
            geocoord[0].latitud_ = lat;  // guarda coords en lat y lng,
            geocoord[0].longitud_ = lng;
            localStorage.geocoord=JSON.stringify(geocoord);
            map = new GMaps({  // muestra mapa centrado en coords [lat, lng]
              el: '#map',
              lat: lat,
              lng: lng,
              click: enlazarMarcador,
              tap: enlazarMarcador
            });
            map.addMarker({ lat: lat, lng: lng});  // marcador en [lat, lng]
          },
          error: function(error) { alert('Geolocalización falla: '+error.message); },
          not_supported: function(){ alert("Su navegador no soporta geolocalización"); },
        });
      };
      function colocageo(){
        GMaps.geolocate({
          success: function(position){
            map = new GMaps({  // muestra mapa centrado en coords [lat, lng]
              el: '#map',
              lat: geocoord[0].latitud_,
              lng: geocoord[0].longitud_,
              click: enlazarMarcador,
              tap: enlazarMarcador
            });
            map.addMarker({ lat: geocoord[0].latitud_, lng: geocoord[0].longitud_});  // marcador en [lat, lng]
            for (var i=1;  i < geocoord.length;  ++i) {
                      map.drawRoute({
                          origin: [geocoord[i-1].latitud_, geocoord[i-1].longitud_],  // origen en coordenadas anteriores
                          destination: [geocoord[i].latitud_, geocoord[i].longitud_],
                          travelMode: 'driving',
                          strokeColor: '#000000',
                          strokeOpacity: 0.6,
                          strokeWeight: 5
                        });
                      map.addMarker({ lat: geocoord[i].latitud_, lng: geocoord[i].longitud_});  // marcador en [lat, lng]

                      lat = geocoord[i].latitud_;   // guarda coords para marca siguiente
                      lng = geocoord[i].longitud_;
            }
            if (geocoord.length===1){
                  lat = geocoord[0].latitud_;   // guarda coords para marca siguiente
                  lng = geocoord[0].longitud_;
                }

          },
          error: function(error) { alert('Geolocalización falla: '+error.message); },
          not_supported: function(){ alert("Su navegador no soporta geolocalización"); },
        });
      };
      if (geocoord[0].latitud_===null){
                  geolocalizar();
      }
      else{
                  colocageo();
      };

      function reiniciar(){
                    localStorage.geocoord= JSON.stringify(cordini);
                    geocoord= JSON.parse (localStorage.geocoord);
                    geolocalizar();
      }
      $("#reinicio").on("click",function(){
                          confirmar.dialog('open');
                          return false;
                        });
    });      
  </script>
  <div id ="titulo">
    <div style="left: 0">
      <h1>Geolocalización&nbsp;&nbsp;<button id="reinicio" title="eliminar rutas seleccionadas" class="btn btn-default">Reinicio</button></h1>
    </div>
  </div>
  <div id="map" style="top:70px"></div>
  <div style="display:none" id="confirmacion" title="!Alerta¡">Al reiniciar se perderán las rutas seleccionadas<br />¿Deseas continuar?</div>
</asp:Content>
