<script language ="javascript" type="text/javascript">

function DetentionCodeSelect(objName)
{
  var strVal="";
  var valObj=document .getElementById(objName).value;
  var objDistinct =document .getElementById("txtFreePeriod");
  if(valObj.indexOf("D")>0)
  {
    strVal =valObj.substring(0,valObj.indexOf("D"));
    objDistinct.value=strVal;
  }
  else{objDistinct.value="";}
}
//lzw091012
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
function OpReleaseContainer(intLineItemNo,intTrxNo,strOrderNo,RequipType,TruckerName)
{
    var ret;
    ret=WindowDialog("ReleaseContainer.aspx"+"?LineItemNo="+intLineItemNo+"&intTrxNo="+intTrxNo+"&OrderNo="+strOrderNo+"&RequipType="+RequipType+"&TruckerName="+TruckerName,1024,520);
    if (ret==RtnOk) {
        GetPageData(null,-1)
    }
}
function ReturntheValue(result,context)
{
        AfterSave(); // after reply need enable the button.
        window.alert(result);
        window.close();
} 

function CanConfirmSave()
{ return true; }

function GetDetail()
{
    var strDetail="";
    strDetail=document.getElementById("hidTrxNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtOrganization").value;
    strDetail=strDetail+ColSeparator+"";
    strDetail=strDetail+ColSeparator+document.getElementById("txtMasterJobNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtVesselName").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtVoyageNo").value;
    strDetail=strDetail+ColSeparator+ConvertDate(document.getElementById("txtETA").value);
    strDetail=strDetail+ColSeparator+document.getElementById("drReleaseType").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtReleasingDC").value;      
    strDetail=strDetail+ColSeparator+document.getElementById("txtPortOfLoading").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtProtOfDischarge1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtProtOfDischarge2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtProtOfDischarge3").value;          
    strDetail=strDetail+ColSeparator+document.getElementById("txtFinalDestination").value;
    strDetail=strDetail+ColSeparator+document.getElementById("drDetentionCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtFreePeriod").value;
    strDetail=strDetail+ColSeparator+"Releasing@InstructionNo";//document.getElementById("txtRIN").value; 
    strDetail=strDetail+ColSeparator+document.getElementById("txtSiteCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtUserId").value;
    strDetail=strDetail+ColSeparator+"";
    strDetail=strDetail+ColSeparator+"";
    strDetail=strDetail+ColSeparator+"";
    
    return strDetail+ParSeparator;
    //return strDetail;
}
  
function NewDetail(intFlag)
{
  if(intFlag!=0){
    var strDetail="";
    document.getElementById("txtOrganization").value=0;
//    document.getElementById("drDemurrageCOde").selectedIndex=0;
    document.getElementById("txtMasterJobNo").value="";
    document.getElementById("txtVesselName").value="";
    document.getElementById("txtVoyageNo").value="";
    document.getElementById("txtETA").value="";
    document.getElementById("drReleaseType").selectedIndex=0;
    document.getElementById("txtReleasingDC").value="";
    document.getElementById("txtPortOfLoading").value="";
    document.getElementById("txtProtOfDischarge1").value="";
    document.getElementById("txtProtOfDischarge2").value="";
    document.getElementById("txtProtOfDischarge3").value="";
    document.getElementById("txtFinalDestination").value="";
    document.getElementById("drDetentionCode").value="";
    document.getElementById("txtFreePeriod").value="";
    //return strDetail;
   }
}

function BeforeSave()
{
    document.getElementById("btnSave").disabled=true;
    document.getElementById("btnClose").disabled=true;
}
function AfterSave()
{
    document.getElementById("btnSave").disabled=false;
    document.getElementById("btnClose").disabled=false;
}
 
function SetOtherSaveReturn(strResult)
{
    if(strResult.length==3){
        document.getElementById("hidTrxNo").value=strResult[3];
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

function SetReturnValue(result,context) 
{ 

    AfterSave();
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
 //drOrganization
  var txt =document.getElementById('txtOrganization')
  if (txt.value=="")
  {
    window.alert("Organization Code is not found in Company table.");
    txt.focus();
    return false;
  }
  //txtMasterJobNo
  var txt =document.getElementById('txtMasterJobNo')
  if (txt.value.Rtrim()=="")
  {
    window.alert("Master Job No is mandatory.");
    txt.focus();
    return false;
  }
  //drReleaseType
  var txt =document.getElementById('drReleaseType')
  if (txt.selectedIndex==0)
  {
    window.alert("Release Type is mandatory.");
    txt.focus();
    return false;
  }  
  return true;
}


 
//-------------------------------BaseList------------------------------------------
function InsertDetail(intFlag)
{
    var strTitle=document .getElementById("HidTitle").value;
    if(intFlag){if(!window.confirm(ConfirmSave.replace("{0}",strTitle))){return false;}}
     if (!CanSave()) { return;}
     context=document.getElementById("divTrxNo");
     BeforeSave();
     var arg = "SaveData"+ParSeparator+GetDetail();
     <%= ClientScript.GetCallbackEventReference(Me, "arg", "OpInsertDetail", "context")%>;
}
function OpInsertDetail(result,context)
{
    strResult=result.split(ParSeparator);
    if (strResult.length==4){
        switch(strResult[0])
        {
            case "1":
                AfterSave(); 
                strRIN=strResult[3];
                 if(strRIN!=""){document.title="Releasing Instruction : "+strRIN}
                context.innerHTML=strResult[2];
                var strTrxNo=document.getElementById("hidTrxNo").value;
                if(strTrxNo!='-1'){RegTrxNo=strTrxNo;}
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
//-----PopupMenu.js------------------------------------------------
 var menuskin = "skin";
 var CurrentId="";
 
 function HideMenu() 
 {
    if (popupMenu.style.display != "none"){
        popupMenu.style.display = "none";
    }
 }
 
 function HighlighItem()
 {
      if (event.srcElement.className == "menuitems"){
         event.srcElement.style.border="0.1px solid";
         event.srcElement.style.backgroundColor = "LightSkyBlue";
         event.srcElement.style.color = "white";
      }
 }
 
 function LowlightItem()
 {
     if (event.srcElement.className == "menuitems") {
        event.srcElement.style.border="";
        event.srcElement.style.backgroundColor = "";
        event.srcElement.style.color = "black";
        window.status = "";
      }
 }              

function ShowMenu(intId)
{ 
    CurrentId=intId;
    var rightedge = document.body.clientWidth-event.clientX;
    var bottomedge =document.body.clientHeight-event.clientY;
    if (rightedge <popupMenu.offsetWidth){
        popupMenu.style.left = document.body.scrollLeft + event.clientX - popupMenu.offsetWidth;
    }
    else {
        popupMenu.style.left = document.body.scrollLeft + event.clientX;
    }
    if (-bottomedge <80){
        popupMenu.style.top = document.body.scrollTop + event.clientY;
    }
    else{        
        popupMenu.style.top = document.body.scrollTop + event.clientY-100;
    }
    popupMenu.style.display = "block";
    return false;
}

function ClickItem() 
{
     var arrResult =CurrentId.split("#");
     var intLineItemNo="";
     var txtRIN="";
     var intTrxNo="";
     if(arrResult.length==3)
     {
        intLineItemNo=arrResult[0];
        txtRIN=arrResult[1];
        intTrxNo=arrResult[2];
     }
     if (event.srcElement.className == "menuitems"){
         HideMenu();
         var arg=event.srcElement.getAttribute("Id");
         switch (arg){
             case "EditColumn":
                 GridColumnSet();
                 break;
            case "InsertDetail":
                InsertDetail();
                break;
            case "EditDetail":
                EditDetail(intLineItemNo,txtRIN,intTrxNo);
                break;
            case "DeleteDetail":
                DeleteDetail(intTrxNo.toString()+"123456789"+intLineItemNo.toString());
                break;
            case "PrintDetail":
                PrintDetail(CurrentId)
                break;
         }         
     }
 }
 
function GridColumnSet()
{
    var ret;
    ret=WindowDialog("../Reference/DynamicColumnEdit.aspx?TableName="+TableName,600,450);
    if(ret!=null && ret!=""){
        GetPageData(null,0) ;
    }
}
//-----PopupMenu.js------------------------------------------------------------------------------------
function SaveReturn(result,context)
{
    AfterSave();
    var strResult=result.split(ParSeparator);
    switch(strResult.length) 
    {
        case 4:
               if (strResult[0]==RtnOk) {
                if(context){
                    blChanged=true;
                    NewDetail(0);
                    SetOtherSaveReturn(strResult);
                    blChanged=true;
                    CloseWindow();
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
</script>