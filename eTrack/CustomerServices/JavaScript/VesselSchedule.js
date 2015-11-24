<script type="text/javascript" language ="javascript">
function vesselDetail(intId) //090113byzhiwei
{
    var ret;
        ret=WindowDialog("VesselScheduleDetail.aspx?id="+intId,419,383);
}
function GetVesuslQueryResult()
{ 
    context =document.getElementById("divSource");
    intPage=1;
    ShowLoadingData();
     var arg = "GetPageData"+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString()+ParSeparator+GetQueryValue();
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
            lbl.innerHTML = PageTitle + intPage.toString() + PageSeparator + intCount.toString();
            var txt=document.getElementById("txtPage");
            txt.value=intPage.toString();
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
    var strWhere="";    
    var txt;
    var strPortOfDischargeName="";
    //drPortOfDischarge
    obj=document.getElementById("drPortOfDischarge");
    if(obj.selectedIndex != "0")
    {
    if(document.getElementById("hid_AddField").value=="")
    {drValue=" and a.PortOfDischargeName ='" + obj.options[obj.selectedIndex].text + "' ";}
    else {drValue="'" + obj.options[obj.selectedIndex].text + "',";}
    }
    obj=document.getElementById("hid_AddField")
    if(obj.value.Trim()!="")
    {
        var arrPortOfDischargeName=obj.value.Trim().split(ColSeparator);
        if (arrPortOfDischargeName.length >0)
         {
            var i = 0;
            for(i = 0;i< arrPortOfDischargeName.length;i++)
              {
                if(arrPortOfDischargeName[i] != "")  {strValue += "'" + arrPortOfDischargeName[i] + "',";}              
              }
            strPortOfDischargeName = strValue.substring(0, strValue.length - 1);
            if(strPortOfDischargeName.length > 0){strWhere += " and PortOfDischargeName in (" + strPortOfDischargeName + ")";}
         }
    }
    else
    {strWhere=drValue;}
    //DepartureDate
    strValue="";
    obj=document.getElementById("drDuring");
    if(obj.selectedIndex != "0"){strValue=parseInt(obj.value)*7;}
    obj=document.getElementById("txtDepartureDate");
    if(obj.value.Trim()!="" )
    {
      if(strValue!="")
      {
       var strdate =ConvertToDate(obj.value);
       strWhere =strWhere+ " and datediff(d,'" + strdate + "',Etd)>=0 and datediff(d,'" + strdate+ "',Etd)<=" + strValue +" ";
      }
      else 
      {
       var strdate =ConvertToDate(obj.value);
       strWhere =strWhere+ " and datediff(d,'" + strdate + "',Etd)>=0 ";
      }
     }
    return strWhere;
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
var obj=document.getElementById("drPortOfDischargeField");
    obj.length=0;
var hid_AddField=document.getElementById("hid_AddField")
   hid_AddField.value="";
}
function RemoveField()
{
    var hid_AddField=document.getElementById("hid_AddField")
    var objPD=document.getElementById("drPortOfDischargeField");
    var strsplit=ColSeparator+objPD.options[objPD.selectedIndex].text; 
    hid_AddField.value=hid_AddField.value.replace(strsplit,"")
    objPD.options[objPD.selectedIndex]=null;
}
function AddField()
{
    var strValue="";
    var txt;
    //SearchField
    obj=document.getElementById("drPortOfDischarge");
    strValue=obj.options[obj.selectedIndex].value;
    document.getElementById("hid_AddField").value+=ColSeparator+strValue
    //setValue 
    var objPD=document.getElementById("drPortOfDischargeField");
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
         tOption.value=document.getElementById("drPortOfDischarge").options.length+1;

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
