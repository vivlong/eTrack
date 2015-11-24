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
function selBindCode(objCode,table,fields,where,showCode,showName)
{
    if(where.indexOf("'")>0){
    var arrwhere =where.split("'");
    var i=0;
    for(i=0;i<arrwhere.length;i++){where=where.replace("'","@@@");}
    }
    arrwhere =where.split("=");
    for(i=0;i<arrwhere.length;i++){where=where.replace("=","~");}
    
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
function SetCity(drCity,drCountry)
{
 var strValue=drCountry.value;
    context=drCity;
    var arg="SetdrCity"+ParSeparator+strValue;
    
    <%=ClientScript.GetCallbackEventReference(Me,"arg","ReturnCombobox","context")%>
}
function ReturnCombobox(result, context) 
        { 
           
            var strResult=result.split(ParSeparator);
       if (strResult[0]=="1")
       {
             // document.getElementById(context).options.length=0
               context.options.length=0; 
                   
              var allArray = strResult[1].split("@");
              for(var i=1;i<allArray.length;i++)
              {
                  var thisArray = allArray[i].split("|");
                  if(thisArray.length>1)
                  {
                  context.options.add(new Option(thisArray[1].toString(),thisArray[0].toString()));
                  }
                  
              }
               }   else
       {alert(strResult[1]);}
            
               
        }

var drp;
function SetCountry(e,drc)
{
drp=drc;
 var strValue=e.value;
     
    context="";
    var arg="SetdrCountry"+ParSeparator+strValue;
    
    <%=ClientScript.GetCallbackEventReference(Me,"arg","SetdrCountry","context")%>
}
function SetdrCountry(va)
{
 var strResult=va.split(ParSeparator);
   var obj =drp;
obj.value=strResult[1];
drp="";
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
function DeletePOPO2(intId,intLineItem)
{
    if (!StrToBool(DeletePrompt) || window.confirm(ConfirmDelete)) {
        context = document.getElementById("divSource");
        var arg = "DeletePOPO2"+ParSeparator+intId.toString()+ParSeparator+intLineItem.toString();
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetSourceValue", "context")%>;
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
        var arg = "DeleteOneData"+ParSeparator+intId.toString()+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+"LineItemNo"+ParSeparator+SortDesc.toString();
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