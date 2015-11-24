<script type="text/javascript" language ="javascript">
function GetQueryValue()
{
    var strValue="";
    //Date
    strValue=strValue+document.getElementById("chkDate").checked;
    strValue=strValue+ColSeparator+document.getElementById("txtQDate").value.Rtrim();
    strValue=strValue+ColSeparator+document.getElementById("txtZDate").value.Rtrim();
    //User
    strValue=strValue+RowSeparator+document.getElementById("chkUser").checked;
    strValue=strValue+ColSeparator+document.getElementById("txtUser").value.Rtrim();
    //Remark
    strValue=strValue+RowSeparator+document.getElementById("chkRemark").checked;
    strValue=strValue+ColSeparator+document.getElementById("txtRemark").value.Rtrim();
    //return value 
    return strValue;
}
</script>

