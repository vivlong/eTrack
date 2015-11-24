<%@ Page Language="VB" AutoEventWireup="true" CodeFile="crReport.aspx.vb" Inherits="Print_crRequest" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ReportQuery</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmcrRequestm" runat="server">
    <div>
        <CR:CrystalReportViewer ID="crvRequest" runat="server" AutoDataBind="True" Height="421px"
            ReportSourceID="crsRequest" Width="767px" HyperlinkTarget="" CssClass="divBorder" GroupTreeStyle-BorderColor="Red" PageToTreeRatio="30" EnableDatabaseLogonPrompt="False" DisplayGroupTree="False" DisplayToolbar="False" PrintMode="ActiveX" />
        <cr:crystalreportsource id="crsRequest" runat="server">
        </cr:crystalreportsource>
    </div>
    </form>
</body>
</html>
