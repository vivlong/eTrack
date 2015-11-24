<script language ="javascript" type="text/javascript">
//---------------------091028--------------------------------------------------------------------------
function CheckContainerNo(event,objContainerNo,SenondCon,ContainerType,UpperCase)
{
        var strContaienrNo= objContainerNo.value;
        if(strContaienrNo==""){return false;}
        if(UpperCase=="y"){
        strContaienrNo=strContaienrNo.toUpperCase();
        objContainerNo.value=strContaienrNo;}
        var strTrxNo=document.getElementById("fldId").value;
        var strLineitemno=document.getElementById("hidLineItemNo").value;
        context = document.getElementById("divSource");
        var arg="CheckContainerNo"+ParSeparator+strContaienrNo+ParSeparator+SenondCon+ParSeparator+objContainerNo.id+ParSeparator+ContainerType+ParSeparator+strTrxNo+ParSeparator+strLineitemno;
     <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetContainerNo", "context")%>;   
}
function SetContainerNo(result,context)
{
    var strResult=result.split(ParSeparator);
            if (strResult[0].toLowerCase()=="1") {
               alert(strResult[2]);
               document.getElementById(strResult[3]).value="";
               document.getElementById(strResult[3]).focus();
            }
            else
            {
             document.getElementById(strResult[1]).focus();
             document.getElementById(strResult[1]).value=document.getElementById("hidTruckerName").value;
             document.getElementById(strResult[1]).focus();
             document.getElementById(strResult[4]).value=document.getElementById("hidEquipmentType").value;             
            }
}
function ReleaseContainer()
{
    if (window.confirm("Are you sure to release container?")) 
    {
          var strTrxNo="";
          var strLineItemNo ="";
          var strContainerNo ="";
          var strReleaseDate =document.getElementById("txtReleaseDate").value;
              strReleaseDate=ConvertDate(strReleaseDate);
             if(strReleaseDate.Trim()==""){ alert("Release Date is mandatory."); return false ;}
             var objGrid =document .getElementById("gvwSource")
             var strAll="";
              if(objGrid.rows.length>1)
              {
                   for(var i=1;i<=objGrid .rows.length-1;i++)
                   {
                        tr = objGrid.rows[i];
                          if (tr.cells[0].hasChildNodes() && (tr.cells[0].childNodes[0].nodeType==1)) 
                          {
                             var strFields=tr.cells[0].childNodes[0].value+",";
                             strFields+=tr.cells[0].childNodes[2].value+",";
                             strFields+=""+tr.cells[1].childNodes[0].value+",";
                             strFields+=""+strReleaseDate+",";                             
                             strFields+="#";
                         }
                         else if(objGrid.rows.length==1)
                         {
                            alert('Please add the release container.')
                            return false ;
                         }
                         if(strAll.indexOf(strFields)<0)
                         {strAll+=strFields;}
                   }
               if(strAll !="")
                {
                    context = document.getElementById("divSource");
                    var arg="InsertCTCE"+ParSeparator+strAll;
                    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReleaseContainer", "context")%>;     
                }
              }
              else{alert('Please add the release container.');}
    }
}
function SetReleaseContainer(result,context) 
{ 
    var strResult=result.split(ParSeparator);
            if (strResult[0]==RtnOk) {
                alert(strResult[1]);
                window.close();
            }
            else if (strResult[1]!=""){
             alert(strResult[1]);
             window.close();
            }
            else{window.close();}
}
//----------------------------------------------------------------------------------------------------------------
      var previousIndex="-1";
      var currentIndex="-1";
      var countOpeng="-1";
      var OldValue="";
      var currentValue="";
      var i=0;
      var currentCon=""
      var strField="";
      var valContainer="";
      //OnBlur
      function focusAt(e,obj,ContainerNo,UpperFlag)
      {
            var strContainerNo="";
             if(strField.toLowerCase()=="containerno")
              {
                if(currentValue.Trim()=="")
                {
                  e.returnValue=false;
                  document.getElementById(obj).focus();
                  return false ;
                } 
              }
      //----------------------------------------------------------------------   
         var flagUpdate=0;
           try
           { 
             var act =document.activeElement.parentNode.parentNode
             previousIndex = act.rowIndex;             
                 if(currentCon!=document.activeElement.id)
                 {
                       currentCon=document.activeElement.id;
                       if(previousIndex!="-1" && currentIndex!=previousIndex)
                       {
                         countOpeng=previousIndex
                         currentIndex=previousIndex;
                         previousIndex="-1";
                         if(OldValue!=currentValue)
                         {flagUpdate=1;}
                       }
                       else{
                              if(OldValue.toLowerCase()!=currentValue.toLowerCase())
                              {flagUpdate=1;}
                              countOpeng =previousIndex;
                              currentIndex=previousIndex;
                           }
                 }
           }
           catch(err){previousIndex=-1;}
           if(flagUpdate==1)
           {
               flagUpdate=0;
               var strTrxNo=document.getElementById("fldId").value;
               var strLineitemno=document.getElementById("hidLineItemNo").value;
               if(strTrxNo!="" && strLineitemno!="")
               { 
                 var strCurrentControl="";
                 strCurrentControl=obj;
                 if(obj.indexOf("ContainerNo")>0)
                 {
                   valContainer=OldValue;
                   strContainerNo=currentValue;
                 }
                 if(UpperFlag=="y"){currentValue=currentValue.toUpperCase();}
                 var strslq=" update ctro2 set "+strField+"='"+currentValue.replace("'","''")+"' where TrxNo="+strTrxNo+" and LineItemNo="+strLineitemno+" and ContainerNo='"+ContainerNo+"'";
                 context = document.getElementById("divSource");
                 var arg = "CTRO2Update"+ParSeparator+strslq+ParSeparator+strTrxNo+ParSeparator+strLineitemno+ParSeparator+ContainerNo+ParSeparator+strCurrentControl+ParSeparator+currentValue;
                 <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetUpdateCTRO2", "context")%>;
               }
           }
       }
       function SetUpdateCTRO2(result,context) 
       {
            var strResult=result.split(ParSeparator);
            switch(strResult.length) {
                case 3:
                    if (strResult[0]==RtnOk) {context.innerHTML=strResult[1];}
                    else
                    {
                      alert(strResult[1]);
//                      if(result.indexOf("Container NO")>0)
//                      {
                        document.getElementById(strResult[2]).value=valContainer;
                        document.getElementById(strResult[2]).focus();
//                      }
//                      e.returnValue=false;
                      return false ;
                    }
                    break;
                default:
                    break;
            }
       }
       //UpdteValue-Onfocus
       function UpdateValue(obj,RowIndex,Field)
       {
         currentIndex=RowIndex;
         currentCon=obj.id;
         OldValue=document.getElementById(obj).value;
         currentValue=document.getElementById(obj).value;
         strField=Field;
       }
       //getOldValue-OnKeyUp
       function getOldValue(obj)
       {
        currentValue=document.getElementById(obj).value;
       }
       function CheckNull(event,firObj,secObj)
       {
        if((event.keyCode==13)||(event.keyCode==0x28)||(event.keyCode==9)) 
         {
           if(firObj.value.Trim()!="")
           {
             FocusControlRC(event,firObj,secObj)
           }
           else{event.returnValue=false;alert("is mandatory.")}
         }
       }
//------------------------------091029----------------------------------------------------------------------------
function EnterAddCtro2(UpperFlag)
{
   if((event.keyCode==13)||(event.keyCode==0x28)||(event.keyCode==9)) 
   {
        var blankFlag=0 ;
        var strFile="";
        var strContainerNO="";
        var strTruckerName="";
        var strVehicleNo="";
        var signFrame = document.getElementById("gvwSource");
        var strTrxNo=document.getElementById("fldId").value;
        var strLineitemno=document.getElementById("hidLineItemNo").value;
        var strReleaseDate=document.getElementById("txtReleaseDate").value;
            strReleaseDate=ConvertDate(strReleaseDate);
        var tr;
           if(signFrame.rows.length == 1){blankFlag+=1}
           else if (signFrame.rows.length > 1)
           { 
                tr = signFrame.rows[signFrame.rows.length-1];
                  if (tr.cells[1].hasChildNodes() && (tr.cells[1].childNodes[0].nodeType==1)) 
                  {
                     if(UpperFlag=="y"){tr.cells[9].childNodes[0].value=tr.cells[9].childNodes[0].value.toUpperCase();}
                     strFile=tr.cells[1].childNodes[0].value.replace(/,/g,"")
                     strContainerNO=strFile;
                     if(strFile==""){alert("Container No is mandatory.");return false;}
                     var DGFlag=tr.cells[6].childNodes[0].value.replace(/,/g,"")
                     if(DGFlag!=""){if(DGFlag.Trim()!='N' && DGFlag.Trim()!='Y')
                     {alert("Please enter either 'Y' or 'N' for DG Flag.");
                      tr.cells[6].childNodes[0].value='';
                      tr.cells[6].childNodes[0].focus();
                      return false;}
                     }
                       strTruckerName=tr.cells[3].childNodes[0].value.replace(/,/g,"")
                       strVehicleNo=tr.cells[4].childNodes[0].value.replace(/,/g,"")                       
                       strFile=strTrxNo+","+strLineitemno+",'"+strFile+"'";
                       for (var j = 3; j< tr.cells.length; j++) 
                         {
                            strFile+=",'"+tr.cells[j].childNodes[0].value.replace(/,/g,"").replace("'","''")+"'"; 
                            blankFlag+=1;
                         }
                         //add Release Date
                         //if(strReleaseDate.trim()!="")
                         //{strReleaseDate="'"+ConvertDate(strReleaseDate.trim())+"'";}
                         //else{strReleaseDate="null";}
                       strFile="("+strFile+")"
                 }
           }
           if(blankFlag>0)
           {
                var signFrame = document.getElementById("gvwSource");
                context = document.getElementById("divSource");
                var arg = "RO2SaveOne"+ParSeparator+strFile+ParSeparator+strTrxNo+ParSeparator+strLineitemno+ParSeparator+strContainerNO+ParSeparator+strTruckerName+ParSeparator+strVehicleNo;
                <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetRO2SaveOne", "context")%>;  
           }
      }
}
 function AddToRO2()
{
        var blankFlag=0 ;
        var strFile="";
        var strContainerNO="";
        var strTruckerName="";
        var strVehicleNo="";
        var signFrame = document.getElementById("gvwSource");
        var strTrxNo=document.getElementById("fldId").value;
        var strLineitemno=document.getElementById("hidLineItemNo").value;
        var strReleaseDate=document.getElementById("txtReleaseDate").value;
            strReleaseDate=ConvertDate(strReleaseDate);
        var tr;
           if(signFrame.rows.length == 1){blankFlag+=1}
           else if (signFrame.rows.length > 1)
           { 
                tr = signFrame.rows[signFrame.rows.length-1];
                  if (tr.cells[1].hasChildNodes() && (tr.cells[1].childNodes[0].nodeType==1)) 
                  {
                     strFile=tr.cells[1].childNodes[0].value.replace(/,/g,"")
                     strContainerNO=strFile;
                     if(strFile==""){alert("Container NO must input!");return false;}
                     var DGFlag=tr.cells[6].childNodes[0].value.replace(/,/g,"")
                     if(DGFlag!=""){if(DGFlag.Trim()!='N' && DGFlag.Trim()!='Y')
                     {alert("Please enter either 'Y' or 'N' for DG Flag.");
                      tr.cells[6].childNodes[0].value='';
                      tr.cells[6].childNodes[0].focus();
                      return false;}
                     }
                       strTruckerName=tr.cells[3].childNodes[0].value.replace(/,/g,"")
                       strVehicleNo=tr.cells[4].childNodes[0].value.replace(/,/g,"")                       
                       strFile=strTrxNo+","+strLineitemno+",'"+strFile+"'";
                       for (var j = 3; j< tr.cells.length; j++) 
                         {
                            strFile+=",'"+tr.cells[j].childNodes[0].value.replace(/,/g,"").replace("'","''")+"'"; 
                            blankFlag+=1;
                         }
                         //add Release Date
                         //if(strReleaseDate.trim()!="")
                         //{strReleaseDate="'"+ConvertDate(strReleaseDate.trim())+"'";}
                         //else{strReleaseDate="null";}
                       strFile="("+strFile+")"
                 }
           }
           if(blankFlag>0)
           {
                var signFrame = document.getElementById("gvwSource");
                context = document.getElementById("divSource");
                var arg = "RO2SaveOne"+ParSeparator+strFile+ParSeparator+strTrxNo+ParSeparator+strLineitemno+ParSeparator+strContainerNO+ParSeparator+strTruckerName+ParSeparator+strVehicleNo;
                <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetRO2SaveOne", "context")%>;  
           }
}
function SetRO2SaveOne(result,context) 
{
    var strResult=result.split(ParSeparator);
    switch(strResult.length) {
        case 2:
            if (strResult[0]==RtnOk) { context.innerHTML = strResult[1];
                    var signFrame = document.getElementById("gvwSource");
                    var tr;
                       if(signFrame.rows.length == 1){blankFlag+=1}
                       else if (signFrame.rows.length > 1)
                       { 
                            tr = signFrame.rows[signFrame.rows.length-1];
                              if (tr.cells[1].hasChildNodes() && (tr.cells[1].childNodes[0].nodeType==1)) 
                              {
                              if(tr.cells[1].childNodes[0].display)
                              {tr.cells[1].childNodes[0].focus();}
                              }
                       }
            }
            else{alert(strResult[1]);}
            break;
        default:
            break;
    }
}
     //-----------------------------------------------------------------------------
function DeleteCTRO2(strContainerNo)
{
            if (window.confirm("Are you sure to delete this record?")) 
            {
                var strTrxNo=document.getElementById("fldId").value;
                var strLineitemno=document.getElementById("hidLineItemNo").value;
                context = document.getElementById("divSource");
                var arg = "DeleteCTRO2"+ParSeparator+strTrxNo+ParSeparator+strLineitemno+ParSeparator+strContainerNo.toString();
                <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetDeleteCTRO2", "context")%>;
            }
}
     //-----------------------------------------------------------------------------
function SetDeleteCTRO2(result,context) 
{ 
    var strResult=result.split(ParSeparator);
            if (strResult[0]==RtnOk) {
                context.innerHTML = strResult[1];
            }
            else if (strResult[1]!=""){
            }
}
//-----------------------------------------------------------------------------------------------


function ReturntheValue(result,context)
{
        window.alert(result);
        window.close(); 
} 

function CanConfirmSave()
{
    return true;
}
  
function BeforeSave()
{
    document.getElementById("btnSave").disabled=true;
    document.getElementById("btnClose").disabled=true;
} 
function SetOtherSaveReturn(strResult)
{
    if(strResult.length==4){
        document.getElementById("divAttach").innerHTML=strResult[2];
        document.getElementById("fldId").value=strResult[3];
    }
}
 
function ConvertDate(strDate)
{
 try
 {
   if(strDate.Trim()!="")
   {strDate=strDate.substr(6)+"-"+strDate.substr(3,2)+"-"+strDate.substr(0,2);}
   else {strDate="";}
 }
 catch(err)
 {strDate="";}
  return strDate;
}




function SetReturnValue(result,context) 
{
    var strResult=result.split(ParSeparator);
    switch(strResult.length) {
        case 2:
            if (strResult[0]==RtnOk) {
                context.innerHTML = strResult[1];
            }
            else if (strResult[1]!=""){
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
function FocusControlRC(event,Prev,Next)
{
   if((event.keyCode==13)||(event.keyCode==0x28)) 
   {
        if(Next!=null) {
            if(!Next.disabled && Next.style.display!="none"){
                event.returnValue=false;
                Next.focus();
                if (Next.type=="text") {
                }
            }
            else{
                      event.keyCode=9;
            }
            return ;
        }
        else {
            event.returnValue=false;
        }
    }
}
function FocusControlRemark(event,Prev,Next)
{
   if((event.keyCode==13)||(event.keyCode==0x28)){
        if(Next!=null) {
            if(!Next.disabled && Next.style.display!="none"){
                event.returnValue=false;
                Next.focus();
                if (Next.type=="text") {
                }
            }
            else{
                      event.keyCode=9;
            }
            return ;
        }
        else {
            event.returnValue=false;
        }
    }
}
 //For ReleaseContainer 091021 zhiwei------------------------------------------------------------------------------------------------------
function CanSave()
{
var str ="";
 
return true;
 
}
function MustBeInput(e,objName,strAlert)
{
  var obj =document.getElementById(objName);
  if(obj.value!=""){return true;}
  else{
  e.returnValue=false;
  obj.focus();
  return false;
  }
}

</script>