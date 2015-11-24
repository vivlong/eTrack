<script type="text/javascript" language ="javascript">
function GetPageData(objCon,intFlag) 
{ 
    strWhere="";
    obj = document.getElementById(objCon);
    context = document.getElementById("divSource");
    if(obj) {
        intPage=parseInt(obj.value);
        if(intFlag==0) {
            if ((intCount>1) && (intPage>1)) {
                intPage=1;
            }
            else {
                return;
            }
        }
        else if (intFlag==1) {
            if ((intCount>1) && (intPage>1)) {
                intPage=intPage-1;
            }
            else {
                return;
            }
        }
        else if (intFlag==2) {
            if ((intCount>1) && (intPage<intCount)) {
                intPage=intPage+1;
            }
            else {
                return;
            }
        }
        else if (intFlag==3) {
            if ((intCount>1) && (intPage<intCount)) {
                intPage=intCount;
            }
            else {
                return;
            }
        }
        else if (intFlag==4) {
            if (intPage>intCount) {
                window.alert(CannotExceedLastPage);
                return;
            }
        }
    }
    if (intPage>intCount) {
        intPage=intCount;
    }
    if (intPage<1) {
        intPage=1;
    }
    ShowLoadingData();
    GetQueryValue();
    var arg = "GetPageData"+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+GetQueryValue()+ParSeparator+SortField+ParSeparator+SortDesc.toString()+ParSeparator+""; 
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetVesselSourceValue", "context")%>; 
}

function ExportExcel()
{
//    Loading();
    var arg = "ServerExportExcel"+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString();
    context=null;
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "ShowExcelFile", "context")%>;
}

function SetVesselSourceValue(result, context) 
{  
    HideLoadingData();
    arrTmp = result.split(ParSeparator);
    if(arrTmp.length==2 && arrTmp[1]!=null && arrTmp[1]!=""){
        intCount=arrTmp[0];
        if(intPage>intCount && intPage!=1){
            intPage=intCount;
        }
        context.innerHTML = arrTmp[1];
        if(document.getElementById("lblPage"))
        { var lbl=document.getElementById("lblPage");
        lbl.innerHTML = PageTitle + intPage.toString() + PageSeparator + intCount.toString();
        var txt=document.getElementById("txtPage");
        txt.value=intPage.toString();
        }
        return true;
    }
     else if(arrTmp.length==4 && arrTmp[1]!=null && arrTmp[1]!=""){
        intCount=arrTmp[1];
        if(intPage>intCount && intPage!=1){
            intPage=intCount;
        }
        context.innerHTML = arrTmp[2];
        if(document.getElementById("lblPage"))
        { var lbl=document.getElementById("lblPage");
        lbl.innerHTML = PageTitle + intPage.toString() + PageSeparator + intCount.toString();
        var txt=document.getElementById("txtPage");
        txt.value=intPage.toString();
        }
       
        return true;
    }
    else{
        return false;
    }
} 
function ContainerDetail(intType,intTrxNo,intLineItemNo) //090113byzhiwei
{
    var ret;
    var strContainerId="";
    if (intType==1)
      {
       strContainerId="sebl2"
      }
      if (intType==2)
      {
       strContainerId="sibl2"
      }
    if(strContainerId!="")
    {
        strContainerId=strContainerId+ "A" + intTrxNo.toString() + "A"+ intLineItemNo.toString();
        ret=WindowDialog("ContainerEnquiryDetail.aspx?id="+strContainerId,419,383);
        if(ret!=null && ret!=""){
        GetPageData(null,0) ;
    }
     }
}

//function ExcelOut()
//{
//        Response.Clear();
//        Response.ClearContent();
//        Response.AddHeader("Content-Disposition", "attachment filename=" + DateTime.Now.ToString("_yyyyMMdd_HHmmss") + ".xls");
//        Response.ContentEncoding = System.Text.Encoding.UTF8;
//        Response.ContentType = "application/ms-excel";
//        StringWriter sw = New StringWriter();
//        HtmlTextWriter htw = New HtmlTextWriter(sw);
//        gv.RenderControl(htw);
//        Response.Write(sw.ToString());
//        Response.Flush();
//        Response.End();
// }

function GetVesuslQueryResult()
{ 
    context =document.getElementById("divSource");
    intPage=1;
    ShowLoadingData();
    GetQueryValue();
     var arg = "GetPageData"+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+GetQueryValue()+ParSeparator+""+ParSeparator+SortDesc.toString()+ParSeparator+GetQueryValue();
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetVesuslSourceValue", "context")%>; 
} 
function SetVesuslSourceValue(result, context) 
{ 

    HideLoadingData();
    strResult=result.split(ParSeparator);
    switch(strResult.length)
    {
        case 3:
            intCount=strResult[1];
            context.innerHTML = strResult[2]; 
            var lbl=document.getElementById("lblPage");
            lbl.innerHTML = PageTitle + intPage.toString() + PageSeparator + intCount.toString();
            var txt=document.getElementById("txtPage");
            txt.value=intPage.toString();
            ShowQueryResult();
            break;
        case 4:
            intCount=strResult[1];
            context.innerHTML = strResult[2];
            var lbl=document.getElementById("lblPage");
           // lbl.innerHTML = PageTitle + intPage.toString() + PageSeparator + intCount.toString();
          //  var txt=document.getElementById("txtPage");
       //  txt.value=intPage.toString();
            lbl=document.getElementById("lblResultTitle");
            if(lbl){
                lbl.innerHTML=strResult[3];
            }
            //zhiwei090211
            //ShowQueryResult();
            break;
        default:
            window.alert(strResult[1]);
            break;
    }
}
function GetQueryValue()
{
    var strValue="";
    var drValue="";
    strWhere="";
    var txt;
    //drContainerNo
    var strContainerNo="";
     obj=document.getElementById("drContainerNo");
    if(obj.selectedIndex != "0")
    {
       drValue=" AND a.ContainerNo = '" + obj.options[obj.selectedIndex].text + "' ";
        strWhere =strWhere+drValue;
     }
     //drOBLNo
    obj=document.getElementById("drOBLNo");
    if(obj.selectedIndex != "0")
    {
        drValue=" AND a.OBLNo = '" + obj.options[obj.selectedIndex].text + "' ";
        strWhere =strWhere+drValue;
    }
     //drMasterJobNo
    var strMasterJobNo="";
    obj=document.getElementById("drMasterJobNo");
    if(obj.selectedIndex != "0")
    {
        drValue=" AND a.MasterJobNo = '" + obj.options[obj.selectedIndex].text + "' ";
        strWhere =strWhere+drValue;
    }
     //drVesselName
     obj=document.getElementById("drVesselName");
    if(obj.selectedIndex != "0")
    {
        drValue=" AND a.VesselName = '" + obj.options[obj.selectedIndex].text + "' ";
        strWhere =strWhere+drValue;
    }
     //drCargoStatusCode
     obj=document.getElementById("drCargoStatusCode");
    if(obj.selectedIndex != "0")
    {
        var strStatus= obj.options[obj.selectedIndex].text;
        drValue=" AND a.CargoStatusCode = '" + obj.options[obj.selectedIndex].text + "' ";
        strWhere =strWhere+drValue; 
    }
    else{
        drValue=" AND (a.CargoStatusCode is null OR (a.CargoStatusCode != 'CMP' AND a.CargoStatusCode != 'INB')) ";
        strWhere =strWhere+drValue; 
    }
    obj=document.getElementById("fldPortofDischargeCode");
    strWhere  =strWhere+ " and a.PortofDischargeCode = '" + obj.value.Trim() + "' ";
    return strWhere;
//    obj=document.getElementById("drContainerNo");    
//    if(obj.selectedIndex != "0")
//    {
//    if(document.getElementById("hid_AddField").value=="")
//    {drValue=" and a.ContainerNo ='" + obj.options[obj.selectedIndex].text + "' ";}
//    else {drValue="'" + obj.options[obj.selectedIndex].text + "',";}
//    }
//    obj=document.getElementById("hid_AddField")
//    if(obj.value.Trim()!="")
//    {
//        var arrContainerNo=obj.value.Trim().split(ColSeparator);
//        if (arrContainerNo.length >0)
//         {
//            var i = 0;
//            for(i = 0;i< arrContainerNo.length;i++)
//              {
//                if(arrContainerNo[i] != "")  {strValue += "'" + arrContainerNo[i] + "',";}              
//              }
//            strContainerNo = strValue.substring(0, strValue.length - 1);
//            if(strContainerNo.length > 0){strWhere += " and a.ContainerNo in (" + strContainerNo + ")";}
//         }
//    }
//    else
//    {strWhere=drValue;}
//     //drMasterJobNo
//    var strMasterJobNo="";
//    obj=document.getElementById("drMasterJobNo");
//    if(obj.selectedIndex != "0")
//    {
//    if(document.getElementById("hid_MasterJobNoAddField").value=="")
//    {drValue=" and a.MasterJobNo ='" + obj.options[obj.selectedIndex].text + "' ";}
//    else {drValue="'" + obj.options[obj.selectedIndex].text + "',";}
//    }
//    obj=document.getElementById("hid_MasterJobNoAddField");
//    if(obj.value.Trim()!="")
//    {
//        var arrMasterJobNo=obj.value.Trim().split(ColSeparator);
//        if (arrMasterJobNo.length >0)
//         {
//            var i = 0;
//            for(i = 0;i< arrMasterJobNo.length;i++)
//              {
//                if(arrMasterJobNo[i] != "")  {strValue += "'" + arrMasterJobNo[i] + "',";}              
//              }
//            strMasterJobNo = strValue.substring(0, strValue.length - 1);
//            if(strMasterJobNo.length > 0){strWhere  =strWhere+ " and a.MasterJobNo in (" + strMasterJobNo + ")";}
//         }
//    }
//    else
//    {strWhere =strWhere+drValue;}
//      //drVesselName
//    var strVesselName="";
//    obj=document.getElementById("drVesselName");
//    if(obj.selectedIndex != "0")
//    {
//    if(document.getElementById("hid_VesselNameAddField").value=="")
//    {drValue=" and a.VesselName ='" + obj.options[obj.selectedIndex].text + "' ";}
//    else {drValue="'" + obj.options[obj.selectedIndex].text + "',";}
//    }
//    obj=document.getElementById("fldPortofDischargeCode");
//    strWhere  =strWhere+ " and a.PortofDischargeCode = '" + obj.value.Trim() + "' ";
//    obj=document.getElementById("hid_VesselNameAddField");
//    if(obj.value.Trim()!="")
//    {
//        var arrVesselName=obj.value.Trim().split(ColSeparator);
//        if (arrVesselName.length >0)
//         {
//            var i = 0;
//            for(i = 0;i< arrVesselName.length;i++)
//              {
//                if(arrVesselName[i] != "")  {strValue += "'" + arrVesselName[i] + "',";}              
//              }
//            strVesselName = strValue.substring(0, strValue.length - 1);
//            if(strVesselName.length > 0){strWhere  =strWhere+ " and a.VesselName in (" + strVesselName + ")";}
//         }
//    }
//    else
//    {strWhere =strWhere+drValue;}    
//    return strWhere;
}
function ConvertToDate(strDate)
{
    var strYear=strDate.substr(6,4);
    var strMonth=strDate.substr(3,2);
    var strDay=strDate.substr(0,2);
    return strYear+"-"+strMonth+"-"+strDay;
}

function ClearField()
{
var obj=document.getElementById("drContainerNoField");
    obj.length=0;
var hid_AddField=document.getElementById("hid_AddField")
   hid_AddField.value="";
}
function RemoveField()
{
    var hid_AddField=document.getElementById("hid_AddField")
    var objPD=document.getElementById("drContainerNoField");
    if(objPD.options.length>0)
    {
     var strsplit=ColSeparator+objPD.options[objPD.selectedIndex].text; 
     hid_AddField.value=hid_AddField.value.replace(strsplit,"")
     objPD.options[objPD.selectedIndex]=null;
    }

}
function AddField()
{
    var strValue="";
    var txt;
    //SearchField
    obj=document.getElementById("drContainerNo");
    strValue=obj.options[obj.selectedIndex].value;
    document.getElementById("hid_AddField").value+=ColSeparator+strValue
    //setValue 
    var objPD=document.getElementById("drContainerNoField");
    for(var i=objPD.options.length-1;i> -1;i--) 
    {
    if(objPD.options[i].text==strValue)
    {
      return false ;
     //document.getElementById("ddlResourceType").options[indx] = null
     //objPD.options[i]=null;
    }
    }
         var tOption = document.createElement("Option");
         tOption.text=strValue;
         tOption.value=document.getElementById("drContainerNo").options.length+1;

        objPD.options.add(tOption);
        for(var i=objPD.options.length-1;i> -1;i--) 
        { 
        objPD.appendChild(objPD.options[i]) ;
        objPD.options[objPD.selectedIndex].value=strValue;
        }
        objPD.selectedIndex=0;
}


function MasterJobNoClearField()
{
var obj=document.getElementById("drMasterJobNoField");
    obj.length=0;
var hid_AddField=document.getElementById("hid_MasterJobNoAddField")
   hid_AddField.value="";
}
function MasterJobNoRemoveField()
{
    var hid_AddField=document.getElementById("hid_MasterJobNoAddField")
    var objPD=document.getElementById("drMasterJobNoField");
    if(objPD.options.length>0)
    {
     var strsplit=ColSeparator+objPD.options[objPD.selectedIndex].text; 
     hid_AddField.value=hid_AddField.value.replace(strsplit,"")
     objPD.options[objPD.selectedIndex]=null;
    }

}
function MasterJobNoAddField()
{
    var strValue="";
    var txt;
    //SearchField
    obj=document.getElementById("drMasterJobNo");
    strValue=obj.options[obj.selectedIndex].value;
    document.getElementById("hid_MasterJobNoAddField").value+=ColSeparator+strValue
    //setValue 
    var objPD=document.getElementById("drMasterJobNoField");
    for(var i=objPD.options.length-1;i> -1;i--) 
    {
    if(objPD.options[i].text==strValue)
    {
      return false ;
     //document.getElementById("ddlResourceType").options[indx] = null
     //objPD.options[i]=null;
    }
    }
         var tOption = document.createElement("Option");
         tOption.text=strValue;
         tOption.value=document.getElementById("drMasterJobNo").options.length+1;

        objPD.options.add(tOption);
        for(var i=objPD.options.length-1;i> -1;i--) 
        { 
        objPD.appendChild(objPD.options[i]) ;
        objPD.options[objPD.selectedIndex].value=strValue;
        }
        objPD.selectedIndex=0;
}


function VesselNameClearField()
{
var obj=document.getElementById("drVesselNameField");
    obj.length=0;
var hid_AddField=document.getElementById("hid_VesselNameAddField")
   hid_AddField.value="";
}
function VesselNameRemoveField()
{
    var hid_AddField=document.getElementById("hid_VesselNameAddField")
    var objPD=document.getElementById("drVesselNameField");
    if(objPD.options.length>0)
    {
     var strsplit=ColSeparator+objPD.options[objPD.selectedIndex].text; 
     hid_AddField.value=hid_AddField.value.replace(strsplit,"")
     objPD.options[objPD.selectedIndex]=null;
    }

}
function VesselNameAddField()
{
    var strValue="";
    var txt;
    //SearchField
    obj=document.getElementById("drVesselName");
    strValue=obj.options[obj.selectedIndex].value;
    document.getElementById("hid_VesselNameAddField").value+=ColSeparator+strValue
    //setValue 
    var objPD=document.getElementById("drVesselNameField");
    for(var i=objPD.options.length-1;i> -1;i--) 
    {
    if(objPD.options[i].text==strValue)
    {
      return false ;
     //document.getElementById("ddlResourceType").options[indx] = null
     //objPD.options[i]=null;
    }
    }
         var tOption = document.createElement("Option");
         tOption.text=strValue;
         tOption.value=document.getElementById("drVesselName").options.length+1;

        objPD.options.add(tOption);
        for(var i=objPD.options.length-1;i> -1;i--) 
        { 
        objPD.appendChild(objPD.options[i]) ;
        objPD.options[objPD.selectedIndex].value=strValue;
        }
        objPD.selectedIndex=0;
}


function FromChange()
{
    var obj=document.getElementById("drpFrom");
    if (obj.value=="ETD" || obj.value=="ETA") {
        obj=document.getElementById("lblTo");
        obj.style.display = "inline-block";
        obj=document.getElementById("txtTo");
        obj.style.display = "inline-block";
        obj.value="";  
        obj=document.getElementById("txtFrom");
        obj.value="";   
        obj=document.getElementById("btnFrom");
        obj.style.display = "inline-block";
        obj=document.getElementById("btnTo");
        obj.style.display = "inline-block"; 
    }
    else{
        obj=document.getElementById("lblTo");
        obj.style.display = "none";
        obj=document.getElementById("txtTo");
        obj.style.display = "none";
        obj.value=""; 
        obj=document.getElementById("txtFrom");
        obj.value="";   
        obj=document.getElementById("btnFrom");
        obj.style.display = "none";
        obj=document.getElementById("btnTo");
        obj.style.display = "none"; 
    }
}
function hidCalendarForm()
{
  calendar.hide();
}
</script>
