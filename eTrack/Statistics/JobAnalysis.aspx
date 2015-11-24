<%@ Page Language="VB" AutoEventWireup="true" CodeFile="JobAnalysis.aspx.vb" Inherits="JobAnalysis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/JobAnalysis.css" rel="stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/js_lzw.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->
    <!--#include file="../JavaScript/Print.js" -->
    <!--#include file="JavaScript/Chart.js" -->

    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>

    <script language="javascript" type="text/javascript">
        function PrintDetail(intId) {
            if (intId) {
                var strUrl = "../loading.aspx?tourl=" + PrintPath + "/crJobAnalysis.aspx?Id=" + intId.toString() + "";
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
          TableName="Aeaw1_Manifest";
    }
    else if(selectId==2)
    {
          TableName="Sebl1_Manifest";
    }
     document.getElementById('hidVal_JobAnalysis').value=selectId;
     context=document.getElementById('hid_div');
     var arg="SetTabVal"+ParSeparator+selectId;
     <%= ClientScript.GetCallbackEventReference(Me,"arg","SetResult", "context")%>; 
    }
       function SetResult(result,context)
   {
   
      var strResult=result.split(ParSeparator);
            if (strResult[0]==RtnOk) {
            context.innerHTML=strResult[1];
            document.getElementById('div_Search').innerHTML=strResult[2];
            }
            else if (strResult[1]!=""){
                window.alert(strResult[1]);
            }
   }
    </script>

</head>
<body onload="DivAutoSize(170);" onresize="DivAutoSize(170);">
    <form id="frmJobAnalysis" runat="server">
    <div id="divTopNav" runat="server" class="divWid">
        <ul id="ulTopNav">
            <li>
                <asp:Label ID="a1" CssClass="f12e navNml navOn" runat="server" Width="115px" onclick="javascript:SelectedDivl(1,6);"
                    Text="<%$ Resources:a1 %>"></asp:Label></li>
            <li>
                <asp:Label ID="a2" CssClass="f12c navNml noSep" runat="server" Width="115px" onclick="javascript:SelectedDivl(2,6);"
                    Text="<%$ Resources:a2 %>"></asp:Label></li>
            <li>
                <asp:Label ID="a3" CssClass="f12c navNml noSep" runat="server" Width="115px" onclick="javascript:SelectedDivl(3,6);"
                    Text="<%$ Resources:a3 %>"></asp:Label></li>
            <li>
                <asp:Label ID="a4" CssClass="f12c navNml noSep" runat="server" Width="115px" onclick="javascript:SelectedDivl(4,6);"
                    Text="<%$ Resources:a4 %>"></asp:Label></li>
            <li>
                <asp:Label ID="a5" CssClass="f12c navNml noSep" runat="server" Width="115px" onclick="javascript:SelectedDivl(5,6);"
                    Text="<%$ Resources:a5 %>"></asp:Label></li>
            <li>
                <asp:Label ID="a6" CssClass="f12c navNml noSep" runat="server" Width="115px" onclick="javascript:SelectedDivl(6,6);"
                    Text="<%$ Resources:a6 %>"></asp:Label></li>
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
    <div id="divSearch" class="divJobAnalysis divSearch" style="height: 53px;" runat="server">
        <div class="divline">
            <asp:Label ID="lblYear" runat="server" Text="<%$ Resources:lblYear %>" CssClass="Label lbl"
                Width="62px" />&nbsp
            <asp:DropDownList ID="drYear" runat="server" />
            &nbsp&nbsp&nbsp;&nbsp;
            <asp:Label ID="lblMonth" runat="server" Text="<%$ Resources:lblMonth %>" CssClass="Label lblMonth"
                Width="54px" />
            <asp:DropDownList ID="drMonth" runat="server" />
            &nbsp&nbsp&nbsp&nbsp&nbsp To&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:DropDownList ID="drMonthTo" runat="server" />
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:DropDownList ID="drType" runat="server" />
        </div>
        <div class="divline">
            <div id="div_Search">
                <asp:DropDownList ID="drpSearch" runat="server" CssClass="fLeft drpSearch" />
            </div>
            &nbsp
            <asp:TextBox ID="txtSearch" runat="server" CssClass="txInput txtSearch" />
            <asp:Button ID="btnSearch" runat="server" CssClass="btnFnt" Width="60px" Text="Query"
                UseSubmitBehavior="false" />
        </div>
    </div>
    <div id="divSource" style="width: 99%;">
        <div>
            <table cellspacing="0" rules="all" border="1" id="tbhard" style="width: 800px; border-collapse: collapse;">
                <tr class="Header">
                    <th scope="col">
                        <div class="divline">
                            <asp:Label ID="lblGroupBy" runat="server" Text="Group By"></asp:Label> &nbsp
                            <asp:DropDownList ID="drhard" runat="server" CssClass="drpSearch" />
                        </div>
                    </th>
                    <th scope="col">
                        Jan
                    </th>
                    <th scope="col">
                        Feb
                    </th>
                    <th scope="col">
                        Mar
                    </th>
                    <th scope="col">
                        Apr
                    </th>
                    <th scope="col">
                        May
                    </th>
                    <th scope="col">
                        Jun
                    </th>
                    <th scope="col">
                        Jul
                    </th>
                    <th scope="col">
                        Aug
                    </th>
                    <th scope="col">
                        Sep
                    </th>
                    <th scope="col">
                        Oct
                    </th>
                    <th scope="col">
                        Nov
                    </th>
                    <th scope="col">
                        Dec
                    </th>
                    <th scope="col" style="width: 150px;">
                        Total
                    </th>
                </tr>
                <tr class="Row" onmouseover="RowMouseOver(this)" onmouseout="RowMouseOut(this,1)">
                    <td align="left">
                        <a href="javascript:showChart('12,8,2,18,9,11,15,5,16,4,7,13');">WAP LOGISTICS (S) PTE
                            LTD</a>
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
                        <a href="javascript:showChart('4,6,1,9,7,3,4,6,8,2,9,1');">KAMIGUMI(HONG KONG) CO.,LTD.</a>
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
                        <a href="javascript:showChart('7,8,9,6,11,4,15,0,14,1,13,7');">ICELAND AIR</a>
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
                        <a href="javascript:showChart('3,37,15,25,38,2,7,33,1,39,5,35');">SERVICES</a>
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
                        <a href="javascript:showChart('30,0,29,1,18,12,17,13,16,14,7,13');">KAMIGUMI(HONG KONG)
                            CO.,LTD.</a>
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
        <asp:HiddenField ID="hidVal_JobAnalysis" runat="server" Value="1" />
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
