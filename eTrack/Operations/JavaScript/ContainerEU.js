<script language ="javascript" type="text/javascript">
function showCancel() 
{  
    //drEvent 
    var obj=document.getElementById("drEvent");
    obj.selectedIndex=0;
    //DrNO
    obj=document.getElementById("DrNO");
    obj.selectedIndex=0;
    //txtNo
    obj=document.getElementById("txtNo");
    obj.value="";
    //txtVesselName
    obj=document.getElementById("txtVesselName");
    obj.value="";
    //txtVoyageNo
    obj=document.getElementById("txtVoyageNo");
    obj.value="";
    context = document.getElementById("divSource");
    intPage=1;
    ShowLoadingData();
    strWhere=" and 1!=1 "
    var arg = "GetPageData"+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString()+ParSeparator+""; 
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetQueryData", "context")%>; 
} 
//-------------------------------------------------------------------------------------------------
function CurrentEvent(strVal)
{
  if(strVal.Trim()==""){return "";}
  switch(strVal.toLowerCase())
  {
    case "bxl" : return "BXD"; break ;
    case "gti" : return "BXL"; break ;
    case "dpo" : return "GTI"; break ;
    case "bxd" : return "GTO"; break ;
    default: return "";break ;
  }
}
function drEventSelect(objEvent)
{
  var objEvent=objEvent.options[objEvent.selectedIndex].value;
  if(objEvent.Trim().toLowerCase()=="bxl")
  {document.getElementById("divNewVoyageNo").style.display='inline';}
  else{document.getElementById("divNewVoyageNo").style.display='none';}
}

function CreateEvent() 
{ 
  var ckbTrxNo ="";
  var strTrxNo="";
  var ValSelect=0;
  var obj=document.getElementById("drEvent")
  var strEvent= CurrentEvent(obj.options[obj.selectedIndex].value);
  if(obj.selectedIndex==0){alert("Event is mandatory.");return false ;}
     var objGrid =document .getElementById("gvwSource")
      if(objGrid.rows.length>1)
      {
           for(var i=1;i<=objGrid .rows.length-1;i++)
           {
                tr = objGrid.rows[i];
                  if (tr.cells[0].hasChildNodes() && (tr.cells[0].childNodes[0].nodeType==1)) 
                  {
                    var strFile=tr.cells[0].childNodes[0].checked;
                    if(strFile==true)
                    {
                      ValSelect+=1;
                      strTrxNo+=tr.cells[0].childNodes[1].value+",";
                    }
                 }
           }
      }
     //txtEventDate
  obj=document.getElementById("txtEventDate")
  var strEventDate=ConvertDate(obj.value);
  if(obj.value.Trim()==""){alert("Event Date is mandatory.");return false ;}
  //txtNewVoyageNo
  obj=document.getElementById("txtNewVoyageNo")
  var strVoyageNo=obj.value.Trim();
  if(ValSelect==0){alert("One or more items in the grid must be selected in order to create event.");return false ;}
  context = document.getElementById("divSource");
  var arg="CreateEvent"+ParSeparator+strTrxNo+ParSeparator+strEvent+ParSeparator+strEventDate+ParSeparator+strVoyageNo;
 <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetCreateEvent", "context")%>; 
}

function SetCreateEvent(result,context) 
{ 
    var strResult=result.split(ParSeparator);
            if (strResult[0]==RtnOk) {
                context.innerHTML = strResult[1];
                alert(strResult[2]);
            }else {alert(strResult[2]);}
            GetPageData(null,-1);
}
//-------------------------------------------------------------------------------------------------
function GetQueryDataEU(sitecode) 
{  
    context = document.getElementById("divSource");
    intPage=1;
    GetQueryEU(sitecode)
    if(strWhere==""){return false;};
    ShowLoadingData();
    var arg = "GetPageData"+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString()+ParSeparator+""; 
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetQueryData", "context")%>; 
} 


function SetQueryData(result, context) 
{  
    HideLoadingData();
    arrTmp = result.split(ParSeparator);
    if(arrTmp.length==2 && arrTmp[1]!=null && arrTmp[1]!=""){
        intCount=arrTmp[0];
        if(intPage>intCount && intPage!=1){
            intPage=intCount;
        }
        context.innerHTML = arrTmp[1];
        return true;
    }
    else{return false;}
} 
//-------------------------------------------------------------------------------------------------
//set strWhere value
function GetQueryEU(sitecode)
{
   strWhere="";
   var strValue="";
   var drValue="";
   var obj ;
    //drEvent
    var valtxtNo =document.getElementById("txtNo").value;
    var valVesselName =document.getElementById("txtVesselName").value;
    var valVoyageNo =document.getElementById("txtVoyageNo").value;
    if(valtxtNo.Trim()=="" && valVesselName.Trim()=="" && valVoyageNo.Trim()=="")
    {alert("One of the following search  field must be entered in order to query:\nJob No\nContainer No\nVessel Name\nVoyage No"); return false;}
    var obj=document.getElementById("drEvent");
    strWhere=" and a.State ='" + obj.options[obj.selectedIndex].value + "' ";
    if(obj.options[obj.selectedIndex].value=="BXL"){strWhere+=" and a.portofdischargecode ='" + sitecode + "' ";}
    else {strWhere+=" and a.SiteCode ='" + sitecode + "' ";}
    //txtNo
   obj=document.getElementById("txtNo");
       if (obj.value.Trim() != "")
       {
         //DrNO
         var drobj=document.getElementById("DrNO");
         var strValue=drobj.selectedIndex;
         var strTxtNo=obj.value.Trim();
         if(drobj.options[drobj.selectedIndex].value=="ContainerNo"){while(strTxtNo.indexOf(" ")> -1){strTxtNo=strTxtNo.replace(" ","");} }//Add for Container 100107
         strWhere += " and a."+drobj.options[drobj.selectedIndex].value +" like '%" + strTxtNo + "%' ";
       }
       //txtVesselName
        obj=document.getElementById("txtVesselName");
        strValue=obj.value;
        if(strValue != "") {strWhere += " and a.VesselName ='" + strValue + "' ";}
       //txtVoyageNo
        obj=document.getElementById("txtVoyageNo");
        strValue=obj.value;
        if(strValue != "") {strWhere += " and a.VoyageNo ='" + strValue + "' ";}
        //strWhere +=" and a.ContainerNo in (select containerNo from rccf1 where UseFlag!='N') "
}
</script>