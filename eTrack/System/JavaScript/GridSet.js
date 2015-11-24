<script language ="javascript" type="text/javascript">
//Update
function UpdateGridSet(sTableName,sFieldName,Field,obj)
{
    context = null;
    var arg="UpdateGridSet"+ParSeparator+sTableName+ParSeparator+sFieldName+ParSeparator+Field+ParSeparator+obj.value;
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "cbUpdateGridSet", "context")%>;
}
function cbUpdateGridSet(){}
function GetQuery(obj)
{
    var Field=$("#drpSearch").val();
    var value=$("#txtSearch").val();
    if(value!=""){
         strWhere = "and "+Field+"='"+value+"'";
       }
}
function GetValue()
{
    strDetail=document.getElementById("fldId").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtOrderDate").value;
    strDetail=strDetail+ColSeparator+document.getElementById("drpCustomerName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("drpContactName").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipperName").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipperAddress1").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipperAddress2").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipperAddress3").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipperAddress4").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsignessName").value;        
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsigneeAddress1").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsigneeAddress2").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsigneeAddress3").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsigneeAddress4").value;     
}
//Insert
function AddToFI()
{
  //var sFunNo =document.getElementById("txtsFunNo").value;
    //if(strReceiveDate.Trim()==""){ alert("sFunNo is mandatory."); return false ;}
   // strReceiveDate=ConvertDate(strReceiveDate);
    if (window.confirm("Are you sure to Add?")) 
    {
          var strTrxNo="";
          var strLineItemNo ="";
          var strContainerNo ="";

             var objGrid =document .getElementById("gvwSource")
             var strAll="";
              if(objGrid.rows.length>1)
              {
//                   for(var i=1;i<objGrid .rows.length-1;i++)
//                   {
                        tr = objGrid.rows[objGrid .rows.length-1];
                          if (tr.cells[0].hasChildNodes() && (tr.cells[0].childNodes[0].nodeType==1)) 
                          {
                          
                  if(validateTextBox("sFunNo",tr.cells[1].childNodes[0].value)==false)
                  {
                  return false;
                  }
                    if(validateTextBox("sParentNo",tr.cells[5].childNodes[0].value)==false)
                  {
                  return false;
                  }
                    if(validateTextBox("lType",tr.cells[6].childNodes[0].value)==false)
                  {
                  return false;
                  }
                    if(validateTextBox("UserFlag",tr.cells[7].childNodes[0].value)==false)
                  {
                  return false;
                  }
                             var strFields=tr.cells[1].childNodes[0].value+",";      //TrxNo
                             strFields+=tr.cells[2].childNodes[0].value+",";         //LineItemNo
                             strFields+=tr.cells[3].childNodes[0].value+",";        //ContainerNo
                             strFields+=tr.cells[4].childNodes[0].value+","; 
                             strFields+=tr.cells[5].childNodes[0].value +","; 
                             strFields+=tr.cells[6].childNodes[0].value +","; 
                             strFields+=tr.cells[7].childNodes[0].value                            //ReleasedDate
                             strFields+="#";                                         
                         }
                         strAll+=strFields;
                   //}
               if(strAll !="")
                {
                    context = document.getElementById("divSource");
                    var arg="InsertCTCE"+ParSeparator+strAll;
                    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetAddToFI", "context")%>;
                } 
              }
              else{}
    }
}
//------------------------------091029----------------------------------------------------------------------------
function SetAddToFI(result,context) 
{
    var strResult=result.split(ParSeparator);
            if (strResult[0]==RtnOk) {
                 
                //alert(strResult[1]);
              context.innerHTML = strResult[1];
               // window.location.reload(); 
                //window.close();
            }
            else if (strResult[1]!=""){
                //if(ReceiveBatchNo!=""){ReceiveBatchNo=strResult[2];}
                alert(strResult[1]);
               // window.location.reload(); 
               //window.close();
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
             document.getElementById(strResult[1]).value=strResult[2];
             document.getElementById(strResult[4]).value=strResult[5];
             alert(strResult[6]);//alert message
             document.getElementById(strResult[1]).focus();
//             document.getElementById(strResult[1]).focus();
//             document.getElementById(strResult[1]).value=strResult[2];
//             document.getElementById(strResult[4]).value=strResult[5];
            }
}


var ReceiveBatchNo="";
function EnterAddFI()
{
   if((event.keyCode==13)||(event.keyCode==0x28)||(event.keyCode==9)) 
   {
//        var strReceiveDate=document.getElementById("txtReceivedDate").value;
//        if(strReceiveDate.Trim()==""){ alert("Receive Date is mandatory."); return false ;}
//           strReceiveDate=ConvertDate(strReceiveDate);
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
                            //strFile+=" sFunNo='"+tr.cells[1].childNodes[0].value.replace(/,/g,"")+"'"
                           strFile+=" ,sFunName='"+tr.cells[2].childNodes[0].value.replace(/,/g,"")+"'"
                           strFile+=" ,sFunUrl='"+tr.cells[3].childNodes[0].value.replace(/,/g,"")+"'"
                           strFile+=" ,sImage='"+tr.cells[4].childNodes[0].value.replace(/,/g,"")+"'"
                           strFile+=" ,sParentNo='"+tr.cells[5].childNodes[0].value.replace(/,/g,"") +"'"
                           strFile+=" ,ltype="+tr.cells[6].childNodes[0].value.replace(/,/g,"")                       
                           //var drState=tr.cells[9].childNodes[1];
                          // var valState=drState.options[drState.selectedIndex].value;
                           strFile+=" ,UserFlag='"+tr.cells[7].childNodes[0].value.replace(/,/g,"")  +"'"
                          // var drContainerType=tr.cells[10].childNodes[2];
                          // var valContainerType=drContainerType.options[drContainerType.selectedIndex].value;
                           //if(strContainer.Trim()==""){alert("ContainerType is mandatory."); tr.cells[10].childNodes[0].focue; return false ;}
                          // strFile+=" ,ContainerType='"+valContainerType +"'"
                          // strFile=strFile+",ReceiveBatchNo";
                  
                  }
           }
           if(strFile.indexOf('undefined')<0)
           {
                var signFrame = document.getElementById("gvwSource");
                context = document.getElementById("divSource");
                var arg = "FISaveOne"+ParSeparator+strContainerNO+ParSeparator+strFile+ParSeparator+ReceiveBatchNo;
                <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetFISaveOne", "context")%>;  
           }
      }
}
//lzw090330
//function AddToFI()
//{
//        var blankFlag=0;
//        var strFile="";
//        var strContainerNO="";
//        if(ReceiveBatchNo==""){ReceiveBatchNo=document.getElementById("hidBatchNo").value;}
//        var signFrame = document.getElementById("gvwSource");
//      //  var strReceiveDate=document.getElementById("txtReceivedDate").value;
//        var tr;
//           if(signFrame.rows.length == 1){blankFlag+=1}
//           else if (signFrame.rows.length > 1)
//           { 
//                tr = signFrame.rows[signFrame.rows.length-1];
//                  if (tr.cells[1].hasChildNodes() && (tr.cells[1].childNodes[0].nodeType==1)) 
//                  {
//                     strContainerNO=tr.cells[1].childNodes[0].value.replace(/,/g,"")
//                     if(strContainerNO.Trim()==""){alert("Container NO is mandatory."); tr.cells[1].childNodes[0].focue; return false ;}//Container NO can not be null
//                           //strFile+=" sFunNo='"+tr.cells[1].childNodes[0].value.replace(/,/g,"")+"'"
//                           strFile+=" ,sFunName='"+tr.cells[2].childNodes[0].value.replace(/,/g,"")+"'"
//                           strFile+=" ,sFunUrl='"+tr.cells[3].childNodes[0].value.replace(/,/g,"")+"'"
//                           strFile+=" ,sImage='"+tr.cells[4].childNodes[0].value.replace(/,/g,"")+"'"
//                           strFile+=" ,sParentNo='"+tr.cells[5].childNodes[0].value.replace(/,/g,"") +"'"
//                           strFile+=" ,ltype="+tr.cells[6].childNodes[0].value.replace(/,/g,"")                       
//                           //var drState=tr.cells[9].childNodes[1];
//                          // var valState=drState.options[drState.selectedIndex].value;
//                           strFile+=" ,UserFlag='"+tr.cells[7].childNodes[0].value.replace(/,/g,"")  +"'"
//                          // var drContainerType=tr.cells[10].childNodes[2];
//                          // var valContainerType=drContainerType.options[drContainerType.selectedIndex].value;
//                           //if(strContainer.Trim()==""){alert("ContainerType is mandatory."); tr.cells[10].childNodes[0].focue; return false ;}
//                          // strFile+=" ,ContainerType='"+valContainerType +"'"
//                          // strFile=strFile+",ReceiveBatchNo";
//                  }
//           }
//           if(strFile.indexOf('undefined')<0)
//           {
//                var signFrame = document.getElementById("gvwSource");
//                context = document.getElementById("divSource");
//                var arg = "FISaveOne"+ParSeparator+strContainerNO+ParSeparator+strFile+ParSeparator+ReceiveBatchNo;
//                <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetFISaveOne", "context")%>;  
//           }
//}
function SetFISaveOne(result,context) 
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
 
function DeleteFI(intId,lineitem)
{
            if (window.confirm("Are you sure to delete this record?")) 
            {
                context = document.getElementById("divSource");
                var arg = "DeleteFI"+ParSeparator+intId.toString()+ParSeparator+lineitem.toString();
                <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetDeleteFI", "context")%>;
            }
}
function SetDeleteFI(result,context) 
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
  
function validateTextBox(FieldName,insertstr)
{
   var res="";
       if(FieldName=="sFunNo" | FieldName=="sParentNo" | FieldName=="lType")
       {
       res= validate(insertstr,"int");
       }
       else if(FieldName=="UserFlag")
       {
         res= validate(insertstr,"bit");
       }
       
       if(res!="")
       {
       alert(FieldName+" "+res);
       return false;
       }
       else{
       return true;
       }
}
function validate(str,type)
{
var regex="";
var info="";
if(type=="int")
{
regex=/\d+/;
info="only allow number";
}
else if(type=="bit")
{
regex=/(0|1)+/;
info='only allow 0 or 1';
}
str=str.replace(regex,"")
if(str=="")
{
return "";}
else
{
return info;
}
}
function SetOtherSaveReturn(strResult)
{
    if(strResult.length==4){
        document.getElementById("divAttach").innerHTML=strResult[2];
        document.getElementById("fldId").value=strResult[3];
    }
}
 
function CanSave()
{
var str ="";
 
return true;
}
</script>