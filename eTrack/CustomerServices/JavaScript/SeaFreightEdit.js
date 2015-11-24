<script language ="javascript" type="text/javascript">
function AddSelectedAttach()
{
     var strJobNo=document.getElementById("txtJobNo").value;
    var ret=WindowDialog("../SysRef/AttachEdit.aspx?Id="+strJobNo+"&Folder=Tracking",640,450);
    if(ret!=null && ret!=""){
        context = document.getElementById("div2");
        var arg = "AddSelectedAttach"+ParSeparator+ret; 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function DeleteOneAttach(strFileName)
{
    var strId=document.getElementById("fldId").value;
    if (window.confirm("Are you sure to delete current select attachment?")) {
        context = document.getElementById("div2");
        var arg = "DeleteOneAttach"+ParSeparator+strId+ParSeparator+strFileName;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}
function SetReturnValue(result,context) 
{ 

    AfterSave();
    var strResult=result.split(ParSeparator);
    switch(strResult.length) {
        case 2:
            if (strResult[0]==RtnOk) {
                context.innerHTML = strResult[1];
            }
            break;
        case 3:
            if (strResult[0]==RtnOk) {
                context.innerHTML = strResult[1];
                if (strResult[2].length <= 6){
                  document.getElementById("fldId").value=strResult[2];
                } 
            }
            else if (strResult[1]!=""){
                window.alert(strResult[1]);
            }
            break;
        case 4:
            if (strResult[0]==RtnOk) {
                context.innerHTML = strResult[1];
            }
            break 
        case 5:
            if (strResult[0]!=RtnOk) {
                //window.alert(strResult[1]);
            }
            else if (strResult[1]!=""){
                window.alert(strResult[1]);
            }
            break;
        default:
            break;
    }
}
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