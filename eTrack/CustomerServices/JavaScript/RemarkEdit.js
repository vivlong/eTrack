<script language ="javascript" type="text/javascript">
function SupplierSelect(obj)
{
  if(obj.selectedIndex>0)
  {
   divNewSupplier.style.display="none";
   context=divSupplier;
   var arg="GetSupplierInfo"+ParSeparator+obj.value;
   <%=ClientScript.GetCallbackEventReference(Me,"arg","SetReturnValue","context")%>
  }
}
function BtnShowSupplier()
{
   var strFlag="";
      if(divNewSupplier.style.display=="block")
      {
        divNewSupplier.style.display="none";
            strFlag="2";
      }
      else
      {
        divNewSupplier.style.display="block";
        var obj =document.getElementById("drSupplier");
        obj.selectedIndex=0;
        strFlag="1";
      }
    context=divInvoiceNumber;
    var arg="SetInvoiceFocus"+ParSeparator+strFlag;
    <%=ClientScript.GetCallbackEventReference(Me,"arg","SetReturnValue","context")%>
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
function AddSelectedAttach()
{
    var strId=document.getElementById("fldId").value;
    var ret=WindowDialog("../SysRef/AttachEdit.aspx?Id="+strId+"&Folder=Popo1",640,450);
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
///////////////////////////////////////////////////////////
function InsertDetail()
{
   var strID = document.getElementById("fldId").value
    var ret=WindowDialog(EditPage+"?strPoTrxNo="+strID,EditWidth,EditHeight);
    if (ret==RtnOk) {
        GetPageData(null,-1)
    }
}

//bylzw for po 090707
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

var blChanged=false;


function SavePODetail(strTitle,intFlag)
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
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SavePOReturn", "context")%>;
        }
        else if(intFlag==2 && strHidCon1==1)
        {
             context=intFlag;
             var arg = "SavePOData"+ParSeparator+GetPOInfoDetail();
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SavePOReturn", "context")%>;
        }
        else if(intFlag==2 && strHidCon1==2)
        {
             context=intFlag;
             var arg = "SaveSupplierInfo"+ParSeparator+GetSupplierDetail();
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SavePOReturn", "context")%>;
        }
        else if(intFlag==2 && strHidCon1==3)
        {
             context=intFlag;
             var arg = "SaveShipToInfo"+ParSeparator+GetShipToDetail();
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SavePOReturn", "context")%>;
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

function SavePOReturn(result,context)
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
</script>