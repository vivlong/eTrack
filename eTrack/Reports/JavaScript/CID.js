<script type="text/javascript" language ="javascript">
function ReturnResult()
{
var obj1 =document.getElementById("txtDateFrom");
var obj2 =document.getElementById("txtDateTo");
if(obj1.value.Trim()==""){alert("Date From must be input");return false;}
if(obj2.value.Trim()==""){alert("Date To must be input");return false;}
return GetQueryResult();
}
function GetQueryValue()
{
    var strValue="";
    //As of Day
    var obj1 =document.getElementById("txtDateFrom");
    var obj2 =document.getElementById("txtDateTo");
    if(obj1.value.Trim()==""){alert("Date From must be input");return false;}
    if(obj2.value.Trim()==""){alert("Date To must be input");return false;}
    strValue=ConvertDate(obj1.value);
    strValue=strValue+"@"+ConvertDate(obj2.value);
    return strValue;
}

</script>

