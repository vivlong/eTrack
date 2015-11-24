<%@ Page Language="VB" AutoEventWireup="true" CodeFile="MultiType.aspx.vb" Inherits="MultiType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        @import url("<%=ConfigPath%>/LrErp.css");
        @import url("<%=ConfigPath%>/LrErp_Grid.css");
        @import url("<%=ConfigPath%>/LrErp_List.css");
        @import url("<%=ConfigPath%>/PageControl.css");
    </style>
    <link href="App_Themes/MultiType.css" rel="Stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="JavaScript/MultiType.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script language="javascript" type="text/javascript">
        function GetQuery() 
    {
        //by lzw
         strQuery = document.getElementById("txtSearch").value;
        var objSearchField = document.getElementById("drpSearch");
        if (objSearchField) 
        {
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
        strWhere =strQuery;
    }
  function setConfig(strConfig)
     {
       switch(strConfig)
       {
         case "Blue":
                colorSecond="#e6eff8";
                colorSelected="#9fbbe2";
                break ;
         case "Orange":
                colorSecond="#feecdb";
                colorSelected="#fecb99";
                break ;
         case "Blue":
                colorSecond="#e6eff8";
                colorSelected="#9fbbe2";
                break ;
         default :
                colorSecond="#e6eff8";
                colorSelected="#9fbbe2";
                break ;
       }
     }
    </script>

</head>
<body onload="setConfig('<%=ExportConfig%>');">
    <form id="frmMultiType" runat="server">
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
        <asp:DropDownList ID="drpSearch" runat="server" CssClass="fLeft drpSearch DropList"
            Width="160px" />
        <asp:TextBox ID="txtSearch" runat="server" CssClass="txInput txtSearch" />
        <asp:Button ID="btnSearch" runat="server" CssClass="btnFnt" Width="60px" Text="Search"
            UseSubmitBehavior="false" />
    </div>
    <div id="divSource" style="height: 400px;">
        <asp:GridView ID="gvwSource" runat="server" OnRowDataBound="gvwSource_RowDataBound"
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
    </div>
    <div id="divBottomNav">
        <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose.Text %>" CssClass="Button"
            UseSubmitBehavior="False" />
        &nbsp
    </div>
    <asp:HiddenField ID="hid_val" runat="server" Value="1" />
    </form>
</body>
</html>
