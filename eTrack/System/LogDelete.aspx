<%@ Page Language="VB" AutoEventWireup="true" CodeFile="LogDelete.aspx.vb" Inherits="LogDelete" Culture="auto" meta:resourcekey="Page" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head  runat="server">
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/Calendar.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/LogDelete.css" rel="Stylesheet" type="text/css" />
    <!--#include file="../JavaScript/JsConst.js"-->
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"> </script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>   
    <script type="text/javascript">   
    function GetValue()
    {
        var strValue="";
        //Date
        strValue=strValue+document.getElementById("chkDate").checked;
        strValue=strValue+ColSeparator+document.getElementById("txtDate").value.Rtrim();
        //User
        strValue=strValue+RowSeparator+document.getElementById("chkUser").checked;
        strValue=strValue+ColSeparator+document.getElementById("txtUser").value.Rtrim();
        //Remark
        strValue=strValue+RowSeparator+document.getElementById("chkRemark").checked;
        strValue=strValue+ColSeparator+document.getElementById("txtRemark").value.Rtrim();
        //return value 
        return strValue;
    }
      
    function LogDelete()
    {
        if (window.confirm("Confirm to Delete Log?")) {
            context = null;
            intPage=1;
            var arg = "LogDelete"+ParSeparator+GetValue();
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetSourceValue", "context")%>; 
            return false;
        }
        else {
            return false;
        }       
    }
    
    function SetSourceValue(result, context) 
    { 
        strResult=result.split(ParSeparator);
        if(strResult.length==2){
            window.alert(strResult[1]);
        }
    }    
   </script>
</head>
<body>
    <form id="frmLogQuery" runat="server">
        <div id="divForm">
            <div id="divTopNav">
                <ul id="ulTopNav">
                    <li><asp:Label ID="lblTitle" CssClass ="f12e navNml navOn" runat="server" Text ="<%$ Resources:Page.Title%>"></asp:Label></li>
                </ul>
            </div>
            <div id="divMiddle" class="divBorder" >
                <div class="divline">
                    <asp:CheckBox ID="chkDate" runat="server" CssClass="CheckBox" Text="<%$ Resources:chkDate.Text%>" />
                    <asp:TextBox ID="txtDate" runat="server" CssClass="TextBox"  ></asp:TextBox>
                    <asp:Button ID="btnDate" runat="server" CssClass="Button" Text="..." UseSubmitBehavior="False" />
                </div>
                <div class="divline">
                    <asp:CheckBox ID="chkUser" runat="server" CssClass="CheckBox" Text="<%$ Resources:chkUser.Text%>" />
                    <asp:TextBox ID="txtUser" runat="server" CssClass="TextBox"  ></asp:TextBox>
                </div>    
                 <div class="divline">
                    <asp:CheckBox ID="chkRemark" runat="server" CssClass="CheckBox" Text="<%$ Resources:chkRemark.Text%>" />
                    <asp:TextBox ID="txtRemark" runat="server" CssClass="TextBox" ></asp:TextBox>
                </div>              
            </div>
            <div id="divBottomNav">
                <asp:Button ID="btnOk" runat="server" CssClass="Button" Text="<%$ Resources:btnOk.Text%>"  UseSubmitBehavior="false"/>
            </div>
        </div>
    </form>
</body>
</html>
