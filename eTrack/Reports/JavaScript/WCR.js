<script type="text/javascript" language ="javascript">
function ReturnResult()
{
var obj =document.getElementById("txtAsOfDate");
if(obj.value.Trim()==""){alert("As Of Date must be input");return false;}
return GetQueryResult();
}


function GetQueryValue()
{
    var strValue="";
    //As of Day
    var obj =document.getElementById("txtAsOfDate");
    if(obj.value.Trim()==""){alert("As Of Date must be input");return false;}
    strValue=ConvertDate(obj.value);
    return strValue;
}
</script>

