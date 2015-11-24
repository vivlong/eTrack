<script language="javascript" type="text/javascript">

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

function ItemClick(Code,name)
{
  if(name==null){window.returnValue=Code;}
  else{window.returnValue=Code+ColSeparator+ name;}
  window.close(); 
}

function CloseWindow(flag)
{
    window.returnValue=null;
    window.close(); 
}
</script>