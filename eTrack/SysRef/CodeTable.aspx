<%@ Page Language="VB" AutoEventWireup="true" CodeFile="CodeTable.aspx.vb" Inherits="CodeTable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">var intpagecount=1 ;</script>

    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/BaseList.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->

        <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
</head>
<body>
    <form id="frmCodeTable" runat="server">
    <div>
        <div id="popupMenu" class="skin" runat="server"  onmousemove="HighlighItem(event)"
            onmouseout="LowlightItem(event)">
        </div>
        <div id="MsgBox">
            <div class="bar">
                <asp:Label ID="lblLoadTitleHint" runat="server" Text="<%$ Resources:Message, LoadTitleHint %>"></asp:Label>
            </div>
            <div class="content">
                <img alt="" src="../images/load.gif" style="text-align: center; vertical-align: middle" />&nbsp;
                &nbsp;<asp:Label ID="lblMessage" runat="server" Text="<%$ Resources:Message, LoadDataHint %>"></asp:Label>
            </div>
        </div>
        <div id="divSearch">
            <div class="searchICO fLeft">
            </div>
            <asp:TextBox ID="txtSearch" runat="server" CssClass="fLeft txInput txtSearch" />
            <asp:Button ID="btnSearch" runat="server" CssClass="btnFnt" Text="Search" UseSubmitBehavior="false" />
        </div>
        <div id="divSource"  style="height: 550px;">
            <div>
                <table cellspacing="0" rules="all" border="1" id="gvwSource" style="width: 610px;
                    border-collapse: collapse;">
                    <tr class="Header">
                        <th class="colEdit taCenter" scope="col">
                            <img id="gvwSource_ctl01_imgInsert" class="delImg" 
                                src="../Images/Edit/ed_Insert.gif" alt="Add" style="border-width: 0px;" />
                        </th>
                        <th scope="col">
                            No.
                        </th>
                        <th  scope="col">
                            Value
                        </th>
                        <th  scope="col">
                            <span>Code Desc</span><img src="../Images/Edit/SortUp.gif" style="border-width: 0px;" />
                        </th>
                    </tr>
                    <tr class="Row" onmouseover="RowMouseOver(this)" oncontextmenu="ShowMenu(event,4)"
                        onmouseout="RowMouseOut(this,1)" 
                        style="color: Black;">
                        <td class="colEdit taCenter" onselectstart="return false;">
                            <img id="gvwSource_ctl02_imgEdit" class="delImg" 
                                src="../Images/Edit/ed_Edit.gif" alt="Edit" style="border-width: 0px;" /><img id="gvwSource_ctl02_imgDelete"
                                    class="delImg" src="../Images/Edit/ed_Delete.gif" alt="Delete" style="border-width: 0px;
                                    display: none;" />
                        </td>
                        <td align="right" onselectstart="return false;" style="width: 40px;">
                            1
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 150px;">
                            4
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 380px;">
                            .Net
                        </td>
                    </tr>
                    <tr class="Alternating" onmouseover="RowMouseOver(this)" oncontextmenu="ShowMenu(event,6)"
                        onmouseout="RowMouseOut(this,0)" 
                        style="color: Black;">
                        <td class="colEdit taCenter" onselectstart="return false;">
                            <img id="gvwSource_ctl03_imgEdit" class="delImg" 
                                src="../Images/Edit/ed_Edit.gif" alt="Edit" style="border-width: 0px;" /><img id="gvwSource_ctl03_imgDelete"
                                    class="delImg" src="../Images/Edit/ed_Delete.gif" alt="Delete" style="border-width: 0px;
                                    display: none;" />
                        </td>
                        <td align="right" onselectstart="return false;" style="width: 40px;">
                            2
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 150px;">
                            6
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 380px;">
                            EDI
                        </td>
                    </tr>
                    <tr class="Row" onmouseover="RowMouseOver(this)" oncontextmenu="ShowMenu(event,13)"
                        onmouseout="RowMouseOut(this,1)" 
                        style="color: Black;">
                        <td class="colEdit taCenter" onselectstart="return false;">
                            <img id="gvwSource_ctl04_imgEdit" class="delImg" 
                                src="../Images/Edit/ed_Edit.gif" alt="Edit" style="border-width: 0px;" /><img id="gvwSource_ctl04_imgDelete"
                                    class="delImg" src="../Images/Edit/ed_Delete.gif" alt="Delete" style="border-width: 0px;
                                    display: none;" />
                        </td>
                        <td align="right" onselectstart="return false;" style="width: 40px;">
                            3
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 150px;">
                            13
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 380px;">
                            EDI Coda
                        </td>
                    </tr>
                    <tr class="Alternating" onmouseover="RowMouseOver(this)" oncontextmenu="ShowMenu(event,7)"
                        onmouseout="RowMouseOut(this,0)" 
                        style="color: Black;">
                        <td class="colEdit taCenter" onselectstart="return false;">
                            <img id="gvwSource_ctl05_imgEdit" class="delImg" 
                                src="../Images/Edit/ed_Edit.gif" alt="Edit" style="border-width: 0px;" /><img id="gvwSource_ctl05_imgDelete"
                                    class="delImg" src="../Images/Edit/ed_Delete.gif" alt="Delete" style="border-width: 0px;
                                    display: none;" />
                        </td>
                        <td align="right" onselectstart="return false;" style="width: 40px;">
                            4
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 150px;">
                            7
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 380px;">
                            eTrack
                        </td>
                    </tr>
                    <tr class="Row" onmouseover="RowMouseOver(this)" oncontextmenu="ShowMenu(event,12)"
                        onmouseout="RowMouseOut(this,1)" 
                        style="color: Black;">
                        <td class="colEdit taCenter" onselectstart="return false;">
                            <img id="gvwSource_ctl06_imgEdit" class="delImg" 
                                src="../Images/Edit/ed_Edit.gif" alt="Edit" style="border-width: 0px;" /><img id="gvwSource_ctl06_imgDelete"
                                    class="delImg" src="../Images/Edit/ed_Delete.gif" alt="Delete" style="border-width: 0px;
                                    display: none;" />
                        </td>
                        <td align="right" onselectstart="return false;" style="width: 40px;">
                            5
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 150px;">
                            12
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 380px;">
                            Installer
                        </td>
                    </tr>
                    <tr class="Alternating" onmouseover="RowMouseOver(this)" oncontextmenu="ShowMenu(event,8)"
                        onmouseout="RowMouseOut(this,0)" 
                        style="color: Black;">
                        <td class="colEdit taCenter" onselectstart="return false;">
                            <img id="gvwSource_ctl07_imgEdit" class="delImg" 
                                src="../Images/Edit/ed_Edit.gif" alt="Edit" style="border-width: 0px;" /><img id="gvwSource_ctl07_imgDelete"
                                    class="delImg" src="../Images/Edit/ed_Delete.gif" alt="Delete" style="border-width: 0px;
                                    display: none;" />
                        </td>
                        <td align="right" onselectstart="return false;" style="width: 40px;">
                            6
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 150px;">
                            8
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 380px;">
                            Request Form
                        </td>
                    </tr>
                    <tr class="Row" onmouseover="RowMouseOver(this)" oncontextmenu="ShowMenu(event,9)"
                        onmouseout="RowMouseOut(this,1)" 
                        style="color: Black;">
                        <td class="colEdit taCenter" onselectstart="return false;">
                            <img id="gvwSource_ctl08_imgEdit" class="delImg" 
                                src="../Images/Edit/ed_Edit.gif" alt="Edit" style="border-width: 0px;" /><img id="gvwSource_ctl08_imgDelete"
                                    class="delImg" src="../Images/Edit/ed_Delete.gif" alt="Delete" style="border-width: 0px;
                                    display: none;" />
                        </td>
                        <td align="right" onselectstart="return false;" style="width: 40px;">
                            7
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 150px;">
                            9
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 380px;">
                            SysAdmin
                        </td>
                    </tr>
                    <tr class="Alternating" onmouseover="RowMouseOver(this)" oncontextmenu="ShowMenu(event,11)"
                        onmouseout="RowMouseOut(this,0)" 
                        style="color: Black;">
                        <td class="colEdit taCenter" onselectstart="return false;">
                            <img id="gvwSource_ctl09_imgEdit" class="delImg" 
                                src="../Images/Edit/ed_Edit.gif" alt="Edit" style="border-width: 0px;" /><img id="gvwSource_ctl09_imgDelete"
                                    class="delImg" src="../Images/Edit/ed_Delete.gif" alt="Delete" style="border-width: 0px;
                                    display: none;" />
                        </td>
                        <td align="right" onselectstart="return false;" style="width: 40px;">
                            8
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 150px;">
                            11
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 380px;">
                            SysConfig
                        </td>
                    </tr>
                    <tr class="Row" onmouseover="RowMouseOver(this)" oncontextmenu="ShowMenu(event,10)"
                        onmouseout="RowMouseOut(this,1)" 
                        style="color: Black;">
                        <td class="colEdit taCenter" onselectstart="return false;">
                            <img id="gvwSource_ctl10_imgEdit" class="delImg" 
                                src="../Images/Edit/ed_Edit.gif" alt="Edit" style="border-width: 0px;" /><img id="gvwSource_ctl10_imgDelete"
                                    class="delImg" src="../Images/Edit/ed_Delete.gif" alt="Delete" style="border-width: 0px;
                                    display: none;" />
                        </td>
                        <td align="right" onselectstart="return false;" style="width: 40px;">
                            9
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 150px;">
                            10
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 380px;">
                            SysSetup
                        </td>
                    </tr>
                    <tr class="Alternating" onmouseover="RowMouseOver(this)" oncontextmenu="ShowMenu(event,5)"
                        onmouseout="RowMouseOut(this,0)" 
                        style="color: Black;">
                        <td class="colEdit taCenter" onselectstart="return false;">
                            <img id="gvwSource_ctl11_imgEdit" class="delImg" 
                                src="../Images/Edit/ed_Edit.gif" alt="Edit" style="border-width: 0px;" /><img id="gvwSource_ctl11_imgDelete"
                                    class="delImg" src="../Images/Edit/ed_Delete.gif" alt="Delete" style="border-width: 0px;
                                    display: none;" />
                        </td>
                        <td align="right" onselectstart="return false;" style="width: 40px;">
                            10
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 150px;">
                            5
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 380px;">
                            TCS
                        </td>
                    </tr>
                    <tr class="Row" onmouseover="RowMouseOver(this)" oncontextmenu="ShowMenu(event,2)"
                        onmouseout="RowMouseOut(this,1)" 
                        style="color: Black;">
                        <td class="colEdit taCenter" onselectstart="return false;">
                            <img id="gvwSource_ctl12_imgEdit" class="delImg" 
                                src="../Images/Edit/ed_Edit.gif" alt="Edit" style="border-width: 0px;" /><img id="gvwSource_ctl12_imgDelete"
                                    class="delImg" src="../Images/Edit/ed_Delete.gif" alt="Delete" style="border-width: 0px;
                                    display: none;" />
                        </td>
                        <td align="right" onselectstart="return false;" style="width: 40px;">
                            11
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 150px;">
                            2
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 380px;">
                            v4.5
                        </td>
                    </tr>
                    <tr class="Alternating" onmouseover="RowMouseOver(this)" oncontextmenu="ShowMenu(event,3)"
                        onmouseout="RowMouseOut(this,0)" 
                        style="color: Black;">
                        <td class="colEdit taCenter" onselectstart="return false;">
                            <img id="gvwSource_ctl13_imgEdit" class="delImg" 
                                src="../Images/Edit/ed_Edit.gif" alt="Edit" style="border-width: 0px;" /><img id="gvwSource_ctl13_imgDelete"
                                    class="delImg" src="../Images/Edit/ed_Delete.gif" alt="Delete" style="border-width: 0px;
                                    display: none;" />
                        </td>
                        <td align="right" onselectstart="return false;" style="width: 40px;">
                            12
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 150px;">
                            3
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 380px;">
                            v4.5 & v5.0
                        </td>
                    </tr>
                    <tr class="Row" onmouseover="RowMouseOver(this)" oncontextmenu="ShowMenu(event,16)"
                        onmouseout="RowMouseOut(this,1)" 
                        style="color: Black;">
                        <td class="colEdit taCenter" onselectstart="return false;">
                            <img id="gvwSource_ctl14_imgEdit" class="delImg" 
                                src="../Images/Edit/ed_Edit.gif" alt="Edit" style="border-width: 0px;" /><img id="gvwSource_ctl14_imgDelete"
                                    class="delImg" src="../Images/Edit/ed_Delete.gif" alt="Delete" style="border-width: 0px;
                                    display: none;" />
                        </td>
                        <td align="right" onselectstart="return false;" style="width: 40px;">
                            13
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 150px;">
                            16
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 380px;">
                            v4.5 & v5.0.02
                        </td>
                    </tr>
                    <tr class="Alternating" onmouseover="RowMouseOver(this)" oncontextmenu="ShowMenu(event,19)"
                        onmouseout="RowMouseOut(this,0)" 
                        style="color: Black;">
                        <td class="colEdit taCenter" onselectstart="return false;">
                            <img id="gvwSource_ctl15_imgEdit" class="delImg" 
                                src="../Images/Edit/ed_Edit.gif" alt="Edit" style="border-width: 0px;" /><img id="gvwSource_ctl15_imgDelete"
                                    class="delImg" src="../Images/Edit/ed_Delete.gif" alt="Delete" style="border-width: 0px;
                                    display: none;" />
                        </td>
                        <td align="right" onselectstart="return false;" style="width: 40px;">
                            14
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 150px;">
                            19
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 380px;">
                            v4.5 & v5.0.02 & v5.0.03
                        </td>
                    </tr>
                    <tr class="Row" onmouseover="RowMouseOver(this)" oncontextmenu="ShowMenu(event,18)"
                        onmouseout="RowMouseOut(this,1)" 
                        style="color: Black;">
                        <td class="colEdit taCenter" onselectstart="return false;">
                            <img id="gvwSource_ctl16_imgEdit" class="delImg" 
                                src="../Images/Edit/ed_Edit.gif" alt="Edit" style="border-width: 0px;" /><img id="gvwSource_ctl16_imgDelete"
                                    class="delImg" src="../Images/Edit/ed_Delete.gif" alt="Delete" style="border-width: 0px;
                                    display: none;" />
                        </td>
                        <td align="right" onselectstart="return false;" style="width: 40px;">
                            15
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 150px;">
                            18
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 380px;">
                            v4.5 & v5.0.03
                        </td>
                    </tr>
                    <tr class="Alternating" onmouseover="RowMouseOver(this)" oncontextmenu="ShowMenu(event,1)"
                        onmouseout="RowMouseOut(this,0)" 
                        style="color: Black;">
                        <td class="colEdit taCenter" onselectstart="return false;">
                            <img id="gvwSource_ctl17_imgEdit" class="delImg" 
                                src="../Images/Edit/ed_Edit.gif" alt="Edit" style="border-width: 0px;" /><img id="gvwSource_ctl17_imgDelete"
                                    class="delImg" src="../Images/Edit/ed_Delete.gif" alt="Delete" style="border-width: 0px;
                                    display: none;" />
                        </td>
                        <td align="right" onselectstart="return false;" style="width: 40px;">
                            16
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 150px;">
                            1
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 380px;">
                            v5.0
                        </td>
                    </tr>
                    <tr class="Row" onmouseover="RowMouseOver(this)" oncontextmenu="ShowMenu(event,14)"
                        onmouseout="RowMouseOut(this,1)" 
                        style="color: Black;">
                        <td class="colEdit taCenter" onselectstart="return false;">
                            <img id="gvwSource_ctl18_imgEdit" class="delImg" 
                                src="../Images/Edit/ed_Edit.gif" alt="Edit" style="border-width: 0px;" /><img id="gvwSource_ctl18_imgDelete"
                                    class="delImg" src="../Images/Edit/ed_Delete.gif" alt="Delete" style="border-width: 0px;
                                    display: none;" />
                        </td>
                        <td align="right" onselectstart="return false;" style="width: 40px;">
                            17
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 150px;">
                            14
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 380px;">
                            v5.0.02
                        </td>
                    </tr>
                    <tr class="Alternating" onmouseover="RowMouseOver(this)" oncontextmenu="ShowMenu(event,17)"
                        onmouseout="RowMouseOut(this,0)" 
                        style="color: Black;">
                        <td class="colEdit taCenter" onselectstart="return false;">
                            <img id="gvwSource_ctl19_imgEdit" class="delImg" 
                                src="../Images/Edit/ed_Edit.gif" alt="Edit" style="border-width: 0px;" /><img id="gvwSource_ctl19_imgDelete"
                                    class="delImg" src="../Images/Edit/ed_Delete.gif" alt="Delete" style="border-width: 0px;
                                    display: none;" />
                        </td>
                        <td align="right" onselectstart="return false;" style="width: 40px;">
                            18
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 150px;">
                            17
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 380px;">
                            v5.0.02 & v5.0.03
                        </td>
                    </tr>
                    <tr class="Row" onmouseover="RowMouseOver(this)" oncontextmenu="ShowMenu(event,15)"
                        onmouseout="RowMouseOut(this,1)" 
                        style="color: Black;">
                        <td class="colEdit taCenter" onselectstart="return false;">
                            <img id="gvwSource_ctl20_imgEdit" class="delImg" 
                                src="../Images/Edit/ed_Edit.gif" alt="Edit" style="border-width: 0px;" /><img id="gvwSource_ctl20_imgDelete"
                                    class="delImg" src="../Images/Edit/ed_Delete.gif" alt="Delete" style="border-width: 0px;
                                    display: none;" />
                        </td>
                        <td align="right" onselectstart="return false;" style="width: 40px;">
                            19
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 150px;">
                            15
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 380px;">
                            v5.0.03
                        </td>
                    </tr>
                    <tr class="Alternating" onmouseover="RowMouseOver(this)" oncontextmenu="ShowMenu(event,-1)"
                        onmouseout="RowMouseOut(this,0)" style="color: Black;">
                        <td class="colEdit taCenter" onselectstart="return false;">
                            <img id="gvwSource_ctl21_imgInsert" class="delImg" 
                                src="../Images/Edit/ed_Insert.gif" alt="Add" style="border-width: 0px;" />
                        </td>
                        <td align="right" onselectstart="return false;" style="width: 40px;">
                            20
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 150px;">
                            &nbsp;
                        </td>
                        <td align="left" onselectstart="return false;" style="width: 380px;">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
            <%--<asp:GridView ID="gvwSource" runat="server"  AutoGenerateColumns="False" OnRowDataBound="gvwSource_RowDataBound" enableviewstate="False" >
            <HeaderStyle CssClass="Header"/>
            <FooterStyle CssClass="Footer"/>
            <RowStyle CssClass="Row" />
            <SelectedRowStyle CssClass="SelectRow" />
            <PagerStyle CssClass="Pager" />
            <AlternatingRowStyle CssClass="Alternating" />                    
            </asp:GridView>--%>
        </div>
        <div id="divPage">
            <div class="fLeft">
                <asp:Label ID="lblPage" runat="server" Text="Page"></asp:Label>
                <asp:LinkButton ID="lbtnFirst" runat="server" Text="First"></asp:LinkButton>
                <asp:LinkButton ID="lbtnPrior" runat="server" Text="Prior"></asp:LinkButton>
                <asp:LinkButton ID="lbtnNext" runat="server" Text="Next"></asp:LinkButton>
                <asp:LinkButton ID="lbtnLast" runat="server" Text="Last"></asp:LinkButton>
                <asp:LinkButton ID="lbtnGoTo" runat="server" Text="Go to"></asp:LinkButton>
                <asp:TextBox ID="txtPage" runat="server" CssClass="txInput"></asp:TextBox>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
