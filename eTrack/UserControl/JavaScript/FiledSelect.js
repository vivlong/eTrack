<script language="javascript" type="text/javascript">
function selDoubleModule(arrPara, conCode, conName, numFile, Type) {

    var ret = ModalDialog("../UserControl/DoubleSelectPage.aspx?arrPara=" + arrPara + "&numFile=" + numFile + "&type=" + Type, 800, 500);
    if (ret != null) {
        var strRel = ret.split(ColSeparator);
        if (strRel.length == 2) {
            var txt = strRel[1] == "&nbsp;" ? " " : strRel[1];
            txt = txt.replace('amp;', '');
            conCode.value = strRel[0] == "&nbsp;" ? " " : strRel[0];
            conName.value = txt;
        }
    }
}
function selSingleModule(arrPara, conName, numFile) {

    var ret = ModalDialog("../UserControl/SingleSelectPage.aspx?arrPara=" + arrPara + "&numFile=" + numFile, 800, 500);
    if (ret != null) {
        var strRel = ret.split(ColSeparator);
        if (strRel.length == 2) {
            var txt = strRel[1] == "&nbsp;" ? " " : strRel[1];
            txt = txt.replace('amp;', '');
            conName.value = txt;
        }
    }
}
</script>