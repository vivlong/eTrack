<script type="text/javascript" language ="javascript">
function GetQueryValue()
{
    var strValue="";
    strValue=strValue+document.getElementById("hid_ProductCodePass").value;
    return strValue;
}

//set strWhere value
function GetQuery()
{
    //SearchField
    var strValue="";
    var obj=document.getElementById("txtCustomerCode");
    if(obj.value.Trim()!=""){strValue = strValue + " and a.pc like '%" + obj.value.Trim() + "%' ";}
    var obj=document.getElementById("txtProductCode");
    if(obj.value.Trim()!=""){strValue = strValue + " and a.pc like '%" + obj.value.Trim() + "%' ";}
    obj=document.getElementById("txtBrandName");
    if(obj.value.Trim()!=""){strValue +="  and a.bn like '%"+obj.value+"%'  ";}
    obj=document.getElementById("txtWarehouseCode");
    if(obj.value.Trim()!=""){strValue +="  and a.wc like '%"+obj.value+"%'  ";}
    strWhere+=strValue;
    obj=document.getElementById("txtDateFrom");
    var strDateFrom=obj.value.Trim();
    if(strDateFrom.Trim()!="")
    {strWhere+=" and Convert(varchar(10), a.md, 20) >='"+ConvertDate(strDateFrom) + "' ";
     document.getElementById("hidDateFrom").value=ConvertDate(strDateFrom);
    }
    obj=document.getElementById("txtDateTo");
    var strDateTo=obj.value;
    if(strDateTo.Trim()!=""){strWhere+=" and Convert(varchar(10), a.md, 20) <='"+ConvertDate(strDateTo) + "' ";
    document.getElementById("hidDateTo").value=ConvertDate(strDateTo);
    }
}

</script>
