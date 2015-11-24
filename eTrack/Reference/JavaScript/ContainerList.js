<script language="javascript" type="text/javascript">

function UpdateContainer(strflag,TrxNo,TruckerName)
{
 if(strflag=='st')
 { 
    //getCheck
    var arrContainerNo =new Array(); 
    var sourcetable=document.getElementById("gvwSource");
    if(sourcetable.rows.length<2){alert("There are not containers to update.");return false;}
    for(var i = 0; i < sourcetable.rows.length; i++) 
      {
            tr = sourcetable.rows[i];
            if(tr.style.display!="none")
            {
                  if (tr.cells[0].hasChildNodes() && (tr.cells[0].childNodes[0].nodeType==1)) {
                  chk=tr.cells[0].childNodes[0];
                  if(chk.checked==true) {arrContainerNo.push(tr.cells[1].innerHTML);}
                  }
            }
      }
    if(arrContainerNo.length==0){alert("Please tick the items to update the containers.");return false;}
    context = document.getElementById("divAttach");
    var arg = "UpdateContainer"+ParSeparator+arrContainerNo.join(",")+ParSeparator+TrxNo+ParSeparator+TruckerName;
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetUpdateContainer", "context")%>;
 }
}
function SetUpdateContainer(result,context)
{
    strResult=result.split(ParSeparator);
    if (strResult[0]==RtnOk) 
    {window.alert(strResult[1]);
    window.returnValue=RtnOk;
    window.close();}
    else{window.alert(strResult[1]);}
}
function SelectAll()
{
    var strText=document.getElementById("btnSelectAll").value;
        var sourcetable=document.getElementById("gvwSource");
        for (var i = 0; i < sourcetable.rows.length; i++) 
        {
		        tr = sourcetable.rows[i];
		        if (tr.cells[0].hasChildNodes() && (tr.cells[0].childNodes[0].nodeType==1)) {
		            chk=tr.cells[0].childNodes[0];
		            if(strText=="Select All"){
		               chk.checked=true;
		               document.getElementById("btnSelectAll").value="Cancle All";
		            }
		            else{
		               chk.checked=false;
		               document.getElementById("btnSelectAll").value="Select All";
		            }
                }
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
function GetSelectedValue()
{
    var strAdd;
    var sourcetable=document.getElementById("gvwSource");	
    var chk;
    var tr;
    if(sourcetable.rows.length>0)
    {
        for (var i = 0; i < sourcetable.rows.length; i++) 
        {
		    tr = sourcetable.rows[i];
		    if (tr.cells[0].hasChildNodes() && (tr.cells[0].childNodes[0].nodeType==1)) 
		    {
		        chk=tr.cells[0].childNodes[0];
		        if (chk.checked) 
		        {
                    if (strAdd) 
                    {
		                strAdd=strAdd +RowSeparator+chk.value
		            }
		            else 
		            {
		                strAdd=chk.value;
		            }
		            for( j=1;j<tr.cells.length;j++) 
		            {
                        if (tr.cells[j].hasChildNodes() && tr.cells[j].childNodes[0].nodeType==1) 
                        {
                           strAdd=tr.cells[1].childNodes[0].value+ColSeparator+tr.cells[j].childNodes[0].value;
                        }
                        else {
                           strAdd=strAdd+ColSeparator+tr.cells[j].innerHTML;
                        }
		            }
		            break;
		        }
		    }
	    }
	}
    return strAdd;
}
 

function CloseWindow(flag)
{
    window.returnValue=null;
    window.close(); 
}
</script>