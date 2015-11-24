<script language ="javascript" type="text/javascript">

function CanSave()
{
    var txt;  
    txt=document.getElementById("txtsPasswordOld");
    fldPassword=document.getElementById("fldPassword");
    if (txt.value.Rtrim()!=fldPassword.value.Rtrim()){
        window.alert("Old password must input!");
        txt.value="";
        txt.focus();
        return false;
    }
    txt1=document.getElementById("txtsPassword1");
    txt2=document.getElementById("txtsPassword2");
    if (txt1.value.Rtrim()!=txt2.value.Rtrim()){
        window.alert("Confirm password is not equal to the new password, please reinput!");
        txt1.value="";
        txt2.value="";
        txt1.focus();
        return false;
    }
    return true;
}

function GetDetail()
{
    var strDetail="";
    strDetail=document.getElementById("fldUserNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtsPassword1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("fldTable").value;
    return strDetail;
}

function ClearDetail()
{
    document.getElementById("txtsPasswordOld").value="";
    document.getElementById("txtsPassword1").value="";
    document.getElementById("txtsPassword2").value="";
    document.getElementById("txtsPasswordOld").focus();
}

function SavePassword()
{
    if (window.confirm("Are you sure to change your login password?")) {
        if (!CanSave()) {
            return;
        }
        var arg = "SavePassword"+ParSeparator+GetDetail(); 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SaveReturn", "null")%>;           
    }
    else {
        return;
    }
}

function SaveReturn(result,context)
{
    strResult=result.split(ParSeparator);
    if (strResult.length==2) {
        if (strResult[0]==RtnOk) {
            window.alert(strResult[1]);
            window.close();
        }
        else {
            window.alert(strResult[1]);
        }
    }
    else {
        window.alert(SaveUnexpectedError);
    }
}

</script>