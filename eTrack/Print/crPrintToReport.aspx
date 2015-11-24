<%@ Page Language="VB" AutoEventWireup="false" CodeFile="crPrintToReport.aspx.vb" Inherits="Print_crPrintToReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Report</title>
</head>
<body>
    <form id="frmcrRequestm" runat="server">
        <div>
            <CR:CrystalReportViewer ID="crvReport" runat="server" AutoDataBind="True" Height="802px"
                Width="1289px" DisplayGroupTree="False" ReportSourceID="crsReport" />
            <CR:CrystalReportSource ID="crsReport" runat="server">
            </CR:CrystalReportSource>
        </div>
    </form>
</body>
</html>

