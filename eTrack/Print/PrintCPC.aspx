<%@ Page Language="VB" AutoEventWireup="true" CodeFile="PrintCPC.aspx.vb" Inherits="PrintCPC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/Print.css" rel="Stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
    function Print()
    {
        WebBrowser.ExecWB(6,1);
    }
    function PrintPreview()
    {
        WebBrowser.ExecWB(7,1);
    }
    function PageSetup()
    {
        WebBrowser.ExecWB(8,1);
    }
    </script>

</head>
<body>
    <object id="WebBrowser" width="0" height="0" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2">
    </object>
    <form id="frmPrintQry" runat="server">
    <div class="NoPrint">
        <asp:Button ID="btnPrint" Text="Print" runat="server" CssClass="Button" />
        <asp:Button ID="btnPrintPreview" Text="Print Preview" runat="server" CssClass="Button" />
        <asp:Button ID="btnPageSetup" Text="Page Setup" runat="server" CssClass="Button" />
    </div>
    <center>
        <table>
            <tr>
                <td align="center" style="width: 100%">
                    <asp:Label ID="lblTitle" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 100%;">
                    <asp:Label ID="lblCompName" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 100%">
                    <asp:Label ID="lblPrintTime" runat="server" Text="Print Date: " />
                    <asp:Label ID="lblTime" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 180px">
                    <%--                        <asp:GridView ID="gvwHidden" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvwHidden_RowDataBound"
                            EnableViewState="false" BorderWidth="0px" CellPadding="0" >
                        </asp:GridView>--%>
                    <div runat="server" id="divResult" style="text-align: left">
                    </div>
                </td>
            </tr>
        </table>
    </center>
    </form>
</body>
</html>
