<script language ="javascript" type="text/javascript">
function getRBLvalue(){
    var b=document.getElementById("rblUseFlag").length
    var a=document.getElementById("rblUseFlag").cells.length; 
    for(var i=0;i<a;i++)
    {
      var ss="rblUseFlag_"+i;
      var aa=document.getElementById(ss).value;
        var bb=document.getElementById(ss);
      if(document.getElementById(ss).checked){return aa;}
    }
}
function GetContainerType(){
    var select=document.getElementById("drpContainerType");
    var strContainerType=select.options[select.selectedIndex].value;
    context=null;
    var arg = "GetContainerType"+ParSeparator+strContainerType;
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "GetContainerTypeReturn", "context")%>;
}
function GetContainerTypeReturn(result,context)
{
    var strResult=result.split(ParSeparator);
    if (strResult.length==2){
        var strValues=strResult[1].split(ColSeparator);
        if (strValues.length==13){
            document.getElementById("txtExternalLength").value=strValues[0];
            document.getElementById("txtExternalWidth").value=strValues[1];
            document.getElementById("txtHeight").value=strValues[2];
            document.getElementById("txtInternalLength").value=strValues[3];
            document.getElementById("txtInternalWidth").value=strValues[4];
            document.getElementById("txtInternalHeight").value=strValues[5];
            document.getElementById("txtMaterial").value=strValues[6];
            document.getElementById("txtCapacity").value=strValues[7];
            document.getElementById("txtTareWeight").value=strValues[8];
            document.getElementById("txtMaximumgrossweight").value=strValues[9];
            document.getElementById("txtMaxPayLoad").value=strValues[10];
            document.getElementById("txtCoat").value=strValues[11];
            document.getElementById("txtApprovals").value=strValues[12];
        }
        else {
            window.alert(strResult[1]);
        }
    }
}
function DefaultOnHireDate(objCommissionDate,objOnHireDate)
{objOnHireDate.value=objCommissionDate.value;}
//---------------------------------------------------------------------------
function CanSave()
{
    var txt;
    txt=document.getElementById("txtContainerNo");
    if (txt.value.Rtrim()=="")
    {
        window.alert("Container No must input!");
        txt.focus();
        return false;
    }

    txt=document.getElementById("txtLessor");
    if (txt.value.Rtrim()=="")
    {
        window.alert("Lessor must input!");
        txt.focus();
        return false;
    }
    return true;
}
function GetDetail()
{
    var strDetail="";
    strDetail=document.getElementById("fldId").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtContainerNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCommissionDate").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtOnHireDate").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtOffHireDate").value;        
    var select=document.getElementById("drpTankCategory");
    strDetail=strDetail+ColSeparator+select.options[select.selectedIndex].value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtLessor").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtManuDate").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtManufacturer").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtPlate").value;
    select=document.getElementById("drpContainerType");
    strDetail=strDetail+ColSeparator+select.options[select.selectedIndex].text;
    strDetail=strDetail+ColSeparator+document.getElementById("txtExternalLength").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtExternalWidth").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtHeight").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtInternalLength").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtInternalWidth").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtInternalHeight").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtMaterial").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCoat").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCapacity").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtMaximumgrossweight").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtTareWeight").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtMaxPayLoad").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtTestingPressure").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtThickness").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtApprovals").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtFileName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("hidUserId").value;    
    strDetail=strDetail+ColSeparator+getRBLvalue();
    strDetail=strDetail+ColSeparator+"";
    strDetail=strDetail+ColSeparator+"";
    strDetail=strDetail+ColSeparator+"";
    strDetail=strDetail+ColSeparator+"";
    strDetail=strDetail+ColSeparator+"";
    return strDetail;
}

function NewDetail(intFlag)
{
    document.getElementById("fldId").value="-1";
    document.getElementById("txtContainerNo").value="";
    document.getElementById("txtCommissionDate").value="";
    document.getElementById("txtOnHireDate").value="";
    document.getElementById("txtOffHireDate").value="";
    document.getElementById("drpTankCategory").selectedIndex=0;
    document.getElementById("txtLessor").value="";
    document.getElementById("txtManuDate").value="";
    document.getElementById("txtManufacturer").value="";
    document.getElementById("txtPlate").value="";
    document.getElementById("drpContainerType").selectedIndex=0;
    document.getElementById("txtExternalLength").value="";    
    document.getElementById("txtExternalWidth").value="";  
    document.getElementById("txtHeight").value="";  
    document.getElementById("txtInternalLength").value="";  
    document.getElementById("txtInternalWidth").value="";  
    document.getElementById("txtInternalHeight").value="";  
    document.getElementById("txtMaterial").value="";  
    document.getElementById("txtCoat").value="";  
    document.getElementById("txtCapacity").value="";
    document.getElementById("txtMaximumgrossweight").value="";  
    document.getElementById("txtTareWeight").value="";  
    document.getElementById("txtMaxPayLoad").value="";  
    document.getElementById("txtTestingPressure").value="";
    document.getElementById("txtThickness").value="";
    document.getElementById("txtApprovals").value="";
    document.getElementById("txtFileName").value="";
    document.getElementById("hidUserId").value="";
    document.getElementById("txtContainerNo").focus();
    //set evetn
    var objCommissionDate=document.getElementById("txtCommissionDate")
    objCommissionDate.onchange=function(){document.getElementById("txtOnHireDate").value=document.getElementById("txtCommissionDate").value;}
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

function GetTankType()
{
    var select=document.getElementById("drpTankType");
    var strTankType=select.options[select.selectedIndex].value;
    context=null;
    var arg = "GetTankType"+ParSeparator+strTankType;
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "GetTankTypeReturn", "context")%>;
}

function GetTankTypeReturn(result,context)
{
    var strResult=result.split(ParSeparator);
    if (strResult.length==2){
        var strValues=strResult[1].split(ColSeparator);
        if (strValues.length==25){
            document.getElementById("txtLength").value=strValues[0];
            document.getElementById("txtBreadth").value=strValues[1];
            document.getElementById("txtHeight").value=strValues[2];
            document.getElementById("txtMaterial").value=strValues[3];
            document.getElementById("txtCapacity").value=strValues[4];
            document.getElementById("txtGrossWeight").value=strValues[5];
            document.getElementById("txtStacking").value=strValues[6];
            document.getElementById("txtTareWeight").value=strValues[7];
            document.getElementById("txtWorkingPressure").value=strValues[8];
            document.getElementById("txtTestingPressure").value=strValues[9];
            document.getElementById("txtThickness").value=strValues[10];
            document.getElementById("txtInsulation").value=strValues[11];
            document.getElementById("txtCoat").value=strValues[12];
            document.getElementById("txtSurface").value=strValues[13];
            document.getElementById("txtSteamPressure").value=strValues[14];
            document.getElementById("txtTopAccess").value=strValues[15];
            document.getElementById("txtManhole").value=strValues[16];
            document.getElementById("txtDipstick").value=strValues[17];
            document.getElementById("txtValves").value=strValues[18];
            document.getElementById("txtThermometer").value=strValues[19];
            document.getElementById("txtTopOutlets").value=strValues[20];
            document.getElementById("txtBottomOutlets").value=strValues[21];
            document.getElementById("txtOutletConnection").value=strValues[22];
            document.getElementById("txtGaskets").value=strValues[23];
            document.getElementById("txtApprovals").value=strValues[24];
        }
        else {
            window.alert(strResult[1]);
        }
    }
}

function BookTank(intId)
{
    WindowDialog("TankBookEdit.aspx?Id=" + intId.toString(),720,540);
    window.close();
    return false;
}
</script>








