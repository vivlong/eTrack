<script language ="javascript" type="text/javascript">

function CanSave()
{
    var txt;
      txt=document.getElementById("txtsUserNo");
    if (txt.value.Rtrim()=="") {
        window.alert("User code must input!");
        SelectedDiv(1,2);
        txt.focus();
        return false;
    }
    password1=document.getElementById("txtsPassword");
    password2=document.getElementById("txtPassword");
    if(password1.value.Rtrim()!=password2.value.Rtrim())
    {
        window.alert("Password input not equal,please input!")
        SelectedDiv(1,2);
        password1.value="";
        password2.value="";
        password1.focus();
        return false;
    }
    return true;
}

function GetDetail()
{
    var strDetail="";
    var select;
     // strDetail=document.getElementById("hid_No").value;
   // strDetail=strDetail+ColSeparator+document.getElementById("txtsUserNo").value;
   strDetail=document.getElementById("txtsUserNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtsUserName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtsPassword").value;  
    return strDetail;
}
                        
function NewDetail(intFlag)
{
    document.getElementById("txtsUserNo").value="";
    document.getElementById("txtsUserName").value="";
    document.getElementById("txtsPassword").value="";
    document.getElementById("txtPassword").value="";
    document.getElementById("a2").style.display="none";
    SelectedDiv(1,2);
     document.getElementById("txtsUserNo").readOnly=false;
    document.getElementById("txtsUserNo").focus();
}

function AddSelectedRole()
{
    var ret=WindowDialog("../SysRef/RoleList.aspx",400,400);
    if(ret!=null && ret!="") {
        context=divRole;
        var arg = "AddSelectedRole"+ParSeparator+ret; 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function DeleteOneRole(RowIndex)
{
    if (!StrToBool(SubDeletePrompt) || window.confirm("Are you sure to delete current selected role?")) {
        context=divRole;
        var arg = "DeleteOneRole"+ParSeparator+RowIndex.toString();
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function AddSelectedManagedUser()
{
    var ret=WindowDialog("../SysRef/PersonList.aspx",<%=SysMagic.SystemClass.InfoListSize.Width%>,<%=SysMagic.SystemClass.InfoListSize.Height%>);
    if(ret!=null && ret!="") {
        context=divPerson;
        var arg = "AddSelectedManagedUser"+ParSeparator+ret; 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function DeleteOneManagedUser(RowIndex)
{
    if (!StrToBool(SubDeletePrompt) || window.confirm("Are you sure to delete current selected user？")) {
        context=divPerson;
        var arg = "DeleteOneManagedUser"+ParSeparator+RowIndex.toString();
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function SetReturnValue(result,context) 
{ 
    var strResult=result.split(ParSeparator);
    switch(strResult.length)
    {
        case 2:
            if (strResult[0]==RtnOk) {
                context.innerHTML = strResult[1];           
            }
            else if (strResult[1]!=""){
                window.alert(strResult[1]);
            }
            break;
        default:
            break;
    }    
}

function SetOtherSaveReturn(strResult)
{
    if(strResult.length==4){
       // document.getElementById("divPerson").innerHTML=strResult[2];
        document.getElementById("divRole").innerHTML=strResult[3];
    }
}

function BeforeSave()
{
    document.getElementById("btnSave").disabled=true;
   // document.getElementById("btnNew").disabled=true;
    document.getElementById("btnClose").disabled=true;
    document.getElementById("SaveHint").style.visibility = "visible";
}

function AfterSave()
{
    document.getElementById("btnSave").disabled=false;
   // document.getElementById("btnNew").disabled=false;
    document.getElementById("btnClose").disabled=false;
    document.getElementById("SaveHint").style.visibility = "hidden";
}

</script>