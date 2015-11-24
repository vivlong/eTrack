<script type="text/javascript" language ="javascript">

//090323
//set strWhere value
function UpdatePassword(BusinessPartyCode,password)
{
 var ret=WindowDialog("../System/PasswordEdit.aspx?BusinessPartyCode="+BusinessPartyCode+"&pwd="+password,<%=SysMagic.SystemClass.InfoListSize.Width%>,<%=SysMagic.SystemClass.InfoListSize.Height%>);
 return false;
}
</script>
