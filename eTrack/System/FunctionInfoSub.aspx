<%@ Page Language="VB" AutoEventWireup="true" CodeFile="FunctionInfoSub.aspx.vb" Inherits="FunctionInfoSub" 
 Culture="auto" meta:resourcekey="Page" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>FunctionInfo</title>
    <base target="_self"></base>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/FunctionInfo.css" rel="Stylesheet" type="text/css" />
    <link href="../UserControl/datepicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
     <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/BaseList.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!-- #include file="JavaScript/FunctionInfoSub.js" -->
    <!--#include file="../JavaScript/DateOperate.js"-->
    
    <script language="javascript" type="text/javascript" src="../JavaScript/Format.js"></script>
    <script language="javascript" type="text/javascript" src="../JavaScript/Common.js"></script>
    
    
    <script language="javascript" type="text/javascript" src="../UserControl/datepicker/WdatePicker.js"></script>

    <script language="javascript" type="text/javascript">
    function on_page_loaded()   
    {   
       blChanged=true;CloseWindow(0);return false;
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
         case "Smalt":
                colorSecond="#e8e8ec";
                colorSelected="#d9cfdd";
                break ;
         default :
                colorSecond="#e6eff8";
                colorSelected="#9fbbe2";
                break ;
       }
     }
    </script>

</head>
<body onunload="on_page_loaded()" onload="setConfig('<%=ExportConfig%>');">
    <form id="frmFunction" runat="server">
    <div id="divForm">
    
          <div id="divTitle">
            <span id="lblTitle" class="Title">FunctionInfo </span>
       
     </div>
        <div id="SaveHint" runat="server" class="Hint" style="left: 0px; top: 10px">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>" />
        </div>
        <div id="divMiddle1" style="width: 100%; height: 420px; padding-top: 10px">
          
            <div id="divSource" style="height: 570px; width: 99%" runat="server">
                <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                    OnRowDataBound="gvwSource_RowDataBound">
                    <%-- --%>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a id="Img2" runat="server" alt="del">
                                    <img id="Img3" runat="server" src="../Images/Edit/ed_Delete.gif" alt="del" />
                                </a>
                                
                            </ItemTemplate>
       
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fun No" >
                            <ItemTemplate>
                                <asp:TextBox ID="txtsFunNo" runat="server" Text='<%# Eval("sFunNo") %>'
                                    MaxLength="10" CssClass="TextBox txtField" BorderStyle="Solid" BorderColor="White"
                                    BorderWidth="0px" />
                               <asp:HiddenField ID="hid_sFunNo" runat="server" Value='<%# Eval("sFunNo") %>' />
                                <asp:HiddenField ID="hid_lSubId" runat="server" Value='<%# Eval("lSubId") %>' />
                           
                            </ItemTemplate>
                   
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fun Name" >
                            <ItemTemplate>
                                <asp:TextBox ID="txtlSubId" runat="server" Text='<%# Eval("lSubId") %>'
                                    MaxLength="5" CssClass="TextBox txtField" BorderStyle="Solid" BorderColor="White"
                                    BorderWidth="0px"  Width="100%"   />
                            </ItemTemplate>
                  
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Code" >
                            <ItemTemplate>
                                <asp:TextBox ID="txtsCode" runat="server" Text='<%# Eval("sCode") %>'
                                    CssClass="TextBox txtField" MaxLength="20" BorderStyle="Solid" BorderColor="White"
                                    BorderWidth="0px" Width="100%"  />
                            </ItemTemplate>
                      
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" >
                            <ItemTemplate>
                                <asp:TextBox ID="txtsName" runat="server" Text='<%# Eval("sName") %>' CssClass="TextBox txtField"
                                    MaxLength="50" Width="100%"   BorderStyle="Solid" BorderColor="White" BorderWidth="0px"
                                    />
                            </ItemTemplate>
                          
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Flag" >
                            <ItemTemplate>
                                <asp:TextBox ID="txtbFlag" runat="server" Text='<%# Eval("bFlag") %>'
                                    CssClass="TextBox txtField" MaxLength="5" BorderStyle="Solid" BorderColor="White"
                                    BorderWidth="0px"  Width="20px" />
                            </ItemTemplate>
                        
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sub Type" >
                            <ItemTemplate>
                                <asp:TextBox ID="txtSubType" runat="server" Text='<%# Eval("SubType") %>'
                                    CssClass="TextBox txtField" MaxLength="1" BorderStyle="Solid" BorderColor="White"
                                    BorderWidth="0px"  Width="20px" />
                            </ItemTemplate>
                       
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
            <br />
        </div>
        <div id="divBottomNav" style="display:none">
            <asp:Button ID="btnSave" runat="server" Text="Save FunctionInfo" CssClass="Button"
                UseSubmitBehavior="False" Width="130px" Visible="False" />
            <%-- <asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:btnCancel %>" CssClass="Button"
                UseSubmitBehavior="False" Width="100px" />--%>
        </div>
        <input name='txtTRLastIndex' type='hidden' id='txtTRLastIndex' value="1" />
        <asp:HiddenField ID="fldId" runat="server" />
        <asp:HiddenField ID="hidBatchNo" runat="server" />
    </div>
    </form>
</body>
</html>