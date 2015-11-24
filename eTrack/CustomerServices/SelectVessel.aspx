<%@ Page Language="VB" AutoEventWireup="true" CodeFile="SelectVessel.aspx.vb" Inherits="SelectVessel" %>

<%@ Register Src="../UserControl/DateTimeSelect.ascx" TagName="DateTimeSelect" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Schedule</title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/VesselSchedule.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/Calendar.css" rel="Stylesheet" type="text/css" />
    <link href="../Print/App_Themes/Print.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!--#include file="JavaScript/Vessel.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"> </script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script language="javascript" type="text/javascript">
//        function Print()
//    {
//        WebBrowser.ExecWB(6,1);
//    }
//    function PrintPreview()
//    {
//        WebBrowser.ExecWB(7,1);
//    }
//    function PageSetup()
//    {
//        WebBrowser.ExecWB(8,1);
//    }
    function GetQueryDataBook() 
{   
    var obj= document.getElementById("txtSearch");
   
    context = document.getElementById("divSource");
    intPage=1;
    ShowLoadingData();
    GetQuery();
    var arg = "GetPageData"+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString()+ParSeparator+""; 
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetSourceValue", "context")%>; 
}
function openCrystalReport(port)
{
//../loading.aspx?tourl=
  window.open ("../Print/crVessel.aspx?id=" + port, 'newwindow', 'height=630, width=900,toolbar=no,menubar=no, scrollbars=yes, resizable=no,location=no, status=no');
}

    </script>
</head>
<body style="height: 20px; width: 898px; overflow-x: hidden;">
    <%--<object id="WebBrowser" width="0" height="0" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2">
    </object>--%>
    <form id="frmVessel" runat="server">
    <div class="NoPrint">
        <table cellpadding="0" cellspacing="0" border="0" 
            style="width: 850px; margin-left: 30px;">
            <tr style="border: 0px">
                <td style="border: 0px">
                    <img alt="" src="../Images/Customer/logo.JPG" style="width: 237px; height: 120px" />
                </td>
                <td style="border: 0px; padding-left: 30px; vertical-align: bottom; padding-bottom: 20px">
                    &nbsp;<span style="font-weight: bold; font-size: 22px; color: #B92233">Singapore</span>
                    &nbsp;- <span style="font-weight: bold; font-size: 22px; color: #7C7C7C">Worldwide</span>
                </td>
                <td style="width: 50px; border: 0px">
                </td>
            </tr>
            <tr style="border: 0px">
                <td colspan="3" style="height: 20px; background-color: #003592; border: 0px">
                </td>
            </tr>
            <tr style="border: 0px">
                <td colspan="3" style="height: 20px; text-align: right; border: 0px;">
                </td>
            </tr>
            <tr style="border: 0px">
                <td colspan="3" style="height: 20px; text-align: right; border: 0px;">
                    &nbsp;
                </td>
                <td style="border: 0px; width: 40px">
                    <asp:LinkButton ID="btnPrint" runat="server" UseSubmitBehavior="false" Visible=false Enabled=false ><img src="../Images/Customer/FilePrint.png" alt=""/></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <div style="width: 100%; padding-left: 20px;">
        <div class="NoPrint">
            <asp:Button ID="btnToExcel" runat="server" CssClass="Button" Text="Export Excel"
                Visible="false" Width="77px" />
        </div>
        <asp:Repeater ID="rpSource" runat="server">
            <ItemTemplate>
                <div class="divline">
                    &nbsp;</div>
                <asp:Label ID="lblPOD" runat="server" Font-Bold="true" Text='<% # Eval("PortofDischargeName") %>'>'></asp:Label>
                <div class="divline">
                    &nbsp;</div>
                <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvwSource_RowDataBound"
                    EnableViewState="False">
                    <HeaderStyle CssClass="Header" />
                    <FooterStyle CssClass="Footer" />
                    <RowStyle CssClass="Row" />
                    <SelectedRowStyle CssClass="SelectRow" />
                    <PagerStyle CssClass="Pager" />
                    <AlternatingRowStyle CssClass="Alternating" />
                </asp:GridView>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
<%--<script type="text/jscript" language="javascript">
    alter($(this).css("background"))
</script>--%>
