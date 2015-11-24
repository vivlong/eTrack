<%@ Page Language="VB" AutoEventWireup="true" CodeFile="DynamicColumnEdit.aspx.vb"
    Inherits="DynamicColumnEdit" Culture="auto" meta:resourcekey="Page" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <base target="_self"></base>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/DynamicColumnEdit.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script>
	<script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->

    <script language="javascript" type="text/javascript">
    var indexMain = parent.layer.getFrameIndex(window.name);    
    var indexLoad;
    function CloseWindow()
    {    
        /*
        window.close();
        */
        parent.layer.close(indexMain);    
    }
    
    function GetDefaultSetting()
    {
        var context=divMiddle;
        var arg = "GetDefaultSetting";
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturn", "context")%>;         
    }   

    function SetReturn(result,context)
    {    
        context.innerHTML = result; 
    }

    function GetValues()
    {
        var strValues="";
        var sourcetable=document.getElementById("gvwSource");	
        if(sourcetable==null){return false;}
        var row;
        var cell;
        for (var i = 1; i < sourcetable.rows.length; i++) {
	        row = sourcetable.rows[i];
	        if (strValues) {
                strValues=strValues +RowSeparator+row.cells[0].innerText+ColSeparator+row.cells[1].childNodes[0+ChildSpl].value+ColSeparator+row.cells[2].childNodes[0+ChildSpl].value; 
            }
            else{
                strValues=row.cells[0].innerText+ColSeparator+row.cells[1].childNodes[0+ChildSpl].value+ColSeparator+row.cells[2].childNodes[0+ChildSpl].value; 
            }
   	        cell=row.cells[3];
            if(cell.childNodes[0+ChildSpl].type=="checkbox"){
                var objChecked=cell.childNodes[0+ChildSpl]
                if (objChecked.checked) {
                    strValues=strValues+ColSeparator+'1'+ColSeparator+objChecked.value;
                }                       
                else {
                    strValues=strValues+ColSeparator+'0'+ColSeparator+objChecked.value;
                }
            }    
        }  
        return strValues;
    }
    
    function SaveGridColumnSetting()
    {
        indexLoad = layer.load(0, {shade: false});
        var context=null;
        var arg = "SaveGridColumnSetting"+ParSeparator+GetValues();
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SaveReturn", "context")%>;         
    }
    function SaveReturn(result,context)
    {
        layer.close(indexLoad);
        parent.layer.close(indexMain);
        /*
        if (result==1){
            window.returnValue=1;
        }
        else{
            window.returnValue="";
        }
        window.close();
        */
    }
    
    function selectAll(strFlag,objc)
    {
        var flag =document.getElementById("chkAll").checked;
        var sourcetable=document.getElementById("gvwSource");
        if(sourcetable==null){return false;}
        var chk;
        var tr;
        if(sourcetable.rows.length>0 && strFlag =="int")
        {
            for (var i = 1; i < sourcetable.rows.length; i++)
            {
		          tr = sourcetable.rows[i];
		           if (tr.cells[3].hasChildNodes()&& (tr.cells[3].childNodes[0+ChildSpl].nodeType==1 || tr.cells[3].childNodes[0+ChildSpl].nodeType==3))
		           {
		                if(navigator.userAgent.indexOf("MSIE")>0)
		                {
		                   chk=tr.cells[3].childNodes[0+ChildSpl];
		                   chk.checked=flag;
		                }
		                else
		                {
	                       var objChk=tr.cells[3].getElementsByTagName("input")[0];
	                       objChk.checked=flag;		   		            
		                }
		           }
	          }
	      }
	      else
	      {
            for (var i = 1; i < sourcetable.rows.length; i++)
            {
		          tr = sourcetable.rows[i];
		           if (tr.cells[3].hasChildNodes()&& (tr.cells[3].childNodes[0+ChildSpl].nodeType==1 || tr.cells[3].childNodes[0+ChildSpl].nodeType==3))
		           {
		                if(navigator.userAgent.indexOf("MSIE")>0)
		                {chk=tr.cells[3].childNodes[0+ChildSpl];}
		                else
		                {chk=tr.cells[3].getElementsByTagName("input")[0];}
		                if(flag==false)
		                {chk.checked=false;}
		                else
		                {
    		                if(i<=10){chk.checked=true;}
		                }
		           }
	          }
	      }
    }
    
    function JudChk(e,objFlag)
    {
        var j=0;
        var sourcetable=document.getElementById("gvwSource");	
        var chk;
        var tr;
        if(sourcetable.rows.length>0)
        {
            for (var i = 1; i < sourcetable.rows.length; i++)
            {
		          tr = sourcetable.rows[i];
		          if (tr.cells[3].hasChildNodes()&& (tr.cells[3].childNodes[0].nodeType==1 || tr.cells[3].childNodes[0].nodeType==3))
		          {
		        //--------------------------------------------for firefox-------------------------------------------------
		        	 if(navigator.userAgent.indexOf("MSIE")>0)
		            {chk=tr.cells[3].childNodes[0];}
		            else
		            {chk=tr.cells[3].getElementsByTagName("input")[0];}
		        //--------------------------------------------------------------------------------------------------------
		            if(chk.checked)
		              {
		                j+=1;
		                if(j>10 && objFlag=='cus')
		                 { 
                           alert("Only can show 10 columns");
		                        if(window.event)
		                          window.event.returnValue = false;
		                        else
		                          e.preventDefault();//for firefox
		                 }
		              }
		            }
	           }
	       }
    }
    </script>

</head>
<body onunload="CloseWindow();">
    <form id="frmDynamicColumnSet" runat="server">
    <div id="divForm">
        <div id="divTopNav">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="lblPage" CssClass="f12e navNml navOn" runat="server" Text="<%$ Resources:lblPage.Text %>"></asp:Label></li>
                <li style="width: 330px;"></li>
                <li style="text-align: right; padding-top: 5px;">
                    <asp:CheckBox ID="chkAll" runat="server" Text="<%$ Resources:chkAll %>" /></li>
            </ul>
        </div>
        <div id="divMiddle" class="divBorder">
            <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" 
                EnableViewState="False">
                <Columns>
                    <asp:BoundField HeaderText="<%$ Resources:BoundField1.HeaderText %>" DataField="FieldTitle">
                        <ItemStyle CssClass="colTitle taLeft" />
                        <HeaderStyle CssClass="colTitle taCenter " />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="<%$ Resources:TemplateField1.HeaderText %>">
                        <ItemTemplate>
                            <asp:TextBox ID="txtPosition" runat="server" Text='<%# Eval("Position","{0:#,##0}") %>'
                                CssClass="gridInput"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle CssClass="colPosition taRight" />
                        <HeaderStyle CssClass="colPosition taCenter" />
                        <FooterStyle CssClass="taRight" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:TemplateField2.HeaderText %>">
                        <ItemTemplate>
                            <asp:TextBox ID="txtWidth" runat="server" Text='<%# Eval("Width","{0:#,##0.0}") %>'
                                CssClass="gridInput"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle CssClass="colWidth taRight" />
                        <HeaderStyle CssClass="colWidth taCenter" />
                        <FooterStyle CssClass="taRight" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:TemplateField3.HeaderText %>">
                        <ItemTemplate>
                            <input type="checkbox" id="chkVisible" runat="server" class="checkbox" value='<%# Eval("FieldName") %>'
                                checked='<%# Eval("Visible") %>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="colVisible taCenter" />
                        <ItemStyle CssClass="colVisible taCenter" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="Header" />
                <FooterStyle CssClass="Footer" />
                <RowStyle CssClass="Row" />
                <SelectedRowStyle CssClass="SelectRow" />
                <PagerStyle CssClass="Pager" />
                <AlternatingRowStyle CssClass="Alternating" />
            </asp:GridView>
        </div>
        <div id="divBottomNav">
            <div id="BottomLeft" class="fLeft">
                <asp:Button ID="btnDefault" runat="server" Text="<%$ Resources:btnDefault.Text %>"
                    CssClass="Button" UseSubmitBehavior="False" />
            </div>
            <div>
                <asp:Button ID="btnOk" runat="server" Text="<%$ Resources:btnOk.Text %>" CssClass="Button"
                    UseSubmitBehavior="False" />
                <asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:btnCancel.Text %>"
                    CssClass="Button" UseSubmitBehavior="False" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>