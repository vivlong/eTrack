<script language ="javascript" type="text/javascript">

function CanSave()
{
    return true;
}

function GetDetail()
{
    var strDetail="";
    return strDetail;
}

function NewDetail(intFlag)
{
}

function BeforeSave()
{
    document.getElementById("btnSave").disabled=true;
    document.getElementById("btnNew").disabled=true;
    document.getElementById("btnClose").disabled=true;
    document.getElementById("SaveHint").style.display = "block";
}

function AfterSave()
{
    document.getElementById("btnSave").disabled=false;
    document.getElementById("btnNew").disabled=false;
    document.getElementById("btnClose").disabled=false;
    document.getElementById("SaveHint").style.display = "none";
}

function AddStatus()
{
    var obj=document.getElementById("txtJobNo");
    if(obj && obj.value){
        var ret;
        ret=WindowDialog("StatusEdit.aspx?JobNo="+obj.value+"&Id=-1",480,360);
        if (ret==RtnOk) {
            context = document.getElementById("divSource");
            var arg = "GetJobStatus";
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetJobStatus", "context")%>;
        }
    }
}

function SetJobStatus(result,context)
{
    strResult=result.split(ParSeparator);
    if (strResult.length==2) {
        switch(strResult[0])
        {
            case RtnOk:
                context.innerHTML = strResult[1]; 
                break;
            default:
                window.alert(strResult[1]);
                break;
        }
    }
    else {
        window.alert(ReturnValueError);
    }
}
</script>