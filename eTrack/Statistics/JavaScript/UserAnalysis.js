<script type="text/javascript" language ="javascript">
 function DropDownBind(drobj)
 {
    var strValue = drobj.value;
        context=divType2;
    var arg="BindDrowDown"+ParSeparator+strValue;
    <%= ClientScript.GetCallbackEventReference(Me,"arg","setDropDownBind","context") %>;
 }
function setDropDownBind(result,context)
{
    var strResult=result.split(ParSeparator);
    context.innerHTML=strResult[1];
}    
 function Showcb(drobj)
 {
    var strValue = drobj.value;
        context=divType2;
    if(strValue=="4"){divexclude.style.display="none";}
    else{divexclude.style.display="inline";}
 }
 //get control search value
 function GetUserAnalysisQuery()
{
    var strValue="";
    //drShow
    var obj=document.getElementById("drShow");
    alert(obj.options[obj.selectedIndex].text);
    strValue=strValue+ obj.options[obj.selectedIndex].text;
    //cbexclude
     obj=document.getElementById("cbexclude");
    strValue=strValue+ColSeparator+obj.options[obj.selectedIndex].checked;
    //txtDateFrom
    obj=document.getElementById("drProductCode");
    strValue=strValue+obj.value;
    //txtDateTo
    obj=document.getElementById("txtDateTo");
    strValue=strValue+obj.value;
    strValue=strValue+document.getElementById("hid_AddField").value;
    return strValue;
}
 function GetQuery()
{
     strWhere="";
     
     var obj=document.getElementById("drShow");
     var strValue=obj.options[obj.selectedIndex].value

    var strwhere1 =" and ShipmentType <> 'M' And StatusCode <> 'DEL' ";
    var strwhere2 =" and JobNo Not In (Select [Item Job No] from Iv_All_Invoice_2 Where [Item Job No] Is Not NULL And Status <> 'DEL' And [Trx Type] IN ('1','2','3','4','5'))  ";
    var strwhere3 =" And JobNo In (Select [Item Job No] from Pl_All_Purchase_2 Where [Item Local Amt] >0 and Status <> 'DEL' And [Trx Type] <> '0' And [Trx Type] <> '9')  ";
    var strwhere4 =" And JobNo IN (Select JobNo From Jmjm2 Where Amt <>0)";
    var strwhere5 =" AND JobNo IN (SELECT JobNo FROM Jmjm2 WHERE LocalAmt<>0 AND CostAmt=0 AND ActualFlag IS NULL) ";
    var strwhere6 =" StatusCode <> 'DEL' ";
    if(strValue!="4")
    {
        obj=document.getElementById("cbexclude");
        var strcbexclude=obj.checked
        if(strValue=="1" && strcbexclude ==false){strWhere=strwhere2 }
        if(strValue=="1" && strcbexclude ==true){strWhere= strwhere2 + strwhere4 }
        
        if(strValue=="2" && strcbexclude ==false){strWhere=strwhere2 + strwhere3; }
        if(strValue=="2" && strcbexclude ==true){strWhere=strwhere2 + strwhere3 +strwhere4; }
        
        
        if(strValue=="3" && strcbexclude ==false){strWhere=strwhere5 + strwhere6;   }
        if(strValue=="3" && strcbexclude ==true){strWhere=strwhere4 + strwhere5 + strwhere6; }
    }
    obj=document.getElementById("txtDateFrom");
    var strUserDateFrom=obj.value.Trim();
    if(strUserDateFrom!="")
    {
    strWhere+=" and Convert(varchar(10), JobDate, 20) >='"+ConvertDate(strUserDateFrom) + "'";
    }
    obj=document.getElementById("txtDateTo");
    var strUserDateTo=obj.value;
    if(strUserDateTo!=""){strWhere+=" and Convert(varchar(10), JobDate, 20) <='"+ConvertDate(strUserDateTo) + "'";}
    //drShow
 }
function ConvertDate(strDate)
{
  strDate=strDate.substr(6)+"-"+strDate.substr(3,2)+"-"+strDate.substr(0,2);
  return strDate;
}
</script>
