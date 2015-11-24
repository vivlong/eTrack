<script type="text/javascript" language="javascript">

var intCount=<%=intPageCount%>;
var intPage=1;
    
function GetPageData(obj,intFlag) 
{ 
    obj = document.getElementById(objCon);
    context = document.getElementById("divSource");
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
    if (intPage>intCount) {
        intPage=intCount;
    }
    else if (intPage<1) {
        intPage=1;
    }
    var arg = "GetPageData"+ParSeparator+intPage; 
    <%= ClientScript.GetCallbackEventReference(this, "arg", "SetSourceValue", "context")%>; 
} 

function GetQueryData(obj) 
{ 
    context = document.getElementById("divSource");
    var strQuery=obj.value;
    intPage=1;
    if(strQuery==undefined || strQuery==null) {
        strQuery="";
    }
    var arg = "GetQueryData"+ParSeparator+strQuery; 
    <%= ClientScript.GetCallbackEventReference(this, "arg", "SetSourceValue", "context")%>; 
} 
  
function SetSourceValue(result, context) 
{ 
    arrTmp = result.split(ParSeparator); 
    intCount=arrTmp[0];
    context.innerHTML = arrTmp[1]; 
    var lbl=document.getElementById("lblPage");
    lbl.innerHTML = PageTitle + intPage.toString() + PageSeparator + intCount.toString();
    var txt=document.getElementById("txtPage");
    txt.value=intPage.toString();                
} 
         
function AddCurrentRow(tr,RowIndex)
{
    var strAdd=RowIndex.toString();
    for( j=1;j<tr.cells.length;j++) {
        if (tr.cells[j].hasChildNodes() && tr.cells[j].childNodes[0].nodeType==1 && tr.cells[j].childNodes[0].type=="text") {
           strAdd=strAdd+ColSeparator+tr.cells[j].childNodes[0].value;
        }
    }
	var arg = "AddSelectedRow"+ParSeparator +strAdd; 
	context = divDestination;
    <%= ClientScript.GetCallbackEventReference(this, "arg", "SetDestValue", "context")%>; 
}
            
function AddSelectedRow()
{
    var strAdd;
    var sourcetable=document.getElementById("gvwSource");	
    var chk;
    var tr;
    for (var i = 0; i < sourcetable.rows.length; i++) {
		tr = sourcetable.rows[i];
        if (i==0){
            if(tr.cells[0].hasChildNodes() && (tr.cells[0].childNodes[0].nodeType==1)){
                chk=tr.cells[0].childNodes[0];
                chk.checked=false;
            }
            continue;
		}
		if (tr.cells[0].hasChildNodes() && (tr.cells[0].childNodes[0].nodeType==1)) {
		    chk=tr.cells[0].childNodes[0];
		    if (chk.checked) {
                if (strAdd) {
		            strAdd=strAdd +RowSeparator+(i).toString();
		        }
		        else {
		            strAdd=(i).toString();
		        }
                chk.checked=false;
                if(i % 2==1) {
                    tr.style.backgroundColor=colorFirst;
                }
                else {
                    tr.style.backgroundColor=colorSecond;
                }
		        for( j=1;j<tr.cells.length;j++) {
                    if (tr.cells[j].hasChildNodes() && tr.cells[j].childNodes[0].nodeType==1 && tr.cells[j].childNodes[0].type=="text") {
                       strAdd=strAdd+ColSeparator+tr.cells[j].childNodes[0].value;
                    }
		        }
		    }
		}
	}
	if(strAdd) {
	    var arg = "AddSelectedRow"+ParSeparator +strAdd; 
	    context = divDestination;
        <%= ClientScript.GetCallbackEventReference(this, "arg", "SetDestValue", "context")%>;
	}
}

function DeleteCurrentRow(tr,RowIndex)
{
    var strDelete=RowIndex.toString();
	var arg = "DeleteSelectedRow"+ParSeparator +strDelete;
	context = document.getElementById("divDestination");
    <%= ClientScript.GetCallbackEventReference(this, "arg", "SetDestValue", "context")%>; 
}

function DeleteSelectedRow()
{
    var addtable=document.getElementById("gvwDestination");
    var tr;
    var chk;
    var strDelete;
    for (var i = addtable.rows.length-1; i >=0; i--) {
        tr=addtable.rows[i];
        if (tr.cells[0].hasChildNodes() && (tr.cells[0].childNodes[0].nodeType==1)) {
            chk=tr.cells[0].childNodes[0];
            if (chk.checked) {
                if (strDelete) {
                    strDelete=strDelete+RowSeparator+(i).toString();
                }
                else {
                    strDelete=(i).toString();
                }
            }
        }
    }
	if(strDelete) {
	var arg = "DeleteSelectedRow"+ParSeparator+strDelete; 
	context = divDestination;
    <%= ClientScript.GetCallbackEventReference(this, "arg", "SetDestValue", "context")%>; 
	}            
}

function SetDestValue(result,context)
{
    if(result!=""){
        context.innerHTML = result; 
    }
}

function ClosingWindow(flag)
{
    var arg = "SetReturnValue"+ParSeparator+flag.toString(); 
    <%= ClientScript.GetCallbackEventReference(this, "arg", "CloseWindow", "null")%>; 
}

function CloseWindow(result,context)
{
    window.returnValue=result;
    window.close();
}
	
function selectAll(chkAll)
{
    var selected = chkAll.checked;
    var sourcetable=document.getElementById("gvwSource");
    if(sourcetable==null){return false;}
    var tr;
    var chk;
    for (var i = 1; i < sourcetable.rows.length; i++) {
        tr=sourcetable.rows[i];
        if (tr.cells[0].hasChildNodes() && (tr.cells[0].childNodes[0].nodeType==1)) {
            chk=tr.cells[0].childNodes[0];
            if (chk.checked!=selected) {
                chk.checked=selected;
            }
        }
    }    
}

</script>