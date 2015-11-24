<script language="javascript" type="text/javascript">

function GetQueryData(obj) 
{ 

    context = document.getElementById("divSource");
    var strQuery=obj.value;
    intPage=1;
    if(strQuery==undefined || strQuery==null) {
        strQuery="";
    }
    var arg = "GetQueryData"+ParSeparator+GetQueryValue(); 
    <%= ClientScript.GetCallbackEventReference(me, "arg", "SetSourceValue", "context")%>; 
} 
function GetQueryValue() 
{
 var strDetail="";
 var drField=document.getElementById("drField");
    strDetail=strDetail+ColSeparator+drField.options[drField.selectedIndex].value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtSearch").value;
return strDetail;
}
function SetSourceValue(result, context) 
{ 
    context.innerHTML = result; 
} 

</script>