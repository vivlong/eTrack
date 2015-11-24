<script language ="javascript" type="text/javascript">


//GetDetail
function GetDetail()
{
    var strDetail="";
    strDetail=document.getElementById("fldId").value;
    //Item Information
    strDetail=strDetail+ColSeparator+document.getElementById("txtLineItemNumber").value;
    obj=document.getElementById("drPartNumber");
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtPartDescription").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtHarmonizeCode").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtHarmonizeDescription").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtUnitPrice").value;
    obj=document.getElementById("drCurrency");
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtSupplierPartNumber").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtQuantity").value;  
    obj=document.getElementById("drQuantity");
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtNetWeight").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtGrossWeight").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtTagNumber").value;
    //Shipping Information
    strDetail=strDetail+ColSeparator+document.getElementById("txtInsuranceValue").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtDateRequested").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtLastestDeliveryDate").value;
    obj=document.getElementById("drModeofTransport");
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;  
    obj=document.getElementById("drStatus");
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;  
    //Package Information
    obj=document.getElementById("drUnitofMeasurement");
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;   
    strDetail=strDetail+ColSeparator+document.getElementById("txtLength").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtWidth").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtHeight").value; 
    strDetail=strDetail+ColSeparator+document.getElementById("txtWeight").value;
    obj=document.getElementById("drWeight");
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;   
    strDetail=strDetail+ColSeparator+document.getElementById("txtDescription").value;
    strDetail=strDetail+ColSeparator+document.getElementById("fldPoTrxNo").value;
    strDetail=strDetail+ColSeparator+"";
    strDetail=strDetail+ColSeparator+"";
    strDetail=strDetail+ColSeparator+"";
    return strDetail;
}
//GetDetail
function GetItemDetail()
{
    var strDetail="";
    //Item info
    strDetail=strDetail+ColSeparator+document.getElementById("txtPartNumber2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtItemDescription1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtSupplierPartNumber2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("drCurrency1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtUnitPrice2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtHarmonizedCode2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDescription2").value;
    strDetail=strDetail+ColSeparator+getRadioButtonSelectedValue("rbHazardous1");
    strDetail=strDetail+ColSeparator+document.getElementById("txtTagNumber2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtQuatityOrdered2").value;
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
function GetShippingDetail()
{
    var strDetail="";
    //Shipping info
    strDetail=strDetail+ColSeparator+document.getElementById("txtInsuranceValue2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDateRequested2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtLatestDeliveryDate2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDateRequiredatSite2").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtEstimatedTimeofArrival2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("drStatus2").value;
    return strDetail;
}
function GetPackageDetail()
{
    var strDetail="";
    //Package info
    strDetail=strDetail+ColSeparator+document.getElementById("txtUnitofMeasurement2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtLength2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtWidth2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtHeight2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtWeight2").value;
    return strDetail;
}
function GetShipToDetail()
{
    var strDetail="";
    //ShipTo info
    strDetail=strDetail+ColSeparator+document.getElementById("txtCompanyName2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtName2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtAddress1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtAddress2").value;
        obj=document.getElementById("drCity2");
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtState2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtPostal2").value;
        obj=document.getElementById("drCountry2");
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtPhone2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtFax2").value;
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
</script>