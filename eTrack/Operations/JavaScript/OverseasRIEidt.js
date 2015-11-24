<script language ="javascript" type="text/javascript">
function showCancel() 
{  
    //txtJobNo 
    var obj=document.getElementById("txtJobNo");
    obj.value="";
    //txtVesselName
    obj=document.getElementById("txtVesselName");
    obj.value="";
    //txtVoyageNo
    obj=document.getElementById("txtVoyageNo");
    obj.value="";
    //txtETA
    obj=document.getElementById("txtETA");
    obj.value="";
    //txtPortOfDischarge
    obj=document.getElementById("txtPortOfDischarge");
    obj.value="";
    //txtReleaseDate
    obj=document.getElementById("txtReleaseDate");
    obj.value="";    
    context = document.getElementById("divSource");
    UpdateFlag="N";
    strRIN='';
    strRON='';
    RegTrxNo='-1'
    document.getElementById("divTitle").innerHTML="";
    intPage=1;
    strWhere=" and 1!=1 "
    var arg = "CancleFun"+ParSeparator+""; 
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetQueryData", "context")%>; 
} 
function SetQueryData(result,context) 
{
    var strResult=result.split(ParSeparator);
    if (strResult[0]==RtnOk) {context.innerHTML=strResult[1];}
    else if (strResult[1]!=""){}
} 
function CreateEvent()
{
   var strReleaseDate =document.getElementById("txtReleaseDate").value;
    strReleaseDate=ConvertDate(strReleaseDate);
    if(strReleaseDate.Trim()==""){ alert("Release Date must be input!"); return false ;}
    if (window.confirm("Are you sure to release container?")) 
    {
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
                             var strFields=tr.cells[1].childNodes[1].value+",";      //TrxNo
                                 strFields+=tr.cells[1].childNodes[2].value+",";         //LineItemNo
                                 strFields+=tr.cells[1].childNodes[0].value+",";        //ContainerNo
                                 strFields+=strReleaseDate;                              //ReleasedDate
                                 strFields+="#";
                                 strAll+=strFields;
                         }
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
                context.innerHTML=strResult[1];
                alert("Release success ");
                window.close();
            }
            else if (strResult[1]!=""){
             alert(strResult[1]);
             window.close();
            }
}
function UpdateCTRO2(TrxNo,Lineitemno,OldValue,conContainer)
{
     var UpdteValue=document.getElementById(conContainer).value;
     if(OldValue==UpdteValue || OldValue.Trim()=="")
     {
      document.getElementById(conContainer).value=OldValue;
      return false;
     }
     if(TrxNo!="" && Lineitemno!="")
     {
      var strslq=" update ctro2 set ContainerNo='"+UpdteValue+"' where TrxNo="+TrxNo+" and LineItemNo="+Lineitemno;
      context = document.getElementById("divSource");
      var arg = "CTRO2Update"+ParSeparator+strslq+ParSeparator+TrxNo+ParSeparator+Lineitemno+ParSeparator+conContainer+ParSeparator+UpdteValue+ParSeparator+OldValue;
      <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetUpdateCTRO2", "context")%>;
     }
 }
 function SetUpdateCTRO2(result,context) 
{
    var strResult=result.split(ParSeparator);
    switch(strResult.length) {
        case 4:
            if (strResult[0]==RtnOk) {
              context.innerHTML = strResult[1];
             }
            else{
                 alert(strResult[1]);
                 document.getElementById(strResult[2]).value=strResult[3];
                 document.getElementById(strResult[2]).focus();
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
function AddToRO2()
{
        if(RegTrxNo=="-1"){alert("Releasing Instruction Info Must be input First.");return false;}
        var strContainerNO="";
        var signFrame = document.getElementById("gvwSource");
//        var strReceivedDate=ConvertDate(document.getElementById("txtReleaseDate").value);
//        if(strReceivedDate.Trim()==""){alert("Release Date must be input.");return false;}
        var tr;
           if(signFrame.rows.length<=1){return false;}
           if (signFrame.rows.length > 1)
           { 
             tr = signFrame.rows[signFrame.rows.length-1];
             if (tr.cells[1].hasChildNodes() && (tr.cells[1].childNodes[0].nodeType==1)) 
             {strContainerNO=tr.cells[1].childNodes[0].value.replace(/,/g,"")}
           }
     if(strContainerNO.Trim()==""){return false;}
     context =document .getElementById("divSource");
     var arg="SaveCtro2"+ParSeparator+strContainerNO+ParSeparator+RegTrxNo;
     <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetOverseasReturn", "context")%>;    
}
function DeleteCTRO2(intId,lineitem,ContainerNo)
{
    if (window.confirm("Are you sure to delete this record?")) 
    {
        context = document.getElementById("divSource");
        var arg = "DeleteCTRO2"+ParSeparator+intId+ParSeparator+lineitem+ParSeparator+ContainerNo;
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
function FocusSave(event,title) //Onfocus
{
  if(!CanSave()){return false;};
  if(UpdateFlag=="Y")
  {
    context = null;
    var arg="SaveRIDetail"+ParSeparator+GetDetail()+ParSeparator+strRIN+ParSeparator+strRON;
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetFocusSave", "context")%>;     
    UpdateFlag='N';
  }
}
function SetFocusSave(result,context) 
{ 
    var strResult=result.split(ParSeparator);
            if (strResult[0]==RtnOk) {
                  strRIN=strResult[2];
                  strRON=strResult[3];
                  RegTrxNo=strResult[4];
                    var str="<span  class='f12e navNml navOn' style='display:inline-block;width:300px;'>Overseas Releasing Instruction : "+strResult[2]+"</span>"
                  document.getElementById("divTitle").innerHTML=str;
            }
            window.alert(strResult[1]);
}
function SaveCtro2(event,title) //Onfocus
{
  if((event.keyCode==13)||(event.keyCode==0x28))
   {
        if(RegTrxNo=="-1"){alert("Releasing Instruction Info Must be input First.");return false;}
        var strContainerNO="";
        var signFrame = document.getElementById("gvwSource");
//        var strReceivedDate=ConvertDate(document.getElementById("txtReleaseDate").value);
//        if(strReceivedDate.Trim()==""){alert("Release Date must be input.");return false;}
        var tr;
           if(signFrame.rows.length<=1){return false;}
           if (signFrame.rows.length > 1)
           { 
             tr = signFrame.rows[signFrame.rows.length-1];
             if (tr.cells[1].hasChildNodes() && (tr.cells[1].childNodes[0].nodeType==1)) 
             {strContainerNO=tr.cells[1].childNodes[0].value.replace(/,/g,"")}
           }
   }
   else{return false;}
   if(strContainerNO.Trim()==""){return false;}
     context =document .getElementById("divSource");
     var arg="SaveCtro2"+ParSeparator+strContainerNO+ParSeparator+RegTrxNo;
     <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetOverseasReturn", "context")%>;     
}

function SetOverseasReturn(result,context) 
{ 
    var strResult=result.split(ParSeparator);
    switch(strResult.length) {
        case 2:
            if (strResult[0]==RtnOk) { context.innerHTML = strResult[1];
                    var signFrame = document.getElementById("gvwSource");
                    var tr;
                       if (signFrame.rows.length > 1)
                       { 
                            tr = signFrame.rows[signFrame.rows.length-1];
                              if (tr.cells[1].hasChildNodes() && (tr.cells[1].childNodes[0].nodeType==1)) 
                              {
                                 tr.cells[1].childNodes[0].focus();
                             }
                       }
            }
            else{alert(strResult[1]);}
            break;
        case 3:
            if (strResult[0]==RtnOk) {
                context.innerHTML = strResult[1];
                if (strResult[2].length <= 6){
                  document.getElementById("hidTrxNo").value=strResult[2];
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
        case 5: //ReleasingInfo Input
            if (strResult[0]==RtnOk) {
                  strRIN=strResult[2];
                  strRON=strResult[3];
                  RegTrxNo=strResult[4];
            }
            else if (strResult[1]!=""){
                window.alert(strResult[1]);
            }
            break;
        default:
            break;
    }
}

function selBindCode(objCode,table,fields,where,showCode,showName)
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
     }
    }
}
//-------------------------------------------------------------------------------------------------
function GetDetail()
{
    var strDetail="";
    strDetail=RegTrxNo;
    strDetail=strDetail+ColSeparator+document.getElementById("txtOrganization").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtJobNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtVesselName").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtVoyageNo").value;
    strDetail=strDetail+ColSeparator+ConvertDate(document.getElementById("txtETA").value);
    strDetail=strDetail+ColSeparator+document.getElementById("txtPortOfDischarge").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtReleaseDate").value;
    return strDetail;
    //return strDetail;
}
  
function NewDetail(intFlag)
{
  if(intFlag!=0){
    var strDetail="";
    document.getElementById("txtOrganization").value=0;
    document.getElementById("txtJobNo").value="";
    document.getElementById("txtVesselName").value="";
    document.getElementById("txtVoyageNo").value="";
    document.getElementById("txtETA").value="";
    document.getElementById("txtPortOfDischarge").selectedIndex=0;
    document.getElementById("txtReleaseDate").value="";
    //return strDetail;
   }
}
function selBindContactName(txtName,table,fields,where,showCode,showName)
{
    var ret=WindowDialog("../SysRef/TypeSort.aspx?table="+table+"&fields="+fields+"&where="+where+"&showCode="+showCode+"&showName="+showName,<%=SysMagic.SystemClass.InfoListSize.Width%>,<%=SysMagic.SystemClass.InfoListSize.Height%>);
    if(ret!=null) 
    {
     var strRel=ret.split(ColSeparator);
     if (strRel.length==2) 
     { 
         context=document.getElementById("div_drop");
        var txt=strRel[1].Trim()=="&nbsp;"?" ":strRel[1];
        txtName.value=txt;
     }
    }
}    

function CanSave()
{
 //drOrganization
  var txt =document.getElementById('txtOrganization')
  if (txt.value=="")
  {
    window.alert("Organization Code  must exit!");
    txt.focus();
    return false;
  }
  //txtMasterJobNo
  var txt =document.getElementById('txtJobNo')
  if (txt.value.Rtrim()=="")
  {
    window.alert("Master Job No must be input!");
    txt.focus();
    return false;
  }  
  return true;
}
//-------------------------------BaseList------------------------------------------
function InsertDetail()
{
    var strTitle=document .getElementById("HidTitle").value;
    if (window.confirm(ConfirmSave.replace("{0}",strTitle))) 
    {
        if (!CanSave()) { return;}
        context=document.getElementById("divTrxNo");
        BeforeSave();
        var arg = "SaveData"+ParSeparator+GetDetail();
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "OpInsertDetail", "context")%>;
    }
}
function OpInsertDetail(result,context)
{
    strResult=result.split(ParSeparator);
    if (strResult.length==4) {
        switch(strResult[0])
        {
            case "1":
                AfterSave(); 
                strRIN=strResult[3];
                context.innerHTML=strResult[2];
                var strTrxNo=document.getElementById("hidTrxNo").value;
                if(RegTrxNo='-1'){RegTrxNo=strTrxNo;}
                var ret=WindowDialog(EditPage+"?RIN="+strRIN+"&TrxNo="+RegTrxNo,EditWidth,EditHeight);
                strWhere=" and TrxNo="+RegTrxNo;
                if (ret==RtnOk) {GetPageData(null,-1)}
            default:
                break;
        }
        }
}
function EditDetail(intId,ContainerList,strRIN,strTrxNo)
{
    var ret;
    if (EditPage.indexOf(".aspx?")>0){
        ret=WindowDialog(EditPage+"&Id="+intId.toString()+"&ContainerList="+ContainerList+"&RIN="+strRIN+"&TrxNo="+strTrxNo,EditWidth,EditHeight);
    }
    else{
        ret=WindowDialog(EditPage+"?Id="+intId.toString()+"&ContainerList="+ContainerList+"&RIN="+strRIN+"&TrxNo="+strTrxNo,EditWidth,EditHeight);
    }
    if (ret==RtnOk) {
        GetPageData(null,-1)
    }
}

function DeleteDetail(intId)
{
    if (!StrToBool(DeletePrompt) || window.confirm(ConfirmDelete)) {
        context=divSource;
        var arg = "DeleteOneData"+ParSeparator+intId.toString()+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString();
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function UndeleteDetail(intId)
{
    if (window.confirm(ConfirmRestore)) {
        context=divSource;
        var arg = "UndeleteOneData"+ParSeparator+intId.toString()+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString();
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function SetReturnValue(result,context)
{
    strResult=result.split(ParSeparator);
    if (strResult.length==4) {
        switch(strResult[0])
        {
            case RtnOk:
                intCount=strResult[2];
                if(intPage>intCount && intPage!=1){
                    intPage=intCount;
                }
                context.innerHTML = strResult[3]; 
                var lbl=document.getElementById("lblPage");
                lbl.innerHTML = PageTitle + intPage.toString() + PageSeparator + intCount.toString();
                var txt=document.getElementById("txtPage");
                txt.value=intPage.toString();
                if(StrToBool(SuccessPrompt)){
                    window.alert(strResult[1]);
                }
                break;
            default:
                window.alert(strResult[1]);
                break;
        }
    }
    else {
        window.alert(ReturnValueError);
    }
}
</script>