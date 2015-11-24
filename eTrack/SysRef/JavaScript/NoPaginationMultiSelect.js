<script language="javascript" type="text/javascript">

function GetSelectedValues()
{
    var sp=0;
    if ( IEType>=9)
    {
        sp=1;
    }
    var strAdd;
    var sourcetable=document.getElementById("gvwSource");
    if(sourcetable==null){return false;}
    var chk;
    var tr;
    for (var i = 1; i < sourcetable.rows.length; i++) {
		tr = sourcetable.rows[i];
		if (tr.cells[0].hasChildNodes() && (tr.cells[0].nodeType==1)) {
		    chk=tr.cells[0].childNodes[0+sp];
		    if (chk.checked) {
                if (strAdd) {
		            strAdd=strAdd +RowSeparator+chk.value;
		        }
		        else {
		            strAdd=chk.value;
		        }
		        for(var j=1;j<tr.cells.length;j++) {
                    if (tr.cells[j].hasChildNodes() && tr.cells[j].childNodes[0].nodeType==1) {
                       strAdd=strAdd+ColSeparator+tr.cells[j].childNodes[0].value;
                    }
                    else {
                       strAdd=strAdd+ColSeparator+tr.cells[j].innerHTML;
                    }
		        }
		    }
		}
	}
    return strAdd;
}

function ClosingWindow(flag)
{
    if (flag==1){
        window.returnValue=GetSelectedValues();
    }
    else{
        window.returnValue="";
    }
    window.close(); 
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

function GetChildNodesValue(cell)
{
    var strValue="";
    for(var k=0; k<cell.childNodes.length;k++){
        if(cell.childNodes[k].id!=undefined){
            if (cell.childNodes[k].id.toString().indexOf("AddNode")>0){
                blAddNode=StrToBool(cell.childNodes[k].value);
            }
            if(strValue){
                strValue=strValue+ColSeparator+cell.childNodes[k].value;
            }
            else{
                strValue=cell.childNodes[k].value;
            }
        }
    }
    return strValue;
}

function GetMultiValues()
{
    var ret=null;
    var sourcetable=document.getElementById("gvwSource");
    if(sourcetable==null){return false;}
    var chk;
    var tr;
    var strId="";
    var strName="";
    var strCode="";
    for (var i = 1; i < sourcetable.rows.length; i++) {
	    tr = sourcetable.rows[i];
	    if (tr.cells[0].hasChildNodes() && (tr.cells[0].nodeType==1)) {
	        chk=tr.cells[0].childNodes[0];
	        var strTemp="";
            if (chk.checked) {
                strTemp=GetChildNodesValue(tr.cells[0]);
                if (strId) {                
		            strId=strId+","+strTemp;
		            strName=strName+","+tr.cells[3].innerText;
		            strCode=strCode+","+tr.cells[2].innerText;
		        }
		        else {
		            strId=strTemp;
		            strName=tr.cells[3].innerText;
		            strCode=tr.cells[2].innerText;
		        }
		    }    
        }                   
    }
    ret=new Array(strId,strName,strCode);
    return ret;
}

function MultiWindow(flag)
{
    if (flag==1){
        window.returnValue=GetMultiValues();
    }
    else{
        window.returnValue=new Array("","");
    }
    window.close(); 
}

</script>