<%@ Page Language="VB" AutoEventWireup="true" CodeFile="DeliveryOrder.aspx.vb" Inherits="DeliveryOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
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
    <!-- #include file="../JavaScript/PopupMenu.js" -->
    <!--#include file="JavaScript/DeliveryOrder.js" -->
    <!--#include file="../JavaScript/Print.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Reference.js"></script>

    <script language="javascript" type="text/javascript">
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
          TableName="sido1";
          SortField="TrxNo";
         document.getElementById('divdrpSearch1').style.display="block";
         document.getElementById('divdrpSearch2').style.display="none";
         
    }
    else if(selectId==2)
    {
          TableName="aido1";
          SortField="DeliveryOrderNo"
          document.getElementById('divdrpSearch1').style.display="none";
          document.getElementById('divdrpSearch2').style.display="block";
    }
     document.getElementById('hidVal_DeliveryOrder').value=selectId;
     context=document.getElementById('hid_div');
     var arg="SetTabVal"+ParSeparator+selectId;
     <%= ClientScript.GetCallbackEventReference(Me,"arg","SetResult", "context")%>; 
    }
       function SetResult(result,context)
   {
    var strResult=result.split(ParSeparator);
            if (strResult[0]==RtnOk) {
            context.innerHTML=strResult[1];
            }
            else if (strResult[1]!=""){
                window.alert(strResult[1]);
            }
   }
       function GetQuery() 
    {
        //by lzw
        strWhere="";
        var strWhereBook = "";
        var strQuery = document.getElementById("txtSearch").value;
        var objSearchField = document.getElementById("drpSearch1");
        var divdrpSearch1=document.getElementById('divdrpSearch1');
        if(divdrpSearch1.style.display=="" || divdrpSearch1.style.display=="block"){objSearchField = document.getElementById("drpSearch1");}
        else{objSearchField = document.getElementById("drpSearch2");}
        if (objSearchField) 
        {
            var arrFieldName = objSearchField.options[objSearchField.selectedIndex].value.split(",");
            if(arrFieldName[0].length!=0)
            {    
                if (arrFieldName[1] == "0") 
                {
                    if (strQuery.Trim == "") 
                    {
                        strWhere = " and (" + arrFieldName[0] + " is null or " + arrFieldName[0] + "='') ";
                    }
                    else { strWhere = "  and " + arrFieldName[0] + " like '%" + strQuery + "%' "; }
                }
                else 
                {
                    if (strQuery.Trim == "") 
                    {
                        strWhere = "  and (" + arrFieldName[0] + " is null or " + arrFieldName[0] + "='') ";
                    }
                    else { strWhere = "  and Cast(" + arrFieldName[0] + " as NVarChar(50))" + " like '%" + strQuery + "%' "; }
                }
            }
        }
        strWhere = strWhere + strWhereBook;
    }
   function AdvGetQuery() {}
    
    </script>

</head>
<body onload="DivAutoSize(120);" onresize="DivAutoSize(120);">
    <form id="frmDeliveryOrder" runat="server">
    <div id="divTopNav" runat="server">
        <ul id="ulTopNav">
            <li>
                <asp:Label ID="a1" CssClass="f12e navNml navOn" runat="server" Width="115px" onclick="javascript:SelectedDivl(1,2);GetQueryData(1);"
                    Text="<%$ Resources:a1 %>"></asp:Label></li>
            <li>
                <asp:Label ID="a2" CssClass="f12c navNml noSep" runat="server" Width="115px" onclick="javascript:SelectedDivl(2,2);GetQueryData(2);"
                    Text="<%$ Resources:a2 %>"></asp:Label></li>
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
    <div id="divSearch" class="divSearch">
        <div class="searchICO fLeft">
        </div>
        <div id="divdrpSearch1" style="display: none;" runat="server">
            <asp:DropDownList ID="drpSearch1" runat="server" CssClass="fLeft" />
        </div>
        <div id="divdrpSearch2" style="display: none;" runat="server">
            <asp:DropDownList ID="drpSearch2" runat="server" CssClass="fLeft" />
        </div>
        <asp:TextBox ID="txtSearch" runat="server" CssClass="txInput txtSearch" />
        <asp:Button ID="btnSearch" runat="server" CssClass="btnFnt" Width="60px" Text="Search"
            UseSubmitBehavior="false" />
        <asp:Button ID="btnAdvSearch" runat="server" CssClass="btnFnt" Width="60px" Text="Advance"
            UseSubmitBehavior="false" />
        <input id="btn" type="button" class="Button btnFnt" value="Custom" onclick="GridColumnSet()"
            style="cursor: hand; width: 60px" />
    </div>
    <div id="divSource">
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
        <asp:HiddenField ID="hidVal_DeliveryOrder" runat="server" Value="1" />
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
