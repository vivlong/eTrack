<script language ="javascript" type="text/javascript">
function TickChk()
{
if(document.getElementById("chkNotifyUsers").checked==true)
{
strSubject=document.getElementById("txtEventTitle").value;  
strContent="Event Date : "+document.getElementById("txtEventDate").value+"\r\n"+document.getElementById("txtComments").value;  
 window.showModalDialog("../Reference/SendEmail.aspx",{params:[strSubject,strContent]},'dialogHeight=350px;dialogWidth=500px;status=no');
//    if(ret!=null && ret!=""){
//     
//    }
//  context = "";
//        var arg = "CallEmail"+ParSeparator+document.getElementById("txtEventTitle").value+ParSeparator+document.getElementById("txtEventDate").value+ParSeparator+document.getElementById("txtComments").value; 
//        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
}
}
function AddSelectedAttach(strPath)
{
    var strId=document.getElementById("fldId").value;
    var strLineItem=document.getElementById("fldLineItemNo").value;
    var ret=WindowDialog("../SysRef/AttachEdit.aspx?Id="+strId+"&LineItemNo="+strLineItem+"&Folder=Popo2",640,450);
    if(ret!=null && ret!=""){
        context = document.getElementById("divAttach");
        var arg = "AddSelectedAttach"+ParSeparator+ret; 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}
function DeleteOneAttach(strFileName)
{
    var strId=document.getElementById("fldId").value+"#"+document.getElementById("fldLineItemNo").value;
    if (window.confirm("Are you sure to delete current select attachment?")) {
        context = document.getElementById("divAttach");
        var arg = "DeleteOneAttach"+ParSeparator+strId+ParSeparator+strFileName;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}
function SetReturnValue(result,context)
{
  var strResult=result.split(ParSeparator);
       if (strResult[0]==RtnOk) 
       {
        context.innerHTML = strResult[1];
       }
       else
       {alert(strResult[1]);}
}
var blChanged=false;

function SetOtherSaveReturn(strResult)
{
    if(strResult.length==3){alert(strResult[1]);
    CloseWindow();
    }
}

//GetDetail
function GetDetail()
{
    var strDetail="";
    strDetail=document.getElementById("fldId").value;
    //Item Information
    strDetail=strDetail+ColSeparator+document.getElementById("txtEventDate").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtEventTitle").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtComments").value;
    strDetail=strDetail+ColSeparator+document.getElementById("chkNotifyUsers").checked;
    strDetail=strDetail+ColSeparator+document.getElementById("fldLineItemNo").value;    
    return strDetail;
}

function NewDetail(flag)
{
return true ;
}


function  textCounter(event,obj,intPar)  
{        
  if(obj.value.length>=intPar)   
  {   
      event.keyCode   =   0;   
      return;   
  }   
}

///////////////////////////////////////////////////////////
function InsertDetail()
{
   var strID =document.getElementById("fldId").value
   
    var ret=WindowDialog(EditPage+"?TrxNo="+strID,EditWidth,EditHeight);
    if (ret==RtnOk) {
        GetPageData(null,-1)
    }
}
// for Even
function EditDetail(intId,FunNo,LineItemNo)
{
    var ret;
    if (EditPage.indexOf(".aspx?")>0){
        ret=WindowDialog(EditPage+"&Id="+intId.toString()+"&FunNo="+FunNo+"&LineItemNo="+LineItemNo,EditWidth,EditHeight);
    }
    else{
        ret=WindowDialog(EditPage+"?Id="+intId.toString()+"&FunNo="+FunNo+"&LineItemNo="+LineItemNo,EditWidth,EditHeight);
    }
    if (ret==RtnOk) {
        GetPageData(null,-1)
    }
}

function DeleteDetail(intId)
{
    if (!StrToBool(DeletePrompt) || window.confirm(ConfirmDelete)) {
        context = document.getElementById("divSource");
        var arg = "DeleteOneData"+ParSeparator+intId.toString()+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString();
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function UndeleteDetail(intId)
{
    if (window.confirm(ConfirmRestore)) {
        context = document.getElementById("divSource");
        var arg = "UndeleteOneData"+ParSeparator+intId.toString()+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString();
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}
//CanSave
function CanSave()
{
    return true;
}
function BeforeSave()
{
//    document.getElementById("btnSave").disabled=true;
//    document.getElementById("btnClose").disabled=true;
}
function AfterSave()
{
    document.getElementById("btnSave").disabled=false;
    document.getElementById("btnClose").disabled=false;
}
function selBindCode(objCode,table,fields,where,showCode,showName)
{
    if(where.indexOf("'")>0){
    var arrwhere =where.split("'");
    var i=0;
    for(i=0;i<arrwhere.length;i++){where=where.replace("'","@@@");}
    }
    arrwhere =where.split("=");
    for(i=0;i<arrwhere.length;i++){where=where.replace("=","~");}
    
    var ret=WindowDialog("../Reference/TypeSort.aspx?table="+table+"&fields="+fields+"&where="+where+"&showCode="+showCode+"&showName="+showName,<%= SysMagic.SystemClass.InfoListSize.Width%>,<%= SysMagic.SystemClass.InfoListSize.Height%>);
    if(ret!=null)
    {
     var strRel=ret.split(ColSeparator);
     if (strRel.length==2) 
     {
        var txt=strRel[1]=="&nbsp;"?" ":strRel[1];
            txt=txt.replace('amp;','');
          objCode.value=strRel[1];
     }
    }
}
</script>