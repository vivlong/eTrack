<%@ Page Language="VB" AutoEventWireup="true" CodeFile="crSebl_BL.aspx.vb" Inherits="Print_crSebl_BL" %>


<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Booking</title>
</head>
<body>
    <form id="frmcrRequestm" runat="server">
        <div>
            <CR:CrystalReportViewer ID="crvSebl" runat="server" AutoDataBind="True" Height="802px"
                Width="1289px" DisplayGroupTree="False" ReportSourceID="crsSebl" />
            <CR:CrystalReportSource ID="crsSebl" runat="server">
                <Report FileName="Report\omtx\rptsebl11.rpt">
                </Report>
            </CR:CrystalReportSource>
        </div>
    </form>
</body>
</html>
