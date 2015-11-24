<script language ="javascript" type="text/javascript">

function SelectPersonFunction(obj)
{
    var strRoleId = obj.value;
    var strName = obj.name; 
    var strRoleName = obj.innerHTML;
    if (strRoleId) {
        var arg="SelectPersonFunction"+ParSeparator+strRoleId+ParSeparator+strName;
        context="";
        <%= ClientScript.GetCallbackEventReference(Me,"arg","ReturnMessage","context") %>;
    }
}
 
function ReturntheValue(result,context)
{
        AfterSave(); // after reply need enable the button.
        window.alert(result);
        window.close(); 
} 
function ExportToDocument(intId,intType)
{
    var strId=document.getElementById("fldId").value;
    var strTrackNo=document.getElementById("txtTrackNo").value;
    var strName=document.getElementById("txtCompleteByName").value; 
    var strMessage;
    if (intType==0){
       strMessage="Are you sure to Export Document?"
      }
    else if (intType==1){
       strMessage="Are you sure to Export Excel about Table changes?"
      }
    else if (intType==2){
       strMessage="Are you sure to Export Excel?"
    }  
    if (strTrackNo.Rtrim()=="")  {
        window.alert("TrackNo is blank,can't export!");
        return false;
        }  
    if (window.confirm(strMessage)) {
        context = document.getElementById("divAttach");
        BeforeSave(); //before export to document need distable the button 
        var arg = "ExportToDocument"+ParSeparator+GetDetail()+ParSeparator+strTrackNo+ParSeparator+strId+ParSeparator+strName+ParSeparator+intType;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }  
}
function CanConfirmSave()
{
    return true;
}
function GetDetail2()
{
    var strDetail="";
    strDetail="New"; 
    strDetail=strDetail+ColSeparator+document.getElementById("txtPcs1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtWeight1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtLength1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtWidth1").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtHeight1").value;  
    return strDetail; 
}
function GetDetail()
{
    var strDetail="";

    strDetail=document.getElementById("fldId").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtOrderDate").value;
    strDetail=strDetail+ColSeparator+document.getElementById("drpCustomerName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("drpContactName").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipperName").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipperAddress1").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipperAddress2").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipperAddress3").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipperAddress4").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsignessName").value;        
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsigneeAddress1").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsigneeAddress2").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsigneeAddress3").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsigneeAddress4").value;     
    strDetail=strDetail+ColSeparator+document.getElementById("txtOriginCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDestCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtPortOfLoadingCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtlblEtdDate").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtPortOfDischargeCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtlblEtaDate").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtVoyageName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCargoType").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDgFlag").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDeliveryType").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCommodityCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtUomCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtGrossWeight").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtVolume").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtNoOfContainer1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtContainerType1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtNoOfContainer2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtContainerType2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtNoOfContainer3").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtContainerType3").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtPickupDateTime").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCollectFromName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCargoAddress1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCargoAddress2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCargoAddress3").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCargoAddress4").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtSpecialInstruction").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtOrderNo").value;
    //add
    strDetail=strDetail+ColSeparator+document.getElementById("hid_CustomerCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtVoyageNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCommodityName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtPcs").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtMarkNo").value;   
    //090312 byzhiwei
    strDetail=strDetail+ColSeparator+document.getElementById("txtAirPortofDepartureCode").value;   
    strDetail=strDetail+ColSeparator+document.getElementById("txtAirPortDestinationCode").value;   
    strDetail=strDetail+ColSeparator+document.getElementById("txtAlirlineID").value;   
    strDetail=strDetail+ColSeparator+document.getElementById("txtFlightNo").value; 
    strDetail=strDetail+ColSeparator+document.getElementById("hid_moduleCode").value; 
     //090325 byzhiwei for Local Transport
         strDetail=strDetail+ColSeparator+document.getElementById("txtCollectFrom").value; 
         strDetail=strDetail+ColSeparator+document.getElementById("txtDeliverTo").value;          
         strDetail=strDetail+ColSeparator+document.getElementById("txtPickupDateTimeTP").value;
         strDetail=strDetail+ColSeparator+document.getElementById("txtCargoDeliverDateTime").value;
         //adress
         strDetail=strDetail+ColSeparator+document.getElementById("txtDeliverToAddress1").value;        
         strDetail=strDetail+ColSeparator+document.getElementById("txtDeliverToAddress2").value;        
         strDetail=strDetail+ColSeparator+document.getElementById("txtDeliverToAddress3").value;        
         strDetail=strDetail+ColSeparator+document.getElementById("txtDeliverToAddress4").value;        
         strDetail=strDetail+ColSeparator+document.getElementById("txtDescriptionOfGoods1").value;        
         strDetail=strDetail+ColSeparator+document.getElementById("txtDescriptionOfGoods2").value;        
         strDetail=strDetail+ColSeparator+document.getElementById("txtDescriptionOfGoods3").value;        
         strDetail=strDetail+ColSeparator+document.getElementById("txtDescriptionOfGoods4").value;        
         strDetail=strDetail+ColSeparator+document.getElementById("txtDescriptionOfGoods1").value;        
    return strDetail+ParSeparator;
    //return strDetail;
}
  
function NewDetail(intFlag)
{
if(intFlag!=2){
document.getElementById("fldId").value="-1";
document.getElementById("txtOrderDate").value="";
document.getElementById("drpCustomerName").value="";
document.getElementById("drpContactName").value="";
document.getElementById("txtShipperName").value="";  
document.getElementById("txtShipperAddress1").value="";  
document.getElementById("txtShipperAddress2").value="";  
document.getElementById("txtShipperAddress3").value="";    
document.getElementById("txtShipperAddress4").value="";    
document.getElementById("txtConsignessName").value="";        
document.getElementById("txtConsigneeAddress1").value="";    
document.getElementById("txtConsigneeAddress2").value="";    
document.getElementById("txtConsigneeAddress3").value="";    
document.getElementById("txtConsigneeAddress4").value="";     
document.getElementById("txtOriginCode").value="";
document.getElementById("txtOriginName").value="";
document.getElementById("txtDestCode").value="";
document.getElementById("txtDestName").value="";
document.getElementById("txtPortOfLoadingCode").value="";
document.getElementById("txtPortOfLoadingName").value="";
document.getElementById("txtlblEtdDate").value="";
document.getElementById("txtPortOfDischargeCode").value="";
document.getElementById("txtPortOfDischargeName").value="";
document.getElementById("txtlblEtaDate").value="";
document.getElementById("txtVoyageName").value="";
document.getElementById("txtCargoType").value="";
document.getElementById("txtDgFlag").value="";
document.getElementById("txtDeliveryType").value="";
document.getElementById("txtDelivery").value="";
document.getElementById("txtCommodityCode").value="";
document.getElementById("txtUomCode").value="";
document.getElementById("txtGrossWeight").value="";
document.getElementById("txtVolume").value="";
document.getElementById("txtNoOfContainer1").value="";
document.getElementById("txtContainerType1").value="";
document.getElementById("txtNoOfContainer2").value="";
document.getElementById("txtContainerType2").value="";
document.getElementById("txtNoOfContainer3").value="";
document.getElementById("txtContainerType3").value="";
document.getElementById("txtPickupDateTime").value="";
document.getElementById("txtCollectFromName").value="";
document.getElementById("txtCargoAddress1").value="";
document.getElementById("txtCargoAddress2").value="";
document.getElementById("txtCargoAddress3").value="";
document.getElementById("txtCargoAddress4").value="";
document.getElementById("txtSpecialInstruction").value="";
document.getElementById("txtOrderNo").value="";
document.getElementById("hid_CustomerCode").value="";
document.getElementById("txtVoyageNo").value="";
document.getElementById("txtCommodityName").value="";
document.getElementById("txtPcs").value="";
document.getElementById("txtMarkNo").value="";
}
//    if(intFlag==1){
//        context = document.getElementById("divAttach");
//        var arg = "GetNewBookingAttach";
//        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
//    }
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
 

function MultiSelectPerson(txtSelect)
{

    var ret=WindowDialog("../SysRef/MultiPersonList.aspx?Id=",<%=SysMagic.SystemClass.InfoListSize.Width%>,<%=SysMagic.SystemClass.InfoListSize.Height%>);

    if(ret!=null) {
        txtSelect.value=ret[1];
    }
}
//lzw081110
function selBindCode(txtCode,txtName,table,fields,where,showCode,showName)
{
    var ret=WindowDialog("../SysRef/TypeSort.aspx?table="+table+"&fields="+fields+"&where="+where+"&showCode="+showCode+"&showName="+showName,<%=SysMagic.SystemClass.InfoListSize.Width%>,<%=SysMagic.SystemClass.InfoListSize.Height%>);
    if(ret!=null) 
    {
     var strRel=ret.split(ColSeparator);
     if (strRel.length==2) 
     {
       context= document.getElementById("div_drop");
        var txt=strRel[1]=="&nbsp;"?" ":strRel[1];
            txt=txt.replace('amp;','');
          txtName.value=txt;
          txtCode.value=strRel[0];
          if(showCode=="Customer Code")
          {
            var arg = "BindDropDown"+ParSeparator+strRel[0]+ParSeparator+strRel[1];
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetContactReturnValue", "context")%>;
          }
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
function CheckValue(objCon,strFieldName,strTable)
{
    var strFieldVal=document.getElementById(objCon).value;
    if (strFieldVal!="")
    {
        context=objCon;
        BeforeSave();
        var arg = "CheckVal"+ParSeparator+strFieldName+ParSeparator+strFieldVal+ParSeparator+strTable;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function CanSave()
{
 return true;
}
function FocusControlDimension(event,Prev,Next)
{
                   if((event.keyCode==13)||(event.keyCode==0x28)) 
                   {
                        if(Next!=null) {
                            if(!Next.disabled && Next.style.display!="none"){
                                event.returnValue=false;
                                Next.focus();
                                if (Next.type=="text") {
//                                    var r =Next.createTextRange();
//                                    r.moveStart("character",Next.value.length);
//                                    r.collapse(true);
//                                    r.select();
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