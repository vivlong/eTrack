<script language="javascript" type="text/javascript">
function UpdatePersonSet()
{
    var strDetail;
    strDetail=document.getElementById("txtUserId").value;
    var drop=document.getElementById("drpFirstPage");
    strDetail=strDetail+ColSeparator+drop.options[drop.selectedIndex].value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtInfoSize").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtSearchSize").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtOpenSize").value;   
    strDetail=strDetail+ColSeparator+document.getElementById("txtStatSize").value;     
    strDetail=strDetail+ColSeparator+document.getElementById("txtDetailSize").value;
    strDetail=strDetail+ColSeparator+document.getElementById("chkDisplaySmsHint").checked;     
	if(strDetail){
	    var arg = "UpdatePersonSet"+ParSeparator +strDetail;
	    context = null;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
	}
}
	
function SetReturnValue(result,context)
{
    if(result==RtnNoLogin){
        return;
    }
    strResult=result.split(ParSeparator);
    if (strResult.length==2) {
        if (strResult[0]==RtnError) {
            window.alert(strResult[1]);
        }
        else {
            window.alert(strResult[1]);
        }
    }
} 

</script>