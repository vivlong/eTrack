<%@ Page Language="VB" AutoEventWireup="true" CodeFile="GridSet.aspx.vb" Inherits="GridSet"
    Culture="auto" meta:resourcekey="Page" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>GridSet</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/GridSet.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../App_Themes/default/easyui.css">
    <link rel="stylesheet" type="text/css" href="../App_Themes/icon.css">
    <link href="../App_Themes/icon.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <script type="text/javascript" src="../JavaScript/jquery.easyui.min.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/BaseList.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!--#include file="../JavaScript/DateOperate.js"-->
    <!-- #include file="JavaScript/GridSet.js" -->
    <script language="javascript" type="text/javascript" src="../JavaScript/Common.js"></script>
    <script language="javascript" type="text/javascript">
        $(function () {
            windowResize();
            $(window).resize(function () {
                windowResize();
            });
        });
        function getWindowHeight() {
            return $(window).height();
        }
        function getWindowWidth() {
            return $(window).width();
        }
        function windowResize() {
            var width = getWindowWidth();
            var height = getWindowHeight();
            $('form#form1').width(width);
            $('form#form1').height(height);
            $('form#form1').layout();
            $('div#divSource').height(height - 57);
        }
        function SetWidth() {

        }
    </script>
</head>
<body>
    <form id="form1" runat="server" class="easyui-layout" style="width: 100%; height: 100%;">
    <div region="center" class="divNonScroll">
        <div id="divSearch" class="divSearch">
            <div class="searchICO fLeft">
            </div>
            <asp:DropDownList ID="drpSearch" runat="server" CssClass="drSearch fLeft" />
            <div id="div_txtSearch" style="display: inline">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="txInput txtSearch" />
            </div>
            <asp:Button ID="btnSearch" runat="server" CssClass="btnFnt" Width="60px" Text="Search"
                UseSubmitBehavior="false" />
        </div>
        <div id="SaveHint" runat="server" class="Hint" style="left: 0px; top: 10px">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>" />
        </div>
        <div id="divSource" title="Grid Set" style="overflow: scroll; padding-left: 2px;
            width: 99.5%;">
            <div>
                <table cellspacing="0" rules="all" border="1" id="Table1" style="width: 0px; border-collapse: collapse;">
                    <tr class="Header">
                        <th scope="col">
                            &nbsp;
                        </th>
                        <th scope="col">
                            Table Name
                        </th>
                        <th scope="col">
                            Field Name
                        </th>
                        <th scope="col">
                            SortField
                        </th>
                        <th scope="col">
                            FieldType
                        </th>
                        <th scope="col">
                            Setting
                        </th>
                        <th scope="col">
                            FieldVisible
                        </th>
                        <th scope="col">
                            FieldOrder
                        </th>
                        <th scope="col">
                            FieldWidth
                        </th>
                        <th scope="col">
                            ChineseTitle
                        </th>
                        <th scope="col">
                            EnglishTitle
                        </th>
                        <th scope="col">
                            ChineseFormat
                        </th>
                        <th scope="col">
                            EnglishFormat
                        </th>
                        <th scope="col">
                            HeaderImageUrl
                        </th>
                    </tr>
                    <tr class="Row">
                        <td style="width: 20px;">
                            <span class="Label LabelBlock" style="width: 20px">&nbsp;</span>
                        </td>
                        <td style="width: 50px;">
                            <p class="Label">
                                <input maxlength="50" class="TextBox txtField" style="width: 40px" type="text" onkeydown="FocusControlJS(event,null,'addFieldName')"
                                    id="addTableName" /></p>
                        </td>
                        <td style="width: 120px;">
                            <p class="Label">
                                <input maxlength="50" class="TextBox txtField" style="width: 120px" type="text" onkeydown="FocusControlJS(event,'addTableName','addSortField')"
                                    id="addFieldName" /></p>
                        </td>
                        <td style="width: 120px;">
                            <input maxlength="50" class="TextBox txtField" style="width: 120px" type="text" onkeydown="FocusControlJS(event,'addFieldName','addFieldType')" id="addSortField" />
                        </td>
                        <td style="width: 50px;">
                            <input maxlength="20" class="TextBox txtField" style="width: 50px" type="text" onkeydown="FocusControlJS(event,'addSortField','addSetting')" id="addFieldType" />
                        </td>
                        <td style="width: 50px;">
                            <input maxlength="2" class="TextBox txtField" type="text" style="width: 50px" onkeydown="FocusControlJS(event,'addFieldType','addFieldVisible')"  id="addSetting" />
                        </td>
                        <td style="width: 60px;">
                            <input maxlength="2" class="TextBox txtField" style="width: 60px" type="text" onkeydown="FocusControlJS(event,'addSetting','addFieldOrder')" id="addFieldVisible" />
                        </td>
                        <td style="width: 60px;">
                            <input maxlength="3" class="TextBox txtField" style="width: 60px" type="text" onkeydown="FocusControlJS(event,'addFieldVisible','addFieldWidth')" id="addFieldOrder" />
                        </td>
                        <td style="width: 60px;">
                            <input maxlength="3" class="TextBox txtField" style="width: 60px" type="text" onkeydown="FocusControlJS(event,'addFieldOrder','addChineseTitle')" id="addFieldWidth" />
                        </td>
                        <td style="width: 120px;">
                            <input maxlength="50" class="TextBox txtField" style="width: 120px" type="text" onkeydown="FocusControlJS(event,'addFieldWidth','addEnglishTitle')"  id="addChineseTitle" />
                        </td>
                        <td style="width: 120px;">
                            <input maxlength="50" class="TextBox txtField" style="width: 120px" type="text" onkeydown="FocusControlJS(event,'addChineseTitle','addChineseFormat')"  id="addEnglishTitle" />
                        </td>
                        <td style="width: 120px;">
                            <input maxlength="50" class="TextBox txtField" style="width: 120px" type="text" onkeydown="FocusControlJS(event,'addEnglishTitle','addEnglishFormat')" id="addChineseFormat" />
                        </td>
                        <td style="width: 120px;">
                            <input maxlength="50" class="TextBox txtField" style="width: 120px" type="text" onkeydown="FocusControlJS(event,'addChineseFormat','addHeaderImageUrl')" id="addEnglishFormat" />
                        </td>
                        <td style="width: 120px;">
                            <input maxlength="100" class="TextBox txtField" style="width: 120px" type="text" onkeydown="FocusControlJS(event,'addEnglishFormat',null)"
                                id="addHeaderImageUrl" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                OnRowDataBound="gvwSource_RowDataBound">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="20px">
                        <ItemTemplate>
                            <a id="Img2" runat="server" alt="del">
                                <img id="Img3" runat="server" src="../Images/Edit/ed_Delete.gif" alt="del" />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Table Name" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <p class="Label">
                                <%# Eval("sTableName") %>&nbsp;</p>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Field Name" ItemStyle-Width="120px">
                        <ItemTemplate>
                            <span class="Label LabelBlock" style="width: 120px">
                                <%# Eval("sFieldName")%></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SortField" ItemStyle-Width="120px">
                        <ItemTemplate>
                            <input value='<%# Eval("sSortField") %>' maxlength="50" class="TextBox txtField"
                                style="width: 120px" type="text" onchange="UpdateGridSet('<%# Eval("sTableName") %>','<%# Eval("sFieldName") %>','sSortField',this)" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FieldType" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <input value='<%# Eval("sFieldType") %>' maxlength="20" class="TextBox txtField"
                                style="width: 50px" type="text" onchange="UpdateGridSet('<%# Eval("sTableName") %>','<%# Eval("sFieldName") %>',this)" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Setting" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <input value='<%# Eval("bSetting") %>' maxlength="2" class="TextBox txtField" type="text"
                                style="width: 50px" onchange="UpdateGridSet('<%# Eval("sTableName") %>','<%# Eval("sFieldName") %>','bSetting',this)" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FieldVisible" ItemStyle-Width="60px">
                        <ItemTemplate>
                            <input value='<%# Eval("bFieldVisible") %>' maxlength="2" class="TextBox txtField"
                                style="width: 60px" type="text" onchange="UpdateGridSet('<%# Eval("sTableName") %>','<%# Eval("sFieldName") %>',this)" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FieldOrder" ItemStyle-Width="60px">
                        <ItemTemplate>
                            <input value='<%# Eval("lFieldOrder") %>' maxlength="3" class="TextBox txtField"
                                style="width: 60px" type="text" onchange="UpdateGridSet('<%# Eval("sTableName") %>','<%# Eval("sFieldName") %>','lFieldOrder',this)" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FieldWidth" ItemStyle-Width="60px">
                        <ItemTemplate>
                            <input value='<%# Eval("lFieldWidth") %>' maxlength="3" class="TextBox txtField"
                                style="width: 60px" type="text" onchange="UpdateGridSet('<%# Eval("sTableName") %>','<%# Eval("sFieldName") %>','lFieldWidth',this)" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ChineseTitle" ItemStyle-Width="120px">
                        <ItemTemplate>
                            <input value='<%# Eval("sChineseTitle") %>' maxlength="50" class="TextBox txtField"
                                style="width: 120px" type="text" onchange="UpdateGridSet('<%# Eval("sTableName") %>','<%# Eval("sFieldName") %>','sChineseTitle',this)" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="EnglishTitle" ItemStyle-Width="120px">
                        <ItemTemplate>
                            <input value='<%# Eval("sEnglishTitle") %>' maxlength="50" class="TextBox txtField"
                                style="width: 120px" type="text" onchange="UpdateGridSet('<%# Eval("sTableName") %>','<%# Eval("sFieldName") %>','sEnglishTitle',this)" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ChineseFormat" ItemStyle-Width="120px">
                        <ItemTemplate>
                            <input value='<%# Eval("sChineseFormat") %>' maxlength="50" class="TextBox txtField"
                                style="width: 120px" type="text" onchange="UpdateGridSet('<%# Eval("sTableName") %>','<%# Eval("sFieldName") %>','sChineseFormat',this)" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="EnglishFormat" ItemStyle-Width="120px">
                        <ItemTemplate>
                            <input value='<%# Eval("sEnglishFormat") %>' maxlength="50" class="TextBox txtField"
                                style="width: 120px" type="text" onchange="UpdateGridSet('<%# Eval("sTableName") %>','<%# Eval("sFieldName") %>','sEnglishFormat',this)" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="HeaderImageUrl" ItemStyle-Width="120px">
                        <ItemTemplate>
                            <input value='<%# Eval("sHeaderImageUrl") %>' maxlength="100" class="TextBox txtField"
                                style="width: 120px" type="text" onchange="UpdateGridSet('<%# Eval("sTableName") %>','<%# Eval("sFieldName") %>','sHeaderImageUrl',this)" />
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
    </div>
    <div region="south" border="false" style="height: 28px; background: #C9EDCC; padding: 2px;">
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
                <asp:Button ID="btnToExcel" runat="server" CssClass="Button" Text="Export Excel"
                    Width="77px" UseSubmitBehavior="False" />
            </div>
        </div>
    </div>
    <input name='txtTRLastIndex' type='hidden' id='txtTRLastIndex' value="1" />
    <asp:HiddenField ID="fldId" runat="server" />
    <asp:HiddenField ID="hidBatchNo" runat="server" />
    </form>
</body>
</html>
