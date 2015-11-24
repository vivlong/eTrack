<%@ Page Language="VB" AutoEventWireup="true" CodeFile="BusinessPartyEdit.aspx.vb"
    Inherits="BusinessPartyEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <base target="_self"></base>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/Calendar.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/BusinessPartyEdit.css" rel="Stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!--#include file="../JavaScript/Print.js" -->
    <!--#include file="JavaScript/BusinessParty.js" -->

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"> </script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>

    <script type="text/javascript" language="javascript">
    function ChgUrgAttribute(aFlag)
    {
        if(aFlag==1)
        {
            document.getElementById("txtUrgentRemark").value = "";
            document.getElementById("txtUrgentRemark").readOnly=true;
        }
        else if(aFlag==2)
        {
            document.getElementById("txtUrgentRemark").readOnly=false;
        }
    }
     function txtonload(oText) 
      {
          if(oText.value.Trim()=='') oText.value='0';
      }    
    function AutoAdd(pcs,weight,length,width,height,volume)
    {
            GetTotalValue(); 
            var valPcs=pcs.value;
            var valweight=weight.value;
            var vallength=length.value;
            var valwidth=width.value;
            var valheight=height.value; 
           if(valPcs=='')  valPcs=0;
           if(valweight=='') valweight=0.0000;
           if(vallength=='') vallength=0.0;
           if(valwidth=='') valwidth=0.0;
           if(valheight=='') valheight=0.0;
          var strtotal = parseFloat(valPcs)*parseFloat(vallength)*parseFloat(valwidth)*parseFloat(valheight);
          volume.innerHTML=strtotal;
    }
            function PrintDetail(intId)
    {
        if(intId){
            var strUrl="../loading.aspx?tourl="+PrintPath+"/crBusinessParty.aspx?Id="+intId.toString()+"";
            window.open(strUrl);
        }
    }
    </script>

</head>
<body>
    <form id="frmBusinessPartyFormEdit" runat="server">
    <div id="divForm">
        <div id="divTopNav" style="width: 100%">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="a1" runat="server" CssClass="f12e navNml navOn" Text="<%$ Resources:a1.Text %>"></asp:Label></li></ul>
        </div>
        <div id="SaveHint" runat="server" class="Hint" style="left: 0px; top: 10px">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>" />
        </div>
        <div id="divMiddle1" style="width: 990px; height: 560px; padding-left: 20px; padding-top: 10px">
            <div id="divMiddle11">
                <div class="divline">
                    <asp:Label ID="lblBusinessPartyCode" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblBusinessPartyCode %>" />
                    <asp:TextBox ID="txtBusinessPartyCode" CssClass="TextBox txtDate" runat="server" />
                    <span style="width: 97px; display: inline-block;"></span>
                    <asp:Label ID="lblPartyType" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblPartyType %>" />
                    <asp:TextBox ID="txtPartyType" CssClass="TextBox txtDate" runat="server" />
                </div>
                <div id="divlblCustomerCode" runat="server" class="divline">
                    <asp:Label ID="lblCustomerCode" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblCustomerCode %>" />
                    <asp:TextBox ID="txtCustomerCode" runat="server" CssClass="TextBox txtDate" MaxLength="3" />
                    <asp:TextBox ID="txtCustomerName" runat="server" CssClass="TextBox txt" MaxLength="50" />
                    <asp:Button ID="btnCustomerCode" runat="server" CssClass="Button bntDate" Text="Update Customer"
                        UseSubmitBehavior="False" />
                </div>
                <div id="divlbVendorCode" runat="server" class="divline">
                    <asp:Label ID="lbVendorCode" CssClass="Label lbl" runat="server" Text="<%$ Resources:lbVendorCode %>" />
                    <asp:TextBox ID="txtVendorCode" runat="server" CssClass="TextBox txtDate" MaxLength="3" />
                    <asp:TextBox ID="txtVendorName" runat="server" CssClass="TextBox txt" />
                    <asp:Button ID="btnVendorCode" runat="server" CssClass="Button bntDate" Text="Update Vendor"
                        UseSubmitBehavior="False" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblCurrencyCode" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblCurrency %>" />
                    <asp:TextBox ID="txtCurrencyCode" CssClass="TextBox txtCurrencyCode" runat="server" />
                    <asp:TextBox ID="txtCurrencyName" CssClass="TextBox txtCurrencyName" runat="server" />
                    <span style="width: 100px; display: inline"></span>&nbsp
                    <asp:Label ID="lblTerm" CssClass="Label" runat="server" Text="<%$ Resources:lblTerm %>" />
                    &nbsp<asp:TextBox ID="txtTermCode" CssClass="TextBox txtCurrencyCode" runat="server" />
                    <asp:TextBox ID="txtTermName" CssClass="TextBox txtCurrencyName" runat="server" />
                    <asp:Label ID="lblOnHold" CssClass="Label" runat="server" Text="<%$ Resources:lblOnHold %>" />
                    &nbsp<asp:TextBox ID="txtOnHold" CssClass="TextBox txtCurrencyCode" runat="server" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblBusinessPartyName" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblBusinessPartyName %>" />
                    <asp:TextBox ID="txtBusinessPartyName" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div class="divline">
                    <asp:Label ID="lbllocalName" runat="server" CssClass="Label lbl" Text="<%$ Resources:lbllocalName %>">
                    </asp:Label>
                    <asp:TextBox ID="txtlocalName" runat="server" CssClass="TextBox txt" MaxLength="50">
                    </asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblAddress" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblAdress %>">
                    </asp:Label>
                    <asp:TextBox ID="txtAddress1" runat="server" CssClass="TextBox txt" MaxLength="50">
                    </asp:TextBox>
                </div>
                <div class="divline">
                    <a class="Label lbl">&nbsp</a>
                    <asp:TextBox ID="txtAddress2" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div class="divline">
                    <a class="Label lbl">&nbsp</a>
                    <asp:TextBox ID="txtAddress3" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div class="divline">
                    <a class="Label lbl">&nbsp</a>
                    <asp:TextBox ID="txtAddress4" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div id="divlblPostalCode" runat="server" class="divline">
                    <a class="Label lbl">&nbsp</a>
                    <asp:TextBox ID="txtPostalCode" runat="server" CssClass="TextBox txtDate" MaxLength="50" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblCityCode" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblCityCode %>" />
                    <asp:TextBox ID="txtCityCode" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblCountryCode" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblCountryCode %>">
                    </asp:Label>
                    <asp:TextBox ID="txtlblCountryCode" runat="server" CssClass="TextBox txt" MaxLength="50">
                    </asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblTelephone" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblTelephone %>">
                    </asp:Label>
                    <asp:TextBox ID="txtTelephone" runat="server" CssClass="TextBox txt" MaxLength="50">
                    </asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblFax" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblFax %>">
                    </asp:Label>
                    <asp:TextBox ID="txtFax" runat="server" CssClass="TextBox txt" MaxLength="50">
                    </asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblEmail" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblEmail %>">
                    </asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox txt" MaxLength="50">
                    </asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblWebSite" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblWebSite %>">
                    </asp:Label>
                    <asp:TextBox ID="txtWebSite" runat="server" CssClass="TextBox txt" MaxLength="50">
                    </asp:TextBox>
                </div>
                <div id="divtxtTelex" runat="server" class="divline">
                    <a class="Label lbl">&nbsp</a>
                    <asp:TextBox ID="txtTelex" runat="server" CssClass="TextBox txtDate" MaxLength="50">
                    </asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblSalesmanCode" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblSalesmanCode %>">
                    </asp:Label>
                    <asp:TextBox ID="txtSalesmanCode" runat="server" CssClass="TextBox txt" MaxLength="50">
                    </asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblCR" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblCR %>">
                    </asp:Label>
                    <asp:TextBox ID="txtCR" runat="server" CssClass="TextBox txt" MaxLength="50">
                    </asp:TextBox>
                    <asp:Button ID="btnInternetPassword" runat="server" CssClass="Button" Width="120px"
                        Text="Internet Password" UseSubmitBehavior="False" />
                </div>
                <div id="divSource" style="width: 583px; height: 180px">
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
        </div>
        <div id="divBottomNav" style="width: 100%">
            <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose.Text %>" CssClass="Button"
                UseSubmitBehavior="False" />
        </div>
    </div>
    </form>
</body>
</html>
