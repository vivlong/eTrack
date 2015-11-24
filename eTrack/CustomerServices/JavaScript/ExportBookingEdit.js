<script language ="javascript" type="text/javascript">
//--------------------------------------------------------------------------------------------
blChanged=true;
        function PrintDetail(intId, Reports) {
            var strUrl = "";
            intId=document.getElementById("fldId").value;
            var strReport = document.getElementById("hidReports").value;
            var arrReport = strReport.split(",");
            if (intId == "-1") { return false; }
            if (Reports == "") { alert("There are Not Reports in the Server."); return false; }
            if (arrReport.length!=1) {
                var strUrl = "../loading.aspx?tourl=CustomerServices/SelectReportEdit.aspx?id=" + intId;
               var ret=WindowDialog(strUrl,400,300);
               if(ret!=null){}
            }
            else {
                strUrl = "../loading.aspx?tourl=CustomerServices/SelectReportEdit.aspx?id=" + intId;
                var strUrl = "../loading.aspx?tourl=Print/crBooking.aspx?Id=" + intId + "&Report=" + arrReport[0];
                window.open(strUrl);
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
function GetDetail()
{
    var strDetail="";
    strDetail=$("#fldId").val();
    strDetail=strDetail+ColSeparator+$("#BookingDateTimeSelect_txtDateTime").val();
    strDetail=strDetail+ColSeparator+$("#txtBookingNo").val();  
    strDetail=strDetail+ColSeparator+$("#txtCustomerName").val();  
    strDetail=strDetail+ColSeparator+$("#ContactNameSelect_txtName").val();  
    strDetail=strDetail+ColSeparator+$("#TelephoneSelect_txtName").val();  
    strDetail=strDetail+ColSeparator+$("#VesselSelect_txtCode").val();    
    strDetail=strDetail+ColSeparator+$("#VesselSelect_txtName").val();    
    strDetail=strDetail+ColSeparator+$("#txtVoyage").val();        
    strDetail=strDetail+ColSeparator+$("#ETDSelect_txtDateTime").val();
    strDetail=strDetail+ColSeparator+$("#ETASelect_txtDateTime").val();    
    strDetail=strDetail+ColSeparator+$("#PortofDischargeSelect_txtCode").val();    
    strDetail=strDetail+ColSeparator+$("#PortofDischargeSelect_txtName").val();     
    strDetail=strDetail+ColSeparator+$("#DestSelect_txtCode").val();
    strDetail=strDetail+ColSeparator+$("#DestSelect_txtName").val();
    strDetail=strDetail+ColSeparator+$("#drpCargoType").val();
    strDetail=strDetail+ColSeparator+$("#drpDgFlag").val();
    strDetail=strDetail+ColSeparator+$("#CommoditySelect_txtCode").val();
    strDetail=strDetail+ColSeparator+$("#CommoditySelect_txtName").val();
    strDetail=strDetail+ColSeparator+$("#txtPcs").val();
    strDetail=strDetail+ColSeparator+$("#txtGrossWeight").val();
    strDetail=strDetail+ColSeparator+$("#txtVolume").val();
    strDetail=strDetail+ColSeparator+$("#txtFooter1").val();
    strDetail=strDetail+ColSeparator+$("#hidSeblTrxNo").val();
    strDetail=strDetail+ColSeparator+"";
    strDetail=strDetail+ColSeparator+"";
    strDetail=strDetail+ColSeparator+"";
    return strDetail+ParSeparator+$("#txtBookingNo").val();
    //return strDetail;
}
  
function NewDetail(intFlag)
{
if(intFlag!=2){
$("#fldId").val("-1");
$("#txtTrxNo").val("");
$("#BookingDateTimeSelect_txtDateTime").val("");
$("#txtBookingNo").val("");
$("#txtCustomerName").val("");  
$("#ContactNameSelect_txtName").val("");  
$("#TelephoneSelect_txtName").val("");  
$("#VesselSelect_txtCode").val("");    
$("#VesselSelect_txtName").val("");    
$("#txtVoyage").val("");        
$("#ETDSelect_txtDateTime").val("");    
$("#ETASelect_txtDateTime").val("");    
$("#PortofDischargeSelect_txtCode").val("");    
$("#PortofDischargeSelect_txtName").val("");     
$("#DestSelect_txtCode").val("");
$("#DestSelect_txtName").val("");
$("#drpCargoType").val("");
$("#drpDgFlag").val("");
$("#CommoditySelect_txtCode").val("");
$("#CommoditySelect_txtName").val("");
$("#txtPcs").val("");
$("#txtGrossWeight").val("");
$("#txtVolume").val("");
$("#txtFooter1").val("");
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
function SaveBookingDetail(strTitle,intFlag)
{
       if (!StrToBool(SavePrompt) || window.confirm(ConfirmSave.replace("{0}",strTitle))) 
          { 
           if (!CanSave()) 
           {return;}
            if(document.frmBookingFormEdit.txtFooter1.value.length>80)
            {
                alert('Remark should be less than 80 words！');
                document.frmBookingFormEdit.txtFooter1.select();
                return;
            }
           context=intFlag;
           BeforeSave();
           var arg = "SaveData"+ParSeparator+GetDetail();
           <%= ClientScript.GetCallbackEventReference(Me, "arg", "SaveBooking", "context")%>;
          }
      else{
           if(intFlag) {NewDetail(1);}
           else {window.close();}
          }
}
function SaveBooking(result,context)
{
    AfterSave();
    var strResult=result.split(ParSeparator);

            if (strResult[0]==RtnOk) 
            {
                blChanged=true;
                if(strResult[2]!="-1"){
                document.getElementById("fldId").value=strResult[2];
                $("#txtTrxNo").val(strResult[2]);
                $("#txtBookingNo").val(strResult[3]);
                }
                alert(strResult[1]);
             }
        else {
                window.alert(strResult[1]);
                if (strResult[0]==RtnTimeOut) {CloseWindow();}
             }
}
function setToUpperCase(Tobj)
{
Tobj.value=Tobj.value.toUpperCase();
}
</script>