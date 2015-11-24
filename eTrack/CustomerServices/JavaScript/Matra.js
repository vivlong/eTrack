<script language ="javascript" type="text/javascript">
//List Page

    var blnFlag=false;      //check if call CheckValid function
    
    function EditDetail(intId)
    {
        var ret;
        if (EditPage.indexOf(".aspx?")>0){
            ret=WindowDialog(EditPage+"&Id="+intId.toString(),EditWidth,EditHeight);
        }
        else{
            ret=WindowDialog(EditPage+"?Id="+intId.toString(),EditWidth,EditHeight);
        }
        if (ret==RtnOk) {
            GetPageData(null,-1)
        }
    }
    
    function InsertDetail()
    {
        var ret=WindowDialog(EditPage,EditWidth,EditHeight);
        if (ret==RtnOk) 
        {
            GetPageData(null,-1)
        }
    }

//Edit Page    
    function selBindCode(txtCode,txtName,table,fields,where,showCode,showName)
    {
        var ret=WindowDialog("../SysRef/TypeSort.aspx?table="+table+"&fields="+fields+"&where="+where+"&showCode="+showCode+"&showName="+showName,<%=SysMagic.SystemClass.InfoListSize.Width%>,<%=SysMagic.SystemClass.InfoListSize.Height%>);
        if(ret!=null) 
        {
         var strRel=ret.split(ColSeparator);
         if (strRel.length==2) 
         {
//            context= document.getElementById("div_drop");
            var txt=strRel[1]=="&nbsp;"?" ":strRel[1];
                txt=txt.replace('amp;','');
              txtName.value=txt;
              txtCode.value=strRel[0];
//              if(showCode=="Customer Code")
//              {
//                var arg = "BindDropDown"+ParSeparator+strRel[0]+ParSeparator+strRel[1];
//                <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetContactReturnValue", "context")%>;
//              }
         }
        }
    }
    
//    function SetContactReturnValue(result,context) 
//    { 
//        var strResult=result.split(ParSeparator);
//        if (strResult[0]==RtnOk) {
//            context.innerHTML = strResult[1]+strResult[2]+strResult[3];
//        }
//        else if (strResult[1]!=""){
//            window.alert(strResult[1]);
//        }
//    }

    function ChangeStatus()
    {
        if(document.getElementById("txtStatus").value!="In-Progress")
        {
            document.getElementById("txtStatus").value = "In-Progress";
        }
    }

    function CheckRfqNo()
    {
        var obj=document.getElementById("txtRfqNo");
        
        if(obj.value.Trim().length==0)
        {
            obj.focus();
        }
        else
        {
            //check if exists the RfqNo
            context = document.getElementById("txtRfqNo");
            var arg = "CheckRfqNo"+ParSeparator+obj.value.Trim();
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "CheckReturn", "context")%>;
        }
    }
    function CheckReturn(result,context) 
    { 
        var strResult=result.split(ParSeparator);
        if (strResult[0]==RtnError&&document.getElementById("fldId").value.Trim().length==0) {
            alert(strResult[1]);
            context.focus();
            return false;
        }
    }
    
    function SaveJob(strTitle,intFlag)
    {
//        alert(strTitle+":"+intFlag);
        var strkey=document.getElementById("txtRfqNo").value.Trim();
        alert(strkey.length);
        if(strkey.length==0)
        {
            alert("Rfq No must be entered.");
            return false;
        }
        if(!CheckRfqNo){return false;}
        if (!StrToBool(SavePrompt) || window.confirm(ConfirmSave.replace("{0}",strTitle))) 
        {
            context=intFlag;
            BeforeSave();
            var arg = "SaveData"+ParSeparator+GetDetail();
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SaveReturn", "context")%>;
//        }
//        else
//        {
//            if(intFlag) {NewDetail(1);}
//            else {window.close();}
        }
    }
    
    function GetDetail()
    {
        var strDetail="";
        strDetail=document.getElementById("fldId").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtChargeWeight").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtCommodity").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtConsignmentNote").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtAirportDestOrPod").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtEta").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtEtd").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtFltOrVoyNo").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtGrossWeight").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtHawbOrHblNo").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtLocalMto").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtMawbOrOblNo").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtMro").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtMtoNotification").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtMtoRep").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtAirportDeptOrPol").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtPartNo").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtPickupDate").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtPickupFrom").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtFinalPlaceOfDelivery").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtDestEta").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtQty").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtRfqNo").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtSerialNo").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtShipDate").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtShipTo").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtStatus").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtUom").value;
        alert("aa");
        strDetail=strDetail+ColSeparator+document.getElementById("txtConsignmentDate").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtDateDeliveredToMro").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtDateDeliveredToMtoRep").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtDateReceivedFromMto").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtDateReceivedFromMtoRep").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtDriveric1").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtDriveric2").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtDriveric3").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtDriverName1").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtDriverName2").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtDriverName3").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtQuotationRefNo").value;
        strDetail=strDetail+ColSeparator+document.getElementById("txtTearDownInspectionDate").value;
        
        return strDetail+ParSeparator;
    }
    
    function SaveReturn(result,context)
    {
        AfterSave();
        var strResult=result.split(ParSeparator);
        if (strResult[0]==RtnOk)
        {
            blChanged=true;
            document.getElementById("txtRfqNo").readOnly=true;
            document.getElementById("fldId").value=document.getElementById("txtRfqNo").value;
        }
        alert(strResult[1]);
    }
    
    function BeforeSave()
    {
        document.getElementById("btnNew").disabled=true;
        document.getElementById("btnSave").disabled=true;
        document.getElementById("btnExit").disabled=true;
    }
    function AfterSave()
    {
        document.getElementById("btnNew").disabled=false;
        document.getElementById("btnSave").disabled=false;
        document.getElementById("btnExit").disabled=false;
    }
    
    function CloseJob()
    {
        var strId=document.getElementById("fldId").value;
        if (strId.length<=0)
        {
            alert("Please save the Job before close.");
            return false;
        }
        if (window.confirm("Are you sure to close this job?")) 
        {
            context = document.getElementById("txtStatus");
            var arg = "CloseJob"+ParSeparator+strId.toString();
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetCloseStatus", "context")%>;
        }
    }
    
    function SetCloseStatus(result,context) 
    { 
        var strResult=result.split(ParSeparator);
        if (strResult[0]==RtnOk) {
            blChanged=true;
            context.value = strResult[1];
            DisabledFields();
        }
        else if (strResult[1]!=""){
        }
    }
    
    function DisabledFields()
    {
        document.getElementById("txtPartNo").readOnly=true;
        document.getElementById("txtSerialNo").readOnly=true;
        document.getElementById("txtMro").readOnly=true;
        document.getElementById("txtMroName").readOnly=true;
        document.getElementById("txtMtoRep").readOnly=true;
        document.getElementById("txtMtoRepName").readOnly=true;
        document.getElementById("btnCloseJob").disabled=true;
        document.getElementById("btnAddStatus").disabled=true;
        document.getElementById("btnMro").disabled=true;
        document.getElementById("btnMtoRep").disabled=true;
        
        document.getElementById("txtDateReceivedFromMto").readOnly=true;
        document.getElementById("btnDateReceivedFromMto").disabled=true;
        document.getElementById("txtDateDeliveredToMro").readOnly=true;
        document.getElementById("btnDateDeliveredToMro").disabled=true;
        document.getElementById("txtDateReceivedFromMtoRep").readOnly=true;
        document.getElementById("btnDateReceivedFromMtoRep").disabled=true;
        document.getElementById("txtDateDeliveredToMtoRep").readOnly=true;
        document.getElementById("btnDateDeliveredToMtoRep").disabled=true;
        document.getElementById("txtTearDownInspectionDate").readOnly=true;
        document.getElementById("btnTearDownInspectionDate").disabled=true;
        document.getElementById("txtQuotationRefNo").readOnly=true;

        //Matra
        document.getElementById("txtMtoNotification").readOnly=true;
        document.getElementById("txtLocalMto").readOnly=true;
        document.getElementById("txtLocalMtoName").readOnly=true;
        document.getElementById("txtConsignmentDate").readOnly=true;
        document.getElementById("txtPickupFrom").readOnly=true;
        document.getElementById("txtPickupDate").readOnly=true;
        document.getElementById("txtShipTo").readOnly=true;
        document.getElementById("txtShipDate").readOnly=true;
        document.getElementById("txtConsignmentNote").readOnly=true;
//        document.getElementById("txtMtoRep").readOnly=true;
        document.getElementById("txtMtoRepName").readOnly=true;
//        document.getElementById("txtMro").readOnly=true;
        document.getElementById("txtMroName").readOnly=true;
        document.getElementById("btnMtoNotification").disabled=false;
        document.getElementById("btnPickupDate").disabled=false;
        document.getElementById("btnShipDate").disabled=false;
        document.getElementById("btnLocalMto").disabled=false;
        document.getElementById("btnMtoRep").disabled=false;
        document.getElementById("btnMro").disabled=false;
        document.getElementById("btnConsignmentDate").disabled=false;

        //Mto 
        document.getElementById("txtDriverName1").readOnly=true;
        document.getElementById("txtDriverName2").readOnly=true;
        document.getElementById("txtDriverName3").readOnly=true;
        document.getElementById("txtDriveric1").readOnly=true;
        document.getElementById("txtDriveric2").readOnly=true;
        document.getElementById("txtDriveric3").readOnly=true;
        document.getElementById("txtCommodity").readOnly=true;
        document.getElementById("txtQty").readOnly=true;
        document.getElementById("txtUom").readOnly=true;
        document.getElementById("txtGrossWeight").readOnly=true;
        document.getElementById("txtChargeWeight").readOnly=true;
        document.getElementById("txtMAwbOrOBlNo").readOnly=true;
        document.getElementById("txtHAwbOrHBlNo").readOnly=true;
        document.getElementById("txtFltOrVoyNo").readOnly=true;
        document.getElementById("txtAirportDeptOrPol").readOnly=true;
        document.getElementById("txtEtd").readOnly=true;
        document.getElementById("txtAirportDestOrPod").readOnly=true;
        document.getElementById("txtEta").readOnly=true;
        document.getElementById("txtFinalPlaceOfDelivery").readOnly=true;
        document.getElementById("txtDestEta").readOnly=true;
        document.getElementById("btnUom").disabled=false;
        document.getElementById("btnEta").disabled=false;
        document.getElementById("btnEtd").disabled=false;
        document.getElementById("btnDestEta").disabled=false;
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
    
    function CheckValid(strTable,strFieldName,strControl,strWhere,strErrMessage)
    {
        if(blnFlag){return false;}
        blnFlag=true;
        context=strControl;
        var arg = "CheckValid"+ParSeparator+strTable+ParSeparator+strFieldName+ParSeparator+strControl.value+ParSeparator+strWhere+ParSeparator+strErrMessage;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "CheckValidReturn", "context")%>;
    }
    
    function CheckValidReturn(result,context)
    {
        var strResult=result.split(ParSeparator);
        if(strResult[0]==RtnOk)
        {
            //do nothing
        }
        else
        {
            alert(strResult[1]);
            context.focus();
        }
        blnFlag=false;
    }
    
    
    
//Jmar2
    //Delete
    function DeleteJmar2(strRefNo,intLineItemNo)
    {
        return false;
    }
    
    //Insert
    function InsertJmar2()
    {
        if(document.getElementById("fldId").value.Trim().length==0)
        {
            alert("Please save the Job before Add Status.");
            return false;
        }
//        var ret;
//        ret=WindowDialog("AddStatus.aspx?RfqNo="+document.getElementById("fldId").value.toString(),350,290);
        var strId=document.getElementById("fldId").value;
        var ret=WindowDialog("AddStatus.aspx?RfqNo="+strId,350,290);
        if(ret!=null && ret!=""){
            context=divMiddle13;
            var arg = "RefreshGrid"+ParSeparator+strId.toString();; 
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "ReturnJmar2Value", "context")%>;
        }
    }
    
    //Edit
    function EditJmar2(strRefNo,intLineItemNo)
    {
        return false;
    }
    
    function ReturnJmar2Value(result,context) 
    { 
        strResult=result.split(ParSeparator);
        if (strResult[0]==RtnOk) {
            context.innerHTML = strResult[1];
        }
        else if (strResult[1]!="")
        {
            window.alert(strResult[1]);
        }
    }
    
    
</script>