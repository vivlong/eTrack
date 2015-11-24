<script language ="javascript" type="text/javascript">
function AddSelectedAttach()
{
     var strJobNo=document.getElementById("txtJobNo").value;
    var ret=WindowDialog("../SysRef/AttachEdit.aspx?Id="+strJobNo+"&Folder=Tracking",640,450);
    if(ret!=null && ret!=""){
        context = document.getElementById("div2");
        var arg = "AddSelectedAttach"+ParSeparator+ret; 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function DeleteOneAttach(strFileName)
{
    var strId=document.getElementById("fldId").value;
    if (window.confirm("Are you sure to delete current select attachment?")) {
        context = document.getElementById("div2");
        var arg = "DeleteOneAttach"+ParSeparator+strId+ParSeparator+strFileName;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}
function SetReturnValue(result,context) 
{ 

    AfterSave();
    var strResult=result.split(ParSeparator);
    switch(strResult.length) {
        case 2:
            if (strResult[0]==RtnOk) {
                context.innerHTML = strResult[1];
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
function CanSave()
{
   return true;
}

function checkDataValue()
{
    var strDetail="";
    strDetail=strDetail+ColSeparator+ "FinalDestDate="+$("#txtFinalDestDate_txtDateTime").val();
    strDetail=strDetail+ColSeparator+ "DOReleaseDate="+$("#txtDOReleaseDate_txtDateTime").val();
    strDetail=strDetail+ColSeparator+ "CntrReturnDate="+$("#txtCntrReturnDate_txtDateTime").val();
    var obj =document.getElementById("drCntrReturnType");
    strDetail=strDetail+ColSeparator+ "CntrReturnType="+obj.options[obj.selectedIndex].value;
    return strDetail;
}

function GetDetail()
{ 
    var strDetail="";
    strDetail=ColSeparator+ "FinalDestDate="+$("#txtFinalDestDate_txtDateTime").val();
    strDetail=strDetail+ColSeparator+ "DOReleaseDate="+$("#txtDOReleaseDate_txtDateTime").val();
    strDetail=strDetail+ColSeparator+ "CntrReturnDate="+$("#txtCntrReturnDate_txtDateTime").val();
    var obj =document.getElementById("drCntrReturnType");
    strDetail=strDetail+ColSeparator+ "CntrReturnType="+obj.options[obj.selectedIndex].value;
    strDetail=strDetail+ColSeparator+ "HODate="+$("#txtHODate_txtDateTime").val();
    strDetail=strDetail+ColSeparator+ "DischargeDate="+$("#dtsDischargeDate_txtDateTime").val();
    strDetail=strDetail+ColSeparator+ "Owner="+document.getElementById("txtOwner").value;
    strDetail=strDetail+ColSeparator+ "CntrRemark="+document.getElementById("txtCntrRemark").value;
    obj =document.getElementById("drCargoStatusCode");
    if (obj.options[obj.selectedIndex].value=="N")
     {
       strDetail=strDetail+ColSeparator+ "CargoStatusCode=";
     }
    else
     {
       if (document.getElementById("fldRccfContainer").value == "")
        {
          strDetail=strDetail+ColSeparator+ "CargoStatusCode=CMP";
        }
       else
        {
          if (document.getElementById("fldCntrTransferDate").value == "")
           {
             strDetail=strDetail+ColSeparator+ "CargoStatusCode=INB";
           }
          else
           {
             strDetail=strDetail+ColSeparator+ "CargoStatusCode=CMP";
           }        
        }             
     }    
    
    strDetail=strDetail+ColSeparator+"";
    strDetail=strDetail+ColSeparator+"";
    strDetail=strDetail+ColSeparator+"";
    strDetail=strDetail+ColSeparator+"";
    return strDetail+ParSeparator;
    //return strDetail;
}

function NewDetail(intFlag)
{
}

function BeforeSave()
{
    document.getElementById("btnSave").disabled=true;
    document.getElementById("btnClose").disabled=true;
    document.getElementById("SaveHint").style.display = "block";
}

function AfterSave()
{
    document.getElementById("btnSave").disabled=false;
    document.getElementById("btnClose").disabled=false;
    document.getElementById("SaveHint").style.display = "none";
}

function SaveDetail(strTitle,intFlag)
{

 if ($("#divMiddle1").css("display")=="block")
 {
  if (!StrToBool(SavePrompt) || window.confirm(ConfirmSave.replace("{0}",strTitle))) 
    { 
        if (!CanSave()) 
        {
            return;
        }
        context=intFlag;
        BeforeSave();
        var arg = "SaveData"+ParSeparator+GetDetail()+checkDataValue();
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SaveReturn", "context")%>;
        AfterSave();
    }
    else {
            if(intFlag) {NewDetail(1);}
            else {window.close();}
         }
  }
  else if(document.getElementById("divMiddle2").style.display=="block")
  {
    if(  document.getElementById("divMiddle1").style.display=="none")
    {
           // BeforeSave();
            context = document.getElementById("divSource");
            var arg = "SaveDiv2Data"+ParSeparator+GetDiv2Detail();
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SaveReturnDiv2", "context")%>;
            return;
    }
  }
}

</script>