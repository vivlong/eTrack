<%@ Page Language="VB" AutoEventWireup="true" CodeFile="AdvSearchEdit.aspx.vb" Inherits="AdvSearchEdit" Culture="auto" meta:resourcekey="Page" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title></title>
    <base target="_self" ></base>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" /> 
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" /> 
    <link href="App_Themes/AdvSearchEdit.css" rel="Stylesheet" type="text/css" /> 
    <script language="javascript" type="text/javascript">
    function ClosingWindow(CloseFlag)
    {
        if (CloseFlag==1){
            window.returnValue=GetAdvCondition();
        }
        else{
            window.returnValue=null;
        }
        window.close(); 
    }

    function SqlSafe(str)
    {
	    var inputStr, strLen, tmpStr;
	    tmpStr = "";
	    inputStr = str.toString();
	    strLen = inputStr.length;
	    for (var i=0; i<strLen; i++){
		    if (inputStr.charAt(i) == "'")
			    tmpStr = tmpStr + "''";
		    else
			    tmpStr = tmpStr + inputStr.charAt(i);
	    }
	    return tmpStr;
    }
    
    function GetAdvCondition()
    {
        var ret="";
        for(var i=1;i<6;i++){
            var strDropName="drpCondition"+i;  
            var objDrop=document.getElementById(strDropName);
            var FieldValue=objDrop.options[objDrop.selectedIndex].value;
            var strWhere=document.getElementById("txtCondition"+i).value;
            strWhere=SqlSafe(strWhere);
            if(FieldValue!="" && strWhere!=""){
                var arrFieldName=FieldValue.split(",");
                var strSearch=""
                if (arrFieldName[1]=="0"){
                    strSearch=arrFieldName[0]+" like '%"+strWhere+"%' ";
                }
                else{
                    strSearch=" and Cast("+arrFieldName[0]+" as NVarChar(50))"+" like '%"+strWhere+"%'";
                }
                if(ret){
                    ret+=strSearch;
                }
                else{
                    ret=strSearch;
                }
            }            
        }  
        return ret;
    }

    function CloseWindow()
    {
        window.close();
    }
    </script>
</head>
<body onunload="CloseWindow();">
    <form id="AdvSearchPage" runat="server">
        <div id="divForm">
            <div id="divTopNav">
                <ul id="ulTopNav">
                    <li><asp:Label ID="lblPage" CssClass ="f12e navNml navOn" runat="server" Text ="<%$ Resources:lblPage.Text %>" ></asp:Label></li>
                </ul>
            </div>
            <div id="divMiddle" class="divBorder" >
                <div class="divline">
                    <asp:DropDownList ID="drpCondition1"  runat="server" CssClass="drpCondition" />              
                    <asp:TextBox ID="txtCondition1" runat="server" CssClass="txtCondition" />
                </div>
                <div class="divline">
                    <asp:DropDownList ID="drpCondition2" runat="server" CssClass="drpCondition" />              
                    <asp:TextBox ID="txtCondition2" runat="server" CssClass="txtCondition" />
                </div>
                <div class="divline">
                    <asp:DropDownList ID="drpCondition3" runat="server" CssClass="drpCondition" />              
                    <asp:TextBox ID="txtCondition3" runat="server" CssClass="txtCondition" />
                </div>
                <div class="divline">
                    <asp:DropDownList ID="drpCondition4" runat="server" CssClass="drpCondition" />              
                    <asp:TextBox ID="txtCondition4" runat="server" CssClass="txtCondition" />
                </div>
                <div class="divline">
                    <asp:DropDownList ID="drpCondition5" runat="server" CssClass="drpCondition" />              
                    <asp:TextBox ID="txtCondition5" runat="server" CssClass="txtCondition" />
                </div>
            </div>  
            <div id="divBottomNav">
                <asp:Button ID="btnOk" runat="server" Text="<%$ Resources:btnOk.Text %>" CssClass="Button" UseSubmitBehavior="False"  />
                <asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:btnCancel.Text %>" CssClass="Button" UseSubmitBehavior="False" />
            </div>               
         </div>    
    </form>
</body>
</html>
