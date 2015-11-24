<script language="javascript" type="text/javascript">

function urlEncode(strValue)
{
    return escape(strValue);
}

function PrintWeb(strClassName,strTableName,intFlag)
{ 
    var strTitle="";
    var objTitle=document.getElementById("lblResultTitle");
    if(objTitle){
        strTitle=objTitle.innerText;
    }
    if(strTitle==""){
        objTitle=document.getElementById("lblQueryTitle");
        if(objTitle){
            strTitle=objTitle.innerText;
        }
    }
    if(strTitle==""){
        objTitle=document.getElementById("lblTitle");
        if(objTitle){
            strTitle=objTitle.innerText;
        }
    }
    var strUrl="";
        var strParam="ClassName="+urlEncode(strClassName);
        strParam=strParam+"&TableName="+urlEncode(strTableName);
        strParam=strParam+"&Title="+urlEncode(strTitle);
        strParam=strParam+"&Query="+urlEncode(strQuery);
        strParam=strParam+"&Where="+urlEncode(strWhere);
        strParam=strParam+"&SortField="+urlEncode(SortField);
        strParam=strParam+"&SortDesc="+SortDesc.toString();
     if(intFlag==2||intFlag==3||intFlag==4||intFlag==5){strParam=strParam+"&Condition="+urlEncode(GetQueryValue());}
    if(intFlag==0){
        strUrl="../loading.aspx?tourl="+"Print/PrintAnaly.aspx?ClassName="+strClassName+"&TableName="+strTableName+"&Title="+strTitle+"&Query="+strQuery+"&Where="+strWhere+"&SortField="+SortField+"&SortDesc="+SortDesc.toString()+"&Condition="+urlEncode(GetQueryValue())+"";
    }
    else if(intFlag==1){
        strUrl="../loading.aspx?tourl="+"Print/crVesselSchedule.aspx?Condition="+urlEncode(GetQueryValue())+"";
    }
    else if(intFlag==2){
        strUrl="../loading.aspx?tourl=Print/PrintDCS.aspx?"+strParam+"";
    }
    else if(intFlag==3){
        strUrl="../loading.aspx?tourl=Print/PrintWCR.aspx?"+strParam+"";
    }
    else if(intFlag==4){
        strUrl="../loading.aspx?tourl=Print/PrintCPC.aspx?"+strParam+"";
    }
    else if(intFlag==5){
        strUrl="../loading.aspx?tourl=Print/PrintCID.aspx?"+strParam+"";
    }
    window.open(strUrl);
}

function ListPrintWeb(strClassName,strTableName,intFlag)
{ 
    var strTitle="";
    var objTitle=document.getElementById("lblResultTitle");
    if(objTitle){
        strTitle=objTitle.innerText;
    }
    if(strTitle==""){
        objTitle=document.getElementById("lblQueryTitle");
        if(objTitle){
            strTitle=objTitle.innerText;
        }
    }
    if(strTitle==""){
        objTitle=document.getElementById("lblTitle");
        if(objTitle){
            strTitle=objTitle.innerText;
        }
    }
    var strUrl="";
    if(intFlag==0){
        strUrl="../loading.aspx?tourl="+"Print/PrintAnaly.aspx?ClassName="+strClassName+"&TableName="+strTableName+"&Title="+strTitle+"&Query="+strQuery+"&Where="+strWhere+"&SortField="+SortField+"&SortDesc="+SortDesc.toString()+"";
    }
    else if(intFlag==1){
        strUrl="../loading.aspx?tourl="+"Print/PrintQry.aspx?ClassName="+strClassName+"&TableName="+strTableName+"&Title="+strTitle+"&Query="+strQuery+"&Where="+strWhere+"&SortField="+SortField+"&SortDesc="+SortDesc.toString()+"";
    }
    else{
        strUrl="../loading.aspx?tourl="+"Print/PrintMergeHeader.aspx?ClassName="+strClassName+"&TableName="+strTableName+"&Title="+strTitle+"&Query="+strQuery+"&Where="+strWhere+"&SortField="+SortField+"&SortDesc="+SortDesc.toString()+"";
    }
    window.open(strUrl);
}

function ExportExcel()
{
    Loading();
    var arg = "ServerExportExcel"+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString()+ParSeparator+GetQueryValue();
    context=null;
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "ShowExcelFile", "context")%>;
}

function ListExportExcel()
{
    Loading();
    var arg = "ServerExportExcel"+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString();
    context=null;
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "ShowExcelFile", "context")%>;
}

function ShowExcelFile(result, context)
{
    if( result!=""){
        window.open(result);
    }
    window.clearTimeout(ink);
    window.status="";
}

//Show in statusbar
var msg = "Export Data, please wait......" ;
var interval = 240;
var seq=0;
var ink;  
function Loading() 
{
    var len = msg.length;
    window.status = msg.substring(0, seq+1);
    seq++;
    if ( seq >= len ) {
        seq = 0;
        window.status = '';
        ink=window.setTimeout("Loading();", interval );
    }
    else{
        ink=window.setTimeout("Loading();", interval );
    }
}
</script>


