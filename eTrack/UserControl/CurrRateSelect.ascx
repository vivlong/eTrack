<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CurrRateSelect.ascx.vb"
    Inherits="CurrRateSelect" %>
<link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
<script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
<script language="javascript" type="text/javascript">
    //lzw081110
    var CurrDate = "";
    function selCurrRateModule(arrPara, conCode, conName, numFile, Type) {
        if (document.getElementById("EtdDateTimeSelect_txtDateTime").value == "")
        { alert("ETD must be input!"); return; }
        arrPara = document.getElementById("EtdDateTimeSelect_txtDateTime").value + arrPara;
        var ret = WindowDialog("../UserControl/DoubleSelectPage.aspx?arrPara=" + arrPara + "&numFile=" + numFile + "&Type=" + Type, 400, 430);
        if (ret != null) {
            var strRel = ret.split(ColSeparator);
            if (strRel.length == 2) {
                var txt = strRel[1] == "&nbsp;" ? " " : strRel[1];
                txt = txt.replace('amp;', '');
                conCode.value = strRel[0];
                conName.value = txt;
            }
        }
    }
</script>
<asp:TextBox ID="txtCode" runat="server" CssClass="TextBox origin" MaxLength="3" />
<asp:TextBox ID="txtName" ReadOnly="true" runat="server" CssClass="TextBox txtorigin" />
<asp:Button ID="btnOpen" runat="server" CssClass="Button bntDate" Text="..." UseSubmitBehavior="False" />
