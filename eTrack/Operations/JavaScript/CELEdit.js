<script language ="javascript" type="text/javascript">
//lzw091228
function ShowState(objEventCode){
  EventCode =objEventCode.value;
  var strState="";
  switch(EventCode)
  {
   case "Depot Out":strState="DPO";break ;
   case "Gate In":strState="GTI";break ;
   case "Box Load":strState="BXL";break ;   
   case "Box Disch":strState="BXD";break ;
   case "Gate Out":strState="GTO";break ;
   case "Depot In":strState="DPI";break ;
  }
  document.getElementById("drState").value=strState;
  
}
//lzw091228
function selBindCode(objCode,table,fields,where,showCode,showName)
{
    if(where.indexOf("'")>0){
    var arrwhere =where.split("'");
    var i=0;
    for(i=0;i<arrwhere.length;i++){where=where.replace("'","@@@");}
    }
    arrwhere =where.split("=");
    for(i=0;i<arrwhere.length;i++){where=where.replace("=","~");}

    var ret=WindowDialog("../Reference/TypeSort.aspx?table="+table+"&fields="+fields+"&where="+where+"&showCode="+showCode+"&showName="+showName,<%=SysMagic.SystemClass.InfoListSize.Width%>,<%=SysMagic.SystemClass.InfoListSize.Height%>);
    if(ret!=null)
    {
     var strRel=ret.split(ColSeparator);
     if (strRel.length==2) 
     {
        var txt=strRel[0]=="&nbsp;"?" ":strRel[0];
          txt=txt.replace('amp;','');
          objCode.value=strRel[0];
     }
    }
}
//lzw091012
function BindCodeName(objCode,objName,table,fields,where,showCode,showName)
{
    var ret=WindowDialog("../Reference/TypeSort.aspx?table="+table+"&fields="+fields+"&where="+where+"&showCode="+showCode+"&showName="+showName,<%=SysMagic.SystemClass.InfoListSize.Width%>,<%=SysMagic.SystemClass.InfoListSize.Height%>);
    if(ret!=null)
    {
     var strRel=ret.split(ColSeparator);
     if (strRel.length==2) 
     {
        var txt=strRel[1]=="&nbsp;"?" ":strRel[1];
            txt=txt.replace('amp;','');
          objCode.value=strRel[0];
          objName.value=txt;
     }
    }
}
function GetContainerType()
{
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
    txt=document.getElementById("txtEquipmentType");
    if (txt.value.Rtrim()=="")
    {
        window.alert("Equipment Type input!");
        txt.focus();
        return false;
    }
    txt=document.getElementById("txtDepotCode");
    if (txt.value.Rtrim()=="")
    {
        window.alert("Depot Code input!");
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
    strDetail=strDetail+ColSeparator+document.getElementById("txtEquipmentType").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtSiteCode").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtEventPortCode").value;        
    var select=document.getElementById("drEventCode");
    strDetail=strDetail+ColSeparator+select.options[select.selectedIndex].value;
    strDetail=strDetail+ColSeparator+document.getElementById("drState").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtEventDate").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtJobNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipperCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipperName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtPortOfLoading").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtFinalDestination").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtVesselName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtVoyageNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsigneeCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsigneeName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDepotCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtTruckerName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtVehicleNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtSealNo").value;
    var select=document.getElementById("drDGFlag");
    strDetail=strDetail+ColSeparator+select.options[select.selectedIndex].value;     
    strDetail=strDetail+ColSeparator+document.getElementById("txtDriverPassNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDetentionCharge").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtComputedDetentionCharge").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtSurveyRemarks").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtRemarks").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtUserId").value;
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
    document.getElementById("txtEquipmentType").value="";
    document.getElementById("txtSiteCode").value="";
    document.getElementById("txtEventPortCode").value="";
    document.getElementById("drEventCode").selectedIndex=0;
    document.getElementById("drState").value="";
    document.getElementById("txtEventDate").value="";
    document.getElementById("txtJobNo").value="";
    document.getElementById("txtShipperCode").value="";
    document.getElementById("txtShipperName").value="";
    document.getElementById("txtPortOfLoading").selectedIndex=0;
    document.getElementById("txtFinalDestination").value="";    
    document.getElementById("txtVesselName").value="";
    document.getElementById("txtVoyageNo").value="";  
    document.getElementById("txtConsigneeCode").value="";  
    document.getElementById("txtConsigneeName").value="";  
    document.getElementById("txtDepotCode").value="";  
    document.getElementById("txtTruckerName").value="";  
    document.getElementById("txtVehicleNo").value="";  
    document.getElementById("txtSealNo").value="";
    document.getElementById("drDGFlag").selectedIndex=0;
    document.getElementById("txtDriverPassNo").value="";  
    document.getElementById("txtDetentionCharge").value="";  
    document.getElementById("txtComputedDetentionCharge").value="";  
    document.getElementById("txtSurveyRemarks").value="";
    document.getElementById("txtRemarks").value="";
    document.getElementById("txtContainerNo").focus();
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
//    document.getElementById("btnNew").disabled=false;
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

</script>








