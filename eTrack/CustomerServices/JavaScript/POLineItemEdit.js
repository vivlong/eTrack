<script language ="javascript" type="text/javascript">
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


function SaveLineItemPODetail(strTitle,intFlag)
{
    if (!StrToBool(SavePrompt) || window.confirm(ConfirmSave.replace("{0}",strTitle))) 
    { 
        if(intFlag==1)
        {
               if (!CanSave()) 
               {
                 return;
               }
              context=intFlag;
              BeforeSave();
             var arg = "SaveData"+ParSeparator+GetDetail();
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SaveLineItemPOReturn", "context")%>;
        }
        else if(intFlag==2 && strHidCon1==1)
        {
             context=intFlag;
             var arg = "SaveLineData"+ParSeparator+GetItemDetail();
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SaveLineItemPOReturn", "context")%>;
        }
        else if(intFlag==2 && strHidCon1==2)
        {
             context=intFlag;
             var arg = "SaveShippingInfo"+ParSeparator+GetShippingDetail();
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SaveLineItemPOReturn", "context")%>;
        }
        else if(intFlag==2 && strHidCon1==3)
        {
             context=intFlag;
             var arg = "SavePackageInfo"+ParSeparator+GetPackageDetail();
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SaveLineItemPOReturn", "context")%>;
        }
        else if(intFlag==2 && strHidCon1==4)
        {
             context=intFlag;
             var arg = "SaveShipToInfo"+ParSeparator+GetShipToDetail();
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SaveLineItemPOReturn", "context")%>;
        }        
    }
    else {
        if(intFlag) {
            NewDetail(1);
        }
        else {
            window.close();
        }
    }
}

function SaveLineItemPOReturn(result,context)
{
    AfterSave();
    var strResult=result.split(ParSeparator);
    switch(strResult.length)
    {
            case 2:
            if (strResult[0]==RtnOk) {
                if(context){
                    blChanged=true;
                    NewDetail(0);
                }
                else {
                    blChanged=true;
                    CloseWindow();
                }
            }
            else {
                window.alert(strResult[1]);
                if (strResult[0]==RtnTimeOut) {
                    CloseWindow();
                }
            }
            break;
        case 3:
        case 4:
        case 5:
            if (strResult[0]==RtnOk) {
                if(context){
                    blChanged=true;
                    NewDetail(0);
                    SetOtherSaveReturn(strResult);
                }
                else {
                    blChanged=true;
                    CloseWindow();
                }
            }
            else  {
                window.alert(strResult[1]);
                if (strResult[0]==RtnTimeOut) {
                    CloseWindow();
                }
            }  
            break;    
        default:
            window.alert(SaveUnexpectedError);
            break;
    }    
}

function CloseWindow()
{
    if(blChanged) {
        window.returnValue=RtnOk;
    }
    else {
        window.returnValue=RtnNoChange;
    }
    window.close();     
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

function DeleteDetail(TrxNo,LineItemNo)
{
    if (!StrToBool(DeletePrompt) || window.confirm(ConfirmDelete)) {
        context = document.getElementById("divSource");
        var arg = "DeleteOneData"+ParSeparator+TrxNo+'&'+LineItemNo+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString();
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnEventValue", "context")%>;
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

function SetReturnEventValue(result,context)
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
                   // window.alert(strResult[1]);
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