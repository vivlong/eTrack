<script language ="javascript" type="text/javascript">
var UserFlag="";
var CNIndex=0;
if( IEType>=9||IEType==4)
{
    CNIndex=1;
}
function SelectUserFlag()
{UserFlag='y';}
//---------------------------------------------------------------------------
function SelectAllSubFunction()
{
    var e = event.srcElement;
    var row = e.parentNode.parentNode;
    var cell=row.cells[2];
    if (cell.hasChildNodes()){
        for(var i=0;i<cell.childNodes.length;i++) {
            if (cell.childNodes[i].nodeType==1 && cell.childNodes[i].type=="checkbox") {
                cell.childNodes[i].checked=e.checked;
            }
        }
    }
}
//save admin RoleFunction
function SaveAdminFunction()
{
if (document.getElementById("hidDiv").value=="2")
{
SaveRoleFunction();
return true;
}
if (document.getElementById("hidDiv").value=="3")
{
SaveRoleFunction();
return true;
}
       if(UserFlag='y')
      {
        var strValue="";
        var sourcetable=document.getElementById("gvwSourceAdmin");
        var row;
        var cell;
        for (var i = 1; i < sourcetable.rows.length; i++){
	        row = sourcetable.rows[i];
	         if(row.cells.length>1){
	            cell = row.cells[0];
                if (strValue) {strValue=strValue+RowSeparator+row.cells[0].childNodes[0+CNIndex].value;}
                else {strValue=row.cells[0].childNodes[0+CNIndex].value;}
		        if (cell.hasChildNodes()){
		            for(var j=0;j<cell.childNodes.length;j++){
                      if (cell.childNodes[j].nodeType==1 && cell.childNodes[j].type=="checkbox") {
                       if (cell.childNodes[j].checked) {strValue=strValue+ColSeparator+IntTrueString;}
                       else {strValue=strValue+ColSeparator+IntFalseString;}
                     }
                   }
		        }
	        }
	    }
	    if(strValue){
            var arg = "SaveAdminFunction"+ParSeparator+strValue;
	        context = document.getElementById("divSource");
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SaveReturn", "context")%>;
	    }
      }
}
//
function SaveRoleFunction()
{
 if(strTab==1||strTab==3)
  {
    if(strTab==1||strTab==3){drobj=document.getElementById("drpRoleInfo");}
    else{drobj=document.getElementById("drpRoleCustomer");}
    var valRoleInfo =drobj.options[drobj.selectedIndex].value
    var strValue="";
    var sourcetable=document.getElementById("gvwSource");
    if(sourcetable==null){return false;}
    var row;
    var cell;
    var cell3;
    for (var i = 1; i < sourcetable.rows.length; i++) {
	    row = sourcetable.rows[i];
	     if(row.cells.length>2){
	        cell = row.cells[2];
	        cell3= row.cells[3];
            if (strValue) {strValue=strValue+RowSeparator+row.cells[0].childNodes[0+CNIndex].value;}
            else {strValue=row.cells[0].childNodes[0+CNIndex].value;}
		    if (cell.hasChildNodes()){
		        for(var j=0;j<cell.childNodes.length;j++)  {
                    if (cell.childNodes[j].nodeType==1 && cell.childNodes[j].type=="checkbox") {
                    var strCondition="";
                     if (cell3.hasChildNodes()){
		                for(var k=0;k<cell3.childNodes.length;k++)  {
                            if (cell3.childNodes[k].nodeType==1 && cell3.childNodes[k].type=="text") {
                                if (cell3.childNodes[k].id==cell.childNodes[j].id.replace("chkFun","txtCondition")) {strCondition="|"+escape(cell3.childNodes[k].value);}                       
                              
                                        }
                                    }
		                        }
                    
                    
                        if (cell.childNodes[j].checked) {strValue=strValue+ColSeparator+IntTrueString+strCondition;}                       
                        else {strValue=strValue+ColSeparator+IntFalseString+strCondition;}
                 
                    }
                }
		    }
	    }
	   else
	   {
	   	  cell = row.cells[0];
            if (strValue) {strValue=strValue+RowSeparator+row.cells[0].childNodes[0+CNIndex].value;}
            else {strValue=row.cells[0].childNodes[0+CNIndex].value;}    
		    if (cell.hasChildNodes()){		
		        for(var j=0;j<cell.childNodes.length;j++)  {
                    if (cell.childNodes[j].nodeType==1 && cell.childNodes[j].type=="checkbox") {
                        if (cell.childNodes[j].checked) {strValue=strValue+ColSeparator+IntTrueString;}                       
                        else {strValue=strValue+ColSeparator+IntFalseString;}
                    }
                }
		    }
	   }
	   
	}
	if(strValue){
        var arg = "SaveRoleFunction"+ParSeparator+strValue+ParSeparator+valRoleInfo;
	    context = document.getElementById("divSource");
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SaveReturn", "context")%>;
	}
  }
 else
 {
    hidRoleId=document.getElementById("hidRoleId");
    var valRoleInfo =hidRoleId.value
    var strValue="";
    var sourcetable=document.getElementById("gvwSource");
    if(sourcetable==null){return false;}
    var row;
    var cell;
    var cell3;
    for (var i = 1; i < sourcetable.rows.length; i++) {
	    row = sourcetable.rows[i];
	     if(row.cells.length>2){
	        cell = row.cells[2];
	        cell3= row.cells[3];
            if (strValue) {strValue=strValue+RowSeparator+row.cells[0].childNodes[0+CNIndex].value;}
            else {strValue=row.cells[0].childNodes[0+CNIndex].value;}
		    if (cell.hasChildNodes()){
		        for(var j=0;j<cell.childNodes.length;j++)  {
                    if (cell.childNodes[j].nodeType==1 && cell.childNodes[j].type=="checkbox") {
                     var strCondition="";
                     if (cell3.hasChildNodes()){
		                for(var k=0;k<cell3.childNodes.length;k++)  {
                            if (cell3.childNodes[k].nodeType==1 && cell3.childNodes[k].type=="text") {
                                if (cell3.childNodes[k].id==cell.childNodes[j].id.replace("chkFun","txtCondition")) {strCondition="|"+escape(cell3.childNodes[k].value);}                       
                              
                                        }
                                    }
		                        }
                        if (cell.childNodes[j].checked) {strValue=strValue+ColSeparator+IntTrueString+strCondition;}                       
                        else {strValue=strValue+ColSeparator+IntFalseString+strCondition;}
                    }
                }
		    }
	    }
	   else
	   {
	   	  cell = row.cells[0];
            if (strValue) {strValue=strValue+RowSeparator+row.cells[0].childNodes[0+CNIndex].value;}
            else {strValue=row.cells[0].childNodes[0+CNIndex].value;}    
		    if (cell.hasChildNodes()){		
		        for(var j=0;j<cell.childNodes.length;j++)  {
                    if (cell.childNodes[j].nodeType==1 && cell.childNodes[j].type=="checkbox") {
                        if (cell.childNodes[j].checked) {strValue=strValue+ColSeparator+IntTrueString;}                       
                        else {strValue=strValue+ColSeparator+IntFalseString;}
                    }
                }
		    }
	   }
	}
	if(strValue){
        var arg = "SaveRoleFunction"+ParSeparator+strValue+ParSeparator+valRoleInfo;
	    context = document.getElementById("divSource");
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SaveReturn", "context")%>;
	}
 } 
	
}

function SaveReturn(result,context)
{
    strResult=result.split(ParSeparator);
    if (strResult.length==2) {
        if (strResult[0]==RtnOk) {
            window.alert(strResult[1]);
        }
        else {
            window.alert(strResult[1]);
        }
    }
    else {
        window.alert(SaveUnexpectedError);
    }
}

function SelectRoleFunction(drop)
{
    var strRoleId = drop.options[drop.selectedIndex].value;
    var strRoleName = drop.options[drop.selectedIndex].innerHTML;
    if (strRoleId) {
        var arg="SelectRoleFunction"+ParSeparator+strRoleId+ParSeparator+strRoleName+ParSeparator+document.getElementById("hidDiv").value;
        context = document.getElementById("divSource");
        <%= ClientScript.GetCallbackEventReference(Me,"arg","SetReturnValue","context") %>;
    }
}

function SelectRoleForAdmin(selectId)
{
    if (selectId) {
        var arg="SelectRoleForAdmin"+ParSeparator+selectId;
        context = document.getElementById("divSource");
        <%= ClientScript.GetCallbackEventReference(Me,"arg","SetReturnValue","context") %>;
    }
}

function SetReturnValue(result,context)
{
    strResult=result.split(ParSeparator);
    if (strResult.length==2) {
        if (strResult[0]==RtnOk) {
            context.innerHTML = strResult[1];
        }
        else {
            window.alert(strResult[1]);
        }
    }
}

function selectAll(chkAll)
{
    var selected = chkAll.checked;
    var sourcetable=document.getElementById("gvwSource");
    if(sourcetable==null){return false;}
    var tr;
    var cell;
    var chk;
    for (var i = 1; i < sourcetable.rows.length; i++) {
        tr=sourcetable.rows[i];
        if (tr.cells[0].hasChildNodes() && (tr.cells[0].childNodes[0+CNIndex].nodeType==1)) {
            chk=tr.cells[0].childNodes[0+CNIndex];
            if (chk.checked!=selected) {chk.checked=selected;}
            cell=tr.cells[2];
	     if(tr.cells.length>2){
	        cell = tr.cells[2];
            if (cell.hasChildNodes()){
                for(var j=0;j<cell.childNodes.length;j++) {
                    if (cell.childNodes[j].nodeType==1 && cell.childNodes[j].type=="checkbox") {cell.childNodes[j].checked=selected;}
                }
            }
	    }
        }
    }    
}
//
function selectAllAdmin(chkAll)
{
    var selected = chkAll.checked;
    var sourcetable=document.getElementById("gvwSourceAdmin");
    var tr;
    var cell;
    var chk;
    for (var i = 1; i < sourcetable.rows.length; i++) 
    {
        tr=sourcetable.rows[i];
        if(tr.cells.length==2)
        {
            if (tr.cells[0].hasChildNodes() && (tr.cells[0].childNodes[0+CNIndex].nodeType==1)) 
            {
                chk=tr.cells[0].childNodes[0+CNIndex];
                if (chk.checked!=selected) {chk.checked=selected;}
            }
        }
    }    
}
</script>

