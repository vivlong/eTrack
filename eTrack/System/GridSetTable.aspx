<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GridSetTable.aspx.vb" Inherits="System_GridSetTable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Select</title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
</head>
<body>
    <form id="form1" runat="server">
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
        <br />
           <div  style="padding-left: 2px;
            width: 99.5%;">  <div class="fLeft">
            <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
            </div>
            <asp:DropDownList ID="drpFunText" runat="server" CssClass="drSearch fLeft" />
             <div id="div1" style="display: inline">
                <asp:TextBox ID="txtFunValue" runat="server" CssClass="txInput txtSearch" />
            </div>
           </div>
        <div id="divSource" title="Grid Set" style="overflow: scroll; padding-left: 2px;
            width: 99.5%;">
                       <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                OnRowDataBound="gvwSource_RowDataBound">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="20px">
                        <ItemTemplate>
                            <input type="checkbox" id="chkSelect" runat="server" class="checkbox" value='' />
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
                <asp:Button ID="btnSave" runat="server" CssClass="Button" Text="Save"
                    Width="77px" UseSubmitBehavior="False" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
