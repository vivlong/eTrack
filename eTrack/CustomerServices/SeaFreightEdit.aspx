<%@ Page Language="VB" AutoEventWireup="true" CodeFile="SeaFreightEdit.aspx.vb" Inherits="SeaFreightEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/SeaFreightEdit.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/Print.css" rel="Stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
        function SelectedDivl(selectId)
           {
                var DivName;
                var LiName;
                    if (selectId==1)
                    {
                               document.getElementById("a1").className="f12e navNml navOn";
                               document.getElementById("lbdownload").className="f12c navNml noSep";
                              document.getElementById("divMiddle1").style.display=""; 
                              document.getElementById("divMiddle2").style.display="none";
                               
                     
                             
                              document.getElementById("div_con").style.display="";
                    }
                    else{
                               document.getElementById("lbdownload").className="f12e navNml navOn";
                               document.getElementById("a1").className="f12c navNml noSep";
                              document.getElementById("divMiddle2").style.display=""; 
                              document.getElementById("divMiddle1").style.display="none"; 
                              document.getElementById("div_con").style.display="none";
                         }
           }
    </script>
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!-- #include file="JavaScript/SeaFreightEdit.js" -->
        <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
        <script type="text/javascript" language="javascript" src="../JavaScript/Format.js"> </script>    
</head>
<body>
    <form id="frmSeaFreightEdit" runat="server">
        <div id="divForm">
            <div id="divTopNav">
                <ul id="ulTopNav">
                    <li>
                        <asp:Label ID="a1" onclick="javascript:SelectedDivl(1);" CssClass="f12e navNml navOn"
                            runat="server" Text="<%$ Resources:a1.Text %>" ></asp:Label></li><%--Text="<%$ Resources:a1.Text %>"--%>
                    <li>
                        <asp:Label ID="lbdownload" onclick="javascript:SelectedDivl(2);" CssClass="f12c navNml noSep"
                            runat="server" Text="<%$ Resources:lbdownload %>"></asp:Label></li>
                </ul>
            </div>
            <div id="SaveHint" runat="server" class="Hint">
                <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>"> </asp:Label>
            </div>
            <div id="divMiddle1" class="divBorder">
                <div class="divline">
                    <asp:Label ID="lblJobNo" runat="server" CssClass="Label" Text="<%$ Resources:lblJobNo.Text %>"></asp:Label>
                    <asp:TextBox ID="txtJobNo" runat="server" CssClass="TextBox"></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblRefNo" runat="server" CssClass="Label" Text="<%$ Resources:lblRefNo.Text %>"></asp:Label>
                    <asp:TextBox ID="txtRefNo" runat="server" CssClass="TextBox"></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblAWBBlNo" runat="server" CssClass="Label" Text="<%$ Resources:lblAWBBlNo.Text %>"></asp:Label>
                    <asp:TextBox ID="txtAWBBlNo" runat="server" CssClass="TextBox"></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblMawbOBLNo" runat="server" CssClass="Label" Text="<%$ Resources:lblMawbOBLNo.Text %>"></asp:Label>
                    <asp:TextBox ID="txtMawbOBLNo" runat="server" CssClass="TextBox"></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblLoadPort" runat="server" CssClass="Label" Text="<%$ Resources:lblLoadPort.Text %>"></asp:Label>
                    <asp:TextBox ID="txtLoadPort" runat="server" CssClass="TextBox"></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblDischargePort" runat="server" CssClass="Label" Text="<%$ Resources:lblDischargePort.Text %>"></asp:Label>
                    <asp:TextBox ID="txtDischargePort" runat="server" CssClass="TextBox"></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblDirectVessel" runat="server" CssClass="Label" Text="<%$ Resources:lblDirectVessel.Text %>"></asp:Label>
                    <asp:TextBox ID="txtDirectVessel" runat="server" CssClass="TextBox"></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblMotherVessel" runat="server" CssClass="Label" Text="<%$ Resources:lblMotherVessel.Text %>"></asp:Label>
                    <asp:TextBox ID="txtMotherVessel" runat="server" CssClass="TextBox"></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblETD" runat="server" CssClass="Label" Text="<%$ Resources:lblETD.Text %>"></asp:Label>
                    <asp:TextBox ID="txtETD" runat="server" CssClass="TextBox"></asp:TextBox>
                    <asp:Label ID="lblETA" runat="server" CssClass="Label" Text="<%$ Resources:lblETA.Text %>"></asp:Label>
                    <asp:TextBox ID="txtETA" runat="server" CssClass="TextBox"></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblConnVessel" runat="server" CssClass="Label" Text="<%$ Resources:lblConnVessel.Text %>"></asp:Label>
                    <asp:TextBox ID="txtConnVessel" runat="server" CssClass="TextBox" ></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblConnETD" runat="server" CssClass="Label" Text="<%$ Resources:lblConnETD.Text %>"></asp:Label>
                    <asp:TextBox ID="txtConnETD" runat="server" CssClass="TextBox"></asp:TextBox>
                    <asp:Label ID="lblConnETA" runat="server" CssClass="Label" Text="<%$ Resources:lblConnETA.Text %>"></asp:Label>
                    <asp:TextBox ID="txtConnETA" runat="server" CssClass="TextBox"></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblCommodity" runat="server" CssClass="Label" Text="<%$ Resources:lblCommodity.Text %>"></asp:Label>
                    <asp:TextBox ID="txtCommodity" runat="server" CssClass="TextBox"></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblPcs" runat="server" CssClass="Label" Text="<%$ Resources:lblPcs.Text %>"></asp:Label>
                    <asp:TextBox ID="txtPcs" runat="server" CssClass="TextBox"></asp:TextBox>
                    <asp:Label ID="lblGross" runat="server" CssClass="Label" Text="<%$ Resources:lblGross.Text %>"></asp:Label>
                    <asp:TextBox ID="txtGross" runat="server" CssClass="TextBox"></asp:TextBox>
                    <asp:Label ID="lblVolume" runat="server" CssClass="Label" Text="<%$ Resources:lblVolume.Text %>"></asp:Label>
                    <asp:TextBox ID="txtVolume" runat="server" CssClass="TextBox"></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblFt20" runat="server" CssClass="Label" Text="<%$ Resources:lblFt20.Text %>"></asp:Label>
                    <asp:TextBox ID="txtFt20" runat="server" CssClass="TextBox"></asp:TextBox>
                    <asp:Label ID="lblFt40" runat="server" CssClass="Label" Text="<%$ Resources:lblFt40.Text %>"></asp:Label>
                    <asp:TextBox ID="txtFt40" runat="server" CssClass="TextBox"></asp:TextBox>
                    <asp:Label ID="lblFt45" runat="server" CssClass="Label" Text="<%$ Resources:lblFt45.Text %>"></asp:Label>
                    <asp:TextBox ID="txtFt45" runat="server" CssClass="TextBox"></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblContainerNo" runat="server" CssClass="Label" Text="<%$ Resources:lblContainerNo.Text %>"></asp:Label>
                    <asp:TextBox ID="txtContainerNo" runat="server" CssClass="TextBox"></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblTelexReleaseFlag" runat="server" CssClass="Label" Text="<%$ Resources:lblTelexReleaseFlag.Text %>"></asp:Label>
                    <asp:TextBox ID="txtTelexReleaseFlag" runat="server" CssClass="TextBox" 
                        Width="26px" ></asp:TextBox>
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
            </div>
            <div id="divMiddle2" class="divBorder" runat="server" style="display: none;">
                <div id="div2" style="height: 502px">
                    <asp:GridView ID="gvwAttach" runat="server" AutoGenerateColumns="False" CssClass="GvwView"
                        EnableViewState="False" OnRowDataBound="gvwAttach_RowDataBound" Width="700px">
                        <FooterStyle CssClass="Footer" />
                        <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="imgDelete" runat="server" ImageUrl="~/Images/Edit/ed_delete.gif" CssClass="delImg" />
                                <asp:Image ID="imgInsert" runat="server" ImageUrl="~/Images/Edit/ed_Insert.gif" CssClass="delImg" /><%--AlternateText="<%$ Resources:imgInsert.AlternateText %>"--%>
                            </ItemTemplate>
                            <ItemStyle CssClass="colEdit taCenter" />
                            <HeaderStyle CssClass="colEdit taCenter " />
                        </asp:TemplateField>
                            <asp:BoundField DataField="No" HeaderText="<%$ Resources:BoundField1.HeaderText %>">
                                <ItemStyle CssClass="colNo taLeft" Width="30px" />
                                <HeaderStyle CssClass="colNo taCenter " Width="30px"  />
                            </asp:BoundField>
                            <asp:BoundField DataField="ReferenceFileName" HeaderText="<%$ Resources:BoundField2.HeaderText %>"
                                HtmlEncode="False">
                                <ItemStyle CssClass="colFileName taLeft" />
                                <HeaderStyle CssClass="colFileName taCenter" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FileSize" DataFormatString="{0:#,##0}" HeaderText="<%$ Resources:BoundField3.HeaderText %>"
                                HtmlEncode="False">
                                <ItemStyle CssClass="colFileSize taRight" />
                                <HeaderStyle CssClass="colFileSize taCenter" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FileDate" DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="<%$ Resources:BoundField4.HeaderText %>"
                                HtmlEncode="False">
                                <ItemStyle CssClass="colFileDate taLeft" />
                                <HeaderStyle CssClass="colFileDate taCenter" />
                            </asp:BoundField>
                        </Columns>
                        <RowStyle CssClass="Row" />
                        <SelectedRowStyle CssClass="SelectRow" />
                        <PagerStyle CssClass="Pager" />
                        <HeaderStyle CssClass="Header" />
                        <AlternatingRowStyle CssClass="Alternating" />
                    </asp:GridView>
                </div>
            </div>
            <div id="divBottomNav">
                <div id="div_con">
                    <asp:Button ID="btnAdd" runat="server" Text="<%$ Resources:btnAdd.Text %>" CssClass="Button"
                        UseSubmitBehavior="False" Visible="False" />
                    <asp:Button ID="btnNew" runat="server" Text="<%$ Resources:btnNew.Text %>" CssClass="Button"
                        UseSubmitBehavior="False" />
                    <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:btnSave.Text %>" CssClass="Button"
                        UseSubmitBehavior="False" />
                    <asp:Button ID="btnPrint" runat="server" Text="<%$ Resources:btnPrint.Text %>" CssClass="Button"
                        UseSubmitBehavior="False" />
                    <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose.Text %>" CssClass="Button"
                        UseSubmitBehavior="False" />
                </div>
            </div>
        </div>
        <asp:HiddenField ID="fldId" runat="server" />
    </form>
</body>
</html>
