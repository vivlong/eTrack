<%@ Page Language="VB" AutoEventWireup="true" CodeFile="DoubleSelectPage.aspx.vb"
    Inherits="DoubleSelectPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/js_lzw.js" -->
    <!-- #include file="JavaScript/NoPaginationSingleSelect.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script language="javascript" type="text/javascript">
        function GetQuery() {
            //by lzw
            strQuery = document.getElementById("txtSearch").value;
            var objSearchField = document.getElementById("drpSearch");
            if (objSearchField) {
                var arrFieldName = objSearchField.options[objSearchField.selectedIndex].value.split(",");
                if (arrFieldName[1] == "0") {
                    if (strQuery == " ") {
                        strQuery = " and (" + arrFieldName[0] + " is null or " + arrFieldName[0] + "='') ";

                    }
                    else { strQuery = "  and " + arrFieldName[0] + " like '%" + strQuery + "%' "; }
                }
                else {
                    if (strQuery == " ") {
                        strQuery = "  and (" + arrFieldName[0] + " is null or " + arrFieldName[0] + "='') ";
                    }
                    else { strQuery = "  and Cast(" + arrFieldName[0] + " as NVarChar(50))" + " like '%" + strQuery + "%' "; }
                }
            }
            strQuery = strWhere + strQuery;
        }
        function killerrors() {
            return true;
        }
        window.onerror = killerrors; 
    </script>
</head>
<body>
    <form id="frmAirline" runat="server">
    <div id="divTitle">
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
    <div id="divSearch">
        <div class="searchICO fLeft">
        </div>
        <asp:DropDownList ID="drpSearch" runat="server" CssClass="fLeft drpSearch" Width="160px" />
        <asp:TextBox ID="txtSearch" runat="server" CssClass="txInput txtSearch" />
        <asp:Button ID="btnSearch" runat="server" CssClass="btnFnt" Width="60px" Text="Search"
            UseSubmitBehavior="false" />
    </div>
    <div id="divSource" style="height: 380px; width :790px">
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
            <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose.Text %>" CssClass="Button"
                UseSubmitBehavior="False" />
        </div>
    </div>
    <asp:HiddenField ID="hid_val" runat="server" Value="1" />
    </form>
</body>
</html>
