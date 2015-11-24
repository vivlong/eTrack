<script language ="javascript" type="text/javascript">
function SetSourceValue(result, context) 
{  
    HideLoadingData();
    arrTmp = result.split(ParSeparator);
    if(arrTmp.length==2 && arrTmp[1]!=null && arrTmp[1]!=""){
        intCount=arrTmp[0];
        if(intPage>intCount && intPage!=1){
            intPage=intCount;
        }
        context.innerHTML = arrTmp[1];
        if(document.getElementById("lblPage"))
        { var lbl=document.getElementById("lblPage");
        lbl.innerHTML = PageTitle + intPage.toString() + PageSeparator + intCount.toString();
        var txt=document.getElementById("txtPage");
        txt.value=intPage.toString();
        }
        var gsum=0;
     var t   =   document.getElementById( "<%=gvwSource.ClientID%>") ;
var   cellNum   = 11  ; 
for(i   =  1;i <t.rows.length;i++) 
{ 
  //alert(t.rows[i].cells[cellNum].innerHTML) 
  inputs   =   t.rows[i].cells[cellNum].innerText ;
  //alert(inputs.value) 
  if(inputs!="")
  {  gsum+=parseFloat(inputs);
  }

}
 var txt=document.getElementById("txtGrandTotal");
        txt.value=gsum.toString();

        return true;
    }
     else if(arrTmp.length==4 && arrTmp[1]!=null && arrTmp[1]!=""){
        intCount=arrTmp[1];
        if(intPage>intCount && intPage!=1){
            intPage=intCount;
        }
        context.innerHTML = arrTmp[2];
        if(document.getElementById("lblPage"))
        { var lbl=document.getElementById("lblPage");
        lbl.innerHTML = PageTitle + intPage.toString() + PageSeparator + intCount.toString();
        var txt=document.getElementById("txtPage");
        txt.value=intPage.toString();
        }
       
        return true;
    }
    else{
        return false;
    }
} 
   function ChgUrgAttribute(aFlag) {
        if (aFlag == 1) {
            document.getElementById("txtUrgentRemark").value = "";
            document.getElementById("txtUrgentRemark").readOnly = true;
        }
        else if (aFlag == 2) {
            document.getElementById("txtUrgentRemark").readOnly = false;
        }
    }
function setDefaultShipTo(obj)
{

  if(obj.checked==true)
  {
    document.getElementById("txtCompanyName").value=strCompanyName;
    document.getElementById("txtLastName").value=strLastName;
    document.getElementById("txtAddress2").value=strAddress2;
    document.getElementById("txtState").value=strState;
    var drCountry =document.getElementById("drCountry");
    drCountry.options.value=strCountry;
    document.getElementById("txtFax").value=strFax;
    document.getElementById("txtFirstName").value=strFirstName;
    document.getElementById("txtAddress").value=strAddress;
    var drCity =document.getElementById("drCity");
    drCity.options.value=strCity;
    document.getElementById("txtPostalCode").value=strPostalCode;
    document.getElementById("txtPhone").value=strPhone;
    document.getElementById("txtEmailAddress").value=strEmailAddress;
    document.getElementById("txtContactPerson").value=strContactName;
document.getElementById("txtShipToName").value=strCompanyName;
document.getElementById("txtShipToAddress1").value=strAddress1;
document.getElementById("txtShipToAddress2").value=strAddress2;
document.getElementById("txtShipToAddress3").value=strAddress3;
document.getElementById("txtShipToAddress4").value=strAddress4;
document.getElementById("txtShipToEmail").value=strEmailAddress;
document.getElementById("txtShipToPhone2").value=strPhone;
document.getElementById("txtShipToFax2").value=strFax;
SetCity(drCity,drCountry);
  }
  else
  {
    document.getElementById("txtCompanyName").value="";
    document.getElementById("txtLastName").value="";
    document.getElementById("txtAddress2").value="";
    document.getElementById("txtState").value="";
    var drCountry =document.getElementById("drCountry");
    drCountry.value='-1';
    document.getElementById("txtFax").value="";
    document.getElementById("txtFirstName").value="";
    document.getElementById("txtAddress").value="";
    var drCity =document.getElementById("drCity");
    drCity.value='-1';
    document.getElementById("txtPostalCode").value="";
    document.getElementById("txtPhone").value="";
    document.getElementById("txtEmailAddress").value="";
    document.getElementById("txtContactPerson").value="";
document.getElementById("txtShipToName").value="";
document.getElementById("txtShipToAddress1").value="";
document.getElementById("txtShipToAddress2").value="";
document.getElementById("txtShipToAddress3").value="";
document.getElementById("txtShipToAddress4").value="";
document.getElementById("txtShipToEmail").value="";
document.getElementById("txtShipToPhone2").value="";
document.getElementById("txtShipToFax2").value="";
SetCity(drCity,drCountry);
  }
}

//GetDetail
function GetDetail()
{
    var strDetail="";
    strDetail=document.getElementById("fldId").value;
    //ship to info
    strDetail=strDetail+ColSeparator+document.getElementById("txtCompanyName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtFirstName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtAddress").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("drCity").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtPostalCode").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtPhone").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtEmailAddress").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtLastName").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtAddress2").value;        
    strDetail=strDetail+ColSeparator+document.getElementById("txtState").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("drCountry").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtFax").value;
      if(  divTop.style.display=="none")
      {
          strDetail=strDetail+ColSeparator+document.getElementById("txtPortOfLoading2").value;
  strDetail=strDetail+ColSeparator+document.getElementById("txtPortOfDischarge2").value;
  }
  else{  strDetail=strDetail+ColSeparator+document.getElementById("txtPortOfLoading").value;
  strDetail=strDetail+ColSeparator+document.getElementById("txtPortOfDischarge").value;
    
  }
    //po info
    strDetail=strDetail+ColSeparator+document.getElementById("txtPurchaseOrderNumber").value;    
    obj=document.getElementById("drCurrency");
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;
    obj=document.getElementById("drIncoTerms");
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;
     obj=document.getElementById("drTermCity");
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value; 
    strDetail=strDetail+ColSeparator+document.getElementById("txtPurchaseOrderAmount").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtIssueDate").value;
    strDetail=strDetail+ColSeparator+document.getElementById("drModeofTransport").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtInvoiceNumber").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDescription").value;
    //supplier Info-12
    var obj=document.getElementById("drSupplier");
    if(obj.value=="" && divNewSupplier.style.display=="block" )
    {
        strDetail=strDetail+ColSeparator+document.getElementById("txtCompanyName1").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtFirstName1").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtLastName1").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtAddress1").value; 
        strDetail=strDetail+ColSeparator+document.getElementById("txtAddress21").value;
        obj=document.getElementById("drCity1");
        strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;   
        strDetail=strDetail+ColSeparator+document.getElementById("txtState1").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtPostalCode1").value;   
        obj=document.getElementById("drCountry1");
        strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;  
        strDetail=strDetail+ColSeparator+document.getElementById("txtPhone1").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtFax1").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtEmailAddress1").value;       
    }
    else if(obj.value=="" && divNewSupplier.style.display=="none")
    {
        strDetail=strDetail+ColSeparator+"";
        strDetail=strDetail+ColSeparator+"";
        strDetail=strDetail+ColSeparator+"";
        strDetail=strDetail+ColSeparator+"";
        strDetail=strDetail+ColSeparator+"";
        strDetail=strDetail+ColSeparator+"";
        strDetail=strDetail+ColSeparator+"";
        strDetail=strDetail+ColSeparator+"";
        strDetail=strDetail+ColSeparator+"";
        strDetail=strDetail+ColSeparator+"";
        
        strDetail=strDetail+ColSeparator+"";
        strDetail=strDetail+ColSeparator+"";
    }
    else if(obj.value!="" && divNewSupplier.style.display=="none")
    {
      var strhidSupplier="";
      strhidSupplier=document.getElementById("hidSupplier").value;
      var arrSupplier=strhidSupplier.split(',');
        strDetail=strDetail+ColSeparator+arrSupplier[0];
        strDetail=strDetail+ColSeparator+arrSupplier[1];
        strDetail=strDetail+ColSeparator+arrSupplier[2];
        strDetail=strDetail+ColSeparator+arrSupplier[3];
        strDetail=strDetail+ColSeparator+arrSupplier[4];
        strDetail=strDetail+ColSeparator+arrSupplier[5];
        strDetail=strDetail+ColSeparator+arrSupplier[6];
        strDetail=strDetail+ColSeparator+arrSupplier[7];
        strDetail=strDetail+ColSeparator+arrSupplier[8];
        strDetail=strDetail+ColSeparator+arrSupplier[9];
        strDetail=strDetail+ColSeparator+arrSupplier[10];
        strDetail=strDetail+ColSeparator+arrSupplier[11];
    } 
     if( divTop.style.display=="none")
    {

     
    strDetail=strDetail+ColSeparator+"";
      strDetail=strDetail+ColSeparator+document.getElementById("txtShipToCompany").value.toString().replace(chr(13)+chr(10),ColSeparator);
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipToAddress").value;
  strDetail=strDetail+ColSeparator+document.getElementById("txtEmail").value;
  strDetail=strDetail+ColSeparator+document.getElementById("txtShipToPhone").value;
  strDetail=strDetail+ColSeparator+document.getElementById("txtShipToFax").value;
    }
    else{  strDetail=strDetail+ColSeparator+document.getElementById("txtContactPerson").value;
  strDetail=strDetail+ColSeparator+document.getElementById("txtShipToName").value;
  strDetail=strDetail+ColSeparator+document.getElementById("txtShipToAddress1").value;
  strDetail=strDetail+ColSeparator+document.getElementById("txtShipToAddress2").value;
  strDetail=strDetail+ColSeparator+document.getElementById("txtShipToAddress3").value;
  strDetail=strDetail+ColSeparator+document.getElementById("txtShipToAddress4").value;
  strDetail=strDetail+ColSeparator+document.getElementById("txtShipToEmail").value;
  strDetail=strDetail+ColSeparator+document.getElementById("txtShipToPhone2").value;
  strDetail=strDetail+ColSeparator+document.getElementById("txtShipToFax2").value;
    }
        strDetail=strDetail+ColSeparator+getRadioButtonSelectedValue("rbPartial");  
             if(  divTop.style.display=="none")
      {
       strDetail=strDetail+ColSeparator+document.getElementById("txtETA2").value;
              strDetail=strDetail+ColSeparator+document.getElementById("txtETD2").value;
                    strDetail=strDetail+ColSeparator+document.getElementById("txtRequiredDate2").value;
      }
      else{
        strDetail=strDetail+ColSeparator+document.getElementById("txtETA").value;
              strDetail=strDetail+ColSeparator+document.getElementById("txtETD").value;
                    strDetail=strDetail+ColSeparator+document.getElementById("txtRequiredDate").value;
      }
        strDetail=strDetail+ColSeparator+"";
        strDetail=strDetail+ColSeparator+""; 
        strDetail=strDetail+ColSeparator+"";
        strDetail=strDetail+ColSeparator+"";
        strDetail=strDetail+ColSeparator+""; 
      
    return strDetail;
}
function getRadioButtonSelectedValue(rdbtnName)   
 {
    var obj;
    obj=document.getElementsByName(rdbtnName);
    for(var i=0;i<obj.length;i++){   
        if(obj[i].checked == true){   
            return  obj[i].value;
            break;
        }   
    }
    return ""; 
}
//GetDetail
function GetPOInfoDetail()
{
    var strDetail="";
    //ship to info
    strDetail=strDetail+ColSeparator+document.getElementById("txtValue").value;
    obj=document.getElementById("drPOCurrCode");
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;
    obj=document.getElementById("drIncoterms2");
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;      
    obj=document.getElementById("drStatus");
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDescription1").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtIssueDate2").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipDate").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtRequestionDate").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtReceivedDate").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtVendorReceivedDate").value;
     
    obj=document.getElementById("drTermCity2");
  
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;  
    if(divTop.style.display=="none")
      {
          strDetail=strDetail+ColSeparator+document.getElementById("txtPortOfLoading2").value;
  strDetail=strDetail+ColSeparator+document.getElementById("txtPortOfDischarge2").value;
  }
  else{  strDetail=strDetail+ColSeparator+document.getElementById("txtPortOfLoading").value;
  strDetail=strDetail+ColSeparator+document.getElementById("txtPortOfDischarge").value;
    
  }
    if(  divTop.style.display=="none")
      {
       strDetail=strDetail+ColSeparator+document.getElementById("txtETA2").value;
              strDetail=strDetail+ColSeparator+document.getElementById("txtETD2").value;
                    strDetail=strDetail+ColSeparator+document.getElementById("txtRequiredDate2").value;
      }
      else{
        strDetail=strDetail+ColSeparator+document.getElementById("txtETA").value;
              strDetail=strDetail+ColSeparator+document.getElementById("txtETD").value;
                    strDetail=strDetail+ColSeparator+document.getElementById("txtRequiredDate").value;
      }
    return strDetail;
}
function GetSupplierDetail()
{
    var strDetail="";
    //ship to info
    strDetail=strDetail+ColSeparator+document.getElementById("txtSupplierCompanyName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtSupplierAdderss").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtSupplierPhone").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtSupplierFax").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtSupplierEmail").value;    
    return strDetail;
}
function GetShipToDetail()
{
    var strDetail="";
    //ship to info
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipToCompany").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipToAddress").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipToPhone").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipToFax").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtEmail").value;    
    return strDetail;
}
function NewDetail(intFlag)
{
}
function SetOtherSaveReturn(strResult)
{
    if(strResult.length==3){alert(strResult[1]);
    CloseWindow();
    }
}
//CanSave
function CanSave()
{
    var txt;
    txt=document.getElementById("txtCompanyName");
    if (txt.value.Rtrim()=="") {
        window.alert("Company Name must input!");
        txt.focus();
        return false;
    }
    txt=document.getElementById("txtAddress");
    if (txt.value.Rtrim()=="") {
        window.alert("Address must input!");
        txt.focus();
        return false;
    }   
    txt=document.getElementById("txtPurchaseOrderNumber");
    if (txt.value.Rtrim()=="") {
        window.alert("Purchase Order Number must input!");
        txt.focus();
        return false;
    }   
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
function SetTab(intTab)
{
  strHidCon1=intTab.toString();
}
function  textCounter(event,obj,intPar)  
{        
  if(obj.value.length>=intPar)   
  {   
      event.keyCode   =   0;   
      return;   
  }   
}
</script>