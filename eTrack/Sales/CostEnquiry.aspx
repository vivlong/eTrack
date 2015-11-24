<%@ Page Language="VB" AutoEventWireup="true" CodeFile="CostEnquiry.aspx.vb" Inherits="CostEnquiry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/CostEnquiry.css" rel="Stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/js_lzw.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->
    <!--#include file="../JavaScript/Print.js" -->

    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script language="javascript" type="text/javascript">
        function PrintDetail(intId) {
            if (intId) {
                var strUrl = "../loading.aspx?tourl=" + PrintPath + "/crCostEnquiry.aspx?Id=" + intId.toString() + "";
                window.open(strUrl);
            }
        }
    </script>

</head>
<body onload="DivAutoSize(180);" onresize="DivAutoSize(180);">
    <form id="frmCostEnquiry" runat="server">
    <div id="divTitle">
        &nbsp
        <asp:Label ID="Label1" CssClass="Title" runat="server" Text="<%$ Resources:lblTitle.Text %>"></asp:Label>
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
    <div id="divSearchAir" class="divCost divSearch" style="height: 53px;" runat="server" >
        <div class="divLine">
            <div class="divline">
                <asp:Label ID="lblOrginCode" runat="server" Text="<%$ Resources:lblOrginCode %>"
                    CssClass="Label lbl" />
                <asp:TextBox ID="txtOrginCode" runat="server" CssClass="TextBox bntDate" MaxLength="5" />
                <div id="divDischarge" style="display: inline">
                    <asp:TextBox ID="txtOrginName" runat="server" ReadOnly="true" CssClass="TextBox txt" />
                </div>
            </div>
            <div class="divline">
                <asp:Label ID="lblDestCode" runat="server" Text="<%$ Resources:lblDestCode %>" CssClass="Label lbl" />
                <asp:TextBox ID="txtDestCode" runat="server" CssClass="TextBox bntDate" MaxLength="50" />
                <asp:TextBox ID="TextBox3" runat="server" CssClass="TextBox txt" MaxLength="50" />
                <asp:Button ID="btnSearchAir" runat="server" CssClass="Button" Text="Search" UseSubmitBehavior="false" />
            </div>
        </div>
    </div>
    <div id="divSearchSea" class="divCost" style="height: 80px; display: none" runat="server">
        <div class="divLine">
            <div class="divline">
                <asp:Label ID="lblPortofLoadiing" runat="server" Text="<%$ Resources:lblPortofLoadiing %>"
                    CssClass="Label lbl" />
                <asp:TextBox ID="txtPortofLoadiingCode" runat="server" CssClass="TextBox bntDate"
                    MaxLength="5" />
                <div id="div3" style="display: inline">
                    <asp:TextBox ID="txtPortofLoadiingName" runat="server" ReadOnly="true" CssClass="TextBox txt" />
                </div>
            </div>
            <div class="divline">
                <asp:Label ID="lblPortofDischarge" runat="server" Text="<%$ Resources:lblPortofDischarge %>"
                    CssClass="Label lbl" />
                <asp:TextBox ID="txtPortofDischargeCode" runat="server" CssClass="TextBox bntDate"
                    MaxLength="50" />
                <asp:TextBox ID="txtPortofDischargeName" runat="server" CssClass="TextBox txt" MaxLength="50" />
            </div>
            <div class="divline">
                <asp:Label ID="lblViaPort" runat="server" Text="<%$ Resources:lblViaPort %>" CssClass="Label lbl" />
                <asp:TextBox ID="txtViaPortCode" runat="server" CssClass="TextBox bntDate" MaxLength="5" />
                <div id="div4" style="display: inline">
                    <asp:TextBox ID="txtViaPortName" runat="server" ReadOnly="true" CssClass="TextBox txt" />
                </div>
                <asp:Button ID="btnSearchSea" runat="server" CssClass="Button" Text="Search" UseSubmitBehavior="false" />
            </div>
        </div>
    </div>
    <fieldset style="padding-left: 3px">
        <legend>Cost Rate</legend>
        <div id="divSource" style="width: 99%">
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
    </fieldset>
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
    <asp:HiddenField ID="hid_val" runat="server" Value="1" />
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
