<script language ="javascript" type="text/javascript">
function RceiveContainer()
{
   var strReceiveDate =document.getElementById("txtReceivedDate").value;
    if(strReceiveDate.Trim()==""){ alert("Receive Date is mandatory."); return false ;}
    strReceiveDate=ConvertDate(strReceiveDate);
    if (window.confirm("Are you sure to Receive container?")) 
    {
          var strTrxNo="";
          var strLineItemNo ="";
          var strContainerNo ="";

             var objGrid =document .getElementById("gvwSource")
             var strAll="";
              if(objGrid.rows.length>1)
              {
                   for(var i=1;i<objGrid .rows.length-1;i++)
                   {
                        tr = objGrid.rows[i];
                          if (tr.cells[0].hasChildNodes() && (tr.cells[0].childNodes[0].nodeType==1)) 
                          {
                             var strFields=tr.cells[1].childNodes[4].value+",";      //TrxNo
                             strFields+=tr.cells[1].childNodes[6].value+",";         //LineItemNo
                             strFields+=tr.cells[1].childNodes[0].value+",";        //ContainerNo
                             strFields+=strReceiveDate;                              //ReleasedDate
                             strFields+="#";                                         
                         }
                         strAll+=strFields;
                   }
               if(strAll !="")
                {
                    context = document.getElementById("divSource");
                    var arg="InsertCTCE"+ParSeparator+strAll;
                    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReleaseContainer", "context")%>;
                } 
              }
              else{alert('Please add the Receive container.');}
    }
}
//------------------------------091029----------------------------------------------------------------------------
function SetReleaseContainer(result,context) 
{
    var strResult=result.split(ParSeparator);
            if (strResult[0]==RtnOk) {
                
                alert(strResult[1]);
                window.close();
            }
            else if (strResult[1]!=""){
                //if(ReceiveBatchNo!=""){ReceiveBatchNo=strResult[2];}
                alert(strResult[1]);
                window.close();
            }
}


//-----------------------------------------------------------------------------------------------
function DropDownUpdate(obj,sField)
{
 var strValue =obj.options[obj.selectedIndex].value;
 var tr=obj.parentNode.parentNode;
 if (tr.cells[0].hasChildNodes() && (tr.cells[0].childNodes[0].nodeType==1)) 
 {
  var strTrxNo=tr.cells[1].childNodes[4].value;      //TrxNo
  var strLineItemNo=tr.cells[1].childNodes[6].value;         //LineItemNo
  context = document.getElementById("divSource");
  var arg="DropDownUpdate"+ParSeparator+strTrxNo+ParSeparator+strLineItemNo+ParSeparator+strValue+ParSeparator+sField;
  <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetDropDownUpdate", "context")%>;
 }
}
//---------------------------------------------------------------------------------------------------
function SetDropDownUpdate(result,context)
{
    var strResult=result.split(ParSeparator);
            if (strResult[0]==RtnOk) {
            }
            else
            {
             alert(strResult[1]);
            }
}
//---------------------------------------------------------------------------------------------------

function CheckContainerNo(event,objContainerNo,SenondCon,objPOL,UpperFlag)
{ 
   if((event.keyCode==13)||(event.keyCode==0x28)||(event.keyCode==9)) 
   {
     var strReceiveDate =document.getElementById("txtReceivedDate").value;
     var strContaienrNo= objContainerNo.value;
     if(strContaienrNo.Trim()==""){alert("Container No is mandatory.");return false ;}
     if(UpperFlag=="y"){strContaienrNo=strContaienrNo.toUpperCase();objContainerNo.value=strContaienrNo;}
         context = document.getElementById("divSource");
         var arg="CheckContainerNo"+ParSeparator+strContaienrNo+ParSeparator+SenondCon.id+ParSeparator+objContainerNo.id+ParSeparator+objPOL.id+ParSeparator+strReceiveDate;
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetContainerNo", "context")%>;   
   }
}
function SetContainerNo(result,context) 
{
    var strResult=result.split(ParSeparator);
            if (strResult[0].toLowerCase()=="1") {
               alert(strResult[2]);
            }
            else
            {
             document.getElementById(strResult[1]).focus();
             document.getElementById(strResult[1]).value=strResult[2];
             document.getElementById(strResult[4]).value=strResult[5];
            }
}
var ReceiveBatchNo="";
function EnterAddCtso2()
{
   if((event.keyCode==13)||(event.keyCode==0x28)||(event.keyCode==9)) 
   {
        var strReceiveDate=document.getElementById("txtReceivedDate").value;
        if(strReceiveDate.Trim()==""){ alert("Receive Date is mandatory."); return false ;}
           strReceiveDate=ConvertDate(strReceiveDate);
        var blankFlag=0;
        var strFile="";
        var strContainerNO="";
        if(ReceiveBatchNo==""){ReceiveBatchNo=document.getElementById("hidBatchNo").value;}
        var signFrame = document.getElementById("gvwSource");
        var tr;
           if(signFrame.rows.length == 1){blankFlag+=1}
           else if (signFrame.rows.length > 1)
           { 
                tr = signFrame.rows[signFrame.rows.length-1];
                  if (tr.cells[1].hasChildNodes() && (tr.cells[1].childNodes[0].nodeType==1)) 
                  {
                     strContainerNO=tr.cells[1].childNodes[0].value.replace(/,/g,"");
                     if(strContainerNO.Trim()==""){alert("Container NO is mandatory."); tr.cells[1].childNodes[0].focue; return false ;}//Container NO can not be null
                           //check mentory
                           if(tr.cells[3].childNodes[0].value==""){ alert("TruckerName is mandatory.");tr.cells[3].childNodes[0].focus(); return false ;}
                           if(tr.cells[4].childNodes[0].value==""){ alert("VehicleNo is mandatory.");tr.cells[4].childNodes[0].focus(); return false ;}
                           strFile+=" TruckerName='"+tr.cells[3].childNodes[0].value.replace(/,/g,"")+"'";
                           strFile+=" ,VehicleNo='"+tr.cells[4].childNodes[0].value.replace(/,/g,"")+"'";
                           strFile+=" ,CollectionRemarks='"+tr.cells[5].childNodes[0].value.replace(/,/g,"")+"'";
                           strFile+=" ,SurveyRemarks='"+tr.cells[6].childNodes[0].value.replace(/,/g,"")+"'";
                           strFile+=" ,ActualDetentionCharge="+tr.cells[7].childNodes[0].value.replace(/,/g,"");
                           strFile+=" ,ComputedDetentionCharge="+tr.cells[8].childNodes[0].value.replace(/,/g,"");
                           strFile+=" ,ReceiveDate='"+strReceiveDate+"'";
                           var drState=tr.cells[9].childNodes[1];
                           var valState=drState.options[drState.selectedIndex].value;
                           strFile+=" ,State='"+valState+"'";
                           var drContainerType=tr.cells[10].childNodes[2];
                           var valContainerType=drContainerType.options[drContainerType.selectedIndex].value;
                           //if(strContainer.Trim()==""){alert("ContainerType is mandatory."); tr.cells[10].childNodes[0].focue; return false ;}
                           strFile+=" ,ContainerType='"+valContainerType +"'";
                           strFile=strFile+",ReceiveBatchNo";
                  }
           }
           if(strFile.indexOf('undefined')<0)
           {
                var signFrame = document.getElementById("gvwSource");
                context = document.getElementById("divSource");
                var arg = "SO2SaveOne"+ParSeparator+strContainerNO+ParSeparator+strFile+ParSeparator+ReceiveBatchNo;
                <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetSO2SaveOne", "context")%>;  
           }
      }
}
////lzw090330
//function AddToSO2()
//{
//        var blankFlag=0;
//        var strFile="";
//        var strContainerNO="";
//        if(ReceiveBatchNo==""){ReceiveBatchNo=document.getElementById("hidBatchNo").value;}
//        var signFrame = document.getElementById("gvwSource");
//        var strReceiveDate=document.getElementById("txtReceivedDate").value;
//        var tr;
//           if(signFrame.rows.length == 1){blankFlag+=1}
//           else if (signFrame.rows.length > 1)
//           { 
//                tr = signFrame.rows[signFrame.rows.length-1];
//                  if (tr.cells[1].hasChildNodes() && (tr.cells[1].childNodes[0].nodeType==1)) 
//                  {
//                     strContainerNO=tr.cells[1].childNodes[0].value.replace(/,/g,"")
//                     if(strContainerNO.Trim()==""){alert("Container NO is mandatory."); tr.cells[1].childNodes[0].focue; return false ;}//Container NO can not be null
//                           strFile+=" sFunNo='"+tr.cells[3].childNodes[0].value.replace(/,/g,"")+"'"
//                           strFile+=" ,sFunName='"+tr.cells[4].childNodes[0].value.replace(/,/g,"")+"'"
//                           strFile+=" ,sFunUrl='"+tr.cells[5].childNodes[0].value.replace(/,/g,"")+"'"
//                           strFile+=" ,sImage='"+tr.cells[6].childNodes[0].value.replace(/,/g,"")+"'"
//                           strFile+=" ,sParentNo="+tr.cells[7].childNodes[0].value.replace(/,/g,"")  +"'"
//                           strFile+=" ,ltype="+tr.cells[8].childNodes[0].value.replace(/,/g,"")   +"'"                      
////                           var drState=tr.cells[9].childNodes[1];
////                           var valState=drState.options[drState.selectedIndex].value;
////                           strFile+=" ,State='"+valState+"'"
////                           var drContainerType=tr.cells[10].childNodes[2];
//                          // var valContainerType=drContainerType.options[drContainerType.selectedIndex].value;
//                           //if(strContainer.Trim()==""){alert("ContainerType is mandatory."); tr.cells[10].childNodes[0].focue; return false ;}
//                          strFile+=" ,UserFlag='"+tr.cells[9].childNodes[0].value.replace(/,/g,"")
//                          // strFile=strFile+",ReceiveBatchNo";
//                  }
//           }
//           if(strFile.indexOf('undefined')<0)
//           {
//                var signFrame = document.getElementById("gvwSource");
//                context = document.getElementById("divSource");
//                var arg = "SO2SaveOne"+ParSeparator+strContainerNO+ParSeparator+strFile+ParSeparator+ReceiveBatchNo;
//                <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetSO2SaveOne", "context")%>;  
//           }
//}
//lzw090330
function AddToSO2()
{
        var blankFlag=0;
        var strFile="";
        var strContainerNO="";
        if(ReceiveBatchNo==""){ReceiveBatchNo=document.getElementById("hidBatchNo").value;}
        var signFrame = document.getElementById("gvwSource");
        var strReceiveDate=document.getElementById("txtReceivedDate").value;
        var tr;
           if(signFrame.rows.length == 1){blankFlag+=1}
           else if (signFrame.rows.length > 1)
           { 
                tr = signFrame.rows[signFrame.rows.length-1];
                  if (tr.cells[1].hasChildNodes() && (tr.cells[1].childNodes[0].nodeType==1)) 
                  {
                     strContainerNO=tr.cells[1].childNodes[0].value.replace(/,/g,"")
                     if(strContainerNO.Trim()==""){alert("Container NO is mandatory."); tr.cells[1].childNodes[0].focue; return false ;}//Container NO can not be null
                           strFile+=" TruckerName='"+tr.cells[3].childNodes[0].value.replace(/,/g,"")+"'"
                           strFile+=" ,VehicleNo='"+tr.cells[4].childNodes[0].value.replace(/,/g,"")+"'"
                           strFile+=" ,CollectionRemarks='"+tr.cells[5].childNodes[0].value.replace(/,/g,"")+"'"
                           strFile+=" ,SurveyRemarks='"+tr.cells[6].childNodes[0].value.replace(/,/g,"")+"'"
                           strFile+=" ,ActualDetentionCharge="+tr.cells[7].childNodes[0].value.replace(/,/g,"")
                           strFile+=" ,ComputedDetentionCharge="+tr.cells[8].childNodes[0].value.replace(/,/g,"")                       
                           var drState=tr.cells[9].childNodes[1];
                           var valState=drState.options[drState.selectedIndex].value;
                           strFile+=" ,State='"+valState+"'"
                           var drContainerType=tr.cells[10].childNodes[2];
                           var valContainerType=drContainerType.options[drContainerType.selectedIndex].value;
                           //if(strContainer.Trim()==""){alert("ContainerType is mandatory."); tr.cells[10].childNodes[0].focue; return false ;}
                           strFile+=" ,ContainerType='"+valContainerType +"'"
                           strFile=strFile+",ReceiveBatchNo";
                  }
           }
           if(strFile.indexOf('undefined')<0)
           {
                var signFrame = document.getElementById("gvwSource");
                context = document.getElementById("divSource");
                var arg = "SO2SaveOne"+ParSeparator+strContainerNO+ParSeparator+strFile+ParSeparator+ReceiveBatchNo;
                <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetSO2SaveOne", "context")%>;  
           }
}
function SetSO2SaveOne(result,context) 
{
    var strResult=result.split(ParSeparator);
    switch(strResult.length) {
        case 3:
            if (strResult[0]==RtnOk) { context.innerHTML = strResult[1];
                    if(ReceiveBatchNo==""){ReceiveBatchNo=strResult[2];}
            }
            else{alert(strResult[1]);}
            break;
        default:
            break;
    }
}

       function SetUpdateCTRO2(result,context) 
       {
            var strResult=result.split(ParSeparator);
            switch(strResult.length) {
                case 4:
                    if (strResult[0]==RtnOk) { 
                    }
                    else
                    {
                      alert(strResult[1]);
                      if(result.indexOf("Container NO")>0)
                      {
                        document.getElementById(strResult[2]).value=strResult[3];
                        document.getElementById(strResult[2]).focus();
                      }
                      //e.returnValue=false;
                      return false ;
                    }
                    break;
                default:
                    break;
            }
       }
       //UpdteValue-Onfocus
       function UpdateValue(TrxNo,LineItemNo,FieldName,conField,ContainerNo)
       {
        var valField="";
        if(FieldName=='ActualDetentionCharge'){
        valField= conField.value.replace("'","''");
        if(valField==""){valField=0;}
        }
        else{valField="'"+conField.value.replace("'","''")+"'";}
        var strslq=" update ctso2 set "+FieldName+"="+valField+" where TrxNo="+TrxNo+" and LineItemNo="+LineItemNo;
        context = document.getElementById("divSource");
        var arg = "CTSO2Update"+ParSeparator+strslq+ParSeparator+TrxNo+ParSeparator+LineItemNo+ParSeparator+ContainerNo+ParSeparator+conField.id+ParSeparator+valField;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetUpdateCTRO2", "context")%>;
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

//-----------------------------------------------------------------------------------------------

function CheckContainerNoUpdate(intId,lineitem,objCon)
{
    var strContainerNo = document.getElementById(objCon).value;
    if (strContainerNo!="") {
        var arg="CheckContainerNoUpdate"+ParSeparator+intId+ParSeparator+lineitem+ParSeparator+strContainerNo;
        context=objCon;
        <%= ClientScript.GetCallbackEventReference(Me,"arg","setCheckContainerNo","context") %>;
    }
}

function DeleteCTSO2(intId,lineitem)
{
            if (window.confirm("Are you sure to delete this record?")) 
            {
                context = document.getElementById("divSource");
                var arg = "DeleteCTSO2"+ParSeparator+intId.toString()+ParSeparator+lineitem.toString();
                <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetDeleteCTSO2", "context")%>;
            }
}
function SetDeleteCTSO2(result,context) 
{ 
    var strResult=result.split(ParSeparator);
            if (strResult[0]==RtnOk) {
                context.innerHTML = strResult[1];
            }
            else if (strResult[1]!=""){
            }
}

function ReturntheValue(result,context)
{
        window.alert(result);
        window.close(); 
} 

function CanConfirmSave()
{
    return true;
}

function GetDetail()
{

}
  
function NewDetail(intFlag)
{

}

function BeforeSave()
{
    document.getElementById("btnSave").disabled=true;
    document.getElementById("btnClose").disabled=true;
}
function AfterSave()
{

}

function AddSelectedAttach()
{
    var strId=document.getElementById("fldId").value;
    var ret=WindowDialog("../SysRef/AttachEdit.aspx?Id="+strId+"&Folder=omtx1",640,450);
    if(ret!=null && ret!=""){
        context = document.getElementById("divAttach");
        var arg = "AddSelectedAttach"+ParSeparator+ret; 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function DeleteOneAttach(strFileName)
{
    var strId=document.getElementById("fldId").value;
    if (window.confirm("Are you sure to delete current select attachment?")) {
        context = document.getElementById("divAttach");
        var arg = "DeleteOneAttach"+ParSeparator+strId+ParSeparator+strFileName;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}
function SetOtherSaveReturn(strResult)
{
    if(strResult.length==4){
        document.getElementById("divAttach").innerHTML=strResult[2];
        document.getElementById("fldId").value=strResult[3];
    }
}

function MultiSelectPerson(txtSelect)
{

    var ret=WindowDialog("../SysRef/MultiPersonList.aspx?Id=",<%=SysMagic.SystemClass.InfoListSize.Width%>,<%=SysMagic.SystemClass.InfoListSize.Height%>);

    if(ret!=null) {
        txtSelect.value=ret[1];
    }
}

function CanSave()
{
var str ="";
 
return true;
}

function FocusControlSO(event,Prev,Next)//091016
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


</script>