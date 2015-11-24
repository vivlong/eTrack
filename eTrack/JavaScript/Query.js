<script language ="javascript" type="text/javascript">
var intCount=<%=intPageCount%>;
var intPage=1;

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

function ShowQueryResult()
{
    var DivQuery="divForm";
    var DivResult="divResult";
    var obj=document.getElementById(DivResult);
    if (obj.style.display=="none"){
        obj.style.display="inline-block";
    }
    obj=document.getElementById(DivQuery);
    if (obj.style.display!="none"){
        obj.style.display="none";
    }
    return true;
}

function HideQueryResult()
{
    var DivQuery="divForm";
    var DivResult="divResult";
    var obj=document.getElementById(DivResult);
    if (obj.style.display!="none"){
        obj.style.display="none";
    }
    obj=document.getElementById(DivQuery);
    if (obj.style.display=="none"){
        obj.style.display="inline-block";
    }
    return true;
}

function GetQueryResult()
{ 
    context = document.getElementById("divSource");
    intPage=1;
    ShowLoadingData();
    var arg = "GetPageData"+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString()+ParSeparator+GetQueryValue();
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetSourceValue", "context")%>; 
} 
  
function GetPageData(obj,intFlag) 
{ 
    obj = document.getElementById(obj);
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
    var arg = "GetPageData"+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString()+ParSeparator+GetQueryValue();
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetSourceValue", "context")%>;
} 

function GetSortPageData(strField,intSort)
{
    context = document.getElementById("divSource");
    SortField=strField;
    SortDesc=intSort;
    intPage=1;
    ShowLoadingData();
    var arg = "GetPageData"+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString()+ParSeparator+GetQueryValue();
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

function GetQueryData(obj) 
{ 
    context = document.getElementById("divSource");
    if(obj==null){return false;}
    intPage=1;
    strQuery=obj.value;
    if(strQuery==undefined || strQuery==null) {
        strQuery="";
    }
    strQuery=SqlSafe(strQuery);
    ShowLoadingData();
    var condition=GetQueryValue();

    var arg = "GetPageData"+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString()+ParSeparator+condition;
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetSourceValue", "context")%>; 
} 

function SetSourceValue(result, context) 
{ 

    HideLoadingData();
    strResult=result.split(ParSeparator);
    switch(strResult.length)
    {
        case 2:
            intCount=1;
            context.innerHTML = strResult[1]; 
            var lbl=document.getElementById("lblPage");
            lbl.innerHTML = PageTitle + intPage.toString() + PageSeparator + intCount.toString();
            var txt=document.getElementById("txtPage");
            txt.value=intPage.toString();
            break;
        case 3:
            intCount=strResult[1];
            context.innerHTML = strResult[2]; 
            var lbl=document.getElementById("lblPage");
            lbl.innerHTML = PageTitle + intPage.toString() + PageSeparator + intCount.toString();
            var txt=document.getElementById("txtPage");
            txt.value=intPage.toString();
            ShowQueryResult();
            break;
        case 4:
            intCount=strResult[1];
            context.innerHTML = strResult[2];
            var lbl=document.getElementById("lblPage");
            lbl.innerHTML = PageTitle + intPage.toString() + PageSeparator + intCount.toString();
            var txt=document.getElementById("txtPage");
            txt.value=intPage.toString();
            lbl=document.getElementById("lblResultTitle");
            if(lbl){
                lbl.innerHTML=strResult[3];
            }
            ShowQueryResult();
            break;
        default:
            window.alert(strResult[1]);
            break;
    }
} 

</script>
