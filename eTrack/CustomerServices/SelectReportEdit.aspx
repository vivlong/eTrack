<%@ Page Language="VB" AutoEventWireup="true" CodeFile="SelectReportEdit.aspx.vb"
    Inherits="SelectReportEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <base target="_self"></base>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/SelectReportEdit.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="JavaScript/SelectReportEdit.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Reference.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>

    <script type="text/javascript" language="javascript">
        function PrintDetail(intId) {
            var strTrxNo = document.getElementById("hidId").value;
            if (strTrxNo != -1) {
                var strUrl = "../loading.aspx?tourl=../Print/crBooking.aspx?Id=" + intId.toString() + "";
                window.open(strUrl);
            }
        }
        function OpenReport(objList,id,type) {
            var strReport = objList.options[objList.selectedIndex].value;
            if (strReport == "") { alert("please select a Report."); return false; }
              if (type == "3") {
                if (id != "") {
//                    var strUrl = "../loading.aspx?tourl=Print/crReport.aspx?Id=" + id.toString() + "&Report=" + strReport;
//                    window.open(strUrl);
                    this.close();
                    PrintCrystalReport("sibl/"+strReport + ".rpt", '{vw_Sibl1.Trx No}', id, 'Int');
                }
            }
            else if (type == "2") {
                if (id != "") {
//                    var strUrl = "../loading.aspx?tourl=Print/crReport.aspx?Id=" + id.toString() + "&Report=" + strReport;
//                    window.open(strUrl);
                    this.close();
                    PrintCrystalReport("sebl/"+strReport + ".rpt", '{vw_Sebl1.Trx No}', id, 'Int');
                }
            }
            else {
                if (id != "") {
                    var strUrl = "../loading.aspx?tourl=Print/crBooking.aspx?Id=" + id.toString() + "&Report=" + strReport;
                    window.open(strUrl);
                    this.close();
                }
            }
        }
    </script>

</head>
<body>
    <form id="frmSelectReport" runat="server">
    <div id="divForm">
        <div id="divTopNav" style="width: 100%">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="a3" CssClass="f12e navNml navOn" runat="server" Text="<%$ Resources:a1 %>" /></li>
            </ul>
        </div>
        <div id="SaveHint" runat="server" class="Hint" style="left: 0px; top: 10px">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>" />
        </div>
        <div class="divLine" style="margin-top: 30px;">
            <asp:Label ID="lblReport" runat="server" Text="Reports" CssClass="Label lbl" />
            <asp:DropDownList ID="drReport" runat="server">
            </asp:DropDownList>
        </div>
        <div id="divBottomNav" style="padding-right: 5px; padding-top: 5px; text-align: right;">
            <asp:Button ID="btnSelected" runat="server" Text="OK" CssClass="Button" UseSubmitBehavior="False" />
            <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose.Text %>" CssClass="Button"
                UseSubmitBehavior="False" />
        </div>
        <asp:HiddenField ID="hidId" runat="server" /> 
    </div>
    </form>
</body>
</html>
