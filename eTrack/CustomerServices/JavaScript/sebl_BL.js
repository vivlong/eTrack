<script language ="javascript" type="text/javascript">
//by lzw 090323
function GetQueryData() 
{   
    context = document.getElementById("divSource");
    intPage=1;
    ShowLoadingData();
    GetQuery();
    var arg = "GetPageData"+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString()+ParSeparator+"";  
    WebForm_DoCallback('__Page',arg,SetSourceValue,context,null,false); 
} 
function ExportExcel()
{
    Loading();
    var arg = "ServerExportExcel"+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString();
    context=null;
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "ShowExcelFile", "context")%>;
}
</script>