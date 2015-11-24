<script language ="javascript" type="text/javascript">
function ValidContainerType(value,ContainerType)
{
  var ContainerType=document.getElementById("txtContainerType").value;
  if(ContainerType.trim==""){return false;}
  if(value!=ContainerType){
    context = ContainerType;
  var arg = "ValidContainerType"+ParSeparator+ContainerType;
  <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetValidContainerType", "context")%>;
  }
}

function SetValidContainerType(result,context) 
{ 
  if (result!="0")
   {
    alert("Container Type has exist and it not can't not be the same!");
    document.getElementById("txtContainerType").focus();
   }
}
function CanSave()
{
    var txt;
    txt=document.getElementById("txtContainerType");
    if (txt.value.Rtrim()=="")
    {
        window.alert("Container Type must input!");
        txt.focus();
        return false;
    }
    return true;
}
function GetDetail()
{
    var strDetail="";
    strDetail=document.getElementById("fldId").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtContainerType").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtExternalLength").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtExternalWidth").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtExternalHeight").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtInternalLength").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtInternalWidth").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtInternalHeight").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtMaterial").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCoat").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCapacity").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtMaximumgrossweight").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtMaxPayLoad").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtStacking").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtTareWeight").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtWorkingPressure").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtApprovals").value;
    strDetail=strDetail+ColSeparator+document.getElementById("hidUserId").value;
    strDetail=strDetail+ColSeparator+"";
    strDetail=strDetail+ColSeparator+"";
    strDetail=strDetail+ColSeparator+"";
    strDetail=strDetail+ColSeparator+"";
    return strDetail;
}

function NewDetail(intFlag)
{
    document.getElementById("fldId").value="-1";
    document.getElementById("txtContainerType").value="";
    document.getElementById("txtExternalLength").value="";
    document.getElementById("txtExternalWidth").value="";
    document.getElementById("txtExternalHeight").value="";
    document.getElementById("txtInternalLength").value="";
    document.getElementById("txtInternalWidth").value="";
    document.getElementById("txtInternalHeight").value="";
    document.getElementById("txtMaterial").value="";
    document.getElementById("txtCoat").value="";
    document.getElementById("txtCapacity").value="";
    document.getElementById("txtMaximumgrossweight").value="";
    document.getElementById("txtMaxPayLoad").value="";
    document.getElementById("txtStacking").value="";
    document.getElementById("txtTareWeight").value="";
    document.getElementById("txtWorkingPressure").value="";
    document.getElementById("txtApprovals").value="";
    document.getElementById("txtContainerType").focus();
}

function BeforeSave()
{
    document.getElementById("btnSave").disabled=true;
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








