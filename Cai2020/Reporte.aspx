<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="proyecto_reportes.Reporte" %>

<%@ Register Src="~/UserControl/ReportViewerControl.ascx" TagPrefix="uc1" TagName="ReportViewerControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Acuse del cuestionario de autoempadronamiento por internet</title>
</head>
<body>
    <div>
        <uc1:ReportViewerControl runat="server" id="ReportViewerControl" />
    </div>
</body>
</html>
