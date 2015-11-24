<script language ="javascript" type="text/javascript">
//------------091030-------------------------------------------------------
function setReadOnly(event)
{
 event.returnValue=false;
}
function DetentionDefault(objEta,objDetentionCode,objDetentionStart,objFreeDay)
{
  var valDetention=objDetentionCode.value;
  if(valDetention.indexOf("D")>0){
    strVal =valDetention.substring(0,valDetention.indexOf("D"));
    objFreeDay.value=strVal;
     if(objEta.value.Trim()!=""){
         var dtEta=new Date();
          if(objEta.value.length==15)
          {
           dtEta=ConvertDate(objEta.value);
           var strTime=dtEta.substring(10,dtEta.length);
           dtEta=dtEta.substring(0,10).replace("-","/").replace("-","/")
          }
          else
          {
           dtEta=SingleToLongDate(objEta.value);
           var strTime=dtEta.substring(10,dtEta.length);
           dtEta=dtEta.substring(0,10).replace("-","/").replace("-","/")
          }
         var strdate=DateAdd(strVal,dtEta);
//        var strDate=parseInt(objEta.value.substring(0,2))
//            strDate+=parseInt(strVal)
        objDetentionStart.value=StringToLongDate(strdate);
     }
  }
}
function DateAdd(NumDay, dtDate) { 
      var dtTmp =new Date(dtDate); 
      dtTmp  =new Date(Date.parse(dtTmp)+(86400000 * NumDay));
      var mStr=new String(dtTmp.getMonth()+1);
      var dStr=new String(dtTmp.getDate());
      if (mStr.length==1){
          mStr="0"+mStr;
      }
      if (dStr.length==1){
          dStr="0"+dStr;
      }
       return dtTmp.getFullYear()+"-"+mStr+"-"+dStr;
  }   

//lzw091012
var table='';
var fields='';
var where='';
var showName='';
var TruckerName='';

function OpContainer(objCode,table1,fields1,where1,showName1,TruckerName1)
{
  table=table1;
  fields=fields1;
  where=where1;
  showName=showName1;
  TruckerName=TruckerName1;
    if(RegTrxNo=="-1")
    {
        var strTitle=document .getElementById("HidTitle").value;
            if (!CanSave()) { return;}
            context=document.getElementById("divTrxNo");
            var arg = "SaveData"+ParSeparator+GetDetail();
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnTrxNo", "context")%>;
    }
    else
    {
        var VesselName=document.getElementById("txtVesselName").value;
        var VoyageNo=document.getElementById("txtVoyageNo").value;
        var ret=WindowDialog("../Reference/ContainerList.aspx?table="+table+"&fields="+fields+"&where="+where+"&showName="+showName+"&VesselName="+VesselName+"&VoyageNo="+VoyageNo+"&TruckerName="+TruckerName+"&TrxNo="+RegTrxNo,<%=SysMagic.SystemClass.InfoListSize.Width%>,<%=SysMagic.SystemClass.InfoListSize.Height%>);
        if(ret!=null)
        {
          var strRel=ret.split(ColSeparator);
          if(strRel[0]==RtnOk)
          {
           strWhere=" and TrxNo="+RegTrxNo;
           GetPageData(null,-1)
          }
        }
    }
}
//------------091030-------------------------------------------------------
function valiMultiName(ConCode,ValiName,Fields,Table) 
{
  var strVal=document.getElementById(ConCode).value;
  var strCode=Fields.substring(0,Fields.indexOf(','));
  if(strVal.Trim()!="")
   {
    context = null;
    var strSql ="select "+Fields+",Address1,Address2,Address3,Address4,ContactName1,Telephone from " + Table + " where " + strCode + " ='" + strVal + "'"
    var arg = "valiMultiName"+ParSeparator+strSql+ParSeparator+ValiName+ParSeparator+ConCode;
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetvaliMultiName", "context")%>;
   }
}
function SetvaliMultiName(result,context)
{ 
    var strResult=result.split(ParSeparator);
    if (strResult[0]!=RtnOk) {
       alert("Invalid "+strResult[2]);
       document.getElementById(strResult[1]).value="";
       document.getElementById(strResult[1]).focus();
    }
    else{
      var strfields =strResult[3].split(",")
      if(strfields.length==7){
      document.getElementById("txtConsigneeName").value=strfields[0].Trim();
      document.getElementById("txtConsigneeAddress1").value=strfields[1].Trim();
      document.getElementById("txtConsigneeAddress2").value=strfields[2].Trim();
      document.getElementById("txtConsigneeAddress3").value=strfields[3].Trim();
      document.getElementById("txtConsigneeAddress4").value=strfields[4].Trim();
      document.getElementById("txtContactPerson").value=strfields[5];
      document.getElementById("txtContactNo").value=strfields[6];}
    }
}
//------------091030-------------------------------------------------------
function DetentionCodeSelect(objName,objDistinct)
{
  var strVal="";
  var valObj=document .getElementById(objName).value;
  if(valObj.indexOf("D")>0)
  {
    strVal =valObj.substring(0,valObj.indexOf("D"));
    objDistinct.value=strVal;
  }
  else{objDistinct.value="";}
}
//lzw091012
function BindCodeName(objCode,objName,table,fields,where,showCode,showName)
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
          objName.value=txt;
     }
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
function selConsigneeCode(objCode)
{
    var orderby="BusinessPartyCode";
    var strSql="BusinessPartyCode as [Consignee Code],BusinessPartyName as [Consignee Name],Address1,Address2,Address3,Address4,ContactName1 as [Contact Person], Telephone as [Contact No] ~~ rcbp1 ~~ "
    var strSearchCode="BusinessPartyCode@Consignee Code~BusinessPartyName@Consignee Name";
    var ret=WindowDialog("../Reference/MultiType.aspx?Sql="+strSql+"&SearchCode="+strSearchCode+"&orderby="+orderby,<%=SysMagic.SystemClass.InfoListSize.Width%>,<%=SysMagic.SystemClass.InfoListSize.Height%>);
    if(ret!=null)
    {
     var strRel=ret.split(',');
     for(var i=0;i<strRel.length;i++ )
     {
      strRel[i]=strRel[i]=="&nbsp;"?" ":strRel[i];
      strRel[i]=strRel[i].replace('amp;','');
     }
     objCode.value=strRel[0];
     document .getElementById("txtConsigneeName").value=strRel[1].Trim();
     document .getElementById("txtConsigneeAddress1").value=strRel[2].Trim();
     document .getElementById("txtConsigneeAddress2").value=strRel[3].Trim();
     document .getElementById("txtConsigneeAddress3").value=strRel[4].Trim();
     document .getElementById("txtConsigneeAddress4").value=strRel[5].Trim();
     document .getElementById("txtContactPerson").value=strRel[6].Trim();
     document .getElementById("txtContactNo").value=strRel[7].Trim();
    }
}
var PubUpperFlag="";
function FocusAddToSO2(event,UpperFlag)
{
    PubUpperFlag=UpperFlag;
   if((event.keyCode==13)||(event.keyCode==0x28)||(event.keyCode==9))
   {
        if(RegTrxNo=="-1")
        {
            var strTitle=document .getElementById("HidTitle").value;
                if (!CanSave()) { return;}
                context=document.getElementById("divTrxNo");
                var arg = "SaveData"+ParSeparator+GetDetail();
                <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnButtonAddToSO2", "context")%>;
        }
        else
        {AddToSO2(RegTrxNo,PubUpperFlag);}
    }
}
function ButtonAddToSO2(event,UpperFlag){
      PubUpperFlag =UpperFlag;
        if(RegTrxNo=="-1")
        {
            var strTitle=document .getElementById("HidTitle").value;
                if (!CanSave()) { return;}
                context=document.getElementById("divTrxNo");
                var arg = "SaveData"+ParSeparator+GetDetail();
                <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnButtonAddToSO2", "context")%>;
        }
        else
        {AddToSO2(RegTrxNo,UpperFlag);}
}
function SetReturnButtonAddToSO2(result,context)
{
    strResult=result.split(ParSeparator);
    if (strResult.length==4) {
        switch(strResult[0])
        {
            case "1":
                var strTrxNo=strResult[2];
                if(strTrxNo!='-1'){RegTrxNo=strTrxNo;}
                if (strResult[3]!=""){document.title="Storing Order No : " + strResult[3];}
                AddToSO2(RegTrxNo,PubUpperFlag);
            default:
                break;
        }
     }
}



function SetReturnTrxNo(result,context)
{
    strResult=result.split(ParSeparator);
    if (strResult.length==4) {
        switch(strResult[0])
        {
            case "1":
                var strTrxNo=strResult[2];
                if(strTrxNo!='-1'){RegTrxNo=strTrxNo;}
                if (strResult[3]!=""){document.title="Storing Order No : " + strResult[3];}
        ///////////////////////////////////////////////
        var VesselName=document.getElementById("txtVesselName").value;
        var VoyageNo=document.getElementById("txtVoyageNo").value;
        var ret=WindowDialog("../Reference/ContainerList.aspx?table="+table+"&fields="+fields+"&where="+where+"&showName="+showName+"&VesselName="+VesselName+"&VoyageNo="+VoyageNo+"&TruckerName="+TruckerName+"&TrxNo="+RegTrxNo,<%=SysMagic.SystemClass.InfoListSize.Width%>,<%=SysMagic.SystemClass.InfoListSize.Height%>);
        if(ret!=null)
        {
          var strRel=ret.split(ColSeparator);
          if(strRel[0]==RtnOk)
          {
           strWhere=" and TrxNo="+RegTrxNo;
           GetPageData(null,-1)
          }
        }
        ///////////////////////////////////////////////
            default:
                break;
        }
     }
}
 function AddToSO2(strTrxNo,UpperFlag)
{
        var blankFlag=0 ;
        var strContainerNO=""
        var strTruckerName=""
        var signFrame = document.getElementById("gvwSource");
        var tr;
           if(signFrame.rows.length == 1){blankFlag+=1}
           else if (signFrame.rows.length > 1)
           { 
                tr = signFrame.rows[signFrame.rows.length-1];
                  if (tr.cells[1].hasChildNodes() && (tr.cells[1].childNodes[0].nodeType==1)) 
                  {
                     strTruckerName=document.getElementById("txtTruckerName").value;
                     strFile=tr.cells[1].childNodes[0].value.replace(/,/g,"")
                     strContainerNO=strFile;
                     if(strContainerNO!="")
                     {blankFlag+=1; if(UpperFlag=="y"){strContainerNO=strContainerNO.toUpperCase();}}
                     else{alert("Container NO must input!");return false;}
                 }
           }
           if(blankFlag>0)
           {
                context = document.getElementById("divSource");
                var arg = "SO2SaveOne"+ParSeparator+RegTrxNo+ParSeparator+strContainerNO+ParSeparator+strTruckerName;
                <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetSO2SaveOne", "context")%>;  
           }
            else {event.returnValue=false;}
}

function SetSO2SaveOne(result,context)
{
    var strResult=result.split(ParSeparator);
    switch(strResult.length) {
        case 3:
            if (strResult[0]==RtnOk) { context.innerHTML = strResult[1];
                    var signFrame = document.getElementById("gvwSource");
                    var tr;
                       if(signFrame.rows.length == 1){blankFlag+=1}
                       else if (signFrame.rows.length > 1)
                       { 
                            tr = signFrame.rows[signFrame.rows.length-1];
                              if (tr.cells[1].hasChildNodes() && (tr.cells[1].childNodes[0].nodeType==1)) 
                              {
                                 tr.cells[1].childNodes[0].focus();
                              }
                       }
                //----------------------------------
                intCount=strResult[2];
                if(intPage>intCount && intPage!=1){
                    intPage=intCount;
                }
                var lbl=document.getElementById("lblPage");
                lbl.innerHTML = PageTitle + intPage.toString() + PageSeparator + intCount.toString();
                var txt=document.getElementById("txtPage");
                txt.value=intPage.toString();
                //----------------------------------
            }
            else{alert(strResult[1]);}
            //alert(strResult[1]);
            break;
        default:
            break;
    }
}
function OpReceivedContainer(intLineItemNo,intTrxNo)
{
    var ret;
    ret=WindowDialog("ReceiveContainer.aspx"+"?LineItemNo="+intLineItemNo+"&intTrxNo="+intTrxNo,1024,520);
    if (ret==RtnOk) {
        GetPageData(null,-1)
    }
}

 //For ReleaseContainer 091021 zhiwei------------------------------------------------------------------------------------------------------
function UpdateCTSO2(strTrxNo,intLineitemno,ContainerNo,conContainer)
{
     var  strValue=document.getElementById(conContainer).value;
     if(strTrxNo!="" && intLineitemno!="" && strValue!=ContainerNo )
     {
      var strslq=" update ctso2 set ContainerNo='"+strValue+"' where TrxNo="+strTrxNo+" and LineItemNo="+intLineitemno;
      context = document.getElementById("divSource");
      var arg = "CTSO2Update"+ParSeparator+strslq+ParSeparator+strTrxNo+ParSeparator+strValue+ParSeparator+conContainer+ParSeparator+ContainerNo;
      <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetUpdateCTSO2", "context")%>;
     }
 }
function SetUpdateCTSO2(result,context) 
{
    var strResult=result.split(ParSeparator);
    switch(strResult.length) {
        case 3:
            if (strResult[0]==RtnOk) {
             }
            else{
                 alert(strResult[1]);
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
function ReturntheValue(result,context)
{
        AfterSave(); // after reply need enable the button.
        window.alert(result);
        window.close(); 
} 
 
function CanConfirmSave()
{
    return true;
}

function GetDetail()
{
    var strDetail="";
    strDetail=RegTrxNo;
    strDetail=strDetail+ColSeparator+document.getElementById("txtOrganization").value;
    strDetail=strDetail+ColSeparator+document.getElementById("drDemurrageCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtJobNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtVesselName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtVoyageNo").value;
    strDetail=strDetail+ColSeparator+ConvertDate(document.getElementById("txtETA").value);
    strDetail=strDetail+ColSeparator+document.getElementById("drReturnType").value;
    strDetail=strDetail+ColSeparator+"";
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsigneeCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsigneeName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsigneeAddress1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtContactPerson").value;          
    strDetail=strDetail+ColSeparator+document.getElementById("txtContactNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDepotCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtPortOfLoading").value;
    strDetail=strDetail+ColSeparator+document.getElementById("drDetentionCode").value; //16
    strDetail=strDetail+ColSeparator+ConvertDate(document.getElementById("txtDetentionStart").value);//17
    strDetail=strDetail+ColSeparator+document.getElementById("txtDetentionFreeDay").value;//18
    strDetail=strDetail+ColSeparator+ConvertDate(document.getElementById("txtDemurrageSD").value);
    strDetail=strDetail+ColSeparator+document.getElementById("txtDemurrageFreeDay").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtInstructionTD").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtTruckerCode").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtTruckerName").value;
    strDetail=strDetail+ColSeparator+ConvertDate(document.getElementById("txtTruckingCD").value);          
    strDetail=strDetail+ColSeparator+document.getElementById("txtTruckerRefNo").value;
    strDetail=strDetail+ColSeparator+"Storing@OrderNo";  
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsigneeAddress2").value; 
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsigneeAddress3").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsigneeAddress4").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtSiteCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtUserNo").value; 
    strDetail=strDetail+ColSeparator+document.getElementById("txtRefNo").value; 
    return strDetail+ParSeparator;
    //return strDetail;
}
  
function NewDetail(intFlag)
{
  if(intFlag!=2){
    document.getElementById("txtOrganization").value="";
    document.getElementById("drDemurrageCode").selectedIndex=0;    
    document.getElementById("txtJobNo").value="";
    document.getElementById("txtVesselName").value="";  
    document.getElementById("txtVoyageNo").value="";
    document.getElementById("txtETA").value="";
    document.getElementById("drReturnType").selectedIndex=0;
    //document.getElementById("txtReturnOC").value="";      
    document.getElementById("txtConsigneeCode").value="";
    document.getElementById("txtConsigneeName").value="";
    document.getElementById("txtConsigneeAddress1").value="";
    document.getElementById("txtContactPerson").value="";          
    document.getElementById("txtContactNo").value="";
    document.getElementById("txtDepotCode").value="";
    document.getElementById("txtPortOfLoading").value="";
    document.getElementById("drDetentionCode").selectedIndex=0; 
    document.getElementById("txtDetentionStart").value="";
    document.getElementById("txtDetentionFreeDay").value="";          
    document.getElementById("txtDemurrageSD").value="";
    document.getElementById("txtDemurrageFreeDay").value="";
    document.getElementById("txtInstructionTD").value="";
    document.getElementById("txtTruckerCode").value="";    
    document.getElementById("txtTruckerName").value="";
    document.getElementById("txtTruckingCD").value="";          
    document.getElementById("txtTruckerRefNo").value="";
    document.getElementById("txtConsigneeAddress2").value="";
    document.getElementById("txtConsigneeAddress3").value="";
    document.getElementById("txtConsigneeAddress4").value="";
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
        document.getElementById("fldId").value=strResult[3];
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
                window.alert(strResult[1]);
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
 //drReturnType
  var drObj =document.getElementById('drReturnType')
  if (drObj.selectedIndex==0)
  {
    window.alert("Return Type is mandatory.");
    drObj.focus();
    return false;
  }
  //txtDepotCode
  var txt =document.getElementById('txtDepotCode')
  if (txt.value.Rtrim()=="")
  {
    window.alert("Depot Code is mandatory.");
    txt.focus();
    return false;
  }
  //txtPortOfLoading
  var txt =document.getElementById('txtPortOfLoading')
  if (txt.value.Rtrim()=="")
  {
    window.alert("Port Of Loading is mandatory.");
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
    if (strResult.length==3) {
        switch(strResult[0])
        {
            case "1":
                AfterSave(); 
                strSON=document.getElementById("txtSON").value;
                var strTrxNo=strResult[2];
                if(strTrxNo!='-1'){RegTrxNo=strTrxNo;}
                AddToSO2(RegTrxNo,UpperFlag);
            default:
                break;
        }
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

</script>