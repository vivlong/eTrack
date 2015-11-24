<script language ="javascript" type="text/javascript">
    function DataBaseChange(obj) {
        if ($(obj).val() == ""){ return false;}
        arrPara = $(obj).val();
        context = null;
        var arg = "DataBaseChange"+ParSeparator+arrPara;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetDataBaseChange", "context")%>; 
    }
    function SetDataBaseChange(result, context)
    {
      strResult=result.split(ParSeparator);
      if (strResult[0]!=RtnOk){ 
          //window.alert(strResult[1]);
          layer.open({type: 0, title: false, content: strResult[1], btn: 'OK', icon: 5});
      }
    }
    function Advance(objAdvance)
    {
     if($("#divLanguage").is(":visible"))
     {
       $("#divLanguage").hide();
       $("#divDataBase").hide();
       $(objAdvance).text("Advance");
     }
     else
     {
       $("#divLanguage").show();
       $("#divDataBase").show();
       $(objAdvance).text("Simple");
     }
       $("#btnLogin").focus();
    }
    //110123 add Salling Schedule Logic
    function ShowVesselList() {
        if ($("#drPort").val() == ""){
            //alert("Port must be input!");
            layer.open({type: 0, title: false, content: 'Port must be input!', btn: 'OK', icon: 5});
            $("#drPort").focus();
            return false;
        }
        //----------
        arrPara = $("#drPort").val();
        context = null;
        var arg = "SallingCheck"+ParSeparator+arrPara;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetSallingCheck", "context")%>; 
    }
    function SetSallingCheck(result, context){
    strResult=result.split(ParSeparator);
    switch(strResult.length){
        case 2:
            if (strResult[0]==RtnOk){
                OpenWindow("CustomerServices/SelectVessel.aspx?port=" + encodeURIComponent(arrPara),900,630) 
                
            }
            else{
                //window.alert(strResult[1]);
                layer.open({type: 0, title: false, content: strResult[1], btn: 'OK', icon: 5});
            }
            break;
        default:
            //window.alert(strResult[1]);
            layer.open({type: 0, title: false, content: strResult[1], btn: 'OK', icon: 5});
            break;
        }
    }
    function ShowVSList() {
        if ($("#drVSPort").val() == ""){
            //alert("Port must be input!");
            layer.open({type: 0, title: false, content: 'Port must be input!', btn: 'OK', icon: 5});
            $("#drVSPort").focus();
            return false;
        }
        if($("#drVSPort").val() == "All")
        {arrPara=""}
        else
        {arrPara = $("#drVSPort").val();}
         context = null;
        OpenWindow("CustomerServices/SelectVS.aspx?port=" + arrPara,900,630) 
    }
    function isNumber(value)
    {
        if(value ==null){return false;}
        if (value.search("^-?\\d+$") != 0){return false;}
        else{return true;}
    }
    //110123 add Transhipment Track Logic
    function ShowTranshipmentTrack() {
        if ($("#drpTranshipmentTrack").val() == ""){
            //alert("BL No Or Container No must be input!");
            layer.open({type: 0, title: false, content: 'BL No Or Container No must be input!', btn: 'OK', icon: 5});
            $("#drpTranshipmentTrack").focus();
            return false;
        }
        if ($("#txtBLNo").val() == ""){
            //alert("BL No must be input!");
            layer.open({type: 0, title: false, content: 'BL No must be input!', btn: 'OK', icon: 5});
            $("#txtBLNo").focus();
            return false;
        }
        var fileName = $("#drpTranshipmentTrack").val();
        var fileValue = $("#txtBLNo").val();
        /////base on ContainerNo
        if ($("#drpTranshipmentTrack").val() == "ContainerNo")
        {
            var context = null;
            var arg = "TranshipmentTrack"+ParSeparator+fileValue;
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetShowTranshipmentTrack", "context")%>; 
        }
        else
        {
            context = null;
            var arg = "CheckTranshipmentTrack"+ParSeparator+fileName+ParSeparator+fileValue;
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetCheckTranshipmentTrack", "context")%>; 
        }
    }
    function SetCheckTranshipmentTrack(result, context){
        strResult = result.split(ParSeparator);
        switch(strResult.length){
            case 3:
                if (strResult[0]==RtnOk){
                  OpenWindow("CustomerServices/TranshipmentTrack.aspx?fieldName="+strResult[1]+"&fieldValue=" + strResult[2],1000,500);
                }
                else{
                    //alert("Not Record Found!");
                    layer.open({type: 0, title: false, content: 'Not Record Found!', btn: 'OK', icon: 5});
                }
                break;
            default:
                //alert("Not Record Found!");
                layer.open({type: 0, title: false, content: 'Not Record Found!', btn: 'OK', icon: 5});
                break;
        }
    }
    function SetShowTranshipmentTrack(result, context){
    var strResult=result.split(ParSeparator);
    switch(strResult.length){
        case 2:
            if (strResult[0]==RtnOk){
               var trxno= ModalDialog ("UserControl/MoutiTranshipmentTrack.aspx?containerNo="+strResult[1],600,550);
               if(trxno==null){return false;}
               if(isNumber(trxno))
               {OpenWindow("CustomerServices/TranshipmentTrack.aspx?trxno="+trxno,1000,500);}
            }
        case 3:
            
            if (strResult[0]==RtnOk){
              if(strResult[2]==null){return false;}
              var arg = "CheckTranshipmentTrack"+ParSeparator+strResult[1]+ParSeparator+strResult[2];
              <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetCheckTranshipmentTrack", "context")%>; 
            }
            else{
                //alert("Not Record Found!");
            layer.open({type: 0, title: false, content: 'Not Record Found!', btn: 'OK', icon: 5});
        }
            break;
        default:
            //window.alert(strResult[1]);
            layer.open({type: 0, title: false, content: strResult[1], btn: 'OK', icon: 5});
            break;
        }
    }
    //110123 add ImportShipmentStatus Logic
    function ShowImportShipmentStatus() {
        if ($("#drpImportShipment").val() == ""){
            //alert("BL No Or Container No must be input!");
            layer.open({type: 0, title: false, content: 'BL No Or Container No must be input!', btn: 'OK', icon: 5});
            $("#drpImportShipment").focus(); 
            return false;
        }
        if ($("#txtImportShipmentBL").val() == ""){
            //alert("BL No must be input!");
            layer.open({type: 0, title: false, content: 'BL No must be input!', btn: 'OK', icon: 5});
            $("#txtImportShipmentBL").focus();
            return false;
        }
        var fileName = $("#drpImportShipment").val();
        var fileValue = $("#txtImportShipmentBL").val();
        /////base on ContainerNo
        if ($("#drpImportShipment").val() == "ContainerNo")
        {
            context = null;
            var arg = "ImportShipmentStatus"+ParSeparator+fileValue;
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetImportShipmentStatus", "context")%>; 
        }
        else
        {
            context = null;
            var arg = "CheckImportShipment"+ParSeparator+fileName+ParSeparator+fileValue;
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "setCheckImportShipment", "context")%>; 
        }
    }
    function setCheckImportShipment(result, context){
    strResult=result.split(ParSeparator);
    switch(strResult.length){
        case 3:
            if (strResult[0]==RtnOk){
              OpenWindow("CustomerServices/ImportShipmentStatus.aspx?fieldName="+strResult[1]+"&fieldValue=" + strResult[2],900,500) 
            }
            else{
                //alert("Not Record Found!");
                layer.open({type: 0, title: false, content: 'Not Record Found!', btn: 'OK', icon: 5});
            }
            break;
        default:
            //alert("Not Record Found!");
            layer.open({type: 0, title: false, content: 'Not Record Found!', btn: 'OK', icon: 5});
            break;
        }
    }
    //SetImportShipmentStatus
    function SetImportShipmentStatus(result, context){
        strResult=result.split(ParSeparator);
        switch(strResult.length){
            case 2:
                if (strResult[0]==RtnOk){
                   var trxno= ModalDialog ("UserControl/MoutiImportShipmentStatus.aspx?containerNo="+strResult[1],600,550);
                   if(trxno==null){return false;}
                   if(isNumber(trxno))
                   {OpenWindow("CustomerServices/ImportShipmentStatus.aspx?trxno="+trxno,900,500);}
                }
                else{
                    //alert("Not Record Found!");
                    layer.open({type: 0, title: false, content: 'Not Record Found!', btn: 'OK', icon: 5});
                }
                break;
            case 3:
                if (strResult[0]==RtnOk){
                  if(strResult[2]==null){return false;}
                  var arg = "CheckTranshipmentTrack"+ParSeparator+strResult[1]+ParSeparator+strResult[2];
                  <%= ClientScript.GetCallbackEventReference(Me, "arg", "setCheckImportShipment", "context")%>; 
                }
                else{
                    //alert("Not Record Found!");
                    layer.open({type: 0, title: false, content: 'Not Record Found!', btn: 'OK', icon: 5});
                }
                break;
            default:
                //window.alert(strResult[1]);
                layer.open({type: 0, title: false, content: strResult[1], btn: 'OK', icon: 5});
                break;
        }
    }
    //140925 Export Shipment
    function ShowExportShipmentStatus() {
        if ($("#drpExportShipment").val() == ""){
            //alert("BL No Or Container No must be input!");
            layer.open({type: 0, title: false, content: 'BL No Or Container No must be input!', btn: 'OK', icon: 5});
            $("#drpExportShipment").focus();
            return false;
        }
        if ($("#txtExportShipmentBL").val() == ""){
            //alert("BL No must be input!");
            layer.open({type: 0, title: false, content: 'BL No must be input!', btn: 'OK', icon: 5});
            $("#txtExportShipmentBL").focus();
            return false;
        }
        var fileName = $("#drpExportShipment").val();
        var fileValue = $("#txtExportShipmentBL").val();
        /////base on ContainerNo
        if ($("#drpExportShipment").val() == "ContainerNo")
        {
            context = null;
            var arg = "ExportShipmentStatus"+ParSeparator+fileValue;
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetExportShipmentStatus", "context")%>; 
        }
        else
        {
            context = null;
            var arg = "CheckExportShipment"+ParSeparator+fileName+ParSeparator+fileValue;
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "setCheckExportShipment", "context")%>; 
        }
    }
    function setCheckExportShipment(result, context){
        strResult = result.split(ParSeparator);
        switch(strResult.length){
            case 3:
                if (strResult[0]==RtnOk){
                  OpenWindow("CustomerServices/ExportShipmentStatus.aspx?fieldName="+strResult[1]+"&fieldValue=" + strResult[2],900,500) 
                }
                else{
                    //alert("Not Record Found!");
                    layer.open({type: 0, title: false, content: 'Not Record Found!', btn: 'OK', icon: 5});
                }
                break;
            default:
                //alert("Not Record Found!");
                layer.open({type: 0, title: false, content: 'Not Record Found!', btn: 'OK', icon: 5});
                break;
        }
    }
    function SetExportShipmentStatus(result, context){
        strResult = result.split(ParSeparator);
        switch(strResult.length){
            case 2:
                if (strResult[0]==RtnOk){
                   var trxno= ModalDialog ("UserControl/MoutiExportShipmentStatus.aspx?containerNo="+strResult[1],600,550);
                   if(trxno==null){return false;}
                   if(isNumber(trxno))
                   {OpenWindow("CustomerServices/ExportShipmentStatus.aspx?trxno="+trxno,900,500);}
                }
                else{
                    //alert("Not Record Found!");
                    layer.open({type: 0, title: false, content: 'Not Record Found!', btn: 'OK', icon: 5});
                }
                break;
            case 3:
                if (strResult[0]==RtnOk){
                  if(strResult[2]==null){return false;}
                  var arg = "CheckTranshipmentTrack"+ParSeparator+strResult[1]+ParSeparator+strResult[2];
                  <%= ClientScript.GetCallbackEventReference(Me, "arg", "setCheckExportShipment", "context")%>; 
                }
                else{
                    //alert("Not Record Found!");
                    layer.open({type: 0, title: false, content: 'Not Record Found!', btn: 'OK', icon: 5});
                }
                break;
            default:
                //window.alert(strResult[1]);
                layer.open({type: 0, title: false, content: 'Not Record Found!', btn: 'OK', icon: 5});
                break;
        }
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
    function GetLoginValue()
    {
        var strValue="";
        //Type 
        strValue=getRadioButtonSelectedValue("rdbtnType");
        //UserId
        strValue=strValue+ColSeparator+document.getElementById("txtUserId").value.trim();
        //Password
        strValue=strValue+ColSeparator+document.getElementById("txtPassword").value.trim();
        //Language
        select=document.getElementById("drpLanguage");
        strValue=strValue+ColSeparator+select.options[select.selectedIndex].value;
        //Save User Name
        strValue=strValue+ColSeparator+document.getElementById("chkUserName").checked;
        //Database Name
        strValue=strValue+ColSeparator+document.getElementById("drpDatabase").value;
        return strValue;
    }
    function GetSearchValue()
    {
        var strValue="";
        //Type
        strValue=3; /// this Type just for Submit button ....
        //Selected
        strValue=strValue+ColSeparator+document.getElementById("drpSearch").value;
        //Searchvalue
        strValue=strValue+ColSeparator+document.getElementById("txtSearch").value; 
        //return value 
        return strValue;
    }        
    function JudgeLogin()
    {
        if(GetLoginValue().trim()==""){
            //alert("Can not connect to the DataBase.");
            layer.open({type: 0, title: false, content: 'Can not connect to the DataBase.', btn: 'OK', icon: 5});
            return false ;
        }
        var Password=document.getElementById("txtPassword").value;
        if(Password.trim()==""){
            //alert("The password is wrong!");
            layer.open({type: 0, title: false, content: 'The password is wrong!', btn: 'OK', icon: 5});
            return false;
        } 
            context = null;
            var objSiteCode=document.getElementById("drSiteCode");
            var SiteCode="";
            if(objSiteCode.selectedIndex==-1){SiteCode="";}
            else{SiteCode=objSiteCode.options[objSiteCode.selectedIndex].value;}
        //if(objSiteCode.style.display=='none'){SiteCode="";}
        var arg = "JudgeLogin"+ParSeparator+GetLoginValue()+ParSeparator+SiteCode;
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetLoginResult", "context")%>; 
    }
    function checkSearch()
    {
        var txt;
        txt=document.getElementById("txtSearch");
        if (txt.value.trim()=="")  {
            //window.alert("The search value can't blank !");
            layer.open({type: 0, title: false, content: 'The search value can not be blank!', btn: 'OK', icon: 5});
            txt.focus; 
        return false;
            }
        else { 
            context = 1;
            var arg = "FindSearch"+ParSeparator+GetSearchValue();
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetLoginResult", "context")%>; 
        }
    }
    function SetLoginResult(result, context) 
    { 
        var txt;
        txt=document.getElementById("drpSearch").value;
        strResult = result.split(ParSeparator);
        switch(strResult.length)
        {
            case 2:
                if (strResult[0] == RtnOk){
                    if (context!=1){
                        window.location.href =strResult[1];
                    }
                    else{
                        if(txt == "OrderNo"){
                            WindowDialog(strResult[1],1024,968);
                        }
                        else if(txt == "ContainerNo" && strResult[1].indexOf("Left")>=0)
                        {
                            WindowDialog(strResult[1],600,550)
                        }
                        else{
                            var strUrlNew = "loading.aspx?tourl="+strResult[1]+"";
                            if($.trim(strResult[1])!="")
                            {    OpenWindow(strUrlNew,790,492);  }
                            else
                            {
                                //alert('module code is not "SE" or "SI"');
                                layer.open({type: 0, title: false, content: 'module code is not "SE" or "SI" or "AE" or "AI"', btn: 'OK', icon: 5});
                            }
                        }
                    }
                }
                else{
                    //window.alert(strResult[1]);
                    layer.open({type: 0, title: false, content: strResult[1], btn: 'OK', icon: 5});
                }          
                break;
            default:
                //window.alert(strResult[1]);
                layer.open({type: 0, title: false, content: strResult[1], btn: 'OK', icon: 5});
                break;
        }
    }
    var valType=1;
    function showDatabase()
    {   
        var objDiv=$("#divDatabase");
        var strValue=getRadioButtonSelectedValue("rdbtnType"); 
        valType=strValue;
        if (strValue==1){ 
          if (!objDiv.is(":visible")|| strValue==1){objDiv.css("display","");}
          else{objDiv.hide();} 
        }
       else{
          $("#divSiteCode").hide();
          ShowSite();
          objDiv.hide();
       }
    }
    function ShowSite()
    {
        if(valType!=1){return false;}
        var objSiteCode=document.getElementById("drSiteCode");
        var UserId=document.getElementById("txtUserId").value;
        if(UserId.trim()==""){return false;}
        context = document.getElementById("divSite");
        var arg = "ShowSite"+ParSeparator+UserId;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetShowSite", "context")%>; 
    }
    function SetShowSite(result, context){
        strResult=result.split(ParSeparator);
        switch(strResult.length){
            case 2:
                if (strResult[0]==RtnOk){
                    document.getElementById("divSiteCode").style.display="";
                    context.style.display="inline";    
                    context.innerHTML=strResult[1];
                }
                else{document.getElementById("divSiteCode").style.display="none";
                    context.style.display="none";}
                break;
            default:
                //window.alert(strResult[1]);
                layer.open({type: 0, title: false, content: strResult[1], btn: 'OK', icon: 5});
                break;
        }
    }
    function BindSite()
    {
        var UserId=document.getElementById("txtUserId").value;
        if(UserId.Trim()==""){return false;}
        context = document.getElementById("divSite");
        var objSiteCode=document.getElementById("drSiteCode");  
        if(objSiteCode.options.length>1){return false;}
        var SiteCode=objSiteCode.options[objSiteCode.selectedIndex].value;
        var arg = "BindSite"+ParSeparator+UserId+ParSeparator+SiteCode;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetBindSite", "context")%>;
    }
    function SetBindSite(result, context){
        strResult=result.split(ParSeparator);
        switch(strResult.length)
        {
            case 3:
                if (strResult[0]==RtnOk){context.innerHTML=strResult[1];}
                    var objSiteCode=document.getElementById("drSiteCode");  
                break;
            default:
                //window.alert(strResult[1]);
                layer.open({type: 0, title: false, content: strResult[1], btn: 'OK', icon: 5});
                break;
        }
    }
    function Reset(){
        $("#txtUserId").val("");
        $("#txtPassword").val("");
    }
</script>