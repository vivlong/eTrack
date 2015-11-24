<%@ Page Language="VB" AutoEventWireup="true" CodeFile="VendorAnalysis.aspx.vb" Inherits="CustomerAnalysis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/CustomerAnalysis.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Calendar.css" rel="Stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/js_lzw.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->
    <!--#include file="../JavaScript/Print.js" -->
    <!--#include file="JavaScript/Chart.js" -->

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"> </script>    
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script language="javascript" type="text/javascript">
        function PrintDetail(intId) {
            if (intId) {
                var strUrl = "../loading.aspx?tourl=" + PrintPath + "/crCustomerAnalysis.aspx?Id=" + intId.toString() + "";
                window.open(strUrl);
            }
        }
     function SelectedDivl(selectId,LiCount)
   {
    var DivName;
    var LiName;
    for(var i=1;i<=LiCount;i++)
    {
        if (selectId==i)
        {
                LiName="a"+selectId.toString();
                document.getElementById(LiName).className="f12e navNml navOn";
        }
        else{
                LiName="a"+i.toString();
                document.getElementById(LiName).className="f12c navNml noSep";
             }
    }
    if(selectId==1)
    { 
          document.getElementById('div_Vendor').style.display ="inline";
          document.getElementById('divdrToplist').style.display ="none";
          document.getElementById('divDate').style.display ="none";
          document.getElementById('divYM').style.display ="inline";          
    }
    else if(selectId==2)
    {
          document.getElementById('div_Vendor').style.display ="none";
          document.getElementById('divdrToplist').style.display ="inline";
          document.getElementById('divDate').style.display ="none";
          document.getElementById('divYM').style.display ="inline";             
    }
      else if(selectId==3)  
      {
       document.getElementById('div_Vendor').style.display ="inline";
       document.getElementById('divdrToplist').style.display ="none";
       document.getElementById('divYM').style.display ="none";      
       document.getElementById('divDate').style.display ="inline";
      }
     else if(selectId==4)
        {
          document.getElementById('div_Vendor').style.display ="inline";
          document.getElementById('divdrToplist').style.display ="none";
          document.getElementById('divDate').style.display ="none";
          document.getElementById('divYM').style.display ="inline";
        }
   }
    </script>

</head>
<body onload="DivAutoSize(160);" onresize="DivAutoSize(160);">
    <form id="frmCustomerAnalysis" runat="server">
    <div id="divTopNav" runat="server" class="divSearch">
        <ul id="ulTopNav">
            <li>
                <asp:Label ID="a1" CssClass="f12e navNml navOn" runat="server" Width="115px" onclick="javascript:SelectedDivl(1,4);"
                    Text="<%$ Resources:a1 %>"></asp:Label></li>
            <li>
                <asp:Label ID="a2" CssClass="f12c navNml noSep" runat="server" Width="115px" onclick="javascript:SelectedDivl(2,4);"
                    Text="<%$ Resources:a2 %>"></asp:Label></li>
            <li>
                <asp:Label ID="a3" CssClass="f12c navNml noSep" runat="server" Width="115px" onclick="javascript:SelectedDivl(3,4);"
                    Text="<%$ Resources:a3 %>"></asp:Label></li>
            <li>
                <asp:Label ID="a4" CssClass="f12c navNml noSep" runat="server" Width="115px" onclick="javascript:SelectedDivl(4,4);"
                    Text="<%$ Resources:a4 %>"></asp:Label></li>
        </ul>
    </div>
    <div id="popupMenu" class="skin" runat="server" onclick="ClickItem(event)" onmousemove="HighlighItem(event)"
        onmouseout="LowlightItem(event)">
    </div>
    <div id="MsgBox">
        <div class="bar">
            <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:Message, LoadTitleHint %>"></asp:Label>
        </div>
        <div class="content">
            <img alt="" src="../images/load.gif" style="text-align: center; vertical-align: middle" />&nbsp;
            &nbsp;<asp:Label ID="lblMessage" runat="server" Text="<%$ Resources:Message, LoadDataHint %>"></asp:Label>
        </div>
    </div>
    <div id="divSearch" class="divCustomerAnalysis divSearch" style="height: 53px;" runat="server">
        <div class="divline">
            <div id="divYM" runat="server" style="display: none">
                <asp:Label ID="lblYear" runat="server" Text="<%$ Resources:lblYear %>" CssClass="Label lbl" />&nbsp
                <asp:DropDownList ID="drYear" runat="server" />
                &nbsp&nbsp
                <asp:Label ID="lblMonth" runat="server" Text="<%$ Resources:lblMonth %>" CssClass="Label lblMonth" />
                <asp:DropDownList ID="drMonth" runat="server" />
            </div>
            <div id="divDate" style="display: none;">
                <asp:Label ID="lbtDate" runat="server" Text="<%$ Resources:lbtDate %>" CssClass="Label lblcustomer" />&nbsp
                <asp:TextBox ID="txtOrderDate" CssClass="TextBox txtDate" runat="server" />
                <asp:Button ID="btnOrderDate" runat="server" CssClass="Button bntDate" Text="..."
                    UseSubmitBehavior="False" />
            </div>
            <div id="divdrpSearch" style="display: inline; padding-left: 30px;">
                <asp:Label ID="lblVendorType" runat="server" Text="<%$ Resources:lblVendorType %>"
                    CssClass="Label" />
                &nbsp&nbsp
                <asp:DropDownList ID="drpSearch" runat="server" />
            </div>
        </div>
        <div id="divdrTopButton" class="divline">
            <div id="divdrToplist" style="display: none;">
                <asp:DropDownList ID="drTopButton" runat="server" Width="103px" />
            </div>
            <div id="div_Vendor" runat="server" style="display: none">
                <asp:Label ID="lblVendor" runat="server" Text="<%$ Resources:lblVendor %>" CssClass="Label lblcustomer" />&nbsp
            </div>
            <asp:TextBox ID="txtSearch" runat="server" CssClass="txInput txtSearch" />
            <asp:Button ID="btnSearch" runat="server" CssClass="btnFnt" Width="60px" Text="Query"
                UseSubmitBehavior="false" />
        </div>
    </div>
    <div id="divSource">
        <div>
            <table cellspacing="0" rules="all" border="1" id="tbhard" style="width: 800px; border-collapse: collapse;">
                <tr class="Header">
                    <th scope="col" style="width: 300px;">
                        Vendor
                    </th>
                    <th scope="col" style="width: 50px;">
                        Jan
                    </th>
                    <th scope="col" style="width: 50px;">
                        Feb
                    </th>
                    <th scope="col" style="width: 50px;">
                        Mar
                    </th>
                    <th scope="col" style="width: 50px;">
                        Apr
                    </th>
                    <th scope="col" style="width: 50px;">
                        May
                    </th>
                    <th scope="col" style="width: 50px;">
                        Jun
                    </th>
                    <th scope="col" style="width: 50px;">
                        Jul
                    </th>
                    <th scope="col" style="width: 50px;">
                        Aug
                    </th>
                    <th scope="col" style="width: 50px;">
                        Sep
                    </th>
                    <th scope="col" style="width: 50px;">
                        Oct
                    </th>
                    <th scope="col" style="width: 50px;">
                        Nov
                    </th>
                    <th scope="col" style="width: 50px;">
                        Dec
                    </th>
                    <th scope="col" style="width: 100px;">
                        Total
                    </th>
                </tr>
                <tr class="Row" onmouseover="RowMouseOver(this)" onmouseout="RowMouseOut(this,1)">
                    <td align="left">
                        <a href="javascript:showChart('12,8,2,18,9,11,15,5,16,4,7,13');">
                            TANDEM GLOBAL LOGISTICS LTD.</a>
                    </td>
                    <td align="left">
                        12
                    </td>
                    <td align="left">
                        8
                    </td>
                    <td align="left">
                        2
                    </td>
                    <td align="left">
                        18
                    </td>
                    <td align="left">
                        9
                    </td>
                    <td align="left">
                        11
                    </td>
                    <td align="left">
                        15
                    </td>
                    <td align="left">
                        5
                    </td>
                    <td align="left">
                        16
                    </td>
                    <td align="left">
                        4
                    </td>
                    <td align="left">
                        7
                    </td>
                    <td align="left">
                        13
                    </td>
                    <td align="left">
                        120
                    </td>
                </tr>
                <tr class="Alternating" onmouseover="RowMouseOver(this)" onmouseout="RowMouseOut(this,0)">
                    <td align="left">
                        <a href="javascript:showChart('4,6,1,9,7,3,4,6,8,2,9,1');">
                            WAP LOGISTICS (S) PTE LTD</a>
                    </td>
                    <td align="left">
                        4
                    </td>
                    <td align="left">
                        6
                    </td>
                    <td align="left">
                        1
                    </td>
                    <td align="left">
                        9
                    </td>
                    <td align="left">
                        7
                    </td>
                    <td align="left">
                        3
                    </td>
                    <td align="left">
                        4
                    </td>
                    <td align="left">
                        6
                    </td>
                    <td align="left">
                        8
                    </td>
                    <td align="left">
                        2
                    </td>
                    <td align="left">
                        9
                    </td>
                    <td align="left">
                        1
                    </td>
                    <td align="left">
                        60
                    </td>
                </tr>
                <tr class="Row" onmouseover="RowMouseOver(this)" onmouseout="RowMouseOut(this,1)">
                    <td align="left">
                        <a href="javascript:showChart('7,8,9,6,11,4,15,0,14,1,13,7');">
                            ICELAND AIR</a>
                    </td>
                    <td align="left">
                        7
                    </td>
                    <td align="left">
                        8
                    </td>
                    <td align="left">
                        9
                    </td>
                    <td align="left">
                        6
                    </td>
                    <td align="left">
                        11
                    </td>
                    <td align="left">
                        4
                    </td>
                    <td align="left">
                        15
                    </td>
                    <td align="left">
                        0
                    </td>
                    <td align="left">
                        14
                    </td>
                    <td align="left">
                        1
                    </td>
                    <td align="left">
                        13
                    </td>
                    <td align="left">
                        7
                    </td>
                    <td align="left">
                        95
                    </td>
                </tr>
                <tr class="Alternating" onmouseover="RowMouseOver(this)" onmouseout="RowMouseOut(this,0)">
                    <td align="left">
                        <a href="javascript:showChart('3,37,15,25,38,2,7,33,1,39,5,35');">
                            KAMIGUMI(HONG KONG) CO.,LTD.</a>
                    </td>
                    <td align="left">
                        3
                    </td>
                    <td align="left">
                        37
                    </td>
                    <td align="left">
                        15
                    </td>
                    <td align="left">
                        25
                    </td>
                    <td align="left">
                        38
                    </td>
                    <td align="left">
                        2
                    </td>
                    <td align="left">
                        7
                    </td>
                    <td align="left">
                        33
                    </td>
                    <td align="left">
                        1
                    </td>
                    <td align="left">
                        39
                    </td>
                    <td align="left">
                        5
                    </td>
                    <td align="left">
                        35
                    </td>
                    <td align="left">
                        240
                    </td>
                </tr>
                <tr class="Row" onmouseover="RowMouseOver(this)" onmouseout="RowMouseOut(this,1)">
                    <td align="left">
                        <a href="javascript:showChart('30,0,29,1,18,12,17,13,16,14,7,13');">
                            SALLEX SHIPPING & FORWARDING SERVICES</a>
                    </td>
                    <td align="left">
                        30
                    </td>
                    <td align="left">
                        0
                    </td>
                    <td align="left">
                        29
                    </td>
                    <td align="left">
                        1
                    </td>
                    <td align="left">
                        18
                    </td>
                    <td align="left">
                        12
                    </td>
                    <td align="left">
                        17
                    </td>
                    <td align="left">
                        13
                    </td>
                    <td align="left">
                        16
                    </td>
                    <td align="left">
                        14
                    </td>
                    <td align="left">
                        7
                    </td>
                    <td align="left">
                        13
                    </td>
                    <td align="left">
                        180
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvwSource_RowDataBound"
            EnableViewState="False">
            <HeaderStyle CssClass="Header" />
            <FooterStyle CssClass="Footer" />
            <RowStyle CssClass="Row" />
            <SelectedRowStyle CssClass="SelectRow" />
            <PagerStyle CssClass="Pager" />
            <AlternatingRowStyle CssClass="Alternating" />
        </asp:GridView>
    </div>
    <div id="divPage">
        <div class="fLeft">
            <asp:Label ID="lblPage" runat="server" Text="Page"></asp:Label>
            <asp:LinkButton ID="lbtnFirst" runat="server" Text="First"></asp:LinkButton>
            <asp:LinkButton ID="lbtnPrior" runat="server" Text="Prior"></asp:LinkButton>
            <asp:Label ID="lblPabe" runat="server" Text="Page" />
            <asp:TextBox ID="txtPage" runat="server" CssClass="txInput"></asp:TextBox>
            <asp:LinkButton ID="lbtnGoTo" runat="server" Text="Go"></asp:LinkButton>
            <asp:LinkButton ID="lbtnNext" runat="server" Text="Next"></asp:LinkButton>
            <asp:LinkButton ID="lbtnLast" runat="server" Text="Last"></asp:LinkButton>
        </div>
        <div class="fRight">
            <asp:Button ID="btnToExcel" runat="server" CssClass="Button" Text="<%$ Resources:lblExcel.Text %>"
                Width="77px" UseSubmitBehavior="False" />
        </div>
    </div>
    <div id="hid_div">
        <asp:HiddenField ID="hidVal_CustomerAnalysis" runat="server" Value="1" />
    </div>
    </form>
</body>
</html>
<script type="text/javascript" language="javascript">
    function nocontextmenu(){ 
     event.cancelBubble = true 
     event.returnValue = false; 
     return false; 
    } 
    function nodblClick(){ 
     event.cancelBubble = true 
     event.returnValue = false; 
     return false; 
    } 
    function norightclick(e){ 
     if (window.Event){ 
      //if (e.which == 2 || e.which == 3) 
      return false; 
     } 
     else 
      if (event.button == 2 || event.button == 3){ 
       event.cancelBubble = true 
       event.returnValue = false; 
       return false; 
      } 
    } 
    document.oncontextmenu = nocontextmenu; // for IE5+ 
    //document.onmousedown = norightclick; 
    document.onclick = HideMenu;
    document.ondblclick = nodblClick;
</script>
