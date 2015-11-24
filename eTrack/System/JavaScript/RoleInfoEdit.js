<script language ="javascript" type="text/javascript">

function CanSave()
{
    var txt;
    txt=document.getElementById("txtsRoleNo");
    if (txt.value.Rtrim()=="")
    {
        window.alert("Role code must input!");
        SelectedDiv(1,2);
        txt.focus();
        return false;
    }
    txt=document.getElementById("txtsRoleName");
    if (txt.value.Rtrim()=="")
    {
        window.alert("Role name must input!");
        SelectedDiv(1,2);
        txt.focus();
        return false;
    }
    return true;
}

function GetDetail()
{
    var strDetail="";
    strDetail=document.getElementById("fldId").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtsRoleNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtsRoleName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("hidUser").value; 
    return strDetail;
}

function NewDetail(intFlag)
{
    document.getElementById("fldId").value="-1";
    document.getElementById("txtsRoleNo").value="";
    document.getElementById("txtsRoleName").value="";
    SelectedDiv(1,2);
    document.getElementById("txtsRoleNo").focus();
}

function AddSelectedRolePerson()
{
    var ret=WindowDialog("../SysRef/PersonList.aspx",<%=SysMagic.SystemClass.InfoListSize.Width%>,<%=SysMagic.SystemClass.InfoListSize.Height%>);
    if(ret!=null && ret!=""){
        context=divPerson;
        var arg = "AddSelectedRolePerson"+ParSeparator+ret; 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function DeleteOneRolePerson(RowIndex)
{
    if (window.confirm("Are you sure to delete current select role person?")) {
        context=divPerson;
        var arg = "DeleteOneRolePerson"+ParSeparator+RowIndex.toString();
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
    if(strResult.length==3){
        document.getElementById("divPerson").innerHTML=strResult[2];
    }
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

</script>