<%@ Page Language="VB" AutoEventWireup="true" CodeFile="FunctionInfo.aspx.vb" Inherits="FunctionInfo" 
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
    <!-- #include file="JavaScript/FunctionInfo.js" -->
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
                                    MaxLength="13" CssClass="TextBox txtField" BorderStyle="Solid" BorderColor="White"
                                    BorderWidth="0px" />
                               <asp:HiddenField ID="hid_sFunNo" runat="server" Value='<%# Eval("sFunNo") %>' />
                                <asp:HiddenField ID="hid_sFunName" runat="server" Value='<%# Eval("sFunName") %>' />
                           
                            </ItemTemplate>
                   
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fun Name" >
                            <ItemTemplate>
                                <asp:TextBox ID="txtsFunName" runat="server" Text='<%# Eval("sFunName") %>'
                                    MaxLength="50" CssClass="TextBox txtField" BorderStyle="Solid" BorderColor="White"
                                    BorderWidth="0px"  Width="100%"   />
                            </ItemTemplate>
                  
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fun Url" >
                            <ItemTemplate>
                                <asp:TextBox ID="txtsFunUrl" runat="server" Text='<%# Eval("sFunUrl") %>'
                                    CssClass="TextBox txtField" MaxLength="100" BorderStyle="Solid" BorderColor="White"
                                    BorderWidth="0px" Width="100%"  />
                            </ItemTemplate>
                      
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Image" >
                            <ItemTemplate>
                                <asp:TextBox ID="txtsImage" runat="server" Text='<%# Eval("sImage") %>' CssClass="TextBox txtField"
                                    MaxLength="100" Width="100%"   BorderStyle="Solid" BorderColor="White" BorderWidth="0px"
                                    />
                            </ItemTemplate>
                          
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Parent No" >
                            <ItemTemplate>
                                <asp:TextBox ID="txtsParentNo" runat="server" Text='<%# Eval("sParentNo") %>'
                                    CssClass="TextBox txtField" MaxLength="10" BorderStyle="Solid" BorderColor="White"
                                    BorderWidth="0px"  Width="20px" />
                            </ItemTemplate>
                        
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type" >
                            <ItemTemplate>
                                <asp:TextBox ID="txtlType" runat="server" Text='<%# Eval("lType") %>'
                                    CssClass="TextBox txtField" MaxLength="3" BorderStyle="Solid" BorderColor="White"
                                    BorderWidth="0px"  Width="20px" />
                            </ItemTemplate>
                       
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User Flag" >
                            <ItemTemplate>
                                <asp:TextBox ID="txtUserFlag" runat="server" Text='<%# Eval("UserFlag") %>'
                                    CssClass="TextBox txtField" MaxLength="1" BorderStyle="Solid" BorderColor="White"
                                    BorderWidth="0px"  Width="10px" />
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