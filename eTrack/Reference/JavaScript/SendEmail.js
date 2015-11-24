<script language="javascript" type="text/javascript">
var params=window.dialogArguments.params;
var subject=params[0];
var content=params[1];
function setValue(){

document.getElementById("txtSubject").value=subject;
document.getElementById("txtContent").value=content;

}
function SendEmail()
{context="";
     var arg = "SendEmail"+ParSeparator+GetDetail();
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
}
function GetDetail()
{
    var strDetail="";
    strDetail=document.getElementById("txtTo").value;
    //Item Information
    strDetail=strDetail+ColSeparator+document.getElementById("txtCC").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtSubject").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtContent").value;
    return strDetail;
}
function SetReturnValue(result,context)
{
  var strResult=result.split(ParSeparator);
       if (strResult[0]==RtnOk) 
       {
        alert(strResult[1]);
        CloseWindow(true);
       }
       else
       {alert(strResult[1]);}
}
function CloseWindow(flag)
{
    window.returnValue=null;
    window.close(); 
}

</script>