<script type="text/javascript" language ="javascript">
    //091204
    function OpAttachList(objCell,strid,Title){
    var ret=WindowDialog("../SysRef/AttachList.aspx?Id=" + strid + "&Folder=" + TableName + "&Title="+Title,640,450);
    if (ret==RtnOk) {GetPageData(null,-1)}
}
//------------------------------------------------------------------------------------------
   function PrintDetail(intId) {
        if (intId) {
            var strUrl = "../loading.aspx?tourl=" + PrintPath + "/crQuotation.aspx?Id=" + intId.toString() + "";
            window.open(strUrl);
        }
    }
   function SelectedDivl(selectId,LiCount)
   {
    var DivName;
    var LiName;
    for(var i=1;i<=LiCount;i++)
    {
        if (selectId==i)
        {
                LiName="a"+selectId.toString();
                document.getElementById(LiName).className="f12e navNml navOn";
        }
        else{
                LiName="a"+i.toString();
                document.getElementById(LiName).className="f12c navNml noSep";
             }
    }
    if(selectId==1)
    { 
         TableName="Smfq1"
         strQuery="Smfq1"
         divdrpSearch1.style.display="block";
         divdrpSearch2.style.display="none";
    }
    else if(selectId==2)
    {
          TableName="Amfq1";
          strQuery="Amfq1"
          divdrpSearch1.style.display="none";
          divdrpSearch2.style.display="block";
    }
     document.getElementById('hidVal_Quotation').value=selectId;
     context=hid_div;
     var arg="SetTabVal"+ParSeparator+selectId;
     <%= ClientScript.GetCallbackEventReference(Me,"arg","SetResult", "context")%>; 
    }
    function SetResult(result,context)
    {
    var strResult=result.split(ParSeparator);
            if (strResult[0]==RtnOk) {
            context.innerHTML=strResult[1];
            divbtnAdvSearch.innerHTML=strResult[2];
            }
            else if (strResult[1]!=""){
                window.alert(strResult[1]);
            }
    }
    function GetQuery() 
    {
        //by lzw
        strWhere="";
        var strWhereBook = "";
        var strQuery = document.getElementById("txtSearch").value;
        var objSearchField = document.getElementById("drpSearch1");
       if(TableName=="Smfq1"){objSearchField = document.getElementById("drpSearch1");}
       else if(TableName=="amfq1"){objSearchField = document.getElementById("drpSearch2");}
        if(divdrpSearch1.style.display=="" || divdrpSearch1.style.display=="block"){objSearchField = document.getElementById("drpSearch1");}
        else{objSearchField = document.getElementById("drpSearch2");}
        if (objSearchField) 
        {
            var arrFieldName = objSearchField.options[objSearchField.selectedIndex].value.split(",");
            if(arrFieldName[0].length!=0)
            {    
                if (arrFieldName[1] == "0") 
                {
                    if (strQuery.Trim == "") 
                    {
                        strWhere = " and (" + arrFieldName[0] + " is null or " + arrFieldName[0] + "='') ";
                    }
                    else { strWhere = "  and " + arrFieldName[0] + " like '%" + strQuery + "%' "; }
                }
                else 
                {
                    if (strQuery.Trim == "") 
                    {
                        strWhere = "  and (" + arrFieldName[0] + " is null or " + arrFieldName[0] + "='') ";
                    }
                    else { strWhere = "  and Cast(" + arrFieldName[0] + " as NVarChar(50))" + " like '%" + strQuery + "%' "; }
                }
            }
        }
        strWhere = strWhere + strWhereBook;
    }
   function AdvGetQuery() {}

</script>
