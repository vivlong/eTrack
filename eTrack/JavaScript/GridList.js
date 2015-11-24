<script type="text/javascript" language="javascript">

var intCount=<%=intPageCount%>;
var intPage=1;

function GetPageData(objCon,intFlag) 
{ 
    obj = document.getElementById(objCon);
    context = document.getElementById("divSource");
    if(obj) {
        intPage=parseInt(obj.value);
        if(intFlag==0) {
            if ((intCount>1) && (intPage>1)) {
                intPage=1;
            }
            else {
                return;
            }
        }
        else if (intFlag==1) {
            if ((intCount>1) && (intPage>1)) {
                intPage=intPage-1;
            }
            else {
                return;
            }
        }
        else if (intFlag==2) {
            if ((intCount>1) && (intPage<intCount)) {
                intPage=intPage+1;
            }
            else {
                return;
            }
        }
        else if (intFlag==3) {
            if ((intCount>1) && (intPage<intCount)) {
                intPage=intCount;
            }
            else {
                return;
            }
        }
        else if (intFlag==4) {
            if (intPage>intCount) {
                window.alert(CannotExceedLastPage);
                return;
            }
        }
    }
    if (intPage>intCount) {
        intPage=intCount;
    }
    if (intPage<1) {
        intPage=1;
    }
    ShowLoadingData();
    var arg = "GetPageData"+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString()+ParSeparator+""; 
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetSourceValue", "context")%>; 
} 

function GetSortPageData(strField,intSort) 
{
    context = document.getElementById("divSource");
    SortField=strField;
    SortDesc=intSort;
    intPage=1;
    ShowLoadingData();
    var arg = "GetPageData"+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString()+ParSeparator+""; 
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetSourceValue", "context")%>; 
}

function SqlSafe(str)
{
	var inputStr, strLen, tmpStr;
	tmpStr = "";
	inputStr = str.toString();
	strLen = inputStr.length;
	for (var i=0; i<strLen; i++){
		if (inputStr.charAt(i) == "'")
			tmpStr = tmpStr + "''";
		else
			tmpStr = tmpStr + inputStr.charAt(i);
	}
	return tmpStr;
}
function GetQueryPersonData(obj) 
{ 
    strWhere=" a.sStatus='USE'";
    context = document.getElementById("divSource");
    intPage=1;
    strQuery=obj.value;
    if(strQuery==undefined || strQuery==null) 
    {       strQuery="";    }
    strQuery=SqlSafe(strQuery);
     var objStatusField=document.getElementById("drpStatus").value;
       if(objStatusField != "ALL" )
       {    strWhere=" a.sStatus='"+objStatusField+"'"; }
       else{strWhere=" 1=1 ";}
    ShowLoadingData();
    var arg = "GetPageData"+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString()+ParSeparator+"";  
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetSourceValue", "context")%>; 
} 
//RequestForm
function GetTabQueryData() 
{ 
    context = document.getElementById("divSource");
    intPage=1;
    GetTabQuery();
    ShowLoadingData();
    var arg = "GetPageData"+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString()+ParSeparator+""; 
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetSourceValue", "context")%>; 
} 
//copy from CTS by danny 20100720
function GetQuery(obj)
{
    strQuery=obj.value;
    if(strQuery==undefined || strQuery==null) {
        strQuery="";
    }
    strQuery=SqlSafe(strQuery);
    var objSearchField=document.getElementById("drpSearch");
    if(objSearchField){
        var arrFieldName=objSearchField.options[objSearchField.selectedIndex].value.split(",");
        if (arrFieldName[0]=="ContainerNo"){while(strQuery.indexOf(" ")> -1){strQuery=strQuery.replace(" ","");} }//Add for Container 100107
        if (arrFieldName[1]=="0"){
            strWhere=" and "+arrFieldName[0]+" like '%"+strQuery+"%' ";
        }
        else{
            strWhere=" and Cast("+arrFieldName[0]+" as NVarChar(50))"+" like '%"+strQuery+"%' ";
        }
       
        var objTankCategoryField=document.getElementById("drpTankCategory");
        if(objTankCategoryField){ 
            var arrFieldName1=objTankCategoryField.options[objTankCategoryField.selectedIndex].value;
            if(arrFieldName1=="0") {
                strWhere = strWhere+"And Tank_Cat<>"+arrFieldName1+" ";
            } 
            else{
               strWhere = strWhere+"And Tank_Cat="+arrFieldName1+" ";
            } 
       }
        strQuery="";
    }
    else{
       var objTankCategoryField=document.getElementById("drpTankCategory");
       if(objTankCategoryField){ 
            var arrFieldName1=objTankCategoryField.options[objTankCategoryField.selectedIndex].value;
            if(arrFieldName1=="0") {
                strWhere = strWhere+"And Tank_Cat<>"+arrFieldName1+" ";
            } 
            else{
               strWhere = strWhere+"And Tank_Cat="+arrFieldName1+" ";
            } 
       }
       else{
          strWhere="";
       }
    }
}
//by lzw 090323
function GetQueryData() 
{   
    var obj= document.getElementById("txtSearch");
    context = document.getElementById("divSource");
    intPage=1;
    ShowLoadingData();
    GetQuery(obj);
    var arg = "GetPageData"+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString()+ParSeparator+"";  
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetSourceValue", "context")%>; 
} 
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

function CheckSelectOne()
{
    var e=event.srcElement;
    if (e.checked) {
        var sourcetable=document.getElementById("gvwSource");
        for (var i = 0; i < sourcetable.rows.length; i++) {
		    tr = sourcetable.rows[i];
		    if (tr.cells[0].hasChildNodes() && (tr.cells[0].childNodes[0].nodeType==1)) {
		        chk=tr.cells[0].childNodes[0];
		        if ((chk!=e) && (chk.checked)) {
                    chk.checked=false;
                    if(i % 2==1) {
                        tr.style.backgroundColor=colorFirst;
                    }
                    else {
                        tr.style.backgroundColor=colorSecond;
                    }
                }
            }                   
        }
    }
}
function ClosingWindow(flag)
{
    var strId="";
    if(flag!=1) {
        window.returnValue=strId;
        window.close();
        return;
    }
    var sourcetable=document.getElementById("gvwSource");
    for (var i = 0; i < sourcetable.rows.length; i++) {
	    tr = sourcetable.rows[i];
	    if (tr.cells[0].hasChildNodes() && (tr.cells[0].childNodes[0].nodeType==1)) {
	        chk=tr.cells[0].childNodes[0];
	        if (chk.checked) {
	            strId=chk.value;
	            break;
            }
        }                   
    }
    window.returnValue=strId;
    window.close();
}

function ClosingWindowReturnArray(flag,arrCol)
{
    var ret=null;
    if(flag!=1) {
        window.returnValue=ret;
        window.close();
        return;
    }
    var sourcetable=document.getElementById("gvwSource");
    for (var i = 0; i < sourcetable.rows.length; i++) {
	    tr = sourcetable.rows[i];
	    if (tr.cells[0].hasChildNodes() && (tr.cells[0].childNodes[0].nodeType==1)) {
	        var cell=tr.cells[0];
	        var strValue="";
	        chk=cell.childNodes[0];
	        if (chk.checked) {
	            ret=new Array();
	            for(var j=0; j < arrCol.length; j++){
	                if (arrCol[j]==0) {
                        for(var k=0; k<cell.childNodes.length;k++){
                            if(cell.childNodes[k].id!=undefined){
                                if(k>0){
                                    strValue=strValue+ColSeparator+cell.childNodes[k].value;
                                }
                                else{
                                    strValue=cell.childNodes[k].value;
                                }
                            }
                        }
	                    ret[0]=chk.value;
	                }
	                else {
	                    ret[j]=tr.cells[arrCol[j]].innerText;
	                }
	            }
	            if(strValue!=""){
	                ret[ret.length]=strValue;
	            }
	            break;
            }
        }
    }
    window.returnValue=ret;
    window.close();
}

function OpenAdvSearch(strTableName,blnFieldPrefix)
{
    var ret;
    ret=WindowDialog("../SysRef/AdvSearchEdit.aspx?TableName="+strTableName+"&FieldPrefix="+blnFieldPrefix.toString(),480,360);
    if(ret!=null){
        var context = document.getElementById("divSource");
        strWhere=ret;
        AdvGetQuery() ;
//      strQuery="";
        intPage=1;
        var arg = "GetPageData"+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString()+ParSeparator+""; 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetSourceValue", "context")%>;
    }
}

function ShowLoadingData()
{
    var objLoading=document.getElementById("MsgBox");
    if (objLoading){
        if (objLoading.style.display != "block"){
            objLoading.style.display = "block";
            objLoading.style.left=(document.body.clientWidth-objLoading.clientWidth)/2;   
            objLoading.style.top=(document.body.clientHeight-objLoading.clientHeight)/2;   
        }
    }
}

function HideLoadingData()
{
    var objLoading=document.getElementById("MsgBox");
    if (objLoading){
        if (objLoading.style.display != "none"){
            objLoading.style.display = "none";
        }
    }
}
</script>
