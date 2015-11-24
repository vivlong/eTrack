<script language ="javascript" type="text/javascript">
function InsertITD(objITD)
{
    var orderby="Code_Desc";
    var strSql="Code_Desc ~~ Code_Table ~~ Code %3D 'Instr_Depot' "
    var strSearchCode="Code_Desc@Code Description";
    var ret=WindowDialog("../Reference/MultiType.aspx?Sql="+strSql+"&SearchCode="+strSearchCode+"&orderby="+orderby,400,<%=SysMagic.SystemClass.InfoListSize.Height%>);
    if(ret!=null)
    {
     var strVal=ret.replace(',&nbsp;');
     strVal=strVal.replace('amp;','');
     strVal=strVal.replace('undefined,','');     
     objITD.value+=strVal;
    }
}
window.prompt = (function(prompt) {
    if (window.navigator.appName.toLowerCase().indexOf("microsoft")<0)
     return prompt;
    return function(msg) {
     window.vbs_var = null;
     execScript('window.vbs_var = InputBox(unEscape("'+escape(msg)+'"), "")', "VBScript");
  return window.vbs_var;
    };
})(window.prompt);
//091223
function updateRON(UpperCase)
{
 var TrxNo =document.getElementById("HidTrxNo").value;
 var LineItemNo =document.getElementById("HidLineItemNo").value;
 var proResult=window.prompt("please input a new Releasing Order No:")
 if(!proResult){return false;}
 if(proResult!="")
 {
   if(UpperCase=="y"){proResult=proResult.substring(0,20).toUpperCase();}
   else{proResult=proResult.substring(0,20)}
   context = null;
   var arg="updateRON"+ParSeparator+proResult+ParSeparator+TrxNo+ParSeparator+LineItemNo;
   <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetupdateRON", "context")%>; 
 }
 function SetupdateRON(result,context) 
{ 
    var strResult=result.split(ParSeparator);
     if (strResult[0]==RtnOk) {
     blChanged=true;
     //window.document.title="Releasing Order :"+strResult[1];
     window.document.title="Releasing Order :"+strResult[1];
     var strOldRON=strResult[2]
     //Update ReleasingOrder In Grid
        var signFrame = window.dialogArguments.window.document.getElementById("gvwSource");
        var tr;
           if (signFrame.rows.length > 1)
           {  
              var RONIndex=0;
              tr = signFrame.rows[0];
              for(i=0;i<=tr.cells.length-1;i++)
              {
                 if(tr.cells[i].innerHTML.toLowerCase()=="order no")
                 {RONIndex=i;}
              }
              if(RONIndex==0){return false;}
              for(i=1;i<signFrame.rows.length;i++)
              {
                 tr = signFrame.rows[i];
                     strRON=tr.cells[RONIndex].innerHTML.replace(/,/g,"");
                     if(strOldRON=strRON)
                     {tr.cells[RONIndex].innerHTML=strResult[1];return false;}
              }
           }
     }else {alert(strResult[1]);}
}
// window.prompt('please write a new Releasing Order No：','您输入的值');
}
//lzw091012
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
        var txt=strRel[0]=="&nbsp;"?" ":strRel[0];
            txt=txt.replace('amp;','');
          objCode.value=strRel[0];
          if(showCode.indexOf("Equipment")>=0)
          {
            var obj=document.getElementById("drPreCoolFlag");
             var bolVal=strRel[0].toLowerCase()=="reffer"?"Y":"N";
             var objFs=document.getElementById("fsPreCool")
             if(bolVal=="Y"){objFs.Style.display="block";}
             else{objFs.style.display="none";}
              for(i=0;i<obj.options.length;i++) 
              {
               if(obj.options[i].value==bolVal)
               {obj.options[i].selected=true;} 
              }
          }
     }
    }
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
    strDetail=document.getElementById("HidEditState").value;
    strDetail=strDetail+ColSeparator+"Releasing@OrderNo"//document.getElementById("txtRON").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipperCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipperName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtEquipmentType").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtQty").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtReleaseQty").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDepotCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtInstructionTD").value;      
    strDetail=strDetail+ColSeparator+document.getElementById("txtTruckerCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtTruckerName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDateCollection").value;
    strDetail=strDetail+ColSeparator+document.getElementById("drPreCoolFlag").value;          
    strDetail=strDetail+ColSeparator+document.getElementById("drPreSetSign").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtPreSetTemp").value;
    strDetail=strDetail+ColSeparator+document.getElementById("drPreSetType").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCommodity").value; 
    strDetail=strDetail+ColSeparator+document.getElementById("drVoltage").value;           
    strDetail=strDetail+ColSeparator+document.getElementById("HidTrxNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("HidLineItemNo").value; 
    strDetail=strDetail+ColSeparator+document.getElementById("txtROReleaseDate").value;    
    return strDetail+ParSeparator;
    //return strDetail;
}
  
function NewDetail(intFlag)
{
  if(intFlag!=2){
    var strDetail="";
    document.getElementById("txtShipperCode").selectedIndex=0;
    document.getElementById("txtShipperName").selectedIndex=0;
    document.getElementById("txtEquipmentType").value="";
    document.getElementById("txtQty").value="";
    document.getElementById("txtReleaseQty").value="";
    document.getElementById("txtDepotCode").value="";
    document.getElementById("txtInstructionTD").selectedIndex=0;
    document.getElementById("txtTruckerCode").value="";
    document.getElementById("txtTruckerName").value="";
    document.getElementById("txtDateCollection").value="";
    document.getElementById("drPreCoolFlag").value="";
    document.getElementById("drPreSetSign").value="";
    document.getElementById("txtPreSetTemp").value="";
    document.getElementById("drPreSetType").value="";
    document.getElementById("txtCommodity").value="";
    document.getElementById("drVoltage").value="";
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
        document.getElementById("HidLineItemNo").value=strResult[3];
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
                  document.getElementById("HidLineItemNo").value=strResult[2];
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
  //txtEquipmentType
  var txt =document.getElementById('txtEquipmentType')
  if (txt.value.Rtrim()=="")
  {
    window.alert("Equipment Type is mandatory.");
    txt.focus();
    return false;
  }  
  //txtQty
  var txt =document.getElementById('txtQty')
  if (txt.value.Rtrim()=="")
  {
    window.alert("Qty is mandatory.");
    txt.focus();
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
  
//  //drPreCoolFlag
//  var txt =document.getElementById('drPreCoolFlag')
//  if (txt.options[txt.selectedIndex].value=="")
//  {
//    window.alert("Pre Cool Flag must input!");
//    txt.focus();
//    return false;
//  }
  return true;
}
//-----------------------------------------------------
function SaveReturn(result,context)
{
    AfterSave();
    var strResult=result.split(ParSeparator);
    switch(strResult.length) 
    {
        case 3:
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
                if (strResult[0]==RtnTimeOut){
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