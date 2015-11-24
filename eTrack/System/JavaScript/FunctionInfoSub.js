<script language ="javascript" type="text/javascript">
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
                          
                  if(validateTextBox("sFunNo",tr.cells[1].childNodes[0+ChildSpl].value)==false)
                  {
                  return false;
                  }
//                    if(validateTextBox("sParentNo",tr.cells[5].childNodes[0+ChildSpl].value)==false)
//                  {
//                  return false;
//                  }
                    if(validateTextBox("bFlag",tr.cells[6].childNodes[0+ChildSpl].value)==false)
                  {
                  return false;
                  }
//                    if(validateTextBox("UserFlag",tr.cells[7].childNodes[0+ChildSpl].value)==false)
//                  {
//                  return false;
//                  }
                             var strFields=tr.cells[1].childNodes[0+ChildSpl].value+",";      //TrxNo
                             strFields+=tr.cells[2].childNodes[0+ChildSpl].value+",";         //LineItemNo
                             strFields+=tr.cells[3].childNodes[0+ChildSpl].value+",";        //ContainerNo
                             strFields+=tr.cells[4].childNodes[0+ChildSpl].value+","; 
                             strFields+=tr.cells[5].childNodes[0+ChildSpl].value +","; 
                             strFields+=tr.cells[6].childNodes[0+ChildSpl].value +""; 
                             strFields+="#";                                         
                         }
                         strAll+=strFields;
                   //}
               if(strAll !="")
                {
                    context = document.getElementById("divSource");
                    var arg="InsertFIS"+ParSeparator+strAll;
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

//function CheckContainerNo(event,objContainerNo,SenondCon,objPOL,UpperFlag)
//{ 
//   if((event.keyCode==13)||(event.keyCode==0x28)||(event.keyCode==9)) 
//   {
//     var strReceiveDate =document.getElementById("txtReceivedDate").value;
//     var strContaienrNo= objContainerNo.value;
//     if(strContaienrNo.Trim()==""){alert("Container No is mandatory.");return false ;}
//     if(UpperFlag=="y"){strContaienrNo=strContaienrNo.toUpperCase();objContainerNo.value=strContaienrNo;}
//         context = document.getElementById("divSource");
//         var arg="CheckContainerNo"+ParSeparator+strContaienrNo+ParSeparator+SenondCon.id+ParSeparator+objContainerNo.id+ParSeparator+objPOL.id+ParSeparator+strReceiveDate;
//    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetContainerNo", "context")%>;   
//   }
//}
//function SetContainerNo(result,context) 
//{
//    var strResult=result.split(ParSeparator);
//            if (strResult[0].toLowerCase()=="1") {
//               alert(strResult[2]);
//            }
//            else
//            {
//             document.getElementById(strResult[1]).value=strResult[2];
//             document.getElementById(strResult[4]).value=strResult[5];
//             alert(strResult[6]);//alert message
//             document.getElementById(strResult[1]).focus();
////             document.getElementById(strResult[1]).focus();
////             document.getElementById(strResult[1]).value=strResult[2];
////             document.getElementById(strResult[4]).value=strResult[5];
//            }
//}


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
        var strsFunNo="";
        var signFrame = document.getElementById("gvwSource");
        var tr;
           if(signFrame.rows.length == 1){blankFlag+=1}
           else if (signFrame.rows.length > 1)
           { 
                tr = signFrame.rows[signFrame.rows.length-1];
                  if (tr.cells[1].hasChildNodes() && (tr.cells[1].childNodes[0].nodeType==1)) 
                  {
                     strsFunNo=tr.cells[1].childNodes[0].value.replace(/,/g,"");
                     if(strsFunNo.Trim()==""){alert("Fun NO is mandatory."); tr.cells[1].childNodes[0].focue; return false ;}//Container NO can not be null
                            //strFile+=" sFunNo='"+tr.cells[1].childNodes[0].value.replace(/,/g,"")+"'"
                           strFile+=" ,lSubId='"+tr.cells[2].childNodes[0].value.replace(/,/g,"")+"'"
                           strFile+=" ,sCode='"+tr.cells[3].childNodes[0].value.replace(/,/g,"")+"'"
                           strFile+=" ,sName='"+tr.cells[4].childNodes[0].value.replace(/,/g,"")+"'"
                           strFile+=" ,bFlag='"+tr.cells[5].childNodes[0].value.replace(/,/g,"") +"'"
                           strFile+=" ,SubType='"+tr.cells[6].childNodes[0].value.replace(/,/g,"") +"'"  
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

       function SetUpdateFI(result,context) 
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
       function UpdateValue(sFunNo,lSubId,FieldName,conField)
       {
        var valField="";
        if(FieldName=='ActualDetentionCharge'){
        valField= conField.value.replace("'","''");
        if(valField==""){valField=0;}
        } 
        else{valField="'"+conField.value.replace("'","''")+"'";}
       var res="";
       if(FieldName=="sFunNo" | FieldName=="sParentNo" | FieldName=="lType")
       {
       res= validate(conField.value.replace("'","''"),"int");
       }
       else if(FieldName=="UserFlag")
       {
         res= validate(conField.value.replace("'","''"),"bit");
       }
       
       if(res!="")
       {
       alert(FieldName+" "+res);
       return false;
       }
        var strslq=FieldName+"="+valField+"";
        context = document.getElementById("divSource");
        var arg = "FIUpdate"+ParSeparator+strslq+ParSeparator+sFunNo+ParSeparator+lSubId+ParSeparator+conField.id+ParSeparator+valField;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetUpdateFI", "context")%>;
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
regex=/(y|n)+/;
info='only allow Y or N';
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
                 try{Next.focus();}
                 catch(err){}
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